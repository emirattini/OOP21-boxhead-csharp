using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public interface IEntity
    {
        Point2D Position { get; set; }
        EntityType Type { get; }
        double Width { get; set; }
        double Height { get; set; }
    }
}
