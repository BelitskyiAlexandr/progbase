using System;

public sealed class Teacher : UniversityPerson
{
    private string subject;
    private string present;

    public Teacher(string name, int age, string UniversityName, string subject) : base(name, age, UniversityName)
    {
        this.subject = subject;
        this.present = "нема";
        // Console.WriteLine("I'm a teacher");
    }

    public string Present
    {
        get { return present; }
        set { present = value; }
    }
    public override void GoToClass()
    {
        Console.WriteLine("I'm going to classroom");
        Console.WriteLine("I'm teaching here");
    }

}