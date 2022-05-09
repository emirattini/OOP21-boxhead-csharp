using System.Drawing;
using System;

namespace Entity
{
    public interface IEntity
    {
        PointF Position { get; set; }

        EntityType EntityType { get; }

        double Width();

        double Height();

        BoundingBox BoundingBox { get; }

        void SetBoundingBox(double height, double width);
    }
}