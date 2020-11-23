using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TipToyGui.Common;

namespace TipToyGui
{
    public static class MaskPicture
    {
        public static Size PrecalculateOidSize(Polygon p, EnumDPI enumDPI)
        {
            float Res = GetEnumDPI(enumDPI);
            var s = p.GetBound().Size;
            return new Size((int)(s.Width / Res), (int)(s.Height / Res));
        }

        public static float GetEnumDPI(EnumDPI enumDPI)
        {
            switch (enumDPI)
            {
                case EnumDPI.Low:
                    return Scene.DPI600;

                default:
                    return Scene.DPI1200;
            }
        }

        public static void CreateImage(OIDProject oIDProject, Scene scene, TTToolSettings set)
        {
            if (scene == null || scene.TTImages == null || scene.TTImages.Count == 0) return;

            string destDir = Path.Combine(oIDProject.ProjectPath, "Scenes");
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            using (var scenePicture = new Bitmap(scene.PixelSize.Width, scene.PixelSize.Height))
            {
                using (Graphics graphic = Graphics.FromImage(scenePicture))
                {
                    foreach (var img in scene.TTImages)
                        img.Draw(graphic, 1);
                }
                scenePicture.Save(Path.Combine(destDir, $"{scene.Name}.jpg"), ImageFormat.Jpeg);
            }

            string workdir = Path.Combine(oIDProject.ProjectPath, "temp");
            if (!Directory.Exists(workdir))
            {
                Directory.CreateDirectory(workdir);
            }

            using (var maskPicture = new Bitmap(scene.PixelSize.Width, scene.PixelSize.Height))
            {
                using (Graphics graphic = Graphics.FromImage(maskPicture))
                {
                    DrawSeceneOids(oIDProject, scene, set, workdir, maskPicture, graphic);
                    DrawStartOids(oIDProject, scene, set, workdir, maskPicture, graphic);
                }


                maskPicture.Save(Path.Combine(destDir, $"{scene.Name}_mask.png"), ImageFormat.Png);
            }
        }

        private static void DrawSeceneOids(OIDProject oIDProject, Scene scene, TTToolSettings set, string workdir, Bitmap maskPicture, Graphics graphic)
        {
            foreach (SceneOid sc in scene.SceneOids)
            {
                var ns = oIDProject.nodeSetups.Where(x => x.Name == sc.SetupName).FirstOrDefault();
                set.CodeDim = new Size(1, 1);
                var res = TTTool.CreateOidCodes(set, (short)ns.OID, workdir);
                var MaskImage = Bitmap.FromFile(res);
                DrawPolygons(maskPicture, graphic, sc, MaskImage);
            }
        }
        private static void DrawStartOids(OIDProject oIDProject, Scene scene, TTToolSettings set, string workdir, Bitmap maskPicture, Graphics graphic)
        {
            if (scene.StartOid != null && scene.StartOid.Polygons != null && scene.StartOid.Polygons.Count > 0)
            {
                set.CodeDim = new Size(1, 1);
                var res = TTTool.CreateOidCodes(set, oIDProject.ProductID, workdir);
                var MaskImage = Bitmap.FromFile(res);
                DrawPolygons(maskPicture, graphic, scene.StartOid, MaskImage);
            }
        }
        
        private static void DrawPolygons(Bitmap maskPicture, Graphics graphic, SceneOid sc, Image MaskImage)
        {
            foreach (Polygon pl in sc.Polygons)
            {
                var r = pl.GetBound();
                float Xs = r.Left;
                float Xe = r.Right;
                float Ys = r.Top;
                float Ye = r.Bottom;

                var width = MaskImage.Width;
                var height = MaskImage.Height;
                for (float x = Xs; x < Xe; x += width)
                {
                    for (float y = Ys; y < Ye; y += height)
                    {
                        int ci = CountEdges(pl, x, y, width, height);
                        if (ci == 4)
                        {
                            graphic.DrawImage(MaskImage, x, y, width, height);
                        }
                        else if (ci > 0)
                        {
                            DrawEdge(pl, (Bitmap)MaskImage, maskPicture, (int)x, (int)y);
                        }
                    }
                }
            }
        }

        public static int CountEdges(Polygon p, float ox, float oy, int width, int height)
        {
            int r = 0;
            if (p.PointInPolygon(ox, oy)) r++;
            if (p.PointInPolygon(ox + width, oy)) r++;
            if (p.PointInPolygon(ox, oy + height)) r++;
            if (p.PointInPolygon(ox + width, oy+height)) r++;
            return r;
        }


        public static void DrawEdge(Polygon p, Bitmap mask, Bitmap dest, int ox, int oy)
        {
            for (int x = 0; x < mask.Width; x++)
            {
                for (int y = 0; y < mask.Height ; y++)
                {
                    if ( p.PointInPolygon(ox+ x, oy+y))
                    {
                        if (ox + x > 0 && ox + x < dest.Width && oy + y > 0 && oy + y < dest.Height )

                        dest.SetPixel(ox + x, oy + y,mask.GetPixel(x, y));
                    }
                }
            }
        }



    }
}