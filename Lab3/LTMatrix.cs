namespace Lab3;

class LTMatrix
{
    public class IndexOutOfRangeException : Exception { }
    public class NotEqualDimensionsException : Exception { }

    private List<int> v;
    int size;
    public LTMatrix()
    {
        this.v = new List<int>() { 1, 2, 3, 4, 5, 6 };
        this.size = 6;
    }
    public LTMatrix(int size)
    {
        this.v = new List<int>(size);
        this.size = size;
    }
    public LTMatrix(LTMatrix m)
    {
        this.v = new List<int>(m.v);
        this.size = m.size;
    }
    public LTMatrix(List<int> v)
    {
        this.v = new List<int>(v);
        this.size = v.Count;
    }
    // public static int ind(int i, int j)
    // {
    //     // if (j < i) throw new IndexOutOfRangeException();
    //     return (i * (i + 1) / 2) + j;
    // }
    public static int ind(int i, int j)
    {
        return j + i * (i + 1) / 2;
    }

    public int GetElement(int i, int j)
    {
        try
        {
            return v[ind(i, j)];
        }
        catch (IndexOutOfRangeException e)
        {
            return 0;
        }

    }
    public void SetElement(int i, int j, int e)
    {
        try
        {
            v[ind(i, j)] = e;
        }
        catch (IndexOutOfRangeException error) { }
    }
    public static LTMatrix add(LTMatrix m1, LTMatrix m2)
    {
        int len = m1.size;
        if (len != m2.size) throw new NotEqualDimensionsException();

        List<int> result = new List<int>(new int[len]);
        for (int i = 0; i < len; i++)
        {
            result[i] = (m1.v[i] + m2.v[i]);
        }
        return new LTMatrix(result);
    }

    public static LTMatrix multiply(LTMatrix m1, LTMatrix m2)
    {
        int len = m1.size;
        if (len != m2.size) throw new NotEqualDimensionsException();

        List<int> result = new List<int>(new int[len]);
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                int c = 0;
                for (int k = j; k <= i; k++)
                {
                    if (ind(i, j) >= len) continue;
                    result[ind(i, j)] += m1.v[ind(i, k)] * m2.v[ind(k, j)];
                }
            }
        }
        return new LTMatrix(result);

    }
    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (ind(i, j) >= size) continue;
                output += v[ind(i, j)] + " ";
            }
            output += "\n";
        }
        return output;
    }

}

