using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.Nodes;

namespace TipToyGui.Nodes
{
    public partial class RegisterNode : BaseNode
    {
        public ConnectionPoint Output { get; private set; }

        OIDRegister Register;
       

        public RegisterNode(JObject jObject): base(jObject)
        {
            InitializeComponent();
            CreateControlLayout();
            SetSettings();
        }
        public RegisterNode(OIDRegister reg)
        {
            InitializeComponent();


                Headlabel.Text = $"{reg.Name}";
                Register = reg;
            
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            var pos = new Point()
            {
                X = this.ClientRectangle.Width - 16,
                Y = Headlabel.Bottom
            };
            Output = new ConnectionPoint(typeof(OIDRegister));
            Output.Location = pos;
            Output.OnConnectionStateChange += (_, e) => { base.RaiseFeebackEvent(new FeebackEventArgs(e)); };
            Output.SetColor(COLORREGISTER);


            this.DoubleClick += (_, e) =>
            {
                Console.WriteLine(GetSettings());
            };

            this.Height = Output.Bottom;
            this.Controls.Add(Output);
        }

        public override object NodeObject(bool validate = false)
        {
            return Register;
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
                var s = (string)Settings["Register"];
                this.Register = MainForm.Project.oIDRegisters.Where(x => x.Name == s).FirstOrDefault();

                Headlabel.Text = $"{Register.Name}";
                base.SetSettings();
            }
        }

        public override JObject GetSettings()
        {
            JObject jObject = new JObject();
            jObject.Add("MyType", GetType().ToString());
            jObject.Add("BaseSetting", base.GetSettings());
            jObject.Add("Output", this.Output.GetData);
            jObject.Add("Register", this.Register.ToString());
            return jObject;
           
        }
    }
}