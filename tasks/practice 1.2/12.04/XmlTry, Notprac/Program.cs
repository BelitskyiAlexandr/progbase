using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student{name="Anna", group="91"},
            new Student{name="Taras", group="92"},
        };
        Root root = new Root
        {
            students = students,
        };

        XmlSerializer ser = new XmlSerializer(typeof(Root));
        ser.Serialize(Console.Out, root);

        string xmlData =@"<Root><students><Student><name>Anna</name><group>91</group></Student><Student><name>Taras</name><group>92</group></Student></students></Root>";
        StringReader reader = new StringReader(xmlData);
        Root newRoot = (Root)ser.Deserialize(reader);
        reader.Close();
    }
}

public class Student
{
    public string name;
    public string group;
}

public class Root
{
    public List<Student> students;
}



