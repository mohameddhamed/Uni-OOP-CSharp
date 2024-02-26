namespace Lab2;
class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public Point(double X, double Y)
    {
        this.X = X;
        this.Y = Y;
    }
    public override string ToString()
    {
        return $"(x = {this.X}, y = {this.Y})";
    }
}