using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentsCustom
{
    public class ColumnsDataGrid
    {
        public int CountColumn { get; set; }
        public string[] NameColumn { get; set; }
        public int[] Width { get; set; }
        public bool[] Visible { get; set; }
        public string[] PropertiesObject { get; set; }
    }
}
