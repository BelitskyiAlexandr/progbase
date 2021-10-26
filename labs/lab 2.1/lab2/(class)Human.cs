using System;
using static System.Console;


public class Human : IDisposable, IJuice, IWater
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
        //  WriteLine("I'm a human");
    }


    public virtual void Print()
    {
        WriteLine($"Name = {this.Name}");
        WriteLine($"Age = {this.age}");
    }



    #region Dispos+Finallize
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
        if (!disposed)
        {
            if (disposing)
            {
                WriteLine("delete managed resourses");
            }
            disposed = true;
            WriteLine("delete unmanaged resourses");
        }
    }
    #endregion

    #region Interfaces

    public void Drink()
    {
        Console.WriteLine("I drank something");
    }

    void IJuice.DoGulp()
    {
        if (highSugar)
        {
            Sip?.Invoke($"{this.name} has high level of sugar. Please, take water");
           // throw new HumanException(this);
        }
        else
        {
            Sip?.Invoke($"{this.name} took a sip of juice");
        }
    }

    void IWater.DoGulp()
    {
        Sip?.Invoke($"{this.name} took a sip of water");
    }
    #endregion

    #region Delegate+Event

    public delegate void ToGulp(string drink);
    public event ToGulp Sip;

    protected bool highSugar;

    public Human(string name, int age, bool sugarLvl)
    {
        this.name = name;
        this.age = age;
        this.highSugar = sugarLvl;
    }


    #endregion
}