namespace TipToyGui.Dialogs
{
    partial class FrmTTToolCreateOID
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
            this.cbDPI = new System.Windows.Forms.ComboBox();
            this.cbImageFormat = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHeigth = new System.Windows.Forms.TextBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.nupPixelsize = new TipToyGui.CustomControls.NumUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTTToolLog = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWorkingDirectory = new System.Windows.Forms.Button();
            this.tbWorkingDirectory = new System.Windows.Forms.TextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numUpDown1 = new TipToyGui.CustomControls.NumUpDown();
            this.nupCode = new TipToyGui.CustomControls.NumUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPixelsize)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCode)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDPI
            // 
            this.cbDPI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbDPI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cbDPI.FormattingEnabled = true;
            this.cbDPI.Location = new System.Drawing.Point(129, 51);
            this.cbDPI.Name = "cbDPI";
            this.cbDPI.Size = new System.Drawing.Size(166, 21);
            this.cbDPI.TabIndex = 2;
            // 
            // cbImageFormat
            // 
            this.cbImageFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbImageFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.cbImageFormat.FormattingEnabled = true;
            this.cbImageFormat.Location = new System.Drawing.Point(129, 24);
            this.cbImageFormat.Name = "cbImageFormat";
            this.cbImageFormat.Size = new System.Drawing.Size(166, 21);
            this.cbImageFormat.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbHeigth);
            this.groupBox1.Controls.Add(this.tbWidth);
            this.groupBox1.Controls.Add(this.nupPixelsize);
            this.groupBox1.Controls.Add(this.cbDPI);
            this.groupBox1.Controls.Add(this.cbImageFormat);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 156);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Optional Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.label2.Location = new System.Drawing.Point(206, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pixel Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "DPI";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Imageformat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Code Dimension";
            // 
            // tbHeigth
            // 
            this.tbHeigth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbHeigth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbHeigth.Location = new System.Drawing.Point(226, 82);
            this.tbHeigth.Name = "tbHeigth";
            this.tbHeigth.Size = new System.Drawing.Size(69, 20);
            this.tbHeigth.TabIndex = 4;
            this.tbHeigth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbHeigth_KeyPress);
            // 
            // tbWidth
            // 
            this.tbWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbWidth.Location = new System.Drawing.Point(129, 82);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(71, 20);
            this.tbWidth.TabIndex = 3;
            this.tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbWidth_KeyPress);
            // 
            // nupPixelsize
            // 
            this.nupPixelsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nupPixelsize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.nupPixelsize.Location = new System.Drawing.Point(129, 113);
            this.nupPixelsize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupPixelsize.Name = "nupPixelsize";
            this.nupPixelsize.Size = new System.Drawing.Size(166, 20);
            this.nupPixelsize.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.label11.Location = new System.Drawing.Point(322, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "tttool.exe Log";
            // 
            // tbTTToolLog
            // 
            this.tbTTToolLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTTToolLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tbTTToolLog.Location = new System.Drawing.Point(322, 36);
            this.tbTTToolLog.Multiline = true;
            this.tbTTToolLog.Name = "tbTTToolLog";
            this.tbTTToolLog.ReadOnly = true;
            this.tbTTToolLog.Size = new System.Drawing.Size(207, 304);
            this.tbTTToolLog.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWorkingDirectory);
            this.groupBox2.Controls.Add(this.tbWorkingDirectory);
            this.groupBox2.Controls.Add(this.btnPlay);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numUpDown1);
            this.groupBox2.Controls.Add(this.nupCode);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 166);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Oid Codes";
            // 
            // btnWorkingDirectory
            // 
            this.btnWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkingDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkingDirectory.Location = new System.Drawing.Point(259, 96);
            this.btnWorkingDirectory.Name = "btnWorkingDirectory";
            this.btnWorkingDirectory.Size = new System.Drawing.Size(36, 23);
            this.btnWorkingDirectory.TabIndex = 11;
            this.btnWorkingDirectory.Text = "...";
            this.btnWorkingDirectory.UseVisualStyleBackColor = true;
            this.btnWorkingDirectory.Click += new System.EventHandler(this.btnExtracMediaLoadDir_Click);
            // 
            // tbWorkingDirectory
            // 
            this.tbWorkingDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkingDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbWorkingDirectory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbWorkingDirectory.Location = new System.Drawing.Point(6, 98);
            this.tbWorkingDirectory.Name = "tbWorkingDirectory";
            this.tbWorkingDirectory.Size = new System.Drawing.Size(247, 20);
            this.tbWorkingDirectory.TabIndex = 10;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(210, 125);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(85, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Create";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Working Directory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Code Nr.";
            // 
            // numUpDown1
            // 
            this.numUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.numUpDown1.Location = new System.Drawing.Point(175, 45);
            this.numUpDown1.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numUpDown1.Name = "numUpDown1";
            this.numUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numUpDown1.TabIndex = 0;
            // 
            // nupCode
            // 
            this.nupCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nupCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.nupCode.Location = new System.Drawing.Point(175, 19);
            this.nupCode.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.nupCode.Name = "nupCode";
            this.nupCode.Size = new System.Drawing.Size(120, 20);
            this.nupCode.TabIndex = 0;
            // 
            // FrmTTToolCreateOID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(538, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbTTToolLog);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTTToolCreateOID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TTTool CreateOID";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPixelsize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDPI;
        private System.Windows.Forms.ComboBox cbImageFormat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbWidth;
        private CustomControls.NumUpDown nupPixelsize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHeigth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbTTToolLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomControls.NumUpDown nupCode;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnWorkingDirectory;
        private System.Windows.Forms.TextBox tbWorkingDirectory;
        private System.Windows.Forms.Label label7;
        private CustomControls.NumUpDown numUpDown1;
    }
}