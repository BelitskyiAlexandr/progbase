using System.Xml.Serialization;

public class Course
{
    [XmlElement("reg_num")]
    public int registerNumber;
    [XmlElement("subj")]
    public string subject;
    [XmlElement("crse")]
    public string course;
    [XmlElement("sect")]
    public string sector;
    public string title;
    public double units;
    public string instructor;
    public string days;
    public Time time;
    public Place place;
}
[XmlType(TypeName = "time")]
public class Time
{
    [XmlElement("start_time")]
    public string startTime;
    [XmlElement("end_time")]
    public string endTime;
}
[XmlType(TypeName = "place")]
public class Place
{
    public string building;
    public string room;
}