using System;
using static System.Console;
using static System.IO.File;

namespace lab_5
{
    struct Teacher
    {
        public int id;
        public string fullname;
        public string subject;
        public int age;
    }
    class Program
    {
        /*
        char+all
        char+lower  
        char+number  
        char+punct  
        
        string+print
        string+set+A new string!
        string+substr+startIndex+length
        string+lower
        string+contains+char

        csv+load
        csv+text
        csv+table
        csv+teachers
        csv+get+index
        csv+set+index+field+newValue
        csv+save
        */

        static string task2String = "Lord, save and protect.";
        static string task3CsvText = "";
        static string[,] task3Table = new string[0, 0];
        static Teacher[] task3Teachers = new Teacher[0];



        static void Main(string[] args)
        {
            WriteLine("==== Info Table ====");
            WriteLine("Char commands: char+all, char+number, char+lower, char+punct");
            WriteLine("String commands: string+print, string+set+a new string!, string+substr+startIndex+length, string+lower, string+contains+char");
            WriteLine("Csv commands: csv+load, csv+text, csv+table, csv+teachers, csv+get+index, csv+set+index+field+newValue, csv+save");
            WriteLine("To end program execution: exit");
            while (true)
            {
                WriteLine();
                Write("Enter command: ");
                string command = ReadLine();
                WriteLine("`{0}`", command);
                string[] subcommands = command.Split('+');

                if (subcommands[0] == "char")
                {
                    ProcessChar(subcommands);
                }
                else if (subcommands[0] == "string")
                {
                    ProcessString(subcommands);
                }
                else if (subcommands[0] == "csv")
                {
                    ProcessCsv(subcommands);
                }
                else if (subcommands[0] == "exit")
                {
                    break;
                }
                else
                {
                    WriteLine("Unknown command `{0}`", subcommands[0]);
                }
            }
            WriteLine("Ending of processing");
        }


        //Char block
        static void ProcessChar(string[] subcommands)
        {
            if (subcommands.Length != 2)
            {
                WriteLine("Error: should be 2 parts in char commands, but have: {0}", subcommands.Length);
                return;
            }
            if (subcommands[1] == "all")
            {
                PrintAllChars();
            }
            else if (subcommands[1] == "lower")
            {
                PrintLowerLetters();
            }
            else if (subcommands[1] == "number")
            {
                PrintCharNumb();
            }
            else if (subcommands[1] == "punct")
            {
                PrintCharPunct();
            }
            else
            {
                WriteLine("Error: Unknown char command `{0}`", subcommands[1]);
                return;
            }
        }

