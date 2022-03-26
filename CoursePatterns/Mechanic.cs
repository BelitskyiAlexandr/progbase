
public class Mechanic : Worker
{
    public Mechanic (string name, int age) : base(name, age)
    {
        base.post = "Mechanic";
    }
    
    public Car RepairCar(Car car)
    {
        car.Engine.Serviceability = true;
        car.Breakes.Serviceability = true;
        car.Transmission.Serviceability = true;
        car.Breakes.Serviceability = true;
        return car;
    }
}