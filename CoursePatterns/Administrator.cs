public class Administrator : Worker
{
    public Administrator (string name, int age, string post) : base(name, age)
    {
        base.post = post;
    }
}