using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TipToyGui.Nodes;

using static TipToyGui.ConnectionPoint;
using static TipToyGui.Nodes.BaseNode;

namespace TipToyGui
{
    public class NodePanel : PictureBox
    {
        public GraphicalOverlay Overlay;

        //private readonly HScrollBar _HScrollBar;
        //private readonly VScrollBar _VScrollBar;
        private readonly Pen LinePen;

        private Control MouseMovedObject;

        private static ConnectionStateEventArgs State;
        private readonly List<ConnectionPair> connectionPairs = new List<ConnectionPair>();
        private bool isConnectingNodes;
        private Point MouseOffset;

        public bool isLoading;

        private Dictionary<string, Type> Nodes;

        public NodePanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            Overlay = new GraphicalOverlay
            {
                Owner = this
            };

            this.Paint += NodePanel_Paint;
            Overlay.Paint += GraphicalOverlay_Paint;

            AllowDrop = true;
            DragEnter += Panel1_DragEnter;
            DragDrop += Panel1_DragDrop;
            LinePen = new Pen(Color.OrangeRed, 2);

            //_HScrollBar = new HScrollBar();
            //_HScrollBar.ValueChanged += (_, __) =>
            //{
            //    foreach (var c in this.Controls.Cast<Control>().Where(x => x is BaseNode))
            //    {
            //        c.Location = c.Location.SubX(_HScrollBar.Value - LastX);
            //    }
            //    this.Refresh();
            //    LastX = _HScrollBar.Value;
            //};

            //_VScrollBar = new VScrollBar();

            //_VScrollBar.ValueChanged += (_, __) =>
            //{
            //    foreach (var c in this.Controls.Cast<Control>().Where(x => x is BaseNode))
            //    {
            //        c.Location = c.Location.SubY(_VScrollBar.Value - LastY);
            //    }
            //    this.Refresh();
            //    LastY = _VScrollBar.Value;
            //};

            //this.Controls.Add(_HScrollBar);
            //this.Controls.Add(_VScrollBar);

            this.Size = new Size(1000, 1000);

            Nodes = new Dictionary<string, Type>();
        }

        #region Private Methods

        private void ClearBaseObjects()
        {
            connectionPairs.Clear();
            this.Overlay.Refresh();
            var c = Controls.Cast<Control>().Where(x => x is BaseNode).ToArray();
            for (int i = 0; i < c.Length; i++)
            {
                this.Controls.Remove(c[i]);
                if (c[i] != null)
                    c[i].Dispose();
            }
        }

        private void NodePanel_Paint(object sender, PaintEventArgs e)
        {
            float[] dashValues = { 2, 2 };
            Pen blackPen = new Pen(Color.FromArgb(60, 60, 60), 2)
            {
                DashPattern = dashValues
            };

            //var v = _VScrollBar.Value;

            for (int i = 0; i < this.Height; i += 100)
            {
                e.Graphics.DrawLine(blackPen, new Point(0, i), new Point(this.Width, i));
            }

            // var h = _HScrollBar.Value;

            for (int i = 0; i < this.Width; i += 100)
            {
                e.Graphics.DrawLine(blackPen, new Point(i, 0), new Point(i, this.Height));
            }
            //  GraphicalOverlay_Paint(this, e);
        }

