using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        XmlSerializer ser = new XmlSerializer(typeof(Library));
        StreamReader reader = new StreamReader("./data.xml");
        Library newLib = (Library)ser.Deserialize(reader);
        reader.Close();
        Console.WriteLine("Library name: {0}", newLib.name);
        foreach(var book in newLib.books)
        {
            Console.WriteLine(book);
            Console.WriteLine("+-----------+");
        }
        double sum = 0;
        double maxPrice = 0;
        int index = 0;
        for(int i = 0; i < newLib.books.Count; i++)
        {
            sum += newLib.books[i].price;
            if (maxPrice < newLib.books[i].price)
            {
                maxPrice = newLib.books[i].price;
                index = i;
            }
        }
        Console.WriteLine($"Cost of all books: {sum}\r\n-------------\r\nThe most expensive book:\r\n{newLib.books[index]}");
    }
}

[XmlRoot("library")]
public class Library
{
    [XmlAttribute()]
    public string name;
    [XmlElement("book")]
    public List<Book> books;
}

public class Book{
    public string title;
    public string authors;
    [XmlAttribute()]
    public double price;

    public override string ToString()
    {
        return $"Name: {title}\r\nAuthor: {authors}\r\nPrice: {price}";
    }
}

