using System;
using static System.Console;
using Microsoft.Data.Sqlite;
using System.IO;

namespace pract_1._03
{
    class Food
    {
        public string name;
        public string scienceName;
        public string group;
        public string subGroup;

        public Food()
        {
            name = "";
            scienceName = "";
            group = "";
            subGroup = "";
        }

        public Food(string name, string scienceName, string group, string subGruop)
        {
            this.name = name;
            this.scienceName = scienceName;
            this.group = group;
            this.subGroup = subGruop;
        }

        public override string ToString()
        {
            return $"{name} {scienceName} - {group} | {subGroup}";
        }
    }
    class ListFood
    {
        private Food[] _items;
        private int _size;

        public ListFood()
        {
            _items = new Food[16];
            _size = 0;
        }

        public void Add(Food food)
        {
            if (this._size == this._items.Length)
            {
                Expand();
            }
            this._items[this._size] = food;
            this._size += 1;
        }

        private void Expand()
        {
            int oldCapacity = this._items.Length;
            Food[] oldArray = this._items;
            this._items = new Food[oldCapacity * 2];
            System.Array.Copy(oldArray, this._items, oldCapacity);
        }

        public void Insert(int index, Food food)
        {
            if ((index > (_size)) || (index < 0))
            {
                WriteLine("Error: Index does not exist");
                Environment.Exit(0);
            }
            if (this._size == this._items.Length)
            {
                Expand();
            }
            for (int i = _size; i >= index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = food;
            _size += 1;
        }

        public bool Remove(Food teacher)
        {
            for (int i = 0; i <= _size; i++)
            {
                if (_items[i] == teacher)
                {
                    _size -= 1;
                    for (int j = i; j < _size; j++)
                    {
                        _items[j] = _items[j + 1];
                    }
                    return true;
                }
            }
            return false;
        }

        public int GetCount()
        {
            return _size;
        }

        public int GetCapacity()
        {
            return _items.Length;
        }

        public Food GetAt(int index)
        {
            if ((index > (_size - 1)) || (index < 0))
            {
                WriteLine("Error: Teacher under this index does not exist");
                Environment.Exit(0);
            }
            return _items[index];
        }

        public void SetAt(int index, Food food)
        {
            if ((index > (_size - 1)) || (index < 0))
            {
                WriteLine("Error: Teacher under this index does not exist");
                Environment.Exit(0);
            }
            _items[index] = food;
        }

        public ListFood ClearList()
        {
            return new ListFood();
        }
    }


    class FoodDataBase
    {
        private string dbFileName;

        public FoodDataBase(string dbFileName)
        {
            this.dbFileName = dbFileName;
        }

        public void getAll()
        {
            string databaseFileName = dbFileName;
            SqliteConnection connection = new SqliteConnection($"Data Source={databaseFileName}");
            connection.Open();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM food";

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Food food = new Food();
                food.name = reader.GetString(0);
                if (!reader.IsDBNull(1))
                {
                food.scienceName = reader.GetString(1);
                }
                food.group = reader.GetString(2);
                food.subGroup = reader.GetString(3);
                WriteLine(food);
            }

            reader.Close();

            connection.Close();
        }

        public string[] getExport (string category)
        {
            string databaseFileName = dbFileName;
            SqliteConnection connection = new SqliteConnection($"Data Source={databaseFileName}");
            connection.Open();

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM food WHERE \"GROUP\" = $group";
            command.Parameters.AddWithValue("$group", category);

            SqliteDataReader reader = command.ExecuteReader();
            string[] export = new string[1000];
            int i = 0;
            while (reader.Read())
            {
                Food food = new Food();
                food.name = reader.GetString(0);
                if (!reader.IsDBNull(1))
                {
                food.scienceName = reader.GetString(1);
                }
                food.group = reader.GetString(2);
                food.subGroup = reader.GetString(3);
                WriteLine("Food found: " + food);
                string[] strn = new string[] {reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetString(3)};
                string str = string.Join(',',strn);
                export[i] = str;
                i++;
            }

            reader.Close();

            connection.Close();
            return export;
        }

        public void Export(string category)
        {
            string[] export = this.getExport(category);
            File.WriteAllLines("./dataout.csv", export);
        }
    }

    class FoodReader
    {
        private StreamReader streamReader;
        public FoodReader(StreamReader sr)
        {
            streamReader = sr;
        }

        public Food ReadFood()
        {
            string line = this.streamReader.ReadLine();
            if (line == null)
            {
                return null;
            }
            string[] parts = line.Split(',');
            if (parts.Length != 4)
            {
                return new Food();
            }

            Food food = new Food();
            food.name = parts[0];
            food.scienceName = parts[1];
            food.group = parts[2];
            food.subGroup = parts[3];

            return food;
        }

        public void Close()
        {
            this.streamReader.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // StreamReader sr = new StreamReader("./data.csv");
            // FoodReader fr = new FoodReader(sr);
            // while (true)
            // {
            //     Food f = fr.ReadFood();
            //     if (f == null)
            //     {
            //         break;
            //     }
            // }
            // fr.Close();

            FoodDataBase fooddb = new FoodDataBase("fooddb");
            fooddb.getAll();
            fooddb.getExport("Vegetables");
            fooddb.Export("Vegetables");


        }
    }
}
