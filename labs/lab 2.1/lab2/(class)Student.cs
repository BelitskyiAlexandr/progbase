using System;
using static System.Console;

public class Student : UniversityPerson
{
    protected int course;
    protected string reportCard;

    public Student(string name, int age, string UniversityName, int course, string reportCard) : base(name, age, UniversityName)
    {
        this.course = course;
        this.reportCard = reportCard;
        // WriteLine("I'm a student");
    }
    public Student(string name, int age, bool highSugar) : base(name, age, highSugar)
    {
        System.Random rnd = new System.Random();
        this.course = rnd.Next(1, 7);
        this.reportCard = rnd.Next(10000, 100000).ToString();
    }

    public void Add(int x1, int x2)
    {
        Console.WriteLine("Summation result: " + (x1 + x2));
    }

    public void Substract(int x1, int x2)
    {
        Console.WriteLine("Subtraction result: " + (x1 - x2));
    }

    public int Multiply(int x1, int x2)
    {
        return x1 * x2;   
    }
    public override void Print()
    {
        WriteLine("The values of fields are:");
        WriteLine($"Name = {this.Name}");
        WriteLine($"Age = {this.Age}");
        WriteLine($"Course = {course}");
        WriteLine($"GradeBook = {reportCard}");
    }

    public override void GoToClass()
    {
        WriteLine("I'm going to classroom");
        WriteLine("I'm studying here");
    }
}