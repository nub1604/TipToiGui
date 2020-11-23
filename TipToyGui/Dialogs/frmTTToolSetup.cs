using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipToyGui.Common;

namespace TipToyGui.Dialogs
{
    public partial class frmTTToolSetup : TTDialog
    {
        public frmTTToolSetup()
        {
            InitializeComponent();
            var path = TTGRegistry.Read("tttoolPath");
            if ( !string.IsNullOrEmpty(path))
            {
                textBox1.Text = path;
            }
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "tttool.exe | tttool.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string s = CMD.GetMultiline(textBox1.Text, "-h");
            button2.ForeColor = Color.Red;
            if (string.IsNullOrEmpty(s))
            {
                return;
            }
            textBox2.Text = s;

            if (s.Contains("Usage: tttool.exe"))
            {
                button2.ForeColor = Color.Green;
                TTGRegistry.Write("tttoolPath", textBox1.Text);
            }
        }
    }
}
