using System;

class Program
{
    static void Main(string[] args)
    {
        Mechanic mechanic = new Mechanic("SS", 22);
        Console.WriteLine(mechanic.ToString());
        Console.WriteLine(mechanic.CheckCurrentState());

        mechanic.Working();
        mechanic.GoOnHoliday();
        mechanic.GoOnHoliday();
        mechanic.GoSickLeave();
        mechanic.GoSickLeave();
        mechanic.Working();
        mechanic.Working();
        
    }
}

