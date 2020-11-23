using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TipToyGui
{
    public partial class ConnectionPoint : UserControl
    {
        private string Id;

        private bool isConnecting;
        public EnumConnectionType ConnectionType { get; private set; }

        public bool Multiinput { get; private set; }
        ToolTip tt;
        public List<ConnectionPoint> Connections { get; private set; }
        public Type OutputObject { get; private set; }
        public Type[] AllowedTypes { get; private set; }

        private readonly Pen CirclePen = new Pen(Color.Black, 2);

        public void SetColor(Color color)
        {
            CirclePen.Color = color;
        }

        public string ID { get => Id; set => Id = value; }

        public string[] GetConnectedID
        {
            get
            {
                return Connections.Select(x => x.ID).ToArray();
            }
        }

        public JObject GetData
        {
            get
            {
                JObject data = new JObject();
                data.Add("ID", Id);
                data.Add("Connections", JsonConvert.SerializeObject(GetConnectedID));

                return data;
            }
        }

        public bool OverrideID(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                this.Id = id;
                return true;
            }
            return false;
        }

        public ConnectionPoint(Type MyObject)
        {
            ConnectionType = EnumConnectionType.output;
            OutputObject = MyObject;
            Init();
        }

        public ConnectionPoint(Type[] allowedTypes, bool multiInput = false)
        {
            ConnectionType = EnumConnectionType.input;
            AllowedTypes = allowedTypes;
            Init();
            Multiinput = multiInput;
        }

        private void Init()
        {
            InitializeComponent();
            AllowDrop = true;
            Connections = new List<ConnectionPoint>();
            Id = Guid.NewGuid().ToString();

            //All Event for Connection Circle
            Paint += Connection_Paint;
            GiveFeedback += (_, __) =>
            {
                if (MouseButtons == MouseButtons.None)
                {
                    RaiseConnectionStateEvent(new ConnectionStateEventArgs(this, EnumConnectionState.finished)); isConnecting = false;
                }

                if (isConnecting)
                {
                    RaiseConnectionStateEvent(new ConnectionStateEventArgs(this, EnumConnectionState.moving));
                }
            };
            MouseDoubleClick += Connection_MouseDoubleClick;
            QueryContinueDrag += (sender, e) =>
            {
                if (MouseButtons != MouseButtons.Left)
                {
                    e.Action = DragAction.Drop;
                    if (isConnecting)
                    {
                        RaiseConnectionStateEvent(new ConnectionStateEventArgs(this, EnumConnectionState.finished)); isConnecting = false;
                    }
                }
            };
            MouseMove += (sender, e) =>
            {
                if (sender != null && e.Button == MouseButtons.Left)
                {
                    if (!isConnecting)
                    {
                        isConnecting = true;
                        RaiseConnectionStateEvent(new ConnectionStateEventArgs(this, EnumConnectionState.start));
                        this.DoDragDrop(this, DragDropEffects.Move);
                    }
                }
            };
            DragEnter += (_, e) =>
            {
                if ((e.AllowedEffect & DragDropEffects.Move) == 0)
                {
                    // Not a Move. Do not allow it.
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    // Get the DragItem.
                    ConnectionPoint drag_item = (ConnectionPoint)e.Data.GetData(typeof(ConnectionPoint));
                    if (drag_item != null)
                    {
                        // Allow it.
                        e.Effect = DragDropEffects.Move;
                    }
                }
            };
            DragDrop += Panel1_DragDrop;

            MouseHover += (_, e) => { tt = new ToolTip(); tt.SetToolTip(this, ID.ToString()); };
        }

        private void Panel1_DragDrop(object sender, DragEventArgs arg)
        {
            var c = (ConnectionPoint)arg.Data.GetData(typeof(ConnectionPoint));
            Connect(c);
        }

        
        public void Connect(ConnectionPoint[] connectionPoints, JToken guids)
        {
            if (guids == null) return;
            var g = JsonConvert.DeserializeObject<string[]>(guids.ToString());

            foreach (var item in g)
            {
                var cp = connectionPoints.Where(x => x.ID == (string)item).FirstOrDefault();
                Connect(cp);
            }
        }

        private void Connect(ConnectionPoint c)
        {
            if (c != null && c != this && !Connections.Contains(c))
            {
                if (this.ConnectionType != c.ConnectionType)
                {
                    if (this.ConnectionType == EnumConnectionType.input)
                    {
                        if (!CanConnect(c, this)) return;
                    }
                    else
                    {
                        if (!CanConnect(this, c)) return;
                    }

                    var i = this.ConnectionType == EnumConnectionType.input ? this : c;
                    var o = this.ConnectionType == EnumConnectionType.output ? this : c;
                    Connections.Add(c);
                    c.Connections.Add(this);
                    RaiseConnectionStateEvent(new ConnectionStateEventArgs(this, EnumConnectionState.create, new ConnectionPair(i, o)));
                }
            }
        }

        private bool CanConnect(ConnectionPoint output, ConnectionPoint input)
        {
            if (!input.Multiinput && input.Connections.Count == 1)
            {
                return false;
            }

            var obj = output.OutputObject;
            if (!input.AllowedTypes.Contains(obj))
            {
                return false;
            }
            return true;
        }

        #region event

        public delegate void ConnectionStateEventHandler(object sender, ConnectionStateEventArgs e);

        public event ConnectionStateEventHandler OnConnectionStateChange;

        public class ConnectionStateEventArgs : EventArgs
        {
            public ConnectionStateEventArgs(ConnectionPoint source, EnumConnectionState s, ConnectionPair pair = null)
            {
                state = s;
                sender = source;
                _Pair = pair;
            }

            private readonly EnumConnectionState state;
            private readonly ConnectionPoint sender;
            private readonly ConnectionPair _Pair;

            public EnumConnectionState State
            {
                get { return state; }
            }

            public ConnectionPoint Sender
            {
                get { return sender; }
            }

            public ConnectionPair GetPair
            {
                get { return _Pair; }
            }
        }

        public enum EnumConnectionState
        {
            start,
            moving,
            finished,
            create,
            remove
        }

        protected void RaiseConnectionStateEvent(ConnectionStateEventArgs e)
        {
            OnConnectionStateChange?.Invoke(this, e);
        }

        #endregion event

        private void Connection_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RemoveConnections();
        }

        public void RemoveConnections()
        {
            foreach (var c in Connections)
            {
                c.Connections.Remove(this);
            }
            Connections.Clear();
            RaiseConnectionStateEvent(new ConnectionStateEventArgs(this, EnumConnectionState.remove));
        }

        private void Connection_Paint(object sender, PaintEventArgs e)
        {
            var pos = new Point()
            {
                X = 0,
                Y = this.ClientRectangle.Height / 2 - 8
            };
            if (Connections != null && Connections.Count > 0)
            {
                e.Graphics.FillEllipse(Brushes.OrangeRed, pos.X + 4, pos.Y + 4, 8, 8);
            }
            e.Graphics.DrawEllipse(CirclePen, pos.X, pos.Y, 16, 16);
        }

        public enum EnumConnectionType
        {
            input, output
        }
    }
}