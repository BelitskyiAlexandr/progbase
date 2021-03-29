using System;
using Microsoft.Data.Sqlite;
using static System.Console;
using System.Text;
using System.IO;


namespace ex2
{
    class Show
    {
        public string show_id;
        public string title;
        public string director;
        public int release_year;


        public Show()
        {
            this.show_id = "";
            this.title = "";
            this.director = "";
            this.release_year = 0;
        }

        public Show(string show_id, string title, string director, int release_year)
        {
            this.show_id = show_id;
            this.title = title;
            this.director = director;
            this.release_year = release_year;
        }

        public override string ToString()
        {

            return $"[{show_id}]  {title}  {director} {release_year}";


        }
    }
    class ListShow
    {
        private Show[] _items;
        private int _size;

        public ListShow()
        {

            _items = new Show[16];

            _size = 0;
        }
        public void Add(Show newShow)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity();

            }
            _items[_size] = newShow;
            _size += 1;
        }
        private void EnsureCapacity()
        {
            int oldCapacity = this._items.Length;
            Show[] oldArray = this._items;
            this._items = new Show[oldCapacity * 2];
            System.Array.Copy(oldArray, this._items, oldCapacity);
        }

        public void Insert(int index, Show newShow)
        {
            if (index > _size && index < 0)
            {
                throw new ArgumentException("Error: incorrect index number");
            }
            else
            {
                if (_items.Length > _size)
                {
                    _size++;
                    for (int i = index; i <= _size; i++)
                    {
                        if (i + 1 < _size)
                        {
                            _items[i] = _items[i + 1];
                        }
                    }
                    newShow = _items[index];
                }
                else
                {
                    EnsureCapacity();
                }
            }

        }
        public void Clear()
        {
            _size = 0;
        }

        public int GetCount()
        {
            return _size;
        }
        public int GetCapacity()
        {
            return _items.Length;
        }

        public Show GetAt(int index)
        {
            if ((index > (_size - 1)) || (index < 0))
            {
                throw new ArgumentException("Error: Show under this index does not exist");

            }
            return _items[index];


        }

        public void SetAt(int index, Show show)
        {
            if ((index > (_size - 1)) || (index < 0))
            {
                throw new ArgumentException("Error: Show under this index does not exist");

            }
            _items[index] = show;
        }


    }
    class ShowRepository1
    {
        private SqliteConnection connection;
        public ShowRepository1(SqliteConnection connection)
        {
            this.connection = connection;
        }



        public void GetAll()
        {
            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT * FROM show ";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Show show = new Show();

                show.show_id = reader.GetString(0);


                show.title = reader.GetString(1);

                if (reader.IsDBNull(2))
                {
                    continue;
                }
                else
                {
                    show.director = reader.GetString(2);
                }

                show.release_year = int.Parse(reader.GetString(3));


                Console.WriteLine("Show: " + show);
            }
            reader.Close();
        }
        public ListShow GetExport(string actor)
        {
            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT * FROM show WHERE cast = $cast";
            command.Parameters.AddWithValue("$cast", actor);

            SqliteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                WriteLine("show with actor " + "'" + actor + "'" + " found:");
                WriteLine("show are writen in export.csv");

            }
            else
            {
                WriteLine("show with such year " + "'" + actor + "'" + " not found:");
            }
            ListShow shows = new ListShow();
            while (reader.Read())
            {
                Show show = new Show();
                show.show_id = reader.GetString(0);
                show.title = reader.GetString(1);
                if (reader.IsDBNull(2))
                {
                    continue;
                }
                else
                {
                    show.director = reader.GetString(2);
                }

                show.release_year = int.Parse(reader.GetString(3));
                shows.Add(show);
            }

            reader.Close();
            return shows;

        }
        public long Countshow()
        {
            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT COUNT(*) FROM show";
            return (long)command.ExecuteScalar();
        }
    }
    class ShowRepository2
    {
        private SqliteConnection connection;
        public ShowRepository2(SqliteConnection connection)
        {
            this.connection = connection;
        }



        public void GetAll()
        {
            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT * FROM show2";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Show show = new Show();

                show.show_id = reader.GetString(0);


                show.title = reader.GetString(1);

                if (reader.IsDBNull(2))
                {
                    continue;
                }
                else
                {
                    show.director = reader.GetString(2);
                }

                show.release_year = int.Parse(reader.GetString(3));


                Console.WriteLine("Show: " + show);
            }
            reader.Close();
        }
        public void Insert(Show show)
        {
            SqliteCommand command = connection.CreateCommand();
            command.CommandText =
              @" INSERT INTO show2 show_id, title, director, release_year) 
              VALUES ($show_id,$title, $director, $release_year);";
            command.Parameters.AddWithValue("$show_id", show.show_id);
            command.Parameters.AddWithValue("$title", show.title);
            command.Parameters.AddWithValue("$director", show.director);
            command.Parameters.AddWithValue("$release_year", show.release_year);
        }

        public long Countshow()
        {
            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT COUNT(*) FROM show2";
            return (long)command.ExecuteScalar();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter command: ");
            string databaseFileName = "films.db";
            string databaseFileName2 = "films2.db";

            string argsinp = Console.ReadLine();
            string[] splitArgs = argsinp.Split(" ");
            SqliteConnection connection = new SqliteConnection($"Data Source={databaseFileName}");
            SqliteConnection connection2 = new SqliteConnection($"Data Source={databaseFileName2}");
            ShowRepository1 repository = new ShowRepository1(connection);
            ShowRepository2 repository2 = new ShowRepository2(connection2);
            connection.Open();
            if (argsinp == "getAll1")
            {
                repository.GetAll();
            }
            if (argsinp == "getAll2")
            {
                repository2.GetAll();
            }
            else if (splitArgs.Length == 2 && splitArgs[0] == "getExport")
            {
                ListShow shows = new ListShow();
                shows = repository.GetExport(splitArgs[1]);
                for (int i = 0; i < repository.Countshow(); i++)
                {
                    repository2.Insert(show);
                }

            }
            else if (argsinp == "Count1")
            {
                long count1 = repository.Countshow();
                WriteLine("Number of shows in first db is " + count1);
            }
            else if (argsinp == "Count2")
            {
                long count2 = repository.Countshow();
                WriteLine("Number of shows in first db is " + count2);
            }

            else
            {
                WriteLine("Incorrect command");

            }
            connection.Close();



        }
        static void Printshow(ListShow show)
        {
            for (int i = 0; i < show.GetCount(); i++)
            {

                WriteLine(show.GetAt(i).ToString());
            }
        }

    }
}
