namespace lowerTriangularMatrix;

public class LTMatrix
{
    private List<int> m_List;
    private int m_size;

    public class IndexOutOfRangeException : Exception { };
    public class NotEqualDimensionsException : Exception { };
    public class SettingOutTMScopeException : Exception { };

    public LTMatrix()
    {
        m_size = 3;
        m_List = new List<int>() { 1, 2, 3, 4, 5, 6 };
    }
    public LTMatrix(LTMatrix a)
    {
        m_size = a.m_size;
        m_List = a.m_List;
    }
    public LTMatrix(int size)
    {
        m_size = size;
        m_List = new List<int>();
        int length = size * (size + 1) / 2;
        for (int i = 0; i < length; i++)
        {
            m_List.Add(0);
        }
    }
    public int ind(int i, int j)
    {
        return j + i * (i + 1) / 2;
    }

    public bool inLowerTr(int i, int j)
    {
        return 0 <= j && j <= i && j < m_size;
    }

    public bool isValidIndex(int i, int j)
    {
        return 0 <= i && i < m_size && 0 <= j && j < m_size;

    }
    public int getItem(int i, int j)
    {
        if (inLowerTr(i, j))
        {
            return m_List[ind(i, j)];
        }
        else if (isValidIndex(i, j))
        {
            return 0;
        }
        throw new IndexOutOfRangeException();
    }

    public static LTMatrix add(LTMatrix a, LTMatrix b)
    {
        if (a.m_size == b.m_size)
        {
            //add
            LTMatrix sum = new LTMatrix(a.m_size);
            for (int i = 0; i < b.m_List.Count; i++)
            {
                sum.m_List[i] = b.m_List[i] + a.m_List[i];
            }

            return sum;
        }

        throw new NotEqualDimensionsException();

    }

    public void setElement(int i, int j, int e)
    {
        if (inLowerTr(i, j))
        {
            m_List[ind(i, j)] = e;
        }
        else
            throw new SettingOutTMScopeException();

    }

    public static LTMatrix multiply(LTMatrix a, LTMatrix b)
    {
        if (a.m_size == b.m_size)
        {
            LTMatrix mul = new LTMatrix(a.m_size);
            for (int i = 0; i < b.m_size; i++)
            {
                for (int j = 0; j < b.m_size; j++)
                {
                    if (b.inLowerTr(i, j))
                    {
                        for (int k = j; k <= i; k++)
                        {
                            mul.setElement(i, j, mul.getItem(i, j) + a.getItem(i, k) * b.getItem(k, j));

                        }
                    }
                }
            }
            return mul;

        }

        throw new NotEqualDimensionsException();
    }


    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {
                output += getItem(i, j) + " ";
            }
            output += "\n";
        }
        return output;
    }

}