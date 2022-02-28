using System;
using System.Linq;
using Microsoft.Win32;
namespace PuzzelLibrary.Registry
{
    //do poprawy
    public class RegErase : RegOpen, IErase
    {
        public RegErase()
        {
        }

        public bool isDone;

        /// <summary>
        /// Usuwanie wartości z rejestru
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa głównego klucza w rejestrze</param>
        /// <param name="subKey">Nazwa pełnej ścieżki w rejestrze</param>
        /// <param name="value">Nazwa wartości która ma zostać usunięta z rejestru</param>
        public void Value(string HostName, RegistryHive mainCatalog, string subKey, string value)
        {
            try
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null)
                    remoteSubKey.DeleteValue(value, true);
            }
            finally
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null)
                {
                    var names = remoteSubKey.GetValue(value).ToString();
                    if (!names.Contains(value))
                    {
                        System.Windows.Forms.MessageBox.Show("Wartość została poprawnie usunięta");
                        isDone = true;
                    }
                }
            }
        }
        /// <summary>
        /// Usuwanie klucza z rejestru
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa głównego klucza w rejestrze</param>
        /// <param name="subKey">Nazwa pełnej ścieżki w rejestrze</param>
        /// <param name="subKeyName">Nazwa klucza który zostanie usunięty, jeśli jest pusty</param>
        public void SubKey(string HostName, RegistryHive mainCatalog, string subKey, string subKeyName)
        {
            try
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null)
                    remoteSubKey.DeleteSubKey(subKeyName, true);
            }
            finally
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null)
                {
                    var names = remoteSubKey.GetValueNames();
                    if (!names.Contains(subKeyName))
                    {
                        System.Windows.Forms.MessageBox.Show("Wartość została poprawnie usunięta");
                        isDone = true;
                    }
                }
            }
        }

        /// <summary>
        /// Usuwanie całego klucza razem z całą zawartością
        /// </summary>
        /// <param name="HostName">Nazwa hosta</param>
        /// <param name="mainCatalog">Nazwa głównego klucza w rejestrze</param>
        /// <param name="subKey">Nazwa pełnej ścieżki w rejestrze</param>
        /// <param name="subKeyName">Nazwa klucza który ma zostać usunięty z całą zawartością</param>
        public void SubKeyRecursive(string HostName, RegistryHive mainCatalog, string subKey, string subKeyName)
        {
            try
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null)
                    remoteSubKey.DeleteSubKeyTree(subKeyName, true);
            }
            finally
            {
                var remoteSubKey = RegOpenRemoteSubKey(HostName, mainCatalog, subKey);
                if (remoteSubKey != null)
                {
                    var names = remoteSubKey.GetValueNames();
                    if (!names.Contains(subKeyName))
                    {
                        System.Windows.Forms.MessageBox.Show("Wartość została poprawnie usunięta");
                        isDone = true;
                    }
                }
            }
        }
    }
}

