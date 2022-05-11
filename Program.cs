using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mines mines = new Mines();
            mines.MinePlanter();
            Program program = new Program();
            program.CoordinateInput();
        }
        /* public override void MinePlanter() // ??
         {
             for (int row = 0; row < boardSize; row++)
             {
                 for (int column = 0; column < boardSize; column++)
                 {
                     if (cell[row, column].hasFlag)
                     {
                         Console.Write("F");
                     }
                     else if (cell[row, column].isUncovered)
                     {
                         Console.Write("#");
                     }
                     else
                     {
                        // Console.Write(mineCount); // not working
                     }
                 }
             }
         } */
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

}
