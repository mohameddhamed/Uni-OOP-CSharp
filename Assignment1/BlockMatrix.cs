namespace Assignment1;

public class BlockMatrix
{

    private int _size;
    private Matrix _block1, _block2, _matrix;
    public BlockMatrix(int b1, int b2, List<int> list)
    {
        // check that b1^2 + b2^2 = list.Count
        _size = b1 + b2;

        _block1 = new Matrix(list.GetRange(0, b1 * b1));
        _block2 = new Matrix(list.GetRange(b1 * b1, b2 * b2));

        _matrix = new Matrix(_size);
        _matrix = Matrix.Add(_matrix, _block1);
        _matrix = Matrix.Add(_matrix, _block2, b1);
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