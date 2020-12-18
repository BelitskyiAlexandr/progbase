using System;
using System.Diagnostics;
using System.IO;

namespace lab_6._1_try
{
    class Program
    {
        enum State
        {
            NotNumber,
            Dot,
            Number
        }

        struct Options
        {
            public bool isInteractiveMode;
            public string inputFile;
            public string outputFile;

            public string parsingError;
        }

        static void Main(string[] args)
        {
            RunTests();

            Console.WriteLine("Command Line Arguments ({0}):", args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("[{0}] \"{1}\"", i, args[i]);
            }

            Options options = ParseOptions(args);
            if (options.parsingError != "")
            {
                Console.WriteLine(options.parsingError);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Interactive mode: {options.isInteractiveMode}");
                if (options.isInteractiveMode == false)
                {
                    Console.WriteLine($"Input file: {options.inputFile}");
                    Console.WriteLine($"Output: {options.outputFile}");
                }
            }



            if (options.isInteractiveMode == true)
            {
                do
                {
                    Console.Write("Enter string of nums: ");
                    string input = Console.ReadLine();
                    if (input == null || input.Length == 0)
                    {
                        Console.WriteLine("Ending processing...");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Чи рядок повністю складається з однієї сутності - {0}", CheckIntegers(input));
                        Console.WriteLine("Кількість сутностей у вхідному рядку - {0}", CountIntegers(input));
                        if (CountIntegers(input) != 0)
                        {
                            PrintIntegers(input);
                        }
                    }

                    Console.WriteLine();
                } while (true);
            }
            else
            {
                string inFilePath = $"/home/alexandr/progbase/progbase/labs/lab 6/{options.inputFile}";
                var isExistInFile = File.Exists(inFilePath);
                string outFilePath = $"/home/alexandr/progbase/progbase/labs/lab 6/{options.outputFile}";
                var isExistOutFile = File.Exists(outFilePath);


                if (isExistInFile)
                {
                    string text = File.ReadAllText(options.inputFile);

                    if (isExistOutFile)
                    {
                        string[] integers = GetAllIntegers(text);
                        string newFileText = string.Join(" ", integers);
                        File.WriteAllText(options.outputFile, newFileText);
                    }
                    else
                    {
                        PrintIntegers(text);
                    }
                }
                else
                {
                    Console.WriteLine("Error: Input file doesn't exist");
                }
            }

        }

