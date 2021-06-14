
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public static class XmlProcess
{
    public static void Serialize(List<Vector> vectors, string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Vector>));
        StreamWriter sw = new StreamWriter(filepath);
        ser.Serialize(sw, vectors);
        sw.Close();
    }

    public static List<Vector> Deserialize(string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Vector>));
        StreamReader sr = new StreamReader(filepath);
        List<Vector> vectors = (List<Vector>)ser.Deserialize(sr);
        sr.Close();
        return vectors;
    }
}
