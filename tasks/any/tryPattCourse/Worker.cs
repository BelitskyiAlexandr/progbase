public abstract class Worker
{
    private string name;
    private int age;
    protected string post;
    public IWorkerState State { get; set; }
    public Worker(string name, int age)                 //де буде додавання нового робітника зробити перевірку на "нульового" робітника
    {
        if (CheckAge(age))
        {
            if (CheckString(name))
            {
                this.age = age;
                this.name = name;
                this.State = new WorkWorkerState();
            }
            else return;
        }
        else return;
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

    #region Properties
    public string Name
    {
        get { return this.name; }
    }

    public int Age
    {
        get { return this.age; }
    }

    #endregion

    #region CheckValidInput
    private bool CheckAge(int age)
    {
        if (age <= 18 || age > 60)
        {
            return false;
        }
        return true;
    }

    private bool CheckString(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return false;
        }
        return true;
    }
    #endregion


    public override string ToString()
    {
        return $"Name: {this.name,-15}; Age: {this.age,2}; Post: {this.post, -15}";
    }
}