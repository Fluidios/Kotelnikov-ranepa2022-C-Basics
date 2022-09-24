IntMatrix A = new IntMatrix(4, 4);
IntMatrix B = new IntMatrix(4, 4);
A.FillWithRandomValues(-5, 5);
B.FillWithRandomValues(-5, 5);
Console.WriteLine("Matrix A:");
A.DebugIntoConsole();
Console.WriteLine("Matrix B:");
B.DebugIntoConsole();
Console.WriteLine("Matrix A + B:");
(A + B).DebugIntoConsole();

class IntMatrix
{
    private int[,] _matrix;

    public IntMatrix(int x, int y)
    {
        _matrix = new int[x, y];
    }

    public int this[int x, int y]
    {
        get { return _matrix[x, y]; }
        set { _matrix[x, y] = value; }
    }
    public int XLength
    {
        get { return _matrix.GetLength(0); }
    }
    public int YLength
    {
        get { return _matrix.GetLength(1); }
    }
    public void FillWithRandomValues(int min = 0, int max = 99)
    {
        Random r = new Random();
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                _matrix[i, j] = r.Next(min, max);
            }
        }
    }

    public void DebugIntoConsole()
    {
        for (int i = 0; i < XLength; i++)
        {
            for (int j = 0; j < YLength; j++)
            {
                Console.Write("{0,3}|", _matrix[i, j]);
            }
            Console.WriteLine();
            for (int j = 0; j < YLength * 4; j++)
                Console.Write("-");
            Console.WriteLine();
        }
    }

    public static IntMatrix operator +(IntMatrix A, IntMatrix B)
    {
        if (A.XLength != B.XLength || A.YLength != B.YLength)
            throw new Exception("Different dimensions, passed matrices cannot be summed!");
        IntMatrix C = new IntMatrix(A.XLength, A.YLength);
        for (int i = 0; i < A.XLength; i++)
        {
            for (int j = 0; j < A.YLength; j++)
            {
                C[i, j] = A[i, j] + B[i, j];
            }
        }
        return C;
    }
}