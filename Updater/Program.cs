using System;
using System.Windows.Forms;

namespace Updater
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
            Updater.LoadCommits();
            if (Updater.CheckNewVersion())
            {
                if (MessageBox.Show(Updater.UpdatingString(), "Aktualizacja jest dostępna", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Application.Run(new Updater("//ToDo//"));
                }
            }
            else
            {
                MessageBox.Show("Twoja wersja jest obecnie aktualna", "Auto-Updater", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Updater.RemoveLocalRepo();
            }
            
        }
    }
}
