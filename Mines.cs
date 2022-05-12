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
        const int boardSize = 10;

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
         
            for (int x = 90; x < 100; x++)
            {
                HasMine[x] = true;
            }
            for (int x = 0; x < 100; x++)
            {
                IsUncovered[x] = false;
            }
            for (int x = 0; x < 100; x++)
            {
                int pos = rand.Next(100);
                bool save = HasMine[x];
                HasMine[x] = HasMine[pos];
                HasMine[pos] = save;
            }
            for (int x = 0; x < 100; x++)
            {
                int column = (x % 10)+1;
                int row = (x / 10) + 1;

                cells[row, column].hasMine = HasMine[x];
            }
            for (int x = 0; x < 100; x++)
            {
                if (IsUncovered[x] == false)
                {
                    Console.Write("a");
                }
                else if (HasMine[x])
                {
                    Console.Write("■");
                }
                else
                {
                    Console.Write("."); //■
                }
                if ((x + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
      public void CountNeighbours()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    int mineCount = 0;
                    if (cells[row - 1, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row - 1, column].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row - 1, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row + 1, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row + 1, column].hasMine)
                    {
                        mineCount++;
                    }
                    if (cells[row + 1, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    cells[row, column].neighbourBombs = mineCount;
                }
            }
        } 
    }

}
