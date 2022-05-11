using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
      public class CellStruct
        {
            public bool hasFlag;
            public bool hasMine;
            public bool isUncovered;
            public int neighbourBombs;
        }
}
