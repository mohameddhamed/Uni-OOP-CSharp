namespace Assignment1;

using System;

public class Matrix
{
    private int[,] _matrix;
    private int _size;
    public Matrix(List<int> entries)
    {
        // check that the square root is correct
        this._size = (int)Math.Sqrt(entries.Count);
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
        this._size = size;
        this._matrix = new int[this._size, this._size];
    }
    public void SetElement(int i, int j, int e)
    {
        // check that i, j are in range
        this._matrix[i, j] = e;
    }
    public int GetElement(int i, int j)
    {
        // check that i, j are in range
        if (i >= _size | j >= _size) return 0;
        return this._matrix[i, j];
    }
    public static Matrix Expand(Matrix m, int amount)
    {
        int expandedSize = m._size + amount;
        // create the bigger matrix filled with zeros
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
    public static Matrix Add(Matrix m1, Matrix m2, int amount)
    {
        int len = m1._size;
        Matrix result = new Matrix(len);

        result = Matrix.Expand(m2, amount);

        return Matrix.Add(m1, result);
    }
    public static Matrix Add(Matrix m1, Matrix m2)
    {
        int len = m1._size;
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
    public static Matrix Multiply(Matrix m1, Matrix m2)
    {
        int len = m1._size;
        // check same size
        // if (len != m2._size) throw new NotEqualSizeMatricesException();

        Matrix result = new Matrix(len);

        // Matrix multiplication algorithm
        for (int i = 0; i < len; i++) // Row of the first matrix
        {

            for (int j = 0; j < len; j++) // Column of the second matrix
            {
                int sum = 0;
                for (int k = 0; k < len; k++)
                    sum += m1.GetElement(i, k) * m2.GetElement(k, j);
                result.SetElement(i, j, sum);
            }
        }
        return result;
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
