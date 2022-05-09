using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace Entity
{
    public class Player : AbstractHealthEntity
    {
        private static readonly int MAX_HEALTH = 100;

        //private LinkedList<Gun> _guns;
        private ISet<BoundingBox> _walls;
        private readonly List<bool> _iscolliding;
        //public Gun CurrentGun { get; set; }
        private int _gunIndex;
        //private Gun _selectedGun = null;

        public Player() : base(new PointF(0, 0), Direction.EAST, new PointF(50, 50), EntityType.PLAYER, MAX_HEALTH)
        {
            //_guns= new LinkedList<Gun>();
            //_currentGun = new GunFactory().getGun(this.getPosition(), GunType.PISTOL);
            //_guns.AddLast(_currentGun);
            _iscolliding = new List<bool>();
            _gunIndex = 0;
        }

        public ISet<BoundingBox> Walls
        {
            set
            {
                _walls = value;
            }
        }


        //public void CheckCollision(Direction direction)
        //{
        //    if(!direction.Equals(Direction.NULL))
        //    {
        //        Direction = direction;
        //        BoundingBox playerBB = new BoundingBox(Position.X + direction.traduce().X, Position.Y + direction.traduce().Y, Width(), Height());
        //        foreach(BoundingBox BB in _walls)
        //        {
        //            if (Collision.IsColliding(playerBB, BB))
        //            {
        //                _iscolliding.Add(true);
        //            }
        //        }
        //        if (_iscolliding.Count)
        //        {
        //            Speed = new PointF(0,0);
        //        }
        //        else
        //        {
        //            Speed = direction.traduce();
        //        }
        //    }
        //    else
        //    {
        //        Speed = direction.traduce();
        //    }
        //    _iscolliding.Clear();
        //}


        //    public void UnlockGun(Gun gun)
        //    {
        //        _guns.AddLast(gun);
        //    }

        //    public void NextGun()
        //    {
        //        if (_gunIndex + 1 < _guns.Count)
        //        {
        //            CurrentGun = _guns.ElementAt(++_gunIndex);
        //        }
        //        else
        //        {
        //            _gunIndex = 0;
        //            CurrentGun = _guns.ElementAt(_gunIndex);
        //        }
        //    }

        //    public void PreviousGun()
        //    {
        //        if (_gunIndex > 0)
        //        {
        //            CurrentGun = _guns.ElementAt(--_gunIndex);
        //        }
        //        else
        //        {
        //            _gunIndex = _guns.Count;
        //            CurrentGun=_guns.ElementAt(_gunIndex)
        //        }
        //    }
    }



}
