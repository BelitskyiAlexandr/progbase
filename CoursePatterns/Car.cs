
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

    public Car RandomCar()
    {
        string[] engines = { "sport", "economic", "off-road" };
        string[] breaks = { "hydro", "air", "electro", "vacuum" };
        string[] transmission = { "mechanic", "hydro", "automatic", "electro-mechanic" };
        string[] wheels = { "summer", "winter", "all-season" };
        bool[] serviceability = { true, false };

        Random rnd = new Random();

        return new Car(
        new Engine(engines[rnd.Next(0, engines.Length)],serviceability[rnd.Next(0,serviceability.Length)]), 
        new Breakes(breaks[rnd.Next(0, breaks.Length)],serviceability[rnd.Next(0,serviceability.Length)]),
        new Transmission(transmission[rnd.Next(0, transmission.Length)],serviceability[rnd.Next(0,serviceability.Length)]),
        new Wheels(wheels[rnd.Next(0, wheels.Length)],serviceability[rnd.Next(0,serviceability.Length)]));
    }

    public override string ToString()
    {
        return $"{this.engine.ToString()} \n{this.breaks.ToString()}\n{this.transmission.ToString()}\n{this.wheels.ToString()}";
    }
}