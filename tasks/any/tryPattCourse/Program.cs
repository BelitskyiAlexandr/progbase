using System;

class Program
{
    static void Main(string[] args)
    {
        Mechanic mechanic = new Mechanic("SS", 22);
        Console.WriteLine(mechanic.CheckCurrentState());

        // mechanic.Working();
        // mechanic.GoOnHoliday();
        // mechanic.GoOnHoliday();
        // mechanic.GoSickLeave();
        // mechanic.GoSickLeave();
        // mechanic.Working();
        // mechanic.Working();
        
        
        Car car = new Car();
        car = car.RandomCar();
        Console.WriteLine(car.ToString() +"\n");

        ServiceStation serviceStation = ServiceStation.getInstance();

        Administrator administrator = new Administrator("Alla", 32);
        administrator.isFree = true;
        Console.WriteLine(administrator.ToString());
       // serviceStation.AddAdministrator(administrator);

        mechanic.isFree = true;
        Console.WriteLine(mechanic.ToString());
        serviceStation.AddMechanic(mechanic);
        
        #region TestCarRepair
        // Client client = new Client("Gerd", 23, car);

        // Car buffer = car.Clone();
        // client.RepairCar(serviceStation);
        // if (Car.IsTheSameCars(buffer, car))
        // {
        //     Console.WriteLine("Car is not repaired");
        // }
        // else Console.WriteLine("Car has been repaired");
     
        #endregion
            }
}

