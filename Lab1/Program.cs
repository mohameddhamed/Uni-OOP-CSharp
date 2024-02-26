using TextFile;
namespace Lab1;

class Program
{
    private static bool readMeasurementsFromFile(out List<int> measurements, string fileName)
    {
        measurements = new List<int>();

        try
        {
            TextFileReader reader = new TextFileReader(fileName);
            while (reader.ReadInt(out number))
            {
                measurements.Add(number);
            }
            return true;
        }
        catch (FileNotFoundException e)
        {
            return false;
        }
    }
    static bool condMaxSearch(List<int> measurements, out int max, out int ind)
    {
        bool condFound = false;
        max = 0;
        ind = 0;
        for (int i = 1; i < measurements.Count - 1; i++)
        {
            if (condFound && measurements[i] <= measurements[i - 1] && measurements[i] <= measurements[i + 1])
            {
                {
                    max = measurements[i];
                    ind = i;
                    if (max < measurements[i])
                }
            }
            else if (!condFound && measurements[i] <= measurements[i - 1] && measurements[i] <= measurements[i + 1])
            {
                condFound = true;
                max = measurements[i];
                ind = i;

            }

        }

        return condFound;
    }
    static void Main(string[] args)
    {
        Console.Write("Enter a filename:");
        string fileName = Console.ReadLine();
        List<int> measurements = new List<int>();

        if (readMeasurementsFromFile(out measurements, fileName))
        {
            int max, ind;
            if (condMaxSearch(measurements, out max, out ind))
            {
                Console.WriteLine($"the highest valley is of value {max}");
            }
            else
            {
                Console.WriteLine("Valley was not found");
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
    }
}