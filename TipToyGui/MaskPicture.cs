using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TipToyGui.Common;
using TipToyGui.Properties;

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

        public static void ExportTTImages(OIDProject oIDProject, Scene scene, TTToolSettings set, bool highquality, bool canvasImage, bool maskimage, EnumNeutralOid enumNeutral)
        {
            if (scene == null || scene.TTImages == null || scene.TTImages.Count == 0) return;

            string destDir = Path.Combine(oIDProject.ProjectPath, "Scenes");
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            if (canvasImage)
            {
                ExportCanvasImage(scene, destDir);
            }

            string workdir = Path.Combine(oIDProject.ProjectPath, "temp");
            if (!Directory.Exists(workdir))
            {
                Directory.CreateDirectory(workdir);
            }
            if (maskimage)
            {
                CreateMaskPicture(oIDProject, scene, set, highquality, destDir, workdir, enumNeutral);
            }
        }

        private static void ExportCanvasImage(Scene scene, string destDir)
        {
            using (var scenePicture = new Bitmap(scene.PixelSize.Width, scene.PixelSize.Height))
            {
                using (Graphics graphic = Graphics.FromImage(scenePicture))
                {
                    foreach (var img in scene.TTImages)
                        img.Draw(graphic, 1);
                }
                scenePicture.Save(Path.Combine(destDir, $"{scene.Name}.png"), ImageFormat.Png);
            }
        }

        private static void CreateNeutralMask(Image image, Scene scene, TTToolSettings set, string workdir)
        {
            var bmp = (set.DPI == 1200 ? Resources.oid_65535_high : Resources.oid_65535_low);

            var allPolygons  = scene.SceneOids.SelectMany(x=>x.Polygons).ToList();
            if (scene.StartOid != null && scene.StartOid.Polygons != null && scene.StartOid.Polygons.Count > 0)
            {
                allPolygons.AddRange(scene.StartOid.Polygons);
            }

            using (Graphics graphic = Graphics.FromImage(image))
            {

                for (float x = 0; x < scene.PixelSize.Width; x += bmp.Width)
                {
                    for (float y = 0; y < scene.PixelSize.Height; y += bmp.Height)
                    {
                        var broadcastPolygon = allPolygons.Where(z => z.GetBound().Contains(x, y));
                        bool  secondPhasehit = false;
                        foreach (Polygon p in broadcastPolygon)
                        {

                            if (p.PointInPolygon(x, y) || p.PointInPolygon(x + bmp.Width, y + bmp.Height) || p.PointInPolygon(x + bmp.Width, y) || p.PointInPolygon(x, y + bmp.Height))
                            {
                                var ci = CountEdges(p, x, y, bmp.Width, bmp.Height, true);
                                if (ci > 0)
                                        DrawEdge(p, (Bitmap)bmp, (Bitmap)image, (int)x, (int)y, true);
                                
                                secondPhasehit = true;
                            }
                        }
                        if (!secondPhasehit)
                        {
                            graphic.DrawImage(bmp, (int)x, (int)y, bmp.Width, bmp.Width);
                        }
                    }
                }
            }
        }


        private static void CreateMaskPicture(OIDProject oIDProject, Scene scene, TTToolSettings set, bool highquality, string destDir, string workdir, EnumNeutralOid enumNeutral)
        {
            using (var maskPicture = new Bitmap(scene.PixelSize.Width, scene.PixelSize.Height))
            {
                using (Graphics graphic = Graphics.FromImage(maskPicture))
                {
                    graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                    if (enumNeutral == EnumNeutralOid.mask)
                    {
                        CreateNeutralMask(maskPicture, scene, set, workdir);
                    }

                    DrawAllOids(oIDProject, scene, set, workdir, maskPicture, graphic, highquality);

                }
                maskPicture.Save(Path.Combine(destDir, $"{scene.Name}_mask.png"), ImageFormat.Png);
            }

            if (enumNeutral == EnumNeutralOid.separate)
            {
                using (var maskPicture = new Bitmap(scene.PixelSize.Width, scene.PixelSize.Height))
                {
                    using (Graphics graphic = Graphics.FromImage(maskPicture))
                    {
                        graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                        CreateNeutralMask(maskPicture, scene, set, workdir);
                    }
                    maskPicture.Save(Path.Combine(destDir, $"{scene.Name}_neutral.png"), ImageFormat.Png);
                }
            }
        }

        private static void DrawAllOids(OIDProject oIDProject, Scene scene, TTToolSettings set, string workdir, Bitmap maskPicture, Graphics graphic, bool highquality)
        {

           var allOids = new List<SceneOid>();
            allOids.AddRange(scene.SceneOids);
            if (scene.StartOid != null && scene.StartOid.Polygons != null && scene.StartOid.Polygons.Count > 0)
            {
                allOids.Add(scene.StartOid);
            }

            foreach (SceneOid sc in allOids)
            {
                var ns = oIDProject.nodeSetups.Where(x => x.Name == sc.SetupName).FirstOrDefault();
                set.CodeDim = new Size(1, 1);
                var res = TTTool.CreateOidCodes(set, (ushort)(ns != null ? ns.OID: oIDProject.ProductID), workdir);
                var MaskImage = Bitmap.FromFile(res);
                DrawPolygons(maskPicture, graphic, sc, MaskImage, highquality);
            }
        }


        private static void DrawPolygons(Bitmap maskPicture, Graphics graphic, SceneOid sc, Image MaskImage, bool highquality)
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
                            if (highquality)

                                DrawFull(pl, (Bitmap)MaskImage, maskPicture, (int)x, (int)y);
                            else
                            {
                               
                                graphic.DrawImage(MaskImage, (int)x, (int)y, width, height);
                            }
                        }
                        else if (ci > 0)
                        {
                            DrawEdge(pl, (Bitmap)MaskImage, maskPicture, (int)x, (int)y);
                        }

                    }
                }
            }
        }

        public static int CountEdges(Polygon p, float ox, float oy, int width, int height, bool invert = false)
        {
            int r = 0;
            if (p.PointInPolygon(ox, oy)^invert) r++;
            if (p.PointInPolygon(ox + width, oy)^ invert) r++;
            if (p.PointInPolygon(ox, oy + height)^ invert) r++;
            if (p.PointInPolygon(ox + width, oy + height)^ invert) r++;
            return r;
        }


        public static void DrawEdge(Polygon p, Bitmap mask, Bitmap dest, int ox, int oy, bool invert = false)
        {
            for (int x = 0; x < mask.Width; x++)
            {
                for (int y = 0; y < mask.Height; y++)
                {
                    if (p.PointInPolygon(ox + x, oy + y) ^ invert)
                    {
                        if (ox + x > 0 && ox + x < dest.Width && oy + y > 0 && oy + y < dest.Height)

                            dest.SetPixel(ox + x, oy + y, mask.GetPixel(x, y));
                    }
                }
            }
        }

        public static void DrawFull(Polygon p, Bitmap mask, Bitmap dest, int ox, int oy)
        {
        
            for (int x = 0; x < mask.Width; x++)
            {
                for (int y = 0; y < mask.Height; y++)
                {

                    if (ox + x > 0 && ox + x < dest.Width && oy + y > 0 && oy + y < dest.Height)

                        dest.SetPixel(ox + x, oy + y, mask.GetPixel(x, y));

                }
            }
        }
        public enum EnumNeutralOid
        {
            none,
            mask,
            separate
        }
    }
}