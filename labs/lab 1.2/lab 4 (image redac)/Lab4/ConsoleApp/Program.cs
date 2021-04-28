using System;
using ProgbaseLab.ImageEditor.Pixel;
using ProgbaseLab.ImageEditor.Fast;

namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try{
                ArgumentProccessor.Run(args);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                Console.WriteLine("Tip: Operation was successful");
                Environment.Exit(0);
            }
        }
    }
}
