using System;

namespace Task_bool
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.Write("Enter number: ");
            a = int.Parse(Console.ReadLine());
            if (a <= 100)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            if ( a % 2 == 0)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            if (a % 3 == 0)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        
        
        }
    }
}
