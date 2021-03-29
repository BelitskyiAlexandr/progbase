using System;
using System.IO;
using static System.Console;
static class ConsoleInterface
{
    public static void AddProcess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 3)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "add")
                {
                    if (int.TryParse(command[2], out int result))
                    {
                        logger.Log("Tip: is the number added: " + set.Add(result));
                    }
                    else
                    {
                        logger.LogError("Error: check correctness of value. It must be integer number");
                    }
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    static bool CheckSet(string[] command)
    {
        string set = command[0].ToLower();
        return ((set == "a") || (set == "b"));
    }

    public static void ContainsProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 3)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "contains")
                {
                    if (int.TryParse(command[2], out int result))
                    {
                        logger.Log("Tip: does the set contains the number: " + set.Contains(result));
                    }
                    else
                    {
                        logger.LogError("Error: check correctness of value. It must be integer number");
                    }
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    public static void RemoveProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 3)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "remove")
                {
                    if (int.TryParse(command[2], out int result))
                    {
                        logger.Log("Tip: is the number removed: " + set.Remove(result));
                    }
                    else
                    {
                        logger.LogError("Error: check correctness of value. It must be integer number");
                    }
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    public static void ClearProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 2)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "clear")
                {
                    set.Clear();
                    logger.Log($"Tip: set {command[0]} was cleared");
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    public static void LogProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 2)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "log")
                {
                    PrintSet(set, command);
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    static void PrintSet(ISetInt set, string[] command)
    {
        int[] arr = new int[set.GetCount];
        set.CopyTo(arr);
        Write($"Set {command[0]} is:");
        foreach (var i in arr)
        {
            Write(" " + i);
        }
        WriteLine();
    }

    public static void CountProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 2)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "count")
                {
                    logger.Log($"Tip: number of elements of set {command[0]}: " + set.GetCount);
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    public static void ReadProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 3)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "read")
                {
                    if (File.Exists($"{command[2]}"))
                    {
                        ReadSet(command[2], logger, set);
                        logger.Log("Tip: file was readed");
                    }
                    else
                    {
                        logger.LogError("Error: the specified file does not exist");
                    }
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    static bool ReadSet(string filePath, ILogger logger, ISetInt set)
    {
        var sr = new StreamReader(filePath);
        string s = "";
        while (true)
        {
            s = sr.ReadLine();
            if (s == null)
            {
                break;
            }
            if (int.TryParse(s, out int num))
            {
                set.Add(num);
            }
            else
            {
                logger.LogError("Error: check data correctness of reading file");
            }
        }
        return true;
    }

    public static void WriteProccess(ISetInt aSet, ISetInt bSet, string[] command, ILogger logger)
    {
        ISetInt set = new SetInt();
        if (command.Length != 3)
        {
            logger.LogError("Error: check correctness of command");
        }
        else
        {
            if (CheckSet(command))
            {
                set = command[0] == "a" || command[0] == "A" ? aSet : bSet;
                if (command[1] == "write")
                {
                    if (File.Exists($"{command[2]}"))
                    {
                        WriteSet(command[2], set);
                        logger.Log("Tip: set was wrote in the file");
                    }
                    else
                    {
                        logger.LogError("Error: the specified file does not exist");
                    }
                }
                else
                {
                    logger.LogError("Error: check correctness of command format");
                }
            }
            else
            {
                logger.LogError("Error: check correctness of name of set. There only can be A or B ");
            }
        }
    }

    static void WriteSet(string filePath, ISetInt set)
    {   
        File.WriteAllText($"{filePath}", String.Empty);
        int[] setArray = new int[set.GetCount];
        set.CopyTo(setArray);
        var sw = new StreamWriter(filePath, true);
        for (int i = 0; i < setArray.Length; i++)
        {
            sw.WriteLine(setArray[i]);
        }
        sw.Close();
    }
}
