using System;

class Program
{
    static void Main()
    {
        // collection initializer support
        MyList<int> numbers = new MyList<int> { 1, 2, 3, 4 };

        Console.WriteLine("Elements in the list:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        Console.WriteLine("Adding element 5");
        numbers.Add(5);

        Console.WriteLine("Updated list:");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("Element at index 2: " + numbers[2]);
        numbers[2] = 99;
        Console.WriteLine("Element at index 2 after change: " + numbers[2]);
    }
}
