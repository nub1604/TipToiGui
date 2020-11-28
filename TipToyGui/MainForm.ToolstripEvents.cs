using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipToyGui.Dialogs;

namespace TipToyGui
{
    public partial class MainForm
    {
        public const string FILTERPROJECT = "tiptoigui project files(*.)|*.ttproj";
        private void SetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var s = new frmTTToolSetup())
            {
                s.ShowDialog();
            }
        }

        private void AssembleExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var s = new FrmTTTool())
            {
                s.ShowDialog();
            }
        }

        private void CreateOIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var s = new FrmTTToolCreateOID())
            {
                s.ShowDialog();
            }
        }

        private void NewProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var s = new FrmProject())
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    Project = s.Project;
                    TempSetup();
                    tbStatusLabel.Text = "Project created";
                }
            }
            Flash(tbStatusLabel, 500, Color.Green, 5);
        }
        private void PlayYamlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var s = new FrmTTToolPlay())
            {
                s.ShowDialog();
            }
        }
        private void GraphicEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            using (var s = new FrmGraphicsEditor())
            {
                s.ShowDialog();
            }

        }
        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            Project.Save();
                RefreshRecentItems();
            }
        

        private void SpeakEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            using (var s = new FrmSpeak())
            {
                s.ShowDialog();
            }

        }
        private void mediaManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            using (var s = new FrmMedia())
            {
                s.ShowDialog();
            }
            LbOidCodes_SelectedIndexChanged(null, null);

        }
        private void createYamlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            
                Project.SaveYaml();
            
        }
        private void createGMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            Project.CreateGME();
           

        }


        private void tsProjectSettings_Click(object sender, EventArgs e)
        {
            if (Project == null) return;
            using (var s = new FrmProject(Project))
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    Project = s.Project;
                    tbStatusLabel.Text = "Project Settings Changed";
                }
            }
            Flash(tbStatusLabel, 500, Color.Green, 3);
        }
        
        private void RefreshRecentItems()
        {
            MenuRecent.DropDownItems.Clear();
            foreach (var item in TTGRegistry.GetRecentProjectPath())
            {
                var mi = new ToolStripMenuItem(item);
                mi.Click += (_, __) =>
                {
                    Project = OIDProject.Load(item);
                    RefreshNodes();
                    RefreshOid();

                    if (lbOidCodes.Items != null && lbOidCodes.Items.Count > 0)
                        lbOidCodes.SelectedIndex = 0;
                };
                MenuRecent.DropDownItems.Add(mi);
            }
        }
        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = FILTERPROJECT;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Project = OIDProject.Load(ofd.FileName);
                    RefreshNodes();
                    RefreshOid();

                    if (lbOidCodes.Items != null && lbOidCodes.Items.Count > 0)
                        lbOidCodes.SelectedIndex = 0;
                }
            }
        }
    }
}
