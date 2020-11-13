using System;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.Connection
{
    internal class Initiate
    {
       

        private static bool isConnectionCredential => CheckCredentials;
        private static bool CheckCredentials 
        {
            get => new Settings.GetSettings().CredentialsAvailable;
        }

        public static DirectoryEntry getDirectoryEntry(string domain, string userName, string password)
        {
            return new DirectoryEntry("LDAP://" + domain, userName, password);
        }
        public static DirectoryEntry getDirectoryEntry(string domain) { return new DirectoryEntry("LDAP://" + domain); }

        public static DirectorySearcher GetDirectorySearcher()
        {
            DirectorySearcher dirsearch = null;
            if (dirsearch == null)

                try
                {
                    if (isConnectionCredential)
                    {
                        Credential.Username credentials = new Credential.Username();
                        credentials.GetCredential();
                        if (credentials.UserName != string.Empty)
                        {
                            dirsearch = new DirectorySearcher(getDirectoryEntry(Other.Domain.GetDomainName, credentials.UserName, credentials.Password));
                        }
                    }
                    else
                        dirsearch = new DirectorySearcher(getDirectoryEntry(Other.Domain.GetDomainName));
                }
                catch (DirectoryServicesCOMException e)
                {
                    Console.WriteLine("Error info");
                    Console.WriteLine("connection credential is wrong, please check");
                    //MessageBox.Show("connection credential is wrong, please check", "error info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Message.ToString();
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    if (ex.Message == "Unknown error (0x80005000)")
                    {
                        Console.WriteLine("Error info");
                        Console.WriteLine("No connection");
                    }

                }
            return dirsearch;
        }
    }
}
