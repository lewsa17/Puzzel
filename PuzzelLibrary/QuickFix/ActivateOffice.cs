using System.IO;
using System;

namespace PuzzelLibrary.QuickFix
{
    public class ActivateOffice
    {
        public static string Activate(string HostName)
        {
            string pathCScript = "\\Windows\\system32\\cscript.exe";
            foreach (string Office in GetOficePath(HostName))
                if (!string.IsNullOrEmpty(Office))
                {
                    var appName = ProcessExecutable.ProcExec.PSexec(HostName);
                    ProcessExecutable.ProcExec.StartSimpleProcess(appName, "cmd /c \"C:" + pathCScript + " \"C:" + Office + "\" /act");
                    return ("Zlecono aktywacje Office, należy uruchomić ponownie w celu zakończenia zmian");
                }
            return ("Nie znaleziono Office");
        }
        private static string[] GetOficePath(string HostName)
        {
            string[] pathOffice = new string[0];
            foreach (string officeVersion in new string[] { "Office14", "Office15", "Office16" })
            {
                foreach (string architecture in new string[] { "", " (x86)" })
                {
                    string path = "\\Program Files" + architecture + "\\Microsoft Office\\" + officeVersion + "\\ospp.vbs";
                    if (isFileAvailable("\\\\" + HostName + "\\c$" + path)) 
                    {
                        Array.Resize(ref pathOffice, pathOffice.Length + 1);
                        pathOffice[pathOffice.Length - 1] = path;
                    }
                }
            }
            return pathOffice;
        }
        private static bool isFileAvailable(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }
    }
}
