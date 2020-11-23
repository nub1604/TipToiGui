namespace TipToyGui
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbRegister = new System.Windows.Forms.ListBox();
            this.lbFunctions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOidCodes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsProjectSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.createYamlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphicEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speakEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tTToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assembleExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playYamlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbStatusLabel = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nodePanel1 = new TipToyGui.NodePanel();
            this.createGMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodePanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRegister
            // 
            this.lbRegister.AllowDrop = true;
            this.lbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lbRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbRegister.FormattingEnabled = true;
            this.lbRegister.Location = new System.Drawing.Point(12, 250);
            this.lbRegister.Name = "lbRegister";
            this.lbRegister.Size = new System.Drawing.Size(170, 197);
            this.lbRegister.TabIndex = 1;
            this.lbRegister.TabStop = false;
            this.lbRegister.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbRegister_MouseDown);
            // 
            // lbFunctions
            // 
            this.lbFunctions.AllowDrop = true;
            this.lbFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFunctions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lbFunctions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFunctions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbFunctions.FormattingEnabled = true;
            this.lbFunctions.Location = new System.Drawing.Point(12, 466);
            this.lbFunctions.Name = "lbFunctions";
            this.lbFunctions.Size = new System.Drawing.Size(170, 119);
            this.lbFunctions.TabIndex = 2;
            this.lbFunctions.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(9, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Register";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(9, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Functions";
            // 
            // lbOidCodes
            // 
            this.lbOidCodes.AllowDrop = true;
            this.lbOidCodes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lbOidCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOidCodes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbOidCodes.FormattingEnabled = true;
            this.lbOidCodes.Location = new System.Drawing.Point(12, 47);
            this.lbOidCodes.Name = "lbOidCodes";
            this.lbOidCodes.Size = new System.Drawing.Size(170, 184);
            this.lbOidCodes.TabIndex = 0;
            this.lbOidCodes.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(9, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OId Codes";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.tTToolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(836, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.MenuRecent,
            this.tsProjectSettings,
            this.toolStripSeparator1,
            this.createYamlToolStripMenuItem,
            this.createGMEToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // MenuRecent
            // 
            this.MenuRecent.Name = "MenuRecent";
            this.MenuRecent.Size = new System.Drawing.Size(180, 22);
            this.MenuRecent.Text = "Recent";
            // 
            // tsProjectSettings
            // 
            this.tsProjectSettings.Name = "tsProjectSettings";
            this.tsProjectSettings.Size = new System.Drawing.Size(180, 22);
            this.tsProjectSettings.Text = "Projekt Settings";
            this.tsProjectSettings.Click += new System.EventHandler(this.tsProjectSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // createYamlToolStripMenuItem
            // 
            this.createYamlToolStripMenuItem.Name = "createYamlToolStripMenuItem";
            this.createYamlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createYamlToolStripMenuItem.Text = "Create Yaml";
            this.createYamlToolStripMenuItem.Click += new System.EventHandler(this.createYamlToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphicEditorToolStripMenuItem,
            this.speakEditorToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // graphicEditorToolStripMenuItem
            // 
            this.graphicEditorToolStripMenuItem.Name = "graphicEditorToolStripMenuItem";
            this.graphicEditorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.graphicEditorToolStripMenuItem.Text = "Graphic Editor";
            this.graphicEditorToolStripMenuItem.Click += new System.EventHandler(this.GraphicEditorToolStripMenuItem_Click);
            // 
            // speakEditorToolStripMenuItem
            // 
            this.speakEditorToolStripMenuItem.Name = "speakEditorToolStripMenuItem";
            this.speakEditorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.speakEditorToolStripMenuItem.Text = "Speak Editor";
            this.speakEditorToolStripMenuItem.Click += new System.EventHandler(this.SpeakEditorToolStripMenuItem_Click);
            // 
            // tTToolToolStripMenuItem
            // 
            this.tTToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.assembleExportToolStripMenuItem,
            this.createOIDToolStripMenuItem,
            this.playYamlToolStripMenuItem});
            this.tTToolToolStripMenuItem.Name = "tTToolToolStripMenuItem";
            this.tTToolToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.tTToolToolStripMenuItem.Text = "TTTool";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.SetupToolStripMenuItem_Click);
            // 
            // assembleExportToolStripMenuItem
            // 
            this.assembleExportToolStripMenuItem.Name = "assembleExportToolStripMenuItem";
            this.assembleExportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.assembleExportToolStripMenuItem.Text = "Assemble / Export";
            this.assembleExportToolStripMenuItem.Click += new System.EventHandler(this.AssembleExportToolStripMenuItem_Click);
            // 
            // createOIDToolStripMenuItem
            // 
            this.createOIDToolStripMenuItem.Name = "createOIDToolStripMenuItem";
            this.createOIDToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.createOIDToolStripMenuItem.Text = "CreateOID";
            this.createOIDToolStripMenuItem.Click += new System.EventHandler(this.CreateOIDToolStripMenuItem_Click);
            // 
            // playYamlToolStripMenuItem
            // 
            this.playYamlToolStripMenuItem.Name = "playYamlToolStripMenuItem";
            this.playYamlToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.playYamlToolStripMenuItem.Text = "Play Yaml";
            this.playYamlToolStripMenuItem.Click += new System.EventHandler(this.PlayYamlToolStripMenuItem_Click);
            // 
            // tbStatusLabel
            // 
            this.tbStatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tbStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbStatusLabel.ForeColor = System.Drawing.Color.White;
            this.tbStatusLabel.Location = new System.Drawing.Point(0, 589);
            this.tbStatusLabel.Name = "tbStatusLabel";
            this.tbStatusLabel.ReadOnly = true;
            this.tbStatusLabel.Size = new System.Drawing.Size(836, 20);
            this.tbStatusLabel.TabIndex = 5;
            this.tbStatusLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.nodePanel1);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.panel1.Location = new System.Drawing.Point(188, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 536);
            this.panel1.TabIndex = 6;
            // 
            // nodePanel1
            // 
            this.nodePanel1.AllowDrop = true;
            this.nodePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.nodePanel1.Location = new System.Drawing.Point(3, 3);
            this.nodePanel1.Name = "nodePanel1";
            this.nodePanel1.Size = new System.Drawing.Size(2000, 1000);
            this.nodePanel1.TabIndex = 3;
            this.nodePanel1.TabStop = false;
            // 
            // createGMEToolStripMenuItem
            // 
            this.createGMEToolStripMenuItem.Name = "createGMEToolStripMenuItem";
            this.createGMEToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createGMEToolStripMenuItem.Text = "Create GME";
            this.createGMEToolStripMenuItem.Click += new System.EventHandler(this.createGMEToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(836, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbStatusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOidCodes);
            this.Controls.Add(this.lbFunctions);
            this.Controls.Add(this.lbRegister);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TipToiGui";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nodePanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRegister;
        private System.Windows.Forms.ListBox lbFunctions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbOidCodes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tTToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assembleExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.TextBox tbStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem MenuRecent;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playYamlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphicEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speakEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createYamlToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        public NodePanel nodePanel1;
        private System.Windows.Forms.ToolStripMenuItem tsProjectSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createGMEToolStripMenuItem;
    }
}

