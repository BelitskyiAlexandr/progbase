using System;

class Program
{
    static void Main(string[] args)
    {
        StudentWork studentWork = new StudentWork(false);

        Checker teacher1 = new Teacher("Gerd", true);
        Checker teacher2 = new Teacher("Asya", false);
        teacher1.Successor = teacher2;

        teacher1.Handle(studentWork);
    }
}

abstract class Checker
{
    public Checker Successor { get; set; }
    public abstract void Handle(StudentWork studentWork);
}

class Teacher : Checker
{
    private string _name;
    public bool busy { get; private set; }

    public Teacher(string name, bool busy)
    {
        this._name = name;
        this.busy = busy;
    }

    public override void Handle(StudentWork studentWork)
    {
        if (studentWork.isChecked == false && this.busy == false)
        {
            Console.WriteLine("Student work has been checked by " + this._name);
            studentWork.isChecked = true;
        }
        else if (Successor != null)
        {
            Console.WriteLine($"{this._name} is busy. Work has gone to next teacher");
            Successor.Handle(studentWork);
        }
    }
}

class StudentWork
{
    public bool isChecked;

    public StudentWork(bool isChecked)
    {
        this.isChecked = isChecked;
    }
}

