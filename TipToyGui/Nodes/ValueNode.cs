using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Windows.Forms;
using TipToyGui.CustomControls;

namespace TipToyGui.Nodes
{
    public partial class ValueNode : BaseNode
    {
        private ConnectionPoint Output;
        private NumUpDown numericUpDown;

        public ValueNode(JObject jObject):base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }
        public ValueNode()
        {
            InitializeComponent();

            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Value";

            numericUpDown = new NumUpDown();
            numericUpDown.Location = Headlabel.Underneath().AddY(2).AddX(4);
            numericUpDown.Width = this.Width / 2;
            numericUpDown.Maximum = ushort.MaxValue;
            numericUpDown.BorderStyle = BorderStyle.None;


            numericUpDown.ValueChanged += (_, __) =>
            {

            };
            this.Height = numericUpDown.Bottom;

            var pos = new Point()
            {
                X = this.ClientRectangle.Width - 16,
                Y = Headlabel.Bottom
            };

            Output = new ConnectionPoint(typeof(ushort));
            Output.Location = pos;
            Output.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            Output.SetColor(COLORVALUE);

            this.Height = Output.Bottom;
            this.Controls.Add(numericUpDown);
            this.Controls.Add(Output);
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
                this.numericUpDown.Value = (ushort)Settings["Value"];
                base.SetSettings();
            }
        }
        public override JObject GetSettings()
        {
            JObject jObject = new JObject();
            jObject.Add("MyType", GetType().ToString());
            jObject.Add("BaseSetting", base.GetSettings());
            jObject.Add("Output", this.Output.GetData);
            jObject.Add("Value", this.numericUpDown.Value);
            return jObject;
        }
        public override object NodeObject(bool validate = false)
        {
            return (ushort)numericUpDown.Value;
        }
    }
}