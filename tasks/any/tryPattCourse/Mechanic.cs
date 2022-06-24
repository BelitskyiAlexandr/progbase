
using System.Threading.Tasks;

public class Mechanic : Worker
{
    public Mechanic(string name, int age) : base(name, age)
    {
        base.post = "Mechanic";
    }

    public async Task<Car> RepairCar(Car car)
    {
        this.isFree = false;
        car.Engine.Serviceability = true;
        car.Breakes.Serviceability = true;
        car.Transmission.Serviceability = true;
        car.Breakes.Serviceability = true;

        System.Threading.Thread.Sleep(1000);
        this.isFree = true;
        return car;
    }
}