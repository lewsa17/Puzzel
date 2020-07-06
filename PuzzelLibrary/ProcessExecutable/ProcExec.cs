using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace PuzzelLibrary.ProcessExecutable
{
    public class ProcExec
    {
        public static string vfs = null;
        public static string eri = null;
        public static string ext = null;
        public static string net = null;
        public static string explorer = null;
        public static void StartSimpleProcess(string FileName, string Arguments)
        {
            try
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = FileName;
                    p.StartInfo.Arguments = Arguments;
                    p.Start();
                }
            }
            catch (System.ComponentModel.Win32Exception x) when (x.Message == "Żądana operacja wymaga podniesienia uprawnień.")
            {
                MessageBox.Show(new Form() { TopMost = true }, x.Message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void StartSimpleProcessWithWaitingForExit(string FileName, string Arguments)
        {
            try
            {
                using (Process p = new Process())
                {
                    p.StartInfo.FileName = FileName;
                    p.StartInfo.Arguments = Arguments;
                    p.Start();
                    p.WaitForExit();
                }
            }
            catch (System.ComponentModel.Win32Exception x) when (x.Message == "Żądana operacja wymaga podniesienia uprawnień.") 
            {
                MessageBox.Show(new Form() { TopMost = true }, x.Message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static string StartExtendedProcess(string FileName, string Arguments)
        {
            OutputValues = null;
            try
            {
                using (Process n = new Process())
                {
                    if (File.Exists(@"C:\Windows\sysnative\" + FileName))
                        n.StartInfo.FileName = @"C:\Windows\sysnative\" + FileName;
                    else
                        n.StartInfo.FileName = @"C:\Windows\system32\" + FileName;
                    n.StartInfo.Arguments = Arguments;
                    //n.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
                    n.StartInfo.CreateNoWindow = true;
                    n.StartInfo.UseShellExecute = false;
                    n.StartInfo.RedirectStandardOutput = true;
                    n.OutputDataReceived += new DataReceivedEventHandler(POutputHandler);
                    n.Start();
                    n.BeginOutputReadLine();
                    n.WaitForExit();
                    n.Dispose();
                }
            }
            catch (System.ComponentModel.Win32Exception x) when (x.Message == "Żądana operacja wymaga podniesienia uprawnień.")
            {
                MessageBox.Show(new Form() { TopMost = true }, x.Message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            return OutputValues;
        }

        private static string OutputValues;
        private static void POutputHandler(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            //this.BeginInvoke(new MethodInvoker(() =>
            //{
                OutputValues+=(((e.Data) ?? string.Empty) + "\n");
            //}));
        }

    }
}
 