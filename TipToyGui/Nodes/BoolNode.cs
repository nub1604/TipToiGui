using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TipToyGui.Nodes
{
    public class BoolNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }
        public ConnectionPoint InputA { get; private set; }
        public ConnectionPoint InputB { get; private set; }
   
     

        private ComboBox comboBox;


        public BoolNode(JObject jObject) : base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        public BoolNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Condition";

            comboBox = new ComboBox
            {
                Location = Headlabel.Underneath(),
                Width = this.Width
            };
            comboBox.Items.AddRange(Enum.GetValues(typeof(BoolOperators)).Cast<object>().ToArray());
            comboBox.SelectedIndex = 0;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            Output = new ConnectionPoint(typeof(BoolNode));
            Output.Location = new Point(this.Width - Output.Width, comboBox.Bottom);
            Output.OnConnectionStateChange += (_, e) => { 
                
                base.RaiseFeebackEvent(new FeebackEventArgs(e)); 
            };
            Output.SetColor(COLORCONDITION);

            InputA = new ConnectionPoint(new Type[] { typeof(OIDRegister) })
            {
                Location = new Point(0, comboBox.Bottom)
            };
            InputA.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputA.SetColor(COLORREGISTER);

            HeadLabel l2 = new HeadLabel
            {
                Text = $"Register Only",
                Location = InputA.RightFrom().AddY(2)
            };

            InputB = new ConnectionPoint(new Type[] { typeof(OIDRegister), typeof(ushort) })
            {
                Location = new Point(0, InputA.Bottom)
            };
            InputB.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputB.SetColor(COLORREGVALUE);

            HeadLabel l3 = new HeadLabel
            {
                Text = $"Register, Value",
                Location = InputB.RightFrom().AddY(2)
            };

            this.Height = InputB.Bottom;

            this.Controls.Add(comboBox);
            this.Controls.Add(Output);
            this.Controls.Add(InputA);
            this.Controls.Add(InputB);
            this.Controls.Add(l2);
            this.Controls.Add(l3);

            this.DoubleClick += (_, __) =>
            {
                var no = NodeObject(true); 
                if (no != null && no is IOIDCondition oID)
                {
                    RaiseMessageEvent(new MessageEventArgs($"{oID.GetConditionString}"));
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
            if (oID != null &&  InputB.Connections != null && InputB.Connections.Count > 0 && InputB.Connections[0].Parent is BaseNode b2)
            {
                if (b2.NodeObject() is ushort v)
                {
                    return new OIDConditionValue(oID, (BoolOperators)comboBox.SelectedItem, v);
                }
                else if (b2.NodeObject() is OIDRegister reg2)
                {
                    return new OIDConditionOID(oID, (BoolOperators)comboBox.SelectedItem, reg2);
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

                this.comboBox.SelectedIndex = comboBox.FindString((string)Settings["Operator"]);
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
                { "InputA", this.InputA.GetData },
                { "InputB", this.InputB.GetData },
                { "Operator", this.comboBox.SelectedItem.ToString() }
            };
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