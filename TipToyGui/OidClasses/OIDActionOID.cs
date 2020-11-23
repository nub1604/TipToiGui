using System;
using System.Text;

namespace TipToyGui
{
    public class OIDActionOID : IOIDAction
    {
        private static StringBuilder b = new StringBuilder();
        public OIDRegister SourceNode;
        public MathOperators Operator;
        public OIDRegister Value;

        public OIDActionOID(OIDRegister sourceNode, MathOperators @operator, OIDRegister value)
        {
            SourceNode = sourceNode ?? throw new ArgumentNullException(nameof(sourceNode));
            Operator = @operator;
            Value = value;
        }

        private string createString()
        {
            b.Clear();
            b.Append(" $r_");
            b.Append(SourceNode.ToString());
            switch (Operator)
            {
                case MathOperators.add: b.Append(" +="); break;
                case MathOperators.minus: b.Append(" -="); break;
                case MathOperators.multiply: b.Append(" *="); break;
                case MathOperators.devide: b.Append(" /="); break;
                case MathOperators.modulo: b.Append(" %="); break;
                case MathOperators.and: b.Append(" &="); break;
                case MathOperators.or: b.Append(" |="); break;
                case MathOperators.xor: b.Append(" ^="); break;
                case MathOperators.set: b.Append(" :="); break;
            }
            b.Append(" $r_");
            b.Append(Value.ToString());

            return b.ToString();
        }

        public string GetActionString => createString();
    }
}