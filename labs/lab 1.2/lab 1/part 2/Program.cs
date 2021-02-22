using System;
using System.Diagnostics;
using System.IO;
using static System.Console;

namespace part_2
{
    class Teacher
    {
        public int id;
        public string fullname;
        public string subject;
        public int age;

        public Teacher()
        {
            id = 0;
            fullname = "";
            subject = "";
            age = 0;
        }

        public Teacher(int id, string fullname, string subject, int age)
        {
            this.id = id;
            this.fullname = fullname;
            this.subject = subject;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{id,-8} {fullname,20} - {subject,-10} | {age,3}";
        }
    }

    class ListTeachers
    {
        private Teacher[] _items;
        private int _size;

        public ListTeachers()
        {
            _items = new Teacher[16];
            _size = 0;
        }

        public ListTeachers ReadAllTeachers(string filePath)
        {
            ListTeachers teacher = new ListTeachers();
            StreamReader sr = new StreamReader(filePath);
            string s = "";
            while (true)
            {
                s = sr.ReadLine();
                if (s == null)
                {
                    break;
                }
                string[] str = s.Split(',');
                if (str[0] == "id")
                {
                    continue;
                }
                else
                {
                    if (str.Length != 4)
                    {
                        WriteLine("Error: csv file has a problem with data");
                        Environment.Exit(0);
                    }
                    else
                    {
                        int str0, str3;
                        if (int.TryParse(str[0], out str0))
                        {
                            if (str0 <= 0)
                            {
                                WriteLine("Error: Id must be a positive number");
                                Environment.Exit(0);
                            }
                            if (int.TryParse(str[3], out str3))
                            {
                                if (str3 <= 0)
                                {
                                    WriteLine("Error: Age must be a positive number");
                                    Environment.Exit(0);
                                }
                                teacher.Add(new Teacher(str0, str[1], str[2], str3));
                            }
                            else
                            {
                                WriteLine("Error: Age must be a number");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            WriteLine("Error: Id must be a number");
                            Environment.Exit(0);
                        }
                    }
                }
            }
            sr.Close();
            return teacher;
        }

        public void PrintFirst10()
        {
            if (_size == 0)
            {
                WriteLine("Error: List is empty");
            }
            else if (_size > 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    WriteLine(_items[i].ToString());
                }
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    WriteLine(_items[i].ToString());
                }
            }
        }


        public void Add(Teacher newTeacher)
        {
            if (this._size == this._items.Length)
            {
                Expand();
            }
            this._items[this._size] = newTeacher;
            this._size += 1;
        }

        private void Expand()
        {
            int oldCapacity = this._items.Length;
            Teacher[] oldArray = this._items;
            this._items = new Teacher[oldCapacity * 2];
            System.Array.Copy(oldArray, this._items, oldCapacity);
        }

        public void Insert(int index, Teacher teacher)
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
            _items[index] = teacher;
            _size += 1;
        }

        public bool Remove(Teacher teacher)
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

        public Teacher GetAt(int index)
        {
            if ((index > (_size - 1)) || (index < 0))
            {
                WriteLine("Error: Teacher under this index does not exist");
                Environment.Exit(0);
            }
            return _items[index];
        }

        public void SetAt(int index, Teacher teacher)
        {
            if ((index > (_size - 1)) || (index < 0))
            {
                WriteLine("Error: Teacher under this index does not exist");
                Environment.Exit(0);
            }
            _items[index] = teacher;
        }

        public ListTeachers MergeLists(ListTeachers list1, ListTeachers list2)
        {
            ListTeachers resultList = new ListTeachers();

            if (list1._items.Length > list2._items.Length)
            {
                var buf = list1;
                list1 = list2;
                list2 = buf;
            }
            resultList = list2;
            for (int i = 0; i < list1._size; i++)
            {
                for (int j = 0; j < resultList._size; j++)
                {
                    if (list1._items[i].id == resultList._items[j].id)
                    {
                        resultList._items[j] = list1._items[i];
                        break;
                    }
                    else if (j == resultList._size - 1)
                    {
                        resultList.Add(list1._items[i]);
                    }
                }
            }
            return resultList;
        }

        public double AverageAge(ListTeachers list)
        {
            int sum = 0;
            for (int i = 0; i < list._size; i++)
            {
                sum += list._items[i].age;
            }
            double avg = sum / list._size;
            return avg;
        }

        public ListTeachers DeleteUnderAverage(ListTeachers list, double avg)
        {
            for (int i = 0; i < list._size; i++)
            {
                while (true)
                {
                    if (list._items[i].age < avg)
                    {
                        list.Remove(list._items[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return list;
        }

        public void WriteAllTeachers(string filePath, ListTeachers list)
        {
            StreamWriter sw = new StreamWriter(filePath);
            string s = "";
            for (int i = 0; i < list._size; i++)
            {
                string[] str = { list._items[i].id.ToString(), list._items[i].fullname, list._items[i].subject, list._items[i].age.ToString() };
                s = string.Join(',', str);
                sw.WriteLine(s);
            }
            sw.Close();
        }
        public ListTeachers ClearList()
        {
            return new ListTeachers();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //
            ListTeachers newList = new ListTeachers();
            newList = newList.ReadAllTeachers("./data2.csv");

            newList.PrintFirst10();
            WriteLine("Number of elements of first list: {0}", newList.GetCount());
            WriteLine("Size of first list: {0}\r\n", newList.GetCapacity());
            Teacher teacher = new Teacher(44, "tt", "reded", 44);
            newList.Insert(14, teacher);
            WriteLine(newList.GetAt(14));

            newList.Remove(teacher);
            WriteLine(newList.GetAt(13));
            WriteLine();

            //
            ListTeachers newList2 = new ListTeachers();
            newList2 = newList2.ReadAllTeachers("./data1.csv");

            newList2.PrintFirst10();
            WriteLine("\r\nNumber of elements of second list: {0}", newList2.GetCount());
            WriteLine("Size of second list: {0}\r\n", newList2.GetCapacity());
            WriteLine(newList2.GetAt(55));
            WriteLine();

            ListTeachers lastList = new ListTeachers();
            lastList = lastList.MergeLists(newList, newList2);
            lastList.PrintFirst10();

            double avg = lastList.AverageAge(lastList);
            WriteLine("Average age is {0}\r\n", avg);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            lastList = lastList.DeleteUnderAverage(lastList, avg);
            sw.Stop();
            lastList.PrintFirst10();

           // WriteLine("\r\n{0}", sw.Elapsed);
            lastList.WriteAllTeachers("./dataout.csv", lastList);
        }
    }
}
