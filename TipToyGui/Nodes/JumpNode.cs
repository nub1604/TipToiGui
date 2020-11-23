using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Windows.Forms;
using TipToyGui.OidClasses;

namespace TipToyGui.Nodes
{
    public partial class JumpNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }

        private BindingSource bindingSource1;
        private ComboBox cb;

        public JumpNode(JObject jObject) : base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        public JumpNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            bindingSource1 = new BindingSource
            {
                DataSource = MainForm.Project.nodeSetups
            };

            Headlabel.Text = $"Jump";

            cb = new ComboBox
            {
                DataSource = bindingSource1.DataSource,
                Location = new Point(0, Headlabel.Bottom),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Output = new ConnectionPoint(typeof(IOIDAction));
            Output.Location = new Point(this.Width - Output.Width, Headlabel.Bottom);
            Output.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            Output.SetColor(COLORACTION);

            this.Controls.Add(cb);
            this.Controls.Add(Output);

            this.Height = Output.Bottom;
        }

        public override object NodeObject(bool validate = false)
        {
            this.BackColor = Color.LimeGreen;
            NodeSetup oID = (NodeSetup)cb.SelectedItem;
            if (oID != null)
            {
                return new OIDActionJump(oID);
            }
            if (validate)
                Flash(this, 500, Color.Red, 3);

            return null;
        }

        public override void Reconnect(ConnectionPoint[] connectionPoints)
        {
            if (Settings != null)
            {
                Output.Connect(connectionPoints, Settings["Output"]["Connections"]);
            }
        }

        public override void SetSettings()
        {
            if (Settings != null)
            {
                Output.ID = (string)Settings["Output"]["ID"];
                this.cb.SelectedItem = (string)Settings["Val"];
                base.SetSettings();
            }
        }

        public override JObject GetSettings()
        {
            JObject jObject = new JObject
            {
                { "MyType", GetType().ToString() },
                { "BaseSetting", base.GetSettings() },
                { "Output", this.Output.GetData },
                { "Val", this.cb.SelectedItem.ToString() }
            };

            return jObject;
        }
    }
}