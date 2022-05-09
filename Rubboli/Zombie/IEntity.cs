namespace Zombie;
    public interface IEntity
    {
        Point2D Position { get; set; }
        
        EntityType Type { get; }

        double Width { get; }

        double Height { get; }
        
    }
