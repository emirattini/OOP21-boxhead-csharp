using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public class StraightTrajectory : ITrajectory
    {
        private static readonly double DEFAULT_SPEED = 20;

        private double _speed;
        private readonly double _angle;
        private Point2D _position;
        private readonly Point2D _positionVariation;

        public StraightTrajectory(Point2D from, Point2D towards)
        {
            this._position = from;
            this._positionVariation = towards;
            this.Speed = DEFAULT_SPEED;
        }

        public Point2D GetCurrentPosition()
        {
            return this._position;
        }

        public double Angle
        {
            get { return this._angle; }
        }

        public double Speed
        {
            get { return this._speed; }
            set { this._speed = value; }
        }

        public Point2D GetPositionVariation()
        {
            return this._positionVariation;
        }

        public bool HasEnded()
        {
            return false;
        }

        public void Update()
        {
            this._position = this._position.Add(this._positionVariation);
        }
    }
}
