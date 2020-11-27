using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipToyGui.OidClasses
{
    public class OIDMedia : IOIDAction
    {
        private static StringBuilder b = new StringBuilder();

        string Name;
        public OIDMedia(string name)
        {
            Name = name;
        }

        private string createString()
        {
            b.Clear();
            b.Append(" P(");
            b.Append($"{Name}");
            b.Append(")");
            return b.ToString();
        }
        public string GetMediaString => createString();

        public string GetActionString => createString();
    }
}
