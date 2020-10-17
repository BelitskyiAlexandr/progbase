using System;

namespace tsk2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int num = 11;
            int sum = 0;
            while (num<=70)
            {
                if ((num % 3 == 0) || (num % 5 == 0))
                {
                    sum = sum + num;
            
                }
                num = num + 2;
            }
        Console.WriteLine("Sum: {0}", sum);
        }
    }
}
