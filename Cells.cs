using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Cells
    {
        public int? Cell1 { get; set; }
        public int? Cell2 { get; set; }
        public int? Cell3 { get; set; }
        public int? Cell4 { get; set; }
        public static int?[,] Arr { get; set; } = new int?[4, 4] { 
            { null, null, null, null }, 
            { null, null, null, null }, 
            { null, null, null, null }, 
            { null, null, null, null }, 
        };
    }
}
