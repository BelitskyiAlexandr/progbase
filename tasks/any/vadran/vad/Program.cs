using System;
using static System.Console;

namespace vadran
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 40;
            WriteLine("Enter k: ");
            int k = int.Parse(ReadLine());
            for (int i = 1; i<= m; i++)
            {
                Write("-");
                if ( i % k == 0)
                {
                    WriteLine();
                }
            }
        }
    }
}
