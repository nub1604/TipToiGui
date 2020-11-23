using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using TipToyGui.Common;

namespace TipToyGui
{
    public class TTImage
    {
        public string TTFile { get; set; }
        public float TTScale { get; set; }

        public float TTRotation { get; set; }
        public PointF TTLocation { get; set; }

        private Image image;
        private GraphicsPath gp;
        private Matrix m = new Matrix();

        public TTImage()
        {
        }

        public TTImage(string fileName)
        {
            TTFile = fileName;
            TTScale = 1;
        }

        public GraphicsPath GetPath(float percent, bool four = true)
        {
            if (image == null)
            {
                if (!File.Exists(TTFile)) return null;
                image = Bitmap.FromFile(TTFile);
            }
            gp = new GraphicsPath();
            if (four)
            {
                gp.AddPolygon(new Point[]{
                new Point(0,0),
                new Point(image.Width,0),
                new Point(image.Width,image.Height),
                new Point(0,image.Height)

            });
            }
            else
            {
                gp.AddPolygon(new Point[]{
                new Point(0,0),
                new Point(image.Width,0),
                new Point(0,image.Height) });
            }
            m = new Matrix();

            m.Scale(percent, percent);

            m.Translate(TTLocation.X, TTLocation.Y);
            m.Scale(TTScale, TTScale);
            m.RotateAt(TTRotation, gp.GetBounds().Center());

            gp.Transform(m);

            return gp;
        }


        public void Draw(Graphics g, float percent)
        {
            var path = GetPath(percent, false);
            if (path == null) return;
            var p = path.PathPoints;
            //var ps = new PointF[3] { p[0], p[1], p[2] };

            g.DrawImage(image, p);
        }

        public void DrawBorder(Graphics g, float percent)
        {
            var gp = GetPath(percent);
            if (gp == null) return;
            var p = gp.PathPoints; 
            //PointF[] borderPoint = new PointF[4]
            // {
            //    p[0], p[1], new PointF(p[1].X, p[2].Y), p[2]
            // };
            g.DrawPolygon(new Pen(Color.Blue, 4), p);
        }

        public bool Contains(PointF location, float percent)
        {
            var gp = GetPath(percent);
            if (gp == null) return false;
            var p = gp.PathPoints;
            return p.PointInPolygon(location.X, location.Y);
        }
        public PointF Middle(float percent)
        {
            var gp = GetPath(percent);
            if (gp == null) return PointF.Empty;
            var b = gp.GetBounds();
            return b.AbsoluteCenter();

           
        }

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(TTFile);
        }
    }
}