using System;
using System.Linq;
using System.Collections.Generic;

namespace koko
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<int> bowls = new List<int>() { 2, 12, 3, 10 };
            int h = 6;
            Console.WriteLine(EatingSpeed(bowls, h));
        }

        public static int Count { get; }

        public static int EatingSpeed(List<int> bowls, int h)
        {
            int head = 1;
            int tail = Int32.MaxValue;
            while (head < tail)
            {
                int mid = (tail - head) / 2 + head;
                int ctr = 0;
                for (int i = 0; i < bowls.Count; i++)
                {
                    ctr += (bowls[i] + mid - 1) / mid;
                }
                if (ctr > h)
                {
                    head = mid + 1;
                }
                else
                {
                    tail = mid;
                }
            }
            return tail;
        }
    }
}
