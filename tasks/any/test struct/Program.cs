using System;
using static System.Console;

namespace test_struct
{
    struct Coordinates
    {
        public int x;
        public int y;

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[5, 5];
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    a[i, j] = random.Next(10, 100);
                }
            }
            WriteLine();

            int[] minelem = new int[5];
            for (int i = 0; i < 5; i++)
            {
                int minLine = a[i, 0];
                int jmin = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (a[i, j] < minLine)
                    {
                        minLine = a[i, j];
  //                     // Coordinates i = new Coordinates();
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    Write(" ");
                    if ((jmin == j))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;

                        minelem[i] = a[i, j];
                    }
                    Write("{0}", a[i, j]);
                    Console.ResetColor();
                }
                WriteLine();
            }

        }
    }
}
