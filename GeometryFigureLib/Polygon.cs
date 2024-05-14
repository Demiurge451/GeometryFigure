using System.Text;

namespace GeometryFigureLib;

public class Polygon : GeometricFigure
{
    private List<(double X, double Y)> _vertices;

    public Polygon(IEnumerable<(double X, double Y)> vertices) : base(0, 0)
    {
        _vertices = vertices.ToList();
        CalculateCentroid();
    }

    private void CalculateCentroid()
    {
        double signedArea = 0;
        double centroidX = 0;
        double centroidY = 0;

        for (int i = 0; i < _vertices.Count; i++)
        {
            int nextIndex = (i + 1) % _vertices.Count;
            double x0 = _vertices[i].X;
            double y0 = _vertices[i].Y;
            double x1 = _vertices[nextIndex].X;
            double y1 = _vertices[nextIndex].Y;

            double a = x0 * y1 - x1 * y0;
            signedArea += a;
            centroidX += (x0 + x1) * a;
            centroidY += (y0 + y1) * a;
        }

        signedArea *= 0.5;
        centroidX /= (6 * signedArea);
        centroidY /= (6 * signedArea);

        // Записываем расчитанные координаты центроида в базовый класс
        X = centroidX;
        Y = centroidY;
    }

    public override (double Top, double Bottom, double Left, double Right) GetBoundingRectangle()
    {
        double top = _vertices.Max(v => v.Y);
        double bottom = _vertices.Min(v => v.Y);
        double left = _vertices.Min(v => v.X);
        double right = _vertices.Max(v => v.X);
        return (top, bottom, left, right);
    }

    public override double GetArea()
    {
        double area = 0;
        for (int i = 0; i < _vertices.Count; i++)
        {
            int nextIndex = (i + 1) % _vertices.Count;
            area += _vertices[i].X * _vertices[nextIndex].Y;
            area -= _vertices[i].Y * _vertices[nextIndex].X;
        }

        area *= 0.5;
        return Math.Abs(area);
    }

    public override string GetName()
    {
        return "Polygon";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Polygon: ({X}, {Y}) and Points");

        foreach (var point in _vertices)
        {
            sb.Append($" ({point.X}, {point.Y})");
        }

        return sb.ToString();
    }
}