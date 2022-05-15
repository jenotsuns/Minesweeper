using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Neighbors
    {
        CellStruct structure = new CellStruct();
        CellStruct[,] cells = new CellStruct[boardSize + 2, boardSize + 2];
        const int boardSize = 10;

        public Neighbors()

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
        public void CountNeighbours()
        {
            for (int row = 1; row < boardSize; row++)
            {
                for (int column = 1; column < boardSize; column++)
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
            for (int row = 1; row < boardSize; row++)
            {
                for (int column = 1; column < boardSize; column++)
                    Console.Write(" {0}", cells[row, column].neighbourBombs);

                Console.WriteLine();
            }
        }
    }
    }

    
 

