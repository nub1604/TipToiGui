using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipToyGui.Dialogs
{
    public partial class FrmProject : TTDialog
    {
        public OIDProject Project { get; private set; }

        /// <summary>
        /// New Project
        /// </summary>
        public FrmProject()
        {
            InitializeComponent();
            Project = new OIDProject();
            comboBox1.Items.AddRange(Enum.GetValues(typeof(EnumGMELANG)).Cast<object>().ToArray());
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }
        /// <summary>
        /// Edit Current
        /// </summary>
        /// <param name="p"></param>
        public FrmProject(OIDProject p)
        {
            InitializeComponent();
            Project = p;

           nupProductID.Value  = Project.ProductID;

            tbMediaPath.Text = p.MediaPath;
            tbProjectName.Text = p.Name;
            tbProjectPath.Text = p.ProjectPath;

            tbWelcome.Text = Project.Welcome;
            tbComment.Text = Project.Comment;

            tbProjectPath.Enabled = false;
            comboBox1.Items.AddRange(Enum.GetValues(typeof(EnumGMELANG)).Cast<object>().ToArray());
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = comboBox1.FindString( Project.Language);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMediaPath.Text)) return;
            if (string.IsNullOrWhiteSpace(tbProjectName.Text)) return;
            if (string.IsNullOrWhiteSpace(tbProjectPath.Text)) return;
                    


            Project.ProductID = (ushort)nupProductID.Value;
            Project.Comment = tbComment.Text;
            Project.MediaPath = tbMediaPath.Text;
            Project.Welcome = tbWelcome.Text;

            Project.Name = tbProjectName.Text;
            Project.ProjectPath = tbProjectPath.Text;
            Project.Language = comboBox1.Text;


            if (Directory.Exists(tbProjectPath.Text) && tbProjectPath.Enabled)
            {

                string ps = "\\";
                string p = $"{Project.ProjectPath}{ps}{Project.MediaPath.Replace(ps,"")}";
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
               
            }

            Project.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbProjectPath.Text = fbd.SelectedPath;
                }
            }

        }
    }
}
