using PluginsConventionLibrary.Plugins;
using System.ComponentModel.Composition;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using PluginsConventionLibrary.Forms;
using ComponentsLibrary.MyUnvisualComponents;
using ComponentsLibrary.BasharinUnvisualComponents;
using ComponentsLibrary.RomanovaUnvisualComponents;
using ComponentsLibrary.RomanovaVisualComponents;
using LibraryBusinessLogic.BusinessLogics;
using LibraryDatabaseImplement.Implements;

namespace PluginsConventionLibrary.MyPlugin
{
    [Export(typeof(IPluginsConvention))]
    public class MainPluginConvention : IPluginsConvention
    {
        private RomanovaListBox romanovaListBox;
        private readonly IBookLogic _bookLogic;
        private readonly IShapeLogic _shapeLogic;

        public MainPluginConvention()
        {
            _bookLogic = new BookLogic();
            _shapeLogic = new ShapeLogic();

            romanovaListBox = new RomanovaListBox();
            var menu = new ContextMenuStrip();
            var shapeMenuItem = new ToolStripMenuItem("Формы");
            menu.Items.Add(shapeMenuItem);
            shapeMenuItem.Click += (sender, e) =>
            {
                var formShape = new FormShape(_shapeLogic);
                formShape.ShowDialog();
            };
            romanovaListBox.ContextMenuStrip = menu;
            ReloadData();
        }

        /// Название плагина
        string IPluginsConvention.PluginName => PluginName();
        public string PluginName()
        {
            return "Books";
        }

        public UserControl GetControl => romanovaListBox;

        PluginsConventionElement IPluginsConvention.GetElement => GetElement();

        public PluginsConventionElement GetElement()
        {
            var book = romanovaListBox.GetSelectedItem<MainPluginConventionElement>(); ;
            MainPluginConventionElement element = null;
            if (romanovaListBox != null)
            {
                element = new MainPluginConventionElement
                {
                    Id = book.Id,
                    Title = book.Title,
                    Shape = book.Shape,
                    Annotation = book.Annotation,
                    Reader1 = book.Reader1,
                    Reader2 = book.Reader2,
                    Reader3 = book.Reader3,
                    Reader4 = book.Reader4,
                    Reader5 = book.Reader5,
                    Reader6 = book.Reader6
                };
            }
            return (new PluginsConventionElement { Id = element.Id });
        }

        public Form GetForm(PluginsConventionElement element)
        {
            var formOrder = new FormBook(_bookLogic, _shapeLogic);
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
                _bookLogic.Delete(new BookBindingModel { Id = element.Id });
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
            romanovaListBox.ClearAll();
            romanovaListBox.LayoutString("Форма {Shape} Идентификатор {Id} Название {Title} Аннотация {Annotation}", '{', '}'); ;
            var list = _bookLogic.Read(null);
            if (list != null)
            {
                foreach (var book in list)
                {
                    romanovaListBox.Fill(book);
                }
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
