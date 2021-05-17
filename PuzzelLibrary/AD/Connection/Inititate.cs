using System;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.Connection
{
    internal class Initiate
    {
        public static DirectoryEntry getDirectoryEntry(string domain, string userName, string password)
        {
            return new DirectoryEntry("LDAP://" + domain, userName, password, AuthenticationTypes.Secure);
        }
        public static DirectoryEntry getDirectoryEntry(string domain) { return new DirectoryEntry("LDAP://" + domain) { AuthenticationType = AuthenticationTypes.Secure}; }

        public static DirectorySearcher GetDirectorySearcher()
        {
            DirectorySearcher dirsearch = null;
            if (dirsearch == null)
                try
                {
                    if (Credentials.DomainName != null && Credentials.DomainName.Length > 1)
                    {
                        if (Credentials.Available)
                        {
                            dirsearch = new DirectorySearcher(getDirectoryEntry(Credentials.DomainName, Credentials.UserName, Credentials.Password));
                        }
                        else
                            dirsearch = new DirectorySearcher(getDirectoryEntry(Credentials.DomainName));
                    }
                    else dirsearch = new DirectorySearcher(getDirectoryEntry(Other.Domain.GetDomainName));
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
