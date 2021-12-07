using System;

class Program
{
    static void Main(string[] args)
    {
        string[] pages1 = new string[] { "page1", "page2", "page3" };
        string[] pages2 = new string[] { "PAGE1", "PAGE2", "PAGE3" };
        Book[] books = new Book[] { new Book(1, "Lev", "Kyiv", pages1), new Book(2, "Bob", "Odessa", pages2)};
        Prototype book1 = books[0];
        Prototype clonedBook1 =  book1.Clone();
        book1.GetInfo();
        book1.GetPages();
        Console.WriteLine("------");
        clonedBook1.GetInfo();
        clonedBook1.GetPages();
    
    }
}

abstract class Prototype
{
    private int _editionNumber;
    public Prototype(int id)
    {
        this._editionNumber = id;
    }
    public int EditionNumber
    {
        get { return _editionNumber; }
    }
    public abstract Prototype Clone();
    public abstract void GetInfo();
    public abstract void GetPages();
}

class Book : Prototype
{
    private string _author;
    private string _publishing;
    string[] pages;

    public Book(int editionNumber, string author, string publishing, string[] pages) : base(editionNumber)
    {
        this._author = author;
        this._publishing = publishing;
        this.pages = pages;
    }
    public override Prototype Clone()
    {
        return this.MemberwiseClone() as Prototype;
    }

    public override void GetInfo()
    {
        Console.WriteLine($"Author : {this._author}\nPublishing : {this._publishing}\nNumber of publishing : {this.EditionNumber}\nNumber of pages : {this.pages.Length}");
    }

    public override void GetPages()
    {
        Console.WriteLine("Pages: ");
        foreach(var item in pages)
            Console.WriteLine($"\t{item}");
    }
}
