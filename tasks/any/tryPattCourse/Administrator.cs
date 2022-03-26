using System.Collections.Generic;

public class Administrator : Worker
{
    public Administrator (string name, int age) : base(name, age)
    {
        base.post = "Administrator";
    }

    public Mechanic CheckFreeMechanic(List<Mechanic> mechanics)
    {
        foreach(var mechanic in mechanics)
        {
            if(mechanic.isFree)
            {
                return mechanic;
            }
        }
        return null;
    }
}