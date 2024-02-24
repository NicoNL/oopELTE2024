using System;


namespace CircleExists
{
    public class Point
    {
        public readonly double x, y;
        public Point (double x, double y)
        {
            this.x = x; this.y = y;
        }

        public double distance(Point p)
        {
            return Math.Sqrt(Math.Pow((x-p.x),2)+Math.Pow((y-p.y),2));
        }
    }
}