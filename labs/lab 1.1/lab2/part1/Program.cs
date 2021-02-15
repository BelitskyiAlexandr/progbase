using System;
using static System.Math;
using static System.Console;

namespace part1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double xMax = 10;
            const double xMin = -10;
            const double xStep = 0.5;
            double x = xMin;
            while (x <= xMax)
            {
                double y = Fx(x);
                Console.WriteLine("x = {0},  y = {1}", x, y);
                x = x + xStep;

            }
            WriteLine();

            //for part 2
            WriteLine("Enter Min: ");
            double xMinn = double.Parse(ReadLine());
            WriteLine("Enter Max: ");
            double xMaxx = double.Parse(ReadLine());
            WriteLine("Enter Steps: ");
            int nSteps = int.Parse(ReadLine());

            if (xMinn > xMaxx)
            {
                WriteLine("Change limits: Min > Max");

            }

            else
            {
                if (xMinn == xMaxx)
                {
                    WriteLine("If Min = Max, integral will always be 0");

                }
                else
                {
                    if (nSteps <= 0)
                    {
                        WriteLine("Step cannot be less than 0 or 0 ");

                    }
                    else
                    {
                        double Int = IntFx(xMinn, xMaxx, nSteps);
                        if (Int == 0)
                        {
                            if ((xMinn < xMaxx) && (nSteps > 0))
                            {
                                WriteLine("The space contains values that aren't included in valid range");
                            }
                        }
                        else
                        {
                            WriteLine("Integral by Left Rectangles : {0}", Int);
                        }

                    }
                }
            }



        }

        static double Gx(double x)
        {
            double gx = -2 / (4 * x - 1) - 1;
            return gx;
        }

        static double Hx(double x)
        {
            double hx = Tan(Pow(x, 2)) + Pow(Sin(2 * x), 2);
            return hx;
        }

        static double Fx(double x)
        {
            double fx;
            if ((x <= 3) && (x > -5))
            {
                fx = Gx(x);
            }
            else
            {
                fx = Hx(x);
            }
            return fx;
        }
        static double IntFx(double xMin, double xMax, int steps)
        {

            double sum = 0;
            double step = (xMax - xMin) / steps;


            for (int i = 0; i <= steps - 1; i++)
            {
                double x = xMin + i * step;
                double n = (Pow(x, 2) - PI / 2) / PI;
                if ((n % Floor(n) == 0) || ((x < 1) && (x > 0)))
                {
                    return 0;
                }
                else
                {
                    sum += Fx(x);
                }
            }

            double result = step * sum;
            return result;

        }
    }
}
