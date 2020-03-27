using System;
using System.Windows.Forms;

namespace Puzzel
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (Form1 mainForm = new Form1())
            {
                Application.Run(mainForm);
            }
        }
        // public static AutoCompleteStringCollection ComputerCollection = new AutoCompleteStringCollection();
        // public static AutoCompleteStringCollection UserCollection = new AutoCompleteStringCollection();
    }
}
