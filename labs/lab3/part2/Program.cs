using System;
using static System.Console;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter size of territory (number of lines  number of columns): ");
            string line = Console.ReadLine();
            string[] data = line.Split(' ');
            int n = int.Parse(data[0]);                 //first integer
            int m = int.Parse(data[1]);                 //second integer
            Random random = new Random();
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i,j] = random.Next(0,2);
                    Write(a[i,j]);
                }
            WriteLine();
            }
        }
    }
}
