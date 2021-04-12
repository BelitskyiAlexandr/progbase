﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays2DConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int cols, rows;
            Console.Write("К-сть стовбців:");
            cols = Convert.ToInt32(Console.ReadLine());
            while (cols <= 0 && (!int.TryParse(Console.ReadLine(), out cols)))
            {
                Console.WriteLine("К-сть стовбців повинна бути більше нуля");
                Console.Write("К-сть стовбців:");
                cols = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("К-сть рядків:");
            rows = Convert.ToInt32(Console.ReadLine());
            while (rows <= 0 && (!int.TryParse(Console.ReadLine(), out rows)))
            {
                Console.WriteLine("К-сть рядків повинна бути більше нуля");
                Console.Write("К-сть рядків:");
                rows = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("{0}  . {1}", cols, rows);


            double[,] arr = new double[cols, rows];

            Console.WriteLine("");
            for (int c = 0; c < rows; c++)
            {
                for (int r = 0; r < cols; r++)
                {
                    arr[r, c] = (rand.Next(-278, 64)) / 10.0;
                    Console.Write($"{arr[r, c]}\t");
                }
                Console.WriteLine("");
            }

            int count = 0;
            int c3 = 0;
            int r3 = 0;

            for (c3 = 0; c3 < rows; c3++)
            {
                for (r3 = 0; r3 < cols; r3++)
                {

                    if (arr[r3, c3] > 0)
                    {
                        break;
                    }
                    if ((arr[r3, c3] <= 0) && (r3 == cols - 1))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"К-сть рядків без додатнього:{count}\n");

            //

            double sum1 = 0;
            double sum2 = 0;
            bool flag;
            do
            {
                flag = false;
                for (r3 = 0; r3 < cols - 1; r3++)
                {
                    for (c3 = 0; c3 < rows; c3++)
                    {
                        if (arr[r3, c3] > 0)
                        {
                            sum1 += arr[r3, c3];
                        }
                    }
                    int rtemp = r3 + 1;
                    for (c3 = 0; c3 < rows; c3++)
                    {
                        if (arr[rtemp, c3] > 0)
                        {
                            sum2 += arr[rtemp, c3];
                        }
                    }
                    if (sum1 > sum2)
                    {
                        double buffer = 0;
                        for (c3 = 0; c3 < rows; c3++)
                        {
                            buffer = arr[r3, c3];
                            arr[r3, c3] = arr[rtemp, c3];
                            arr[rtemp, c3] = buffer;
                        }
                        flag = true;
                    }
                }
            } while (flag);

            //

            for (int c = 0; c < rows; c++)
            {
                for (int r = 0; r < cols; r++)
                {
                    Console.Write($"{arr[r, c]}\t");
                }
                Console.WriteLine("");
            }

            // double fsum = 0, ssum = 0;
            // double tmp;
            // for (int r = 0; r < rows;)
            //     for (int c = 0; c < cols; c++)
            //     {
            //         if (arr[c, r] > 0)
            //         {
            //             fsum += arr[c, r];
            //         }
            //         if (arr[c, r + 1] > 0)
            //         {
            //             ssum += arr[c, r + 1];
            //         }
            //         if (c == cols - 1)
            //         {
            //             if (fsum < ssum)
            //             {
            //                 for (int r2 = r; r2 < rows;)
            //                     for (int c2 = 0; c2 < cols; c2++)
            //                     {
            //                         tmp = arr[c2, r2];
            //                         arr[c2, r2] = arr[c2, r2 + 1];
            //                         arr[c2, r2 + 1] = tmp;
            //                     }
            //                 r++;

            //             }
            //             else
            //             {
            //                 r++;
            //             }
            //         }
            //     }

            // for (int c = 0; c < cols; c++)
            // {
            //     for (int r = 0; r < rows; r++)
            //     {
            //         arr[c, r] = (rand.Next(-278, 784)) / 10.0;
            //         Console.Write($"{arr[c, r]}\t");
            //     }
            //     Console.WriteLine("");
            // }

            Console.ReadKey();
        }
    }
}