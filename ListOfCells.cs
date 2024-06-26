using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public static class ListOfCells
    {
        public static List<Cells> cells = [
            new Cells()
            {
                Cell1 = null,
                Cell2 = 4,
                Cell3 = 2,
                Cell4 = 4,
            },
            new Cells()
            {
                Cell1 = 4,
                Cell2 = 2,
                Cell3 = 4,
                Cell4 = 2,
            },
            new Cells()
            {
                Cell1 = 2,
                Cell2 = 4,
                Cell3 = 2,
                Cell4 = 4,
            },
            new Cells()
            {
                Cell1 = 4,
                Cell2 = 2,
                Cell3 = 4,
                Cell4 = 2,
            },
        ];
    }
}
