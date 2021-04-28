using System;
using System.Diagnostics;
using System.Drawing;
using ProgbaseLab.ImageEditor.Common;

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

        public static void Run(string[] args)
        {
            ProgramArguments progArgs = ParseArgs(args);
            IRedatctingImage redactor = ChooseRedactor(progArgs.module);
            Bitmap iputBit = new Bitmap(progArgs.inputFile);
            switch (progArgs.operation)
            {
                case "crop":
                    {
                        ProccessCrop(redactor, progArgs, iputBit);
                        break;
                    }
                case "FlipVertical":
                    {
                        ProccessFlipVertical(redactor, iputBit, progArgs.outputFile, progArgs.otherArgs);
                        break;
                    }
                case "RemoveRed":
                    {
                        ProccessRemoveRed(redactor, iputBit, progArgs.outputFile, progArgs.otherArgs);
                        break;
                    }
                case "GrayScale":
                    {
                        ProccessGrayScale(redactor, iputBit, progArgs.outputFile, progArgs.otherArgs);
                        break;
                    }
                case "Blur":
                    {
                        ProccessBlur(redactor, progArgs, iputBit);
                        break;
                    }
            }

        }

        private static void ProccessBlur(IRedatctingImage redactor, ProgramArguments progArgs, Bitmap iputBit)
        {
            if (progArgs.otherArgs.Length != 1)
            {
                throw new ArgumentException($"Blur must have one intensity argument, but have {progArgs.otherArgs.Length}");
            }
            if (Int32.TryParse(progArgs.otherArgs[0], out int sigma) == false)
            {
                throw new ArgumentException($"Blur must have integer intensity argument, but have {progArgs.otherArgs[0]}");
            }
            if (sigma > 20 && sigma < 0)
            {
                throw new ArgumentException($"Simga must be from 0 to 20, but have {sigma}");
            }
            Stopwatch watchProcess = new Stopwatch();
            watchProcess.Start();
            Stopwatch watchImage = new Stopwatch();


            watchImage.Start();
            Bitmap outBit = redactor.Blur(iputBit, sigma);
            watchImage.Stop();

            Console.WriteLine($"Image process finished in {watchImage.ElapsedMilliseconds}");
            outBit.Save(progArgs.outputFile);
            watchProcess.Stop();
            Console.WriteLine($"Whole process finished in {watchProcess.ElapsedMilliseconds}");
        }

        private static void ProccessGrayScale(IRedatctingImage redactor, Bitmap bitmap, string outputFile, string[] otherArgs)
        {
            if (otherArgs.Length != 0)
            {
                throw new FormatException($"Incorrect RemoveRed format. Expected other arguments `0` but have {otherArgs.Length}");
            }
            Stopwatch watchProcess = new Stopwatch();
            watchProcess.Start();
            Stopwatch watchImage = new Stopwatch();
            watchImage.Start();

            Bitmap outBit = redactor.GrayScale(bitmap);

            watchImage.Stop();

            Console.WriteLine($"Image process finished in {watchImage.ElapsedMilliseconds}");
            outBit.Save(outputFile);
            watchProcess.Stop();
            Console.WriteLine($"Whole process finished in {watchProcess.ElapsedMilliseconds}");
        }

        private static void ProccessRemoveRed(IRedatctingImage redactor, Bitmap bitmap, string outputFile, string[] otherArgs)
        {
            if (otherArgs.Length != 0)
            {
                throw new FormatException($"Incorrect RemoveRed format. Expected other arguments `0` but have {otherArgs.Length}");
            }
            Stopwatch watchProcess = new Stopwatch();
            watchProcess.Start();
            Stopwatch watchImage = new Stopwatch();
            watchImage.Start();

            Bitmap outBit = redactor.RemoveRed(bitmap);

            watchImage.Stop();

            Console.WriteLine($"Image process finished in {watchImage.ElapsedMilliseconds}");
            outBit.Save(outputFile);
            watchProcess.Stop();
            Console.WriteLine($"Whole process finished in {watchProcess.ElapsedMilliseconds}");
        }

        private static void ProccessCrop(IRedatctingImage redactor, ProgramArguments progArgs, Bitmap iputBit)
        {
            if (progArgs.otherArgs.Length != 1)
            {
                throw new ArgumentException($"Crop must have one dimensions argument, but have {progArgs.otherArgs.Length}");
            }
            Stopwatch watchProcess = new Stopwatch();
            watchProcess.Start();
            Stopwatch watchImage = new Stopwatch();

            string cropArguments = progArgs.otherArgs[0];
            Rectangle cropRect = ParseRectangle(cropArguments);

            watchImage.Start();
            Bitmap outBit = redactor.Crop(iputBit, cropRect);
            watchImage.Stop();

            Console.WriteLine($"Image process finished in {watchImage.ElapsedMilliseconds}");
            outBit.Save(progArgs.outputFile);
            watchProcess.Stop();
            Console.WriteLine($"Whole process finished in {watchProcess.ElapsedMilliseconds}");
        }

        private static void ProccessFlipVertical(IRedatctingImage redactor, Bitmap bitmap, string outputFile, string[] otherArgs)
        {
            if (otherArgs.Length != 0)
            {
                throw new FormatException($"Incorrect FlipVertical format. Expected other arguments `0` but have {otherArgs.Length}");
            }
            Stopwatch watchProcess = new Stopwatch();
            watchProcess.Start();
            Stopwatch watchImage = new Stopwatch();
            watchImage.Start();

            Bitmap outBit = redactor.FlipVertical(bitmap);

            watchImage.Stop();

            Console.WriteLine($"Image process finished in {watchImage.ElapsedMilliseconds}");
            outBit.Save(outputFile);
            watchProcess.Stop();
            Console.WriteLine($"Whole process finished in {watchProcess.ElapsedMilliseconds}");
        }

        private static IRedatctingImage ChooseRedactor(string module)
        {
            if (module == "pixel")
            {
                return new ProgbaseLab.ImageEditor.Pixel.Class1();

            }
            else
            {
                return new ProgbaseLab.ImageEditor.Fast.Class1();
            }
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
            string[] supportedOperations = new string[] { "crop", "FlipVertical", "RemoveRed", "GrayScale", "Blur" };
            for (int i = 0; i < supportedOperations.Length; i++)
            {
                if (supportedOperations[i] == operation)
                {
                    return;
                }
            }
            throw new ArgumentException($"Not supported operation {operation}");
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
            string[] stringParameters = rec.Split('x', '+');
            if (stringParameters.Length != 4)
            {
                throw new ArgumentException($"Wrong number of parameters. Need 4 but have {stringParameters.Length}");
            }
            int[] parameters = new int[4];
            for (int i = 0; i < stringParameters.Length; i++)
            {
                if (int.TryParse(stringParameters[i], out parameters[i]) == false)
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