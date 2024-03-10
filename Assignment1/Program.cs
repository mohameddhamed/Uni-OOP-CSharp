namespace Assignment1;

class Program
{
    static void Main(string[] args)
    {
        // try
        // {
        //     Matrix m1 = new Matrix(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        //     Matrix m2 = new Matrix(new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18 });

        //     Matrix result = Matrix.Multiply(m1, m2);
        //     Console.WriteLine(result);
        // }
        // catch (Matrix.NotEqualSizeMatricesException e) { }
        // catch (Matrix.NotPerfectSquareExeption e) { }

        // Matrix result = Matrix.Add(m1, m2);

        try
        {
            BlockMatrix bm1 = new BlockMatrix(2, 3, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine(bm1);

            BlockMatrix bm2 = new BlockMatrix(2, 3, new List<int> { 55, 0, 66, 77, 10, 11, 12, 13, 14, 15, 16, 17, 18 });
            Console.WriteLine(bm2);

            BlockMatrix bmR = BlockMatrix.Multiply(bm1, bm2);
            Console.WriteLine(bmR);
        }
        catch (BlockMatrix.NotEqualBlockMatrixDimensionsException e) { }
        catch (BlockMatrix.NotEqualBlockDistributionException e) { }
    }
}
