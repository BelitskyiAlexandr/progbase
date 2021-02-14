using System;

namespace Tsk1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 2 ;
            while (num<=100) 
            {
                if (num % 7 == 0)
                {
                    Console.WriteLine("Num: {0}", num);
                }
            num = num+2;
            }
        }
    }
}
