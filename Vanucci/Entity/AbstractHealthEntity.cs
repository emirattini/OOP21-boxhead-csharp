using System.Drawing;

namespace Entity
{
    public abstract class AbstractHealthEntity : AbstractActiveEntity
    {
        public int Health { get; set; }

        public AbstractHealthEntity(PointF speed, Direction direction, PointF position, EntityType entityType, int health) : base(speed, direction, position, entityType)
        {
            Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}