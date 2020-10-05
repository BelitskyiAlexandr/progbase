using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, sum;
            double average;
            Console.WriteLine("Enter a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine(a);
            Console.WriteLine("Enter b: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine(b);
            Console.WriteLine("Enter c: ");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine(c);


            sum = a + b + c;
            Console.WriteLine("Sum: " + sum);

            average =(a+b+c)/3;
            Console.WriteLine("Average: " + average);
        }
    }
}
