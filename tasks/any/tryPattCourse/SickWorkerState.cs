
using System;

public class SickWorkerState : IWorkerState
{
    public void GoWorking(Worker worker)
    {
        Console.WriteLine("Worker on sick leave. Do you want to call him/her to work? (Yes/No)");
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
        Console.WriteLine("Do you want to send worker on holiday? (Yes/No)");
        string answer = Console.ReadLine();
        if (answer == "Yes")
        {
            worker.State = new HolidayWorkerState();
            Console.WriteLine("Worker has been sent on holiday");
        }
        else if (answer == "No") Console.WriteLine("Operation has been cancelled");
        else Console.WriteLine("Error: Unknown command");
    }

    public void GoSickLeave(Worker worker)
    {
        Console.WriteLine("Worker is already on sick leave");
    }

}