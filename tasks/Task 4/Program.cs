using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            Console.WriteLine("Enter x: ");
            x = double.Parse(Console.ReadLine());
            double num1 = Math.Pow(x,2)+Math.Sin(x);
            double num2 = Math.Sqrt(Math.Pow(Math.Cos(x),2)+Math.Abs(x));
            double num3 = 1/(x+3)- (Math.Pow(x, 2)+50)/2;
            Console.WriteLine("num1: {0}.", num1);
            Console.WriteLine("num2: {0}.", num2);
            Console.WriteLine("num3: {0}.", num3);
        }
    }
}
