using System.Drawing;

namespace Entity
{
    public abstract class AbstractActiveEntity : AbstractEntity, IActiveEntity
    {
        public PointF Speed { get; set; }
        public Direction Direction { get; set; }

        public AbstractActiveEntity(PointF speed, Direction direction, PointF position, EntityType entityType) : base(position, entityType)
        {
            Speed = speed;
            Direction = direction;
        }

        public void Update()
        {
            PointF pos = Position;
            pos.X = Position.X + Speed.X;
            pos.Y = Position.Y + Speed.Y;
            Position = pos;
        }

    }

}
