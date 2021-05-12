
using System;
using System.Collections.Generic;

public static class GetData
{
    public static List<string> GetSubjects(Root root)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < root.courses.Count; i++)
        {
            if (list.Contains(root.courses[i].subject.ToString()) == false)
            {
                list.Add(root.courses[i].subject.ToString());
            }
        }
        return list;

    }

    public static List<string> GetTitles(Root root, string subject)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < root.courses.Count; i++)
        {
            if (root.courses[i].subject == subject)
            {
                if (list.Contains(root.courses[i].course.ToString()) == false)
                {
                    list.Add(root.courses[i].course.ToString());
                }
            }
        }
        return list;
    }

    public static List<string> GetInstructors(Root root)
    {
        List<string> list = new List<string>();
        for (int i = 0; i < root.courses.Count; i++)
        {
            if (list.Contains(root.courses[i].instructor.ToString()) == false)
            {
                list.Add(root.courses[i].instructor.ToString());
            }
        }
        return list;
    }
    public static void PrintPage(Root root, int page)
    {
        Course[] arr = new Course[root.courses.Count];
        root.courses.CopyTo(arr);

        int pageSize = 5;
        int pages = GetTotalPages(arr);
        Console.WriteLine($"+-----------------------------------------------------{page} / {pages}-------------------------------------------------------+");
        for (int i = 0; i < pageSize; i++)
        {
            if (pageSize * (page - 1) + i >= arr.Length)
            {
                continue;
            }
            Console.Write("Register number: `" + arr[pageSize * (page - 1) + i].registerNumber + "` ");
            Console.Write("Subject: [" + arr[pageSize * (page - 1) + i].subject + "]; ");
            Console.Write("Course: `" + arr[pageSize * (page - 1) + i].course + "`; ");
            Console.Write("Sector: [" + arr[pageSize * (page - 1) + i].sector + "]; ");
            Console.WriteLine("Title: \"" + arr[pageSize * (page - 1) + i].title + "\" ");
            Console.Write("\tUnits: `" + arr[pageSize * (page - 1) + i].units + "`; ");
            Console.Write("Instructor: " + arr[pageSize * (page - 1) + i].instructor + "; ");
            Console.WriteLine("Days: [" + arr[pageSize * (page - 1) + i].days + "] ");
            Console.Write("\t\tStart time: `" + arr[pageSize * (page - 1) + i].time.startTime + "`; ");
            Console.WriteLine("End time: `" + arr[pageSize * (page - 1) + i].time.endTime + "` ");
            Console.Write("\t\tBuilding: [" + arr[pageSize * (page - 1) + i].place.building + "]; ");
            Console.WriteLine("Room: [" + arr[pageSize * (page - 1) + i].place.room + "] ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

    }

    public static int GetTotalPages(Course[] arr)
    {
        const int pageSize = 5;
        return (int)Math.Ceiling(arr.Length / (double)pageSize);
    }
}
