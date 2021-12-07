using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Worker worker = new Worker();
        PoolBuilder builder = new ConcretePool();
        Pool concretePool = worker.Create(builder);
        Console.WriteLine(concretePool.ToString());

        builder = new PlasticPool();
        Pool plasticPool = worker.Create(builder);
        Console.WriteLine(plasticPool.ToString());

        builder = new MembranePool();
        Pool membranePool = worker.Create(builder);
        Console.WriteLine(membranePool.ToString());
    }
}

abstract class PoolBuilder
{
    public Pool pool { get; private set; }
    public void CreatePool()
    {
        pool = new Pool();
    }
    public abstract void PitConstruction();
    public abstract void FillWater();
    public abstract void SetPlants();
    public abstract void SettleInhabitants();
}

class Worker
{
    public Pool Create(PoolBuilder poolBuilder)
    {
        poolBuilder.CreatePool();
        poolBuilder.PitConstruction();
        poolBuilder.FillWater();
        poolBuilder.SetPlants();
        poolBuilder.SettleInhabitants();
        return poolBuilder.pool;
    }
}

class Pit
{
    public string pitForm { get; set; }
}
class Water
{
    public bool IsFilled { get; set; }
}
class Plants
{
    public string Name { get; set; }
}
class Animal
{
    public string Name { get; set; }
}

class Pool
{
    public Pit pit { get; set; }
    public Water water { get; set; }
    public Plants plants { get; set; }
    public Animal animals { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (pit != null)
            sb.Append("Pit: " + pit.pitForm + "\n");
        if (water != null)
            sb.Append("Is filled:" + water.IsFilled + "\n");
        if (plants != null)
            sb.Append("plants: " + plants.Name + " \n");
        if (animals != null)
            sb.Append("animals: " + animals.Name + " \n");
        return sb.ToString();
    }
}

class ConcretePool : PoolBuilder
{
    public override void PitConstruction()
    {
        this.pool.pit = new Pit { pitForm = "Concrete" };
    }

    public override void FillWater()
    {
        this.pool.water = new Water { IsFilled = true };
    }

    public override void SetPlants()
    {
        this.pool.plants = new Plants { Name = "Lilies" };
    }

    public override void SettleInhabitants()
    {
        this.pool.animals = new Animal { Name = "Frogs" };
    }
}

class PlasticPool : PoolBuilder
{
    public override void PitConstruction()
    {
        this.pool.pit = new Pit { pitForm = "Plastic" };
    }

    public override void FillWater()
    {
        this.pool.water = new Water { IsFilled = true };
    }

    public override void SetPlants()
    {
        this.pool.plants = new Plants { Name = "Sea cucumbers" };
    }

    public override void SettleInhabitants()
    {
        this.pool.animals = new Animal { Name = "Axolotls" };
    }
}

class MembranePool : PoolBuilder
{
    public override void PitConstruction()
    {
        this.pool.pit = new Pit { pitForm = "Membrane" };
    }

    public override void FillWater()
    {
        this.pool.water = new Water { IsFilled = true };
    }

    public override void SetPlants()
    {
        this.pool.plants = new Plants { Name = "Reeds" };
    }

    public override void SettleInhabitants()
    {
        this.pool.animals = new Animal { Name = "Fishes" };
    }
}