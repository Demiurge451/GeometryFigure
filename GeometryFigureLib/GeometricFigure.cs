namespace GeometryFigureLib;

public abstract class GeometricFigure
{
    public double X { get; protected set; } // X координата центра
    public double Y { get; protected set; } // Y координата центра

    protected GeometricFigure(double x, double y)
    {
        X = x;
        Y = y;
    }

    public abstract (double Top, double Bottom, double Left, double Right) GetBoundingRectangle();
    public abstract double GetArea();
    public abstract string GetName();
}