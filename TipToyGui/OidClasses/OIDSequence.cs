using System.Collections.Generic;
using System.Text;

namespace TipToyGui
{
    public class OIDSequence
    {
        private const string SQUENCESPACE = "  -";
        private static StringBuilder b = new StringBuilder();

        public OIDSequence()
        {
            oIDConditions = new List<IOIDCondition>();
            oIDActions = new List<IOIDAction>();
        }

        public List<IOIDCondition> oIDConditions { get; private set; }
        public List<IOIDAction> oIDActions { get; private set; }

        public string GetSequenceString()
        {
            b.Clear();
            b.Append(SQUENCESPACE);
            foreach (var c in oIDConditions)
            {
                b.Append(c.GetConditionString);
            }
            foreach (var a in oIDActions)
            {
                b.Append(a.GetActionString);
            }
            return b.ToString();
        }
    }
}