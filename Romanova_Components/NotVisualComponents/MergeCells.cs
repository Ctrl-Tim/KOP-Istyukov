using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotVisualComponents
{
    public class MergeCells
    {
        public string Heading;
        public int[] CellIndexes;

        public MergeCells(string heading, int[] cellIndexes)
        {
            Heading = heading;
            CellIndexes = cellIndexes;
        }
    }
}
