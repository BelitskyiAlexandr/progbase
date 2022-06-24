
public class Client : Human
{
    public Car car { get; private set; }
    public Client(string name, int age, Car car) : base(name, age)
    {
        this.car = car;
    }

    public Car RepairCar(ServiceStation serviceStation)
    {
        Mechanic mechanic = serviceStation.CheckOpportunityToRepairCar();
        if (mechanic != null)
        {
            car = mechanic.RepairCar(car).Result;
            return car;
        }
        else return this.car;       // if (car == client.RepairCar(car)) => cannot repair, try later
    }

    public void Run(ServiceStation serviceStation)
    {
        while (true)
        {
            System.Threading.Thread.Sleep(10_000);
            this.RepairCar(serviceStation);
        }
    }

}