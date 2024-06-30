using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Cells
    {
        public static int?[,] Arr { get; set; } = new int?[4, 4] { 
            { null, null, null, null }, 
            { null, null, null, null }, 
            { null, null, null, null }, 
            { null, null, null, null }, 
        };
    }
}
