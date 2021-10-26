using System;

public abstract class UniversityPerson : Human
{
    protected string UniversityName;

    public UniversityPerson(string name, int age, string UniversityName) : base(name, age)
    {
        this.UniversityName = UniversityName;

       // Console.WriteLine("I'm university person");
    }

    public UniversityPerson(string name, int age, bool highSugar) : base(name, age, highSugar)
    {
        this.UniversityName = "unknown";

    }

    public abstract void GoToClass();
    
}