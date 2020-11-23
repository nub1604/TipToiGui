using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipToyGui.OidClasses
{
    public class OIDSpeak : IOIDAction
    {

        private static StringBuilder b = new StringBuilder();

        public string Lang { get; set; }
        public string Name { get; set; }
         public string Text { get; set; }
        public OIDSpeak()
        {
         
        }

        public OIDSpeak(string name, string text, string lang)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text;
            Lang = lang;
        }

        public override string ToString()
        {
            return Name??"";
        }

        public string createSpeakString()
        {
            b.Clear();
            b.Append(Name);
            b.Append(": \"");
            b.Append(Text);
            b.Append("\"");
            return b.ToString();
        }

        private string createString()
        {
            b.Clear();
            b.Append(" P(");
            b.Append($"sp_{Name}");
            b.Append(")");
            return b.ToString();
        }
      

        public string GetActionString => createString();
    }
}
