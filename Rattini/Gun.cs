using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public class Gun : AbstractEntity, IGun
    {
        private readonly IGun.GunType _gunType;
        private int _damage;
        private long _rateOfFire;
        private int _magazineSize;
        private readonly String _name;

        private long _lastShot;
        private int _ammoInMagazine;

        public Gun(Point2D pos, IGun.GunType gunType, String name, int damage, long rate, int magazine) : base(pos, EntityType.GUN)
        {
            this._gunType = gunType;
            this._name = name;
            this._damage = damage;
            this._rateOfFire = rate;
            this._magazineSize = magazine;
            this._ammoInMagazine = magazine;
            this._lastShot = 0;
        }
        
        public int Damage { get { return this._damage; } }

        public int MagazineSize { get { return this._magazineSize;} }

        public int CurrentAmmo { get { return this._ammoInMagazine;} }

        public ISet<IShot> Attack(Point2D pos, Direction direction)
        {
            ISet<IShot> shots = new HashSet<IShot>();
            if(DateTime.Now.Millisecond - _lastShot <= _rateOfFire || _ammoInMagazine <= 0)
            {
                return shots;
            }
            this._ammoInMagazine--;
            this._lastShot = DateTime.Now.Millisecond;
            switch (this._gunType)
            {
                case IGun.GunType.PISTOL:
                case IGun.GunType.UZI:
                    shots.Add(new Bullet(pos, pos.Add(direction.Traduce()), Damage));
                    return shots;
                case IGun.GunType.SHOTGUN:
                    shots.Add(new Bullet(pos, pos.Add(direction.Traduce()), Damage));
                    shots.Add(new Bullet(pos, pos.Add(direction.Traduce()), Damage));
                    shots.Add(new Bullet(pos, pos.Add(direction.Traduce()), Damage));
                    return shots;
            }
            return shots;
        }

        public IGun.GunType GetGunType()
        {
            return this._gunType;
        }

        public string GetName()
        {
            return this._name;
        }

        public void RechargeAmmo(int ammo)
        {
            this._ammoInMagazine = ammo;
        }

        public void UpdateDamage(int damage)
        {
            this._damage = damage;
            this._ammoInMagazine = MagazineSize;
        }

        public void UpdateMagazine(int magazine)
        {
            this._magazineSize = magazine;
            this._ammoInMagazine = magazine;
        }

        public void UpdateRateOfFire(long rate)
        {
            this._rateOfFire = rate;
        }
    }
}
