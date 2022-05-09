namespace Zombie;
    public interface IActiveEntity : IEntity
    {

        Point2D Speed { get; set; }

        void Update();

        Direction Direction { get; set; }
    }

