namespace Zombie;
    public interface IZombieModel
    {
        void Update();
        ISet<Zombie> Zombies { get; }

        void HitZombie(Zombie zombie, int damage);

        int ZombiesToSpawn { set; }

    }