using System;
using static System.Console;


class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World!");
        
        Human h = new Human("Gerd", 44);
        h.Print();
        Birthday.HappyBirthday(h);
        WriteLine("-----\n");

        UniversityPerson universityPerson= new UniversityPerson("Nun", 33, "ZhTI");
        universityPerson.GoToClass();
        WriteLine("-----\n");

        Teacher teacher = new Teacher("Harley", 43, "KPI", "PE");
        teacher.GoToClass();
        WriteLine("-----\n");
        
        
        Student s = new Student("Bob", 22, "KPI", 4, "ssd23w");
        s.Print();
        WriteLine();
        
        s.GoToClass();
        WriteLine();

        Birthday.HappyBirthday(s);
        WriteLine("-----\n");

        Aspirant a = new Aspirant("Huan", 62, "VNTU", 4, "323sd2", "Football");
        a.Print();
        WriteLine("-----\n");
    
    
        Watch watch = new Watch();
        WriteLine("-----\n");

        GCProcess();
    }

    static void GCProcess()
    {
        Human[] group = new Human[1500];
        for(int i = 0; i < 1350; i++)
        {
            group[i] = new Human();
        }
        WriteLine("Total memory before: {0}", GC.GetTotalMemory(false));
    
        GC.Collect();
        GC.WaitForPendingFinalizers();

        WriteLine("Total memory after: {0}", GC.GetTotalMemory(false));
    }
}


public class Human : IDisposable
{
    private string name;
    private int age;
    public string Name
    {
        set
        {
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                name = value;
        }
        get { return name; }
    }

    public int Age
    {
        set
        {
            if (value > 0 && value < 150)
                age = value;
        }
        get { return age; }
    }
    public Human() { }
    public Human(string name, int age)
    {
        this.name = name;
        this.age = age;
        WriteLine("I'm a human");
    }
    public virtual void Print()
    {
        WriteLine($"Name = {this.Name}");
        WriteLine($"Age = {this.age}");
    }


    private bool disposed = false;

    ~Human()
    {
        Dispose(false);
        Beep();
        WriteLine("Destructor has worked");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);

        Beep();
        WriteLine("IDisposable method has worked");

    }

    protected virtual void Dispose(bool disposing)
    {
        if(!disposed)
        {
            if(disposing)
            {
                WriteLine("delete managed resourses");
            }
            disposed = true;
            WriteLine("delete unmanaged resourses");
        }
    }
}
public class UniversityPerson : Human
{
    protected string UniversityName;

    public UniversityPerson(string name, int age, string UniversityName) : base(name, age)
    {
        this.UniversityName = UniversityName;

        WriteLine("I'm university person");
    }

    //TODO: GoToClass

    public virtual void GoToClass()
    {
        WriteLine("I'm going to classroom");
    }

}

public sealed class Teacher : UniversityPerson
{
    private string subject;

    public Teacher(string name, int age, string UniversityName, string subject) : base(name, age, UniversityName)
    {
        this.subject = subject;

        WriteLine("I'm a teacher");
    }

    public override void GoToClass()
    {
        base.GoToClass();
        WriteLine("I'm teaching here");
    }

}

public class Student : UniversityPerson
{
    protected int course;
    protected string reportCard;

    public Student(string name, int age, string UniversityName, int course, string reportCard) : base(name, age, UniversityName)
    {
        this.course = course;
        this.reportCard = reportCard;
        WriteLine("I'm a student");
    }

    public int Course
    {
        get { return course; }
        set { course = value; }
    }

    public string GradeBook
    {
        get { return reportCard; }
        set { reportCard = value; }
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
        base.GoToClass();
        WriteLine("I'm studying here");
    }
}

public class Aspirant : Student
{
    protected string topic;

    public Aspirant(string name, int age, string UniversityName, int course, string reportCard, string topic) : base(name, age, UniversityName, course, reportCard)
    {
        base.Name = name;
        this.course = course;
        this.reportCard = reportCard;

        this.topic = topic;

        WriteLine("I'm aspirant");
    }

    public new void Print()
    {
        base.Print();
        WriteLine($"Topic = {topic}");
    }
}

public class Birthday
{
    private Birthday() { }

    public static void HappyBirthday(Human human)
    {
        human.Age = human.Age + 1;
        WriteLine("{0} is {1} years old now", human.Name, human.Age);
    }
}

public class Watch
{
    static DateTime time;

    static Watch()
    {
        time = DateTime.Now;
        
        WriteLine("The evolution of man is now at : {0}", time);
    }

}
