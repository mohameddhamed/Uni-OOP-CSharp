namespace Assignment1;

class Program
{
    static void Main(string[] args)
    {
        Matrix m1 = new Matrix(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        Matrix m2 = new Matrix(new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18 });
        // Matrix result = Matrix.multiply(m1, m2);
        Matrix result = Matrix.Add(m1, m2);


        BlockMatrix bm = new BlockMatrix(2, 3, new List<int> { 1, 2, 3, 4, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
        Console.WriteLine(bm);

    }
}
