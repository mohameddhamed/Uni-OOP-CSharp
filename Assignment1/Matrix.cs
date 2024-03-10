namespace Assignment1;

using System;

public class Matrix
{
    public class NotEqualSizeMatricesException : Exception { }
    public class IndexOutOfRangeException : Exception { }
    public class NotPerfectSquareExeption : Exception { }
    public class NotPositiveSizeException : Exception { }
    private int[,] _matrix;
    private int _size;
    public Matrix(List<int> entries)
    {
        double sqrtResult = Math.Sqrt(entries.Count);
        _size = (int)Math.Floor(sqrtResult);
        if (_size * _size != entries.Count) throw new NotPerfectSquareExeption();
        this._matrix = new int[this._size, this._size];

        for (int i = 0; i < entries.Count; i++)
        {
            int k = i / this._size;
            int l = i % this._size;
            this._matrix[k, l] = entries[i];
        }
    }

    public Matrix(int size)
    {
        if (size < 0) throw new NotPositiveSizeException();
        this._size = size;
        this._matrix = new int[this._size, this._size];
    }
    public void SetElement(int i, int j, int e)
    {
        if (j < 0 || i < 0) throw new IndexOutOfRangeException();
        this._matrix[i, j] = e;
    }
    public int GetElement(int i, int j)
    {
        if (j < 0 || i < 0) throw new IndexOutOfRangeException();
        if (j >= _size || i >= _size) return 0;
        return this._matrix[i, j];
    }
    public static Matrix Expand(Matrix m, int amount)
    {
        int expandedSize = m._size + amount;
        // create the bigger matrix filled with zeros
        try
        {
            Matrix expandedMatrix = new Matrix(expandedSize);

            // iterate over the smaller matrix, and insert its values into the matrix's slot + amount
            for (int i = 0; i < m._size; i++)
            {
                for (int j = 0; j < m._size; j++)
                {
                    expandedMatrix.SetElement(i + amount, j + amount, m.GetElement(i, j));
                }
            }
            return expandedMatrix;
        }
        catch (NotPositiveSizeException e) { return null; }
        catch (IndexOutOfRangeException e) { return null; }
    }
    public static Matrix Add(Matrix m1, Matrix m2, int amount)
    {
        try
        {
            int len = m1._size;
            Matrix result = new Matrix(len);

            result = Matrix.Expand(m2, amount);

            return Matrix.Add(m1, result);
        }
        catch (NotPositiveSizeException e) { return null; }
    }
    public static Matrix Add(Matrix m1, Matrix m2)
    {
        int len = m1._size;
        try
        {
            Matrix result = new Matrix(len);

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    int sum = m1.GetElement(i, j) + m2.GetElement(i, j);
                    result.SetElement(i, j, sum);
                }
            }
            return result;
        }
        catch (NotPositiveSizeException e) { return null; }
        catch (IndexOutOfRangeException e) { return null; }
    }
    public static Matrix Multiply(Matrix m1, Matrix m2)
    {
        int len = m1._size;
        if (len != m2._size) throw new NotEqualSizeMatricesException();

        try
        {
            Matrix result = new Matrix(len);

            // Matrix multiplication algorithm
            for (int i = 0; i < len; i++) // Row of the first matrix
            {
                for (int j = 0; j < len; j++) // Column of the second matrix
                {
                    int sum = 0;
                    try
                    {
                        for (int k = 0; k < len; k++)
                            sum += m1.GetElement(i, k) * m2.GetElement(k, j);
                        result.SetElement(i, j, sum);
                    }
                    catch (IndexOutOfRangeException e) { return null; }
                }
            }
            return result;
        }
        catch (NotPositiveSizeException e) { return null; }
    }
    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                output += _matrix[i, j] + "\t";
            }
            output += '\n';
        }
        return output;
    }
}
