using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.Common;
using TipToyGui.Dialogs;

namespace TipToyGui
{
    public partial class FrmGraphicsEditor : TTDialog
    {
        private GraphicalOverlay Overlay;

        private PointF nearest;
        private PointF[] Line;

        private PointF MouseImgModifyStartLocation;
        private PointF MouseImgModifyStartOffset;
        private PointF MouseImgModifyInitialCenter;
        private PointF MouseMoveInitImageLocation;
        private float MouseMoveInitLength;

        private float MouseImgModifyInitialScale;

        private float Percent = 1;

        private Pen smallPen = new Pen(Color.Orange, 3);
        private Pen smallPenT = new Pen(Color.FromArgb(99, Color.Orange), 2);
        private Pen selectedPen = new Pen(Color.Green, 4);
        private Pen selectedPenT = new Pen(Color.FromArgb(99, Color.Green), 3);

        private Scene selectedScene;
        private SceneOid selectedSceneOid;
        private Polygon selectedpolygon;
        private TTImage selectedImage;

        private bool PlayMode = false;

        private PlayTTTool _PlayTTTool;
        private EnumPolyEditMode PolyEditMode;

        public FrmGraphicsEditor()
        {
            InitializeComponent();
            PolyEditMode = EnumPolyEditMode.MoveImage;
 
    

            Overlay = new GraphicalOverlay() { Owner = pbDrawSpace };

            Overlay.Paint += Overlay_Paint;
            InitTSEvents();
            InitPbDrawSpace();

            btnNewTTImage.Click += BtnTTImageNew_Click;
            btnDelTTImage.Click += (_, __) => { if (lbTTImages.SelectedItem != null) { selectedScene.TTImages.RemoveAt(lbTTImages.SelectedIndex); RefreshTTImages(); Overlay.Refresh(); } };
            btnMoveUpTTImage.Click += (_, __) => { if (lbTTImages.SelectedIndex > 0) { SwapImages(lbTTImages.SelectedIndex, lbTTImages.SelectedIndex - 1); RefreshTTImages(); Overlay.Refresh(); } };
            btnMoveDownTTImage.Click += (_, __) => { if (lbTTImages.SelectedIndex < lbTTImages.Items.Count - 1) { SwapImages(lbTTImages.SelectedIndex, lbTTImages.SelectedIndex + 1); RefreshTTImages(); Overlay.Refresh(); } };

            var SceneContext = new ContextMenu();
            SceneContext.MenuItems.Add("New", (_, __) =>
            {
                if (MainForm.Project == null) return;
                using (var f = new frmScene(MainForm.Project.Scenes.ToArray()))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        MainForm.Project.Scenes.Add(f.Result);
                        RefreshScenes();
                        lbScenes.SelectedIndex = lbScenes.Items.Count - 1;
                    }
                }
            });
            SceneContext.MenuItems.Add("Edit", (_, __) =>
            {
                if (MainForm.Project == null || lbScenes.SelectedItem == null) return;

                using (var f = new frmScene(MainForm.Project.Scenes.ToArray(), MainForm.Project.Scenes[lbScenes.SelectedIndex]))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        var s = MainForm.Project.Scenes[lbScenes.SelectedIndex];
                        s.Name = f.Result.Name;
                        s.ResolutionDPI = f.Result.ResolutionDPI;
                        s.CanvasSize = f.Result.CanvasSize;

                        RefreshScenes();
                    }
                }
            });
            lbScenes.ContextMenu = SceneContext;

            lbOids.SelectedIndexChanged += LbOids_SelectedIndexChanged;
            lbScenes.SelectedIndexChanged += LB_Scenes_SelectedIndexChanged;
            tsPolygons.SelectedIndexChanged += (_, __) =>
            {
                if (selectedSceneOid != null)
                {
                    int i = tsPolygons.SelectedIndex;
                    if (i > -1 && selectedSceneOid.Polygons.Count > 0)
                    {
                        selectedpolygon = selectedSceneOid.Polygons[i];
                        Overlay.Refresh();
                    }
                }
            };

            btnOnSwitchOid.Click += (_, __) =>
            {
                if (selectedScene == null) return;

                lbOids.SelectedIndex = -1;
                tsPolygons.Items.Clear();


                if (selectedScene.StartOid == null)
                {
                    selectedScene.StartOid = new SceneOid("os_start");
                    selectedSceneOid = selectedScene.StartOid;

                }
                if (selectedScene.StartOid.Polygons == null || selectedScene.StartOid.Polygons.Count == 0)
                {
                    selectedSceneOid = selectedScene.StartOid;
                    tsAddPoly.PerformClick();
                }
                selectedSceneOid = selectedScene.StartOid;

               
                tsPolygons.Items.AddRange(selectedSceneOid.Polygons.ToArray());
                if (tsPolygons.Items.Count > 0) tsPolygons.SelectedIndex = 0;
            };

            RefreshScenes();
            RefreshNodes();
            tsImgMove.PerformClick();
        }

        private void SwapImages(int i1, int i2)
        {
            if (selectedScene != null && selectedScene.TTImages != null)
            {
                var temp = selectedScene.TTImages[i1];
                selectedScene.TTImages[i1] = selectedScene.TTImages[i2];
                selectedScene.TTImages[i2] = temp;
            }
        }

        private void LB_Scenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbScenes.SelectedItem != null)
            {
                selectedScene = MainForm.Project.Scenes.Where(x => x.Name == lbScenes.SelectedItem.ToString()).FirstOrDefault();
                RefreshTTImages();

                float min = (panel1.Width - 26f) / (float)selectedScene.PixelSize.Width;
                Percent =  min;
                pbDrawSpace.Size = selectedScene.PixelSizeZoomed(Percent);
                Overlay.Refresh();
         
            }
        }

        private void LbOids_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbOids.SelectedItem != null && selectedScene != null)
            {
                selectedSceneOid = selectedScene.SceneOids.Where(x => x.SetupName == lbOids.SelectedItem.ToString()).FirstOrDefault();
                if (selectedSceneOid == null)
                {
                    var nso = new SceneOid(lbOids.SelectedItem.ToString());
                    selectedScene.SceneOids.Add(nso);
                    selectedSceneOid = nso;
                }
                if (selectedSceneOid.Polygons == null) selectedSceneOid.Polygons = new List<Polygon>();

                selectedpolygon = selectedSceneOid.Polygons.FirstOrDefault();
                if (selectedpolygon == null)
                {
                    var p = new Polygon();
                    selectedSceneOid.Polygons.Add(p);
                    selectedpolygon = p;
                }
                tsPolygons.Items.Clear();
                tsPolygons.Items.AddRange(selectedSceneOid.Polygons.ToArray());
                if (tsPolygons.Items.Count > 0) tsPolygons.SelectedIndex = 0;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.D1)
            {
                tsPolyNewPoint.PerformClick();
            }
            if (keyData == Keys.D2)
            {
                tsPolyNewPoinInLine.PerformClick();
            }
            if (keyData == Keys.D3)
            {
                tsPolyMove.PerformClick();
            }
            if (keyData == Keys.D4 || keyData == Keys.Delete)
            {
                tsPolyDelete.PerformClick();
            }
            if (keyData == Keys.D5)
            {
                tsImgMove.PerformClick();
            }
            if (keyData == Keys.D6)
            {
                tsImgRotate.PerformClick();
            }
            if (keyData == Keys.D7)
            {
                tsImgScale.PerformClick();
            }



            if (keyData == (Keys.OemMinus))
            {
                float min = (panel1.Width - 26f) / (float)selectedScene.PixelSize.Width;
                Percent = Math.Max(Percent - 0.1f, min);
                pbDrawSpace.Size = selectedScene.PixelSizeZoomed(Percent);
                Overlay.Refresh();
            }
            if (keyData == (Keys.Oemplus))
            {
                Percent = Math.Min(Percent + 0.1f, 1f);
                pbDrawSpace.Size = selectedScene.PixelSizeZoomed(Percent);
                Overlay.Refresh();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshScenes()
        {
            if (MainForm.Project != null)
            {
                int selectedIndex = lbScenes.SelectedIndex;
                lbScenes.Items.Clear();
                foreach (var reg in MainForm.Project.Scenes)
                {
                    lbScenes.Items.Add(reg);
                }

                if (selectedIndex != -1)
                {
                    lbScenes.SelectedIndex = selectedIndex;
                }
                else
                {
                    if (lbScenes.Items.Count > 0)
                    {
                        lbScenes.SelectedIndex = 0;

                        pbDrawSpace.Size = selectedScene.PixelSizeZoomed(Percent);
                    }
                }
                RefreshTTImages();
            }
        }

        private void RefreshTTImages()
        {
            lbTTImages.Items.Clear();
            if (selectedScene != null)
            {
                foreach (var ttimg in selectedScene.TTImages)
                {
                    lbTTImages.Items.Add(ttimg);
                }
            }
        }

        private void RefreshNodes()
        {
            if (MainForm.Project != null)
            {
                int selectedIndex = lbOids.SelectedIndex;
                lbOids.Items.Clear();
                foreach (var reg in MainForm.Project.nodeSetups)
                {
                    lbOids.Items.Add(reg);
                }
                lbOids.SelectedIndex = selectedIndex;
            }
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            if (selectedScene == null) return;

            if (selectedScene.TTImages == null) selectedScene.TTImages = new System.Collections.Generic.List<TTImage>();

            foreach (var item in selectedScene.TTImages)
            {
                item.Draw(e.Graphics, Percent);
            }

            foreach (var sceneoid in selectedScene.SceneOids)
            {
                foreach (var polygon in sceneoid.Polygons)
                {
                    DrawPolygon(e, polygon);
                }
            }
            if (selectedScene.StartOid != null)
            {
                foreach (var polygon in selectedScene.StartOid.Polygons)
                {
                    DrawPolygon(e, polygon);
                }
            }

            if (PolyEditMode != EnumPolyEditMode.NewVertInLine)
            {
                if (nearest != Point.Empty)
                {
                    PointF v = nearest;
                    e.Graphics.DrawRectangle(PolyEditMode.ToString().Contains("Image")  ? smallPenT: smallPen, RectangleF.FromLTRB(v.X - 4, v.Y - 4, v.X + 4, v.Y + 4).ReCalcZoom(Percent).ToR());
                }
            }
            else
            {
                if (Line != null && Line.Length == 2)
                {
                    e.Graphics.DrawLine(PolyEditMode.ToString().Contains("Image") ? smallPenT : smallPen, Line[0].ReCalcZoom(Percent), Line[1].ReCalcZoom(Percent));
                }
            }

            if (PolyEditMode.ToString().Contains("Image"))
            {
                if (selectedImage != null)
                {
                    selectedImage.DrawBorder(e.Graphics, Percent);
                }
            }
        }

        private void DrawPolygon(PaintEventArgs e, Polygon polygon)
        {
            if (polygon.Vertices.Length > 1)
                if (polygon == selectedpolygon)
                {
                    e.Graphics.DrawPolygon(PolyEditMode.ToString().Contains("Image") ? selectedPenT : selectedPen, polygon.Vertices.ReCalcZoom(Percent));
                }
                else
                {
                    e.Graphics.DrawPolygon(PolyEditMode.ToString().Contains("Image") ? smallPenT : smallPen, polygon.Vertices.ReCalcZoom(Percent));
                }
            foreach (var v in polygon.Vertices)
            {
                e.Graphics.DrawRectangle(PolyEditMode.ToString().Contains("Image") ? smallPenT : smallPen, RectangleF.FromLTRB(v.X - 2, v.Y - 2, v.X + 2, v.Y + 2).ReCalcZoom(Percent).ToR());
            }
        }

        private void BtnTTImageNew_Click(object sender, EventArgs e)
        {
            if (MainForm.Project != null && selectedScene != null)
            {
                using (var ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Image bitmap = Image.FromFile(ofd.FileName);
                            selectedScene.TTImages.Add(new TTImage(ofd.FileName));
                            lbTTImages.Items.Add(selectedScene.TTImages.Last());
                            Overlay.Refresh();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void PlayTTTool_OnRaiseMessageEvent(object sender, Nodes.BaseNode.MessageEventArgs e)
        {
            if (IsHandleCreated)
            {
                try
                {
                    Invoke((Action)(() =>
                    {
                        tbTTToolLog.Text += (e.Message);
                    }));
                }
                catch
                { }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _PlayTTTool?.Dispose();
            base.OnClosing(e);
        }

        private enum EnumPolyEditMode
        {
            NewVert, NewVertInLine, MoveVertorPoly, DelVert, ScaleImage, MoveImage, RotateImage
        }

        public Stream GetEmbeddedResourceStream(string resourceName)
        {
            return GetType().Assembly.GetManifestResourceStream(GetType().Assembly.GetManifestResourceNames().Where(x => x.Contains(resourceName)).FirstOrDefault());
        }

        public Image PictureBoxZoom(Image img, float percent)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * percent), Convert.ToInt32(img.Height * percent));
            Graphics grap = Graphics.FromImage(bm);
            grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bm;
        }

        private void lbTTImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedScene == null || selectedScene.TTImages == null) return;
            if (lbTTImages.SelectedItem != null)
            {
                selectedImage = selectedScene.TTImages[lbTTImages.SelectedIndex];

                Overlay.Refresh();
            }
        }
    }
}