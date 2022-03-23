class WorkWorkerState : IWorkerState
{
    public void Working(Worker worker)
    {
        throw new System.NotImplementedException();                 ////    TODO
    }

    public void GoOnHoliday(Worker worker)
    {
        worker.State = new HolidayWorkerState();
    }

    public void GoSickLeave(Worker worker)
    {
        worker.State = new SickWorkerState();
    }
}


class HolidayWorkerState : IWorkerState
{
    public void Working(Worker worker)
    {
        worker.State = new WorkWorkerState();
    }

    public void GoOnHoliday(Worker worker)
    {
        throw new System.NotImplementedException();         //// TODO
    }

    public void GoSickLeave(Worker worker)
    {
        worker.State = new SickWorkerState();
    }
}


class SickWorkerState : IWorkerState
{
    public void Working(Worker worker)
    {
        worker.State = new WorkWorkerState();
    }

    public void GoOnHoliday(Worker worker)
    {
        worker.State = new HolidayWorkerState();
    }

    public void GoSickLeave(Worker worker)
    {
        throw new System.NotImplementedException();         ////
    }

}