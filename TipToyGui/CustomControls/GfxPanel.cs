using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipToyGui.CustomControls
{
    public class GfxPanel: Panel
    {


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.VScroll && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                this.VScroll = false;
                base.OnMouseWheel(e);
                this.VScroll = true;
            }
            else if (this.VScroll && Control.ModifierKeys != Keys.Shift &&
                Control.ModifierKeys != Keys.Alt &&
                    Control.ModifierKeys != Keys.Control
                
                )
            {
                base.OnMouseWheel(e);
            }

        }

    }
}
