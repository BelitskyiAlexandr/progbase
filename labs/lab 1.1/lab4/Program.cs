using System;
using Progbase.Procedural;
using static System.Console;

namespace lab4
{
    struct Point
    {
        public double x;
        public double y;
    }

    class Program
    {
        static void Main(string[] args)
        {

            const int size = 40;
            Canvas.SetSize(size, size);
            Point c = new Point();
            c.x = size / 2;
            c.y = size / 2;

            double r1 = 5;
            double r2 = 15;
            double r3 = 3;
            double alpha = Math.PI / 3;
            Point b = new Point();

            Canvas.InvertYOrientation();
            ConsoleKeyInfo keyInfo;
            Console.Clear();
            do
            {

                b.x = r2 * Math.Cos(alpha) + c.x;
                b.y = r2 * Math.Sin(alpha) + c.y;

                Canvas.BeginDraw();

                Canvas.SetColor(255, 255, 150);
                Canvas.FillCircle((int)b.x, (int)b.y, (int)r3);
                Canvas.SetColor(255, 0, 0);
                Canvas.PutPixel((int)b.x, (int)b.y);

                Canvas.SetColor(150, 255, 150);
                Canvas.FillCircle((int)c.x, (int)c.y, (int)r1);
                Canvas.SetColor(255, 0, 255);
                Canvas.PutPixel((int)c.x, (int)c.y);

                Canvas.EndDraw();

                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.W)
                {
                    if (c.y < size - 1)
                        c.y += 1;
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    if (c.y > 0)
                        c.y -= 1;
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    if (c.x < size - 1)
                        c.x += 1;
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    if (c.x > 0)
                        c.x -= 1;
                }
                else if (keyInfo.Key == ConsoleKey.Z)
                {
                    alpha += Math.PI / 10;
                }
                else if (keyInfo.Key == ConsoleKey.X)
                {
                    alpha -= Math.PI / 10;
                }
                else if (keyInfo.Key == ConsoleKey.T)
                {
                    r3 += 1;
                }
                else if (keyInfo.Key == ConsoleKey.Y)
                {
                    if (r3 > 1)
                    {
                        r3 -= 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.G)
                {
                    r2 += 1;
                }
                else if (keyInfo.Key == ConsoleKey.H)
                {
                    if (r2 > 1)
                    {
                        r2 -= 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.B)
                {
                    r1 += 1;
                }
                else if (keyInfo.Key == ConsoleKey.N)
                {
                    if (r1 > 1)
                    {
                        r1 -= 1;
                    }
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
            Console.WriteLine();
        }
    }
}
