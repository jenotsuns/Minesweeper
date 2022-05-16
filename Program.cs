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
            do {
                Console.Clear();
                int gameStatus = 0; // 0 = in progress, 1 = win, 2 = lose
                bool isMineUncovered = false;

                Mines mines = new Mines();
                mines.MinePlanter();
                mines.CountNeighbours();
                Program program = new Program();

                while (gameStatus == 0)
                {
                    (string input, int[] cell) = program.CoordinateInput();
                    Console.Clear();
                    isMineUncovered = mines.chooseCell(cell);
                    mines.PrintingTheBoard(isMineUncovered);
                    Console.WriteLine($"\nYou entered value: {input}");
                    if (isMineUncovered)
                    {
                        gameStatus = 2;
                        Console.WriteLine("You lost!");
                    }
                    else if (mines.hasWonGame())
                    {
                        gameStatus = 1;
                        Console.WriteLine("You win!");
                    }
                }
            } while (again());
        }
   
        public (string, int[]) CoordinateInput()
        {
            int[] cellIndexes = new int[2];
            string playerInput = "";
            bool isInputCorrect = false;

            while (!isInputCorrect) {
                int rowIndex;
                int columnIndex;
                Console.WriteLine($"\nEnter the coordinates (letter + number, for example B3): ");
                playerInput = Console.ReadLine();

                // empty value?
                if (playerInput == null) {
                    Console.WriteLine($"\nEmpty value, try again.");
                    continue;
                }

                byte[] asciiValues = Encoding.ASCII.GetBytes(playerInput);

                // is first character a letter A-Z?
                if (asciiValues[0] < 65 || asciiValues[0] > 90) {
                    Console.WriteLine($"\nIncorrect letter (A-Z), try again.");
                    continue;
                }

                rowIndex = asciiValues[0] - 65;

                // row exists?
                if (rowIndex > Minesweeper.Mines.boardSize) {
                    Console.WriteLine($"\nIncorrect row letter, try again.");
                    continue;
                }

                cellIndexes[0] = rowIndex;

                // are numbers?
                if(int.TryParse(playerInput.Substring(1), out int value)) {
                    columnIndex = value;

                    // column exists?
                    if (value >= Minesweeper.Mines.boardSize) {
                        Console.WriteLine($"\nIncorrect number, try again.");
                        continue;
                    }
                } else {
                    Console.WriteLine($"\nIncorrect number, try again.");
                    continue;
                }

                cellIndexes[1] = columnIndex;
                isInputCorrect = true;
            }
            return (playerInput, cellIndexes);
        }
        static bool again()
        {
            while (true)
            {
                Console.WriteLine("Would you like to play again? (Y/N)");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'Y' || answer == 'y')
                {
                    return true;
                }

                if (answer == 'N' || answer == 'n')
                {
                    return false;
                }
                // + needs to repeat the printing loop
            }

        }
    }

}
