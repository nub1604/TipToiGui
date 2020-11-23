using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipToyGui.Nodes;

namespace TipToyGui.OidClasses
{
    public class OIDActionJump : IOIDAction
    {

        private static StringBuilder b = new StringBuilder();

        public NodeSetup Value;
        public OIDActionJump(NodeSetup value)
        {
            Value = value;
        }

        private string createString()
        {
            b.Clear();
            b.Append(" J(");
            b.Append(Value.ToString());
            b.Append(")");
            return b.ToString();
        }

        public string GetActionString => createString();
    }
}
