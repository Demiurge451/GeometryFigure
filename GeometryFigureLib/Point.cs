namespace GeometryFigureLib;

public class Point : GeometricFigure
{
    public Point(double x, double y) : base(x, y)
    {
    }

    public override (double Top, double Bottom, double Left, double Right) GetBoundingRectangle()
    {
        return (Y, Y, X, X);
    }

    public override double GetArea()
    {
        return 0;
    }

    public override string GetName()
    {
        return "Point";
    }

    public override string ToString()
    {
        return $"Point: ({X}, {Y})";
    }
}