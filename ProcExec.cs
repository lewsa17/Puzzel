using System.Diagnostics;
using System.IO;
namespace Puzzel
{
    public class ProcExec
    {
		static string[] Working = null;
        public static string explorer = @"explorer.exe";
        public static string vfs = Working[3].Remove(11);
        public static string eri = Working[4].Remove(11);
        public static string net = Working[5].Remove(11);
        public static string ext = Working[6].Remove(11);
        public static string rdp = @"mstsc.exe";
        public static string rdp_args = @"/v:";
        public static string compmgmt = "compmgmt.msc";
        public static string ping = "ping";
        public static string mmc_args = @"/computer:\\";
        public static string nbtstat = @"C:\Windows\sysnative\nbtstat.exe";
        public ProcExec()
        {

        }
        public ProcExec(params object[] args)
        {
            Working = File.ReadAllLines("DefaultValue.txt");
            Process execute = new Process();
            execute.StartInfo.FileName = args[0].ToString();
            execute.StartInfo.Arguments = args[1].ToString();
            execute.Start();
        }
        public void ProcExecIF(params object[] args)
        {
            Working = File.ReadAllLines("DefaultValue.txt");
            Process execute = new Process();
            execute.StartInfo.FileName = args[0].ToString();
            execute.StartInfo.Arguments = args[1].ToString();
            execute.Start();
        }
        
        
    }
     
    
}
