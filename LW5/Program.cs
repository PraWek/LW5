using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of rows: ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter minimum value: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Enter maximum value: ");
        int max = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(m, n, min, max);

        Console.WriteLine("Initial matrix:");
        matrix.Show();

        Console.WriteLine("\nPartial output (rows 1-2, cols 1-2):");
        matrix.ShowPartialy(1, 2, 1, 2);

        Console.WriteLine("\nChanging size to 5x5:");
        matrix.ChangeSize(5, 5, min, max);
        matrix.Show();

        Console.WriteLine("\nChanging element [0,0] to 999");
        matrix[0, 0] = 999;
        matrix.Show();
    }
}
