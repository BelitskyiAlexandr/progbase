public class Game
{
    public int rank;
    public string name;
    public int year;
    public string genre;
    public double globalSales;
    public int publisherId;

    public override string ToString()
    {
        return $"[{rank}] {name}: {globalSales}; PlId: {publisherId}";
    }
}