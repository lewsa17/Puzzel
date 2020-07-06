using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzelLibrary.Registry
{
    class RegEnum : RegOpen, IEnum
    {
        public RegEnum()
        {

        }
        /// <summary>
        /// Pobieranie wartości z rejestru dla nazwy
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa główna klucza</param>
        /// <param name="subKey">Nazwa podklucza</param>
        /// <param name="value">Wartość </param>
        /// <returns></returns>
        public object GetValue(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey, string value)
        {
            return RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValue(value, null);
        }

        /// <summary>
        ///  Wyszukiwanie nazw wartości w kluczu
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa główna klucza</param>
        /// <param name="subKey">Nazwa podklucza</param>
        /// <returns></returns>
        public string[] GetValueNames(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey)
        {
            var x = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            return x.GetValueNames();
        }
        /// <summary>
        /// Wyszukiwanie nazw podkluczy w rejestrze
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa główna klucza</param>
        /// <param name="subKey">Nazwa podklucza</param>
        /// <returns></returns>
        public string[] GetSubKeyNames(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey)
        {
            var x = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            return x.GetSubKeyNames();
        }
        /// <summary>
        /// Pobieranie typu danych na wybranej wartości
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa główna klucza</param>
        /// <param name="subKey">Nazwa podklucza</param>
        /// <param name="value">Wartość </param>
        /// <returns></returns>
        public Microsoft.Win32.RegistryValueKind GetValueKind(string HostName, Microsoft.Win32.RegistryHive mainCatalog, string subKey, string value)
        {
            return RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValueKind(value);
        }
    }
}
