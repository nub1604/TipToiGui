using System.Collections.Generic;
using System.Text;

namespace TipToyGui
{
    public class OIDTextSequence
    {
        private const string SQUENCESPACE = "  - ";
        private static StringBuilder b = new StringBuilder();
        public string Text { get; set; }
        public OIDTextSequence()
        {
           
        }


        public string GetSequenceString()
        {
            b.Clear();
            b.Append(SQUENCESPACE);
            b.Append(Text);
            return b.ToString();
        }
    }
}