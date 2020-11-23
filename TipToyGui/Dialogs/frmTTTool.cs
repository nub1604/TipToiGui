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
    public partial class FrmTTTool : TTDialog
    {
        public FrmTTTool()
        {
            InitializeComponent();

            this.Text = string.IsNullOrEmpty(TTGRegistry.Read("tttoolPath")) ? "TTTool not loaded" : "TTTool loaded";

        }

        #region Assemble
        private void BtnAssembleLoadYaml_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = TTTool.FILTERYAML;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbAssembleYaml.Text = ofd.FileName;
                }
            }
        }

        private void BtnAssembleSaveGME_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = TTTool.FILTERGME;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    tbAssembleGME.Text = sfd.FileName;
                }
            }
        }

        private void BtnAssemble_Click(object sender, EventArgs e)
        {
            if ( File.Exists(tbAssembleYaml.Text))
            {

                tbTTToolLog.Text =   TTTool.Assemble(tbAssembleYaml.Text, tbAssembleGME.Text);
            }
        }
        #endregion

        #region Export Media
        private void btnExtractMediaLoadGME_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = TTTool.FILTERGME;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbExtractMediaGME.Text = ofd.FileName;
                }
            }
        }

        private void btnExtracMediaLoadDir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
            
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbExtractMediaFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnExtractMedia_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbExtractMediaGME.Text))
            {
                tbTTToolLog.Text = TTTool.ExtractMediaFromGME(tbExtractMediaGME.Text, tbExtractMediaFolder.Text);
            }
        }
        #endregion

        #region Export Yaml
        private void btnExtractYamlLoadGME_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = TTTool.FILTERGME;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbExtractYamlGME.Text = ofd.FileName;
                }
            }
        }

        private void btnExtractYamlSaveYaml_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = TTTool.FILTERYAML;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    tbExtractYamlYaml.Text = sfd.FileName;
                }
            }
        }

        private void btnExtractYaml_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbExtractYamlGME.Text))
            {
                tbTTToolLog.Text = TTTool.ExtractYamlFromGME(tbExtractYamlGME.Text, tbExtractYamlYaml.Text);
            }
        }
        #endregion
    }
}
