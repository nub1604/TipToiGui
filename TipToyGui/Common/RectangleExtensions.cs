using System.Drawing;

namespace TipToyGui
{
    public static class RectangleExtensions
    {
        public static PointF Center(this RectangleF r)
        {
            return new PointF(r.X + r.Width / 2, r.Y + r.Height / 2);
        }

        public static PointF AbsoluteCenter(this RectangleF r)
        {
            return new PointF(r.Width / 2, r.Height / 2);
        }


        public static Point Center(this Rectangle r)
        {
            return new Point(r.X + r.Width / 2, r.Y + r.Height / 2);
        }

        public static Point AbsoluteCenter(this Rectangle r)
        {
            return new Point(r.Width / 2, r.Height / 2);
        }

    }
}