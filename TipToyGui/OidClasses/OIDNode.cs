using System.Collections.Generic;
using System.Drawing.Design;
using System.Text;

namespace TipToyGui
{
    public class OIDNode 
    {
        private static StringBuilder b = new StringBuilder();
        public string OIDParent { get; set; }
        public List<string> oIDSequences { get; set; }

        public string GetNodeCode()
        {
            b.Clear();
            b.Append(OIDParent.ToString());
            b.AppendLine(":");
            foreach (var item in oIDSequences)
            {
                b.AppendLine($"  {item}");
            }
            return b.ToString();
        }

        public OIDNode(OIDRegister p)
        {
            OIDParent = p.ToString();
            oIDSequences = new List<string>();
        }

        public OIDNode()
        {
            OIDParent = "";
            oIDSequences = new List<string>();
        }

        public void AddSequece(OIDSequence sequence)
        {
            oIDSequences.Add(sequence.GetSequenceString());
        }
        public void AddSequece(OIDTextSequence sequence)
        {
            oIDSequences.Add(sequence.GetSequenceString());
        }
    }
}