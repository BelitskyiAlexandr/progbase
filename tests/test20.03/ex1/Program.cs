using System;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Choose mode 'cf'(create file) 'wwe'(work with existing): ");
            string mode = ReadLine();
            if (mode == "cf")
            {
                WriteLine("Enter arguments (filename, bottom line, upper line, number of elements)");
                string s = ReadLine();
                string[] str = s.Split(' ');
                if (str.Length != 4)
                {
                    throw new Exception("Check input data");
                }
                else if (str[0].StartsWith("./"))
                {
                    if (int.TryParse(str[1], out int a) && int.TryParse(str[2], out int b) && int.TryParse(str[3], out int n))
                    {
                        if (a >= b)
                        {
                            throw new Exception("Lower line is higher than upper line");
                        }

                        string f = str[0];
                        if (GenerateNumbersFile(f, a, b, n))
                        {
                            WriteLine("File was created");
                        }
                    }
                    else
                    {
                        throw new Exception("Check input numbers");
                    }
                }
            }
            else if (mode == "wwe")
            {
                WriteLine("Enter filename: ");
                string f = ReadLine();
                if (File.Exists($"{f}"))
                {
                    if (ProcessFile(f))
                    {
                        WriteLine("Tip: Process was successful");
                    }

                }
            }
            else
            {
                throw new Exception("Unknown mode");
            }
        }

        static bool GenerateNumbersFile(string f, int a, int b, int n)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int value = random.Next(a, b);
                StreamWriter sw = new StreamWriter(f, true);
                sw.WriteLine(value);
                sw.Close();
            }
            return true;
        }

        static ListInt ReadSpecificNumbersFromFile(string f)
        {
            var list = new ListInt();
            StreamReader sr = new StreamReader(f);
            string s = "";
            while (true)
            {
                s = sr.ReadLine();
                if (s == null)
                {
                    break;
                }
                if (int.TryParse(s, out int value))
                {
                    if (value > 0)
                    {
                        list.Add(value);
                    }
                }
            }
            sr.Close();
            return list;
        }

        static bool ProcessFile(string f)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var list = ReadSpecificNumbersFromFile(f);
            for (int i = 1; i < list.GetCount() - 1; i++)
            {
                while (true)
                {
                    if (list.GetAt(i) < list.GetAt(i - 1))
                    {
                        if (i >= list.GetCount())
                        {
                            break;
                        }
                        else
                        {
                            list.Remove(list.GetAt(i));
                        }                        
                    }
                    else
                    {
                        break;
                    }
                }
            }
            sw.Stop();
            WriteLine("Time: ", sw.Elapsed);
            PrintList(list);
            return true;
        }

        static void PrintList(ListInt list)
        {
            for (int i = 0; i < list.GetCount(); i++)
            {
                Write($"[{list.GetAt(i)}] -> ");
            }
        }
    }
}
