using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minesweeper
{
    internal class Program
    {
       struct CellStruct
        {
            public bool hasFlag;
            public bool hasMine;
            public bool isUncovered;
            public int neighbourBombs;
        }
        const int boardSize = 10;
        CellStruct[,] cell = new CellStruct[boardSize + 2, boardSize + 2];
        bool gameOver;
 
        public void CountNeighbours()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    CellStruct[,] cell = new CellStruct[boardSize + 2, boardSize + 2];
                    int mineCount = 0; // why can't i declare it as <int mineCount;> ?
                    if (cell[row - 1, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row - 1, column].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row - 1, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row + 1, column - 1].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row + 1, column].hasMine)
                    {
                        mineCount++;
                    }
                    if (cell[row + 1, column + 1].hasMine)
                    {
                        mineCount++;
                    }
                    cell[row, column].neighbourBombs = mineCount;
                }
            }
        }
        public void CoordinateInput()
        {
            Console.WriteLine($"\nEnter the coordinates (letter + number): ");
            string playerInput = Console.ReadLine();
            Console.WriteLine($"You entered: {playerInput}");
        }
        static bool again()
        {
            while (true)
            {
                Console.WriteLine("Would you like to play again? (Y/N)");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'Y' || answer == 'y') return true;
                if (answer == 'N' || answer == 'n') return false;
                // + needs to repeat the printing loop
            }
        }
    }
    public class PrintInConsole
    {
        static void Main(string[] args)
        {

            // CountNeighbours(); // not needed i guess
            Mines mines = new Mines();
            mines.MinePlanter();
            Program program = new Program();
            program.CoordinateInput();

        }
    }
}