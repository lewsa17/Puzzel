using System.IO;
using System.Management.Automation;

namespace Forms.QuickFix
{
    public class ActivateOffice2016
    {
        public static void Active(string HostName)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                string pathCScript = "\\Windows\\system32\\cscript.exe";
                string OfficeExist = CheckOfficeExist(HostName);
                if (!string.IsNullOrEmpty(OfficeExist))
                {
                    ps.AddScript("Invoke-Command -ComputerName " + HostName + " {cmd /c \"C:" + pathCScript + " \"C:" + OfficeExist + "\" /act} "); ;
                    ps.Invoke();
                    Form1.UpdateRichTextBox("Zlecono aktywacje Office, należy uruchomić ponownie w celu zakończenia zmian");
                }
                else Form1.UpdateRichTextBox("Nie znaleziono Office");
            }
        }
        private static string CheckOfficeExist(string HostName)
        {
            string pathOfficeX86 = @"\Program Files(x86)\Microsoft Office\Office16\ospp.vbs";
            string pathOfficeX64 = @"\Program Files\Microsoft Office\Office16\ospp.vbs";
            string pathOffice = string.Empty;
            if (File.Exists("\\" + HostName + @"\C$" + pathOfficeX86))
                pathOffice = pathOfficeX86;
            if (File.Exists("\\" + HostName + @"\C$" + pathOfficeX64))
                pathOffice = pathOfficeX64;
            return pathOffice;
        }
    }
}
