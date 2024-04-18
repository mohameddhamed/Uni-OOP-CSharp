namespace Lab5;
using TextFile;

class Program
{
    enum Status { norm, abnorm };

    //     Calculate the average of daily temperatures
    // stored in a sequential input file.
    // a.before the first temperature under the freezing point.
    private static void read(ref Status st, ref double e, ref TextFileReader x)
    {
        if (!x.ReadDouble(out e))
        {
            st = Status.abnorm;
        }
        else
        {
            st = Status.norm;
        }
    }
    private static double averageBefore(TextFileReader x)
    {
        double e = 0, sum = 0, n = 0;
        Status st = Status.norm;

        read(ref st, ref e, ref x);
        while (st == Status.norm && e > 0)
        {
            sum += e;
            n++;
            read(ref st, ref e, ref x);
        }
        return sum / n;
    }
    // b. after the first temperature under the freezing point.
    private static double averageAfter(TextFileReader reader)
    {
        Status st = Status.norm;
        double e = 0, n = 0, sum = 0;

        read(ref st, ref e, ref reader);
        while (st == Status.norm && e >= 0)
        {
            read(ref st, ref e, ref reader);
        }

        read(ref st, ref e, ref reader);
        while (st == Status.norm)
        {
            sum += e;
            n++;
            read(ref st, ref e, ref reader);
        }
        return sum / n;

    }
    // c.before and after the first temperature under the freezing point where in the after version the first freezing temperature is included, too.
    private static Tuple<double, double> averageBeforeNAfter(TextFileReader x)
    {
        Status st = Status.norm;
        double e = 0, sum1 = 0, sum2 = 0, n1 = 0, n2 = 0;
        read(ref st, ref e, ref x);
        while (st == Status.norm && e > 0)
        {
            sum1 += e;
            n1++;
            read(ref st, ref e, ref x);
        }
        sum2 = e;
        n2++;
        read(ref st, ref e, ref x);
        while (st == Status.norm)
        {
            sum2 += e;
            n2++;
            read(ref st, ref e, ref x);
        }
        return new Tuple<double, double>(sum1 / n1, sum2 / n2);
    }

    // 1 0 3 4 -2 -5 3 12
    static void Main(string[] args)
    {
        Console.WriteLine("Enter filename: \n");
        string fileName = Console.ReadLine();

        TextFileReader reader = new TextFileReader(fileName);
        // Console.WriteLine(averageBefore(reader));
        // Console.WriteLine(averageAfter(reader));
        Console.WriteLine(averageBeforeNAfter(reader));

    }
}



