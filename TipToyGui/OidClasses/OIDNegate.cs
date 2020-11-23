using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipToyGui.OidClasses
{
    public class OIDNegate : IOIDAction
    {

        private static StringBuilder b = new StringBuilder();
        public OIDRegister SourceNode;

        public OIDNegate(OIDRegister sourceNode)
        {
            SourceNode = sourceNode ?? throw new ArgumentNullException(nameof(sourceNode));
        }

        private string createString()
        {
            b.Clear();
            b.Append(" Neg($r_");
            b.Append(SourceNode.ToString());
            b.Append(")");
            return b.ToString();
        }
        public string GetActionString => createString();
    }
}
