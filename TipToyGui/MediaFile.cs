using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace TipToyGui
{
    public class MediaFile
    {
        public const string FILTERMEDIA = "Media(*.wav;*.ogg;*.mp3)|*.wav;*.ogg;*.mp3;*.PNG;*.TIFF";
        public string FileName { get;  set; }
        public string HashValue { get;  set; }
        public string EditorEditorName { get;  set; }

        public override string ToString()
        {
            return EditorEditorName;
        }
        public string MediaFileToString()
        {
            return FileName;
        }


        public static MediaFile ImportNewFile(OIDProject oIDProject)
        {

            MediaFile newMediaFile = new MediaFile();
            var existing = oIDProject.MediaFiles;
            if (oIDProject == null || existing == null) return null;
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = FILTERMEDIA;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {

                        var fn = GetHashSha1(fs);
                        var nfn = $"{fn}{Path.GetExtension(ofd.FileName)}";
                        string pf = Path.Combine(oIDProject.ProjectPath, oIDProject.MediaPath, $"m_{nfn}");


                        var alreadyexisting = existing.Where(x => x.HashValue == fn).FirstOrDefault();
                        if (alreadyexisting != null)
                        {
                            MessageBox.Show($"File already imported {alreadyexisting.EditorEditorName}");
                            return null;

                        }

                        File.Copy(ofd.FileName, pf,true);

                        newMediaFile.FileName = $"m_{nfn}";
                        newMediaFile.EditorEditorName = Regex.Replace(Path.GetFileNameWithoutExtension(ofd.FileName), "[^A-Za-z0-9_]", "");
                        newMediaFile.HashValue = fn;
                    }
                    return newMediaFile;
                }
            }
            return null;
        }


        private static SHA1 sHA1 = SHA1.Create();
        private static SHA256 Sha256 = SHA256.Create();

        private static string GetHashSha1(FileStream stream)
        {
            var hash = sHA1.ComputeHash(stream);
            string result = "";
            foreach (byte b in hash) result += b.ToString("x2");
            return result;

        }


        private string GetHashSha256(FileStream stream)
        {
            var hash = Sha256.ComputeHash(stream);
            string result = "";
            foreach (byte b in hash) result += b.ToString("x2");
            return result;

        }
        private bool CheckbitRateWav(FileStream stream, int expected)
        {
            stream.Seek(28, SeekOrigin.Begin);
            byte[] val = new byte[4];
            stream.Read(val, 0, 4);
           return  BitConverter.ToInt32(val, 0) * 8 == expected;
        }
        private bool validOgg(FileStream stream)
        {
            stream.Seek(37, SeekOrigin.Begin);
            byte[] val = new byte[3];
            return val[0] == 1 && val[1] == 2 && val[2] == 2;
        }
    }
}
