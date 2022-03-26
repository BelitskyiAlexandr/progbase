
using System;

public class Car
{
    private Engine engine;
    private Breakes breaks;
    private Transmission transmission;
    private Wheels wheels;

    public Car()
    {
        this.engine = new Engine("", true);
        this.breaks = new Breakes("", true);
        this.transmission = new Transmission("", true);
        this.wheels = new Wheels("", true);
    }
    public Car(Engine engine, Breakes breaks, Transmission transmission, Wheels wheels)
    {
        this.engine = engine;
        this.breaks = breaks;
        this.transmission = transmission;
        this.wheels = wheels;
    }
    #region Properties
    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }
    public Breakes Breakes
    {
        get { return this.breaks; }
        set { this.breaks = value; }
    }
    public Transmission Transmission
    {
        get { return this.transmission; }
        set { this.transmission = value; }
    }
    public Wheels Wheels
    {
        get { return this.wheels; }
        set { this.wheels = value; }
    }
    #endregion
    public Car RandomCar()
    {
        string[] engines = { "sport", "economic", "off-road" };
        string[] breaks = { "hydro", "air", "electro", "vacuum" };
        string[] transmission = { "mechanic", "hydro", "automatic", "electro-mechanic" };
        string[] wheels = { "summer", "winter", "all-season" };
        bool[] serviceability = { true, false };

        Random rnd = new Random();

        return new Car(
        new Engine(engines[rnd.Next(0, engines.Length)], serviceability[rnd.Next(0, serviceability.Length)]),
        new Breakes(breaks[rnd.Next(0, breaks.Length)], serviceability[rnd.Next(0, serviceability.Length)]),
        new Transmission(transmission[rnd.Next(0, transmission.Length)], serviceability[rnd.Next(0, serviceability.Length)]),
        new Wheels(wheels[rnd.Next(0, wheels.Length)], serviceability[rnd.Next(0, serviceability.Length)]));
    }

    public override string ToString()
    {
        return $"{this.engine.ToString()} \n{this.breaks.ToString()}\n{this.transmission.ToString()}\n{this.wheels.ToString()}";
    }

    public Car Clone() => new Car(new Engine(engine.Type, engine.Serviceability), new Breakes(breaks.Type, breaks.Serviceability),
     new Transmission(transmission.Type, transmission.Serviceability), new Wheels(wheels.Type, wheels.Serviceability));


    public static bool IsTheSameCars(Car car1, Car car2)
    {
        if (car1.engine.Type == car2.engine.Type && car1.engine.Serviceability == car2.engine.Serviceability)
        {
            if (car1.breaks.Type == car2.breaks.Type && car1.breaks.Serviceability == car2.breaks.Serviceability)
            {
                if (car1.transmission.Type == car2.transmission.Type && car1.transmission.Serviceability == car2.transmission.Serviceability)
                {
                    if (car1.wheels.Type == car2.wheels.Type && car1.wheels.Serviceability == car2.wheels.Serviceability)
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }
}