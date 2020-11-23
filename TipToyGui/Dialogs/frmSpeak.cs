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
    public partial class FrmSpeak : TTDialog
    {

        public FrmSpeak()
        {
            InitializeComponent();
            RefreshSpeaklist();
            comboBox1.Items.AddRange(Enum.GetValues(typeof(EnumLangShort)).Cast<object>().ToArray());
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

        }

        private void RefreshSpeaklist()
        {
            if (MainForm.Project != null)
            {
                this.listBox1.Items.Clear();
                var arr = MainForm.Project.SpeakObjects.ToArray();
                this.listBox1.Items.AddRange(arr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {

                MainForm.Project.SpeakObjects[listBox1.SelectedIndex].Name = textBox1.Text;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {

                MainForm.Project.SpeakObjects[listBox1.SelectedIndex].Text = string.Join(" ", textBox2.Lines);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                textBox1.Text = MainForm.Project.SpeakObjects[listBox1.SelectedIndex].Name;
                textBox2.Text = MainForm.Project.SpeakObjects[listBox1.SelectedIndex].Text;
                comboBox1.SelectedItem = MainForm.Project.SpeakObjects[listBox1.SelectedIndex].Lang;



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = MainForm.Project.SpeakObjects.Count + 1;

            if (MainForm.Project != null)
            {
                MainForm.Project.SpeakObjects.Add(new OidClasses.OIDSpeak($"SpeakLabel{i}","", "en"));
            }

            RefreshSpeaklist();
            listBox1.SelectedIndex = listBox1.FindString($"SpeakLabel{i}");
            textBox1.Focus();
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = textBox1.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainForm.Project != null)
            {
                MainForm.Project.SpeakObjects.Remove(MainForm.Project.SpeakObjects[listBox1.SelectedIndex]);
            }
            RefreshSpeaklist();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {

                MainForm.Project.SpeakObjects[listBox1.SelectedIndex].Lang = (string)comboBox1.Text;
            }
        }
    }

    
}