        static void RunTests()
        {
            //CountIntegers
            Debug.Assert(CountIntegers("") == 0, "Empty sring");
            Debug.Assert(CountIntegers("gsdsf") == 0, "Only letters");
            Debug.Assert(CountIntegers("444b.") == 0, "Can't contain letter");
            Debug.Assert(CountIntegers("4334") == 0, "Must contain dot");
            Debug.Assert(CountIntegers("44.44") == 0, "Can't contain fraction");
            Debug.Assert(CountIntegers("44.bb") == 0, "Can't contain letters after dot");
            Debug.Assert(CountIntegers("44. bb.") == 1, "Can't contain letters after dot");
            Debug.Assert(CountIntegers("43. ") == 1, "Only one number");
            Debug.Assert(CountIntegers("43. 4. 543453.") == 3, "Three numbers");
            Debug.Assert(CountIntegers("..**..$.%.sd.") == 0, "Must contain integer number");
            Debug.Assert(CountIntegers(".......") == 0, "Must contain int number not only dots");
            Debug.Assert(CountIntegers("43.,645. 8.") == 3, "Punctual is normal");


            //CheckIntegers
            Debug.Assert(CheckIntegers("33.") == true);
            Debug.Assert(CheckIntegers("33. 43.") == false);
            Debug.Assert(CheckIntegers("dds") == false);
            Debug.Assert(CheckIntegers("43r.") == false);
            Debug.Assert(CheckIntegers("33. dd.") == false);
            Debug.Assert(CheckIntegers(".") == false);
            Debug.Assert(CheckIntegers(".%>#$@)#$@*$.") == false);
            Debug.Assert(CheckIntegers("33.bb") == false);
            Debug.Assert(CheckIntegers("33.,") == false);

            //GetAllIntegers
            Debug.Assert(CompareArrays(GetAllIntegers(""), new string[0] { }));
            Debug.Assert(CompareArrays(GetAllIntegers("43. "), new string[1] { "43." }));
            Debug.Assert(CompareArrays(GetAllIntegers("44. gg."), new string[1] { "44." }));
            Debug.Assert(CompareArrays(GetAllIntegers("....#@$#Y$#@!I$O."), new string[0] { }));
            Debug.Assert(CompareArrays(GetAllIntegers("44. 23."), new string[2] { "44.", "23." }));
            Debug.Assert(CompareArrays(GetAllIntegers("324.,"), new string[1] { "324." }));
            Debug.Assert(CompareArrays(GetAllIntegers("werwer."), new string[0] { }));

            //Options
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "example.txt", "-i" }), new Options
            {
                isInteractiveMode = true,
                inputFile = "",
                outputFile = "",
                parsingError = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "-o", "example.txt", "-i" }), new Options
            {
                isInteractiveMode = true,
                inputFile = "",
                outputFile = "",
                parsingError = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "-i", "-o", "example.txt" }), new Options
            {
                isInteractiveMode = true,
                inputFile = "",
                outputFile = "",
                parsingError = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "" }), new Options
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "",
                parsingError = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "-o", "example.txt" }), new Options
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "",
                parsingError = "Error: must be Interactive mode or input file",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "example.txt" }), new Options
            {
                isInteractiveMode = false,
                inputFile = "example.txt",
                outputFile = "",
                parsingError = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "-i", "-i" }), new Options
            {
                isInteractiveMode = true,
                inputFile = "",
                outputFile = "",
                parsingError = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] { "-o", "val1", "-o", "val2", "Val" }), new Options
            {
                isInteractiveMode = false,
                inputFile = "Val",
                outputFile = "val2",
                parsingError = "",
            }));
            Debug.Assert(ParseOptions(new string[] { "-o" }).parsingError != "");
            Debug.Assert(ParseOptions(new string[] { "-u" }).parsingError != "");
            Debug.Assert(ParseOptions(new string[] { "-o", "-i" }).parsingError == "");
            Debug.Assert(ParseOptions(new string[] { "example1", "examlpe2" }).parsingError != "");
        }

        static bool CheckIntegers(string str)
        {
            bool ifOne = false;
            int counter = CountIntegers(str);
            string[] integers = new string[100];
            string[] structures = new string[counter];
            integers = str.Split(' ', ',', ';');
            State state = State.NotNumber;
            if (integers.Length != 1)
            {
                return ifOne;
            }
            else
            {
                for (int i = 0; i < integers.Length; i++)
                {
                    string stringInt = integers[i];
                    state = State.NotNumber;

                    for (int j = 0; j < integers[i].Length; j++)
                    {
                        char c = stringInt[j];
                        if (state == State.NotNumber)
                        {
                            if (char.IsDigit(c))
                            {
                                state = State.Number;
                            }
                        }
                        else if (state == State.Number)
                        {
                            if ((c == '.') && (j == integers[i].Length - 1))
                            {
                                state = State.Dot;
                                ifOne = true;
                            }
                            else if (!char.IsDigit(c))
                            {
                                state = State.NotNumber;
                            }
                        }
                        else if (state == State.Dot)
                        {
                            state = State.NotNumber;
                        }
                    }
                }
            }
            return ifOne;
        }
        static int CountIntegers(string str)
        {
            int counter = 0;
            string[] integers = new string[100];
            integers = str.Split(' ', ',', ';');
            State state = State.NotNumber;

            for (int i = 0; i < integers.Length; i++)
            {
                string stringInt = integers[i];
                state = State.NotNumber;
                int dots = 0;
                for (int j = 0; j < integers[i].Length; j++)
                {
                    char c = stringInt[j];
                    if (c == '.')
                        dots++;
                }
                if (dots != 1)
                {
                    continue;
                }
                for (int j = 0; j < integers[i].Length; j++)
                {
                    char c = stringInt[j];
                    if (state == State.NotNumber)
                    {
                        if (char.IsDigit(c))
                        {
                            state = State.Number;
                        }
                    }
                    else if (state == State.Number)
                    {
                        if ((c == '.') && (j == integers[i].Length - 1))
                        {
                            state = State.Dot;
                            counter++;
                        }
                        else if (!char.IsDigit(c))
                        {
                            state = State.NotNumber;
                        }
                    }

                    else if (state == State.Dot)
                    {
                        state = State.NotNumber;
                    }
                }
            }

            return counter;
        }

        static string[] GetAllIntegers(string str)
        {

            int counter = CountIntegers(str);
            string[] integers = new string[100];
            string[] structures = new string[counter];
            integers = str.Split(' ', ',', ';');
            State state = State.NotNumber;

            int k = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                string stringInt = integers[i];
                state = State.NotNumber;
                int dots = 0;
                for (int j = 0; j < integers[i].Length; j++)
                {
                    char c = stringInt[j];
                    if (c == '.')
                        dots++;
                }
                if (dots != 1)
                {
                    continue;
                }
                for (int j = 0; j < integers[i].Length; j++)
                {
                    char c = stringInt[j];
                    if (state == State.NotNumber)
                    {
                        if (char.IsDigit(c))
                        {
                            state = State.Number;
                        }
                    }
                    else if (state == State.Number)
                    {
                        if ((c == '.') && (j == integers[i].Length - 1))
                        {
                            state = State.Dot;
                            structures[k] = integers[i];
                            k++;

                        }
                        else if (!char.IsDigit(c))
                        {
                            state = State.NotNumber;
                        }
                    }
                    else if (state == State.Dot)
                    {
                        state = State.NotNumber;
                    }
                }
            }
            return structures;
        }

        static void PrintIntegers(string str)
        {
            string[] array = GetAllIntegers(str);
            int counter = CountIntegers(str);
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("[{0}] -> {1}", i, array[i]);
            }
        }

        static bool CompareArrays(string[] arr1, string[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        static bool CompareOptions(Options o1, Options o2)
        {
            return o1.isInteractiveMode == o2.isInteractiveMode
            && o1.inputFile == o2.inputFile
            && o1.outputFile == o2.outputFile
            && o1.parsingError == o2.parsingError;
        }

        static Options ParseOptions(string[] args)
        {
            Options options = new Options()
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "",
                parsingError = "",
            };
            if (args.Length == 0)
            {
                return options;
            }
            bool[] isUsed = new bool[args.Length];
            while (true)
            {
                bool hasUnUsed = false;
                foreach (bool isUsedItem in isUsed)
                {
                    if (isUsedItem == false)
                    {
                        hasUnUsed = true;
                        break;
                    }
                }
                if (hasUnUsed == false)
                {
                    break;
                }

                for (int i = 0; i < args.Length; i++)
                {
                    if (isUsed[i])
                    {
                        continue;
                    }
                    if (args[i] == "-i")
                    {
                        options.isInteractiveMode = true;
                        isUsed[i] = true;
                    }
                }
                if (options.isInteractiveMode == true)
                    break;
                for (int i = 0; i < args.Length; i++)
                {
                    if (isUsed[i])
                    {
                        continue;
                    }
                    if (args[i] == "-o")
                    {
                        if (i == args.Length - 1 || args[i + 1].StartsWith('-'))
                        {
                            options.parsingError = "Error: `-o` опція із аргументом, задайте назву файлу";
                            return options;
                        }
                        options.outputFile = args[i + 1];
                        isUsed[i] = true;
                        isUsed[i + 1] = true;
                    }
                    else if (args[i].StartsWith('-'))
                    {
                        options.parsingError = $"error: unrecognized option '{args[i]}'";
                        return options;
                    }
                    else
                    {
                        if (options.inputFile != "")
                        {
                            options.parsingError = "error: there are two input files";
                            return options;
                        }
                        options.inputFile = args[i];
                        isUsed[i] = true;
                    }
                }
            }
            if (args[0] == "")
            {
                return options;
            }
            else if ((options.isInteractiveMode == false) && (options.inputFile == ""))
            {
                options.parsingError = "Error: must be Interactive mode or input file";
                options.isInteractiveMode = false;
                options.inputFile = "";
                options.outputFile = "";
            }
            return options;
        }
    }
}
