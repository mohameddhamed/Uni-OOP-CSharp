namespace Assignment1;

public class BlockMatrix
{
    public class NotEqualBlockDistributionException : Exception { }
    public class NotEqualBlockMatrixDimensionsException : Exception { }
    public class NotValidBlockSizeException : Exception { }
    private int _size, _b1_size;
    private Matrix _block1, _block2, _matrix;
    public BlockMatrix(int b1, int b2)
    {
        if (b1 <= 0 || b2 <= 0) throw new NotValidBlockSizeException();

        _b1_size = b1;
        _size = b1 + b2;

        try
        {
            _block1 = new Matrix(b1);
            _block2 = new Matrix(b2);
            _matrix = new Matrix(_size);
        }
        catch (Matrix.NotPositiveSizeException e) { }
    }
    public BlockMatrix(int b1, int b2, List<int> list)
    {
        // check that b1^2 + b2^2 = list.Count
        if (b1 <= 0 || b2 <= 0 || b1 * b1 + b2 * b2 != list.Count) throw new NotValidBlockSizeException();

        _b1_size = b1;
        _size = b1 + b2;

        try
        {
            _block1 = new Matrix(list.GetRange(0, b1 * b1));
            _block2 = new Matrix(list.GetRange(b1 * b1, b2 * b2));

            _matrix = new Matrix(_size);
            _matrix = Matrix.Add(_matrix, _block1);
            _matrix = Matrix.Add(_matrix, _block2, b1);
        }
        catch (Matrix.NotPositiveSizeException e) { }

    }

    public static BlockMatrix Add(BlockMatrix m1, BlockMatrix m2)
    {
        if (m1._size != m2._size) throw new NotEqualBlockMatrixDimensionsException();
        if (m1._b1_size != m2._b1_size) throw new NotEqualBlockDistributionException();

        try
        {
            BlockMatrix result = new BlockMatrix(m1._b1_size, m1._size - m1._b1_size);

            Matrix temp = Matrix.Add(m1._block1, m2._block1);
            result._matrix = Matrix.Add(result._matrix, temp);

            temp = Matrix.Add(m1._block2, m2._block2);
            result._matrix = Matrix.Add(result._matrix, temp, result._b1_size);

            return result;
        }
        catch (NotValidBlockSizeException e) { return null; }
    }
    public static BlockMatrix Multiply(BlockMatrix m1, BlockMatrix m2)
    {
        if (m1._size != m2._size) throw new NotEqualBlockMatrixDimensionsException();
        if (m1._b1_size != m2._b1_size) throw new NotEqualBlockDistributionException();

        try
        {
            BlockMatrix result = new BlockMatrix(m1._b1_size, m1._size - m1._b1_size);


            Matrix temp = Matrix.Multiply(m1._block1, m2._block1);
            result._matrix = Matrix.Add(result._matrix, temp);

            temp = Matrix.Multiply(m1._block2, m2._block2);
            result._matrix = Matrix.Add(result._matrix, temp, result._b1_size);

            return result;
        }
        catch (NotValidBlockSizeException e) { return null; }
    }

    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                output += _matrix.GetElement(i, j) + "\t";
            }
            output += '\n';
        }
        return output;
    }
}