using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

class StringBuilder
{
    private string[] _strings;
    private int _size;

    public StringBuilder()
    {
        this._strings = new string[16];
        this._size = 0;
    }

    public StringBuilder Append(string str)
    {
        if (this._size == this._strings.Length)
        {
            this.Expand();
        }
        this._strings[this._size] = str;
        this._size += 1;
        return this;
    }

    private void Expand()
    {
        int oldCapacity = this._strings.Length;
        string[] oldArray = this._strings;
        this._strings = new string[oldCapacity * 2];
        System.Array.Copy(oldArray, this._strings, oldCapacity);
    }

    private int GetTotalLength()
    {
        int charCounter = 0;
        for (int i = 0; i < this._size; i++)
        {
            string str = this._strings[i];
            charCounter += str.Length;
        }
        return charCounter;
    }

    public override string ToString()
    {
        int charCounter = this.GetTotalLength();
        char[] buffer = new char[charCounter];
        int index = 0;
        for (int i = 0; i < this._size; i++)
        {
            string str = this._strings[i];
            System.Array.Copy(str.ToCharArray(), 0, buffer, index, str.Length);
            index += str.Length;
        }
        string allString = new string(buffer);
        return allString;
    }
}


class Program
{
    static void Main(string[] args)
    {
        StringBuilder sb1 = new StringBuilder();
        int pageNumber = 17;
        bool page = false;

        const string url = "https://tools.ietf.org/html/rfc4648";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.UserAgent = "ConsoleTest";
        Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();

        StreamReader streamReader = new StreamReader(responseStream);
        string line = "";
        while (line != null)
        {
            line = streamReader.ReadLine();
            if (line != null)
            {
                line = WebUtility.HtmlDecode(Regex.Replace(line, "<[^>]*(>|$)", ""));
                //Console.WriteLine(line);


                if (line.Contains($"[Page {pageNumber+1}]"))        //спробував зробити жалку пародію на FSA 
                {
                    page = false;
                }
                if (page == true)
                {
                    sb1.Append(line.ToString()).Append("\r\n");
                }
                if (line.Contains($"[Page {pageNumber}]"))
                {
                    page = true;
                    sb1.Append(line.ToString()).Append("\r\n");
                }
            }
        }
        streamReader.Close();
        Console.WriteLine(sb1);
    }
}
