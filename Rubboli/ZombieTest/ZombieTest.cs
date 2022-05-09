using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Zombie;

namespace ZombieTest;

    [TestClass]
    public class ZombieTest
    {
        private IZombieModel model = new ZombieModel();
        private readonly Point SPAWN_POINT = new Point(0, 0);

        [TestMethod]
        public void TestSpawn()
        {
            this.model.ZombiesToSpawn = 1;
            this.model.Update();
            Assert.IsTrue(this.model.Zombies.Count == 1);
        }

        [TestMethod]
        public void TestHitZombie()
        {
            this.model.ZombiesToSpawn = 1;
            this.model.Update();
            Zombie zombie = this.model.Zombies.ToList()[0];
            int zombieHp = zombie.Health;
            int damage = zombieHp / 2;
            this.model.HitZombie(zombie, damage);
            Assert.IsTrue(zombie.Health.Equals(zombieHp - damage));
        }

        [TestMethod]
        public void TestKillZombie()
        {
            this.model.ZombiesToSpawn = 1;
            this.model.Update();
            Zombie zombie = this.model.Zombies.ToList()[0];
            int zombieHp = zombie.Health;
            this.model.HitZombie(zombie, zombieHp);
            this.model.Update();
            Assert.IsTrue(this.model.Zombies.Count == 0);
        }
    }

