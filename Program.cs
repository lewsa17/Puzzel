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
            Application.Run(new Form1());
        }
        public static AutoCompleteStringCollection ComputerCollection = new AutoCompleteStringCollection();
        public static AutoCompleteStringCollection UserCollection = new AutoCompleteStringCollection();
    }
}
