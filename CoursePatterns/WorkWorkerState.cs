using System;

public class WorkWorkerState : IWorkerState
{
    public void GoWorking(Worker worker)
    {
        Console.WriteLine("Worker is already on work");
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
        Console.WriteLine("Do you want to send worker on sick leave? (Yes/No)");
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
