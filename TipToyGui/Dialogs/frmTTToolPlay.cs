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
using TipToyGui.Common;

namespace TipToyGui.Dialogs
{
    public partial class FrmTTToolPlay : TTDialog
    {

        PlayTTTool _PlayTTTool;
        public FrmTTToolPlay()
        {
            InitializeComponent();

            this.Text = string.IsNullOrEmpty(TTGRegistry.Read("tttoolPath")) ? "TTTool not loaded" : "TTTool loaded";
           
        }

        private void PlayTTTool_OnRaiseMessageEvent(object sender, Nodes.BaseNode.MessageEventArgs e)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() =>
                {
                    tbTTToolLog.Text += (e.Message);
                }));
            }
        }

        #region Play
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

        private void BtnAssemble_Click(object sender, EventArgs e)
        {
            string ttool = TTGRegistry.Read("tttoolPath");
            if ( File.Exists(tbAssembleYaml.Text) && File.Exists(ttool))
            {
                _PlayTTTool = new PlayTTTool(ttool, $"play {tbAssembleYaml.Text}");
                _PlayTTTool.OnRaiseMessageEvent += PlayTTTool_OnRaiseMessageEvent;
            }
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(_PlayTTTool != null)
            {
                _PlayTTTool.Write(tbMess.Text);
                tbMess.Text = "";
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {

            _PlayTTTool?.Dispose();
            base.OnClosing(e);
        }
    }
}
