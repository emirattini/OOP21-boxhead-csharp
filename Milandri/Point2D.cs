using OOP21_boxhead_csharp.Milandri;
/// <summary>
/// Implementation of IPoint2D
/// </summary>
public class Point2D : IPoint2D
{
    private readonly double _x;
    private readonly double _y;
    public Point2D(double x, double y)
    {
        this._x = x;
        this._y = y;
    }

    public double X { get { return this._x; } }
    public double Y { get { return this._y; } }

    public Point2D Add(Point2D point)
    {
        return new Point2D(this._x + point.X, this._y + point.Y); 
    }
}
