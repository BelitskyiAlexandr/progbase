using System;
using static System.Console;
using System.Diagnostics;

namespace ElCal_1._1
{
    class Event
    {
        public DateTime dateOfEvent;
        public string nameOfEvent;
        public string tipToEvent;

        public Event()
        {
            nameOfEvent = "Default";
            dateOfEvent = new DateTime();
            tipToEvent = "None";
        }

        public Event(DateTime date, string tip, string name)
        {
            nameOfEvent = name;
            tipToEvent = tip;
            dateOfEvent = date;
        }

        public Event (DateTime eventTime)
        {
            dateOfEvent = eventTime;
        }
        public TimeSpan TimeToEvent (DateTime date1, DateTime date2)
        {
            return date1.Subtract(date2);
        }

        public override string ToString()
        {
            return string.Format("Event: {0} \r\nWhen: {1} \r\nTip: {2}\r\n", nameOfEvent, dateOfEvent,tipToEvent);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTests();

            Event jesusBirth = new Event();
            Event east = new Event( new DateTime(2021,5,2), "paint the eggs", "East");
            Event newCentury = new Event(new DateTime(2101,1,1),"Hello after 80 years", "XXII");

            WriteLine(jesusBirth.ToString());
            WriteLine(east.ToString());
            WriteLine(newCentury.ToString());

            WriteLine("From nowadays to {0} is {1}", nameof(newCentury), newCentury.TimeToEvent(newCentury.dateOfEvent, DateTime.Now));
            WriteLine();
            WriteLine("From {0} to {1} is {2}",nameof(jesusBirth), nameof(newCentury), jesusBirth.TimeToEvent(newCentury.dateOfEvent, jesusBirth.dateOfEvent));
        }
    
        static void RunTests()
        {
            Debug.Assert(new Event(new DateTime(2000,1,1)).TimeToEvent(new DateTime(2021,1,1), new DateTime(2000,1,1)).Days == 7671);
            Debug.Assert(new Event(new DateTime(2000,1,1)).TimeToEvent(new DateTime(2000,1,2), new DateTime(2000,1,1)).TotalHours == 24);
            Debug.Assert(new Event(new DateTime(2000,1,1)).TimeToEvent(new DateTime(2000,1,2), new DateTime(2000,1,1)).Days == 1);
        }
    }
}
