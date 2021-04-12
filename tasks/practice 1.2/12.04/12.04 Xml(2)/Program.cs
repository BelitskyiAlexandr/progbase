using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Configuration));
        StreamReader reader = new StreamReader("./data.xml");
        Configuration newConfig = (Configuration)ser.Deserialize(reader);
        reader.Close();
        Console.WriteLine($"Filepath: {newConfig.filePath}, skipIntro: {newConfig.skipIntro}, ");
        Console.Write($"adjustments: brightness: {newConfig.adjustments.brightness}, contrast: {newConfig.adjustments.contrast}");
        Console.WriteLine();

    }
}
[XmlRoot("configuration")]
public class Configuration
{
    public string filePath;
    [XmlAttribute()]
    public bool skipIntro;
    public Adjustments adjustments;

}
[XmlType(TypeName = "adjustments")]
public class Adjustments
{
    [XmlAttribute()]
    public double brightness;
    [XmlAttribute()]
    public double contrast;
}
