using ComponentsCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOP_Forms
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void listBoxModified_SelectedChangedEvent(object sender, EventArgs e)
        {
            labelCurrent2.Text = listBoxModified.ValueList;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBoxModified.AddItem(textBoxInputItems.Text);
            textBoxInputItems.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxModified.ClearList();
        }

        private void buttonAddText_Click(object sender, EventArgs e)
        {
            labelCurrent1.Text = textBoxModified.ValueTextBox.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            textBoxInputItems.Text = listBoxModified.ValueList;
            Console.WriteLine(listBoxModified.ValueList);
        }

        public class MyObject
        {
            public string name { get; set; }

            public int count { get; set; }
        }

        private void dataGrivViewModified_Load(object sender, EventArgs e)
        {
            MyObject objMy = new MyObject();
            objMy.count = 20;
            objMy.name = "Timofey";
            MyObject objMy2 = new MyObject();
            objMy2.count = 19;
            objMy2.name = "Aleksey";
            ColumnsDataGrid column = new ColumnsDataGrid();
            column.CountColumn = 2;
            column.NameColumn = new string[] { "name", "count" };
            column.Width = new int[] { 80, 50 };
            column.Visible = new bool[] { true, true };
            column.PropertiesObject = new string[] { "name", "count" };
            dataGridViewModified.ConfigColumn(column);
            dataGridViewModified.AddRow(objMy);
            dataGridViewModified.AddRow(objMy2);
        }

        private void dataGridViewModified_Load(object sender, EventArgs e)
        {
            MyObject objMy = new MyObject();
            objMy.name = "Timofey";
            objMy.count = 20;
            MyObject objMy2 = new MyObject();
            objMy2.name = "Aleksey";
            objMy2.count = 19;
            ColumnsDataGrid column = new ColumnsDataGrid();
            column.CountColumn = 2;
            column.NameColumn = new string[] { "name", "count" };
            column.Width = new int[] { 80, 50 };
            column.Visible = new bool[] { true, true };
            column.PropertiesObject = new string[] { "name", "count" };
            dataGridViewModified.ConfigColumn(column);
            dataGridViewModified.AddRow(objMy);
            dataGridViewModified.AddRow(objMy2);
        }

        private void buttonSaveStorage_Click(object sender, EventArgs e)
        {
            List<string[,]> datas = new List<string[,]>();
        }
    }
}
