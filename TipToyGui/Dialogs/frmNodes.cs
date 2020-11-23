using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.Nodes;

namespace TipToyGui.Dialogs
{
    public partial class FrmNodes : TTDialog
    {
        private NodeSetup Source;
        private NodeSetup[] Existingregister;

        public NodeSetup Result { get; private set; }

        public FrmNodes(NodeSetup[] recent, NodeSetup nodeSetup = null)
        {
            InitializeComponent();
            Existingregister = recent;

            numericUpDown1.Minimum = 1000;
            numericUpDown1.Maximum = ushort.MaxValue;
            this.Source = nodeSetup;

            if (nodeSetup == null)
            {
                if (Existingregister != null && Existingregister.Length > 0)
                {
                    var r = Existingregister.OrderByDescending(x => x.OID).FirstOrDefault();
                    if (r.OID != numericUpDown1.Maximum)
                        numericUpDown1.Value = r.OID + 1;
                }
            }
            else
            {
                textBox1.Text = nodeSetup.Name;
                numericUpDown1.Value = nodeSetup.OID;
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

            Result = new NodeSetup((ushort)numericUpDown1.Value, textBox1.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}