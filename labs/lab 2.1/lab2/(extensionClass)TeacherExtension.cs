using System;

public static class TeacherExtension
{
    public static void GivePresent(this Teacher teacher, string present)
    {
        teacher.Present = present;
    }
}