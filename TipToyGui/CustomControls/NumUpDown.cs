using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipToyGui.CustomControls
{
    public partial class NumUpDown : NumericUpDown
    {
        public NumUpDown()
        {
            InitializeComponent();
        }
        public override void UpButton()
        {
            if (Value < Maximum)
                Value++;
            else
                Value = Minimum;
        }
        public override void DownButton()
        {
            if (Value > Minimum)
                Value--;
            else
                Value = Maximum;
        }
    }
}
