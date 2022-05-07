using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public class GunFactory
    {
        private static readonly int PISTOL_DAMAGE = 30;
        private static readonly long PISTOL_RATE_OF_FIRE = 800;
        private static readonly int PISTOL_MAGAZINE = 15;

        private static readonly int UZI_DAMAGE = 25;
        private static readonly long UZI_RATE_OF_FIRE = 350;
        private static readonly int UZI_MAGAZINE = 25;

        private static readonly int SHOTGUN_DAMAGE = 50;
        private static readonly long SHOTGUN_RATE_OF_FIRE = 1000;
        private static readonly int SHOTGUN_MAGAZINE = 10;

        public IGun GetGun(Point2D position, IGun.GunType type)
        {
            switch (type)
            {
                case IGun.GunType.PISTOL:
                    return this.GetPistol(position);
                case IGun.GunType.UZI:
                    return this.GetUzi(position);
                case IGun.GunType.SHOTGUN:
                    return this.GetShotgun(position);
                default:
                    return GetPistol(position);
            }
        }

        private IGun GetPistol(Point2D position)
        {
            return new Gun.Builder(position, IGun.GunType.PISTOL, "Pistol")
                          .Damage(PISTOL_DAMAGE)
                          .RateOfFire(PISTOL_RATE_OF_FIRE)
                          .MagazineSize(PISTOL_MAGAZINE)
                          .Build();
        }

        private IGun GetUzi(Point2D position)
        {
            return new Gun.Builder(position, IGun.GunType.UZI, "Uzi")
                          .Damage(UZI_DAMAGE)
                          .RateOfFire(UZI_RATE_OF_FIRE)
                          .MagazineSize(UZI_MAGAZINE)
                          .Build();
        }

        private IGun GetShotgun(Point2D position)
        {
            return new Gun.Builder(position, IGun.GunType.SHOTGUN, "Shotgun")
                          .Damage(SHOTGUN_DAMAGE)
                          .RateOfFire(SHOTGUN_RATE_OF_FIRE)
                          .MagazineSize(SHOTGUN_MAGAZINE)
                          .Build();
        }
    }
}
