using System;
using static System.Console;

namespace asd_day_after
{
    class Program
    {
        static void Main(string[] args)
        {
            int d;
            int m;
            int y;
            int nd = 1;
            int ny = 1;
            int nm = 1;
            WriteLine("Enter day: ");
            d = int.Parse(ReadLine());
            WriteLine("Enter month: ");
            m = int.Parse(ReadLine());
            WriteLine("Enter year: ");
            y = int.Parse(ReadLine());
            if (d < 28)
            {
                nd = d + 1;
                nm = m;
                ny = y;
            }
            else
            {
                if (m == 2)
                {
                    if (d == 28)
                    {
                        bool l_year = Leak_year(y);
                        if (l_year)
                        {
                            nd = d + 1;
                            nm = m;
                            ny = y;
                        }
                        else
                        {
                            nd = 1;
                            nm = m + 1;
                            ny = y;
                        }
                    }
                    if (d == 29)
                    {
                        nd = 1;
                        nm = m + 1;
                        ny = y;
                    }
                }
                if ((m == 4) || (m == 6) || (m == 9) || (m == 11))
                {
                    if (d == 30)
                    {
                        nd = 1;
                        nm = m + 1;
                        ny = y;
                    }
                }
                else
                {
                    if (d == 31)
                    {
                        nd = 1;
                        nm = m + 1;
                        ny = y;
                    }
                }
                if (m == 12)
                {
                    if (d == 31)
                    {
                        nd = 1;
                        nm = 1;
                        ny = y + 1;
                    }
                }





                WriteLine("dd.mm.yyyy: {0}.{1}.{2}", nd, nm, ny);

            }
        }

        static bool Leak_year(int y)
        {
            if (y % 4 == 0)
            {
                if (y % 100 == 0)
                {
                    if (y % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

    }
}
