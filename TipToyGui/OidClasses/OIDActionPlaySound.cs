using System;
using System.Text;

namespace TipToyGui
{
    public class OIDActionPlaySound : IOIDAction
    {
        private static StringBuilder b = new StringBuilder();

        public OIDActionPlaySound(string[] sounds)
        {
            Sounds = sounds ?? throw new ArgumentNullException(nameof(sounds));
        }

        public string[] Sounds { get; set; }

        public string GetActionString => createString();

        private string createString()
        {
            b.Clear();
            b.Append(" P(");
            for (int i = 0; i < Sounds.Length; i++)
            {
                if (i != 0)
                {
                    b.Append(", ");
                }
                b.Append($"s_{Sounds[i]}");
            }
            b.Append(")");
            return b.ToString();
        }
    }
}