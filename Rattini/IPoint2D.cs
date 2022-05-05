using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public interface IPoint2D
    {
        double X { get; }

        double Y { get; }

        Point2D Add(Point2D point);
    }
}
