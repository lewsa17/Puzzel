using System;
using System.Windows.Forms;

namespace Settings
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.IO.File.Exists("PuzzelLibrary.dll"))
               if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length == 1)
                    Application.Run(new SettingsForm(""));
                else MessageBox.Show(new Form() { TopMost = true}, "Nie można kolejny raz włączyć ustawien", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else Application.Exit();
        }
    }
}
