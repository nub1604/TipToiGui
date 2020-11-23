using System.Collections.Generic;
using TipToyGui.Common;

namespace TipToyGui
{
    public class SceneOid
    {
        public SceneOid()
        {
        }

        public SceneOid(string name)
        {
            SetupName = name;
            Polygons = new List<Polygon>();
        }

        public string SetupName { get; set; }

        public List<Polygon> Polygons { get; set; }

        public override string ToString()
        {
            return SetupName;
        }
    }
}