using Microsoft.Win32;

namespace PuzzelLibrary.QuickFix
{
    public class IEHosting
    {
        private const string Message = "Za krótka nazwa komputera";

        public static void EnableCompatibilityFramework4inIE(string HostName)
        {
            if (HostName.Length > 2)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName) == System.Net.NetworkInformation.IPStatus.Success)
                    new Registry.RegQuery().QueryKey(HostName, RegistryHive.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\.NETFramework", "EnableIEHosting", "1", RegistryValueKind.DWord);
            }
            //else Form1.UpdateRichTextBox(Message);
        }
    }
}
