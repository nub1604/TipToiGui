using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Windows.Forms;
using TipToyGui.OidClasses;

namespace TipToyGui.Nodes
{
    public partial class SpeakNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }
        private ComboBox comboBox;

        public SpeakNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        public SpeakNode(JObject settings) : base(settings)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Speak";

            var pos = new Point()
            {
                X = this.ClientRectangle.Width - 16,
                Y = Headlabel.Bottom
            };

            Output = new ConnectionPoint(typeof(IOIDAction))
            {
                Location = pos
            };
            Output.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            Output.SetColor(COLORACTION);

            comboBox = new ComboBox
            {
                Width = this.Width / 2,
                Location = Headlabel.Underneath()
            };
            comboBox.Items.Clear();

            comboBox.Items.AddRange(MainForm.Project.SpeakObjects.ToArray());
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            this.Height = Output.Bottom;
            this.Controls.Add(comboBox);
            this.Controls.Add(Output);
            this.DoubleClick += (_, __) =>
            {
                var no = NodeObject(true);
                if (no != null && no is IOIDAction oID)
                {
                    RaiseMessageEvent(new MessageEventArgs($"{oID.GetActionString}"));
                }
            };
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
                this.comboBox.SelectedIndex = comboBox.FindString((string)Settings["Value"]);
                base.SetSettings();
            }
        }

        public override JObject GetSettings()
        {
            JObject jObject = new JObject
            {
                { "MyType", GetType().ToString() },
                { "BaseSetting", base.GetSettings() },
                { "Output", this.Output.GetData }
            };
            if (this.comboBox.SelectedItem != null)
                jObject.Add("Value", this.comboBox.SelectedItem.ToString());
            return jObject;
        }

        public override object NodeObject(bool validate = false)
        {
            if (this.comboBox.SelectedItem != null && this.comboBox.SelectedItem is OIDSpeak oIDSpeak)
            {
                return oIDSpeak;
            }
            if (validate)
                Flash(this, 500, Color.Red, 3);
            return null;
        }
    }
}