using System;
using static System.Console;

namespace block_1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Write 1 if you wanna convert to ASCII, write 2 if from ASCII: ");
            int k = int.Parse(ReadLine());
            if ((k == 1) || (k == 2))
            {
                WriteLine("Enter  your string: ");
                string str = ReadLine();
                if (k == 1)
                {
                    toASCII(str);
                }
                else
                {
                    fromASCII(str);
                }
            }
            else
            {
                WriteLine("Please, choose correct mode of programm");
            }
            WriteLine();
        }

        static void toASCII(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int code = Convert.ToInt32(chars[i]);
                Write(" {0}", code);
            }
        }

        static void fromASCII(string str)
        {
            string[] everynum = str.Split(" ");
            int[] nums = new int[everynum.Length];
            for (int i = 0; i < everynum.Length; i++)
            {
                nums[i] = Convert.ToInt32(everynum[i]);
                char Letter = Convert.ToChar(nums[i]);
                Write(Letter);
            }
        }
    }
}
