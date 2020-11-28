namespace TipToyGui.Dialogs
{
    partial class FrmMedia
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lbMediaFilelist = new System.Windows.Forms.ListBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnRemoveAudioFile = new System.Windows.Forms.Button();
            this.btnLoadAudioFile = new System.Windows.Forms.Button();
            this.tbHash = new System.Windows.Forms.TextBox();
            this.tbAudioFile = new System.Windows.Forms.TextBox();
            this.lblHash = new System.Windows.Forms.Label();
            this.lblImportAudio = new System.Windows.Forms.Label();
            this.lblRemoveAudioFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.Location = new System.Drawing.Point(295, 199);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.Btn_Click);
            // 
            // lbMediaFilelist
            // 
            this.lbMediaFilelist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.lbMediaFilelist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbMediaFilelist.FormattingEnabled = true;
            this.lbMediaFilelist.Location = new System.Drawing.Point(12, 12);
            this.lbMediaFilelist.Name = "lbMediaFilelist";
            this.lbMediaFilelist.Size = new System.Drawing.Size(172, 186);
            this.lbMediaFilelist.TabIndex = 0;
            this.lbMediaFilelist.SelectedIndexChanged += new System.EventHandler(this.LbMediaFilelist_SelectedIndexChanged);
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbName.Location = new System.Drawing.Point(190, 84);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(180, 20);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.TbName_TextChanged);
            this.tbName.Leave += new System.EventHandler(this.TbName_Leave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblName.Location = new System.Drawing.Point(190, 68);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFilename.Location = new System.Drawing.Point(190, 107);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(49, 13);
            this.lblFilename.TabIndex = 6;
            this.lblFilename.Text = "Filename";
            // 
            // btnRemoveAudioFile
            // 
            this.btnRemoveAudioFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAudioFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemoveAudioFile.Location = new System.Drawing.Point(159, 199);
            this.btnRemoveAudioFile.Name = "btnRemoveAudioFile";
            this.btnRemoveAudioFile.Size = new System.Drawing.Size(25, 25);
            this.btnRemoveAudioFile.TabIndex = 4;
            this.btnRemoveAudioFile.Text = "-";
            this.btnRemoveAudioFile.UseVisualStyleBackColor = true;
            this.btnRemoveAudioFile.Click += new System.EventHandler(this.BtnRemoveAudioFile_Click);
            // 
            // btnLoadAudioFile
            // 
            this.btnLoadAudioFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadAudioFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLoadAudioFile.Location = new System.Drawing.Point(327, 12);
            this.btnLoadAudioFile.Name = "btnLoadAudioFile";
            this.btnLoadAudioFile.Size = new System.Drawing.Size(43, 25);
            this.btnLoadAudioFile.TabIndex = 1;
            this.btnLoadAudioFile.Text = "...";
            this.btnLoadAudioFile.UseVisualStyleBackColor = true;
            this.btnLoadAudioFile.Click += new System.EventHandler(this.BtnLoadAudioFile_Click);
            // 
            // tbHash
            // 
            this.tbHash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbHash.Location = new System.Drawing.Point(190, 163);
            this.tbHash.Name = "tbHash";
            this.tbHash.ReadOnly = true;
            this.tbHash.Size = new System.Drawing.Size(180, 20);
            this.tbHash.TabIndex = 3;
            this.tbHash.TabStop = false;
            this.tbHash.TextChanged += new System.EventHandler(this.TbName_TextChanged);
            // 
            // tbAudioFile
            // 
            this.tbAudioFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbAudioFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbAudioFile.Location = new System.Drawing.Point(190, 123);
            this.tbAudioFile.Name = "tbAudioFile";
            this.tbAudioFile.ReadOnly = true;
            this.tbAudioFile.Size = new System.Drawing.Size(180, 20);
            this.tbAudioFile.TabIndex = 6;
            this.tbAudioFile.TabStop = false;
            this.tbAudioFile.TextChanged += new System.EventHandler(this.TbName_TextChanged);
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblHash.Location = new System.Drawing.Point(190, 147);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(32, 13);
            this.lblHash.TabIndex = 6;
            this.lblHash.Text = "Hash";
            // 
            // lblImportAudio
            // 
            this.lblImportAudio.AutoSize = true;
            this.lblImportAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblImportAudio.Location = new System.Drawing.Point(190, 18);
            this.lblImportAudio.Name = "lblImportAudio";
            this.lblImportAudio.Size = new System.Drawing.Size(79, 13);
            this.lblImportAudio.TabIndex = 5;
            this.lblImportAudio.Text = "Import Audiofile";
            // 
            // lblRemoveAudioFile
            // 
            this.lblRemoveAudioFile.AutoSize = true;
            this.lblRemoveAudioFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRemoveAudioFile.Location = new System.Drawing.Point(12, 205);
            this.lblRemoveAudioFile.Name = "lblRemoveAudioFile";
            this.lblRemoveAudioFile.Size = new System.Drawing.Size(133, 13);
            this.lblRemoveAudioFile.TabIndex = 5;
            this.lblRemoveAudioFile.Text = "Remove selected Audiofile";
            // 
            // FrmMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(379, 236);
            this.Controls.Add(this.btnRemoveAudioFile);
            this.Controls.Add(this.btnLoadAudioFile);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.tbAudioFile);
            this.Controls.Add(this.lblRemoveAudioFile);
            this.Controls.Add(this.lblImportAudio);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbHash);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbMediaFilelist);
            this.Controls.Add(this.btnOk);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMedia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Media Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListBox lbMediaFilelist;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnRemoveAudioFile;
        private System.Windows.Forms.Button btnLoadAudioFile;
        private System.Windows.Forms.TextBox tbHash;
        private System.Windows.Forms.TextBox tbAudioFile;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Label lblImportAudio;
        private System.Windows.Forms.Label lblRemoveAudioFile;
    }
}