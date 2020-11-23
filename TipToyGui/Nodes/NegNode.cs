using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.OidClasses;

namespace TipToyGui.Nodes
{
    public class NegNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }
        public ConnectionPoint InputA { get; private set; }
 

        public NegNode(JObject jObject) : base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        public NegNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Negate";



            Output = new ConnectionPoint(typeof(IOIDAction));
            Output.Location = new Point(this.Width - Output.Width, Headlabel.Bottom);
            Output.OnConnectionStateChange += (_, e) => { 
                
                base.RaiseFeebackEvent(new FeebackEventArgs(e)); 
            };
            Output.SetColor(COLORACTION);

            InputA = new ConnectionPoint(new Type[] { typeof(OIDRegister) })
            {
                Location = new Point(0, Headlabel.Bottom)
            };
            InputA.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputA.SetColor(COLORREGISTER);

            HeadLabel l2 = new HeadLabel();
            l2.Text = $"Register Only";
            l2.Location = InputA.RightFrom().AddY(2);

            this.Height = InputA.Bottom;
            this.Controls.Add(Output);
            this.Controls.Add(InputA);

            this.Controls.Add(l2);
          

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
            if (oID != null)
            {
                return new OIDNegate(oID);

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
               
            }
        }

        public override void SetSettings()
        {
            if (Settings != null)
            {
                Output.ID = (string)Settings["Output"]["ID"];
                InputA.ID = (string)Settings["InputA"]["ID"];
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
            return jObject;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoolNode
            // 
            this.Name = "BoolNode";
            this.ResumeLayout(false);

        }
    }
}