using System;

class SetInt : ISetInt
{
    private int[] _items;
    private int _size;
    public SetInt()
    {
        _items = new int[0];
        _size = 0;
    }

    public bool Add(int value)
    {
        if (Contains(value))
        {
            return false;
        }

        if (this._size == this._items.Length)
        {
            Expand();
        }
        this._items[this._size] = value;
        this._size += 1;
        _items = this.InsertionSort(_items);
        return true;
    }
    private void Expand()
    {
        int oldCapacity = this._items.Length;
        int[] oldArray = this._items;
        this._items = new int[oldCapacity + 1];
        System.Array.Copy(oldArray, this._items, oldCapacity);
    }
    private int[] InsertionSort(int[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (inputArray[j - 1] > inputArray[j])
                {
                    int temp = inputArray[j - 1];
                    inputArray[j - 1] = inputArray[j];
                    inputArray[j] = temp;
                }
            }
        }
        return inputArray;
    }

    public void Clear()
    {
        _size = 0;
    }

    public bool Contains(int value)
    {
        int index = FindIndex(value);
        return index >= 0;
    }

    private int FindIndex(int value)
    {
        for (int i = 0; i < _size; i++)
        {
            if (_items[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    public void CopyTo(int[] array)
    {
        if (array.Length < _size)
        {
            throw new System.ArgumentException("Error: Given array does not have enough capacity. ");
        }
        for (int i = 0; i < _size; i++)
        {
            array[i] = _items[i];
        }
    }

    public int GetCount
    {
        get
        {
            return _size;
        }
    }

    public bool Overlaps(ISetInt other)
    {
        int[] array = new int[other.GetCount];
        other.CopyTo(array);
        for (int i = 0; i < _size; i++)
        {
            for(int j = 0; j < array.Length; j++)
            {
                if(array[j] == _items[i])
                {
                    return true;
                }
            } 
        }
        return false;
    }

    public bool Remove(int value)
    {
        int index = FindIndex(value);
        if (index == -1)
        {
            return false;
        }

        for (int i = index; i < _size - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        _size--;
        return true;
    }
}