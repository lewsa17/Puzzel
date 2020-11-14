namespace PuzzelLibrary.Registry
{
    public class RegEnum : RegOpen, IEnum
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
            var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            if (remoteSubKey != null)
                return remoteSubKey.GetValue(value, null);
            return null;
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
            var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            if (remoteSubKey != null)
                return remoteSubKey.GetValueNames();
            return null;
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
            var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            if (remoteSubKey != null)
                return remoteSubKey.GetSubKeyNames();
            return null;
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
            var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
            if (remoteSubKey != null)
                return remoteSubKey.GetValueKind(value);
            return default;
        }
    }
}
