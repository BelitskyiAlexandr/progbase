public abstract class Detail
{
    protected string type;
    protected bool serviceability;

    public Detail(string type, bool serviceability)
    {
        this.type = type;
        this.serviceability = serviceability;
    }
}

public class Engine : Detail
{
    private string name;

    public Engine(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Engine";
    }

    public override string ToString()
    {
        return $"Name: {this.name,-15} Type: {base.type,-20} Serviceability: {base.serviceability,-6}";
    }
}

public class Breakes : Detail
{
    private string name;

    public Breakes(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Breakes";
    }

    public override string ToString()
    {
        return $"Name: {this.name,-15} Type: {base.type,-20} Serviceability: {base.serviceability,-6}";
    }
}

public class Transmission : Detail
{
    private string name;

    public Transmission(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Transmission";
    }

    public override string ToString()
    {
        return $"Name: {this.name,-15} Type: {base.type,-20} Serviceability: {base.serviceability,-6}";
    }
}

public class Wheels : Detail
{
    private string name;

    public Wheels(string type, bool serviceability) : base(type, serviceability)
    {
        this.name = "Wheels";
    }

    public override string ToString()
    {
        return $"Name: {this.name,-15} Type: {base.type,-20} Serviceability: {base.serviceability,-6}";
    }
}