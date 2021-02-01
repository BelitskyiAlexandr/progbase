using System;
using static System.Console;

namespace цикл_зсув_на_к
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter n: ");
            int n = int.Parse(ReadLine());
            WriteLine("Enter k: ");
            int k = int.Parse(ReadLine());

            //добавить проверки для n и k

            int[] a = new int[n];
            Random rnd = new Random();

            //заполняем массив рандом числами
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(-10, 10);
                Write(" {0}", a[i]);
            }

            WriteLine();
            WriteLine();

            //циклически двигаем элементы влево на k позиций
            int buf = a[0];
            for (int j = 0; j < k; j++)
            {
                buf = a[0];
                for (int i = 0; i < n - 1; i++)
                {
                    a[i] = a[i + 1];
                }
                a[n - 1] = buf;
            }

            //вывод миссива
            for (int i = 0; i < n; i++)
                Write(" {0}", a[i]);
        }
    }
}
