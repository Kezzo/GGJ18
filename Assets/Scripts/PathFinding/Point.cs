using System;

namespace PathFinding
{
    [Serializable]
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator ==(Point p0, Point p1)
        {
            return p0.X == p1.X && p0.Y == p1.Y;
        }

        public static bool operator !=(Point p0, Point p1)
        {
            return !(p0 == p1);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                return ((Point)obj) == this;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return X + Y * 100000;
        }

        public override string ToString()
        {
            return string.Format("[Point {0} {1}]", X, Y);
        }
    }
}