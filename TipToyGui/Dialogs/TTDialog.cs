using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipToyGui.Dialogs
{
    public class TTDialog:Form
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.DialogResult = DialogResult.Cancel;
            }
      

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
