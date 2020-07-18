using System.IO;

namespace PuzzelLibrary.NetDiag
{
    public class RemoteTracert
    {
        public RemoteTracert(string HostName)
        {
            _hostName = HostName;
        }
        private static string HostName { get => _hostName; }
        private static string _hostName;
        public string StartRemoteTracert(string RemoteHostName)
        {
            string VerboseTracert = string.Empty;
            int licz = 0;
            
            if (RemoteHostName != null)
            {
                using (StreamWriter SW = new StreamWriter("remotetracert.cmd"))
                {
                    SW.WriteLine("PsExec64.exe " + @"\\" + HostName + " tracert " + RemoteHostName + " 1> " + Directory.GetCurrentDirectory() + @"\temp.log");
                    SW.Close();
                }

                ProcessExecutable.ProcExec.StartSimpleProcessWithWaitingForExit("CMD.exe", "/c remotetracert.cmd");

                if (File.Exists(Directory.GetCurrentDirectory() + @"\temp.log"))
                {
                    using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\temp.log"))
                    {
                        VerboseTracert = sr.ReadToEnd();
                        sr.Close();
                    }
                }
                if (VerboseTracert.Contains("ledzenie"))
                {
                    licz = VerboseTracert.IndexOf("ledzenie");
                    VerboseTracert = VerboseTracert.Replace(VerboseTracert[licz - 1], 'ź');
                    VerboseTracert = VerboseTracert.Replace("źledzenie", "Śledzenie");
                    VerboseTracert = VerboseTracert.Replace("maksymalnź", "maksymalną");
                    VerboseTracert = VerboseTracert.Replace("liczbź", "liczbą");
                    VerboseTracert = VerboseTracert.Replace("przeskokźw", "przeskoków");
                    VerboseTracert = VerboseTracert.Replace("zakoźczone", "zakończone");
                }
            }
            if (File.Exists("remotetracert.cmd"))
                File.Delete("remotetracert.cmd");
            if (File.Exists("temp.log"))
                File.Delete("temp.log");
            return VerboseTracert;
        }
    }
}
