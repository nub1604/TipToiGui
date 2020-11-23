using System;
using System.Text;

namespace TipToyGui
{
    public class OIDTimer : IOIDAction
    {
        private static StringBuilder b = new StringBuilder();
        public OIDRegister SourceNode;

        public ushort Value;

        public OIDTimer(OIDRegister sourceNode, ushort value)
        {
            SourceNode = sourceNode ?? throw new ArgumentNullException(nameof(sourceNode));
       
            Value = value;
        }

        private string createString()
        {
            b.Clear();
            b.Append(" T($r_");
            b.Append(SourceNode.ToString());
            b.Append(", ");
            b.Append(Value.ToString());
            b.Append(")");
            return b.ToString();
        }

        public string GetActionString => createString();
    }

}