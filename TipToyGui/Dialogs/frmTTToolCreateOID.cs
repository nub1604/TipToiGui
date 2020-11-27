using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipToyGui.Dialogs
{
    public partial class FrmTTToolCreateOID : TTDialog
    {
        public FrmTTToolCreateOID()
        {
            InitializeComponent();

            cbDPI.DataSource = Enum.GetValues(typeof(EnumDPI));
            cbImageFormat.DataSource = Enum.GetValues(typeof(EnumImageFormat));
        }

        private void TbWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TbHeigth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            TTToolSettings tset = new TTToolSettings
            {
                CodeDim = new Size(int.Parse(string.IsNullOrWhiteSpace(tbWidth.Text) ? "0" : tbWidth.Text), int.Parse(string.IsNullOrWhiteSpace(tbWidth.Text) ? "0" : tbHeigth.Text)),
                DPI = (int)cbDPI.SelectedItem,
                ImageFormat = (EnumImageFormat)cbImageFormat.SelectedItem,
                PixelSize = (int)nupPixelsize.Value
            };
            string result;
            if (string.IsNullOrWhiteSpace(tbWorkingDirectory.Text))
            {
                result = TTTool.CreateOidCodes(tset, (ushort)nupCode.Value );
            }
            else
            {
                result = TTTool.CreateOidCodes(tset, (ushort)nupCode.Value, tbWorkingDirectory.Text);
            }


            if (!string.IsNullOrEmpty(result))
            {
                tbTTToolLog.Text = result;
            }


        }

        private void btnExtracMediaLoadDir_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbWorkingDirectory.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