        private void NodePanel_Resize(object sender, System.EventArgs e)
        {
            //_HScrollBar.Minimum = 0; _HScrollBar.Maximum = 1000;
            //_HScrollBar.Location = new Point(0, this.Height - _HScrollBar.Height);
            //_HScrollBar.Width = this.Width - _VScrollBar.Width;

            //_VScrollBar.Minimum = 0; _VScrollBar.Maximum = 1000;
            //_VScrollBar.Location = new Point(this.Width - _VScrollBar.Width, 0);
            //_VScrollBar.Height = this.Height - _HScrollBar.Height;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void GraphicalOverlay_Paint(object sender, PaintEventArgs e)
        {
            if (isConnectingNodes && State != null)
            {
                var p1 = PointToClient(State.Sender.PointToScreen(State.Sender.ClientRectangle.Center()));
                var p2 = PointToClient(MousePosition);
                var bez = PointExtensions.CalcBezier(p1, p2, State.Sender.ConnectionType == EnumConnectionType.output, !p1.IsGreaterX(p2));
                e.Graphics.DrawBeziers(LinePen, bez);
            }
            foreach (var c in connectionPairs)
            {
                if (!c.Output.Parent.Visible) continue;

                var input = PointToClient(c.Output.PointToScreen(c.Output.ClientRectangle.Center()));
                var output = PointToClient(c.Input.PointToScreen(c.Input.ClientRectangle.Center()));

                var bez = PointExtensions.CalcBezier(output, input, false, true);
                e.Graphics.DrawBeziers(LinePen, bez);
            }
        }

        private void Panel1_DragEnter(object senderInput, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Move) == 0)
            {
                // Not a Move. Do not allow it.
                e.Effect = DragDropEffects.None;
            }
            else
            {
                OIDRegister drag_item = (OIDRegister)e.Data.GetData(typeof(OIDRegister));
                if (drag_item != null)
                {
                    // Allow it.
                    e.Effect = DragDropEffects.Move;
                    return;
                }
                string di = (string)e.Data.GetData(typeof(string));
                if (di != null)
                {
                    // Allow it.
                    e.Effect = DragDropEffects.Move;
                    return;
                }
            }
        }

        private void Panel1_DragDrop(object sender, DragEventArgs e)
        {
            OIDRegister drag_item = (OIDRegister)e.Data.GetData(typeof(OIDRegister));
            if (drag_item != null)
            {
                AddNode(new RegisterNode(drag_item));
                RaiseUpdatePanelEvent(new EventArgs());
                return;
            }

            string di = (string)e.Data.GetData(typeof(string));
            if (di != null && Nodes.ContainsKey(di))
            {
                AddNode(GetInstance(Nodes[di]));
                RaiseUpdatePanelEvent(new EventArgs());
            }
        }

        private void AddNode(BaseNode bn, JObject jObject = null)
        {
            bn.AllowDrop = true;

            if (jObject == null)
                bn.Location = PointToClient(MousePosition);
            else
            {
                bn.Location = JsonConvert.DeserializeObject<Point>(jObject["BaseSetting"]["Location"].ToString());

                //var t2 = jObject.GetValue("Location").Cast<Point>().FirstOrDefault();
                //bn.Location = t2;
            }
            bn.MouseDown += So_MouseDown;
            bn.MouseMove += So_MouseMove;
            bn.MouseUp += So_MouseUp;
            bn.DragEnter += So_DragEnter;
            bn.OnRaiseMessageEvent += (_, e) => { RaiseMessageEvent(e); };
            bn.OnRaiseFeebackEvent += So_OnRaiseFeebackEvent;
            Controls.Add(bn);
        }

        private void So_DragEnter(object sender, DragEventArgs e)
        {
            var n = (ConnectionPoint)e.Data.GetData(typeof(ConnectionPoint));
            if (n != null)
            {
                OverlayRefresh();
                return;
            }
        }

        private void So_OnRaiseFeebackEvent(object sender, BaseNode.FeebackEventArgs e)
        {
            if (e.Feedback is ConnectionStateEventArgs a)
            {
                switch (a.State)
                {
                    case EnumConnectionState.start: State = a; isConnectingNodes = true; break;
                    case EnumConnectionState.moving: State = a; break;
                    case EnumConnectionState.finished: State = null; isConnectingNodes = false; break;
                    case EnumConnectionState.create:
                        if (a.GetPair != null)
                        {
                            connectionPairs.Add(a.GetPair);
                            //Console.WriteLine($"Input {a.GetPair.Input.ID} Output {a.GetPair.Output.ID}");
                            Actalize();
                        }
                        break;

                    case EnumConnectionState.remove: connectionPairs.RemoveAll(x => x.Input == a.Sender || x.Output == a.Sender); Actalize(); break;
                }

                State = a; Refresh();
            }
        }

        private void Actalize()
        {
            if (!isLoading)
                RaiseUpdatePanelEvent(new EventArgs());
        }

        private void So_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Control c)
            {
                if (MouseMovedObject == c)
                {
                    MouseMovedObject = null;
                    RaiseUpdatePanelEvent(new EventArgs());
                }
            }
        }

        private void So_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Control c)
            {
                if (MouseMovedObject == c)
                {
                    c.Location = PointToClient(MousePosition).Sub(MouseOffset);
                    OverlayRefresh();
                }
            };
        }

        private void So_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Control c)
            {
                if (e.Button == MouseButtons.Right)
                {
                    foreach (var node in c.Controls.Cast<Control>())
                    {
                        if (node is ConnectionPoint n)
                        {
                            n.RemoveConnections();
                        }
                    }
                    Controls.Remove(c);
                    c.Dispose();
                    return;
                }
                else
                {
                    c.BringToFront();
                    if (MouseMovedObject == null)
                    {
                        MouseMovedObject = c;
                        MouseOffset = PointToClient(MousePosition).Sub(c.Location);
                    }
                }
            }
        }

        private void AddBaseNode(JObject jObject)
        {
            if (jObject != null && jObject.TryGetValue("MyType", out JToken value))
            {
                string obj = value.ToString();
                AddNode((BaseNode)GetInstance(obj, jObject), jObject);
            }
        }

        private BaseNode GetInstance(string strFullyQualifiedName, JObject jObject)
        {
            Type t = Type.GetType(strFullyQualifiedName);

            return (BaseNode)Activator.CreateInstance(t, jObject);
        }

        private BaseNode GetInstance(Type t)
        {
            return (BaseNode)Activator.CreateInstance(t);
        }

        #endregion Private Methods

        public void ApplyNewSetup(NodeSetup setup)
        {
            isLoading = true;
            ClearBaseObjects();
            foreach (var s in setup.Setup)
            {
                if (s.ContainsKey("MyType"))
                {
                    AddBaseNode(s);
                }
            }
            List<ConnectionPoint> points = new List<ConnectionPoint>();
            foreach (var c in Controls.Cast<Control>().Where(x => x is BaseNode))
            {
                points.AddRange(c.Controls.Cast<Control>().Where(x => x is ConnectionPoint).Cast<ConnectionPoint>());
            }
            foreach (var c in Controls.Cast<Control>().Where(x => x is BaseNode))
            {
                (c as BaseNode).Reconnect(points.ToArray());
            }
            isLoading = false;
        }

        public void NewNode(string name, Type type)
        {
            Nodes.Add(name, type);
        }

        public string[] GetNodes()
        {
            return Nodes.Keys.ToArray();
        }

        public void OverlayRefresh()
        {
            this.Overlay.Refresh();
        }

        public void ResetNodePositions()
        {
            Point ol = Point.Empty;

            foreach (var control in this.Controls.Cast<Control>().Where(x => x is BaseNode))
            {
                if (control.Left < ol.X) ol.X = control.Left;
                if (control.Top < ol.Y) ol.Y = control.Top;
            }
            ol.X = Math.Abs(ol.X);
            ol.Y = Math.Abs(ol.Y);
            if (ol.X > 0 || ol.Y > 0)
            {
                foreach (var control in this.Controls.Cast<Control>().Where(x => x is BaseNode))
                {
                    control.Location = control.Location.Add(ol);
                }
                this.Refresh();
            }
        }

        #region event Message

        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public event MessageEventHandler OnRaiseMessageEvent;

        protected void RaiseMessageEvent(MessageEventArgs e)
        {
            OnRaiseMessageEvent?.Invoke(this, e);
        }

        #endregion event Message

        #region event UpdatePanel

        public delegate void UpdatePanelEventHandler(object sender, EventArgs e);

        public event UpdatePanelEventHandler OnRaiseUpdatePanelEvent;

        public void RaiseUpdatePanelEvent(EventArgs e)
        {
            OnRaiseUpdatePanelEvent?.Invoke(this, e);
        }

        #endregion event UpdatePanel
    }
}