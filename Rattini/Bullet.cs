using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public class Bullet : AbstractShot
    {
        private static readonly double HEIGHT = 2;
        private static readonly double WIDTH = 1;

        private readonly ITrajectory _trajectory;

        public Bullet(Point2D from, Point2D towards, int damage) : base (from, EntityType.BULLET, damage)
        {
            this._trajectory = new StraightTrajectory(from, towards);
        }

        public override ITrajectory GetTrajectory()
        {
            return this._trajectory;
        }
    }
}
