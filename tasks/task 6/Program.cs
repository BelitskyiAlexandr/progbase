using System;

namespace task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            Console.WriteLine("Enter x: ");
            x = double.Parse(Console.ReadLine());
            double y;
            Console.WriteLine("Enter y: ");
            y = double.Parse(Console.ReadLine());
            double z;
            Console.WriteLine("Enter z: ");
            z = double.Parse(Console.ReadLine());
            double a, b, c, d;
            b = Math.Pow(x,y + 1)/(Math.Pow(x-y, 1/z));
            c = 1*y + z/x;
            d = Math.Sqrt((Math.Abs(Math.Cos(y)/Math.Sin(x)+2)));
            a = b + c + d;
            Console.WriteLine("a = {0}.", a);
        }
    }
}
