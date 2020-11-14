using System;
using System.Linq;
using Microsoft.Win32;

namespace PuzzelLibrary.Registry
{
    public class RegQuery : RegOpen
    {
        public void QueryKey(string HostName, RegistryHive mainCatalog, string subKey, string valueName, string value, RegistryValueKind valueKind)
        {
            try
            { var remoteSubkey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubkey != null)
                    remoteSubkey.SetValue(valueName, value, valueKind);
            }
            catch (Exception e)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(e, value);
            }
            finally
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null) 
                {
                    var names = remoteSubKey.GetValueNames();
                    if (names.Contains(valueName))
                    {
                        System.Windows.Forms.MessageBox.Show("Zadanie ukończone pomyślnie");
                    }
                }
            }

        }
    }
}
