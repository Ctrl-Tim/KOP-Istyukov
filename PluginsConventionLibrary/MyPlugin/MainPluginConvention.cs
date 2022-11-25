using PluginsConventionLibrary.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.ViewModels;
using PluginsConventionLibrary.Plugins;
using PluginsConventionLibrary.Forms;
using ComponentsLibrary.MyUnvisualComponents;
using ComponentsLibrary.BasharinUnvisualComponents;
using ComponentsLibrary.RomanovaUnvisualComponents;

namespace PluginsConventionLibrary.MyPlugin
{
    Export(typeof(IPluginsConvention))]
    public class MainPluginConvention : IPluginsConvention
    {
        private ControlDataTableTable dataTableView;
        private readonly IBookLogic _bookLogic;
        private readonly IShapeLogic _shapeLogic;
        private List<DataTableColumnConfig> config;

        public MainPluginConvention()
        {
            dataTableView = new ControlDataTableTable();

            var menu = new ContextMenuStrip();
            var bookMenuItem = new ToolStripMenuItem("Книги");
            menu.Items.Add(bookMenuItem);
            bookMenuItem.Click += (sender, e) =>
            {
                var formBook = new FormBook(_bookLogic, _shapeLogic);
                formBook.ShowDialog();
            };
            dataTableView.ContextMenuStrip = menu;

            config = new List<DataTableColumnConfig>
            {
                new DataTableColumnConfig
                {
                    ColumnHeader = "Id",
                    PropertyName = "Id",
                    Visible = false,
                },
                new DataTableColumnConfig
                {
                    ColumnHeader = "ФИО покупателя",
                    PropertyName = "CustomerFIO",
                    Visible = true,
                    Width = 120
                },
                new DataTableColumnConfig
                {
                    ColumnHeader = "Товар",
                    PropertyName = "Product",
                    Visible = true,
                    Width = 140
                },
                new DataTableColumnConfig
                {
                    ColumnHeader = "Почта",
                    PropertyName = "Mail",
                    Visible = true,
                    Width = 200
                }
            };
            dataTableView.LoadColumns(config);
            _bookLogic = new IBookLogic();
            ReloadData();
        }

        public string PluginName => "Книги";

        public UserControl GetControl => dataTableView;

        public PluginsConventionElement GetElement => dataTableView.GetSelectedObject<PluginsConventionElement>();

        private Dictionary<string, List<(int, double)>> PdfData()
        {
            var list = _bookLogic.Read(null);
            var list_book = new Dictionary<string, int>();
            foreach (var item in list)
            {
                if (list_book.ContainsKey(item.Product))
                    list_book[item.Product]++;
                else
                {
                    list_book.Add(item.Product, 1);
                }
            }
            var list_changed = new Dictionary<string, List<(int, double)>>();
            foreach (var item in list_book)
            {
                list_changed.Add(item.Key, new List<(int, double)> { (1, item.Value) });
            }
            return list_changed;
        }

        public Form GetForm(PluginsConventionElement element)
        {
            var formOrder = new FormBook();
            if (element != null)
            {
                formOrder.Id = element.Id;
            }
            return formOrder;
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                _bookLogic.Delete(new LogicDB.BindingModels.OrderBindingModel { Id = element.Id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void ReloadData()
        {
            dataTableView.Clear();
            var data = _bookLogic.Read(null);
            if (data.Count > 0)
            {
                dataTableView.AddTable(data);
            }
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                WordTablesContext wordTablesContext = new WordTablesContext();
                string fileName = "";
                using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }
                List<string[,]> tables = new List<string[,]>();
                var list = _bookLogic.Read(null);
                if (list != null)
                {
                    foreach (var book in list)
                    {
                        string[,] readers = new string[,] { {book.Reader1, book.Reader2, book.Reader3,
                                                         book.Reader4, book.Reader5, book.Reader6 } };
                        tables.Add(readers);
                    }
                }
                wordTablesContext.SaveData(fileName, "Последние читатели, бравшие книги", tables);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                TableToPDF tableToPDF = new TableToPDF();
                string fileName = "";
                using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }

                Dictionary<int, int> rowMergeInfo = new() { { 0, 1 }, { 1, 1 }, { 2, 1 } };
                Dictionary<int, int> rowHeightInfo = new() { { 0, 15 }, { 1, 20 }, { 2, 30 }, { 3, 20 }, { 4, 150 } };
                Dictionary<Tuple<int, string>, List<string>> headers = new()
            {
                { Tuple.Create(0, "Идентификатор"), new List<string>() },
                { Tuple.Create(1, "Название"), new List<string>()},
                { Tuple.Create(2, "Описание"), new List<string>(){"Форма", "Аннотация"} }
            };
                var books = _bookLogic.Read(null);
                tableToPDF.Order = new() { "Id", "Title", "Shape", "Annotation" };
                tableToPDF.CreateDocument(fileName, "Отчёт по всем книгам", rowMergeInfo, rowHeightInfo, headers, books);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                string fileName = "";
                using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }

                LineChartConfig data = new LineChartConfig();
                data.FilePath = fileName;
                data.Header = "Линейная диаграмма";
                data.ChartTitle = "Диаграмма";
                string[] Names = { "Маленькая", "Большая" };
                string[] diapasons = { "100-120", "120-140", "140-160", "160-180", "180-200" };

                var list2D = new Dictionary<string, List<int>>();
                var books = _bookLogic.Read(null);


                for (int i = 0; i < Names.Length; i++)
                {
                    var row = new List<int>();
                    for (int j = 0; j < diapasons.Length; j++)
                    {
                        int count = 0;
                        foreach (var book in books)
                        {
                            if (book.Shape.Equals(Names[i]))
                            {
                                if (book.Annotation.Length >= 100 + j * 20 && book.Annotation.Length < 100 + (j + 1) * 20)
                                {
                                    count++;
                                }
                            }
                        }
                        row.Add(count);
                    }
                    list2D.Add(Names[i], row);
                }

                data.Values = list2D;

                RomanovaExcelDiagram diagram = new RomanovaExcelDiagram();
                diagram.CreateExcel(data);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
