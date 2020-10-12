using System;

namespace Task_interval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num:");
            int n = int.Parse(Console.ReadLine());
            /*
            if (n<10 && n>-5)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            
            if ((n<=-50 && n>=-90) || (n<=20 && n>-10))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            */
            if ((n<=10 && n>=-80) && (n>=-20 && n<=30))
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