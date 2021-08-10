using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace PuzzelLibrary.ProcessExecutable
{
    public class ProcExec
    {


        private static bool isFileExist(string FileName)
        {
            foreach (var path in System.Environment.GetEnvironmentVariable("PATH").Split(';'))
                if (File.Exists(Path.Combine(path,FileName)))
                    return true;
            return false;
        }
        public static void StartSimpleProcess(string FileName, string Arguments)
        {
            if (isFileExist(FileName))
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
            else
                MessageBox.Show(new Form() { TopMost = true }, "Brak pliku " + FileName, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void StartSimpleProcessWithWaitingForExit(string FileName, string Arguments)
        {
            if (isFileExist(FileName))
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
            else
                MessageBox.Show(new Form() { TopMost = true }, "Brak pliku " + FileName, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static string PSexec(string HostName)
        {
            System.Management.ManagementScope scope = new();
            string OSName = string.Empty;
            if (WMI.ComputerInfo.wmiConnect(HostName, WMI.ComputerInfo.pathCIMv2, out scope))
                OSName = WMI.ComputerInfo.GetInfo(HostName, WMI.ComputerInfo.pathCIMv2, scope, WMI.ComputerInfo.queryOperatingSystem, "osarchitecture");
            string rCommandPath = Application.StartupPath;
            if (OSName.Contains("64-bit"))
                return rCommandPath + "PsExec64.exe";
            return rCommandPath + "PsExec.exe";
        }

        public static string StartExtendedProcess(string FileName, string Arguments)
        {
            OutputValues = null;
            if (isFileExist(FileName))
            {
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
            }
            else
                MessageBox.Show(new Form() { TopMost = true }, "Brak pliku " + FileName, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
 
