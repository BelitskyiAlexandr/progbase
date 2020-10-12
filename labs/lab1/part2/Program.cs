using System;
using static System.Console;
using static System.Math;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            double n;
            double y;
            WriteLine("Enter x: ");
            double x = double.Parse(ReadLine());
            n = (Pow(x, 2) - PI / 2) / PI;
            if ((x > -6 && x < 6) || (x >= 8 && x <= 10))
            {
                if (x != 0.25) 
                {
                    y = (-2 / (4 * x - 1) - 1);
                }
                else
                {
                    y = double.NaN;
                }
            }
            else
            {
                if (n % Floor(n) != 0) 
                {
                    y = Tan(Pow(x, 2)) + Pow(Sin(2 * x), 2);
                }
                else
                {
                    y = double.NaN;
                }
            }
            WriteLine("y = {0}.", y);
            
        }
    }
}
