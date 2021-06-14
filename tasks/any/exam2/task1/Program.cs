using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args[0] == "gen_num")
        {
            ProcessGenNum(args);
        }
        else if (args[0] == "num")
        {
            ProcessNum(args);
        }
        else if (args[0] == "num_uni")
        {
            ProcessUni(args);
        }
        else if (args[0] == "gen_vec")
        {
            ProcessGenVec(args);
        }
        else if (args[0] == "vec")
        {
            ProcessVec(args);
        }
        else
        {
            Console.Error.WriteLine("Error: unknown command");
        }
    }

    public static void ProcessVec(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("Error: incorrect number of args");
            return;
        }
        if (File.Exists(args[1]))
        {
            List<Vector> vectors = XmlProcess.Deserialize(args[1]);
            int sum = 0;

            foreach(var elem in vectors)
            {
                if(IsPrimeNumber(elem.x) || IsPrimeNumber(elem.y))
                {
                    sum += 1;
                }
            }
            Console.WriteLine("Number of vectors where coordinate is prime number: {0}", sum);
        }
        else
        {
            Console.Error.WriteLine($"Error: file {args[1]} does not exists");
            return;
        }
    }

    public static bool IsPrimeNumber(int n)
    {
        var result = true;

        if (n > 1)
        {
            for (var i = 2u; i < n; i++)
            {
                if (n % i == 0)
                {
                    result = false;
                    break;
                }
            }
        }
        else
        {
            result = false;
        }

        return result;
    }

    public static void ProcessGenVec(string[] args)
    {
        if (args.Length != 5)
        {
            Console.Error.WriteLine("Error: incorrect number of args");
            return;
        }
        Random rnd = new Random();
        if ((int.TryParse(args[2], out int a) && int.TryParse(args[3], out int b) && int.TryParse(args[4], out int n)))
        {
            File.WriteAllText(args[1], String.Empty);
            List<Vector> vectors = new List<Vector>();
            for (int i = 0; i < n; i++)
            {

                int x = rnd.Next(a, b + 1);
                int y = rnd.Next(a, b + 1);

                vectors.Add(new Vector(x, y));
            }

            XmlProcess.Serialize(vectors, args[1]);
        }
        else
        {
            Console.Error.WriteLine("Error: check correctness of integer values");
            return;
        }
        Console.WriteLine("Successful");

    }

    public static void ProcessUni(string[] args)
    {
        if (args.Length != 3)
        {
            Console.Error.WriteLine("Error: incorrect number of args");
            return;
        }
        if (File.Exists(args[1]))
        {

            List<int> list = new List<int>();

            string[] numbers = File.ReadAllLines(args[1]);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (int.TryParse(numbers[i], out int num))
                {
                    CheckUniq(list, num);
                }
            }

            File.WriteAllText(args[2], String.Empty);
            foreach (var item in list)
            {
                File.AppendAllText(args[2], item + Environment.NewLine);
            }


            Console.WriteLine("Successful");
        }
    }

    public static List<int> CheckUniq(List<int> list, int num)
    {
        if (!list.Contains(num))
        {
            list.Add(num);
        }
        return list;
    }

    public static void ProcessNum(string[] args)
    {
        if (args.Length != 2)
        {
            Console.Error.WriteLine("Error: incorrect number of args");
            return;
        }
        if (File.Exists(args[1]))
        {
            StreamReader sr = new StreamReader(args[1]);
            int minOdd = 1000;
            while (sr.ReadLine() != null)
            {
                if (int.TryParse(sr.ReadLine(), out int num))
                {
                    minOdd = FindMinOdd(minOdd, num);
                }
                else
                {
                    Console.Error.WriteLine("Error: problems in reading file");
                    return;
                }
            }
            sr.Close();
            Console.WriteLine("Min odd number: {0}", minOdd);
        }
        else
        {
            Console.Error.WriteLine($"Error: file {args[1]} does not exists");
            return;
        }

    }

    private static int FindMinOdd(int min, int num)
    {
        if (Math.Abs(num) % 2 == 1)
        {
            if (min > num)
                min = num;
        }
        return min;
    }

    public static void ProcessGenNum(string[] args)
    {
        if (args.Length != 5)
        {
            Console.Error.WriteLine("Error: incorrect number of args");
            return;
        }
        StreamWriter sw = new StreamWriter(args[1]);
        Random rnd = new Random();
        if ((int.TryParse(args[2], out int a) && int.TryParse(args[3], out int b) && int.TryParse(args[4], out int n)))
        {
            if (a >= b)
            {
                Console.Error.WriteLine("Error: check correctness of limits");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                int num = rnd.Next(a, b + 1);
                sw.WriteLine(num);
            }
            sw.Close();
        }
        else
        {
            Console.Error.WriteLine("Error: check correctness of integer values");
            return;
        }



    }
}
