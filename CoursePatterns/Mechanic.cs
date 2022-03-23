
public class Mechanic : Worker
{
    public Mechanic (string name, int age, string post) : base(name, age)
    {
        base.post = post;
    }
    
}