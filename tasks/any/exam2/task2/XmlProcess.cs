
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public static class XmlProcess
{
    public static void Serialize(List<Award> vectors, string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Award>));
        StreamWriter sw = new StreamWriter(filepath);
        ser.Serialize(sw, vectors);
        sw.Close();
    }

    public static Root Deserialize(string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Root));
        StreamReader sr = new StreamReader(filepath);
        Root awards = (Root)ser.Deserialize(sr);
        sr.Close();
        return awards;
    }
}
[XmlRoot("root")]
public class Root
{
    [XmlElement("row")]
    public List<Award> awards;
    public Root()
    {
        this.awards = new List<Award>();
    }
}
