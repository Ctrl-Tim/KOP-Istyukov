using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentsCustom
{
    public partial class DataGridViewModified : UserControl
    {
        /// <summary>
        ///Инициализация DataGrid
        /// </summary>
        public DataGridViewModified()
        {
            InitializeComponent();
        }

        public int IndexRow
        {
            get { return dataGridView.SelectedRows[0].Index; }
            set
            {
                if (dataGridView.SelectedRows.Count <= value || value < 0)
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", value));
                else
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[value].Selected = true;
                }
            }
        }

        /// <summary>
        /// Метoд очистки строк DataGrid
        /// </summary>
        public void ClearDataGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }
        /// <summary>
        /// Метод конфигурации DataGridView. Отдельный метод для конфигурации столбцов.
        /// </summary>
        /// <param name="countColumn"></param>
        /// <param name=""></param>
        public void ConfigColumn(ColumnsDataGrid columnsData)
        {
            dataGridView.ColumnCount = columnsData.CountColumn;
            for (int i = 0; i < columnsData.CountColumn; i++)
            {
                dataGridView.Columns[i].Name = columnsData.NameColumn[i];
                dataGridView.Columns[i].Width = columnsData.Width[i];
                dataGridView.Columns[i].Visible = columnsData.Visible[i];
                dataGridView.Columns[i].DataPropertyName = columnsData.PropertiesObject[i];
            }
        }
        /// <summary>
        /// Полуение объекта из строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetSelectedObjectIntoRow<T>()
        {
            T objectMy = (T)Activator.CreateInstance(typeof(T));
            var propertiesObj = typeof(T).GetProperties();
            foreach (var properties in propertiesObj)
            {
                bool propIsExist = false;
                int columnIndex = 0;
                for (; columnIndex < dataGridView.Columns.Count; columnIndex++)
                {
                    if (dataGridView.Columns[columnIndex].DataPropertyName.ToString() == properties.Name)
                    {
                        propIsExist = true;
                        break;
                    }
                }
                if (!propIsExist) { throw new Exception("can not find propertie"); };
                object value = dataGridView.SelectedRows[0].Cells[columnIndex].Value;
                properties.SetValue(objectMy, value);
            }
            return objectMy;
        }

        /// <summary>
        ///  Заполнение DataGridView построчно
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectMy"></param>

        public void AddRow<T>(T objectMy)
        {
            if (objectMy == null)
                return;
            int rowId = dataGridView.Rows.Add();
            var row = dataGridView.Rows[rowId];
            var properties = objectMy.GetType().GetProperties();
            for (int i = 0; i < typeof(T).GetProperties().Length; i++)
            {
                row.Cells[i].Value = properties[i].GetValue(objectMy).ToString();
            }
        }

        private void DataGrivViewModified_Load(object sender, EventArgs e)
        {

        }
    }
}
