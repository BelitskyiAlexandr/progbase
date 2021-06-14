using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main(string[] args)
    {
        if (args[0] == "gen_db" && args.Length == 5)
        {

            int n;
            int m;
            bool check;

            if (!File.Exists(args[1]))
            {
                Console.Error.WriteLine("Xml file wasn't found");
                return;
            }
            if (!args[1].EndsWith(".xml"))
            {
                Console.Error.WriteLine("Wrong format of xml file");
                return;
            }

            try
            {
                if (Directory.Exists(args[2]))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }


                DirectoryInfo di = Directory.CreateDirectory(args[2]);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(args[2]));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            check = int.TryParse(args[3], out n);
            if (!check || n < 0)
            {
                Console.Error.WriteLine($"n must be integer and more than 0");
                return;
            }

            check = int.TryParse(args[4], out m);
            if (!check || m < 0)
            {
                Console.Error.WriteLine($"m must be integer and more than 0");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                System.IO.File.Copy(@"data.db", args[2] + $"/data{i}.db");
                SqliteConnection connection = new SqliteConnection($"Data Source={args[2] + $"/data{i}.db"}");
                AwardRepository awardsRepository = new AwardRepository(connection);
                List<Award> awards = ReadXml(args[1], m);
                awardsRepository.Insert(awards);
            }
        }
        else if (args[0] == "merge_csv" && args.Length == 3)
        {
            if (Directory.Exists(args[1]))
            {
                List<Award> allAwards = new List<Award>();
                int fileCount = Directory.GetFiles(args[1]).Length;
                for (int i = 0; i < fileCount; i++)
                {
                    SqliteConnection connection = new SqliteConnection($"Data Source={args[1] + $"/data{i}.db"}");
                    AwardRepository awardsRepository = new AwardRepository(connection);
                    List<Award> awards = awardsRepository.GetAll();
                    foreach (Award award in awards)
                    {
                        bool exist = false;
                        foreach (var elem in allAwards)
                        {
                            if (elem.id == award.id)
                            {
                                exist = true;
                            }
                        }
                        if (!exist)
                        {
                            allAwards.Add(award);
                        }
                    }
                }
                WriteCsv(args[2], allAwards);
            }
        }
        else if (args[0] == "delete_award" && args.Length == 3)
        {
            if (Directory.Exists(args[1]))
            {
                List<Award> allAwards = new List<Award>();
                int fileCount = Directory.GetFiles(args[1]).Length;
                for (int i = 0; i < fileCount; i++)
                {
                    SqliteConnection connection = new SqliteConnection($"Data Source={args[1] + $"/data{i}.db"}");
                    AwardRepository awardsRepository = new AwardRepository(connection);
                    List<Award> awards = awardsRepository.GetAll();
                    foreach (Award award in awards)
                    {
                        if(award.name == args[2])
                        {
                            awardsRepository.DeleteByName(args[2]);
                        }
                    }

                }
            }
        }
        else
        {
            Console.Error.WriteLine("Unknown command");
            return;
        }


    }
    static void WriteCsv(string source, List<Award> awards)
    {
        StringBuilder sb = new StringBuilder("Id,Year,Ceremony,Award,Winner,Name,Film\r\n");
        foreach (Award award in awards)
        {
            sb.Append($"{Convert.ToString(award.id)}, {Convert.ToString(award.year)}, {Convert.ToString(award.ceremony)}, {award.award}, {award.winner} , {award.name} , {award.film}\r\n");
        }

        string all = sb.ToString();
        StreamWriter sw = new StreamWriter(source);
        sw.Write(all);
        sw.Close();
    }

    static List<Award> ReadXml(string source, int m)
    {
        Root root = XmlProcess.Deserialize(source);
        List<Award> list = new List<Award>();

        for (int i = 0; i < m; i++)
        {
            list.Add(root.awards[i]);
        }

        return list;
    }

}

