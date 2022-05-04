using OOP21_boxhead_csharp.Rattini;
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

    public double GetX()
    {
        return this._x;
    }

    public double GetY()
    {
        return this._y;
    }

    public Point2D Add(Point2D point)
    {
        return new Point2D(this._x + point.GetX(), this._y + point.GetY()); 
    }
}
