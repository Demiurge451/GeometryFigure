namespace GeometryFigureLib;

public class Line : GeometricFigure
{
    public double X1 { get; }
    public double Y1 { get; }
    
    public double X2 { get; }
    public double Y2 { get; }

    public Line(double x1, double y1, double x2, double y2) : base(0, 0)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;

        X = (x1 + x2) / 2.0;
        Y = (y1 + y2) / 2.0;
    }

    public override (double Top, double Bottom, double Left, double Right) GetBoundingRectangle()
    {
        return (Math.Max(Y, Y2), Math.Min(Y, Y2), Math.Min(X, X2), Math.Max(X, X2));
    }

    public override double GetArea()
    {
        return 0;
    }

    public override string GetName()
    {
        return "Line";
    }

    public override string ToString()
    {
        return $"Line: ({X1}, {Y1}) - ({X2}, {Y2})";
    }
}