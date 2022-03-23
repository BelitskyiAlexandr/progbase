public interface IWorkerState 
{
    void Working(Worker worker);
    void GoOnHoliday(Worker worker);
    void GoSickLeave(Worker worker);
}