
using System;

public class Car
{
    private string engine;
    private string breaks;
    private string transmission;
    private string wheels;

    public Car()
    {
        this.engine = "";
        this.breaks = "";
        this.transmission = "";
        this.wheels = "";
    }
    public Car(string engine, string breaks, string transmission, string wheels)
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

        Random rnd = new Random();

        return new Car(engines[rnd.Next(0, engine.Length)], breaks[rnd.Next(0, breaks.Length)],
                       transmission[rnd.Next(0, transmission.Length)], wheels[rnd.Next(0, wheels.Length)]);
    }

    public override string ToString()
    {
        return $"Engine: {this.engine,-35} Breakes: {this.breaks,-10}\nTransmission: {this.transmission,-29} Wheels: {this.wheels,-10}";
    }
}