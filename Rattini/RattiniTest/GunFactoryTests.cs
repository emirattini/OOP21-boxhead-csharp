using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP21_boxhead_csharp.Rattini;

namespace RattiniTest
{
    [TestClass]
    public class GunFactoryTests
    {

        Point2D position = new Point2D(5, 5);
        GunFactory gunFactory = new GunFactory();

        [TestMethod]
        public void TestPistol()
        {
            IGun pistol = gunFactory.GetGun(position, IGun.GunType.PISTOL);
            Assert.AreEqual(pistol.GetName(), "Pistol");
            int ammo = pistol.CurrentAmmo;
            Bullet bullet1 = pistol.Attack(position, Direction.EAST).First;
            Assert.AreEqual(bullet1.GetType(), EntityType.BULLET);
            Assert.AreEqual(bullet1.Damage, pistol.Damage);
            Assert.IsFalse(bullet1.HasEnded);
            Assert.AreEqual(ammo - 1, pistol.CurrentAmmo);
            bullet1.Update();
            Assert.IsFalse(bullet1.Position.Equals(position));
            pistol.RechargeAmmo();
            Assert.AreEqual(ammo, pistol.CurrentAmmo);
        }

        public void TestUzi()
        {
            IGun uzi = gunFactory.GetGun(position, IGun.GunType.UZI);
            Assert.AreEqual(uzi.GetName(), "Uzi");
            int ammo = uzi.CurrentAmmo;
            Bullet bullet1 = uzi.Attack(position, Direction.EAST).First;
            Assert.AreEqual(bullet1.GetType(), EntityType.BULLET);
            Assert.AreEqual(bullet1.Damage, uzi.Damage);
            Assert.IsFalse(bullet1.HasEnded);
            Assert.AreEqual(ammo - 1, uzi.CurrentAmmo);
            bullet1.Update();
            Assert.IsFalse(bullet1.Position.Equals(position));
            uzi.RechargeAmmo();
            Assert.AreEqual(ammo, uzi.CurrentAmmo);
        }

        public void TestShotgun()
        {
            IGun shotgun = gunFactory.GetGun(position, IGun.GunType.SHOTGUN);
            Assert.AreEqual(shotgun.GetName(), "Shotgun");
            int ammo = shotgun.CurrentAmmo;
            Bullet bullet1 = shotgun.Attack(position, Direction.EAST).First;
            Assert.AreEqual(bullet1.GetType(), EntityType.BULLET);
            Assert.AreEqual(bullet1.Damage, shotgun.Damage);
            Assert.IsFalse(bullet1.HasEnded);
            Assert.AreEqual(ammo - 1, shotgun.CurrentAmmo);
            bullet1.Update();
            Assert.IsFalse(bullet1.Position.Equals(position));
            shotgun.RechargeAmmo();
            Assert.AreEqual(ammo, shotgun.CurrentAmmo);
        }
    }
}