using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel.QuickFix
{
    class IEHosting
    {
        private const string Message = "Za krótka nazwa komputera";

        public static void EnableCompatibilityFramework4inIE(string HostName)
        {
            if (HostName.Length > 2)
            {
                if (Ping.Pinging(HostName) == System.Net.NetworkInformation.IPStatus.Success)
                    new Registry.RegQuery().QueryKey(HostName, RegistryHive.LocalMachine, @"SOFTWARE\WOW6432Node\Microsoft\.NETFramework", "EnableIEHosting", "1", RegistryValueKind.DWord);
            }
            else Form1.UpdateRichTextBox(Message);
        }
    }
}
