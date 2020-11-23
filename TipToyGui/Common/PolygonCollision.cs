using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TipToyGui.Common
{
    public static class PolygonCollision
    {
        private static bool LineLineCollision(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
            float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

            // if uA and uB are between 0-1, lines are colliding
            if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
            {
                return true;
            }
            return false;
        }

        private static (PointF, PointF)[] GetLines(this Polygon polygon)
        {
            List<(PointF, PointF)> Lines = new List<(PointF, PointF)>();

            var vectors = polygon.Vertices;
            for (int i = 0; i < vectors.Length; i++)
            {
                if (i == vectors.Length - 1)
                {
                    Lines.Add((vectors[i], vectors[0]));
                }
                else
                    Lines.Add((vectors[i], vectors[i + 1]));
            }
            return Lines.ToArray();
        }

        private static (PointF, PointF)[] GetLines(this PointF[] vertices)
        {
            List<(PointF, PointF)> Lines = new List<(PointF, PointF)>();

            var vectors = vertices;
            for (int i = 0; i < vectors.Length; i++)
            {
                if (i == vectors.Length - 1)
                {
                    Lines.Add((vectors[i], vectors[0]));
                }
                else
                    Lines.Add((vectors[i], vectors[i + 1]));
            }
            return Lines.ToArray();
        }

        public static bool PointInPolygon(this Polygon polygon, PointF ps)
        {
            return PointInPolygon(polygon, ps.X, ps.Y);
        }

        public static bool PointInPolygon(this Polygon polygon, float x, float y)
        {
            var l = polygon.GetLines();

            int count ;
            var pe = new PointF(x + float.MaxValue, y - float.MaxValue);
            count = CountCollision(x, y, l, pe);

            return ((count & 1) == 1);
        }

        public static bool PointInPolygon(this PointF[] polygon, float x, float y)
        {
            var l = polygon.GetLines();

            int count;
            var pe = new PointF(x + float.MaxValue, y - float.MaxValue);
            count = CountCollision(x, y, l, pe);

            return ((count & 1) == 1);
        }

        public static PointF FindClosest(this PointF[] searchIn, PointF compareTo)
        {
            if (searchIn == null || searchIn.Length == 0) return Point.Empty;

            return searchIn
                .Select(p => new { point = p, distance = DistanceSquaredBetweenPoints(p, compareTo) })
                .OrderBy(distances => distances.distance)
                .First().point;
        }

        public static PointF[] GetNeighbors(this PointF[] searchIn, PointF source)
        {
            var s = Array.IndexOf(searchIn, source);
            if (s != -1)
            {
                var pUp = searchIn[s + 1 == searchIn.Length ? 0 : s + 1];

                var pDown = searchIn[s - 1 == -1 ? searchIn.Length - 1 : s - 1];

                if (pDown != pUp) return new PointF[] { pUp, pDown };
            }
            return null;
        }

        public static PointF FindClosest(this Polygon searchIn, PointF compareTo)
        {
            return searchIn.Vertices
                .Select(p => new { point = p, distance = DistanceSquaredBetweenPoints(p, compareTo) })
                .OrderBy(distances => distances.distance)
                .First().point;
        }

        private static double DistanceSquaredBetweenPoints(PointF p1, PointF p2)
        {
            return Math.Pow((p2.X - p1.X), 2) + Math.Pow(p2.Y - p1.Y, 2);
        }

        private static int CountCollision(PointF ps, (PointF, PointF)[] l, PointF pe)
        {
            return CountCollision(ps.X, ps.Y, l, pe);
        }

        private static int CountCollision(float x, float y, (PointF, PointF)[] l, PointF pe)
        {
            int count = 0;
            for (int i = 0; i < l.Length; i++)
            {
                var ls = l[i].Item1;
                var le = l[i].Item2;

                if (LineLineCollision(ls.X, ls.Y, le.X, le.Y, x, y, pe.X, pe.Y))
                {
                    count++;
                }
            }
            return count;
        }
    }
}