using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PluginsConventionLibrary.Plugins;
using LibraryBusinessLogic.BusinessLogics;
using LibraryDatabaseImplement.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using Unity;
using ComponentsLibrary.MyUnvisualComponents;
using ComponentsLibrary.BasharinUnvisualComponents;
using DocumentFormat.OpenXml.Bibliography;
using ComponentsLibrary.RomanovaUnvisualComponents;
using DocumentFormat.OpenXml.Office2010.CustomUI;

namespace LibraryView
{
    public partial class FormMain : Form
    {
        private ContextMenuStrip contextMenu = new ContextMenuStrip();
        private readonly IBookLogic _bookLogic;

        public FormMain(IBookLogic bookLogic)
        {
            InitializeComponent();
            _bookLogic = bookLogic;

            // создаем элементы меню
            ToolStripMenuItem addMenuShape = new ToolStripMenuItem("Справочник");
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить книгу");
            ToolStripMenuItem updateMenuItem = new ToolStripMenuItem("Изменить книгу");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Удалить книгу");
            ToolStripMenuItem simpleDocMenuItem = new ToolStripMenuItem("Простой документ");
            ToolStripMenuItem tableMenuItem = new ToolStripMenuItem("Таблица");
            ToolStripMenuItem diagramMenuItem = new ToolStripMenuItem("Диаграмма");

            // добавляем элементы в меню
            contextMenu.Items.AddRange(new[] { addMenuItem, updateMenuItem, deleteMenuItem, simpleDocMenuItem, tableMenuItem, diagramMenuItem });

            // ассоциируем контекстное меню с узлом дерева
            romanovaListBox.ContextMenuStrip = contextMenu;

            // устанавливаем обработчики событий для меню
            addMenuShape.Click += ShapesToolStripMenuItem_Click;
            addMenuItem.Click += AddElementToolStripMenuItem_Click;
            updateMenuItem.Click += UpdElementToolStripMenuItem_Click;
            deleteMenuItem.Click += DelElementToolStripMenuItem_Click;
            simpleDocMenuItem.Click += WordDocToolStripMenuItem_Click;
            tableMenuItem.Click += PdfDocToolStripMenuItem_Click;
            diagramMenuItem.Click += ExcelDocToolStripMenuItem_Click;
        }

        private Dictionary<string, IPluginsConvention> LoadPlugins()
        {
            // TODO Заполнить IPluginsConvention
            // TODO Заполнить пункт меню "Справочники" на основе IPluginsConvention.PluginName
            // TODO Например, создавать ToolStripMenuItem, привязывать к ним обработку событий и добавлять в menuStrip
            // TODO При выборе пункта меню получать UserControl и заполнять элемент panelControl этим контролом на всю площадь
            // Пример: panelControl.Controls.Clear(); panelControl.Controls.Add(ctrl);
            return new Dictionary<string, IPluginsConvention>();     
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control) 
            {
                return; 
            }

            switch (e.KeyCode)
            { 
                case Keys.A: AddNewElement(); 
                    break; 
                case Keys.U:
                    UpdateElement();
                    break; 
                case Keys.D:
                    DeleteElement(); 
                    break;
                case Keys.S:
                    CreateWordReadersTable();
                    break; 
                case Keys.T: 
                    CreatePdfBooks(); 
                    break; 
                case Keys.C: 
                    CreateExcelShapes();
                    break;
            }
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewElement()
        {
            var form = Program.Container.Resolve<FormBook>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void UpdateElement()
        {
            var form = Program.Container.Resolve<FormBook>();
            form.Id = Convert.ToInt32(romanovaListBox.GetSelectedItem<Book>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteElement()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(romanovaListBox.GetSelectedItem<Book>().Id);
                try
                {
                    _bookLogic.Delete(new BookBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void CreateWordReadersTable()
        {
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

        private void CreatePdfBooks()
        {
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

        private void CreateExcelShapes()
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

        private void ShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormShape>();
            form.ShowDialog();
        }

        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) => AddNewElement();

        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) => UpdateElement();

        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) => DeleteElement();

        private void WordDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateWordReadersTable();

        private void PdfDocToolStripMenuItem_Click(object sender, EventArgs e) => CreatePdfBooks();

        private void ExcelDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateExcelShapes();
    }
}
