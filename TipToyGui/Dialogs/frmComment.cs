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
    public partial class FrmComment : TTDialog
    {
        public string Comment { get; private set; }
        public FrmComment()
        {
            InitializeComponent();
        }
        public FrmComment(string comment)
        {
            InitializeComponent();
            textBox1.Text = comment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comment = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
