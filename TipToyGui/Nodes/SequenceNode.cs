using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TipToyGui.Nodes
{
    public partial class SequenceNode : BaseNode, IPriority
    {
        public ConnectionPoint InputConditions { get; private set; }
        public ConnectionPoint InputActions { get; private set; }

        public int prio;
        public int Prio { get => prio; set => prio = value; }

        private TextBox nud;

        public SequenceNode(JObject jObject) : base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }

        public SequenceNode()
        {
            InitializeComponent();
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            Headlabel.Text = $"Sequence";

            InputConditions = new ConnectionPoint(new Type[] { typeof(BoolNode) }, true);
            InputConditions.Location = Headlabel.Underneath().AddY(2);
            InputConditions.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputConditions.SetColor(COLORCONDITION);

            HeadLabel labelInputConditions = new HeadLabel(); labelInputConditions.Location = InputConditions.RightFrom().AddY(3);
            labelInputConditions.Text = $"Conditions";

            InputActions = new ConnectionPoint(new Type[] { typeof(IOIDAction) }, true);
            InputActions.Location = InputConditions.Underneath().AddY(2);
            InputActions.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            InputActions.SetColor(COLORACTION);
            HeadLabel labelInputActions = new HeadLabel(); labelInputActions.Location = InputActions.RightFrom().AddY(3); ;
            labelInputActions.Text = $"Actions";

            this.Height = InputActions.Underneath().AddY(2).Y;

            nud = new TextBox();
            nud.BorderStyle = BorderStyle.FixedSingle;

            nud.Location = new Point(labelInputConditions.Right, Headlabel.Bottom);
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

            this.Controls.Add(InputConditions);
            this.Controls.Add(labelInputConditions);
            this.Controls.Add(InputActions);
            this.Controls.Add(labelInputActions);
            this.Controls.Add(nud);

            Headlabel.Width = this.Width;
            this.DoubleClick += (_, __) =>
            {
                var no = NodeObject(true);
                if (no != null && no is OIDSequence oID)
                {
                    RaiseMessageEvent(new MessageEventArgs($"test {oID.GetSequenceString()}"));
                }
            };
        }

        private bool IsAllDigits(string s) => s.All(char.IsDigit);

        public override object NodeObject(bool validate = false)
        {
            OIDSequence seq = new OIDSequence();
            bool childvalidation = true;
            bool conditionAvailable = true;
            bool actionAvailable = true;

            if (InputConditions.Connections != null && InputConditions.Connections.Count > 0)
            {
                foreach (var con in InputConditions.Connections)
                {
                    if (con.Parent is BaseNode b && b.NodeObject() is IOIDCondition condition)
                    {
                        seq.oIDConditions.Add(condition);
                    }
                    else
                    {
                        childvalidation = false;
                    }
                }
            }
            else
            {
                conditionAvailable = false;
            }

            if (InputActions.Connections != null && InputActions.Connections.Count > 0)
            {
                foreach (var con in InputActions.Connections)
                {
                    if (con.Parent is BaseNode b && b.NodeObject() is IOIDAction action)
                    {
                        seq.oIDActions.Add(action);
                    }
                    else
                    {
                        childvalidation = false;
                    }
                }
            }
            else
            {
                actionAvailable = false;
            }

            if (childvalidation && (conditionAvailable || actionAvailable))
            {
                return seq;
            }
            else
            {
                if (validate)
                    Flash(this, 500, Color.Red, 3);
            }

            return null;
        }

        public override void Reconnect(ConnectionPoint[] connectionPoints)
        {
            if (Settings != null)
            {
                InputConditions.Connect(connectionPoints, Settings["InputCon"]["Connections"]);
                InputActions.Connect(connectionPoints, Settings["InputAct"]["Connections"]);
            }
        }

        public override void SetSettings()
        {
            if (Settings != null)
            {
                InputConditions.ID = (string)Settings["InputCon"]["ID"];
                InputActions.ID = (string)Settings["InputAct"]["ID"];

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
            jObject.Add("InputCon", this.InputConditions.GetData);
            jObject.Add("InputAct", this.InputActions.GetData);
            jObject.Add("prio", prio);
            return jObject;
        }
    }
}