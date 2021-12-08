using System;


class Program
{
    static void Main(string[] args)
    {
        Human human = new Human(new Currency());
        human.GiveMoney();
        human.setMoney = new Bank();
        human.GiveMoney();
        human.setMoney = new Shares();
        human.GiveMoney();
    }
}

interface ISetMoney
{
    void PayFor();
}

class Currency : ISetMoney
{
    public void PayFor()
    {
        Console.WriteLine("Currency was purchased");
    }
}

class Bank : ISetMoney
{
    public void PayFor()
    {
        Console.WriteLine("Money was put on deposit");
    }
}

class Shares : ISetMoney
{
    public void PayFor()
    {
        Console.WriteLine("Shares was purchased");
    }
}
class Human
{
    public Human(ISetMoney setMoney)
    {
        this.setMoney = setMoney;
    }
    public ISetMoney setMoney { private get; set; }

    public void GiveMoney()
    {
        setMoney.PayFor();
    }
}