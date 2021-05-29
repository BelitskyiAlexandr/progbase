using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Data.Sqlite;
using static System.IO.File;


class Program
{
    static void Main(string[] args)
    {
        string filepath = "./database/videogamessales";
        SqliteConnection connection = new SqliteConnection($"Data Source={filepath}");

        GameRepository gameRepository = new GameRepository(connection);
        PublisherRepository publisherRepository = new PublisherRepository(connection);

        XmlProcess xmlProcess = new XmlProcess();

        while (true)
        {
            Console.WriteLine("Enter command: ");
            string command = Console.ReadLine();
            string[] commands = command.Split(' ');
            if (commands.Length <= 3)
            {
                Console.Error.WriteLine("Error: incorrect command format");
            }
            else if (command.StartsWith("import"))
            {
                if (commands[1] == "games")
                {
                    if (commands[2].EndsWith(".csv") && System.IO.File.Exists(commands[2]))
                    {
                        ProcessGameCsv(commands, gameRepository);
                    }
                    else
                    {
                        Console.Error.WriteLine("Error: incorrect filetype or filepath");
                    }

                }
                else if (commands[1] == "publishers")
                {
                    if (commands[2].EndsWith(".csv") && System.IO.File.Exists(commands[2]))
                    {
                        ProcessPublishCsv(commands, publisherRepository);
                    }
                    else
                    {
                        Console.Error.WriteLine("Error: incorrect filetype or filepath");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Error: unknown table name");
                }
            }
            else if (command.StartsWith("delete"))
            {
                if (commands[2] == "publishers")
                {
                    ProccessPublishersDelete(publisherRepository);
                }
                else if (commands[2] == "games")
                {
                    ProcessGamesDelete(gameRepository);
                }
                else
                {
                    Console.Error.WriteLine("Error: unknown command");
                }
            }
            else if (command.StartsWith("print"))
            {
                if (commands[2] == "publishers")
                {
                    ProcessPrintPublishers(publisherRepository);
                }
                else if (commands[2] == "games")
                {
                    ProcessPrintGames(gameRepository);
                }
                else
                {
                    Console.Error.WriteLine("Error: unknown command");
                }
            }
            else if (command.StartsWith("export"))  // export publishers .xml
                                                    // export `publishId` games .xml
            {                                       // export `gameName` game .xml
                if (commands[2] == "games")
                {
                    if (commands[3].EndsWith(".xml") && System.IO.File.Exists(commands[3]))
                    {
                        ProcessGamesXml(commands, gameRepository, publisherRepository, xmlProcess);
                    }
                    else
                    {
                        Console.Error.WriteLine("Error: incorrect filetype or filepath");
                    }

                }
                if (commands[2] == "game")
                {
                    if (commands[3].EndsWith(".xml") && System.IO.File.Exists(commands[3]))
                    {
                        ProcessPublishersByGame(commands, gameRepository, publisherRepository, xmlProcess);
                    }
                    else
                    {
                        Console.Error.WriteLine("Error: incorrect filetype or filepath");
                    }

                }
                else if (commands[1] == "publishers")
                {
                    if (commands[2].EndsWith(".xml") && System.IO.File.Exists(commands[2]))
                    {
                        ProcessPublishersXml(commands, publisherRepository, xmlProcess);
                    }
                    else
                    {
                        Console.Error.WriteLine("Error: incorrect filetype or filepath");
                    }
                }
                else
                {
                    Console.Error.WriteLine("Error: unknown command");
                }
            }
        }
    }

    static void ProcessPrintGames(GameRepository gameRepository)
    {
        foreach (var game in gameRepository.GetAll())
        {
            Console.WriteLine(game);
        }
    }

    static void ProcessPrintPublishers(PublisherRepository publisherRepository)
    {
        foreach (var publisher in publisherRepository.GetAll())
        {
            Console.WriteLine(publisher);
        }
    }
    static void ProcessGamesDelete(GameRepository repository)
    {
        foreach (var game in repository.GetAll())
        {
            repository.Delete(game.rank);
        }
    }
    static void ProccessPublishersDelete(PublisherRepository repository)
    {
        foreach (var publish in repository.GetAll())
        {
            repository.Delete(publish.id);
        }
    }

    static void ProcessPublishersByGame(string[] commands, GameRepository gameRepository, PublisherRepository publisherRepository, XmlProcess xmlProcess)
    {
        if (commands.Length != 4)
        {
            Console.Error.WriteLine("Error: incorrect command format");
            return;
        }
        if (String.IsNullOrWhiteSpace(commands[1]))
        {
            Console.Error.WriteLine("Incorrect name value in csv");
            return;
        }


    }

    static void ProcessGamesXml(string[] commands, GameRepository gameRepository, PublisherRepository publisherRepository, XmlProcess xmlProcess)
    {
        if (commands.Length != 4)
        {
            Console.Error.WriteLine("Error: incorrect command format");
            return;
        }
        if (int.TryParse(commands[1], out int id) && (id > 0) && (id < publisherRepository.CountRecords()))
        {
            List<Game> listOfGames = gameRepository.GetByPublishId(id);
            xmlProcess.GameByPublisher(listOfGames, commands[3]);
        }
        else
        {
            Console.Error.WriteLine("Incorrect publisher id");
            return;
        }
        List<Game> gamesList = gameRepository.GetGamesByName(commands[2]);
        List<Publisher> publishersList = publisherRepository.GetAll();

        List<Publisher> releasePublishersList = new List<Publisher>();

        foreach (var game in gamesList)
        {
            foreach (var publisher in publishersList)
            {
                if (game.publisherId == publisher.id)
                {
                    releasePublishersList.Add(publisher);
                }
            }
        }

        for (int i = 0; i < releasePublishersList.Count; i++)
        {
            for (int j = 0; j < releasePublishersList.Count - 1; j++)
            {
                if (needToReorder(releasePublishersList[j].publisher, releasePublishersList[j + 1].publisher))
                {
                    var buffer = releasePublishersList[j];
                    releasePublishersList[j] = releasePublishersList[j + 1];
                    releasePublishersList[j + 1] = buffer;
                }
            }
        }

        releasePublishersList.Reverse();

        Root root = new Root
        {
            game = gamesList[0],
            publishers = releasePublishersList,
        };

        xmlProcess.RootXml(root, commands[3]);
    }

    static bool needToReorder(string s1, string s2)
    {
        for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
        {
            if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
            if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
        }
        return false;
    }


    static void ProcessPublishCsv(string[] commands, PublisherRepository publisherRepository)
    {
        if (commands.Length != 3)
        {
            Console.Error.WriteLine("Error: incorrect command format");
            return;
        }

        string[] csvLines = ReadAllLines(commands[2]);

        foreach (string line in csvLines)
        {
            string[] components = line.Split(",");

            if (ParsePublisherLine(components))
            {
                int.TryParse(components[0], out int id);

                Publisher publish = new Publisher();
                publish.id = id;
                publish.publisher = components[1];
                publish.platform = components[2];

                publisherRepository.Import(publish);
            }
            else return;
        }
    }

    static void ProcessPublishersXml(string[] commands, PublisherRepository publisherRepository, XmlProcess xmlProcess)
    {
        if (commands.Length != 3)
        {
            Console.Error.WriteLine("Error: incorrect command format");
            return;
        }
        List<Publisher> listOfPublishers = publisherRepository.GetAll();
        xmlProcess.XmlPublishers(listOfPublishers, commands[2]);
    }

    static bool ParsePublisherLine(string[] components)
    {
        if (components.Length != 3)
        {
            Console.Error.WriteLine("Incorrect csv data..\nImport stopped");
            return false;
        }
        if (int.TryParse(components[0], out int id))
        {
            if (String.IsNullOrWhiteSpace(components[1]))
            {
                Console.Error.WriteLine("Incorrect publisher value in csv");
                return false;
            }
            if (String.IsNullOrWhiteSpace(components[2]))
            {
                Console.Error.WriteLine("Incorrect platform value in csv");
                return false;
            }
            return true;
        }
        else
        {
            Console.Error.WriteLine("Incorrect id value in csv");
            return false;
        }
    }
    static void ProcessGameCsv(string[] commands, GameRepository gameRepository)
    {
        if (commands.Length != 3)
        {
            Console.Error.WriteLine("Error: incorrect command format");
            return;
        }

        string[] csvLines = ReadAllLines(commands[2]);
        foreach (string line in csvLines)
        {
            string[] components = line.Split(",");

            if (ParseGameLine(components))
            {
                int.TryParse(components[0], out int rank);
                int.TryParse(components[2], out int year);
                int.TryParse(components[5], out int publisherId);
                double.TryParse(components[4], out double globalSales);

                Game game = new Game();
                game.rank = rank;
                game.name = components[1];
                game.year = year;
                game.genre = components[3];
                game.globalSales = globalSales;
                game.publisherId = publisherId;

                gameRepository.Import(game);
            }
            else return;


        }
    }

    static bool ParseGameLine(string[] components)
    {
        if (components.Length != 6)
        {
            Console.Error.WriteLine("Incorrect csv data..\nImport stopped");
            return false;
        }
        if (int.TryParse(components[0], out int rank))
        {
            if (String.IsNullOrWhiteSpace(components[1]))
            {
                Console.Error.WriteLine("Incorrect name value in csv");
                return false;
            }
            if (int.TryParse(components[2], out int year))
            {
                if (String.IsNullOrWhiteSpace(components[3]))
                {
                    Console.Error.WriteLine("Incorrect genre value in csv");
                    return false;
                }
                if (double.TryParse(components[4], out double globalSales))
                {
                    if (int.TryParse(components[5], out int publisherId))
                    {
                        return true;
                    }
                    else
                    {
                        Console.Error.WriteLine("Incorrect publisher_id value in csv");
                        return false;
                    }
                }
                else
                {
                    Console.Error.WriteLine("Incorrect global_sales value in csv");
                    return false;
                }
            }
            else
            {
                Console.Error.WriteLine("Incorrect year value in csv");
                return false;
            }
        }
        else
        {
            Console.Error.WriteLine("Incorrect rank value in csv");
            return false;
        }
    }
}

