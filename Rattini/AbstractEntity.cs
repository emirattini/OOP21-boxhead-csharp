using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public abstract class AbstractEntity : IEntity
    {
        private Point2D _position;
        private EntityType _entityType;
        private double _width;
        private double _height;

        public AbstractEntity(Point2D point, EntityType type)
        {
            this._position = point;
            this._entityType = type;
            this._width = 20;
            this._height = 20;
        }

        public virtual Point2D Position
        {
            get { return this._position; }
            set { this._position = value; }
        }

        public EntityType Type
        {
            get { return this._entityType; }
        }

        public double Width
        {
            get { return this._width; }
            set { this._width = value; }
        }

        public double Height
        {
            get { return this._height; }
            set { this._height = value; }
        }
    }
}
