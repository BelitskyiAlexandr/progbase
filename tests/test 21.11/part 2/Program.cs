using System;
using static System.Console;

namespace part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //part 1
            Write("Enter n: ");
            string Str1 = ReadLine();
            int n;
            bool isNum1 = int.TryParse(Str1, out n);
            if (isNum1)
            {
                if ((n < 1) || (n > 100))
                {
                    WriteLine("N should be in range from 1 to 100 ");
                }
                else
                {
                    Random random = new Random();
                    int[] a = new int[n];
                    int sum = 0;
                    for (int i = 0; i < n; i++)
                    {
                        a[i] = random.Next(-99, 100);
                        Write(" {0}", a[i]);
                        if ((a[i] > 0) && (a[i] % 2 != 0))
                        {
                            sum += a[i];
                        }
                    }
                    WriteLine();
                    WriteLine("Sum of positine odd elements: {0}", sum);


                    //part2
                    Write("Enter m: ");
                    string Str2 = ReadLine();
                    int m;
                    bool isNum2 = int.TryParse(Str2, out m);
                    if (isNum2)
                    {
                        if ((m < n) && (m > 0))
                        {
                            int[] b = new int[m];
                            for (int i = 0; i < m; i++)
                            {
                                Write("Enter num from -99 to 99: ");
                                b[i] = int.Parse(ReadLine());
                                if ((b[i] < -99) || (b[i] > 99))
                                {
                                    WriteLine("Nums should be in range from -99 to 99");
                                    break;
                                }
                                else
                                {
                                    for (int j = 0; j < n; j++)
                                    {
                                        if (b[i] == a[j])
                                        {
                                            WriteLine("Num {0} is in both arrays", a[j]);
                                            WriteLine();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            WriteLine("M should be in range from 0 to n ");
                        }
                    }
                    else
                    {
                        WriteLine("Please, enter integer number");
                    }
                }
            }
            else
            {
                WriteLine("Please, enter integer number");
            }
        }
    }
}
