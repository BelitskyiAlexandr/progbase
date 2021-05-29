public class Publisher
{
    public int id;
    public string publisher;
    public string platform;

    public override string ToString()
    {
        return $"[{id}] - {publisher}: {platform}";
    }
}