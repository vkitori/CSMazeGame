using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSMazeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new char[15, 30];
            int userX = 6, userY = 15;
            List<char> bag = new List<char>();
            Random rand = new Random();
                                    
            Console.CursorVisible = false;
            InizializeMap();
            
            while (true) {
                DrowMap();
                ShowBag();
                KeyMove();               
                Console.Clear();
            }

            void KeyMove()
            {
                Console.SetCursorPosition(userY, userX);
                Console.Write('#');
                ConsoleKeyInfo charKey = Console.ReadKey();
                
                switch (charKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != '*' && map[userX + 1, userY] != '^')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != '*' && map[userX - 1, userY] != '^')
                        {
                            userX--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != '*' && map[userX, userY - 1] != '^')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != '*' && map[userX, userY + 1] != '^')
                        {
                            userY++;
                        }
                        break;
                }

                if (map[userX,userY] == '?')
                {
                    map[userX, userY] = 'x';
                    bag.Add('?');                   
                }
            }

            void ShowBag()
            {
                Console.SetCursorPosition(40, 0);
                Console.Write("In your bag you have: ");
                foreach (char c in bag)
                {
                    Console.Write(c + " ");
                }
            }

            void InizializeMap()
            {
                Console.SetCursorPosition(0, 0);
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
                        map[10, 5] = '?';
                    }
                }
                // Randomly place '?'
                int questionMarksCount = rand.Next(5, 10);
                for (int i = 0; i < questionMarksCount; i++)
                {
                    int x = rand.Next(1, map.GetLength(0) - 1);
                    int y = rand.Next(1, map.GetLength(1) - 1);
                    while (map[x, y] != ' ')
                    {
                        x = rand.Next(1, map.GetLength(0) - 1);
                        y = rand.Next(1, map.GetLength(1) - 1);
                    }
                    map[x, y] = '?';
                }
            }

            void DrowMap() 
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
