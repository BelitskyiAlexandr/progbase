using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, num; 
            Console.WriteLine("Enter a number: ");
            num = int.Parse(Console.ReadLine());
            a = (num / 100) % 10;
            b = (num / 10) % 10;
            c = num % 10;
            int sum = a + c + b;
            Console.WriteLine("Sum is {0}.", sum);
        }
    }
}
