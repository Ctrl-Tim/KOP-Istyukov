using System;
using ComponentsCustom;
using ComponentsCustomUnvisual.HelperModels;

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
            MyObject[] myObjects = new MyObject[2];
            dataGridViewModified.AddRow(objMy);
            dataGridViewModified.AddRow(objMy2);
        }

        private void buttonSaveStorage_Click(object sender, EventArgs e)
        {
            List<string[,]> datas = new List<string[,]>();
        }

        private void buttonSaveStorage_Click_1(object sender, EventArgs e)
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
            List<string[,]> datas = new List<string[,]>();
            string[,] data = new string[,] { { "Skalkin", "Egov" }, { "Vorinina", "Guskov" } };
            datas.Add(data);
            wordTablesContext.SaveData(fileName, "Документ с таблицами", datas);
        }

        private void buttonSaveDataChangebleWord_Click(object sender, EventArgs e)
        {
            DataClass data = new DataClass();
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
            wordTableCustom.SaveData<TestData>(new ComponentWordTableConfig<TestData>
            {
                WordInfo = new WordInfo
                {
                    FileName = fileName,
                    Title = "2 лаба по КОП"
                },
                ColumnsWidth = data.getColumnsWidth(2, 2400),
                RowsHeight = data.getRowsHeight(5, 1000),
                Headers = data.GetHeader(2),
                PropertiesQueue = data.GetHeader(2),
                ListData = data.GetTests()
            });
        }

        private void buttonGistogram_Click(object sender, EventArgs e)
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
            List<TestData> data = new List<TestData>();

            data.Add(new TestData { name = "Иван", value = 18 });
            data.Add(new TestData { name = "Николай", value = 17 });
            data.Add(new TestData { name = "Альберт", value = 19 });
            data.Add(new TestData { name = "Глеб", value = 20 });
            data.Add(new TestData { name = "Антон", value = 23 });
            LocationLegend legend = new LocationLegend();
            wordGistagram.ReportSaveGistogram(fileName, "Документ с гистограммой", "Студенты", legend, data);
        }
    }
}
