using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies
{
    public interface IActiveEntity : IEntity
    {

        Point2D Speed { get; set; }

        void Update();

        Direction Direction { get; set; }
    }
}
