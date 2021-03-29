using System;
using static System.Console;
namespace ex1
{
    class ListInt
    {
        private int[] _items;
        private int _size;

        public ListInt()
        {
            _items = new int[16];
            _size = 0;
        }



        public void Add(int number)
        {
            if (this._size == this._items.Length)
            {
                Expand();
            }
            this._items[this._size] = number;
            this._size += 1;
        }

        private void Expand()
        {
            int oldCapacity = this._items.Length;
            int[] oldArray = this._items;
            this._items = new int[oldCapacity * 2];
            System.Array.Copy(oldArray, this._items, oldCapacity);
        }

        public void Insert(int index, int number)
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
            _items[index] = number;
            _size += 1;
        }

        public bool Remove(int number)
        {
            for (int i = 0; i <= _size; i++)
            {
                if (_items[i] == number)
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

        public int GetAt(int index)
        {
            if ((index > (_size)) || (index < 0))
            {
                throw new Exception("Error: Number under this index does not exist");
            }
            return _items[index];
        }}
}