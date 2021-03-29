
using System;
using System.IO;

class CsvFileLogger2 : ILogger
{
    private string _messageCSV;
    private string _errorCSV;
    private string _dateTime;

    public CsvFileLogger2(string messageCSV, string errorCSV)
    {
        this._messageCSV = messageCSV;
        this._errorCSV = errorCSV;
        this._dateTime = "";
    }

    public void Log(string message)
    {
        _dateTime = DateTime.UtcNow.ToString();

        string str = _dateTime + ',' + message;
        var sw = new StreamWriter(_messageCSV, true);
        sw.WriteLine(str);
        sw.Close();

    }

    public void LogError(string errorMessage)
    {
        _dateTime = DateTime.UtcNow.ToString();

        string str = _dateTime + ',' + errorMessage;
        var sw = new StreamWriter(_errorCSV, true);
        sw.WriteLine(str);
        sw.Close();
    }
}
