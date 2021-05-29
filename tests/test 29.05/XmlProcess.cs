using System.Collections.Generic;
using System.Xml.Serialization;

public class XmlProcess
{
    public void XmlPublishers(List<Publisher> listOfPublishers, string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Publisher>));
        System.IO.StreamWriter writer = new System.IO.StreamWriter(filepath);
        ser.Serialize(writer, listOfPublishers);
        writer.Close();
    }

    public void GameByPublisher(List<Game> listOfGames, string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(List<Game>));
        System.IO.StreamWriter writer = new System.IO.StreamWriter(filepath);
        ser.Serialize(writer, listOfGames);
        writer.Close();
    }

    public void RootXml(Root root, string filepath)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Root));
        System.IO.StreamWriter writer = new System.IO.StreamWriter(filepath);
        ser.Serialize(writer, root);
        writer.Close();
    }

}