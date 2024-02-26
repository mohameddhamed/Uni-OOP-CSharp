namespace Lab2;
using TextFile;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a fileName: ");
            string fileName = Console.ReadLine();

            TextFileReader reader = new TextFileReader(fileName);

            // read coordinates of circle and radius
            reader.ReadDouble(out double circle_x);
            reader.ReadDouble(out double circle_y);
            reader.ReadDouble(out double circle_radius);

            // create the Circle object
            Circle circle = new Circle(circle_radius, new Point(circle_x, circle_y));

            // read number of points
            reader.ReadInt(out int pointsNumber);
            Point[] points = new Point[pointsNumber];

            for (int i = 0; i < pointsNumber; i++)
            {
                // read coordinates and create points
                reader.ReadDouble(out double x);
                reader.ReadDouble(out double y);
                points[i] = new Point(x, y);
            }

            bool foundPointInsideCircle = false;
            Point pointInsideCircle = points[0];

            for (int i = 0; i < points.Length && !foundPointInsideCircle; i++)
            {
                foundPointInsideCircle = circle.Contains(points[i]);
                pointInsideCircle = points[i];
            }
            if (foundPointInsideCircle)
            {
                Console.WriteLine($"there is a point inside the circle {pointInsideCircle}");
            }
            else
            {

                Console.WriteLine("there was no point found inside the circle ");
            }

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("file doesn't exist.");

        }
        catch (Circle.WrongRadiusException)
        {
            Console.WriteLine("invalid radius");
        }
    }

}
