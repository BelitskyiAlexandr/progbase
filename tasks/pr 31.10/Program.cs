using System;

namespace pr_31._10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] n = new double[] { -3.14, 45, 0.13, -4.123, 19, -20, 0, 21 };
            for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                Console.WriteLine("Item value at index {0} is {1}", index, item);
            }

            Console.WriteLine();

            double sum = 0;
            for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                sum = sum + item;
            }
            Console.WriteLine("Sum of elements is {0}", sum);

            Console.WriteLine();

            double possum = 0;
            for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                if (item > 0)
                {
                    possum = possum + item;
                }
            }
            Console.WriteLine("Sum of positive is {0}", possum);

            Console.WriteLine();

            double negsum = 0;
            for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                if (item < 0)
                {
                    negsum = negsum + item;
                }
            }
            Console.WriteLine("Sum of negative is {0}", negsum);

            Console.WriteLine();

            for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                if (item > 0)
                {
                    Console.WriteLine("Positive num {0} is at {1}", item, index);
                }
            }

Console.WriteLine();

            for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                if (item < 0)
                {
                    Console.WriteLine("Negative num {0} is at {1}", item, index);
                }
            }
        
        
        double min = n[0];
        double max = n[0];
        int indmin = 0;
        int indmax = 0;
        for (int index = 0; index < n.Length; index++)
            {
                double item = n[index];
                if (item < min)
                {
                    min = item;
                    indmin = index;
                }
                if (item > max)
                {
                    max = item;
                    indmax = index;
                }
            }
        Console.WriteLine("Min is {0}, index is {1}", min, indmin);
        Console.WriteLine("Max is {0}, index is {1}", max, indmax);
        }
    }
}
