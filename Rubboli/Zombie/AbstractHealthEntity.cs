namespace Zombie;
	public abstract class AbstractHealthEntity : AbstractActiveEntity
{
    int health;

    public AbstractHealthEntity(Point2D speed, Direction direction, Point2D position, EntityType entityType, int health) : base(speed, direction, position, entityType)
		{
			this.health = health;
		}

    public int Health
		{
			set
			{
				this.health = value;
			}
			get
			{
				return this.health;
			}
		}

    public void takeDamage(int damage)
        {
            this.health -= damage;
        }

    public Boolean isAlive()
        {
            return this.health > 0;
        }
    }