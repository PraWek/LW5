using System;
using System.Collections;

/// <summary>
/// represents a simple generic list based on arrays
/// provides basic functionality similar to List
/// </summary>
/// <typeparam name="T">type of elements stored in the list</typeparam>
class MyList<T> : IEnumerable<T>
{
    private T[] items;
    private int count;

    /// <summary>
    /// creates an empty list with an initial capacity of 4
    /// </summary>
    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    /// <summary>
    /// gets the number of elements in the list
    /// </summary>
    public int Count
    {
        get { return count; }
    }

    /// <summary>
    /// adds an element to the end of the list
    /// </summary>
    /// <param name="item">element to add</param>
    public void Add(T item)
    {
        if (count == items.Length)
        {
            Resize(items.Length * 2);
        }
        items[count] = item;
        count++;
    }

    /// <summary>
    /// gets or sets the element at the specified index
    /// </summary>
    /// <param name="index">index of the element</param>
    /// <returns>element at the specified index</returns>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return items[index];
        }
        set
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            items[index] = value;
        }
    }

    /// <summary>
    /// increases the size of the internal array to the specified capacity
    /// </summary>
    /// <param name="newCapacity">new array size</param>
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        for (int i = 0; i < count; i++)
        {
            newArray[i] = items[i];
        }
        items = newArray;
    }

    /// <summary>
    /// returns an enumerator for iterating through the list
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}