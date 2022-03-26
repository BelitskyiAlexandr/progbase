
using System;

public class HolidayWorkerState : IWorkerState
{
    public void GoWorking(Worker worker)
    {
        Console.WriteLine("Worker on vacation. Do you want to call him/her to work? (Yes/No)");
        string answer = Console.ReadLine();
        if (answer == "Yes")
        {
            worker.State = new WorkWorkerState();
            Console.WriteLine("Worker is coming soon");
        }
        else if (answer == "No") Console.WriteLine("Thank you! Operation has been cancelled");
        else Console.WriteLine("Error: Unknown command");
    }

    public void GoOnHoliday(Worker worker)
    {
        Console.WriteLine("Worker is already on vacation");
    }

    public void GoSickLeave(Worker worker)
    {
        Console.WriteLine("Do you want to sent worker on sick leave? (Yes/No)");
        string answer = Console.ReadLine();
        if (answer == "Yes")
        {
            worker.State = new SickWorkerState();
            Console.WriteLine("Worker has been sent on sick leave");
        }
        else if (answer == "No") Console.WriteLine("Operation has been cancelled");
        else Console.WriteLine("Error: Unknown command");
    }
}
