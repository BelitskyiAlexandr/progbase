using System;
using static System.Console;
using static System.IO.File;

namespace block4
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = ReadAllText("./data.csv");
            WriteLine(text);
            string[] str = text.Split("\r\n");
            foreach (string i in str)
            {
                Console.WriteLine(" ({0})", i);
            }
            string[] comma = text.Split(",");
            foreach (string i in comma)
            {
                Console.Write(" ({0})", i);
            }
        }
    }
}
