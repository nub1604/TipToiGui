using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TipToyGui.Dialogs;

namespace TipToyGui.Nodes
{
    public class BaseNode : UserControl
    {
        public static Color COLORCONDITION = Color.SaddleBrown;
        public static Color COLORACTION = Color.HotPink;
        public static Color COLORREGISTER = Color.LightGoldenrodYellow;
        public static Color COLORREGVALUE = Color.Green;
        public static Color COLORVALUE = Color.Blue;
        public static Color COLORAUDIO = Color.Aquamarine;

        public HeadLabel Headlabel { get; private set; }
        private ToolTip TTComment = new ToolTip();
        private Button BtnComment;
        private string Comment;

        private Button BtnVisible;
        public bool VisibleDirection = true;

        public JObject Settings { get; private set; }

        private Color back;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public BaseNode()
        {
            CreateControlLayout();
        }

        public BaseNode(JObject settings)
        {
            if (settings != null)
            {
                Settings = settings;
            }
            CreateControlLayout();
        }

        private void CreateControlLayout()
        {
            this.Headlabel = new HeadLabel();

            back = Color.FromArgb(51, 51, 55);
            this.BackColor = back;
            this.ForeColor = Color.White;

            this.Headlabel.BackColor = Color.FromArgb(66, 66, 77);
            this.Headlabel.Text = "BaseNode";
            this.Headlabel.Width = this.Width;
            this.BtnComment = new Button()
            {
                Size = new Size(this.Headlabel.Height, Headlabel.Height),
                Location = this.Headlabel.RightFrom().SubX(this.Headlabel.Height),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(77, 77, 88),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
            };
            BtnComment.Click += (_, __) =>
            {
                using (var fcomment = new FrmComment(Comment))
                {
                    if (fcomment.ShowDialog() == DialogResult.OK)
                    {
                        this.Comment = fcomment.Comment;
                        if (this.Parent is NodePanel bp)
                            bp.RaiseUpdatePanelEvent(new EventArgs());
                    }
                }
            };

            this.BtnVisible = new Button()
            {
                Size = new Size(this.Headlabel.Height, Headlabel.Height),
                Location = this.Headlabel.RightFrom().SubX(this.Headlabel.Height * 2),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(77, 77, 88),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
            };

            BtnVisible.Click += (_, __) =>
            {
                VisibleDirection = !VisibleDirection;
                SwitchVisible();
                if (this.Parent is NodePanel bp)
                    bp.RaiseUpdatePanelEvent(new EventArgs());
            };

            this.MouseHover += (_, __) =>
            {
                TTComment.SetToolTip(this, Comment);
            };
            TTComment.Popup += (_, e) =>
            {
                //Todo: Wrap Lines;
            };

            this.Resize += (_, __) =>
            {
                this.Headlabel.Width = this.Width;
                this.BtnComment.Location = this.Headlabel.RightFrom().SubX(this.Headlabel.Height);
            };

            this.Controls.Add(Headlabel);
            this.Headlabel.Controls.Add(BtnComment);
            this.Headlabel.Controls.Add(BtnVisible);
        }

        public void SwitchVisible()
        {
            foreach (var c in Controls.Cast<Control>().Where(x => x is ConnectionPoint))
            {
                if (c is ConnectionPoint input && input.ConnectionType == ConnectionPoint.EnumConnectionType.input)
                {
                    foreach (var output in input.Connections)
                    {
                        if (output.Parent is BaseNode b)
                        {
                            b.Visible = VisibleDirection;
                            b.VisibleDirection = VisibleDirection;
                            b.SwitchVisible();
                        }
                    }
                }
            }
            if (Parent is NodePanel np)
            {
                np.OverlayRefresh();
            }
        }

        private bool AreAllConnectionsInvisible(ConnectionPoint output)
        {
            foreach (var inputs in output.Connections)
            {
                if (inputs.Parent is BaseNode b)
                {
                    if (b.Visible) return false;
                }
            }
            return true;
        }

        public virtual JObject GetSettings()
        {
            JObject jObject = new JObject
            {
                { "Location", JsonConvert.SerializeObject(Location) },
                { "Comment", Comment },
                { "Size", JsonConvert.SerializeObject(Size) },
                { "Visible", Visible },
                { "VisibleDir", VisibleDirection }
            };

            return jObject;
        }

        public virtual void SetSettings()
        {
            if (Settings != null)
            {
                JObject jObject = Settings["BaseSetting"] as JObject;
                if (jObject.ContainsKey("Comment"))
                    Comment = (string)Settings["BaseSetting"]["Comment"];

                if (jObject.ContainsKey("VisibleDir"))
                    VisibleDirection = (bool)Settings["BaseSetting"]["VisibleDir"];
                if (jObject.ContainsKey("Visible"))
                    Visible = (bool)Settings["BaseSetting"]["Visible"];
            }
        }

        public virtual void Reconnect(ConnectionPoint[] connectionPoints)
        {
        }

        public virtual object NodeObject(bool validate = false)
        {
            return "";
        }

        #region event Mouse

        public delegate void FeebackEventHandler(object sender, FeebackEventArgs e);

        public event FeebackEventHandler OnRaiseFeebackEvent;

        public class FeebackEventArgs : EventArgs
        {
            public FeebackEventArgs(object f)
            {
                feedback = f;
            }

            private readonly object feedback;

            public object Feedback
            {
                get { return feedback; }
            }
        }

        protected void RaiseFeebackEvent(FeebackEventArgs e)
        {
            OnRaiseFeebackEvent?.Invoke(this, e);
        }

        #endregion event Mouse

        #region event Message

        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public event MessageEventHandler OnRaiseMessageEvent;

        public class MessageEventArgs : EventArgs
        {
            public MessageEventArgs(string message)
            {
                _Message = message;
            }

            private readonly string _Message;

            public string Message
            {
                get { return _Message; }
            }
        }

        protected void RaiseMessageEvent(MessageEventArgs e)
        {
            OnRaiseMessageEvent?.Invoke(this, e);
        }

        #endregion event Message

        public void Flash(Control control, int interval, Color color, int flashes)
        {
            new Thread(() => FlashInternal(control, interval, color, flashes)).Start();
        }

        private delegate void UpdateTextboxDelegate(Control control, Color originalColor);

        public void UpdateTextbox(Control control, Color color)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateTextboxDelegate(UpdateTextbox), new object[] { control, color });
            }
            control.BackColor = color;
        }

        private void FlashInternal(Control control, int interval, Color flashColor, int flashes)
        {
            try
            {
                Color original = control.BackColor;
                for (int i = 0; i < flashes; i++)
                {
                    UpdateTextbox(control, flashColor);
                    Thread.Sleep(interval / 2);
                    UpdateTextbox(control, back);
                    Thread.Sleep(interval / 2);
                }
            }
            catch
            {
            }
        }
    }
}