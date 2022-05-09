using System;
using System.Drawing;

namespace Entity
{

    public interface IActiveEntity
    {
        PointF Speed { get; set; }
        Direction Direction { get; set; }
        void Update();
    }
}