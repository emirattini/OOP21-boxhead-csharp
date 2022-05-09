namespace Zombie;
public class ZombieModel : IZombieModel
{
  public double speed;

  public int maxHp;

  public int damage; 
  
   private readonly ISet<Zombie> zombies;
   
   private int zombiesToSpawn;
   
   private double lastSpawn;

   private ISet<Zombie> zombiesToKill {get; set;}

   private int killedZombies;

   public ZombieModel()
        {

            this.zombies = new HashSet<Zombie>();
            this.zombiesToKill = new HashSet<Zombie>();
            this.killedZombies = 0;
        }

   public void Update()
        {
            this.UpdateSpawns();
            this.UpdateKills();
        }

   public int ZombiesToSpawn
        {
            set
            {
                this.zombiesToSpawn = value;
            }
        }
   public ISet<Zombie> Zombies
         {
            get
            {
                return this.zombies;
            }
        }

   public int ZombiesCount
        {
            get
            {
                return this.zombiesToSpawn + this.killedZombies;
            }
        }

   public void HitZombie(Zombie zombie, int damage)
        {
            zombie.takeDamage(damage);
            if (!zombie.isAlive())
            {
                this.KillZombie(zombie);
            }
        }

        public int KilledZombies
        {
            get
            {
                return this.killedZombies;
            }
        }

        private void KillZombie(Zombie zombie)
        {
            this.zombiesToKill.Add(zombie);
        }

        private void UpdateSpawns()
        {
            for (int i = 0; i < this.zombiesToSpawn; i++) {
                this.SpawnZombie();
            }
        }

        private void SpawnZombie()
        {
            this.zombies.Add(new Zombie(new Point2D(0, 0), Direction.WEST, speed, EntityType.ZOMBIE, maxHp, damage));
            this.zombiesToSpawn -= 1;
        }

        private void UpdateKills()
        {
            this.killedZombies += this.zombiesToKill.Count;
            foreach (Zombie zombie in this.zombiesToKill)
            {
                this.zombies.Remove(zombie);
            }
            this.zombiesToKill.Clear();
        }
    }
