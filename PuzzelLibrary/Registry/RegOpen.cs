using Microsoft.Win32;

namespace PuzzelLibrary.Registry
{
    public class RegOpen
    {
        private RegistryKey RegOpenRemoteBaseKey(RegistryHive mainCatalog, string HostName)
        {
            try
            {
                return RegistryKey.OpenRemoteBaseKey(mainCatalog, HostName, RegistryView.Default);
            }
            catch (System.IO.IOException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Brak obiektu", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                Debug.LogsCollector.GetLogs(ex, " Registry::" + HostName + "\\" + mainCatalog);
                return null;
            }
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
            RegistryKey registryKey = null;
            try
            {
                using RegistryKey subkey = RegOpenRemoteBaseKey(mainCatalog, HostName);
                if (subkey != null)
                    registryKey = subkey.OpenSubKey(subKey, true);
            }
            catch (System.Security.SecurityException)
            {
                AccessAllowed = false;
                System.Windows.Forms.MessageBox.Show("Brak uprawnień do " + subKey + " na " + HostName);
            }
            return registryKey;
        }
        public bool AccessAllowed = true;
    }
}
