using static System.Console;
using static System.Math;

namespace left_rec
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter Min: ");
            double xMinn = double.Parse(ReadLine());
            WriteLine("Enter Max: ");
            double xMaxx = double.Parse(ReadLine());
            WriteLine("Enter Steps: ");
            int nSteps = int.Parse(ReadLine());
            double Int = IntFx(xMinn, xMaxx, nSteps);
                WriteLine("Integral by Left Rectangles : {0}", Int);
        }

        static double IntFx(double xMin, double xMax, int steps)
        {

            double sum = 0;
            double step = (xMax - xMin) / steps;


            for (int i = 0; i <= steps - 1; i++)
            {
                double x = xMin + i * step;
                sum += Fx(x);
            }

            double result = step * sum;
            return result;

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
    }
}
