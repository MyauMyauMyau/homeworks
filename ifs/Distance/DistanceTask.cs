using System;
using System.Collections.Generic;
using System.Linq;

namespace Distance
{
    public class Point
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double GetDistanceTo(Point p2)
        {
            return (Math.Sqrt((X - p2.X) * (X - p2.X) + (Y - p2.Y) * (Y - p2.Y)));
        }
        public bool isOnTheSegment(Point start, Point end)
        {
            if ((Y > start.Y && Y < end.Y) || (Y < start.Y && Y > end.Y))
                return true;
            return false;
        }

        public Point LayPerpendicular(Point p1, Point p2)
        {
            var a1 = p1.Y - p2.Y;
            var b1 = p2.X - p1.X;
            var c1 = -1 * (p1.X * a1 + p1.Y * b1);
            var a2 = b1;
            var b2 = -a1;
            var c2 = -(b1 * X + b2 * Y);
            var x = -(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
            var y = -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
            return new Point(x, y);
        }
    }
    public class DistanceTask
    {
        readonly int edges = 4;

        public double GetDistanceToCurve(double x, double y)
        {
            var p = new Point(x, y);
            var arcCenter = new Point(0, -10);
            var arcRadius = 50;
            var polygonLines = new List<Tuple<Point, Point>>();
            polygonLines.Add(new Tuple<Point, Point>(new Point(-50, 10), new Point(-50,-10)));
            polygonLines.Add(new Tuple<Point, Point>(new Point(-50, 10), new Point(0, 60)));
            polygonLines.Add(new Tuple<Point, Point>(new Point(0,60), new Point(50, 10)));
            polygonLines.Add(new Tuple<Point, Point>(new Point(50, 10), new Point(50, -10)));

            var distances = new List<double>();
            distances.Add(p.GetDistanceTo(polygonLines[0].Item1));
            for (int i = 0; i < edges; i++)
                distances.Add(p.GetDistanceTo(polygonLines[i].Item2));

            if (y <= arcCenter.Y)
                distances.Add(Math.Abs(p.GetDistanceTo(arcCenter) - arcRadius));

            var intersections = new Point[edges];
            for (int i = 0; i < edges; i++)
            {
                intersections[i] = p.LayPerpendicular(polygonLines[i].Item1, polygonLines[i].Item2);
                if (intersections[i].isOnTheSegment(polygonLines[i].Item1, polygonLines[i].Item2))
                    distances.Add(p.GetDistanceTo(intersections[i]));
            }
            return distances.Min();
        }
    }
}