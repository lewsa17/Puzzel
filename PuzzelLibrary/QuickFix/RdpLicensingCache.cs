using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzelLibrary.QuickFix
{
    public class RdpLicensingCache
    {
        private string _hostName;
        public RdpLicensingCache(string HostName)
        {
            _hostName = HostName;
        }
        public void Remove()
        {
            var RegDelete = new Registry.RegErase();
            RegDelete.SubKeyRecursive(_hostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\MSLicensing", "Store");

            if (RegDelete.isDone)
                System.Windows.Forms.MessageBox.Show("Należy uruchomić aplikację \"Podłączanie pulpitu zdalnego \" jako administrator aby zrestartować licencje.");
        }
    }
}
