using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;



public static class XmlProcess
{
    public static void Serialize(string outFile, Root root)   
    {
        XmlSerializer ser = new XmlSerializer(typeof(Root));
        System.IO.StreamWriter writer = new System.IO.StreamWriter(outFile);
        ser.Serialize(writer, root);
        writer.Close();
    }

    public static Root Deserialize(string inputFile)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Root));
        StreamReader reader = new StreamReader(inputFile);
        Root value = (Root)ser.Deserialize(reader);
        reader.Close();
        return value;
    }

    public static void Export(int n, string filePath, Root root)
    {
        Course[] arr = new Course[root.courses.Count];
        root.courses.CopyTo(arr);
        ///insertion sort
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (arr[j - 1].units > arr[j].units)
                {
                    var temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }

        Array.Reverse(arr);
        Root newRoot = new Root();
        List<Course> list = new List<Course>();
        newRoot.courses = list;

        for (int i = 0; i < n; i++)
        {
            newRoot.courses.Add(arr[i]);
        }
        Serialize(filePath, newRoot);
    }

}
