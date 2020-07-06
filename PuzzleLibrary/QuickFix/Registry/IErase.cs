using Microsoft.Win32;

namespace Puzzel.Registry
{
    interface IErase
    {
        void SubKey(string HostName, RegistryHive mainCatalog, string subKey, string subKeyName);
        void SubKeyRecursive(string HostName, RegistryHive mainCatalog, string subKey, string subKeyName);
        void Value(string HostName, RegistryHive mainCatalog, string subKey, string value);
    }
}