using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Alpha();
        if (args.Length == 1 && args[0] == "console")
        {
            ILogger logger = new ConsoleLogger();

            ProccessSets(logger);
        }
        else if (args.Length == 3 && args[0] == "csv")
        {
            if (File.Exists($"{args[1]}"))
            {
                if (File.Exists($"{args[2]}"))
                {
                    ILogger logger = new CsvFileLogger2(args[1], args[2]);

                    ProccessSets(logger);
                }
                else
                {
                    throw new FileNotFoundException("Specified file does not found");
                }
            }
            else
            {
                throw new FileNotFoundException("Specified file does not found");
            }
        }
        else
        {
            throw new FormatException("Check command format to use logger");
        }
    }

    static void PrintCommands()
    {
        Console.WriteLine(@"
Available commands to work with the database:

/c o m m a n d/   /f o r m a t/                 /e x e c u t i o n/
+------------------------------------------------------------------------------------------------------------------+
add             - {set} add {value}         -  adds the value {value} to the set {set}
contains        - {set} contains {value}    -  checks if the value {value} is in the set {set}
remove          - {set} remove {value}      -  removes the value {value} from the set {set}
clear           - {set} clear               -  clears the set {set}
log             - {set} log                 -  outputs numbers from the set {set}
count           - {set} count               -  displays the number of elements in the set {set}
read            - {set} read {file}         -  reads unique {plural} numbers from {file}
write           - {set} write {file}        -  writes to file {file} numbers from the set {set}
Overlaps        - Overlaps                  -  checks whether the current set and another set have common elements
exit            - exit                      -  exit the program
+------------------------------------------------------------------------------------------------------------------+
            ");
    }


    static void ProccessSets(ILogger logger)
    {
        ISetInt a = new SetInt();
        ISetInt b = new SetInt();
        while (true)
        {
            PrintCommands();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter command: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string str = Console.ReadLine();
            string[] command = str.Split(' ');

            Console.ForegroundColor = ConsoleColor.Yellow;
            if (str == "exit")
            {
                return;
            }
            else if (str.Contains(" add "))
            {
                ConsoleInterface.AddProcess(a, b, command, logger);
            }
            else if (str.Contains(" contains "))
            {
                ConsoleInterface.ContainsProccess(a, b, command, logger);
            }
            else if (str.Contains(" remove "))
            {
                ConsoleInterface.RemoveProccess(a, b, command, logger);
            }
            else if (str.Contains(" clear"))
            {
                ConsoleInterface.ClearProccess(a, b, command, logger);
            }
            else if (str.Contains(" log"))
            {
                ConsoleInterface.LogProccess(a, b, command, logger);
            }
            else if (str.Contains(" count"))
            {
                ConsoleInterface.CountProccess(a, b, command, logger);
            }
            else if (str.Contains(" read "))
            {
                ConsoleInterface.ReadProccess(a, b, command, logger);
            }
            else if (str.Contains(" write "))
            {
                ConsoleInterface.WriteProccess(a, b, command, logger);
            }
            else if (str.Contains("Overlaps"))
            {
                if (command.Length != 1)
                {
                    logger.LogError("Error: check correctness of command");
                }
                else
                {
                    logger.Log("Tip: Do sets have common numbers: " + a.Overlaps(b).ToString());
                }
            }
            else{
                logger.LogError("Error: unknown command");
            }
            Console.ResetColor();
        }
    }

    static void Alpha()
    {
        Console.WriteLine("Hello World!");
        var a = new SetInt();
        var b = new SetInt();

        a.Add(2);
        a.Add(3);
        a.Add(4);
        a.Add(5);
        a.Add(0);
        a.Add(-2);

        b.Add(4);
        b.Add(-14);
        b.Add(-2);
        b.Add(7);
        b.Add(8);
        b.Add(5);

        Console.WriteLine(a.Overlaps(b));

        // var logg = new CsvFileLogger2("message", "error.csv");
        // logg.Log("It's work");
        // logg.Log("Correctly");
        // logg.Log("exactly");

        // logg.LogError("it is too");
        // logg.LogError("Works correctly");

        int[] aarr = new int[16];
        int[] barr = new int[16];
        a.CopyTo(aarr);
        b.CopyTo(barr);

        foreach (var i in aarr)
        {
            Console.Write(" {0}", i);
        }
        Console.WriteLine();
        foreach (var i in barr)
        {
            Console.Write(" {0}", i);
        }
    }
}

