using System;

class Program
{
    static void Main()
    {
        MyDictionary<string, int> dict = new MyDictionary<string, int>();

        dict.Add("apple", 3);
        dict.Add("banana", 7);
        dict.Add("orange", 5);

        Console.WriteLine("Number of elements: " + dict.Count);

        Console.WriteLine("Value for key 'banana': " + dict["banana"]);

        dict["banana"] = 10;
        Console.WriteLine("New value for key 'banana': " + dict["banana"]);

        Console.WriteLine("Iterating through dictionary:");
        foreach (var pair in dict)
        {
            Console.WriteLine(pair.Key + " -> " + pair.Value);
        }
    }
}
