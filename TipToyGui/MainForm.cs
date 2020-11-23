using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TipToyGui.Nodes;

namespace TipToyGui
{
    public partial class MainForm : Form
    {
        public static OIDProject Project;
        private OIDRegister SelectdRegister;

        private NodeSetup selectedOidNode;
        private NodeSetup actualOidNode;

        private void TempSetup()
        {
            if (Project != null)
            {
                Project.nodeSetups.Add(new NodeSetup(1000, "FirstNode"));
                Project.oIDRegisters.Add(new OIDRegister(0, "Hallo"));
                Project.oIDRegisters.Add(new OIDRegister(1, "World"));
                RefreshNodes();
                RefreshOid();
                lbOidCodes.SelectedIndex = 0;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitContextMenues();
            lbFunctions.MouseDown += LbFunctions_MouseDown;
            lbOidCodes.SelectedIndexChanged += LbOidCodes_SelectedIndexChanged;

            nodePanel1.OnRaiseMessageEvent += (_, e) =>
            {
                tbStatusLabel.Text = e.Message;
                Flash(tbStatusLabel, 500, Color.Green, 5);
            };
            nodePanel1.OnRaiseUpdatePanelEvent += (_, e) =>
            {
                if (lbOidCodes.SelectedIndex != -1)
                {
                    Console.WriteLine("OnRaiseUpdatePanelEvent");
                    SaveActualSetup();
                    //saveProjectToolStripMenuItem.PerformClick();
                }
            };
            nodePanel1.NewNode("Value", typeof(ValueNode));
            nodePanel1.NewNode("Sequence", typeof(SequenceNode));
            nodePanel1.NewNode("SequenceText", typeof(TextSequenceNode));
            nodePanel1.NewNode("Condition", typeof(BoolNode));
            nodePanel1.NewNode("Manipulation", typeof(ManipulationNode));
            nodePanel1.NewNode("Negate", typeof(NegNode));
            nodePanel1.NewNode("Jump", typeof(JumpNode));
            nodePanel1.NewNode("Media", typeof(MediaNode));
            nodePanel1.NewNode("Speak", typeof(SpeakNode));
            nodePanel1.NewNode("Timer", typeof(TimerNode));

            RefreshRecentItems();

            lbFunctions.Items.AddRange(nodePanel1.GetNodes());
        }

        private void RefreshRecentItems()
        {
            MenuRecent.DropDownItems.Clear();
            foreach (var item in TTGRegistry.GetRecentProjectPath())
            {
                var mi = new ToolStripMenuItem(item);
                mi.Click += (_, __) =>
                {
                    Project = OIDProject.Load(item);
                    RefreshNodes();
                    RefreshOid();

                    if (lbOidCodes.Items != null && lbOidCodes.Items.Count > 0)
                        lbOidCodes.SelectedIndex = 0;
                };
                MenuRecent.DropDownItems.Add(mi);
            }
        }

        private void RefreshOid()
        {
            if (Project == null) return;
            lbRegister.Items.Clear();
            foreach (var reg in Project.oIDRegisters)
            {
                lbRegister.Items.Add(reg.Name);
            }
        }

        private void RefreshNodes()
        {
            if (Project == null) return;
            int sel = lbOidCodes.SelectedIndex;
            lbOidCodes.Items.Clear();
            foreach (var reg in Project.nodeSetups)
            {
                lbOidCodes.Items.Add(reg);
            }
            if (lbOidCodes.Items.Count > sel)
            {
                lbOidCodes.SelectedIndex = sel;
            }
            else
            {
                if (lbOidCodes.Items.Count > 0)
                {
                    lbOidCodes.SelectedIndex = 0;
                }
            }
        }

        private void LbOidCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Project == null) return;
            selectedOidNode = Project.nodeSetups.Where(x => x.Name == lbOidCodes.SelectedItem.ToString()).FirstOrDefault();
            if (actualOidNode != null)
            {
                SaveActualSetup();
            }
            if (selectedOidNode != actualOidNode)
            {
                LoadSetup(selectedOidNode);
            }

