using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies
{
    public interface IPoint2D
    {
        double X { get; }

        double Y { get; }

        Point2D Add(Point2D point);
    }
}
