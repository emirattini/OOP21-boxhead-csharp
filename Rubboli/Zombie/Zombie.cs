namespace Zombie;

public class Zombie : AbstractHealthEntity
{
    private readonly int damage;

    public Zombie(Point2D spawnPoint, Direction direction, double speed, EntityType entityType, int maxHp,
        int damage) : base(new Point2D(speed,speed), Direction.WEST, spawnPoint, EntityType.ZOMBIE, maxHp)
    {
        this.damage = damage;
    }

    public int Damage { get; }

public class Builder
    {
        private Point2D spawnPoint;
        private double speed;
        private int maxHp;
        private int damageDealt;

        private Direction direction;

        public Builder(Point2D spawnPoint)
        {
            this.spawnPoint = spawnPoint;
        }

        public Builder Speed(double speed)
        {
            this.speed = speed;
            return this;
        }

        public Builder MaxHp(int maxHp)
        {
            this.maxHp = maxHp;
            return this;
        }

        public Builder DamageDealt(int dmg)
        {
            this.damageDealt = dmg;
            return this;
        }

        public Zombie build()
        {
            return new Zombie(spawnPoint, direction, speed, EntityType.ZOMBIE, maxHp, damageDealt);
        }
    }
}


