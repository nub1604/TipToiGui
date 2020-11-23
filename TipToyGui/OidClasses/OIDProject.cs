using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using TipToyGui.Nodes;
using TipToyGui.OidClasses;

namespace TipToyGui
{
    public class OIDProject
    {
        public string Name { get; set; }
        public string Welcome { get; set; }
        public string Language { get; set; }
        public string Comment { get; set; }
        public short ProductID { get; set; }
        public string MediaPath { get; set; }
        public string ProjectPath { get; set; }

        public List<OIDRegister> oIDRegisters = new List<OIDRegister>();
        public BindingList<NodeSetup> nodeSetups = new BindingList<NodeSetup>();

        public List<OIDSpeak> SpeakObjects = new List<OIDSpeak>();
        public List<Scene> Scenes = new List<Scene>();

        public void Save()
        {
            var s = JsonConvert.SerializeObject(this);
            var file = $"{Path.Combine(ProjectPath, Name)}.ttproj";

            using (var fileStream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(s);
                }
            }
            TTGRegistry.SetRecentProject(file);
        }

        public string SaveYaml()
        {
            var file = $"{Path.Combine(ProjectPath, Name)}.yaml";

            using (var fileStream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(CreateYaml());
                }
            }
            return file;
        }

        public string CreateGME()
        {
            var yaml = $"{Path.Combine(ProjectPath, Name)}_build.yaml";

            using (var fileStream = new FileStream(yaml, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(CreateYaml());
                }
            }

            var gme = $"{Path.Combine(ProjectPath, Name)}.gme";

            TTTool.Assemble(yaml, gme);

            return gme;
        }

        public static OIDProject Load(string proj)
        {
            if (!File.Exists(proj)) return null;
            OIDProject p;

            using (var fileStream = new FileStream(proj, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    p = JsonConvert.DeserializeObject<OIDProject>(reader.ReadToEnd());
                }
            }
            return p;
        }

        private string CreateYaml()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("product-id: ").AppendLine(ProductID.ToString());
            sb.Append("media-path: ").AppendLine($"{MediaPath}/%s");
            if (!string.IsNullOrWhiteSpace(Language)) sb.Append("gme-lang: ").AppendLine(Language.ToString());
            if (!string.IsNullOrWhiteSpace(Comment)) sb.Append("comment: ").AppendLine(Comment.ToString());
            if (!string.IsNullOrWhiteSpace(Welcome))
            {
                sb.Append("welcome: ").AppendLine(Welcome.ToString());
            }

            if (oIDRegisters.Count > 0)
            {
                sb.Append("init: ");
                foreach (var item in oIDRegisters)
                {
                    sb.Append(item.Init);
                }
                sb.AppendLine("");
            }

            sb.AppendLine("scripts: ");
            foreach (var item in nodeSetups.Where(x => x.Node != null && x.Node.oIDSequences.Count > 0))
            {
                sb.AppendLine($"  o_{item.Node.GetNodeCode()}");
            }

            if (SpeakObjects.Count > 0)
            {
                sb.AppendLine("speak: ");

                var queryLang = from speaks in SpeakObjects
                                     group speaks by speaks.Lang into newGroup
                                     orderby newGroup.Key
                                        select newGroup;

                foreach (var langGroup in queryLang)
                {

                    sb.AppendLine($"- language: {langGroup.Key}");
                    foreach (var item in langGroup)
                    {
                        sb.AppendLine($"  sp_{item.createSpeakString()}");
                    }
                }


                foreach (var item in SpeakObjects.GroupBy(x => x.Lang))
                {
                    
                    
                }
            }

            if (nodeSetups.Count > 0)
            {
                sb.AppendLine("scriptcodes: ");
                foreach (var item in nodeSetups)
                {
                    sb.AppendLine($"  {item.ScriptCode}");
                }
            }
            return sb.ToString();
        }
    }
    public enum EnumLangShort
    {
        en, de, fr
    }
    public enum EnumGMELANG
    {
        ENGLISH, GERMAN, FRANCE
    }
}