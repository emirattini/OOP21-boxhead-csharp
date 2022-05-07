using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies
{
    public abstract class AbstractEntity : IEntity
    {
        private Point2D position;
        private EntityType type;
        private double width;
        private double height;

        public AbstractEntity(Point2D position, EntityType type)
        {
            this.position = position;
            this.type = type;
        }

        public virtual Point2D Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public EntityType Type
        {
            get
            {
                return this.type;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
        }
    }
}
