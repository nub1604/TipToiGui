using System;
using System.Diagnostics;
using static TipToyGui.Nodes.BaseNode;

namespace TipToyGui.Common
{
    public class PlayTTTool : IDisposable
    {
        private Process TTToolExe;

        public PlayTTTool(string path, string arg)
        {
            var processStartInfo = new ProcessStartInfo(path);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Arguments = arg;

            TTToolExe = new Process();
            TTToolExe.StartInfo = processStartInfo;
            TTToolExe.EnableRaisingEvents = true;
            TTToolExe.OutputDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                    RaiseMessageEvent(new MessageEventArgs(e.Data));
            };
            TTToolExe.ErrorDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                    RaiseMessageEvent(new MessageEventArgs(e.Data));
            };

            TTToolExe.Start();
            TTToolExe.BeginOutputReadLine();
            TTToolExe.BeginErrorReadLine();
        }

        public void Write(string s)
        {
            if (!TTToolExe.HasExited)
            {
                TTToolExe.StandardInput.WriteLine(s);
            }
        }

        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public event MessageEventHandler OnRaiseMessageEvent;

        protected void RaiseMessageEvent(MessageEventArgs e)
        {
            OnRaiseMessageEvent?.Invoke(this, e);
        }

        ~PlayTTTool()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (TTToolExe != null)
            {
                TTToolExe.Dispose();
                TTToolExe = null;
            }
        }
    }
}