        static void PrintAllChars()
        {
            for (int code = 0; code < 128; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
        }
        static void PrintLowerLetters()
        {
            for (int code = 97; code <= 122; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
        }
        static void PrintCharNumb()
        {
            for (int code = 48; code <= 57; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
        }
        static void PrintCharPunct()
        {
            for (int code = 33; code <= 47; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
            for (int code = 58; code <= 64; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
            for (int code = 91; code <= 96; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
            for (int code = 123; code <= 126; code++)
            {
                WriteLine("{0}  '{1}'", code, (char)code);
            }
        }


        //String block  
        static void ProcessString(string[] subcommands)
        {
            if ((subcommands.Length != 2) && (subcommands.Length != 3) && (subcommands.Length != 4))
            {
                WriteLine("Error: must be 2-4 parts in string commands, but have: {0}", subcommands.Length);
                return;
            }
            if (subcommands[1] == "substr")
            {
                if (subcommands.Length != 4)
                {
                    WriteLine("Error: must be 4 parts in substr command, but have: {0}", subcommands.Length);
                    return;
                }
                bool ifStartIndex = Int32.TryParse(subcommands[2], out int startIndex);
                if (ifStartIndex)
                {
                    bool ifLength = Int32.TryParse(subcommands[3], out int Length);
                    if (ifLength)
                    {

                        PrintSubString(startIndex, Length);
                    }
                    else
                    {
                        WriteLine("Error: Substr length must be an integer number, but have: {0}", subcommands[3]);
                    }
                }
                else
                {
                    WriteLine("Error: Substr startIndex must be an integer number, but have: {0}", subcommands[2]);
                }
            }
            else if (subcommands[1] == "print")
            {
                if (subcommands.Length != 2)
                {
                    WriteLine("Error: must be 2 parts in string print command, but have: {0}", subcommands.Length);
                    return;
                }
                PrintString2Task();
            }
            else if (subcommands[1] == "set")
            {
                if (subcommands.Length != 3)
                {
                    WriteLine("Error: must be 3 parts in string set command, but have: {0}", subcommands.Length);
                    return;
                }
                ChangeString(subcommands[2]);
            }
            else if (subcommands[1] == "lower")
            {
                if (subcommands.Length != 2)
                {
                    WriteLine("Error: must be 2 parts in string lower command, but have: {0}", subcommands.Length);
                    return;
                }
                StringToLower();
            }
            else if (subcommands[1] == "contains")
            {
                if (subcommands.Length != 3)
                {
                    WriteLine("Error: must be 3 parts in string contains command, but have: {0}", subcommands.Length);
                    return;
                }
                if (subcommands[2].Length != 1)
                {
                    WriteLine("Error: must be 1 char in string contains command, but have: {0}", subcommands[2].Length);
                    return;
                }
                ContainChar(subcommands[2]);
            }
            else
            {
                WriteLine("Error: Unknown string command `{0}`", subcommands[1]);
                return;
            }
        }

        static void PrintSubString(int startIndex, int Length)
        {
            if (Length < 0)
            {
                WriteLine("Error: Substr length is negative ");
                return;
            }

            if (startIndex < 0)
            {
                WriteLine("Error: Substr startIndex is negative ");
                return;
            }
            string s = task2String;
            if (startIndex > s.Length)
            {
                WriteLine("Error: Substr startIndex is more than length of string ");
                return;
            }
            if ((s.Length - startIndex) < Length)
            {
                WriteLine("Error: Substr length is more than length of string");
                return;
            }
            s = task2String.Substring(startIndex, Length);
            WriteLine("Substring is: `{0}`", s);

        }
        static void PrintString2Task()
        {
            Write("Current string: `{0}`, its length is {1}", task2String, task2String.Length);
        }
        static void ChangeString(string newString)
        {
            task2String = newString;
        }
        static void StringToLower()
        {
            Write(task2String.ToLower());
        }
        static void ContainChar(string symbol)
        {
            if (task2String.Contains(symbol))
            {
                WriteLine("Current string `{0}` contains char `{1}` ", task2String, symbol);
            }
            else
            {
                WriteLine("Current string `{0}` doesn't contain char `{1}` ", task2String, symbol);
            }
        }


        //csv block
        static void ProcessCsv(string[] subcommands)
        {
            if (subcommands[1] == "load")
            {
                LoadCsv();
            }
            else if (subcommands[1] == "text")
            {
                WriteCsvText();
            }
            else if (subcommands[1] == "table")
            {
                task3Table = CsvToTable();
                PrintTable(task3Table);
            }
            else if (subcommands[1] == "teachers")
            {
                PrintTeachers();
            }
            else if (subcommands[1] == "get")
            {
                Getprocess(subcommands);
            }
            else if (subcommands[1] == "set")
            {
                SetProcess(subcommands);
            }
            else if (subcommands[1] == "save")
            {
                SaveCsv();
            }
            else
            {
                WriteLine("Error: Unknown csv command");
            }
        }
        static void LoadCsv()
        {
            task3CsvText = ReadAllText("./data.csv");
            CsvToTeacher();
            WriteLine("Tip: Csv table was uploaded");
        }
        static void CsvToTeacher()
        {
            string[] lines = ReadAllLines("./data.csv");
            int i = 0;
            Array.Resize(ref task3Teachers, task3Teachers.Length + lines.Length);
            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                task3Teachers[i].id = int.Parse(items[0]);
                task3Teachers[i].fullname = items[1];
                task3Teachers[i].subject = items[2];
                task3Teachers[i].age = int.Parse(items[3]);
                i++;
            }
            task3Table = CsvToTable();
        }
        static void PrintTeachers()
        {
            string[] lines = ReadAllLines("./data.csv");
            WriteLine("{0,3} ║ {1,-15} ║ {2,-12} ║ {3,4}║", "id", "fullname", "subject", "age");
            for (int i = 0; i < 44; i++)
            {
                Write("~");
            }
            WriteLine();
            for (int j = 0; j < lines.Length; j++)
            {
                WriteLine("{0,3} ║ {1,-15} ║ {2,-12} ║ {3,4}║", task3Teachers[j].id, task3Teachers[j].fullname, task3Teachers[j].subject, task3Teachers[j].age);
            }

        }
        static void WriteCsvText()
        {
            WriteLine(task3CsvText);
        }
        static string[,] CsvToTable()
        {
            string[] lines = task3CsvText.Split("\r\n");
            string[] column = lines[0].Split(",");
            string[,] Table = new string[lines.Length, column.Length];
            for (int i = 0; i < Table.GetLength(0); i++)
            {
                Table[i, 0] = task3Teachers[i].id.ToString();
                Table[i, 1] = task3Teachers[i].fullname;
                Table[i, 2] = task3Teachers[i].subject;
                Table[i, 3] = task3Teachers[i].age.ToString();
            }
            return Table;
        }
        static void PrintTable(string[,] Table)
        {
            WriteLine("{0,3} | {1,-15} | {2,-12} | {3,4}|", "id", "fullname", "subject", "age");
            for (int i = 0; i < 44; i++)
            {
                Write("-");
            }
            WriteLine();
            for (int i = 0; i < Table.GetLength(0); i++)
            {
                WriteLine("{0,3} | {1,-15} | {2,-12} | {3,4}|", task3Table[i, 0], task3Table[i, 1], task3Table[i, 2], task3Table[i, 3]);
            }
        }
        static void Getprocess(string[] subcommands)
        {
            bool ifIndex = Int32.TryParse(subcommands[2], out int index);
            if ((ifIndex) && (index >= 0))
            {
                if (index > task3Teachers.Length)
                {
                    WriteLine("Error: {index} is out of range");
                    return;
                }
                WriteLine("{0,3} ║ {1,-15} ║ {2,-12} ║ {3,4}║", "id", "fullname", "subject", "age");
                for (int i = 0; i < 44; i++)
                {
                    Write("-");
                }
                WriteLine();
                for (int i = 0; i < task3Teachers.Length; i++)
                {
                    if (i == index)
                    {
                        WriteLine("{0,3} ║ {1,-15} ║ {2,-12} ║ {3,4}║", task3Teachers[i].id, task3Teachers[i].fullname, task3Teachers[i].subject, task3Teachers[i].age);
                        return;
                    }
                }
            }
            else
            {
                WriteLine("Error: {index} must be a integer positive (>=0) number");
            }
        }
        static void SetProcess(string[] subcommands)
        {
            if (subcommands.Length != 5)
            {
                WriteLine("Error: must be 5 parts in csv+set command, but have: {0}", subcommands.Length);
                return;
            }
            bool ifIndex = Int32.TryParse(subcommands[2], out int index);
            if ((ifIndex) && (index >= 0))
            {
                if (index < task3Table.GetLength(0))
                {
                    if (subcommands[3] == "id")
                    {
                        bool ifNum = Int32.TryParse(subcommands[4], out int num);
                        if ((ifNum) && (num > 0))
                        {
                            for (int i = 0; i < task3Teachers.Length; i++)
                            {
                                if (num == task3Teachers[i].id)
                                {
                                    WriteLine("Error: new id must be original");
                                    return;
                                }
                            }
                            for (int i = 0; i < task3Teachers.Length; i++)
                                if (i == index)
                                {
                                    task3Teachers[i].id = num;
                                    WriteLine("Tip: Id was changed");
                                    task3Table[i, 0] = subcommands[4];
                                    TableToText();
                                    return;
                                }
                        }
                        else
                        {
                            WriteLine("Error: new value of id must be positive integer");
                            return;
                        }
                    }
                    else if (subcommands[3] == "fullname")
                    {
                        foreach (char item in subcommands[4])
                        {
                            if ((subcommands[4].Contains('"')) || (subcommands[4].Contains(',')))
                            {
                                WriteLine("Error: must not use \" and ,");
                                return;
                            }
                        }
                        for (int i = 0; i < task3Teachers.Length; i++)
                            if (i == index)
                            {
                                task3Teachers[i].fullname = subcommands[4];
                                WriteLine("Tip: Fullname was changed");
                                task3Table[i, 1] = subcommands[4];
                                TableToText();
                                return;
                            }

                    }
                    else if (subcommands[3] == "subject")
                    {
                        foreach (char item in subcommands[4])
                        {
                            if ((subcommands[4].Contains('"')) || (subcommands[4].Contains(',')))
                            {
                                WriteLine("Error: must not use \" and ,");
                                return;
                            }
                        }
                        for (int i = 0; i < task3Teachers.Length; i++)
                            if (i == index)
                            {
                                task3Teachers[i].subject = subcommands[4];
                                WriteLine("Tip: Subject was changed");
                                task3Table[i, 2] = subcommands[4];
                                TableToText();
                                return;
                            }
                    }
                    else if (subcommands[3] == "age")
                    {
                        bool ifNum = Int32.TryParse(subcommands[4], out int num);
                        if ((ifNum) && (num > 0))
                        {
                            for (int i = 0; i < task3Teachers.Length; i++)
                                if (i == index)
                                {
                                    task3Teachers[i].age = num;
                                    WriteLine("Tip: Age was changed");
                                    task3Table[i, 3] = subcommands[4];
                                    TableToText();
                                    return;
                                }
                        }
                        else
                        {
                            WriteLine("Error: new value of age must be positive integer");
                            return;
                        }
                    }
                    else
                    {
                        WriteLine("Error: can not found such field in table, but have `{0}`", subcommands[2]);
                        return;
                    }
                }
                else
                {
                    WriteLine("Error: Teacher under index {0} doesn't exist", index);
                    return;
                }

            }
            else
            {
                WriteLine("Error: index must be integer positive (>=0) number`{0}`", subcommands[2]);
                return;
            }
        }
        static void TableToText()
        {
            string[] lines = new string[task3Table.GetLength(0)];

            for (int i = 0; i < task3Table.GetLength(0); i++)
            {
                string[] item = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    item[j] = task3Table[i, j];
                }
                string line = string.Join(",", item);
                lines[i] = line;
            }
            task3CsvText = string.Join("\r\n", lines);


        }
        static void SaveCsv()
        {
            WriteAllText("./data.csv", task3CsvText);
            WriteLine("Tip: csv was updated");
        }
    }
}



