using System;
using static System.Console;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            Human gerd = new Human("Gerd", 44, true);
            IWater iW = gerd;
            IJuice iJ = gerd;

            gerd.Sip += DisplayMessage;

            iW.DoGulp();
            iJ.DoGulp();

            Console.WriteLine("+----------~");

            Student nick = new Student("Nick", 22, false);

            nick.Sip += delegate (string message)
            {
                Console.WriteLine(message);
            };
            iW = nick;
            iJ = nick;

            iW.DoGulp();
            iJ.DoGulp();

            Console.WriteLine("+----------~");

            Student bob = new Student("Bob", 33, true);

            bob.Sip += message => Console.WriteLine(message);
            iW = bob;
            iJ = bob;

            iW.DoGulp();
            iJ.DoGulp();

            Console.WriteLine();

            Action<int, int> DoMath;
            DoMath = bob.Add;
            Operation(36, 22, DoMath);
            DoMath = bob.Substract;
            Operation(34, 22, DoMath);

            Console.WriteLine();

            Func<int, int, int> Multiply = bob.Multiply;
            int multiResult = GetMultiply(4, 5, Multiply);
            Console.WriteLine("(Func)Multiplication result: " + multiResult);

            Console.WriteLine("+----------~");

            Teacher teacher = new Teacher("Harley", 43, "KPI", "PE");
            teacher.GivePresent("laptop");
            Console.WriteLine("Present to teacher {0}: {1}", teacher.Name, teacher.Present);

        }
        catch (HumanException ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    static int GetMultiply(int x1, int x2, Func<int, int, int> returned)
    {
        int result = returned(x1, x2);
        return result;
    }
    static void Operation(int x1, int x2, Action<int, int> doMath)
    {
        if (x1 > x2)
            doMath(x1, x2);
    }

    private static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }


}















