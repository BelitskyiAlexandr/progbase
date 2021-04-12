using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace _12._04_Xml_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            string aXMLData = @"
<Configuration>
  <filePath>./some/file/path.xml</filePath>
  <skipIntro>true</skipIntro>
  <adjustments>
    <brightness>0.7</brightness>
    <contrast>1.0</contrast>
  </adjustments>
</Configuration>
";
            XmlSerializer ser = new XmlSerializer(typeof(Configuration));
            StringReader reader = new StringReader(aXMLData);
            Configuration newConfig = (Configuration)ser.Deserialize(reader);
            reader.Close();
            Console.WriteLine($"Filepath: {newConfig.filePath}, skipIntro: {newConfig.skipIntro}, ");
            Console.Write($"adjustments: brightness: {newConfig.adjustments.brightness}, contrast: {newConfig.adjustments.contrast}");
            Console.WriteLine();
        }
    }
}

public class Configuration
{
    public string filePath;
    public bool skipIntro;
    public Adjustments adjustments;

}
[XmlType(TypeName ="adjustments")]
public class Adjustments
{
    public double brightness;
    public double contrast;
}

