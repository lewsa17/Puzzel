using System.IO;

namespace PuzzelLibrary.NetDiag
{
    public class RemotePing
    {
        private static string HostName { get => _hostName; }
        private static string _hostName;
        public RemotePing(string HostName)
        {
            _hostName = HostName;
        }
        public string StartRemotePing(string RemoteHostName, string counter)
        {
            int licz = 0;
            string VerbosePing = string.Empty;
            

            if (RemoteHostName != null)
            {
                if (counter == string.Empty)
                    counter = "5";
                using (StreamWriter SW = new StreamWriter("remoteping.cmd"))
                {
                    SW.WriteLine("PsExec64.exe " + @"\\" + HostName + " ping " + RemoteHostName + " -n " + counter + " 1> " + Directory.GetCurrentDirectory() + @"\temp.log");
                    SW.Close();
                }

                ProcessExecutable.ProcExec.StartSimpleProcessWithWaitingForExit("cmd.exe", "/c remoteping.cmd");
                if (File.Exists(Directory.GetCurrentDirectory() + @"\temp.log"))
                {
                    using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\temp.log"))
                    {
                        VerbosePing = (sr.ReadToEnd());
                        sr.Close();
                    }
                }

                if (VerbosePing.Contains("Odpowied"))
                {
                    licz = VerbosePing.IndexOf("Odpowied");
                    VerbosePing = VerbosePing.Replace(VerbosePing[licz + 8], 'ź');
                    VerbosePing = VerbosePing.Replace("bźźdzenia", "błądzenia");
                    VerbosePing = VerbosePing.Replace("bajtźw", "bajtów");
                    VerbosePing = VerbosePing.Replace("wysźane", "wysłane");
                    VerbosePing = VerbosePing.Replace("pakietźw", "pakietów");
                    VerbosePing = VerbosePing.Replace("Wysźane", "Wysłane");
                    VerbosePing = VerbosePing.Replace("źredni", "średni");
                }
            }
            if (File.Exists("remoteping.cmd"))
                File.Delete("remoteping.cmd");
            if (File.Exists("temp.log"))
                File.Delete("temp.log");
            return VerbosePing;
        }
    }
}
