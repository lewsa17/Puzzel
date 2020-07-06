using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzelLibrary.Registry
{
    interface IEnum
    {
        object GetValue(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey, string value);
        string[] GetValueNames(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey);
        Microsoft.Win32.RegistryValueKind GetValueKind(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey, string value);

        string[] GetSubKeyNames(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey);
    }
}
