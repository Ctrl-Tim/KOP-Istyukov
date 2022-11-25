using System;
using System.Windows.Forms;
using System.Collections.Generic;
using PluginsConventionLibrary.Plugins;
using LibraryBusinessLogic.BusinessLogics;
using LibraryDatabaseImplement.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryContracts.ViewModels;
using Unity;
using Microsoft.IdentityModel.Tokens;

namespace LibraryView
{
    public partial class FormBook : Form
    {
        public int Id { set { id = value; } }

        private readonly IBookLogic _logic;
        private readonly IShapeLogic _logicS;

        private int? id;

        public FormBook(IBookLogic logic, IShapeLogic logicS)
        {
            InitializeComponent();
            _logic = logic;
            _logicS = logicS;
            textBoxAnnotation.startRange = 100;
            textBoxAnnotation.endRange = 200;
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            List<ShapeViewModel> viewS = _logicS.Read(null);
            if (viewS != null)
            {
                foreach (ShapeViewModel s in viewS)
                {
                    listBoxModifiedShape.AddItem(s.Name);
                }
            }
            if (id.HasValue)
            {
                try
                {
                    BookViewModel view = _logic.Read(new BookBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        listBoxModifiedShape.ValueList = view.Shape;
                        textBoxAnnotation.Txt = view.Annotation;
                        textBoxReader1.Text = view.Reader1;
                        textBoxReader2.Text = view.Reader2;
                        textBoxReader3.Text = view.Reader3;
                        textBoxReader4.Text = view.Reader4;
                        textBoxReader5.Text = view.Reader5;
                        textBoxReader6.Text = view.Reader6;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(listBoxModifiedShape.ValueList))
            {
                MessageBox.Show("Выберите форму", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxAnnotation.Txt == null)
            {
                MessageBox.Show("Заполните аннотацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxReader1.Text) || string.IsNullOrEmpty(textBoxReader2.Text) ||
                string.IsNullOrEmpty(textBoxReader3.Text) || string.IsNullOrEmpty(textBoxReader4.Text) ||
                string.IsNullOrEmpty(textBoxReader5.Text) || string.IsNullOrEmpty(textBoxReader6.Text))
            {
                MessageBox.Show("Заполните всех читателей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                _logic.CreateOrUpdate(new BookBindingModel
                {
                    Id = id,
                    Title = textBoxTitle.Text,
                    Shape = listBoxModifiedShape.ValueList.ToString(),
                    Annotation = textBoxAnnotation.Txt,
                    Reader1 = textBoxReader1.Text,
                    Reader2 = textBoxReader2.Text,
                    Reader3 = textBoxReader3.Text,
                    Reader4 = textBoxReader4.Text,
                    Reader5 = textBoxReader5.Text,
                    Reader6 = textBoxReader6.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancell_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
