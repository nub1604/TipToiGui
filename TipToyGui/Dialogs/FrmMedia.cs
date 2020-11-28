using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipToyGui.Dialogs
{
    public partial class FrmMedia : TTDialog
    {

        public FrmMedia()
        {
            InitializeComponent();
            RefreshMediaFiles();
        }

        private void RefreshMediaFiles()
        {
            var lastindex = lbMediaFilelist.SelectedIndex;
            
            this.lbMediaFilelist.Items.Clear();
            var arr = MainForm.Project.MediaFiles.ToArray();
            this.lbMediaFilelist.Items.AddRange(arr);

            if (lastindex > 0 && lastindex < lbMediaFilelist.Items.Count)
                lbMediaFilelist.SelectedIndex = lastindex;
            else if (lbMediaFilelist.Items.Count > 0)
                lbMediaFilelist.SelectedIndex = 0;
            else
            {
                tbName.Text = "";
                tbAudioFile.Text = "";
                tbHash.Text = "";
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TbName_TextChanged(object sender, EventArgs e)
        {
        
            if (this.lbMediaFilelist.SelectedItem != null)
            {
                MainForm.Project.MediaFiles[lbMediaFilelist.SelectedIndex].EditorEditorName = tbName.Text;
            }
        }


        private void LbMediaFilelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbMediaFilelist.SelectedItem != null)
            {
                tbName.Text = MainForm.Project.MediaFiles[lbMediaFilelist.SelectedIndex].EditorEditorName;
                tbAudioFile.Text = MainForm.Project.MediaFiles[lbMediaFilelist.SelectedIndex].FileName;
                tbHash.Text = MainForm.Project.MediaFiles[lbMediaFilelist.SelectedIndex].HashValue;
            }
        }

        private void BtnLoadAudioFile_Click(object sender, EventArgs e)
        {
          var m =   MediaFile.ImportNewFile(MainForm.Project);

            if (m != null)
            {
                MainForm.Project.MediaFiles.Add(m);
                RefreshMediaFiles();
            }
        }

        private void BtnRemoveAudioFile_Click(object sender, EventArgs e)
        {
            if (MainForm.Project != null)
            {
                string pf = Path.Combine(MainForm.Project.ProjectPath, MainForm.Project.MediaPath, MainForm.Project.MediaFiles[lbMediaFilelist.SelectedIndex].FileName);
                File.Delete(pf);
                MainForm.Project.MediaFiles.Remove(MainForm.Project.MediaFiles[lbMediaFilelist.SelectedIndex]);
            }
            RefreshMediaFiles();
        }

        private void TbName_Leave(object sender, EventArgs e)
        {
            RefreshMediaFiles();
        }
    }

    
}
