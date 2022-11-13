using System;
using System.Linq;

public class MainClass
{
    public static void Main()
    {
        var A = new Matrix();
        A.Read();

        var B = new Matrix();
        B.Read();

        var C = new Matrix();

        C = Matrix.MatrixMultiply(Matrix.Sum((Matrix.Multiply(A, 5)),Matrix.Multiply(B,2)) , A);
        C.Write();
    }
}

public class Matrix
{
    public int CountRow { get; private set; }
    public int CountColumn { get; private set; }
    public double[,] Data { get; private set; }
    public void Read()
    {
        var s1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        CountRow = s1[0];
        CountColumn = s1[1];
        Data = new double[CountRow, CountColumn];
        for (int i = 0; i < CountRow; i++)
        {
            var input = Console.ReadLine().Split(' ');
            for(int j = 0; j < CountColumn; j++)
                Data[i, j] = Double.Parse(input[j], System.Globalization.CultureInfo.InvariantCulture);
        }

    }
    public static Matrix Multiply(Matrix A, double n)
    {
        Matrix B = new Matrix();
        B.CountRow = A.CountRow;
        B.CountColumn = A.CountColumn;
        B.Data = new double[A.CountRow, A.CountColumn];
        for (int i = 0; i < B.CountRow; i++)
        {
            for (int j = 0; j < B.CountColumn; j++)
                B.Data[i, j] = A.Data[i, j] * n;
        }
        return B;
    }
    public static Matrix MatrixMultiply(Matrix A, Matrix B)
    {
        Matrix C = new Matrix();
        C.CountRow = A.CountRow;
        C.CountColumn = B.CountColumn;
        C.Data = new double[A.CountRow, B.CountColumn];
      
        for (int i = 0; i < A.CountRow; i++)
            for (int j = 0; j < B.CountColumn; j++)
                for (var k = 0; k < B.CountRow; k++)
                    C.Data[i, j] += A.Data[i, k] * B.Data[k, j];
        return C;
    }
    public void Write()
    {
        for (int i = 0; i < CountRow; i++)
        {
            for (var j = 0; j < CountColumn - 1; j++)
                Console.Write(Data[i, j] + " ");
            Console.Write(Data[i, CountColumn - 1]);
            Console.WriteLine();
        }
    }

    
        public static Matrix Sum(Matrix A, Matrix B)
        {
        Matrix C = new Matrix();
        C.CountRow = A.CountRow;
        C.CountColumn = A.CountColumn;
        C.Data = new double[A.CountRow, A.CountColumn];
        for (int i = 0; i < A.CountRow; i++)
        {
            for (var j = 0; j < A.CountColumn; j++)
                C.Data[i, j] = A.Data[i, j] + B.Data[i, j];
        }
        return C;
        }
}