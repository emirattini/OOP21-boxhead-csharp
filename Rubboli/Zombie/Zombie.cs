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
}


