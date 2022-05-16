using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Mines
    {
        CellStruct structure = new CellStruct();
        CellStruct[,] cells = new CellStruct[boardSize + 2, boardSize + 2];
        public const int boardSize = 10;

        public Mines()

        {
            int count = 12;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    var cell = new CellStruct();
                    cells[i, j] = cell;
                }
            }
        }

        public virtual void MinePlanter()
        {
            Random rand = new Random();
            bool[] HasMine = new bool[100];
            bool [] IsUncovered = new bool[100];
            //for (int x = 0; x < 90; x++)
            //{
            //    HasMine[x] = false;
            //}
         
            /*for (int x = 90; x < 100; x++)
            {
               HasMine[x] = true;
            }
            for (int x = 0; x < 100; x++)
            {
                IsUncovered[x] = false;
            }*/
            for (int x = 0; x < 10; x++)
            {
                int pos = rand.Next(100);
                //bool save = HasMine[x];
                //HasMine[] = HasMine[pos];
                //HasMine[pos] = save;
                if (!HasMine[pos]) 
                {
                    HasMine[pos] = true;
                }
                else
                {
                    x--;
                }
            }
            for (int x = 0; x < 100; x++)
            {
                //int column = (x % 10)+1;
                //int row = (x / 10) + 1;
                int column = x % 10;
                int row = x / 10;
                cells[row, column].hasMine = HasMine[x];
            }
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   -------------------");
            
            Console.Write((char)65+" |");
            for (int x = 0; x < 100; x++)
            {
                
                if (IsUncovered[x] ==false)
                {
                    Console.Write("# ");
                }
                else if (HasMine[x])
                {
                    Console.Write("@ ");
                }
                else
                {
                    Console.Write(". "); //■
                }
                if ((x + 1) % 10 == 0)
                {
                    Console.WriteLine();
                    if (x/10<9 && x!=0) Console.Write((char)(66+x/10)+" |");
                }
            }
        }
      public void CountNeighbours()
        {
            for (int row = 0; row < boardSize; row++)
            {

                for (int column = 0; column < boardSize; column++)
                {
                    if (cells[row, column].hasMine) {
                        continue;
                    }

                    int mineCount = 0;

                    if (row!=0 && column!=0 && cells[row - 1, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (row != 0 && cells[row - 1, column].hasMine)
                    {
                        mineCount++;
                    }
                    if (row!=0 && column!= boardSize-1 && cells[row - 1, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (column!=0 && cells[row, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (column!= boardSize - 1 && cells[row, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (row!= boardSize - 1 && column!=0 && cells[row + 1, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (row != boardSize - 1 && cells[row + 1, column].hasMine)
                    {
                        mineCount++;
                    }
                    if (row != boardSize - 1 && column != boardSize-1 && cells[row + 1, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    cells[row, column].neighbourBombs = mineCount;
                }
            }
        }
        public void PrintingTheBoard(bool isMineHit)
        {
            Console.WriteLine("   0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   -------------------");

            for (int row = 0; row < boardSize; row++)
            {
                Console.Write((char)(row+65)+" |");
                for (int column = 0; column < boardSize; column++)
                {
                    if (isMineHit && cells[row, column].hasMine) {
                        Console.Write("@ ");
                        continue;
                    }

                    if (cells[row, column].isUncovered) {
                        Console.Write(cells[row, column].neighbourBombs+" ");
                        continue;
                    }

                    Console.Write("# ");
                }
                Console.WriteLine(); // \n
            }
        }

        public bool chooseCell(int[] cell) {
            cells[cell[0], cell[1]].isUncovered = true;

            return cells[cell[0], cell[1]].hasMine;
        }

        public bool hasWonGame() {
            bool hasWon=true;
            int uncoveredCellCount=0;
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    if (!cells[row, column].hasMine && cells[row, column].isUncovered)
                    {
                        uncoveredCellCount++;
                    }
                }
            }
            if (uncoveredCellCount < 90)
            {
                hasWon = false;
            }
            return hasWon;
        }
    }

}
