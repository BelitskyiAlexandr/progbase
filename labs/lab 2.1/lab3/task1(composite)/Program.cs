using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Group group1 = new Group("First");
        group1.Add(new Student("Igor"));
        group1.Add(new Student("Nata"));
        group1.Add(new Student("Georg"));

        group1.ShowInfo(1);
        group1.PassExam();
        Console.WriteLine();

        group1.ShowInfo(1);

        Console.WriteLine("=====");

        Group group2 = new Group("Second");
        Student gerd = new Student("Gerd");

        group2.Add(gerd);
        group2.Add(new Student("Bob"));
        group2.Add(new Student("Pidge"));

        group2.ShowInfo(1);
        gerd.PassExam();
        Console.WriteLine();

        group2.ShowInfo(1);
    }
}

abstract class Component //основа
{
    protected string _name;
    protected bool _passExam;

    public Component(string name)
    {
        this._name = name;
        this._passExam = false;
    }

    public abstract void ShowInfo(int indent);
    public abstract bool PassExam();
    public abstract void Add(Component a);
    public abstract void Remove(Component a);
}

class Student : Component
{
    public Student(string name) : base(name) { }

    public override void ShowInfo(int indent)
    {
        Console.WriteLine(new String('-', indent) + "+ " + _name + "\t" + _passExam);
    }
    public override bool PassExam()
    {
        return this._passExam = true;
    }

    public override void Add(Component student)
    {
        Console.WriteLine("Cannot add to student");
    }


    public override void Remove(Component student)
    {
        Console.WriteLine("Cannot remove from student");
    }
}

class Group : Component  //компонувальник
{
    private List<Component> students = new List<Component>();

    public Group(string name) : base(name) { }

    public override void Add(Component a)
    {
        students.Add(a);
    }

    public override void Remove(Component a)
    {
        students.Remove(a);
    }

    public override void ShowInfo(int indent)
    {
        Console.WriteLine(new String('-', indent) + "+ " + _name + "\t" + _passExam);

        foreach (var student in students)
        {
            student.ShowInfo(indent + 2);
        }
    }

    private void IfPassedAllGroup()
    {
        bool ifPassedAllGroup = true;
        foreach (var student in students)
        {
            if (!student.PassExam())
            {
                ifPassedAllGroup = false;
            }
        }
        _passExam = ifPassedAllGroup;
    }

    public override bool PassExam()
    {
        IfPassedAllGroup();
        foreach (var student in students)
        {
            student.PassExam();
        }
        return true;
    }
}

