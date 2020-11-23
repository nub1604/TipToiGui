using System;
using System.Drawing;
using System.Windows.Forms;

namespace TipToyGui
{
    public static class PointExtensions
    {
        public static Point Add(this Point p, Point point)
        {
            return new Point(p.X + point.X, p.Y + point.Y);
        }

        public static Point Sub(this Point p, Point point)
        {
            return new Point(p.X - point.X, p.Y - point.Y);
        }

        public static PointF Add(this PointF p, PointF point)
        {
            return new PointF(p.X + point.X, p.Y + point.Y);
        }

        public static PointF Sub(this PointF p, PointF point)
        {
            return new PointF(p.X - point.X, p.Y - point.Y);
        }

        public static PointF Sub(this Point p, PointF point)
        {
            return new PointF(p.X - point.X, p.Y - point.Y);
        }

        public static PointF Divide(this Point start, PointF end)
        {
            return new PointF(start.X / end.X, start.Y / end.Y);
        }

        public static Point ToPoint(this PointF pointF)
        {
            return new Point((int)pointF.X, (int)pointF.Y);
        }
        public static Point AddX(this Point p, int x)
        {
            return new Point(p.X + x, p.Y);
        }

        public static Point AddY(this Point p, int y)
        {
            return new Point(p.X, p.Y + y);
        }

        public static Point SubX(this Point p, int x)
        {
            return new Point(p.X - x, p.Y);
        }

        public static Point SubY(this Point p, int y)
        {
            return new Point(p.X, p.Y - y);
        }

        public static bool IsGreaterX(this Point p1, Point p2)
        {
            return p1.X < p2.X;
        }

        public static PointF ReCalcZoom(this PointF p1, float zoom)
        {
            return new PointF(p1.X * zoom, p1.Y * zoom);
        }

        public static PointF ReCalcZoom(this Point p1, float zoom)
        {
            return new PointF((int)(p1.X * zoom), (int)(p1.Y * zoom));
        }

        public static PointF ReCalcInvertZoom(this PointF p1, float zoom)
        {
            return new PointF((p1.X / zoom), (p1.Y / zoom));
        }

        public static PointF ReCalcInvertZoom(this Point p1, float zoom)
        {
            return new PointF((p1.X / zoom), (p1.Y / zoom));
        }

        public static SizeF ReCalcZoom(this SizeF p1, float zoom)
        {
            return new SizeF((int)(p1.Width * zoom), (int)(p1.Height * zoom));
        }

        public static PointF[] ReCalcZoom(this PointF[] pts, float zoom)
        {
            PointF[] nerPointArray = new PointF[pts.Length];
            for (int i = 0; i < pts.Length; i++)
            {
                nerPointArray[i] = pts[i].ReCalcZoom(zoom);
            }
            return nerPointArray;
        }

        public static RectangleF ReCalcZoom(this RectangleF rectangle, float zoom)
        {
            return new RectangleF(rectangle.Location.ReCalcZoom(zoom), rectangle.Size);
        }

        public static RectangleF ReCalcInvertZoom(this RectangleF rectangle, float zoom)
        {
            return new RectangleF(rectangle.Location.ReCalcInvertZoom(zoom), rectangle.Size);
        }

        public static float AbsLength  (this PointF start, PointF end)
         {
           return (float) Math.Sqrt(Math.Pow(( Math.Abs( end.Y - start.Y)), 2) + Math.Pow((Math.Abs (end.X - start.X)), 2));
        }
        public static float Length  (this PointF start, PointF end)
        {
           return (float) Math.Sqrt(Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.X - start.X, 2));
        }
        public static Point[] CalcBezier(Point pStart, Point pEnd, bool p1left = true, bool p2left = false)
        {
            var top = pStart.Y < pEnd.Y ? pStart.Y : pEnd.Y;
            var bottom = top == pStart.Y ? pEnd.Y : pStart.Y;

            var left = pStart.X < pEnd.X ? pStart.X : pEnd.X;
            var right = left == pStart.X ? pEnd.X : pStart.X;

            var disX = right - left;
            var disY = bottom - top;

            var ps = pStart;
            var p1 = p1left ? pStart.AddX(40) : pStart.SubX(40);
            var p2 = p2left ? pEnd.AddX(40) : pEnd.SubX(40);

            var inL = p2.X < p1.X ? p2.X : p1.X;

            var pM = p1left != p2left ? new Point(left + disX / 2, top + disY / 2) : new Point(inL + disX / 2, top + disY / 2);

            var pE = pEnd;

            return new Point[] { ps, p1, p1, pM, p2, p2, pE };
        }

        public static Point RightFrom(this Control control)
        {
            return new Point(control.Right, control.Top);
        }

        public static Point Underneath(this Control control)
        {
            return new Point(control.Left, control.Bottom);
        }

        public static Rectangle ToR(this RectangleF r)
        {
            return new Rectangle((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height);
        }
    }
}