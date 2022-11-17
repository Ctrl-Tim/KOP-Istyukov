using ComponentsLibrary.MyUnvisualComponents.HelperModels;

namespace TestComponents
{
    /// <summary>
    /// Класс-помощник для настройки конфигурации таблички с настраивыми колонками и строками (WordTableCustom)
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
            if (count > 0 && count < 10)
                switch ((count % 10))
                {
                    case 2:
                        list.Add("name");
                        goto case 1;
                    case 1:
                        list.Add("value");
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
            testsData.Add(new TestData { name = "Иван", value = 18 });
            testsData.Add(new TestData { name = "Николай", value = 17 });
            testsData.Add(new TestData { name = "Альберт", value = 19 });
            testsData.Add(new TestData { name = "Глеб", value = 20 });
            testsData.Add(new TestData { name = "Антон", value = 23 });
        }
    }
}
