using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.OidClasses;

namespace TipToyGui.Nodes
{
    public partial class MediaNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }
        private ComboBox comboBox;
       

        public MediaNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        public MediaNode(JObject settings) : base(settings)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Media";

            if (MainForm.Project != null)
            {

            }

            comboBox = new ComboBox
            {
                Location = Headlabel.Underneath(),
                Width = this.Width / 2

            };
            comboBox.Items.AddRange(MainForm.Project.MediaFiles.ToArray());
                  
           

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            if (comboBox.Items.Count > 0)
            comboBox.SelectedIndex = 0;

            var pos = new Point()
            {
                X = this.ClientRectangle.Width - 16,
                Y = Headlabel.Bottom
            };

            Output = new ConnectionPoint(typeof(IOIDAction));
            Output.Location = pos;
            Output.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            Output.SetColor(COLORACTION);

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
            JObject jObject = new JObject();
            jObject.Add("MyType", GetType().ToString());
            jObject.Add("BaseSetting", base.GetSettings());
            jObject.Add("Output", this.Output.GetData);
            if (this.comboBox.SelectedItem != null)
            jObject.Add("Value", this.comboBox.SelectedItem.ToString());
            return jObject;
        }

        public override object NodeObject(bool validate = false)
        {
           

            if (this.comboBox.SelectedItem != null)
            {
                return new OIDMedia((MediaFile)this.comboBox.SelectedItem); 
            }
            if (validate)
                Flash(this, 500, Color.Red, 3);
            return null;


        }
    }
}