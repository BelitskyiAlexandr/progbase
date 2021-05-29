using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class PublisherRepository
{

    private SqliteConnection connection;

    public PublisherRepository(SqliteConnection connection)
    {
        this.connection = connection;
    }

    public void Import(Publisher publish)
    {
        connection.Open();

        SqliteCommand readerCommand = connection.CreateCommand();
        readerCommand.CommandText = @"SELECT * FROM publishers";

        SqliteDataReader reader = readerCommand.ExecuteReader();
        while (reader.Read())
        {
            Publisher publisher = new Publisher();
            publisher.id = int.Parse(reader.GetString(0));
            publisher.publisher = reader.GetString(1);
            publisher.platform = reader.GetString(2);

            if (publisher.id  == publish.id &&
                publisher.publisher == publish.publisher &&
                publisher.platform == publish.platform)
            {
                return;
            }
        }

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO publishers (id, publisher, platform)
        VALUES ($id, $publisher, $platform);
        SELECT last_insert_rowid();";

        command.Parameters.AddWithValue("$id", publish.id);
        command.Parameters.AddWithValue("$publisher", publish.publisher);
        command.Parameters.AddWithValue("$platform", publish.platform);
        long newId = (long)command.ExecuteScalar();

        connection.Close();

    }

    public List<Publisher> GetAll()               
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM publishers";

        List<Publisher> publisher = new List<Publisher>();
        SqliteDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Publisher publish = new Publisher();

            publish.id = int.Parse(reader.GetString(0));
            publish.publisher = reader.GetString(1);
            publish.platform = reader.GetString(2);
            publisher.Add(publish);
        }
        reader.Close();
        connection.Close();

        return publisher;
    }

    public long CountRecords()
    {
        connection.Open();
        SqliteCommand command = connection.CreateCommand();

        command.CommandText = @"SELECT COUNT(*) FROM publishers";

        long count = (long)command.ExecuteScalar();

        return count;
    }

    public bool Delete(long id)
    {
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM publishers WHERE id = $id";
        command.Parameters.AddWithValue("$id", id);

        int nChanged = command.ExecuteNonQuery();

        connection.Close();

        if (nChanged == 0)
        {
            return false;
        }

        return true;
    }
}