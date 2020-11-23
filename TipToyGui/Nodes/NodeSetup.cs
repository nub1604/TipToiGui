using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipToyGui.Nodes
{
    public class NodeSetup : OIDRegister
    {
        public NodeSetup() { Setup = new List<JObject>(); }

        public NodeSetup(ushort oid, string name) : base(oid, name)
        {
            Setup = new List<JObject>();
        }

        public NodeSetup(NodeSetup setup) : base(setup.OID, setup.Name)
        {
            Setup = new List<JObject>();
        }

        //public string SetupJson { get; set; }

        public OIDNode  Node {get; set;}

        public List<JObject> Setup { get; private  set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
