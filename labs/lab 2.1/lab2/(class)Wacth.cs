using System;

public class Watch
{
    static DateTime time;

    static Watch()
    {
        time = DateTime.Now;
        
        Console.WriteLine("The evolution of man is now at : {0}", time);
    }

}