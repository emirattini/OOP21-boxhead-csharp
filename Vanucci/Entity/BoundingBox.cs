namespace Entity
{
    public class BoundingBox
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _xMax;
        private readonly double _yMax;

        public BoundingBox(double x, double y, double widht, double height)
        {
            _x = x;
            _y = y;
            _xMax = _x + widht;
            _yMax = _y + height;
        }

        public double GetX() => _x;

        public double GetY() => _y;

        public double GetXMax() => _xMax;

        public double GetYMax() => _yMax;

        public bool Intersect(BoundingBox bb)
        {
            return bb.GetXMax() >= _x && bb.GetX() <= _xMax && bb.GetYMax() >= _y && bb.GetY() <= _yMax;
        }

    }


}