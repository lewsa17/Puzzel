using System;
using PuzzelLibrary.Registry;
using System.Linq;

namespace PuzzelLibrary.QuickFix
{
    public class Unlock
    {
        public static bool UnlockRemoteRPC(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey)
        {
            var temp = new RegEnum().RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            if (temp != null)
                if (temp.GetValueNames().Contains("AllowRemoteRPC"))
                {
                    if (Convert.ToInt32(new RegEnum().RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValue("AllowRemoteRPC")) == 0)
                        new RegQuery().QueryKey(HostName, mainCatalog, subKey, "AllowRemoteRPC", "1", Microsoft.Win32.RegistryValueKind.DWord);
                    return true;
                }
            return false;
        }
    }
}
