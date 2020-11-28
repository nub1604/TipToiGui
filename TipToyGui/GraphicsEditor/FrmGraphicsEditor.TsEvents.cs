using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.Common;
using TipToyGui.Dialogs;
using TipToyGui.Properties;

namespace TipToyGui
{
    public partial class FrmGraphicsEditor
    {
        private void InitTSEvents()
        {
            tsPolyNewPoint.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.NewVert; ActivateTSEditorMode(PolyEditMode); };
            tsPolyNewPoinInLine.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.NewVertInLine; ActivateTSEditorMode(PolyEditMode); };
            tsPolyMove.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.MoveVertorPoly; ActivateTSEditorMode(PolyEditMode); };
            tsPolyDelete.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.DelVert; ActivateTSEditorMode(PolyEditMode); };

            tsImgMove.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.MoveImage; ActivateTSEditorMode(PolyEditMode); };
            tsImgRotate.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.RotateImage; ActivateTSEditorMode(PolyEditMode); };
            tsImgScale.Click += (_, __) => { PolyEditMode = EnumPolyEditMode.ScaleImage; ActivateTSEditorMode(PolyEditMode); };

            tsAddPoly.Click += AddPoly_Click;
            tsDelPoly.Click += DelPoly_Click;
            tsPlay.Click += Play_Click;

            
        }
        private void AddPoly_Click(object sender, EventArgs e)
        {
            if (selectedSceneOid != null)
            {
                selectedSceneOid.Polygons.Add(new Polygon());
                tsPolygons.Items.Add(selectedSceneOid.Polygons.Last());
                tsPolygons.SelectedItem = selectedSceneOid.Polygons.Last();
                tsPolyNewPoint.PerformClick();
            }
        }

        private void DelPoly_Click(object sender, EventArgs e)
        {
            if (selectedSceneOid == null) return;
            int i = tsPolygons.SelectedIndex;
            if (i > -1 && selectedSceneOid.Polygons.Count > 0)
            {
                
                selectedpolygon = null;
                nearest = Point.Empty;
                selectedSceneOid.Polygons.RemoveAt(i);
              
                Overlay.Refresh();
            }
            if (selectedSceneOid != null)
            {
                tsPolygons.Items.Clear();
                tsPolygons.Items.AddRange(selectedSceneOid.Polygons.ToArray());
            }
        }
        private void Play_Click(object sender, EventArgs e)
        {
            if (!PlayMode)
            {
                if (MainForm.Project != null)
                {
                    MainForm.Project.Save();
                    var file = MainForm.Project.SaveYaml();
                    string ttool = TTGRegistry.Read("tttoolPath");
                    if (File.Exists(file) && File.Exists(ttool))
                    {
                        _PlayTTTool = new PlayTTTool(ttool, $"play {file}");
                        _PlayTTTool.OnRaiseMessageEvent += PlayTTTool_OnRaiseMessageEvent;
                        PlayMode = true;
                        tsPlay.BackgroundImage = global::TipToyGui.Properties.Resources.TipToiStop;
                        var s = GetEmbeddedResourceStream(@"Tip.cur");
                        var c = new Cursor(s);
                        pbDrawSpace.Cursor = c;
                        tsPolyMove.PerformClick();
                        tsImgMove.Enabled = false;
                        tsImgRotate.Enabled = false;
                        tsImgScale.Enabled = false;
                        tsImgMove.BackgroundImage = Resources.i_imgMove;
                        tsImgRotate.BackgroundImage = Resources.i_imgRotate;
                        tsImgScale.BackgroundImage = Resources.i_imgScale;
                    }
                }
            }
            else
            {
                _PlayTTTool?.Dispose();
                PlayMode = false;
                tsPlay.BackgroundImage = Resources.TipToiPlay;
                pbDrawSpace.Cursor = default;

                tsImgMove.Enabled = true;
                tsImgRotate.Enabled = true;
                tsImgScale.Enabled = true;
                tsImgMove.BackgroundImage = Resources.imgMove;
                tsImgRotate.BackgroundImage = Resources.imgRotate;
                tsImgScale.BackgroundImage = Resources.imgScale;
            }
        }

        private void TsGenerateLayer_Click(object sender, EventArgs e)
        {
            if (selectedScene != null && MainForm.Project != null)
            {
                TTToolSettings tTToolSettings = new TTToolSettings();

               
                tTToolSettings.DPI = selectedScene.ResolutionDPI;
                using (var f = new frmImageExport())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        MaskPicture.ExportTTImages(MainForm.Project, selectedScene, tTToolSettings, f.Highquality, f.ExportCanvasImage, f.ExportMask, f.enumNeutral);
                        
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
        void ActivateTSEditorMode(EnumPolyEditMode mode)
        {

            tsImgMove.BackgroundImage = Resources.imgMove;
            tsImgRotate.BackgroundImage = Resources.imgRotate;
            tsImgScale.BackgroundImage = Resources.imgScale;
            tsPolyDelete.BackgroundImage = Resources.DelPoint;
            tsPolyMove.BackgroundImage = Resources.MovPoint;
            tsPolyNewPoinInLine.BackgroundImage = Resources.NewPointInLine;
            tsPolyNewPoint.BackgroundImage = Resources.NewPoint;
            switch (mode)
            {
                case EnumPolyEditMode.DelVert:
                    tsPolyDelete.BackgroundImage = Resources.o_DelPoint;
                    break;
                case EnumPolyEditMode.MoveVertorPoly:
                    tsPolyMove.BackgroundImage = Resources.o_MovPoint;
                    break;
                case EnumPolyEditMode.NewVert:
                    tsPolyNewPoint.BackgroundImage = Resources.o_NewPoint;
                    break;
                case EnumPolyEditMode.NewVertInLine:
                    tsPolyNewPoinInLine.BackgroundImage = Resources.o_NewPointInLine;
                    break;
                case EnumPolyEditMode.MoveImage:
                    tsImgMove.BackgroundImage = Resources.o_imgMove;
                    break;
                case EnumPolyEditMode.ScaleImage:
                    tsImgScale.BackgroundImage = Resources.o_imgScale;
                    break;
                case EnumPolyEditMode.RotateImage:
                    tsImgRotate.BackgroundImage = Resources.o_imgRotate;
                    break;
            }
            Overlay.Refresh();
        }
    }
}