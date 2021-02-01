using System;
using System.Collections.Generic;

namespace list
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> numbers = new List<int>() { 4, 2, 1, 5 };
            GetSums(numbers);
        }

        public static int Count { get; }
        public static List<int> GetSums(List<int> numbers)
        {
            // Write your code here...
            List<int> sums = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    sum = sum + numbers[j];
                }
                numbers.RemoveAt(0);
                sums.Add(sum);
                i = -1;
            }
            sums.Add(0);
            foreach (int i in sums)
            {
                Console.WriteLine(i);
            }
            return sums;
        }
    }
}
