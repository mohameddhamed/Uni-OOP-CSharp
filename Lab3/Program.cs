namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
        try
        {

            LTMatrix m = new LTMatrix();
            LTMatrix m2 = new LTMatrix();
            LTMatrix sum = LTMatrix.add(m, m2);
            LTMatrix mul = LTMatrix.multiply(m, m2);
            Console.WriteLine(mul);
            Console.WriteLine(sum);
        }
        catch (LTMatrix.IndexOutOfRangeException)
        {
            Console.WriteLine("index out of range");
        }
        catch (LTMatrix.NotEqualDimensionsException)
        {
            Console.WriteLine("Dimensions are not the same.");

        }
    }
}
