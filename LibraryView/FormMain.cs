using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PluginsConventionLibrary.Plugins;
using LibraryBusinessLogic.BusinessLogics;
using LibraryDatabaseImplement.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using Unity;

namespace LibraryView
{
    public partial class FormMain : Form
    {
        private readonly IBookLogic _bookLogic;

        public FormMain(IBookLogic bookLogic)
        {
            InitializeComponent();
            _bookLogic = bookLogic;
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
                    CreateSimpleDoc();
                    break; 
                case Keys.T: 
                    CreateTableDoc(); 
                    break; 
                case Keys.C: 
                    CreateChartDoc();
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

        private void CreateSimpleDoc()
        {            

        } 

        private void CreateTableDoc()
        {      

        }

        private void CreateChartDoc()
        {       

        }

        private void ShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormShape>();
            form.ShowDialog();
        }

        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) => AddNewElement();

        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) => UpdateElement();

        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) => DeleteElement();

        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateSimpleDoc();

        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateTableDoc();

        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateChartDoc();
    }
}
