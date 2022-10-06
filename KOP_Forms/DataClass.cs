using ComponentsCustomUnvisual.HelperModels;

namespace KOP_Forms
{
    /// <summary>
    /// Класс-помощник для настройки конфигурации таблички с настраивыми колонками и строками (WordTableTwo)
    /// </summary>
    public class DataClass
    {
        public List<TestData> testsData = new List<TestData>();

        public List<string[,]> getListTables(int count, int width, int height)
        {
            List<string[,]> list = new List<string[,]>();

            for (int i = 0; i < count; i++)
            {
                list.Add(getStringTables(width, height));
            }
            return list;
        }

        private string[,] getStringTables(int width, int height)
        {

            string[,] tables = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tables[i, j] = testsData[i % 8].name + " " + i + "" + j;
                }
            }
            return tables;
        }

        public List<int> getColumnsWidth(int count, int width)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(width);
            }
            return list;
        }

        public List<int> getRowsHeight(int count, int height)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(height);
            }
            return list;
        }

        public List<string> GetHeader(int count)
        {
            List<string> list = new List<string>();
            if (count > 0 && count < 15)
                switch ((count % 15))
                {
                    case 3:
                        list.Add("name");
                        goto case 2;
                    case 2:
                        list.Add("age");
                        goto case 1;
                    case 1:
                        list.Add("kurs");
                        break;
                    default:
                        break;
                }
            return list;
        }

        public List<TestData> GetTests()
        {
            return testsData;
        }

        public DataClass()
        {
            testsData.Add(new TestData { name = "Иван", age = 18, kurs = 1 });
            testsData.Add(new TestData { name = "Николай", age = 17, kurs = 1 });
            testsData.Add(new TestData { name = "Альберт", age = 19, kurs = 2});
            testsData.Add(new TestData { name = "Глеб", age = 20, kurs = 3 });
            testsData.Add(new TestData { name = "Антон", age = 23, kurs = 5 });
        }
    }
}
