using System;
using System.Diagnostics;

namespace pr_12._12
{
    struct Options
    {
        public bool isInteractiveMode;
        public string inputFile;
        public string outputFile;
        public string parsingError;
        public string split;
    }
    class Program
    {
        static bool CompareOptions(Options o1, Options o2)
        {
            return o1.isInteractiveMode == o2.isInteractiveMode &&
                o1.inputFile == o2.inputFile &&
                o1.outputFile == o2.outputFile &&
                o1.parsingError == o2.parsingError &&
                o1.split == o2.split;
        }

        static Options ParseOptions(string[] args)              //не працює, перевірки
        {
            
            
            Options option = new Options
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "",
                parsingError = "",
                split = "",
            };
            return option;
        }

        static void Main(string[] args)
        {
            Debug.Assert(CompareOptions(ParseOptions(new string[0] { }), new Options
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "",
                parsingError = "",
                split = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] {"-i"}), new Options
            {
                isInteractiveMode = true,
                inputFile = "",
                outputFile = "",
                parsingError = "",
                split = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] {"-o", "OUTPUT.txt"}), new Options
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "OUTPUT.txt",
                parsingError = "",
                split = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] {"INPUTFILE.txt"}), new Options
            {
                isInteractiveMode = false,
                inputFile = "INPUTFILE.txt",
                outputFile = "",
                parsingError = "",
                split = "",
            }));
            Debug.Assert(CompareOptions(ParseOptions(new string[] {"-s", "substring"}), new Options
            {
                isInteractiveMode = false,
                inputFile = "",
                outputFile = "",
                parsingError = "",
                split = "substring",
            }));
            Debug.Assert(ParseOptions(new string[] {"-u"}).parsingError != "");
            Debug.Assert(ParseOptions(new string[] {"-o"}).parsingError != "");
            Debug.Assert(ParseOptions(new string[] {"-o", "-i"}).parsingError != "");
            Debug.Assert(ParseOptions(new string[] {"-o", "-s"}).parsingError != "");
            Debug.Assert(ParseOptions(new string[] {"-s"}).parsingError != "");
            Debug.Assert(ParseOptions(new string[] {"-s", "-i"}).parsingError != "");
            Debug.Assert(ParseOptions(new string[] {"-s", "-o"}).parsingError != "");
            Console.WriteLine("OK");
        }
    }
}