            actualOidNode = selectedOidNode;
        }

        private void SaveActualSetup()
        {
            actualOidNode.Setup.Clear();
            foreach (var c in nodePanel1.Controls.Cast<Control>().Where(x => x is BaseNode))
            {
                actualOidNode.Setup.Add((c as BaseNode).GetSettings());
            }
            var seqlist = nodePanel1.Controls.Cast<Control>().Where(x => x is IPriority).ToList().OrderBy(x => (x as IPriority).Prio);
            actualOidNode.Node = new OIDNode(actualOidNode);
            foreach (var seq in seqlist)
            {
                if ((seq as BaseNode).NodeObject() is OIDSequence s)
                    actualOidNode.Node.AddSequece(s);
                if ((seq as BaseNode).NodeObject() is OIDTextSequence ts)
                    actualOidNode.Node.AddSequece(ts);
            }
        }

        private void LoadSetup(NodeSetup nodeSetup)
        {
            if (nodeSetup == null) return;
            nodePanel1.ApplyNewSetup(nodeSetup);
        }

        private OIDRegister GetByString(string name)
        {
            var res = Project.oIDRegisters.Where(x => x.Name == name).FirstOrDefault();
            if (res == null) throw new ArgumentNullException($" \"{name}\" is not a member!");
            return res;
        }

        private void LbRegister_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Project == null) return;
                SelectdRegister = null;

                if (lbRegister.Items.Count == 0)
                {
                    return;
                }

                int index = lbRegister.IndexFromPoint(e.X, e.Y);
                if (index > -1)
                {
                    string s = lbRegister.Items[index].ToString();
                    SelectdRegister = GetByString(s);

                    lbRegister.DoDragDrop(SelectdRegister, DragDropEffects.Move);
                }
            }
        }

        private void LbFunctions_MouseDown(object sender, MouseEventArgs e)
        {
            if (Project == null) return;
            SelectdRegister = null;

            if (lbFunctions.Items.Count == 0)
            {
                return;
            }

            int index = lbFunctions.IndexFromPoint(e.X, e.Y);
            if (index > -1)
            {
                string s = lbFunctions.Items[index].ToString();

                lbFunctions.DoDragDrop(s, DragDropEffects.Move);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                if (Project != null)
                {
                    Project.Save();

                    RefreshRecentItems();
                    return true;
                }
                else
                    return false;
            }
            if (keyData == (Keys.Control | Keys.N))
            {
                newProjectToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.P))
            {
                tsProjectSettings.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.L))
            {
                if (MenuRecent.DropDownItems.Count > 0)
                {
                    MenuRecent.DropDownItems[0].PerformClick();
                    return true;
                }
                else
                    return false;
            }
            if (keyData == (Keys.Control | Keys.O))
            {
                if (Project != null && lbOidCodes.SelectedItem != null)
                {
                    nodePanel1.ResetNodePositions();
                }
            }

            if (keyData == (Keys.Control | Keys.G))
            {
                createGMEToolStripMenuItem.PerformClick();
            }
            if (keyData == (Keys.Control | Keys.J))
            {
                createYamlToolStripMenuItem.PerformClick();
            }

            if (keyData == (Keys.F6))
            {
                if (Project != null)
                {
                    speakEditorToolStripMenuItem.PerformClick();
                }
            }
            if (keyData == (Keys.F7))
            {
                if (Project != null)
                {
                    graphicEditorToolStripMenuItem.PerformClick();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

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
            control.ForeColor = color;
        }

        private void FlashInternal(Control control, int interval, Color flashColor, int flashes)
        {
            try
            {
                Color original = control.ForeColor;
                for (int i = 0; i < flashes; i++)
                {
                    UpdateTextbox(control, flashColor);
                    Thread.Sleep(interval / 2);
                    UpdateTextbox(control, original);
                    Thread.Sleep(interval / 2);
                }
            }
            catch
            {
            }
        }
    }
}