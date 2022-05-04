namespace OOP21_boxhead_csharp.Rattini
{
    public interface ITrajectory
    {
        Point2D GetCurrentPosition();

        double Angle { get; }

        double Speed { get; set; }

        Point2D GetPositionVariation();

        Boolean HasEnded();

        void Update();

    }
}
