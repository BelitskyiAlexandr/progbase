using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class AwardRepository
{
    private SqliteConnection connection;
    public AwardRepository(SqliteConnection connection)
    {
        this.connection = connection;
    }

    private static Award GetAward(SqliteDataReader reader)
    {
        Award award = new Award()
        {
            id = long.Parse(reader.GetString(0)),
            year = int.Parse(reader.GetString(1)),
            ceremony = int.Parse(reader.GetString(2)),
            award = reader.GetString(3),
            winner = int.Parse(reader.GetString(4)) == 0 ? true : false,
            name = reader.GetString(5),
            film = reader.GetString(6)
        };

        return award;
    }
    public bool Insert(List<Award> awards)
    {
        connection.Open();
        Console.WriteLine(awards.Count);
        foreach (Award award in awards)
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
            @"INSERT INTO awards (year, ceremony, award, winner, name, film) 
            VALUES ($year, $ceremony, $award, $winner, $name, $film);
            SELECT last_insert_rowid();";

            command.Parameters.AddWithValue("$year", award.year);
            command.Parameters.AddWithValue("$ceremony", award.ceremony);
            command.Parameters.AddWithValue("$award", award.award);
            command.Parameters.AddWithValue("$winner", award.winner);
            command.Parameters.AddWithValue("$name", award.name);
            command.Parameters.AddWithValue("$film", award.film);

            long lastId = (long)command.ExecuteScalar();

        }
        connection.Close();
        return true;
    }

    public List<Award> GetAll()
    {
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM awards";

        SqliteDataReader reader = command.ExecuteReader();
        List<Award> Awards = new List<Award>();
        while (reader.Read())
        {
            Award Award = GetAward(reader);
            Awards.Add(Award);
        }
        reader.Close();
        connection.Close();
        return Awards;
    }

    public int DeleteByName(string name)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM awards WHERE name = $name";
        command.Parameters.AddWithValue("$name", name);

        int nChanged = command.ExecuteNonQuery();

        connection.Close();
        return nChanged;
    }

}