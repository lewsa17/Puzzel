using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel
{
    public class QuickFixes
    {
        public void RepairNice(string machineName)
        {
            var LM = Microsoft.Win32.RegistryHive.LocalMachine;
            var RV = Microsoft.Win32.RegistryView.Default;
            string subkey = @"SOFTWARE\WOW6432Node\Microsoft\.NETFramework";
            var DWord = Microsoft.Win32.RegistryValueKind.DWord;
            Registry.RegQuery.SetQuery(LM, RV, subkey, "EnableIEHosting","1",DWord, machineName);
        }

    }
}
