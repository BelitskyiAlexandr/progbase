
public class Mechanic : Worker
{
    public Mechanic (string name, int age) : base(name, age)
    {
        base.post = "Mechanic";
    }
    
}