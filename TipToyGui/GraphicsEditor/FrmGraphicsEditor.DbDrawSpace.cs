using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.Common;

namespace TipToyGui
{
    public partial class FrmGraphicsEditor
    {
        private void InitPbDrawSpace()
        {
            pbDrawSpace.MouseUp += (_, e) =>
            {
                MouseImgModifyStartLocation = PointF.Empty;
            };
            pbDrawSpace.MouseMove += PbDrawSpace_MouseMove;
            pbDrawSpace.MouseDown += PbDrawSpace_MouseDown;
            pbDrawSpace.MouseWheel += PbDrawSpace_MouseWheel;

            pbDrawSpace.Resize += (_, __) =>
            {
                pbDrawSpace.Invalidate();
            };
        }

        private void PbDrawSpace_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)

                if (e.Delta > 0)
                {

                    Percent = Math.Min(Percent + 0.1f, 1f);
                    pbDrawSpace.Size = selectedScene.PixelSizeZoomed(Percent);
                    Overlay.Refresh();

                }
                else if (e.Delta < 0)
                {
                    float min = (panel1.Width-26f) / (float)selectedScene.PixelSize.Width;
                    Percent = Math.Max(Percent - 0.1f, min);
                    pbDrawSpace.Size = selectedScene.PixelSizeZoomed(Percent);
                    Overlay.Refresh();
                }
        }

        private void PbDrawSpace_MouseMove(object sender, MouseEventArgs e)
        {
            pbDrawSpace.Focus();

            if (selectedpolygon != null && PolyEditMode.ToString().Contains("Vert"))
            {
                PointF pointA = Point.Empty;

                if (PolyEditMode != EnumPolyEditMode.NewVertInLine)
                {
                    pointA = selectedpolygon.Vertices.FindClosest(e.Location.ReCalcInvertZoom(Percent));
                }
                else
                {
                    var arr = selectedpolygon.Vertices;
                    var src = arr.FindClosest(e.Location.ReCalcInvertZoom(Percent));
                    var res = arr.GetNeighbors(src).FindClosest(e.Location.ReCalcInvertZoom(Percent));
                    if (res != Point.Empty)
                    {
                        Line = new PointF[] { src, res };
                    }
                    else
                    {
                        Line = null;
                    }
                    Overlay.Refresh();
                }

                if (PolyEditMode == EnumPolyEditMode.MoveVertorPoly && e.Button == MouseButtons.Left)
                {
                    if (ModifierKeys == Keys.Shift)
                    {
                        selectedpolygon.MovePolygon(e.Location.ReCalcInvertZoom(Percent));
                    }
                    else
                    {
                        selectedpolygon.MoveVert(e.Location.ReCalcInvertZoom(Percent));
                    }
                    Overlay.Refresh();
                }

                if (pointA != nearest)
                {
                    nearest = pointA;
                    Overlay.Refresh();
                }
            }
            else if (selectedImage != null && PolyEditMode.ToString().Contains("Image") && MouseImgModifyStartLocation != PointF.Empty)
            {
                ModifyImage(e);
            }

            tslblMouseReal.Text = $"MouseCoord {e.Location}";
            tslblMouseWorld.Text = $"WorldSpace {e.Location.ReCalcInvertZoom(Percent)}";
        }

        private void PbDrawSpace_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedScene != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (PolyEditMode.ToString().Contains("Vert"))
                    {
                        SelectPolygon(e);
                    }
                    else if (PolyEditMode.ToString().Contains("Image"))
                    {
                        SelectedImage(e);
                        if (selectedImage != null)
                            tslblState.Text = $"Center SelectedImage: {selectedImage.Middle(Percent)}";
                    }
                }
                else
                {
                    if (PolyEditMode.ToString().Contains("Vert"))
                    {
                        if (selectedpolygon != null)
                            ModifyPolygon(e);
                    }
                    else if (PolyEditMode.ToString().Contains("Image"))
                    {
                        MouseImgModifyStartLocation = e.Location;
                        if (selectedImage != null)
                        {
                            MouseImgModifyInitialScale = selectedImage.TTScale;
                            MouseImgModifyInitialCenter = selectedImage.Middle(Percent);
                            MouseMoveInitImageLocation = selectedImage.TTLocation;
                            MouseImgModifyStartOffset = MouseImgModifyStartLocation.ReCalcInvertZoom(Percent).Sub(MouseMoveInitImageLocation);
                            MouseMoveInitLength = MouseImgModifyStartOffset.ReCalcInvertZoom(Percent).Length(MouseMoveInitImageLocation);
                        }
                    }
                }
            }
        }

        private void ModifyImage(MouseEventArgs e)
        {
            switch (PolyEditMode)
            {
                case  EnumPolyEditMode.MoveImage:
                    tslblState.Text = $"Center SelectedImage: {MouseImgModifyStartOffset}";
                    selectedImage.TTLocation = e.Location.ReCalcInvertZoom(Percent).Sub(MouseImgModifyStartOffset);
                    Overlay.Refresh();

                    break;

                case EnumPolyEditMode.RotateImage:

                    tslblState.Text = $"Center SelectedImage: {MouseImgModifyInitialCenter}";
                    var s3 = e.Location;
                    var dir = MouseImgModifyInitialCenter.Sub(s3);
                    var r = -Math.Atan2(dir.X, dir.Y) * 180 / Math.PI;
                    //Console.WriteLine($"r {r} ");
                    selectedImage.TTRotation = (float)r;
                    Overlay.Refresh();
                    break;

                case EnumPolyEditMode.ScaleImage:
                    //tslblState.Text = $"Center SelectedImage: {MouseImgModifyInitialCenter}";
                    var init = MouseMoveInitImageLocation;
                    var offset = MouseImgModifyStartOffset;
                    var oldscale = MouseImgModifyInitialScale;
                    var L1 = init.Length(offset);
                    var L2 = init.Length(e.Location.ReCalcInvertZoom(Percent).Sub(init));
                    var Lres = (L2 - L1) / 1000;
                    tslblState.Text = $"Scale: {MouseImgModifyInitialScale + Lres}";

                    selectedImage.TTScale = oldscale + Lres;

                    Overlay.Refresh();

                    break;
            }
        }

        private void SelectedImage(MouseEventArgs e)
        {
            foreach (var image in Enumerable.Reverse(selectedScene.TTImages))
            {
                if (image.Contains(e.Location, Percent))
                {
                    lbTTImages.SelectedItem = image;

                    return;
                }
            }
        }

        private void ModifyPolygon(MouseEventArgs e)
        {
            if (PolyEditMode == EnumPolyEditMode.NewVert) selectedpolygon.AddVert(e.Location.ReCalcInvertZoom(Percent));
            if (PolyEditMode == EnumPolyEditMode.NewVertInLine)
            {
                if (Line != null && Line.Length == 2)
                {
                    selectedpolygon.AddVert(Line[0], Line[1]);
                }
            }
            if (PolyEditMode == EnumPolyEditMode.DelVert && nearest != Point.Empty) selectedpolygon.DelVert(nearest);
            if (PolyEditMode == EnumPolyEditMode.MoveVertorPoly && nearest != Point.Empty && e.Button == MouseButtons.Left) selectedpolygon.SelectIndex(nearest);
        }

        private void SelectPolygon(MouseEventArgs e)
        {
            if(selectedScene.StartOid != null)
            foreach (var polygon in from polygon in selectedScene.StartOid.Polygons
                                    where polygon.PointInPolygon(e.Location.ReCalcInvertZoom(Percent))
                                    select (polygon))
            {
                lbOids.SelectedIndex = -1;

                tsPolygons.Items.Clear();
                tsPolygons.Items.AddRange(selectedScene.StartOid.Polygons.ToArray());
                tsPolygons.SelectedItem = polygon;
                selectedpolygon = polygon;
                Console.WriteLine(selectedScene.StartOid.SetupName);
                Overlay.Refresh();
                if (PlayMode && _PlayTTTool != null)
                {
                        tbTTToolLog.Text += MainForm.Project.ProductID;
                }
                    selectedSceneOid = selectedScene.StartOid;
                return;
            }

            foreach (var (oid, polygon) in from oid in selectedScene.SceneOids
                                           from polygon in oid.Polygons
                                           where polygon.PointInPolygon(e.Location.ReCalcInvertZoom(Percent))
                                           select (oid, polygon))
            {
                lbOids.SelectedIndex = lbOids.FindString(oid.SetupName);
                tsPolygons.Items.Clear();
                tsPolygons.Items.AddRange(selectedSceneOid.Polygons.ToArray());
                tsPolygons.SelectedIndex = oid.Polygons.IndexOf(polygon);
                Console.WriteLine(oid.SetupName);
                Overlay.Refresh();
                if (PlayMode && _PlayTTTool != null)
                {
                    _PlayTTTool.Write($"o_{oid.SetupName}");
                }

                return;
            }
        }
    }
}