using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TipToyGui.Nodes
{
    public partial class TextSequenceNode : BaseNode, IPriority
    {
     

        public int prio;
        public int Prio { get => prio; set => prio = value; }

        private TextBox nud;
        private TextBox tbNativeCode;

        public TextSequenceNode(JObject jObject) : base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        public TextSequenceNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Sequence";
            tbNativeCode = new TextBox();
            tbNativeCode.Width = this.Width;
            tbNativeCode.Location = Headlabel.Underneath();

            nud = new TextBox();
            nud.BorderStyle = BorderStyle.FixedSingle;
            nud.Location = new Point(this.Width * 2 / 3, tbNativeCode.Bottom);
            nud.Width = this.Width - nud.Left;
            nud.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };
            nud.TextChanged += (sender, e) =>
            {
                if (nud.Text == "" || !IsAllDigits(nud.Text)) nud.Text = "0";
                prio = Int32.Parse(nud.Text);
            };

            this.Height = nud.Underneath().AddY(2).Y;
            this.Controls.Add(tbNativeCode);
            this.Controls.Add(nud);

            Headlabel.Width = this.Width;
            this.DoubleClick += (_, __) =>
            {
                var no = NodeObject(true);
                if (no != null && no is OIDTextSequence oID)
                {
                    RaiseMessageEvent(new MessageEventArgs($"test {oID.GetSequenceString()}"));
                }
            };
        }

        private bool IsAllDigits(string s) => s.All(char.IsDigit);

        public override object NodeObject(bool validate = false)
        {
            OIDTextSequence seq = new OIDTextSequence();
            if (!string.IsNullOrWhiteSpace(tbNativeCode.Text))
            {
                seq.Text = tbNativeCode.Text;
                return seq;
            }
            else
            {


                if (validate)
                    Flash(this, 500, Color.Red, 3);


                return null;
            }
        }

      

        public override void SetSettings()
        {
            if (Settings != null)
            {
                if (Settings.ContainsKey("Text"))
                {
                    this.tbNativeCode.Text = (string)Settings["Text"];
                }
              

                if (Settings.ContainsKey("prio"))
                {
                    prio = (int)Settings["prio"];
                    nud.Text = prio.ToString();
                }

                base.SetSettings();
            }
        }

        public override JObject GetSettings()
        {
            JObject jObject = new JObject();
            jObject.Add("MyType", GetType().ToString());
            jObject.Add("BaseSetting", base.GetSettings());
            jObject.Add("Text", tbNativeCode.Text);
            jObject.Add("prio", prio);
            return jObject;
        }
    }
}