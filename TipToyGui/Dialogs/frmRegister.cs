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
    public partial class frmRegister : TTDialog
    {
        private OIDRegister[] Existingregister;
        private OIDRegister Source;
        public OIDRegister Result { get; private set; }

        public frmRegister(OIDRegister[] existing, OIDRegister source = null)
        {
            InitializeComponent();
            numericUpDown1.Maximum = ushort.MaxValue;
            Existingregister = existing;
            Source = source;
            if (Source == null)
            {
                if (existing != null && existing.Length > 0)
                {
                    var r = existing.OrderByDescending(x => x.OID).FirstOrDefault();
                    numericUpDown1.Value = r.OID + 1;
                }
            }
            else
            {
                textBox1.Text = source.Name;
                numericUpDown1.Value = source.OID;
                numericUpDown2.Value = source.InitValue;
            }
        }

        private void NodeFrm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reg = Existingregister.Where(x => x.Name == textBox1.Text && (Source == null || x != Source)).FirstOrDefault();

                if (reg != null)
                {
                    MessageBox.Show("name allready in use");
                    return;
                }
            
          
        
            Result = new OIDRegister((ushort)numericUpDown1.Value, textBox1.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}