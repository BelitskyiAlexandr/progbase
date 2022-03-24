public interface IWorkerState 
{
    void GoWorking(Worker worker);
    void GoOnHoliday(Worker worker);
    void GoSickLeave(Worker worker);
}