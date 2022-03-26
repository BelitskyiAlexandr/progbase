public abstract class Detail
{
    protected string type;
    protected bool serviceability;
    protected string name;

    public Detail(string type, bool serviceability)
    {
        this.type = type;
        this.serviceability = serviceability;
    }

    #region Properties
    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }
    public bool Serviceability
    {
        get { return this.serviceability; }
        set { this.serviceability = value; }
    }
    #endregion
  
    public override string ToString()
    {
        return $"Name: {this.name,-15} Type: {this.type,-20} Serviceability: {this.serviceability,-6}";
    }
}

public class Engine : Detail
{
    public Engine(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Engine";
    }
}

public class Breakes : Detail
{
    public Breakes(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Breakes";
    }
}

public class Transmission : Detail
{
    public Transmission(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Transmission";
    }
}

public class Wheels : Detail
{
    public Wheels(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Wheels";
    }
}