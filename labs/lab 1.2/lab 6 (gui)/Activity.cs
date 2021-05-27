using System;

public class Activity
{
    public long id;
    public string type;
    public string title;
    public string commentary;
    public double distance;
    public DateTime timeOfCreation;

    public override string ToString()
    {
        return $"[{id}] - {type}: {title}; {commentary}";
    }
}