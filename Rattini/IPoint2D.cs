using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP21_boxhead_csharp.Rattini
{
    public interface IPoint2D
    {
        double GetX();
        double GetY();

        void Add(Point2D point);
    }
}
