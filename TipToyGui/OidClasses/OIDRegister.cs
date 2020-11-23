using System;

namespace TipToyGui
{
    public class OIDRegister
    {

        public OIDRegister() { }

        public OIDRegister(ushort oID, string name)
        {
            OID = oID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public OIDRegister(ushort oID, string name, ushort initValue)
        {
            OID = oID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            InitValue = initValue;
        }

        public string ScriptCode => $"o_{Name} : {OID}";

        public string Init => InitValue > 0 ? $" '$'r_{Name} := {InitValue}": "";

        public ushort OID { get; set; }
        public ushort InitValue { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? OID.ToString() : Name;
        }
    }
}