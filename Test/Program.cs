using TextFile;

namespace highestValley
{

    internal class Program
    {
        private static bool readMeasurementsFromFile(out List<int> measurements, in string fileName)
        {

            measurements = new List<int>();
            try
            {
                TextFileReader reader = new TextFileReader(fileName);

                while (reader.ReadInt(out int m))
                {
                    measurements.Add(m);
                }

                return true;
            }
            catch
            {

                return false;
            }
        }

        private static bool condMaxSearch(in List<int> x, out int max, out int ind)
        {
            bool condFound = false;
            max = 0;
            ind = 0;
            for (int i = 1; i < x.Count - 1; i++)
            {
                if (condFound && x[i] <= x[i - 1] && x[i] <= x[i + 1])
                {
                    if (max < x[i])
                    {
                        max = x[i];
                        ind = i;
                    }
                }
                else if (!condFound && x[i] <= x[i - 1] && x[i] <= x[i + 1])
                {
                    condFound = true;
                    max = x[i];
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

}
