using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minesweeper
{
    public class Program // bija internal class Program
    {
        static void Main(string[] args)
        {
            Mines mines = new Mines();
            //mines.DrawPlayBoard();
            mines.MinePlanter();
            mines.CoordinateInput();
            //mines.IsUncovered();
        }

       


        //}
        //THIS WILL BE FULLY CHANGED
        /* static bool again()
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
        */
    }

}
