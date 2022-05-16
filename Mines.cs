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
                for (int y = 1; y < 11; y++)
                {

                    cells[x, y].hasMine = HasMine[countForHasMines];
                    cells[x, y].isUncovered = IsUncovered[countForHasMines];
                    cells[x, y].neighbourBombs = NeighbourBombs[countForHasMines];
                    countForHasMines++;
                }
            }
            //Console.Write(" | ");


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
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    if (row ==0 && column > 0)
                    {
                        Console.Write($" {column} ");
                    }
                    else if (row > 0 && column == 0)
                    {
                        Console.Write(row + "|"); // + " ");
                    }
                    else if (cells[row, column].isUncovered == false) //change to false afterwards
                    {
                        Console.Write(" ? ");
                    }
                    else if (cells[row, column].hasMine)
                    {
                        Console.Write(" ■ ");
                    }
                    else if (!(row == 0) && !(column == 0))
                    {
                        Console.Write($" {cells[row, column].neighbourBombs} ");
                    }
                    //Console.Write(" | ");

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
        public void CoordinateInput()
        {

            //int X_input = 0;
            //int Y_input = 0;
            //Console.WriteLine($"\nEnter the coordinates (letter + number): ");
            //string playerInput = Console.ReadLine();
            //Console.WriteLine($"You entered: {playerInput}");
            //int X_input = 0;
            //int Y_input = 0;
            int row = 0;
            int column = 0;
            Console.WriteLine("Enter the X coordinate: ");
            string resultX;
            resultX = Console.ReadLine();
            int X_input;
            X_input = Convert.ToInt32(resultX);
            row = X_input;
            //Console.WriteLine("You entered:{0}", X_input);

            Console.WriteLine("Enter the Y coordinate: ");
            string resultY;
            resultY = Console.ReadLine();
            int Y_input;
            Y_input = Convert.ToInt32(resultY);
            column = Y_input;
            //Console.WriteLine("You entered:{0}", Y_input);


            if (cells[row, column].isUncovered == true)
            {
                Console.SetCursorPosition(row, column);
                Console.WriteLine(".");
            }
            if (cells[row, column].hasMine)
            {
                Console.SetCursorPosition(row, column);
                Console.WriteLine("■");
            }
           
           else
            {
                Console.SetCursorPosition(row, column);
                Console.WriteLine($"{cells[row, column].neighbourBombs}");
            }

        }
        public void Coordinates()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    Console.WriteLine("Enter the X coordinate: ");
                    //string resultX;
                    //resultX = Console.ReadLine();
                    int X_input;
                    X_input = Convert.ToInt32(Console.ReadLine());
                    row = X_input;
                    Console.WriteLine("You entered:{0}", X_input);

                    Console.WriteLine("Enter the Y coordinate: ");
                    //string resultY;
                    //resultY = Console.ReadLine();
                    int Y_input;
                    Y_input = Convert.ToInt32(Console.ReadLine()); ;
                    column = Y_input;
                    Console.WriteLine("You entered:{0}", Y_input);
                    continue;

                }

            }

            //public void IsUncovered()
            //{
            //        int row = 0;
            //        int column = 0;

            //        if (cells[row, column].isUncovered)
            //        {
            //            Console.Write(".");
            //        }
            //        if (cells[row, column].hasMine)
            //        {
            //            Console.Write("■");
            //        }
            //        else if (!(row == 0) && !(column == 0))
            //        {
            //            Console.Write($"{cells[row, column].neighbourBombs}");
            //        }

            //    }

            //}


        }
    }
}

