using System;

public class Aspirant : Student
{
    protected string topic;

    public Aspirant(string name, int age, string UniversityName, int course, string reportCard, string topic) : base(name, age, UniversityName, course, reportCard)
    {
        base.Name = name;
        this.course = course;
        this.reportCard = reportCard;

        this.topic = topic;

       // Console.WriteLine("I'm aspirant");
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine($"Topic = {topic}");
    }
}