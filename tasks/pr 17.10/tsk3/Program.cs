using System;

namespace tsk3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num: ");
            int a = int.Parse(Console.ReadLine());
            int s = 0;
            while (a>0)
            {
                s = s + a%10;
                a = a/10;
            }
        Console.WriteLine("Sum; {0}", s);
        }
    }
}
