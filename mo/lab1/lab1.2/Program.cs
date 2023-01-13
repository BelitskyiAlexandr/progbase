using System;
using static System.Console;


class Program       //спрощений Ньютона + простих ітерацій
{
    static void Main(string[] args)
    {
        double e = Math.Pow(10, -7);

        Console.WriteLine("Метод Ньютона - n, метод простих ітерацій - m");
        string s = ReadLine();
        if(s == "n")
        {
            Console.WriteLine("Введіть x0:");
            double x0 = Convert.ToDouble(ReadLine());
            NewtonMethod(x0, e);
        }
        else if(s == "m")
        {
            Console.WriteLine("Введіть початок інтервалу: ");
            double a = Convert.ToDouble(ReadLine());
            Console.WriteLine("Введіть кінець інтервалу: ");
            double b = Convert.ToDouble(ReadLine());  
            MPI(a,b,e);
        }
        else{
            Console.WriteLine("Невідома команда");
        }
        
        
        //NewtonMethod(0.1, e);
        //MPI(0, 0.12, e);
    }

    /* a7x^7+a6x^6+a5x^5+a4x^4+a3x^3+a2x^2+a1x+a0=0  
     a7=31
     a6=-210
     a5=-449
     a4=850
     a3=916
     a2=-809
     a1=-139
     a0=25
     */
    public static double f(double x)
    {
        return 31 * Math.Pow(x, 7) + (-210 * Math.Pow(x, 6)) + (-449 * Math.Pow(x, 5)) +
                +(850 * Math.Pow(x, 4)) + (916 * Math.Pow(x, 3)) + (-809 * Math.Pow(x, 2)) +
                +(-139 * Math.Pow(x, 1)) + 25;
    }

    public static double defF(double x)
    {
        return 217 * Math.Pow(x, 6) - 1260 * Math.Pow(x, 5) - 2245 * Math.Pow(x, 4) + 3400 * Math.Pow(x, 3) + 2748 * Math.Pow(x, 2) - 1618 * Math.Pow(x, 1) - 139;
    }

    public static bool IsMonotonF(double a, double b)
    {
        double step = 0.00001;
        bool grow = f(a) < f(a + step);
        bool decrease = f(a) > f(a + step);

        if (grow)
        {
            while (a < b)
            {
                if (f(a) < f(a + step) != grow)
                    return false;
                a += step;
            }
        }
        else if (decrease)
        {
            while (a < b)
            {
                if (f(a) > f(a + step) != decrease)
                    return false;
                a += step;
            }
        }
        return true;
    }
    public static bool IsMonotonDf(double a, double b)
    {
        double step = 0.00001;
        bool grow = defF(a) < defF(a + step);
        bool decrease = defF(a) > defF(a + step);

        if (grow)
        {
            while (a < b)
            {
                if (defF(a) < defF(a + step) != grow)
                    return false;
                a += step;
            }
        }
        else if (decrease)
        {
            while (a < b)
            {
                if (defF(a) > defF(a + step) != decrease)
                    return false;
                a += step;
            }
        }
        return true;
    }
    public static bool ExistRoots(double a, double b)
    {
        return f(a) * f(b) < 0;
    }

    public static double FindLambda(double a, double b)
    {
        if (IsMonotonDf(a, b))
        {
            double alpha = Math.Min(defF(a), defF(b));
            double gamma = Math.Max(defF(a), defF(b));

            double lambda = 2 / (alpha + gamma);

            return lambda;
        }
        return 200;
    }
    public static double FindQ(double a, double b)
    {
        if (IsMonotonDf(a, b))
        {
            double alpha = Math.Min(defF(a), defF(b));
            double gamma = Math.Max(defF(a), defF(b));

            double q = (alpha - gamma) / (alpha + gamma);

            return q;
        }
        return 200;
    }

    public static double NewtonMethod(double xCur, double e)
    {
        int iter = 0;
        double xNext = 0;

        do
        {
            xNext = xCur - f(xCur) / defF(xCur);
            xCur = xNext;
            iter++;

            Console.WriteLine("Next x is: {0:F07}", xNext);
        } while (Math.Abs(xNext - xCur) > e);

        return xNext;
    }

    public static double MPI(double a, double b, double e)
    {
        if (IsMonotonF(a, b))
        {
            if (ExistRoots(a, b))
            {
                double lambda = FindLambda(a, b);
                if (lambda == 200)
                {
                    Console.WriteLine("Лямбду не можна знайти, похідна не монотонна");
                }
                else
                {
                    Console.WriteLine("Ламбда: " + lambda);

                    int i = 0;
                    while (true)
                    {
                        double q = FindQ(a, b);
                        b = a - lambda * f(a);
                        if (Math.Abs(a - b) <= Math.Abs((1 - q) * e / q))
                        {
                            break;
                        }

                        a = b;
                        Console.WriteLine("Ітерація №{0}, наближене значення: {1:F07}", i, a);
                        i++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Не існує коренів.");
            }
        }
        else
        {
            Console.WriteLine("Неправильний інтервал, функція не монотонна.");
        }
        return 0;
    }
    public static bool StopLobach(double[] aMas, double[] bMas, double e)
    {
        for (int i = 0; i < aMas.Length; i++)
        {
            if (Math.Abs(Math.Pow(aMas[i], 2)) == Math.Abs(bMas[i]))
            {
                return true;
            }
        }
        return false;
    }

    public static void SolveLobach(double e)
    {
        double[] koefs = { 31, -210, -449, 850, 916, -809, -139, 25 };

        double[] newKoefs = new double[koefs.Length];

        while (!StopLobach(koefs, newKoefs, e))
        {

        }
    }
}
