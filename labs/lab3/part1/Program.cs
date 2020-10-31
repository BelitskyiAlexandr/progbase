using System;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { -4, 4, -5, 0, 1, -4, 1, 0, 6, 0, -4 };

            double min = a[0];
            double max = a[0];
            int indmin = 0;
            int indmax = 0;
            for (int index = 0; index < a.Length; index++)
            {
                double item = a[index];
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
                Console.WriteLine("Min is {0}, index is {1}", min, indmin);
                Console.WriteLine("Max is {0}, index is {1}", max, indmax);
            }
            for (int index = 0; index < a.Length; index++)
            {
                double item = a[index];
                Console.WriteLine("Item value at index {0} is {1}", index, item);
            }


        }
    }
}

