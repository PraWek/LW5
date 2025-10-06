using System;
using System.Collections;

/// <summary>
/// represents a simple generic dictionary based on arrays
/// provides basic functionality similar to Dictionary
/// </summary>
/// <typeparam name="TKey">type of keys</typeparam>
/// <typeparam name="TValue">type of values</typeparam>
class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private TKey[] keys;
    private TValue[] values;
    private int count;

    /// <summary>
    /// creates an empty dictionary with an initial capacity of 4
    /// </summary>
    public MyDictionary()
    {
        keys = new TKey[4];
        values = new TValue[4];
        count = 0;
    }

    /// <summary>
    /// gets the number of elements in the dictionary
    /// </summary>
    public int Count
    {
        get { return count; }
    }

    /// <summary>
    /// adds a new key-value pair to the dictionary
    /// </summary>
    /// <param name="key">key of the new element</param>
    /// <param name="value">value of the new element</param>
    public void Add(TKey key, TValue value)
    {
        if (ContainsKey(key))
            throw new ArgumentException("Key already exists");

        if (count == keys.Length)
            Resize(keys.Length * 2);

        keys[count] = key;
        values[count] = value;
        count++;
    }

    /// <summary>
    /// gets or sets the value associated with the specified key
    /// </summary>
    /// <param name="key">key to find</param>
    /// <returns>value associated with the key</returns>
    public TValue this[TKey key]
    {
        get
        {
            int index = IndexOfKey(key);
            if (index == -1)
                throw new KeyNotFoundException();
            return values[index];
        }
        set
        {
            int index = IndexOfKey(key);
            if (index == -1)
                throw new KeyNotFoundException();
            values[index] = value;
        }
    }

    /// <summary>
    /// returns true if the dictionary contains the specified key
    /// </summary>
    /// <param name="key">key to check</param>
    private bool ContainsKey(TKey key)
    {
        return IndexOfKey(key) != -1;
    }

    /// <summary>
    /// returns the index of the specified key or -1 if not found
    /// </summary>
    /// <param name="key">key to find</param>
    private int IndexOfKey(TKey key)
    {
        for (int i = 0; i < count; i++)
        {
            if (EqualityComparer<TKey>.Default.Equals(keys[i], key))
                return i;
        }
        return -1;
    }

    /// <summary>
    /// increases the size of the internal arrays to the specified capacity
    /// </summary>
    /// <param name="newCapacity">new array size</param>
    private void Resize(int newCapacity)
    {
        TKey[] newKeys = new TKey[newCapacity];
        TValue[] newValues = new TValue[newCapacity];

        for (int i = 0; i < count; i++)
        {
            newKeys[i] = keys[i];
            newValues[i] = values[i];
        }

        keys = newKeys;
        values = newValues;
    }

    /// <summary>
    /// returns an enumerator for iterating through the dictionary
    /// </summary>
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}