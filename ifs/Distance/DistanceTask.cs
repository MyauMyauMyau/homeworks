using System;
using System.Collections.Generic;
using System.Linq;

namespace Distance
{
    public class Point
    {
        public double X { get;}
        public double Y { get;}
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double GetDistanceTo(Point p2)
        {
            return (Math.Sqrt((X - p2.X) * (X - p2.X) + (Y - p2.Y) * (Y - p2.Y)));
        }
        public double GetDistanceTo(Line line)
        {
            var intersection = this.LayPerpendicular(line);
            return (intersection.isOnTheSegment(line)) ? this.GetDistanceTo(intersection) :
                Math.Min(this.GetDistanceTo(line.StartPoint), this.GetDistanceTo(line.EndPoint));
        }
        public bool isOnTheSegment(Line line)
        {
            return ((Y > line.StartPoint.Y && Y < line.EndPoint.Y) || (Y < line.StartPoint.Y && Y > line.EndPoint.Y));
        }

        public Point LayPerpendicular(Line line)
        {
            var p1 = line.StartPoint;
            var p2 = line.EndPoint;
            // a, b, c - coefficients in fundamental equality
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

    public class Line
    {
        public Point StartPoint { get; }
        public Point EndPoint { get; }
        public Line(Point p1, Point p2)
        {
            StartPoint = p1;
            EndPoint = p2;
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
            var polygonLines = new List<Line>();
            polygonLines.Add(new Line(new Point(-50, 10), new Point(-50,-10)));
            polygonLines.Add(new Line(new Point(-50, 10), new Point(0, 60)));
            polygonLines.Add(new Line(new Point(0,60), new Point(50, 10)));
            polygonLines.Add(new Line(new Point(50, 10), new Point(50, -10)));

            var distances = new List<double>();
            for (int i = 0; i < edges; i++)
                distances.Add(p.GetDistanceTo(polygonLines[i]));

            if (y <= arcCenter.Y)
                distances.Add(Math.Abs(p.GetDistanceTo(arcCenter) - arcRadius));

            return distances.Min();
        }
    }




}