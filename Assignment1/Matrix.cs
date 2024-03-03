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
    public int getElement(int i, int j)
    {
        // check that i, j are in range
        return this._matrix[i, j];
    }
    public static Matrix multiply(Matrix m1, Matrix m2)
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
                    sum += m1.getElement(i, k) * m2.getElement(k, j);
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
