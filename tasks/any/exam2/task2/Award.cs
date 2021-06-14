using System.Xml.Serialization;

public class Award
{
    public long id;
    [XmlElement("Year")]
    public int year;
    [XmlElement("Ceremony")]
    public int ceremony;
    [XmlElement("Award")]
    public string award;
    [XmlElement("Winner")]
    public bool winner;
    [XmlElement("Name")]
    public string name;
    [XmlElement("Film")]
    public string film;

    public Award()
    {
        this.id = 0;
        this.year = 0;
        this.ceremony = 0;
        this.award = "";
        this.winner = default;
        this.name = "";
        this.film = "";
    }

    public Award(int year, int ceremony, string award, bool winner, string name, string film)
    {
        this.year = year;
        this.ceremony = ceremony;
        this.award = award;
        this.winner = winner;
        this.name = name;
        this.film = film;
    }

    public override string ToString()
    {
        return $"[{this.id}] - {this.year}  {this.ceremony}  {this.award}";
    }
}