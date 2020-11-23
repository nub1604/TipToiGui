using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipToyGui.Nodes;
using static TipToyGui.Scene;

namespace TipToyGui.Dialogs
{
    public partial class frmScene : TTDialog
    {
        private Scene Source;
        private Scene[] Existingregister;

        public Scene Result { get; private set; }


        public frmScene(Scene[] recent, Scene scene = null)
        {
            InitializeComponent();
            Existingregister = recent;
            cbDPI.DataSource = Enum.GetValues(typeof(EnumDPI));
            comboBox1.DataSource = Enum.GetValues(typeof(EnumDin));
            this.Source = scene;

            if (scene != null)
            {
                textBox1.Text = scene.Name;
                comboBox1.SelectedItem = Scene.SizeToDin( scene.CanvasSize);
                cbDPI.SelectedItem = scene.ResolutionDPI == 1200? EnumDPI.High: EnumDPI.Low;
            }
        }

        private void NodeFrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No Name defined");
                return;
            }
            var reg = Existingregister.Where(x => x.Name == textBox1.Text && (Source == null || x != Source)).FirstOrDefault();
            if (reg != null)
            {
                MessageBox.Show("name allready in use");
                return;
            }

            Result = new Scene(textBox1.Text, Scene.Din2Size((EnumDin)comboBox1.SelectedItem), (EnumDPI) cbDPI.SelectedItem);

            

            this.DialogResult = DialogResult.OK;
        }
    }
}