
using System.Collections.Generic;

public class ServiceStation
{
    private static ServiceStation instance;

    private List<Mechanic> mechanics;
    private List<Administrator> administrators;

    public static ServiceStation getInstance()
    {
        if (instance == null)
            instance = new ServiceStation();
        return instance;
    }
    private ServiceStation()
    {
        this.mechanics = new List<Mechanic>();
        this.administrators = new List<Administrator>();
    }

    public List<Mechanic> AddMechanic(Mechanic mechanic)
    {
        this.mechanics.Add(mechanic);
        return this.mechanics;
    }

    public List<Administrator> AddAdministrator(Administrator administrator)
    {
        this.administrators.Add(administrator);
        return this.administrators;
    }

    public Mechanic CheckOpportunityToRepairCar()
    {
        foreach (var admin in this.administrators)
        {
            if (admin.isFree)
            {
                Mechanic mechanic = admin.CheckFreeMechanic(this.mechanics);
                if (mechanic != null)
                {
                    return mechanic;
                }
                return null;
            }
        }
        return null;
    }
}