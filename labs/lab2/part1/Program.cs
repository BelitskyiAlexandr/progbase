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
            WriteLine("Enter Min: ");
            double xMinn = double.Parse(ReadLine());
            WriteLine("Enter Max: ");
            double xMaxx = double.Parse(ReadLine());
            WriteLine("Enter Steps: ");
            int nSteps = int.Parse(ReadLine());
            double Int = IntFx(xMinn, xMaxx, nSteps);
            if (Int == 0)
            {

            }
            else
            {
                WriteLine("Integral by Left Rectangles : {0}", Int);
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
            if (xMin >= xMax)
            {
                WriteLine("Change limits: Min => Max");
                return 0;
            }
            if (steps <= 0)
            {
                WriteLine("Step cannot be less than 0 or 0 ");
                return 0;
            }

            for (int i = 0; i <= steps - 1; i++)
            {
                double x = xMin + i * step;
                sum += Fx(x);
            }

            double result = step * sum;
            return result;

        }
    }
}
