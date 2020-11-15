using System;
using static System.Console;
using static System.IO.File;

namespace block_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ReadAllText("./data.txt");
            WriteLine(text);
            string[] str = text.Split("\n");
            foreach (string i in str)
            {
                Console.WriteLine("({0})", i);
            }
            string[] word = text.Split(" ");
            foreach (string i in word)
            {
                Console.WriteLine("{0}", i);
            }
        }
    }
}
