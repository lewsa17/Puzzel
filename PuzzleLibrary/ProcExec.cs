using System.Diagnostics;
namespace Puzzel
{
    public struct ProcExec
    {
        public const string explorer = @"explorer.exe";
        public const string vfs = ExternalResources.vfs;
        public const string eri = ExternalResources.eri;
        public const string net = ExternalResources.net;
        public const string ext = ExternalResources.ext;
        public const string rdp = @"mstsc.exe";
        public const string rdpArgs = @"/v:";
        public const string compmgmt = "compmgmt.msc";
        public const string ping = "ping";
        public const string mmcArgs = @"/computer:\\";
        public const string nbtstat = @"C:\Windows\sysnative\nbtstat.exe"; 
    }
}
