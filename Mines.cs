using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Mines
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
        public virtual void MinePlanter() // virtual so that it could be inherited from
        {
            //Program E = new Program();
            //E.CellStruct();
            //CellStruct[,] cell = new CellStruct[boardSize + 2, boardSize + 2];
            Random rand = new Random();
            bool[] n = new bool[100];
            for (int x = 0; x < 90; x++)
            {
                n[x] = false;
            }
            for (int x = 90; x < 100; x++)
            {
                n[x] = true;
            }
            for (int x = 0; x < 100; x++)
            {
                int pos = rand.Next(100);
                bool save = n[x];
                n[x] = n[pos];
                n[pos] = save;
            }
            for (int x = 0; x < 100; x++)
            {
                int column = x % 10;
                int row = x / 10;
                cell[row, column].hasMine = n[x];
            }
            for (int x = 0; x < 100; x++)
            {
                if (n[x])
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write("#"); //■
                }
                if ((x + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
    class Draw : Mines
    {
        struct CellStruct // copied as it's inaccessible due to its protection level 
        {
            public bool hasFlag;
            public bool hasMine;
            public bool isUncovered;
            public int neighbourBombs;
        }
        const int boardSize = 10;
        CellStruct[,] cell = new CellStruct[boardSize + 2, boardSize + 2];
        bool gameOver;
        public virtual void MinePlanter()
        {
            //const int boardSize = 10; // 'Mines.boardSize' is inaccessible due to its protection level 
            //  CellStruct[,] cell = new CellStruct[boardSize + 2, boardSize + 2]; /
            
            for (int row = 0; row <boardSize; row++)
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
                        Console.Write(mineCount);
                    }
                }
            }
        }
       
    }
}
