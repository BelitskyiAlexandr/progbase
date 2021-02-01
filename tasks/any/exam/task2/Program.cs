using System;
using static System.Console;
using System.IO;

namespace task2
{
    struct Circle
    {
        public int x;
        public int y;
        public int radius;
    }

    class Program
    {
        static Circle[] circles = new Circle[0];
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                WriteLine("Error: there must be 3 arguments");
                Environment.Exit(0);
            }

            string inFilePath = $"/home/alexandr/progbase/progbase/tasks/any/exam/task2/{args[0]}";
            var isExistInFile = File.Exists(inFilePath);

            string outFilePath = $"/home/alexandr/progbase/progbase/tasks/any/exam/task2/{args[1]}";
            var isExistOutFile = File.Exists(outFilePath);


            if (isExistInFile)
            {
                string[] lines = File.ReadAllLines($"./{args[0]}");

                int i = 0;
                string[] items = new string[3];
                foreach (string line in lines)
                {
                    items = line.Split(',');
                    circles[i].radius = int.Parse(items[2]);
                    circles[i].y = int.Parse(items[1]);
                    circles[i].x = int.Parse(items[0]);
                    i++;
                }

                string text;
                string[] str = new string[lines.Length];

                for (int j = 0; i < lines.Length; j++)
                {
                    double length = 2 * Math.PI * circles[j].radius;
                    int N = Convert.ToInt32(args[2]);
                    if (length > N)
                    {
                        if ((circles[j].x > 0) && (circles[j].y > 0))
                        {
                            string strin = string.Join(",", circles[j].x, circles[j].y, circles[j].radius);
                            str[j] = strin;
                        }
                    }
                }
                text = string.Join("\r\n", str);

                if (isExistOutFile)
                {
                    File.WriteAllText(args[1], text);
                }
                else
                {
                    File.AppendAllText($"/home/alexandr/progbase/progbase/tasks/any/exam/task2/{args[1]}", text);
                }
            }
            else
            {
                Console.WriteLine("Error: Input file doesn't exist");
            }
        }
    }
}
