using System;

public class Birthday
{
    private Birthday() { }

    public static void HappyBirthday(Human human)
    {
        human.Age = human.Age + 1;
        Console.WriteLine("{0} is {1} years old now", human.Name, human.Age);
    }
}