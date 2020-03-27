using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Puzzel.Registry
{
    class RegOpen
    {
        private static RegistryKey RegOpenRemoteBaseKey(RegistryHive mainCatalog, string HostName)
        {
            return RegistryKey.OpenRemoteBaseKey(mainCatalog, HostName,RegistryView.Default);
        }
        /// <summary>
        /// Otwieranie podklucza
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa głownego katalogu w rejestrze</param>
        /// <param name="subKey">Nazwa podklucza</param>
        /// <returns>Zwraca otwarty podklucz na którym można operować</returns>
        public RegistryKey RegOpenRemoteSubKey(string HostName, RegistryHive mainCatalog, string subKey)
        {
            using (RegistryKey subkey = RegOpenRemoteBaseKey(mainCatalog, HostName))
            {
                return subkey.OpenSubKey(subKey, true);
            }
        }
    }
}
