using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Module module1 = new Module("Module 1");
        // module1.Display();
        // module1.MakeGreatMarks();
        // module1.Display();

        //Student student = new Student("Gerd");


        ProxyStudent student = new ProxyStudent("Gerd");
        student.DisplayModules();
        Console.WriteLine();

        student.DoNextModule();
        Console.WriteLine();

        student.DoGreatPrevousModuls();
        student.DisplayModules();

        student.DoNextModule();
        Console.WriteLine();
        student.DisplayModules();
    }
}

abstract class UnivetsityHuman
{
    protected string _name;
    protected int currentmodule;
    protected List<Module> modules;

    public UnivetsityHuman(string name)
    {
        this._name = name;
        this.currentmodule = 1;
        modules = new List<Module>();
        for (int i = 0; i < 2; i++)
        {
            modules.Add(new Module($"Module {i + 1}"));
        }
    }
    public abstract void DoNextModule();
    public abstract void DoGreatPrevousModuls();
    public abstract void DisplayModules();
}

class ProxyStudent : UnivetsityHuman
{
    Student student;
    public ProxyStudent(string name) : base(name)
    {
        student = new Student(name);
        this.modules = student.Modules;
    }

    public override void DisplayModules()
    {
        student.DisplayModules();
    }

    public override void DoGreatPrevousModuls()
    {
        student.DoGreatPrevousModuls();
    }

    private bool IfCanDoNextModule()
    {
        if (modules[currentmodule - 1].CheckBadMark())
            return false;
        return true;
    }
    public override void DoNextModule()
    {
        if (IfCanDoNextModule())
        {
            student.DoNextModule();
            Console.WriteLine("Next module done");
        }
        else
            Console.WriteLine("You should do previous modules great (>= 10) ");
    }
}
class Student : UnivetsityHuman
{
    public Student(string name) : base(name) { }

    public List<Module> Modules
    {
        get { return this.modules; }
    }
    public override void DisplayModules()
    {
        foreach (var item in modules)
        {
            Console.WriteLine($"{item.Name}");
            item.Display();
            Console.WriteLine();
        }
    }

    public override void DoGreatPrevousModuls()
    {
        for (int i = 0; i < currentmodule; i++)
        {
            modules[i].MakeGreatMarks();
        }
    }

    public override void DoNextModule()
    {
        currentmodule++;
        modules[currentmodule - 1].MakeRandomMarks();
    }
}

class Module
{
    private List<Exercise> _exercises;
    private string _name;

    public string Name
    {
        get { return _name; }
    }
    public Module(string name)
    {
        this._name = name;
        this._exercises = GenerateExercises();
    }

    private List<Exercise> GenerateExercises()
    {
        Random rnd = new Random();
        List<Exercise> exercises = new List<Exercise>();
        string[] randomExercises = { "Math", "PE", "IT", "Biology", "History", "English", "Literature" };

        string[] randomFirstFour = randomExercises.OrderBy(x => rnd.Next()).ToArray();

        for (int i = 0; i < 4; i++)
        {
            Exercise ex = new Exercise(randomFirstFour[i]);
            exercises.Add(ex);
        }
        return exercises;
    }

    public void Display()
    {
        foreach (var item in _exercises)
        {
            Console.WriteLine($"{item.Name,-15}\t{item.Mark,4}");
        }
    }

    public void MakeGreatMarks()
    {
        Random rnd = new Random();
        foreach (var item in _exercises)
        {
            item.ChangeMark(rnd.Next(10, 13));
        }
    }

    public void MakeRandomMarks()
    {
        Random rnd = new Random();
        foreach (var item in _exercises)
        {
            item.ChangeMark(rnd.Next(1, 13));
        }
    }

    public bool CheckBadMark()
    {
        foreach (var item in _exercises)
        {
            if (item.Mark < 10)
                return true;
        }
        return false;
    }

}

class Exercise
{
    private string _name;
    private int _mark;

    public Exercise(string name)
    {
        this._name = name;
        //Random rnd = new Random();
        //this._mark = rnd.Next(1,10);
        this._mark = 0;
    }

    public void ChangeMark(int mark)
    {
        if (mark > 12 || mark < 0)
            throw new ArgumentException("Error: mark must be from 0 to 12");
        this._mark = mark;
    }

    public string Name
    {
        get { return _name; }
    }

    public int Mark
    {
        get { return _mark; }
    }
}
