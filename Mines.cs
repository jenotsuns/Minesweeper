using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Mines
    {
        CellStruct structure = new CellStruct();
        CellStruct[,] cells = new CellStruct[boardSize + 2, boardSize + 2];
        const int boardSize = 11;

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
            // RANDOM BOMB 10% PLANTER
            Random rand = new Random();
            bool[] HasMine = new bool[100];
            bool[] IsUncovered = new bool[100];
            int[] NeighbourBombs = new int[100];


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

            int countForHasMines = 0;

            for (int x = 1; x < 11; x++)
            {
                for(int y = 1; y < 11; y++) { 

                cells[x, y].hasMine = HasMine[countForHasMines];
                cells[x, y].isUncovered = IsUncovered[countForHasMines];
                cells[x, y].neighbourBombs = NeighbourBombs[countForHasMines];
                    countForHasMines++;
                }
            }
            Console.Write(" | ");


        //NEIGHBOURING MINE COUNTER
            for (int row = 1; row < boardSize; row++)  //1
            {
                for (int column = 1; column < boardSize; column++) //1
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
            PrintingTheBoard();
        }
        private void PrintingTheBoard()
        {
            for(int row = 0; row < boardSize; row++)
            {
                for(int column = 0; column < boardSize; column++)
                {
                    if (row == 0 && column > 0) 
                    {
                        Console.Write(column);
                    }
                    else if (row > 0 && column == 0)
                    {
                        Console.Write(row+ " ");
                    }
                    else if (cells[row, column].isUncovered == true) //change to false afterwards
                    {
                        Console.Write("?");
                    }
                    else if (cells[row, column].hasMine)
                    {
                        Console.Write("■");
                    }
                    else if (!(row == 0) && !(column == 0))
                    {
                        Console.Write($"{cells[row, column].neighbourBombs}");
                    }
                    Console.Write(" | ");

                    if ((column + 1) % 11 == 0)
                    {
                        Console.WriteLine();
                    }
                }
                if (row == 0)
                {
                    Console.WriteLine();
                }
            }
            
        }
     }
    
 }

