using System;
using System.Collections.Generic;
using System.IO;


/*
SerializeProcess - Serialize (запис у файл)  !_ save {filename}
DeserializeProcess - Deserialize (читка з файлу)  -- ОБОВ'ЯЗКОВО ДОДАТИ НА ІНШІ ДІЇ ПЕРЕВІРКУ ЗАГРУЗКИ ФАЙЛУ !- load {filename}


GetTitles - IsExist subject
Export - n > 0 AND n < root.courses.count 
GetPage - перевірку на >= 1 AND < pages
*/

class Program
{
    static void Main(string[] args)
    {
        Root root = new Root();
        List<string> list = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command: ");
            string command = Console.ReadLine();
            string[] subcommands = command.Split(" ");
            if (command == "exit")
            {
                Console.WriteLine("Ending processing...");
                break;
            }
            else if (subcommands[0] == "subjects")
            {
                if (subcommands.Length != 1)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have only name of command");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    var subjects = GetData.GetSubjects(root);
                    for (int i = 1; i <= subjects.Count; i++)
                    {
                        Console.Write("[{0}]\t ", subjects[i - 1]);
                        if (i % 8 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (subcommands[0] == "instructors")
            {
                if (subcommands.Length != 1)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have only name of command");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    var instructors = GetData.GetInstructors(root);
                    for (int i = 1; i <= instructors.Count; i++)
                    {
                        Console.Write("{0, -17} ", instructors[i - 1]);
                        if (i % 8 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
            else if (subcommands[0] == "load")
            {
                if (subcommands.Length != 2)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have additional argument");
                }
                else
                {
                    if (File.Exists(subcommands[1]))
                    {
                        if (subcommands[1].EndsWith(".xml"))
                        {
                            root = XmlProcess.Deserialize(subcommands[1]);
                            Console.WriteLine("Tip: Xml was upload");
                        }
                        else
                        {
                            Console.WriteLine("Error: check type of input file. Must be xml");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: file `{subcommands[1]}` does not exist");
                    }
                }
            }
            else if (subcommands[0] == "print")
            {
                if (subcommands.Length != 2)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have additional argument");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    if (int.TryParse(subcommands[1], out int page))
                    {
                        if (page < 1 || page > 141)
                        {
                            Console.WriteLine("Error: Wrong page number. Must be 1 - 141, but have `{0}`", page);
                        }
                        else
                        {
                            GetData.PrintPage(root, page);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: argument must be integer number");
                    }
                }
            }
            else if (subcommands[0] == "save")
            {
                if (subcommands.Length != 2)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have additional argument");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    if (subcommands[1].EndsWith(".xml"))
                    {
                        XmlProcess.Serialize(subcommands[1], root);
                        Console.WriteLine("Tip: Xml was saved");
                    }
                    else
                    {
                        Console.WriteLine("Error: check type of output file. Must be xml");
                    }
                }
            }
            else if (subcommands[0] == "image")
            {
                if (subcommands.Length != 2)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have additional argument");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    if (subcommands[1].EndsWith(".png"))
                    {
                        ImageProcess.CreateImage(subcommands[1], root);
                        Console.WriteLine("Tip: Diagram was saved");
                    }
                    else
                    {
                        Console.WriteLine("Error: check type of output file. Must be png");
                    }
                }
            }
            else if (subcommands[0] == "subject")
            {
                if (subcommands.Length != 2)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have additional argument");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    string subject = "";
                    for (int i = 0; i < root.courses.Count; i++)
                    {
                        if (root.courses[i].subject == subcommands[1])
                        {
                            subject = subcommands[1];
                            break;
                        }
                    }
                    if (subject == "")
                    {
                        Console.WriteLine($"Error: Subject {subcommands[1]} does not found");
                    }
                    else
                    {
                        var titles = GetData.GetTitles(root, subject);
                        for (int i = 1; i <= titles.Count; i++)
                        {
                            Console.Write("[{0}]\t ", titles[i - 1]);
                            if (i % 8 == 0)
                            {
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            else if (subcommands[0] == "export")
            {
                if (subcommands.Length != 3)
                {
                    Console.WriteLine($"Error: Command `{subcommands[0]}` must have 2 additional argument");
                }
                else if (root.courses == null)
                {
                    Console.WriteLine("Error: firstly, upload xml");
                }
                else
                {
                    if (int.TryParse(subcommands[1], out int n))
                    {
                        if (n < 1 || n > root.courses.Count)
                        {
                            Console.WriteLine($"Error: Wrong number. Must be 1 - {root.courses.Count}, but have `{0}`", n);
                        }
                        else
                        {
                            if (subcommands[2].EndsWith(".xml"))
                            {
                                XmlProcess.Export(n,subcommands[2], root);
                                Console.WriteLine("Tip: Data was exported");
                            }
                            else
                            {
                                Console.WriteLine("Error: check type of output file. Must be xml");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: argument must be integer number");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: Unknown command {command}");
            }
        }
    }


}
