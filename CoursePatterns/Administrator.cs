public class Administrator : Worker
{
    public Administrator (string name, int age) : base(name, age)
    {
        base.post = "Administrator";
    }
}