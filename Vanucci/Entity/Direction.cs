using System.Collections.Generic;
using System.Drawing;

namespace Entity
{

    public sealed class Direction
    {
        public static readonly Direction NORTH = new Direction("NORTH", InnerEnum.NORTH, 0, -1, 270);

        public static readonly Direction NORTH_EAST = new Direction("NORTH_EAST", InnerEnum.NORTH_EAST, 0.707, -0.707, 315);

        public static readonly Direction EAST = new Direction("EAST", InnerEnum.EAST, 1, 0, 0);

        public static readonly Direction SOUTH_EAST = new Direction("SOUTH_EAST", InnerEnum.SOUTH_EAST, 0.707, 0.707, 45);

        public static readonly Direction SOUTH = new Direction("SOUTH", InnerEnum.SOUTH, 0, 1, 90);

        public static readonly Direction SOUTH_WEST = new Direction("SOUTH_WEST", InnerEnum.SOUTH_WEST, -0.707, 0.707, 135);

        public static readonly Direction WEST = new Direction("WEST", InnerEnum.WEST, -1, 0, 180);

        public static readonly Direction NORTH_WEST = new Direction("NORTH_WEST", InnerEnum.NORTH_WEST, -0.707, -0.707, 225);

        public static readonly Direction NULL = new Direction("NULL", InnerEnum.NULL, 0, 0, -1);

        private static readonly List<Direction> valueList = new List<Direction>();

        static Direction()
        {
            valueList.Add(NORTH);
            valueList.Add(NORTH_EAST);
            valueList.Add(EAST);
            valueList.Add(SOUTH_EAST);
            valueList.Add(SOUTH);
            valueList.Add(SOUTH_WEST);
            valueList.Add(WEST);
            valueList.Add(NORTH_WEST);
            valueList.Add(NULL);
        }

        public enum InnerEnum
        {
            NORTH,
            NORTH_EAST,
            EAST,
            SOUTH_EAST,
            SOUTH,
            SOUTH_WEST,
            WEST,
            NORTH_WEST,
            NULL
        }

        public readonly InnerEnum innerEnumValue;
        private readonly string nameValue;
        private readonly int ordinalValue;
        private static int nextOrdinal = 0;
        private readonly PointF direction;
        private readonly double angle;


        internal Direction(string name, InnerEnum innerEnum, double x, double y, double angle)
        {
            direction = new PointF((float)x, (float)y);
            this.angle = angle;

            nameValue = name;
            ordinalValue = nextOrdinal++;
            innerEnumValue = innerEnum;
        }

        public double X
        {
            get
            {
                return direction.X;
            }
        }

        public double Y
        {
            get
            {
                return direction.Y;
            }
        }

        public PointF traduce()
        {
            return direction;
        }

        public double Angle
        {
            get
            {
                return angle;
            }
        }

        public static IList<Direction> values()
        {
            return valueList;
        }

        public int ordinal()
        {
            return ordinalValue;
        }

        public override string ToString()
        {
            return nameValue;
        }

        public static Direction valueOf(string name)
        {
            foreach (Direction enumInstance in valueList)
            {
                if (enumInstance.nameValue == name)
                {
                    return enumInstance;
                }
            }
            throw new System.ArgumentException(name);
        }
    }
}

