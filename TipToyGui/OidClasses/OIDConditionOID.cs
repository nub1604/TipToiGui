using System;
using System.Text;

namespace TipToyGui
{
    /// <summary>
    /// Bedingungne müssen am Anfang der Zeile stehen
    /// </summary>
    public class OIDConditionOID : IOIDCondition
    {
        private static StringBuilder b = new StringBuilder();

        public OIDConditionOID(OIDRegister sourceNode, BoolOperators @operator, OIDRegister value)
        {
            SourceNode = sourceNode ?? throw new ArgumentNullException(nameof(sourceNode));
            Operator = @operator;
            Value = value;
        }

        public OIDRegister SourceNode { get; set; }
        public BoolOperators Operator { get; set; }
        public OIDRegister Value { get; set; }

        private string createString()
        {
            b.Clear();
            b.Append(" $r_");
            b.Append(SourceNode.ToString());
            switch (Operator)
            {
                case BoolOperators.equal: b.Append(" =="); break;
                case BoolOperators.notEqual: b.Append(" !="); break;
                case BoolOperators.gtEqual: b.Append(" >="); break;
                case BoolOperators.ltEqual: b.Append(" <="); break;
                case BoolOperators.gt: b.Append(" >"); break;
                case BoolOperators.lt: b.Append(" <"); break;
            }
            b.Append(" $r_");
            b.Append(Value.ToString());
            b.Append("?");

            return b.ToString();
        }

        public string GetConditionString => createString();
    }

    
}