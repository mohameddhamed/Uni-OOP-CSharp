namespace Lab2;
using System;
class Circle
{
    public class WrongRadiusException : Exception { }
    public double Radius { get; set; }
    public Point Center { get; set; }
    public Circle(double radius, Point center)
    {
        if (radius <= 0) throw new WrongRadiusException();
        this.Radius = radius;
        this.Center = center;
    }
    public bool Contains(Point point)
    {
        double x = point.X, y = point.Y, x1 = this.Center.X, y1 = this.Center.Y;
        double distance = Math.Sqrt((Math.Pow((x - x1), 2) + Math.Pow((y - y1), 2)));
        return distance <= this.Radius;
    }
    public override string ToString()
    {
        return $"The center is {this.Center} and radius is {this.Radius}";
    }
}