using System;
using System.Diagnostics;
using System.Drawing;


class Program
{
    static void Main(string[] args)
    {
        ArgumentProccessor.Run(args);
    }
}

static class ImageEditor
{
    public static Bitmap Crop(Bitmap bmp, Rectangle rec)
    {
        //TODO
        //throw new System.NotImplementedException();

        if (rec.Left < 0 || rec.Left >= bmp.Width)
        {
            throw new Exception("Invalid left");
        }
        if (rec.Right >= bmp.Width)
        {
            throw new Exception("Invalid right");
        }
        if (rec.Top < 0 || rec.Top >= bmp.Height)
        {
            throw new Exception("Invalid right");
        }
        if (rec.Bottom >= bmp.Height)
        {
            throw new Exception("Invalid right");
        }
        Bitmap cropImage = new Bitmap(rec.Width, rec.Height);
        for (int y = 0; y < cropImage.Height; y++)
        {
            for (int x = 0; x < cropImage.Width; x++)
            {
                Color color = bmp.GetPixel(x + rec.Left, y + rec.Top);
                cropImage.SetPixel(x, y, color);
            }
        }

        return cropImage;

    }

    public static Bitmap FlipVertical(Bitmap bitmap)
    {
        //TODO
        Bitmap flippedBMP = new Bitmap(bitmap.Width, bitmap.Height);
        for (int x = bitmap.Width; x > 0; x++)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                Color color = bitmap.GetPixel(x, y);
                flippedBMP.SetPixel(bitmap.Width - x - 1, bitmap.Height, color);
            }
        }
        return flippedBMP;
    }
}
static class ArgumentProccessor
{
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
    private static void ValidateArgumentsLength(int length)
    {
        if (length < 4)
        {
            throw new ArgumentException($"Not enough command line arguments. Expected more than 3, got {length}");
        }

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
    private static Rectangle ParseRectangle(string rec)
    {
        // REDO
        return new Rectangle
        {
            Location = new Point(10, 45),
            Width = 200,
            Height = 100,
        };
    }

    public static void FlipVertical()
    {

    }
    public static void Run(string[] args)
    {
        ProgramArguments progArgs = ParseArgs(args);
        Bitmap iputBit = new Bitmap(progArgs.inputFile);
        switch (progArgs.operation)
        {
            case "crop":
                {
                    ProccessCrop(progArgs, iputBit);
                    break;
                }
            case "FlipVertical":
                {
                    ProccessFlipVertical(iputBit, progArgs.outputFile);
                    break;
                }

        }
    }

    struct ProgramArguments
    {
        public string module;
        public string inputFile;
        public string outputFile;
        public string operation;
        public string[] otherArgs;
    }

    private static ProgramArguments ParseArgs(string[] args)
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
    private static void ProccessFlipVertical(Bitmap bitmap, string outputFile)
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        Bitmap outBit = ImageEditor.FlipVertical(bitmap);
        watch.Stop();

        Console.WriteLine($"Finished in {watch.ElapsedMilliseconds}");
        outBit.Save(outputFile);
    }

    private static void ProccessCrop(ProgramArguments progArgs, Bitmap iputBit)
    {
        Stopwatch watch = new Stopwatch();
        if (args.Length != 5)
        {
            throw new ArgumentException("Crop must have dimensions argument");
        }
        string cropArguments = progArgs.otherArgs[0];
        Rectangle cropRect = ParseRectangle(cropArguments);
        watch.Start();
        Bitmap outBit = ImageEditor.Crop(iputBit, cropRect);
        watch.Stop();

        Console.WriteLine($"Finished in {watch.ElapsedMilliseconds}");
        outBit.Save(progArgs.outputFile);
    }
}


