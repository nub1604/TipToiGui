using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TipToyGui.MaskPicture;

namespace TipToyGui.Dialogs
{
    public partial class frmImageExport : TTDialog
    {
        public EnumNeutralOid enumNeutral { get; private set; }
        public bool ExportMask { get; private set; }
        public bool ExportCanvasImage { get; private set; }
        public bool Highquality { get; private set; }


        public frmImageExport()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Enum.GetValues(typeof(EnumNeutralOid)).Cast<object>().ToArray());


        }

        private void button2_Click(object sender, EventArgs e)
        {

            ExportCanvasImage = checkBox1.Checked;
            enumNeutral = (EnumNeutralOid)(comboBox1.SelectedItem?? EnumNeutralOid.none);
            ExportMask = checkBox2.Checked;
            Highquality = checkBox3.Checked;
            DialogResult = DialogResult.OK;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if( checkBox2.Checked)
            {
                comboBox1.Enabled = true;
                checkBox3.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                checkBox3.Enabled = false;
            }
        }
    }
}
