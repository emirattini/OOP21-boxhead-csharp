using System.Drawing;

namespace Entity
{
    public abstract class AbstractEntity : IEntity
    {
        public PointF Position { get; set; }
        public EntityType EntityType { get; }
        private double _height;
        public double _width;

        public AbstractEntity(PointF position, EntityType entityType)
        {
            Position = position;
            EntityType = entityType;
        }

        public BoundingBox BoundingBox
        {
            get
            {
                return new BoundingBox(Position.X, Position.Y, _width, _height);
            }
        }

        public double Height() => _height;

        public double Width() => _width;


        public void SetBoundingBox(double width, double height)
        {
            _width = width;
            _height = height;
        }
    }
}