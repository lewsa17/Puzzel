using System.IO;
using System.Management.Automation;
using System;

namespace PuzzelLibrary.QuickFix
{
    public class ActivateOffice
    {
        public static string Activate(string HostName)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                string pathCScript = "\\Windows\\system32\\cscript.exe";
                string data = null;
                foreach (string Office in GetOficePath(HostName))
                    if (!string.IsNullOrEmpty(Office))
                {
                    ps.AddScript("Invoke-Command -ComputerName " + HostName + " {cmd /c \"C:" + pathCScript + " \"C:" + Office + "\" /act} "); ;
                    ps.Invoke();
                    data += ("Zlecono aktywacje Office, należy uruchomić ponownie w celu zakończenia zmian");
                }
                else return ("Nie znaleziono Office");
                return data;
            }
        }
        private static string[] GetOficePath(string HostName)
        {
            string[] pathOffice = new string[0];
            foreach (string officeVersion in new string[] { "Office14", "Office15", "Office16" })
            {
                Array.Resize(ref pathOffice, pathOffice.Length + 1);
                string pathOfficeX86 = @"\Program Files(x86)\Microsoft Office\" + officeVersion + @"\ospp.vbs";
                string pathOfficeX64 = @"\Program Files\Microsoft Office\" + officeVersion + @"\ospp.vbs";
                if (File.Exists("\\" + HostName + @"\C$" + pathOfficeX86))
                    pathOffice[pathOffice.Length] = pathOfficeX86;
                if (File.Exists("\\" + HostName + @"\C$" + pathOfficeX64))
                    pathOffice[pathOffice.Length] = pathOfficeX64;
            }
            return pathOffice;
        }
    }
}
