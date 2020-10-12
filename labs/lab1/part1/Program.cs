using System;
using static System.Console;
using static System.Math;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter a: ");
            double a = double.Parse(ReadLine());
            WriteLine("Enter b: ");
            double b = double.Parse(ReadLine());
            WriteLine("Enter c: ");
            double c = double.Parse(ReadLine());


            double d0 = ((Pow((a+3), (c+1))-10)/(a-b));
            double d1 = 4*b+(c/a);
            double d2 = Pow((a+4), ((Abs(Sin(b)))/(1+c)));
            double d = d0+d1+d2;
            WriteLine("d0 = {0}.", d0);
            WriteLine("d1 = {0}.", d1);
            WriteLine("d2 = {0}.", d2);
            WriteLine("d = {0}.", d);

        }
    }
}
