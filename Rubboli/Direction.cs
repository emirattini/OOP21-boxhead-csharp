using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies
{
    public class Direction
    {
        public static readonly Direction EAST =       new(1, 0, 0);
        public static readonly Direction SOUTH_EAST = new(0.707, 0.707, 45);
        public static readonly Direction SOUTH =      new(0, 1, 90);
        public static readonly Direction SOUTH_WEST = new(-0.707,0.707,135);
        public static readonly Direction WEST =       new(-1, 0, 180);
        public static readonly Direction NORTH_WEST = new(-0.707, -0.707, 225);
        public static readonly Direction NORTH =      new(0, -1, 270);
        public static readonly Direction NORTH_EAST = new(0.707, -0.707, 315);
        public static readonly Direction NULL =       new(0, 0, -1);
        public enum InnerEnum
        {
            EAST,
            SOUTH_EAST,
            SOUTH,
            SOUTH_WEST,
            WEST,
            NORTH_WEST,
            NORTH,
            NORTH_EAST,
            NULL,
        }

        private readonly Point2D _direction;
        private readonly double _angle;
        public Direction(double x, double y, double angle)
        {
            this._direction = new Point2D(x, y);
            this._angle = angle;
        }

        public double X { get { return _direction.X; } }

        public double Y { get { return _direction.Y; } }

        public Point2D Traduce() { return _direction; }

        public double Angle { get { return _angle;} }
    }
}
