using System;
using static System.Console;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[10];
            FillArr(array);
            PrintArr(array);


            int min = SearchMin(array);
            int max = SearchMax(array);
            int sum = SumOfEl(array);
            double average = AverageOfEl(array);

            WriteLine(" Min element: {0}\r\n Max element: {1}\r\n Sum of elemants: {2}\r\n Average of elements {3}", min, max, sum, average);

            ShiftToLeft(array);
            PrintArr(array);
        }

        static void FillArr(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-50, 51);
            }
        }

        static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Write("[{0}] ",arr[i]);
            }
            WriteLine();
        }

        static int SearchMax(int[] arr)
        {
            int max = arr[0];
            for (int index = 0; index < arr.Length; index++)
            {
                int item = arr[index];
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        static int SearchMin(int[] arr)
        {
            int min = arr[0];
            for (int index = 0; index < arr.Length; index++)
            {
                int item = arr[index];
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        static int SumOfEl(int[] arr)
        {
            int sum = 0;
            for (int index = 0; index < arr.Length; index++)
            {
                int item = arr[index];
                sum = sum + item;
            }
            return sum;
        }

        static double AverageOfEl(int[] arr)
        {
            int sum = SumOfEl(arr);
            double average = sum / arr.Length;
            return average;
        }

        static void ShiftToLeft(int[] arr)
        {
            int buf = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }
            arr[arr.Length - 1] = buf;
        }
    }
}
