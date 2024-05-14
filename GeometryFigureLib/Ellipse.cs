namespace GeometryFigureLib;

public class Ellipse : GeometricFigure
{
    public double RadiusX { get; set; }
    public double RadiusY { get; set; }

    public Ellipse(double x, double y, double radiusX, double radiusY) : base(x, y)
    {
        RadiusX = radiusX;
        RadiusY = radiusY;
    }

    public override (double Top, double Bottom, double Left, double Right) GetBoundingRectangle()
    {
        return (Y + RadiusY, Y - RadiusY, X - RadiusX, X + RadiusX);
    }

    public override double GetArea()
    {
        return Math.PI * RadiusX * RadiusY;
    }

    public override string GetName()
    {
        return "Ellipse";
    }

    public override string ToString()
    {
        return $"Ellipse: ({X}, {Y}) with RadiusX={RadiusX} and RadiusY={RadiusY}";
    }
}