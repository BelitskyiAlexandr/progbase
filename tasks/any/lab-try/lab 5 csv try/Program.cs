using System;
using static System.Console;
using static System.IO.File;

namespace lab_5_csv_try
{
    struct Teacher
    {
        public int id;
        public string fullname;
        public string subject;
        public int age;
    }

    /*
    csv+load
    csv+text
    csv+table
    csv+teachers
    csv+get+index
    csv+set+index+field+newValue
    csv+save
    */
    class Program
    {
        static string task3CsvText = "";
        static string[,] task3Table = new string[0, 0];
        static Teacher[] task3Teachers = new Teacher[0];

        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine();
                Write("Enter command: ");
                string command = ReadLine();
                WriteLine("`{0}`", command);
                string[] subcommands = command.Split('+');
                if (subcommands[0] == "csv")
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
