using System;
using static System.Console;

namespace part_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter n: ");
            int n = int.Parse(ReadLine());

            WriteLine("Enter a: ");
            int a = int.Parse(ReadLine());

            WriteLine("Enter b: ");
            int b = int.Parse(ReadLine());

            Random random = new Random();
            int[,] dec = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                if (a < b)
                {
                    int k = random.Next(a, b + 1);
                    int j = random.Next(a, b + 1);
                    Write(" [{0},{1}]", k, j);
                }
                else
                {
                    int k = random.Next(b, a + 1);
                    int j = random.Next(b, a + 1);
                    Write(" [{0},{1}]", k, j);
                }

            }
        }
    }
}
