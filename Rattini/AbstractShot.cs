using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public abstract class AbstractShot : AbstractEntity, IShot
    {
        private readonly int _damage;
        public AbstractShot(Point2D point, EntityType type, int damage) : base(point, type)
        {
            this._damage = damage;
        }

        public abstract ITrajectory GetTrajectory();
        public int Damage
        {
            get { return this._damage; }
        }

        public bool HasEnded()
        {
            return this.GetTrajectory.HasEnded;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
