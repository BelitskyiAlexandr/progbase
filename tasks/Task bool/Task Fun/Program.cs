using System;

namespace Task_Fun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n: ");
            double x = int.Parse(Console.ReadLine());
            
            double y;

            if (x>=0)
            {
                y=Math.Sin(Math.Pow(x, 3));
        
            }
            else
            {
                y = Math.Sin(x - Math.PI);
            }
            Console.WriteLine(" y: {0}.", y);
        }
    }
}
