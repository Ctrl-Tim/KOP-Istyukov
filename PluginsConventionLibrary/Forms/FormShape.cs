using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;

namespace PluginsConventionLibrary.Forms
{
    public partial class FormShape : Form
    {
        private readonly IShapeLogic shapeLogic;
        List<ShapeBindingModel> list;

        public FormShape(IShapeLogic _shapeLogic)
        {
            InitializeComponent();
            shapeLogic = _shapeLogic;
            list = new List<ShapeBindingModel>();
        }

        private void LoadData()
        {
            try
            {
                var list1 = shapeLogic.Read(null);
                list.Clear();
                foreach (var item in list1)
                {
                    list.Add(new ShapeBindingModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                    });
                }
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormShape_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = (string)dataGridView.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(typeName))
            {
                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    shapeLogic.CreateOrUpdate(new ShapeBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value),
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    shapeLogic.CreateOrUpdate(new ShapeBindingModel()
                    {
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridView.Rows.Count == 0)
                {
                    list.Add(new ShapeBindingModel());
                    dataGridView.DataSource = new List<ShapeBindingModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1];
                    return;
                }
                if (dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1].Value != null)
                {
                    list.Add(new ShapeBindingModel());
                    dataGridView.DataSource = new List<ShapeBindingModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    shapeLogic.Delete(new ShapeBindingModel() { Id = (int)dataGridView.CurrentRow.Cells[0].Value });
                    LoadData();
                }
            }
        }
    }
}
