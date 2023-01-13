using System;
using static System.Console;


    class Program       // метод хорд
    {
        static void Main(string[] args)
        {
            double e = Math.Pow(10, -7);
            
            Console.WriteLine("Введіть початок інтервалу: ");
            double x0 = Convert.ToDouble(ReadLine());
            Console.WriteLine("Введіть кінець інтервалу: ");
            double x1 = Convert.ToDouble(ReadLine());            //  [-3;-1.35]   [-1.15;1.15]  [1.6;2.7]
            
            // double x0 = -3;
            // double x1 = 1.35;

            double x = ChordMethod(x0, x1, e);
            Console.WriteLine(x);
        }


        // x^3+cos^2x-5x=3   [-inf,inf]
        public static double f(double x)
        {
            return Math.Pow(x,3) + Math.Pow(Math.Cos(x),2) - 5 * x - 3;
        }

        public static double defF(double x)
        {
            return 3*Math.Pow(x,2) + Math.Sin(2*x) - 5;
        }

        
        public static double ChordMethod(double a, double b, double e)
        {
            // double xNext = 0;
            // double buff = 0;

            // do
            // {
            //     buff = xNext;
            //     xNext = b - f(b) * (a - b)/(f(a)-f(b));
                
            //     a = b;
            //     b = buff;

            //     Console.WriteLine("Next x is: {0:F07}", xNext);
            // } while (Math.Abs(xNext - b) > e);
        
            // return xNext;

            double c = 0;

            if(IsMonoton(a,b))
            {
                if(ExistRoots(a,b))
                {
                    double buff = 0;
                    int i = 0;
                    do
                    {
                        c = a - (f(a) * (b-a)) / (f(b)-f(a));

                        if(Math.Abs(c-buff) < e)
                        {
                            return c;
                        }
                        else if(f(c)*f(a)<0)
                        {
                            b = c;
                        }
                        else if(f(c)*f(a)<0)
                        {
                            a = c;
                        }
                
                        Console.WriteLine("Ітерація №{0}, наближене значення: {1:F07}", i, c);
                        
                        buff = c;
                        i++;
                    } while (Math.Abs(a-b) > e);
                    
                    
                }
                else
                {
                    Console.WriteLine("Не існує коренів.");    
                }
            }
            else{
                Console.WriteLine("Неправильний інтервал, функція не монотонна.");
            }

            return 0;
        }
        
        public static bool IsMonoton(double a, double b)
        {
            double step = 0.00001;
            bool grow = f(a) < f(a + step);
            bool decrease = f(a) > f(a + step);
            
            if(grow)
            {
                while(a < b)
                {
                    if(f(a) < f(a + step) != grow)
                        return false;
                    a+=step; 
                }
            }
            else if(decrease)
            {
                while(a < b)
                {
                    if(f(a) > f(a + step) != decrease)
                        return false;
                    a+=step; 
                }
            }
            return true;
        }
        public static bool ExistRoots(double a,double b)
        {
            return f(a) * f(b) < 0;
        }
    
    
       
    }
