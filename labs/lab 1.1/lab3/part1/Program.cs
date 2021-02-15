using System;
using static System.Console;
using static System.Math;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter size of array: ");               // n розмір
            int n = int.Parse(ReadLine());
            WriteLine("Enter water level: ");
            int wlvl = int.Parse(ReadLine());
            if (n > 150)
            {
                WriteLine("Size of array can't be more than 150");
            }
            else
            {
                int[] a = new int[n];
                Random rnd = new Random();
                int min = a[0];

                for (int index = 0; index < a.Length; index++)    //запис масиву випадковими числами + обчислення мінімального 
                {
                    a[index] = rnd.Next(-7, 7);
                    int item = a[index];
                    if (item < min)
                    {
                        min = item;
                    }
                    Write(" {0}", a[index]);
                }
                WriteLine();

                int[] b = new int[n];                              //нормалізований масив
                double max = b[0];
                for (int index = 0; index < a.Length; index++)
                {
                    b[index] = a[index] - min;
                    double item = b[index];
                    if (item > max)
                    {
                        max = item;
                    }
                     Write(" {0}", b[index]);
                }
                WriteLine();

                double[] c = new double[n];                       // 0 - 1 масив
                for (int index = 0; index < b.Length; index++)
                {
                    c[index] = b[index] / max;
                     Write(" {0:F3}", c[index]);
                }
                WriteLine();


                int[] waterlvl = new int[n];                        //array of waterlevel
                int sumoflan = 0;
                for (int index = 0; index < b.Length; index++)
                {
                    waterlvl[index] = b[index] - wlvl;
                    if (waterlvl[index] < 0)
                    {
                        waterlvl[index] = 0;
                    }
                    // Write(" {0}", waterlvl[index]);
                    sumoflan = sumoflan + waterlvl[index];
                }
                // WriteLine();
                WriteLine("Volume of land above water: {0}", sumoflan);

                Pic(n, max, b, a, min, wlvl);
            }
        }

        static void Pic(int n, double max, int[] b, int[] a, int min, int wlvl )
        {
            for (int i = 0; i < n + 2; i++)
            {
                Write("-");
            }
            WriteLine(" {0}", max + 1);

            double[,] la = new double[(int)max + 1, n + 1];     
            for (int i = (int)max; i >= 1; i += -1)
            {
                Write("|");
                for (int index = 0; index < n; index++)
                {
                    b[index] = a[index] - min;
                    if (b[index] >= i)                           // цей блок можна спростити, але залишив для зручності і кращого розуміння
                    {
                        la[i, index] = 1;
                    }
                    else
                    {
                        la[i, index] = 0;
                    }
                    if (la[i, index] == 1)
                    {
                        Write("N");
                    }
                    else
                    {
                        if (i <= wlvl)
                        {
                            Write("~");
                        }
                        else
                        {
                            Write(" ");
                        }
                    }
                }
                Write("|");
                Write(" {0}", i);
                if (wlvl == i)
                {
                    Write(" (waterlevel)");
                }
                WriteLine();
            }

            for (int i = 0; i < n + 2; i++)
            {
                Write("-");
            }
            WriteLine(" 0");
        }
    }
}