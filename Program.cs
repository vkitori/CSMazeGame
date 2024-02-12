using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[15, 30];
            int userX = 1, userY = 1;
            Console.CursorVisible = false;

            while (true) {
                DrowMap();
                Console.SetCursorPosition(userX, userY);
                Console.Write('#');
                Console.ReadKey();
                Console.Clear();
            }

            void DrowMap() 
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (i == 0 || j == 0 || i == map.GetLength(0) - 1 || j == map.GetLength(1) - 1)
                        {
                            map[i, j] = '*';
                        }
                        else if (i == 5 && j > 10 || i == 8 && j <= 20 || i == 11 && j > 5 || i < 5 && j == 5 || i < 4 && j == 23)
                        {
                            map[i, j] = '^';
                        }
                        else
                        {
                            map[i, j] = ' ';
                        }

                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
