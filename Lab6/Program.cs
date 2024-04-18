namespace Lab6;
using TextFile;

// Integers are stored in a sequential input file sorted in ascending order. Count how many times each
// number occurs in the file and write the (number, count).
// 1 1 4 4 4 4 6 6 6 6 6 6 8 8
class Program
{
    enum Status { norm, abnorm };
    private static void read(ref Status st, ref int e, ref TextFileReader x)
    {
        if (!x.ReadInt(out e))
        {
            st = Status.abnorm;
        }
        else
        {
            st = Status.norm;
        }
    }
    private static void occurences(TextFileReader x)
    {
        Status st = Status.norm;
        int prev = 0, curr = 0, cnt = 1;
        read(ref st, ref prev, ref x);

        while (st == Status.norm)
        {
            read(ref st, ref curr, ref x);
            if (curr == prev)
            {
                cnt++;
            }
            else
            {
                Console.WriteLine(new Tuple<int, int>(prev, cnt));
                prev = curr;
                cnt = 1;
            }
        }

    }
    public static void Main(string[] args)
    {
        TextFileReader reader = new TextFileReader("input.txt");
        // Console.WriteLine(occurences(reader));
        occurences(reader);
    }
}