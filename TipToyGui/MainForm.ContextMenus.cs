using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipToyGui.Dialogs;
using TipToyGui.Nodes;

namespace TipToyGui
{
    public partial class MainForm
    {
        private void InitContextMenues()
        {
            var MenuOidNodes = new ContextMenu();
            MenuOidNodes.MenuItems.Add("New", (_, __) =>
            {
                if (Project == null) return;
                using (var f = new FrmNodes(Project.nodeSetups.ToArray()))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Project.nodeSetups.Add(new NodeSetup(f.Result));
                        RefreshNodes();
                    }
                }
            });
            MenuOidNodes.MenuItems.Add("Edit", (_, __) =>
            {
                if (Project == null) return;
                if (lbOidCodes.SelectedItem != null)
                    using (var f = new FrmNodes(Project.nodeSetups.ToArray(), Project.nodeSetups[lbOidCodes.SelectedIndex]))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            Project.nodeSetups[lbOidCodes.SelectedIndex] = (f.Result);
                            RefreshNodes();
                        }
                    }
            });
            MenuOidNodes.MenuItems.Add("Delete", (_, __) =>
            {
                if (Project == null) return;
                if (lbOidCodes.SelectedItem != null)
                {
                    List<SceneOid> sceneOids = new List<SceneOid>(); ;
                    if (Project.Scenes != null && Project.Scenes.Count > 0)
                    {
                        foreach (var scene in Project.Scenes)
                        {
                            sceneOids.AddRange(scene.SceneOids.Where(x => x.SetupName == lbOidCodes.SelectedItem.ToString()).ToList());
                        }
                    }

                    string existingSceneOids = sceneOids != null && sceneOids.Count > 0 ? ", Some scenes contains this OID polygons" : "";
                    if (MessageBox.Show(this, $"Delete {lbOidCodes.SelectedItem}{existingSceneOids}", "Delete Oid", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Project.nodeSetups.RemoveAt(lbOidCodes.SelectedIndex);
                        if (Project.Scenes != null && Project.Scenes.Count > 0)
                        {
                            foreach (var scene in Project.Scenes)
                            {
                                scene.SceneOids.RemoveAll(x => x.SetupName == lbOidCodes.SelectedItem.ToString());
                            }
                        }
                        RefreshNodes();
                    }
                }
            });


            var MenuOidRegister = new ContextMenu();
            MenuOidRegister.MenuItems.Add("New", (_, __) =>
            {
                if (Project == null) return;
                using (var f = new frmRegister(Project.oIDRegisters.ToArray(), null))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Project.oIDRegisters.Add(f.Result);
                        RefreshOid();
                    }
                }
            });
            MenuOidRegister.MenuItems.Add("Edit", (_, __) =>
            {
                if (Project == null) return;
                if (lbRegister.SelectedItem != null)
                    using (var f = new frmRegister(Project.oIDRegisters.ToArray(), Project.oIDRegisters[lbRegister.SelectedIndex]))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {

                            RenameRegister(Project.oIDRegisters[lbRegister.SelectedIndex], f.Result);
                            Project.oIDRegisters[lbRegister.SelectedIndex] = (f.Result);

                            RefreshOid();
                            if (selectedOidNode != null)
                                LoadSetup(selectedOidNode);
                        }
                    }
            });
            MenuOidRegister.MenuItems.Add("Delete", (_, __) =>
            {
                if (Project == null) return;
                if (lbRegister.SelectedItem != null)
                    if (MessageBox.Show(this, $"Delete {lbRegister.SelectedItem}", "Delete Register", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteRegister(Project.oIDRegisters[lbRegister.SelectedIndex]);

                        Project.oIDRegisters.Remove(Project.oIDRegisters[lbRegister.SelectedIndex]);
                        RefreshOid();
                        if (selectedOidNode != null)
                            LoadSetup(selectedOidNode);

                    }
            });

            lbOidCodes.ContextMenu = MenuOidNodes;
            lbRegister.ContextMenu = MenuOidRegister;
        }
        private void RenameRegister(OIDRegister old, OIDRegister newreg)
        {
            foreach (var item in Project.nodeSetups)
            {
                var s = typeof(RegisterNode).ToString();
                var token = item.Setup.Where(x => x.ContainsKey("MyType") && x["MyType"].ToString() == s).ToList();
                foreach (var t in token)
                {
                    if (t.ContainsKey("Register") && t["Register"].ToString() == old.Name)
                        t["Register"] = newreg.Name;
                }
            }

        }
        private void DeleteRegister(OIDRegister oIDRegister)
        {
            foreach (var item in Project.nodeSetups)
            {
                var s = typeof(RegisterNode).ToString();
                var token = item.Setup.Where(x => x.ContainsKey("MyType") && x["MyType"].ToString() == s)
                    .Where(y => y.ContainsKey("Register") && y["Register"].ToString() == oIDRegister.Name).ToList();
                for (int i = 0; i < token.Count; i++)
                {
                    item.Setup.Remove(token[i]);
                }
            }
        }
    }
}
