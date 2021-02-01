using System;
using System.Diagnostics;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest();
        }

        static void RunTest()
        {
            Debug.Assert(ConvertToBase10("1011", 2) == 11);
            Debug.Assert(ConvertToBase10("30", 4) == 12);
            Debug.Assert(ConvertToBase10("112", 6) == 44);
            Debug.Assert(ConvertToBase10("20", 11) == 22);
            Debug.Assert(ConvertToBase10("186", 22) == 666);
            Debug.Assert(ConvertToBase10("NM", 28) == 666);
            Debug.Assert(ConvertToBase10("15", 10) == 15);
            Debug.Assert(ConvertToBase10("43T*", 36) == -1);
            Debug.Assert(ConvertToBase10("-3y", 36) == -1);
            Debug.Assert(ConvertToBase10("3424", 1) == -1);
            Debug.Assert(ConvertToBase10("S", 9) == -1);
        }

        static int ConvertDigitTo10Number(char symbol)
        {
            if (char.IsDigit(symbol))
            {
                return ((int)symbol - '0');
            }

            return (10 + (int)symbol - 'A');
        }

        static bool CheckNumber(string number, int @base)
        {
            if (@base < 2 || @base > 36)
            {
                return false;
            }

            if (number.Length == 0)
            {
                return false;
            }

            foreach (char c in number)
            {
                if (char.IsDigit(c))
                {
                    int digit = (int)c - (int)'0';
                    if (digit >= @base)
                    {
                        return false;
                    }
                }
                else if (char.IsLetter(c))
                {
                    char letter = char.ToLower(c);
                    int letterCodeDiff = (int)letter - (int)'a';
                    int digit = letterCodeDiff + 10;
                    if (digit >= @base)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        static int ConvertToBase10(string number, int @base)
        {
            number = number.ToUpper();
            if (!CheckNumber(number, @base))
            {
                return -1;
            }
            int _base = 1, res = 0;
            for (int i = number.Length - 1; i >= 0; --i)
            {
                char dig = number[i];
                res += _base * ConvertDigitTo10Number(dig);
                _base *= @base;
            }

            return res;
        }


    }
}
