using System;

/// <summary>
/// represents a matrix with m rows and n columns
/// provides methods for filling, resizing and displaying the matrix
/// </summary>
class MyMatrix
{
    private int[,] data;
    private int rows;
    private int cols;
    private Random random;

    /// <summary>
    /// creates a matrix with the specified number of rows and columns
    /// the matrix is filled with random numbers within the given range
    /// </summary>
    /// <param name="rows">number of rows</param>
    /// <param name="cols">number of columns</param>
    /// <param name="minValue">minimum random value</param>
    /// <param name="maxValue">maximum random value</param>
    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        this.rows = rows;
        this.cols = cols;
        data = new int[rows, cols];
        random = new Random();
        Fill(minValue, maxValue);
    }

    /// <summary>
    /// fills the matrix with random numbers within the given range
    /// </summary>
    /// <param name="minValue">minimum random value</param>
    /// <param name="maxValue">maximum random value</param>
    public void Fill(int minValue, int maxValue)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                data[i, j] = random.Next(minValue, maxValue + 1);
            }
        }
    }

    /// <summary>
    /// changes the size of the matrix, copying existing values
    /// if the new matrix is larger, fills the remaining cells with random numbers
    /// </summary>
    /// <param name="newRows">new number of rows</param>
    /// <param name="newCols">new number of columns</param>
    /// <param name="minValue">minimum random value</param>
    /// <param name="maxValue">maximum random value</param>
    public void ChangeSize(int newRows, int newCols, int minValue, int maxValue)
    {
        int[,] newData = new int[newRows, newCols];

        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(cols, newCols); j++)
            {
                newData[i, j] = data[i, j];
            }
        }

        for (int i = 0; i < newRows; i++)
        {
            for (int j = 0; j < newCols; j++)
            {
                if (i >= rows || j >= cols)
                {
                    newData[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        data = newData;
        rows = newRows;
        cols = newCols;
    }

    /// <summary>
    /// displays the entire matrix in the console
    /// </summary>
    public void Show()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(data[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// displays a specific part of the matrix defined by row and column ranges
    /// </summary>
    /// <param name="rowStart">starting row index</param>
    /// <param name="rowEnd">ending row index</param>
    /// <param name="colStart">starting column index</param>
    /// <param name="colEnd">ending column index</param>
    public void ShowPartialy(int rowStart, int rowEnd, int colStart, int colEnd)
    {
        for (int i = rowStart; i <= rowEnd && i < rows; i++)
        {
            for (int j = colStart; j <= colEnd && j < cols; j++)
            {
                Console.Write(data[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// provides access to matrix elements by indices
    /// </summary>
    /// <param name="i">row index</param>
    /// <param name="j">column index</param>
    /// <returns>matrix element</returns>
    public int this[int i, int j]
    {
        get { return data[i, j]; }
        set { data[i, j] = value; }
    }
}
