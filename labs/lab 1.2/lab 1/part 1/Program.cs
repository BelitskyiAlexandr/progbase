using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using static System.Console;

namespace part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckArgs(args);

            if (File.Exists($"{args[0]}"))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                File.WriteAllText($"{args[0]}", String.Empty);
                File.WriteAllText($"{args[0]}", GenerateFile((GiveInt(args))));
                sw.Stop();
                WriteLine($"Tip: Specified file was rewrited");
                WriteLine(sw.Elapsed);
            }
            else
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                FileStream flstream = new FileStream($"{args[0]}", FileMode.OpenOrCreate);
                File.WriteAllText($"{args[0]}", GenerateFile((GiveInt(args))));
                sw.Stop();
                WriteLine("Tip: New file was created");
                WriteLine(sw.Elapsed);
            }
        }

        static void CheckArgs(string[] args)
        {
            if (args.Length != 2)
            {
                WriteLine("Error: Row arguments length");
                Environment.Exit(0);
            }
            else if ((args[0][0] != '.') && (args[0][1] != '/'))
            {
                WriteLine("Error: Enter a relative path to the file");
                Environment.Exit(0);
            }
            GiveInt(args);
        }

        static int GiveInt(string[] args)
        {
            int number;
            if (int.TryParse(args[1], out number))
            {
                if (number <= 0)
                {
                    WriteLine("Error: Enter positive integer number");
                    Environment.Exit(0);
                }
                return number;
            }
            else
            {
                WriteLine("Error: Second argument must be a number");
                Environment.Exit(0);
            }
            return number;
        }

        static string GenerateFile(int strings)
        {
            StringBuilder sb1 = new StringBuilder();
            string[] fullname = {"Prokhorov Ludwig", "Rusakov Yuri","Stepanov Gordey","Ilyin Mechislav","Lobanov Ernest",
            "Bespalov Mitrofan","Boris Kulikov","Veselov Anton","Sukhanov Arsen","Komissarov Klim"};
            string[] subject = { "Algebra", "Art", "Biology", "Chemistry", "English", "Geography", "Geometry", "Health", "History", "PE" };
            int[] age = { 33, 23, 45, 66, 34, 78 };

            sb1.Append("id").Append(',').Append("fullname").Append(',').Append("subject").Append(',').Append("age");


            for (int i = 1; i < strings; i++)
            {
                sb1.Append("\r\n").Append(i).Append(',').Append(fullname[new Random().Next(0, fullname.Length)]).Append(',')
                .Append(subject[new Random().Next(0, subject.Length)]).Append(',').Append(age[new Random().Next(0, age.Length)]);
            }
            return sb1.ToString();
        }
    }
}
