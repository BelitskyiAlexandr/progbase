
public class Client : Human
{
    private Car car; 
    public Client(string name, int age, Car car) : base(name, age)
    {
        this.car = car;
    }

    public Car Car
    {
        get { return this.car; }
    }
}