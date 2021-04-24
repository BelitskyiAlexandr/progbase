using System;
using System.Drawing;

namespace ConsoleApp
{
    static class ArgumentProccessor
    {
        public struct ProgramArguments
        {
            public string module;
            public string inputFile;
            public string outputFile;
            public string operation;
            public string[] otherArgs;
        }

        private static void ValidateArgumentsLength(int length)
        {
            if (length < 4)
            {
                throw new ArgumentException($"Not enough command line arguments. Expected more than 3, got {length}");
            }

        }

        private static void ValidateModule(string module)
        {
            string[] supportedModules = new string[] { "pixel", "fast" };
            for (int i = 0; i < supportedModules.Length; i++)
            {
                if (supportedModules[i] == module)
                {
                    return;
                }
            }
            throw new ArgumentException($"Not supported module {module}");
        }

        private static void ValidateInputFile(string file)
        {
            if (System.IO.File.Exists(file) == false)
            {
                throw new ArgumentException($"File does not exist {file}");
            }
        }

        private static void ValidateOperation(string operation)
        {
            string[] supportedOperations = new string[] { "crop", "FlipVertical" };
            for (int i = 0; i < supportedOperations.Length; i++)
            {
                if (supportedOperations[i] == operation)
                {
                    return;
                }
            }
            throw new ArgumentException($"Not supported module {operation}");
        }
        public static ProgramArguments ParseArgs(string[] args)
        {
            ValidateArgumentsLength(args.Length);
            string module = args[0];
            ValidateModule(module);

            string inputFile = args[1];
            ValidateInputFile(inputFile);

            string outputFile = args[2];
            string operation = args[3];
            ValidateOperation(operation);

            ProgramArguments programArgs = new ProgramArguments();
            programArgs.module = module;
            programArgs.inputFile = inputFile;
            programArgs.outputFile = outputFile;
            programArgs.operation = operation;
            programArgs.otherArgs = new string[args.Length - 4];
            for (int i = 0; i < programArgs.otherArgs.Length; i++)
            {
                programArgs.otherArgs[i] = args[i + 4];
            }
            return programArgs;
        }

        public static Rectangle ParseRectangle(string rec)
        {
            string[] stringParameters = rec.Split('x','+');
            if (stringParameters.Length != 4)
            {
                throw new ArgumentException($"Wrong number of parameters. Need 4 but have {stringParameters.Length}");
            }
            int[] parameters = new int[4];
            for (int i = 0; i < stringParameters.Length; i++)
            {
                if (int.TryParse(stringParameters[i],out parameters[i]) == false)
                {
                    throw new ArgumentException("Wrong input rectangle parameters");
                }
            }

            return new Rectangle
            {
                Location = new Point(parameters[2], parameters[3]),
                Width = parameters[0],
                Height = parameters[1],
            };
        }
    }
}