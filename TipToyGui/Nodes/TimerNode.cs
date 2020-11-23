using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TipToyGui.Nodes
{
    public partial class TimerNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }
        public ConnectionPoint InputA { get; private set; }
        public ConnectionPoint InputB { get; private set; }


        public TimerNode(JObject jObject) : base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        public TimerNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Timer";

            Output = new ConnectionPoint(typeof(IOIDAction));
            Output.Location = new Point(this.Width - Output.Width, Headlabel.Bottom);
            Output.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            Output.SetColor(COLORACTION);

            InputA = new ConnectionPoint(new Type[] { typeof(OIDRegister) });
            InputA.Location = new Point(0, Headlabel.Bottom);
            InputA.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputA.SetColor(COLORREGISTER);

            HeadLabel l2 = new HeadLabel();
            l2.Text = $"Register Only";
            l2.Location = InputA.RightFrom().AddY(2);

            InputB = new ConnectionPoint(new Type[] { typeof(ushort) });
            InputB.Location = new Point(0, InputA.Bottom);
            InputB.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputB.SetColor(COLORVALUE);

            HeadLabel l3 = new HeadLabel();
            l3.Text = $"Register, Value";
            l3.Location = InputB.RightFrom().AddY(3);

            this.Height = InputB.Bottom;
            this.Controls.Add(l2);
            this.Controls.Add(l3);
          
            this.Controls.Add(Output);
            this.Controls.Add(InputA);
            this.Controls.Add(InputB);

            this.DoubleClick += (_, __) =>
            {
                var no = NodeObject(true);
                if (no != null && no is IOIDAction oID)
                {
                    RaiseMessageEvent(new MessageEventArgs($"{oID.GetActionString}"));
                }
            };
        }

        public override object NodeObject(bool validate = false)
        {
           
            OIDRegister oID = null;
            if (InputA.Connections != null && InputA.Connections.Count > 0 && InputA.Connections[0].Parent is BaseNode b1 && b1.NodeObject() is OIDRegister reg)
            {
                oID = reg;
            }

            if (oID != null && InputB.Connections != null && InputB.Connections.Count > 0 && InputB.Connections[0].Parent is BaseNode b2)
            {
                if (b2.NodeObject() is ushort v)
                {
                    
                    return new OIDTimer(oID, v);
                }

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
                InputA.Connect(connectionPoints, Settings["InputA"]["Connections"]);
                InputB.Connect(connectionPoints, Settings["InputB"]["Connections"]);

            }
        }

        public override void SetSettings()
        {
            if (Settings != null)
            {
                Output.ID = (string)Settings["Output"]["ID"];
                InputA.ID = (string)Settings["InputA"]["ID"];
                InputB.ID = (string)Settings["InputB"]["ID"];
                
                base.SetSettings();
            }
        }

        public override JObject GetSettings()
        {
            JObject jObject = new JObject();
            jObject.Add("MyType", GetType().ToString());
            jObject.Add("BaseSetting", base.GetSettings());
            jObject.Add("Output", this.Output.GetData);
            jObject.Add("InputA", this.InputA.GetData);
            jObject.Add("InputB", this.InputB.GetData);
          
            return jObject;
        }
    }
}