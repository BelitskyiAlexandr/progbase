using System;

namespace func
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = -10;
            while (x<=10)
            {
                double y = Math.Sin(x);
                Console.WriteLine("x = {0} y = {1}",x, y);
                x = x + 0.2;
            }
        }
    }
}
