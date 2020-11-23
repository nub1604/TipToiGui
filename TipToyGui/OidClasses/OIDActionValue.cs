using System;
using System.Text;

namespace TipToyGui
{
    public class OIDActionValue : IOIDAction
    {
        private static StringBuilder b = new StringBuilder();
        public OIDRegister SourceNode;
        public MathOperators Operator;
        public ushort Value;

        public OIDActionValue(OIDRegister sourceNode, MathOperators @operator, ushort value)
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
            b.Append(" ");
            b.Append(Value.ToString());

            return b.ToString();
        }

        public string GetActionString => createString();
    }

    public enum MathOperators
    {
        add, minus, devide, multiply, modulo, and, or, xor,
        set
    }
}