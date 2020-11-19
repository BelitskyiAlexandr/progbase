using System;
using static System.Console;
using System.Linq;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("**Enter size of territory**");
            Write("Enter length of territory: ");
            string Str1 = ReadLine();
            int n;
            bool isNum1 = int.TryParse(Str1, out n);
            if (isNum1)
            {
                Write("Enter width of territory: ");
                string Str2 = ReadLine();
                int m;
                bool isNum2 = int.TryParse(Str2, out m);
                WriteLine();
                if (isNum2)
                {
                    Random random = new Random();
                    int[,] a = new int[n, m];
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            a[i, j] = random.Next(0, 2);
                            Write(" {0}", a[i, j]);
                        }
                        WriteLine();
                    }
                    int[,] b = new int[a.GetLength(0), a.GetLength(1)];
                    Array.Copy(a, b, a.GetLength(0) * a.GetLength(1));

                    int islands = 0;
                    foreach (int i in Enumerable.Range(0, a.GetLength(0)))
                    {
                        foreach (int j in Enumerable.Range(0, a.GetLength(1)))
                        {
                            if (Land(a, i, j))
                                islands++;
                        }
                    }
                    WriteLine("Number of islands is: {0}", islands);


                    Picture(b, n, m);
                }
                else
                {
                    WriteLine("Please, enter integer number");
                }
            }
            else
            {
                WriteLine("Please, enter integer number");
            }
        }

        static bool Land(int[,] a, int i, int j)
        {
            if ((i < 0) || (i >= a.GetLength(0))) return false;
            if ((j < 0) || (j >= a.GetLength(1))) return false;

            bool island = a[i, j] == 1;

            a[i, j] = 0;

            if (island)
            {
                Land(a, i, j + 1);
                Land(a, i, j - 1);
                Land(a, i + 1, j);
                Land(a, i - 1, j);
            }

            return island;
        }

        static void Picture(int[,] b, int n, int m)
        {
            for (int i = 0; i < m + 2; i++)
            {
                if ((i == 0) || (i == m + 1))
                {
                    Write("+");
                }
                else
                {
                    Write("-");
                }
            }
            WriteLine();

            for (int i = 0; i < n; i++)
            {
                Write("|");
                for (int j = 0; j < m; j++)
                {
                    if (b[i, j] == 1)
                    {
                        Write("N");
                    }
                    else
                    {
                        Write(" ");
                    }
                }
                Write("|");
                WriteLine();
            }

            for (int i = 0; i < m + 2; i++)
            {
                if ((i == 0) || (i == m + 1))
                {
                    Write("+");
                }
                else
                {
                    Write("-");
                }
            }
            WriteLine();
        }
    }
}