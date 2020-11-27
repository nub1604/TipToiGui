using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TipToyGui.Common;

namespace TipToyGui
{
    public static class TTTool
    {
        public const string FILTERGME = "gme files(*.gme)|*.gme|All files (*.*)|*.*";
        public const string FILTERYAML = "yaml files(*.yaml)|*.yaml|All files (*.*)|*.*";
        /// <summary>
        /// Das tttool kann OID-Muster in verschiedenen Formaten erzeugen – das brauchst du dann, wenn du deine eigenen
        /// Tiptoi-Produkte gestalten willst.Es versteht dazu mehrere Befehle, je nach dem woher es wissen soll, zu welche
        /// Codes es die Muster erzeugen soll, und mehrere Optionen, die steuern, wie die Muster auszusehen haben.
        /// </summary>
        /// <param name="tttSettings"></param>
        /// <param name="code"></param>
        public static string CreateOidCodes(TTToolSettings tttSettings, ushort code, string workdir ="", bool raw = false)
        {
            var path = TTGRegistry.Read("tttoolPath");
            
            var arg = $"{ConvertSettingsToArguments(tttSettings)} oid-code {(raw?"--raw ":"")}{code}";
            if (string.IsNullOrEmpty(workdir))
            {
                CMD.GetMultiline(path, arg);
                return Path.Combine(Assembly.GetAssembly(typeof (MainForm)).Location, $"oid-{code}.png");
            }
            else
            {
                CMD.GetMultiline(path, workdir, arg);
                return Path.Combine(workdir, $"oid-{code}.png");
            }
        }


        /// <summary>
        /// Das tttool kann OID-Muster in verschiedenen Formaten erzeugen – das brauchst du dann, wenn du deine eigenen
        ///Tiptoi-Produkte gestalten willst.Es versteht dazu mehrere Befehle, je nach dem woher es wissen soll, zu welche
        /// Codes es die Muster erzeugen soll, und mehrere Optionen, die steuern, wie die Muster auszusehen haben.
        /// </summary>
        /// <param name="tttSettings"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static string CreateOidCodes(TTToolSettings tttSettings, ushort from, ushort to, string workdir = "")
        {

            if (from < to)
            {
                var t = from;
                from = to;
                to = t;
            }

            var path = TTGRegistry.Read("tttoolPath");
            var arg = $"{ConvertSettingsToArguments(tttSettings)} oid-code {from}-{to}";
            if (string.IsNullOrEmpty(workdir))
                return CMD.GetMultiline(path, arg);
            return CMD.GetMultiline(path, workdir, arg);

        }

        /// <summary>
        /// Das tttool kann OID-Muster in verschiedenen Formaten erzeugen – das brauchst du dann, wenn du deine eigenen
        ///Tiptoi-Produkte gestalten willst.Es versteht dazu mehrere Befehle, je nach dem woher es wissen soll, zu welche
        /// Codes es die Muster erzeugen soll, und mehrere Optionen, die steuern, wie die Muster auszusehen haben.
        /// </summary>
        /// <param name="tttSettings"></param>
        /// <param name="yamlFile"></param>
        /// <returns></returns>
        public static string CreateOidCodes(TTToolSettings tttSettings, string yamlFile, string outPath ="")
        {
            var path = TTGRegistry.Read("tttoolPath");
            var yf = yamlFile.EndsWith(".yaml") ? "yamlFile" : $"{yamlFile}.yaml";
            var arg = $"{ConvertSettingsToArguments(tttSettings)} oid-codes {yf}";
            if ( !string.IsNullOrEmpty(outPath))
            {
                arg = $"{arg} \"{outPath}\"";
            }
            return CMD.GetMultiline(path, arg);
        }

        public static string ExtractYamlFromGME(string gmeFile, string yamlFile ="")
        {
            var f = fileExtension(gmeFile, "gme");
            if (!File.Exists(f))
                return $"{f} file not exists";

            var path = TTGRegistry.Read("tttoolPath");
            var arg = $" export {gmeFile}";

            if (!string.IsNullOrEmpty(yamlFile))
            {
                arg = $"{arg} \"{fileExtension(yamlFile, "yaml")}\"";
            }
            return CMD.GetMultiline(path, arg);
        }
        public static string ExtractMediaFromGME(string gmeFile, string mediaPath = "")
        {
            if (!File.Exists(gmeFile))
                return $"{gmeFile} file not exists";

            var path = TTGRegistry.Read("tttoolPath");
            var arg = $" media {gmeFile}";

            if (!string.IsNullOrEmpty(mediaPath))
            {
                arg = $"{arg} -d {mediaPath}";
            }
            return CMD.GetMultiline(path, arg);
        }

        public static string Assemble(string yamlFile, string gmeFile = "")
        {
            if (!File.Exists(yamlFile))
                return $"{yamlFile} file not exists";

            var path = TTGRegistry.Read("tttoolPath");
         
            var arg = $"assemble \"{fileExtension(yamlFile, "yaml")}\"";

            if (!string.IsNullOrEmpty(gmeFile))
            {
              
                arg = $"{arg} \"{fileExtension(gmeFile, "gme")}\"";
            }
            return CMD.GetMultiline(path, arg);
        }
        public static string Play(string yamlFile)
        {
            if (!File.Exists(yamlFile))
                return $"{yamlFile} file not exists";

            var path = TTGRegistry.Read("tttoolPath");

            var arg = $"assemble \"{fileExtension(yamlFile, "yaml")}\"";

            return CMD.GetMultiline(path, arg);
        }

        static string ConvertSettingsToArguments(TTToolSettings s)
        {
            StringBuilder sb = new StringBuilder();
            if (s.ImageFormat != EnumImageFormat.Default)
            {
                if (s.ImageFormat == EnumImageFormat.SVGPNG)
                    sb.Append($" --image-format SVG+PNG");
                else
                    sb.Append($" --image-format {s.ImageFormat}");
            }
            if (s.CodeDim != Size.Empty)
            {
                sb.Append($" --code-dim {s.CodeDim.Width}x{s.CodeDim.Height}");
            }
            sb.Append($" --dpi {(int)s.DPI}");
            
            if (s.PixelSize != 0)
            {
                sb.Append($" --pixel-size {(int)s.PixelSize}");
            }
            return sb.ToString();
        }

        static string fileExtension(string file, string extension)
        {
            return file.EndsWith($".{extension}") ? file : $"{file}.{extension}";
        }
    }
}
