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
            Application.Run(new Updater(new string[] { 
                PuzzelLibrary.Version.Major.ToString(), 
                PuzzelLibrary.Version.Minor.ToString(), 
                PuzzelLibrary.Version.Build.ToString(), 
                PuzzelLibrary.Version.Hash.ToString(), 
                PuzzelLibrary.Version.BuildDate.ToString() 
            }));

        }
    }
}
