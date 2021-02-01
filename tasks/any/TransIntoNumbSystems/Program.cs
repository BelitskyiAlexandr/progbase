using System;
using System.Diagnostics;

namespace TransIntoNumbSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTests();

            

            Console.WriteLine("Write number: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Write base number: ");
            int bass = int.Parse(Console.ReadLine());

            if (bass > 36 || bass < 2)
            {
                Console.WriteLine("Error: check correctness of base number.");
            }
            else
            {
                Console.WriteLine("The number [{0}] in [{1}] base is {2}", num, bass, ToAnoterSystem(num, bass));
            }
        }

        static string ToAnoterSystem(int num, int bass)
        {
            const string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int len = (int)Math.Log(num, bass) + 1;
            var digits = new char[len];

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                num = Math.DivRem(num, bass, out int rem);
                digits[i] = alphabet[rem];
            }

            return new string(digits);
        }

        static void RunTests()
        {
            Debug.Assert(ToAnoterSystem(22, 2) == "10110");
            Debug.Assert(ToAnoterSystem(22, 3) == "211");
            Debug.Assert(ToAnoterSystem(22, 6) == "34");
            Debug.Assert(ToAnoterSystem(22, 7) == "31");
            Debug.Assert(ToAnoterSystem(22, 9) == "24");

            Debug.Assert(ToAnoterSystem(22, 10) == "22");

            Debug.Assert(ToAnoterSystem(22, 11) == "20");
            Debug.Assert(ToAnoterSystem(44, 17) == "2A");
            Debug.Assert(ToAnoterSystem(44, 22) == "20");
            Debug.Assert(ToAnoterSystem(222, 28) == "7Q");
            Debug.Assert(ToAnoterSystem(222, 35) == "6C");
        }

    }
}
