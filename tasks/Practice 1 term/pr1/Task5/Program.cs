using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter num1: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num2: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter num3: ");
            c = int.Parse(Console.ReadLine());

            int min = Math.Min(a,b);
            min = Math.Min(min,c);
            int max = Math.Max(a,b);
            max = Math.Max(max,c);
            Console.WriteLine("Min: {0}.", min);
            Console.WriteLine("Max: {0}.", max);

        }
    }
}
