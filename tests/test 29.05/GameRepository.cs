using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;

public class GameRepository
{
    private SqliteConnection connection;

    public GameRepository(SqliteConnection connection)
    {
        this.connection = connection;
    }

    public void Import(Game game)
    {
        connection.Open();

        SqliteCommand readerCommand = connection.CreateCommand();
        readerCommand.CommandText = @"SELECT * FROM games";

        SqliteDataReader reader = readerCommand.ExecuteReader();
        while (reader.Read())
        {
            Game bdGame = new Game();
            bdGame.rank = int.Parse(reader.GetString(0));
            bdGame.name = reader.GetString(1);
            bdGame.year = int.Parse(reader.GetString(2));
            bdGame.genre = reader.GetString(3);
            bdGame.globalSales = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            bdGame.publisherId = int.Parse(reader.GetString(5));


            if (bdGame.rank == game.rank &&
                bdGame.name == game.name &&
                bdGame.year == game.year &&
                bdGame.genre == game.genre &&
                bdGame.globalSales == game.globalSales &&
                bdGame.publisherId == game.publisherId)
            {
                return;
            }
        }


        SqliteCommand publishCommand = connection.CreateCommand();
        readerCommand.CommandText = @"SELECT * FROM publishers";

        SqliteDataReader reader1 = readerCommand.ExecuteReader();

        bool existConnection = false;
        while (reader1.Read())
        {
            Publisher publisher = new Publisher();
            publisher.id = int.Parse(reader1.GetString(0));

            if (publisher.id == game.publisherId)
            {
                existConnection = true;
            }
        }

        if (!existConnection)
        {
            Console.Error.WriteLine("Error: relationship does not exist");
            game.publisherId = 0; // для оновлення таблиці з 0 потрібно загрузити publishers з новими id і знову імпортувати csv з іграми
        }


        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO games (rank, name, year, genre, global_sales, publisher_id)
        VALUES ($rank, $name, $year, $genre, $globalSales, $publisherId);
        SELECT last_insert_rowid();";

        command.Parameters.AddWithValue("$rank", game.rank);
        command.Parameters.AddWithValue("$name", game.name);
        command.Parameters.AddWithValue("$year", game.year);
        command.Parameters.AddWithValue("$genre", game.genre);
        command.Parameters.AddWithValue("$globalSales", game.globalSales);
        command.Parameters.AddWithValue("$publisherId", game.publisherId);

        long newId = (long)command.ExecuteScalar();

        connection.Close();

    }

    public List<Game> GetAll()
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM games";

        List<Game> games = new List<Game>();
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Game game = new Game();

            game.rank = int.Parse(reader.GetString(0));
            game.name = reader.GetString(1);
            game.year = int.Parse(reader.GetString(2));
            game.genre = reader.GetString(3);
            game.globalSales = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            game.publisherId = int.Parse(reader.GetString(5));
            games.Add(game);
        }
        reader.Close();
        connection.Close();

        return games;
    }

    public List<Game> GetGamesByName(string name)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM games  WHERE name = $name";
        command.Parameters.AddWithValue("$name", name);

        List<Game> games = new List<Game>();
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Game game = new Game();

            game.rank = int.Parse(reader.GetString(0));
            game.name = reader.GetString(1);
            game.year = int.Parse(reader.GetString(2));
            game.genre = reader.GetString(3);
            game.globalSales = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            game.publisherId = int.Parse(reader.GetString(5));
            games.Add(game);
        }

        reader.Close();
        connection.Close();

        return games;
    }

    public bool Delete(long rank)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM games WHERE rank = $rank";
        command.Parameters.AddWithValue("$rank", rank);

        int nChanged = command.ExecuteNonQuery();

        connection.Close();

        if (nChanged == 0)
        {
            return false;
        }

        return true;
    }


    public List<Game> GetByPublishId(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM games  WHERE publisher_id = $id";
        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        List<Game> games = new List<Game>();

        while (reader.Read())
        {
            Game game = new Game();

            game.rank = int.Parse(reader.GetString(0));
            game.name = reader.GetString(1);
            game.year = int.Parse(reader.GetString(2));
            game.genre = reader.GetString(3);
            game.globalSales = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            game.publisherId = int.Parse(reader.GetString(5));
            games.Add(game);
        }

        reader.Close();
        connection.Close();

        return games;
    }
}