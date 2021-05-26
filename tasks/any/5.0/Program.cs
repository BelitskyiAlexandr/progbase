using System;
using static System.Console;

namespace deleteElOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr = new int[5] { 44, 33, 22, 5, 11 };
            // int indexDel = 2;
            // arr = DelEl(arr, indexDel);
            // foreach (int i in arr)
            // {
            //     Write(" " + i);
            // }
            // WriteLine();
        
            int[] arr = new int [5];
            arr[0] = 2;
            WriteLine(arr.Length);
        }

        static int[] DelEl(int[] arr, int index)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > index - 1)
                {
                    arr[i - 1] = arr[i];
                }
                if (i == arr.Length - 1)
                {
                    Array.Resize(ref arr, arr.Length - 1);
                }
            }
            return arr;
        }
    }
}
