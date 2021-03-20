using System;
using static System.Console;

namespace part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            WriteLine("Enter a: ");
            a = int.Parse(ReadLine());

            int b;
            WriteLine("Enter b: ");
            b = int.Parse(ReadLine());

            int c;
            c = NSD(a, b);
            WriteLine("НСД а i b = {0}", c);
            WriteLine();

            //2 виклик
            WriteLine("Enter a: ");
            a = int.Parse(ReadLine());

            WriteLine("Enter b: ");
            b = int.Parse(ReadLine());

            c = NSD(a, b);
            WriteLine("НСД а i b = {0}", c);
            WriteLine();

            //3 виклик
            WriteLine("Enter a: ");
            a = int.Parse(ReadLine());

            WriteLine("Enter b: ");
            b = int.Parse(ReadLine());

            c = NSD(a, b);
            WriteLine("НСД а i b = {0}", c);

        }

        static int NSD(int a, int b)
        {
            while (a > 0 && b > 0)

                if (a > b)
                    a %= b;

                else
                    b %= a;

            return a + b;
        }
    }
}
