using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies
{
	public abstract class AbstractActiveEntity : AbstractEntity, IActiveEntity
	{
		private Point2D speed;
		private Direction direction;

		public AbstractActiveEntity(Point2D speed, Direction direction, Point2D position, EntityType entityType): base(position, entityType)
		{
			this.speed = speed;
			this.direction = direction;
		}

		public Direction Direction
		{
			set
			{
				this.direction = value;
			}
			get
			{
				return this.direction;
			}
		}

		public Point2D Speed
		{
			set
			{
				this.speed = value;
			}
			get
			{
				return this.speed;
			}
		}

		public virtual void Update()
		{
			Point2D point = Point2D.Add(base.Position, new Size(speed));
			base.Position = point;
		}
	}
}
