using System;
using PuzzelLibrary.Registry;
using System.Linq;

namespace PuzzelLibrary.QuickFix
{
    public class UnlockRPC
    {
        public UnlockRPC(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey)
        {
            this.HostName = HostName;
            this.mainCatalog = mainCatalog;
            this.subKey = subKey;
        }
        private string HostName;
        private Microsoft.Win32.RegistryHive mainCatalog;
        private string subKey;
        public bool IsOpen => isOpen();

        public void RemoteUnlockPort()
        {
            new RegQuery().QueryKey(HostName, mainCatalog, subKey, "AllowRemoteRPC", "1", Microsoft.Win32.RegistryValueKind.DWord);
        }
        private bool isOpen()
        {
            var objects = new RegEnum().RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            if (objects != null)
                if (objects.GetValueNames().Contains("AllowRemoteRPC"))
                {
                    if (Convert.ToInt32(objects.GetValue("AllowRemoteRPC")) == 0)
                        return true;
                }
            return false;
        }
    }
}
