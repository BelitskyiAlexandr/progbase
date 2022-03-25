public abstract class Human
{
     private string name;
    private int age;

    public Human(string name, int age)                //де буде додавання нового робітника зробити перевірку на "нульового" робітника
    {
        if (CheckAge(age))
        {
            if (CheckString(name))
            {
                this.age = age;
                this.name = name;
            }
            else return;
        }
        else return;
    }

    #region Properties
    public string Name
    {
        get { return this.name; }
    }

    public int Age
    {
        get { return this.age; }
    }

    #endregion

    #region CheckValidInput
    private bool CheckAge(int age)
    {
        if (age <= 18 || age > 60)
        {
            return false;
        }
        return true;
    }

    private bool CheckString(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return false;
        }
        return true;
    }
    #endregion

}