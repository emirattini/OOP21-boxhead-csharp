using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entity;

namespace PlayerTest
{
    [TestClass]
    public class PlayerTest
    {
        private Player _player = new Player();
        private readonly PointF PLAYER_POSITION = new PointF(10, 10);
        private readonly BoundingBox OBSTACLE = new BoundingBox(100, 100, 15, 15);
        private readonly int PLAYER_BB = 20;
        private readonly int MAX_HP = 100;



        [TestMethod]
        public void TestMovement()
        {
            Assert.AreEqual(MAX_HP, _player.Health);
            _player.Position = PLAYER_POSITION;
            //Test NORTH movement
            _player.Direction = Direction.NORTH;
            _player.Speed = _player.Direction.traduce();
            _player.Update();
            Assert.AreEqual(new PointF(10, 9), new PointF(_player.Position.X, _player.Position.Y));
            //Test NORTH_EAST movement
            _player.Position = PLAYER_POSITION;
            _player.Direction = Direction.NORTH_EAST;
            _player.Speed = _player.Direction.traduce();
            _player.Update();
            Assert.AreEqual(new PointF(10 + Direction.NORTH_EAST.traduce().X, 10 + Direction.NORTH_EAST.traduce().Y), new PointF(_player.Position.X, _player.Position.Y));

        }

        ////public void TestCollision()
        ////{
        ////    _player.SetBoundingBox(PLAYER_BB,PLAYER_BB);
        ////    ISet<BoundingBox> obstacles = new HashSet<BoundingBox>();
        ////    obstacles.Add(OBSTACLE);
        ////    _player.Walls=obstacles;
        ////    _player.CheckCollision(Direction.NULL);
        ////    Assert.AreEqual(new PointF(0,0), _player.Speed);
        ////}
    }
}