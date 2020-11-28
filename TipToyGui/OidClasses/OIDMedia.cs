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

        MediaFile Media;
        public OIDMedia(MediaFile media)
        {
            Media = media;
        }

        private string createString()
        {
            b.Clear();
            b.Append(" P(");
            b.Append($"m_{Media.HashValue}");
            b.Append(")");
            return b.ToString();
        }
        public string GetMediaString => createString();

        public string GetActionString => createString();
    }
}
