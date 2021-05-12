using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("root")]
public class Root
{
    [XmlElement("course")]
    public List<Course> courses;
}