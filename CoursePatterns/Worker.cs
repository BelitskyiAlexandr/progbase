public abstract class Worker : Human
{
    protected string post;
    public IWorkerState State { get; set; }
    public Worker(string name, int age) : base(name, age)               //де буде додавання нового робітника зробити перевірку на "нульового" робітника
    {
        this.State = new WorkWorkerState();
    }

    public IWorkerState CheckCurrentState()
    {
        return this.State;
    }

    #region StateFunctions
    public void Working()
    {
        State.GoWorking(this);
    }
    public void GoOnHoliday()
    {
        State.GoOnHoliday(this);
    }
    public void GoSickLeave()
    {
        State.GoSickLeave(this);
    }

    #endregion

    public override string ToString()
    {
        return $"Name: {base.Name,-15}; Age: {this.Age,2}; Post: {this.post,-15}";
    }
}