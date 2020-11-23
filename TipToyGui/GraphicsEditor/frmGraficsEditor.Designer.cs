

namespace TipToyGui
{
    partial class FrmGraphicsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTTToolLog = new System.Windows.Forms.TextBox();
            this.panel1 = new TipToyGui.CustomControls.GfxPanel();
            this.pbDrawSpace = new System.Windows.Forms.PictureBox();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOnSwitchOid = new System.Windows.Forms.Button();
            this.lbOids = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbScenes = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsPolyNewPoint = new System.Windows.Forms.ToolStripButton();
            this.tsPolyNewPoinInLine = new System.Windows.Forms.ToolStripButton();
            this.tsPolyMove = new System.Windows.Forms.ToolStripButton();
            this.tsPolyDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsImgMove = new System.Windows.Forms.ToolStripButton();
            this.tsImgRotate = new System.Windows.Forms.ToolStripButton();
            this.tsImgScale = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsPolygons = new System.Windows.Forms.ToolStripComboBox();
            this.tsDelPoly = new System.Windows.Forms.ToolStripButton();
            this.tsAddPoly = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPlay = new System.Windows.Forms.ToolStripButton();
            this.TsGenerateLayer = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbTTImages = new System.Windows.Forms.ListBox();
            this.btnDelTTImage = new System.Windows.Forms.Button();
            this.btnMoveDownTTImage = new System.Windows.Forms.Button();
            this.btnMoveUpTTImage = new System.Windows.Forms.Button();
            this.btnNewTTImage = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblMouseReal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblMouseWorld = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawSpace)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTTToolLog
            // 
            this.tbTTToolLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTTToolLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tbTTToolLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTTToolLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbTTToolLog.Location = new System.Drawing.Point(3, 16);
            this.tbTTToolLog.Multiline = true;
            this.tbTTToolLog.Name = "tbTTToolLog";
            this.tbTTToolLog.ReadOnly = true;
            this.tbTTToolLog.Size = new System.Drawing.Size(712, 94);
            this.tbTTToolLog.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbDrawSpace);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 694);
            this.panel1.TabIndex = 13;
            // 
            // pbDrawSpace
            // 
            this.pbDrawSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pbDrawSpace.Location = new System.Drawing.Point(3, 3);
            this.pbDrawSpace.Name = "pbDrawSpace";
            this.pbDrawSpace.Size = new System.Drawing.Size(749, 431);
            this.pbDrawSpace.TabIndex = 1;
            this.pbDrawSpace.TabStop = false;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 175);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(150, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(150, 25);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightToolStripPanel.Location = new System.Drawing.Point(150, 25);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 150);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 25);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 150);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(175, 205);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOnSwitchOid);
            this.groupBox2.Controls.Add(this.lbOids);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 281);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OID Codes";
            // 
            // btnOnSwitchOid
            // 
            this.btnOnSwitchOid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnSwitchOid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOnSwitchOid.Location = new System.Drawing.Point(6, 19);
            this.btnOnSwitchOid.Name = "btnOnSwitchOid";
            this.btnOnSwitchOid.Size = new System.Drawing.Size(193, 23);
            this.btnOnSwitchOid.TabIndex = 4;
            this.btnOnSwitchOid.Text = "Select Start Oid";
            this.btnOnSwitchOid.UseVisualStyleBackColor = true;
            // 
            // lbOids
            // 
            this.lbOids.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbOids.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbOids.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbOids.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbOids.FormattingEnabled = true;
            this.lbOids.Location = new System.Drawing.Point(3, 57);
            this.lbOids.Name = "lbOids";
            this.lbOids.Size = new System.Drawing.Size(199, 221);
            this.lbOids.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbScenes);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 191);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scenes";
            // 
            // lbScenes
            // 
            this.lbScenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbScenes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbScenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScenes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbScenes.FormattingEnabled = true;
            this.lbScenes.Location = new System.Drawing.Point(3, 16);
            this.lbScenes.Name = "lbScenes";
            this.lbScenes.Size = new System.Drawing.Size(199, 172);
            this.lbScenes.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbTTToolLog);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(721, 144);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "tttool Log";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPolyNewPoint,
            this.tsPolyNewPoinInLine,
            this.tsPolyMove,
            this.tsPolyDelete,
            this.toolStripSeparator1,
            this.tsImgMove,
            this.tsImgRotate,
            this.tsImgScale,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.tsPolygons,
            this.tsDelPoly,
            this.tsAddPoly,
            this.toolStripSeparator3,
            this.tsPlay,
            this.TsGenerateLayer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1394, 36);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsPolyNewPoint
            // 
            this.tsPolyNewPoint.AutoSize = false;
            this.tsPolyNewPoint.BackgroundImage = global::TipToyGui.Properties.Resources.NewPoint;
            this.tsPolyNewPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsPolyNewPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsPolyNewPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPolyNewPoint.Margin = new System.Windows.Forms.Padding(2);
            this.tsPolyNewPoint.Name = "tsPolyNewPoint";
            this.tsPolyNewPoint.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsPolyNewPoint.Size = new System.Drawing.Size(32, 32);
            this.tsPolyNewPoint.Tag = "1";
            this.tsPolyNewPoint.ToolTipText = "Add point";
            // 
            // tsPolyNewPoinInLine
            // 
            this.tsPolyNewPoinInLine.AutoSize = false;
            this.tsPolyNewPoinInLine.BackgroundImage = global::TipToyGui.Properties.Resources.NewPointInLine;
            this.tsPolyNewPoinInLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsPolyNewPoinInLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPolyNewPoinInLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPolyNewPoinInLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPolyNewPoinInLine.Margin = new System.Windows.Forms.Padding(2);
            this.tsPolyNewPoinInLine.Name = "tsPolyNewPoinInLine";
            this.tsPolyNewPoinInLine.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsPolyNewPoinInLine.Size = new System.Drawing.Size(32, 32);
            this.tsPolyNewPoinInLine.Tag = "2";
            this.tsPolyNewPoinInLine.Text = "toolStripButton4";
            this.tsPolyNewPoinInLine.ToolTipText = "Add point in line";
            // 
            // tsPolyMove
            // 
            this.tsPolyMove.AutoSize = false;
            this.tsPolyMove.BackgroundImage = global::TipToyGui.Properties.Resources.MovPoint;
            this.tsPolyMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsPolyMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsPolyMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPolyMove.Margin = new System.Windows.Forms.Padding(2);
            this.tsPolyMove.Name = "tsPolyMove";
            this.tsPolyMove.Size = new System.Drawing.Size(32, 32);
            this.tsPolyMove.Tag = "3";
            this.tsPolyMove.ToolTipText = "Move Vertice";
            // 
            // tsPolyDelete
            // 
            this.tsPolyDelete.AutoSize = false;
            this.tsPolyDelete.BackgroundImage = global::TipToyGui.Properties.Resources.DelPoint;
            this.tsPolyDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsPolyDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsPolyDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPolyDelete.Margin = new System.Windows.Forms.Padding(2);
            this.tsPolyDelete.Name = "tsPolyDelete";
            this.tsPolyDelete.Size = new System.Drawing.Size(32, 32);
            this.tsPolyDelete.Tag = "4";
            this.tsPolyDelete.ToolTipText = "Delete Vertice";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // tsImgMove
            // 
            this.tsImgMove.AutoSize = false;
            this.tsImgMove.BackgroundImage = global::TipToyGui.Properties.Resources.imgMove;
            this.tsImgMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsImgMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsImgMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImgMove.Name = "tsImgMove";
            this.tsImgMove.Size = new System.Drawing.Size(32, 32);
            this.tsImgMove.Tag = "5";
            this.tsImgMove.ToolTipText = "Move Image";
            // 
            // tsImgRotate
            // 
            this.tsImgRotate.AutoSize = false;
            this.tsImgRotate.BackgroundImage = global::TipToyGui.Properties.Resources.imgRotate;
            this.tsImgRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsImgRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImgRotate.Name = "tsImgRotate";
            this.tsImgRotate.Size = new System.Drawing.Size(32, 32);
            this.tsImgRotate.Tag = "6";
            this.tsImgRotate.ToolTipText = "Rotate Image";
            // 
            // tsImgScale
            // 
            this.tsImgScale.AutoSize = false;
            this.tsImgScale.BackgroundImage = global::TipToyGui.Properties.Resources.imgScale;
            this.tsImgScale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsImgScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsImgScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsImgScale.Name = "tsImgScale";
            this.tsImgScale.Size = new System.Drawing.Size(32, 32);
            this.tsImgScale.Tag = "7";
            this.tsImgScale.ToolTipText = "Scale Image";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 33);
            this.toolStripLabel1.Text = "Select OId";
            // 
            // tsPolygons
            // 
            this.tsPolygons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsPolygons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsPolygons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tsPolygons.Name = "tsPolygons";
            this.tsPolygons.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsPolygons.Size = new System.Drawing.Size(121, 36);
            // 
            // tsDelPoly
            // 
            this.tsDelPoly.AutoSize = false;
            this.tsDelPoly.AutoToolTip = false;
            this.tsDelPoly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDelPoly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelPoly.Name = "tsDelPoly";
            this.tsDelPoly.Size = new System.Drawing.Size(32, 32);
            this.tsDelPoly.Text = "-";
            // 
            // tsAddPoly
            // 
            this.tsAddPoly.AutoSize = false;
            this.tsAddPoly.AutoToolTip = false;
            this.tsAddPoly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsAddPoly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddPoly.Name = "tsAddPoly";
            this.tsAddPoly.Size = new System.Drawing.Size(32, 32);
            this.tsAddPoly.Text = "+";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // tsPlay
            // 
            this.tsPlay.AutoSize = false;
            this.tsPlay.AutoToolTip = false;
            this.tsPlay.BackgroundImage = global::TipToyGui.Properties.Resources.TipToiPlay;
            this.tsPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPlay.Name = "tsPlay";
            this.tsPlay.Size = new System.Drawing.Size(32, 32);
            this.tsPlay.Text = "toolStripButton1";
            // 
            // TsGenerateLayer
            // 
            this.TsGenerateLayer.AutoSize = false;
            this.TsGenerateLayer.BackgroundImage = global::TipToyGui.Properties.Resources.sceneSave;
            this.TsGenerateLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsGenerateLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsGenerateLayer.Name = "TsGenerateLayer";
            this.TsGenerateLayer.Size = new System.Drawing.Size(32, 32);
            this.TsGenerateLayer.Text = "toolStripButton1";
            this.TsGenerateLayer.Click += new System.EventHandler(this.TsGenerateLayer_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1394, 842);
            this.splitContainer1.SplitterDistance = 1185;
            this.splitContainer1.TabIndex = 16;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Size = new System.Drawing.Size(1185, 842);
            this.splitContainer4.SplitterDistance = 694;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(205, 842);
            this.splitContainer2.SplitterDistance = 191;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lbTTImages);
            this.splitContainer3.Panel2.Controls.Add(this.btnDelTTImage);
            this.splitContainer3.Panel2.Controls.Add(this.btnMoveDownTTImage);
            this.splitContainer3.Panel2.Controls.Add(this.btnMoveUpTTImage);
            this.splitContainer3.Panel2.Controls.Add(this.btnNewTTImage);
            this.splitContainer3.Size = new System.Drawing.Size(205, 647);
            this.splitContainer3.SplitterDistance = 281;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbTTImages
            // 
            this.lbTTImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTTImages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lbTTImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbTTImages.FormattingEnabled = true;
            this.lbTTImages.Location = new System.Drawing.Point(5, 17);
            this.lbTTImages.Name = "lbTTImages";
            this.lbTTImages.Size = new System.Drawing.Size(158, 303);
            this.lbTTImages.TabIndex = 5;
            this.lbTTImages.SelectedIndexChanged += new System.EventHandler(this.lbTTImages_SelectedIndexChanged);
            // 
            // btnDelTTImage
            // 
            this.btnDelTTImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelTTImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelTTImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelTTImage.Location = new System.Drawing.Point(170, 104);
            this.btnDelTTImage.Name = "btnDelTTImage";
            this.btnDelTTImage.Size = new System.Drawing.Size(23, 23);
            this.btnDelTTImage.TabIndex = 4;
            this.btnDelTTImage.Text = "-";
            this.btnDelTTImage.UseVisualStyleBackColor = true;
            // 
            // btnMoveDownTTImage
            // 
            this.btnMoveDownTTImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDownTTImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDownTTImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMoveDownTTImage.Location = new System.Drawing.Point(170, 75);
            this.btnMoveDownTTImage.Name = "btnMoveDownTTImage";
            this.btnMoveDownTTImage.Size = new System.Drawing.Size(23, 23);
            this.btnMoveDownTTImage.TabIndex = 4;
            this.btnMoveDownTTImage.Text = "↓";
            this.btnMoveDownTTImage.UseVisualStyleBackColor = true;
            // 
            // btnMoveUpTTImage
            // 
            this.btnMoveUpTTImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUpTTImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUpTTImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMoveUpTTImage.Location = new System.Drawing.Point(170, 46);
            this.btnMoveUpTTImage.Name = "btnMoveUpTTImage";
            this.btnMoveUpTTImage.Size = new System.Drawing.Size(23, 23);
            this.btnMoveUpTTImage.TabIndex = 4;
            this.btnMoveUpTTImage.Text = "↑";
            this.btnMoveUpTTImage.UseVisualStyleBackColor = true;
            // 
            // btnNewTTImage
            // 
            this.btnNewTTImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTTImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTTImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNewTTImage.Location = new System.Drawing.Point(170, 17);
            this.btnNewTTImage.Name = "btnNewTTImage";
            this.btnNewTTImage.Size = new System.Drawing.Size(23, 23);
            this.btnNewTTImage.TabIndex = 4;
            this.btnNewTTImage.Text = "+";
            this.btnNewTTImage.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblMouseReal,
            this.tslblMouseWorld,
            this.tslblState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 856);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1394, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblMouseReal
            // 
            this.tslblMouseReal.Name = "tslblMouseReal";
            this.tslblMouseReal.Size = new System.Drawing.Size(0, 17);
            // 
            // tslblMouseWorld
            // 
            this.tslblMouseWorld.Name = "tslblMouseWorld";
            this.tslblMouseWorld.Size = new System.Drawing.Size(0, 17);
            // 
            // tslblState
            // 
            this.tslblState.Name = "tslblState";
            this.tslblState.Size = new System.Drawing.Size(118, 17);
            this.tslblState.Text = "toolStripStatusLabel3";
            // 
            // FrmGraphicsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1394, 878);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.KeyPreview = true;
            this.Name = "FrmGraphicsEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Graphicseditor";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawSpace)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbDrawSpace;
        private System.Windows.Forms.TextBox tbTTToolLog;
        private TipToyGui.CustomControls.GfxPanel panel1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbOids;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbScenes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStripButton tsPolyNewPoint;
        private System.Windows.Forms.ToolStripButton tsPolyNewPoinInLine;
        private System.Windows.Forms.ToolStripButton tsPolyMove;
        private System.Windows.Forms.ToolStripButton tsPolyDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox tsPolygons;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsDelPoly;
        private System.Windows.Forms.ToolStripButton tsAddPoly;
        private System.Windows.Forms.ToolStripButton tsPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnDelTTImage;
        private System.Windows.Forms.Button btnMoveDownTTImage;
        private System.Windows.Forms.Button btnMoveUpTTImage;
        private System.Windows.Forms.Button btnNewTTImage;
        private System.Windows.Forms.ListBox lbTTImages;
        private System.Windows.Forms.ToolStripButton tsImgMove;
        private System.Windows.Forms.ToolStripButton tsImgRotate;
        private System.Windows.Forms.ToolStripButton tsImgScale;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblMouseReal;
        private System.Windows.Forms.ToolStripStatusLabel tslblMouseWorld;
        private System.Windows.Forms.ToolStripStatusLabel tslblState;
        private System.Windows.Forms.ToolStripButton TsGenerateLayer;
        private System.Windows.Forms.Button btnOnSwitchOid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}