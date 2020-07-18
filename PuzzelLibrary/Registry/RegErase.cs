using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
namespace PuzzelLibrary.Registry
{
    //do poprawy
    public class RegErase : RegOpen, IErase
    {
        public RegErase()
        {
        }

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
                RegOpenRemoteSubKey(HostName, mainCatalog, subKey).DeleteValue(value,true);
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("Obiekt nie zostal znaleziony");
            //}
            finally
            {
                var names = RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValue(value).ToString();
                if (names.Contains(value))
                {
                    MessageBox.Show("Wartość została poprawnie usunięta");
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
                RegOpenRemoteSubKey(HostName, mainCatalog, subKey).DeleteSubKey(subKeyName, true);
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("Klucz nie zostal znaleziony");
            //}
            finally
            {
                var names = RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValueNames();
                if (names.Contains(subKeyName))
                {
                    MessageBox.Show("Wartość została poprawnie usunięta");
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
                RegOpenRemoteSubKey(HostName, mainCatalog, subKey).DeleteSubKeyTree(subKeyName, true);
            }
            //catch (Exception)
            //{
            //    MessageBox.Show("Klucz nie zostal znaleziony");
            //}
            finally
            {
                var names = RegOpenRemoteSubKey(HostName, mainCatalog, subKey).GetValueNames();
                if (names.Contains(subKeyName))
                {
                    MessageBox.Show("Wartość została poprawnie usunięta");
                }
            }
        }
    }
}

