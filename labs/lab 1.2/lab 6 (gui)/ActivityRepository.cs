using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Data.Sqlite;

public class ActivityRepository
{
    private SqliteConnection connection;

    public ActivityRepository(SqliteConnection connection)
    {
        this.connection = connection;
    }

    public long Add(Activity activity)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO activities (type, title, commentary, distance, timeOfCreation)
        VALUES ($type, $title, $commentary, $distance, $timeOfCreation);
        SELECT last_insert_rowid();";

        command.Parameters.AddWithValue("$type", activity.type);
        command.Parameters.AddWithValue("$title", activity.title);
        command.Parameters.AddWithValue("$commentary", activity.commentary);
        command.Parameters.AddWithValue("$distance", activity.distance);
        command.Parameters.AddWithValue("$timeOfCreation", DateTime.Now); //activity.timeOfCreation

        long newId = (long)command.ExecuteScalar();

        connection.Close();

        return newId;
    }

    public bool Delete(long id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM activities WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        int nChanged = command.ExecuteNonQuery();

        connection.Close();

        if (nChanged == 0)
        {
            return false;
        }

        return true;
    }

    public bool Update(long id, Activity activity)
    {
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"UPDATE activities SET type = $type, title = $title, commentary = $commentary, distance = $distance, timeOfCreation = $timeOfCreation WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$type", activity.type);
        command.Parameters.AddWithValue("$title", activity.title);
        command.Parameters.AddWithValue("$commentary", activity.commentary);
        command.Parameters.AddWithValue("$distance", activity.distance);
        command.Parameters.AddWithValue("$timeOfCreation", activity.timeOfCreation);
        int rowChange = command.ExecuteNonQuery();

        connection.Close();
        if (rowChange == 0)
        {
            return false;
        }

        return true;
    }

    public List<Activity> GetAll()               
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM activities";

        List<Activity> activities = new List<Activity>();
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Activity activity = new Activity();

            activity.id = int.Parse(reader.GetString(0));
            activity.type = reader.GetString(1);
            activity.title = reader.GetString(2);
            activity.commentary = reader.GetString(3);
            activity.distance = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            activity.timeOfCreation = reader.GetDateTime(5);
            activities.Add(activity);
        }
        reader.Close();
        connection.Close();

        return activities;
    }

    public Activity GetById(int id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM activities  WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        SqliteDataReader reader = command.ExecuteReader();

        Activity activity = new Activity();

        if (reader.Read())
        {
            activity.id = int.Parse(reader.GetString(0));
            activity.type = reader.GetString(1);
            activity.title = reader.GetString(2);
            activity.commentary = reader.GetString(3);
            activity.distance = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            activity.timeOfCreation = reader.GetDateTime(5);
            reader.Close();
        }

        reader.Close();
        connection.Close();

        return activity;
    }

    public int GetTotalPages()
    {
        const int pageSize = 3;
        return (int)Math.Ceiling(this.GetCount() / (double)pageSize);
    }
    private long GetCount() //for GetTotalPages
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT COUNT(*) FROM activities";

        long count = (long)command.ExecuteScalar();
        return count;
    }

    public List<Activity> GetPage(int pageNumber)
    {
        if( pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber));
        }
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM activities LIMIT 3 OFFSET 3*($pageNumber-1)";
        command.Parameters.AddWithValue("$pageNumber", pageNumber);

        SqliteDataReader reader = command.ExecuteReader();
        List<Activity> activities = new List<Activity>();

        while (reader.Read())
        {

            Activity activity = new Activity();
            activity.id = int.Parse(reader.GetString(0));
            activity.type = reader.GetString(1);
            activity.title = reader.GetString(2);
            activity.commentary = reader.GetString(3);
            activity.distance = double.Parse(reader.GetString(4), CultureInfo.InvariantCulture);
            activity.timeOfCreation = reader.GetDateTime(5);
            activities.Add(activity);
        }

        reader.Close();
        connection.Close();

        return activities;
    }
}