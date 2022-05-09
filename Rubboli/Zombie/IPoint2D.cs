namespace Zombie;
    public interface IPoint2D
    {
        double X { get; }

        double Y { get; }

        Point2D Add(Point2D point);
    }
