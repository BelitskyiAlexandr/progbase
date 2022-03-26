
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

    public Car RepairCar(ServiceStation serviceStation)
    {
        Mechanic mechanic = serviceStation.CheckOpportunityToRepairCar();
        if(mechanic != null)
        {
            mechanic.RepairCar(car);
            return car;        
        }
        else return this.car;       // if (car == client.RepairCar(car)) => cannot repair, try later
    }
}