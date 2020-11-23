using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace TipToyGui
{
    public class Scene
    {
        public Scene()
        {
        }

        public Scene(string name, Size size, EnumDPI dPI)
        {
            Name = name;
            CanvasSize = size;
            ResolutionDPI = (dPI == EnumDPI.High ? 1200 : 600);
            SceneOids = new List<SceneOid>();
            TTImages = new List<TTImage>();
        }

        public string Name { get; set; }

        public int ResolutionDPI { get; set; }

        /// <summary>
        /// In Milimeter
        /// </summary>
        public Size CanvasSize { get; set; }

        public Size PixelSize { get => Scene.GetPixelSize(CanvasSize, ResolutionDPI); }
        public Size PixelSizeZoomed(float percent) { return new Size((int)(PixelSize.Width * percent), (int)(PixelSize.Width * percent)); }



        public List<TTImage> TTImages { get; set; }

        public List<SceneOid> SceneOids { get; set; }
        public SceneOid StartOid { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static Size DinA3H = new Size(420, 297);
        public static Size DinA4H = new Size(297, 210);
        public static Size DinA5H = new Size(210, 148);

        public static Size DinA3V = new Size(297, 420);
        public static Size DinA4V = new Size(210, 297);
        public static Size DinA5V = new Size(148, 210);

        public const float DPI1200 = 47.242857f;
        public const float DPI600 = 23.62142857f;

        public enum EnumDin
        {
            HorizontalA4,
            HorizontalA5,
            HorizontalA3,
            VertivalA4,
            VertivalA5,
            VertivalA3,
        }

        public static Size GetPixelSize(EnumDin din, int dpi)
        {
            var dinSize = Din2Size(din);
            switch (dpi)
            {
                case 600: return new Size((int)(dinSize.Width * DPI600), (int)(dinSize.Height * DPI600));
                default: return new Size((int)(dinSize.Width * DPI1200), (int)(dinSize.Height * DPI1200));
            }
        }

        public static Size GetPixelSize(Size mm, int dpi)
        {
            if (mm == Size.Empty)
            {
                mm = DinA4H;
            }

            switch (dpi)
            {
                case 600: return new Size((int)(mm.Width * DPI600), (int)(mm.Height * DPI600));
                default: return new Size((int)(mm.Width * DPI1200), (int)(mm.Height * DPI1200));
            }
        }

        public static Size Din2Size(EnumDin din)
        {
            switch (din)
            {
                case EnumDin.HorizontalA3: return DinA3H;
                case EnumDin.HorizontalA4: return DinA4H;
                case EnumDin.HorizontalA5: return DinA5H;
                case EnumDin.VertivalA3: return DinA3V;
                case EnumDin.VertivalA4: return DinA4V;
                case EnumDin.VertivalA5: return DinA5V;
                default: return DinA4H;
            }
        }
        public static EnumDin SizeToDin(Size size)
        {

            if (size == DinA3H) return EnumDin.HorizontalA3;
            else if (size == DinA4H) return EnumDin.HorizontalA4;
            else if (size == DinA5H) return EnumDin.HorizontalA5;
            else if (size == DinA3V) return EnumDin.VertivalA3;
            else if (size == DinA4V) return EnumDin.VertivalA4;
            else return EnumDin.VertivalA5;
        }
    }
}