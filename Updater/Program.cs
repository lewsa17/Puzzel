using System;
using System.Windows.Forms;
namespace Updater
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Updater.IDFSet && !string.IsNullOrEmpty(Updater.IntranetDeploymentFolder))
            {
                Application.Run(new Updater());
            }
            else
            {
                MessageBox.Show("Aktualizacja nie może zostać wykonana.\n" +
                                   "Nie podano ścieżki do katalogu z aktualizacjami lub aktualizacje lokalne są wyłączone", "Auto-Updater", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
