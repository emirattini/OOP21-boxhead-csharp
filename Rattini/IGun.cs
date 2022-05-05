using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public interface IGun : IEntity
    {
        enum GunType
        {
            PISTOL,
            UZI,
            SHOTGUN
        }

        String GetName();

        ISet<IShot> Attack(Point2D pos, Direction direction);

        int Damage { get; }

        int MagazineSize { get; }

        int CurrentAmmo { get; }

        GunType GetGunType();

        void RechargeAmmo(int ammo);

        void UpdateDamage(int damage);

        void UpdateRateOfFire(long rate);

        void UpdateMagazine(int magazine);


    }
}
