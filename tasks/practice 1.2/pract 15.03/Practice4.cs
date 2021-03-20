using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

interface ICommandSource
{
    string GetNextCommand();
}

interface IOutputTarget
{
    void Output(string result);
    void OutputError(string error);
}

class ConsoleSource : ICommandSource
{
    public string GetNextCommand()
    {
        return Console.ReadLine();
    }
}

class ConsoleTarget : IOutputTarget
{
    public void Output(string result)
    {
        StreamWriter sw = new StreamWriter("out.txt", true);
        sw.WriteLine(result);
        sw.Close();
    }

    public void OutputError(string error)
    {
        StreamWriter sw = new StreamWriter("outerror.txt", true);
        sw.WriteLine(error);
        sw.Close();
    }
}

class Program
{
    static void Main()
    {
        ProcessCommands(new ConsoleSource(), new ConsoleTarget());
    }

    static void ProcessCommands(ICommandSource source, IOutputTarget target)
    {
        Stack<int> stack = new Stack<int>();
        string command = null;
        do
        {
            command = source.GetNextCommand();
            if (string.IsNullOrWhiteSpace(command))
            {
                continue;
            }

            if (command == "count")
            {
                target.Output("Stack count: " + stack.Count);
            }
            else if (command.StartsWith("push "))
            {
                string arg = command.Substring("push ".Length);
                int newValue;
                if (!int.TryParse(arg, out newValue))
                {
                    target.OutputError("Push command should have a number. Got: " + arg);
                    continue;
                }

                stack.Push(newValue);
                target.Output("Push value: " + newValue);
            }
            else if (command == "pop")
            {
                if (stack.Count == 0)
                {
                    target.OutputError("Pop command on empty stack");
                    continue;
                }

                int popValue = stack.Pop();
                target.Output("Pop value: " + popValue);
            }
            else if (command == "print")
            {
                if (stack.Count == 0)
                {
                    target.Output("Stack is empty");
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (int item in stack)
                    {
                        sb.Append(item).Append(", ");
                    }
                    target.Output(sb.ToString());
                }
            }
            else
            {
                target.OutputError("Unknown command: " + command);
            }
        }
        while (!string.IsNullOrWhiteSpace(command));
    }
}
