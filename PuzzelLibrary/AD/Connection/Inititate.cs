﻿using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.Connection
{
    internal class Initiate
    {
       

        private static bool ConnectionCredential => CheckCredentials;
        private static bool CheckCredentials 
        {
            get => true;//new Settings.GetSettings().CredentialsAvailable;
        }
        public static DirectorySearcher GetDirectorySearcher()
        {
            DirectorySearcher dirsearch = null;
            if (dirsearch == null)

                try
                {
                    if (ConnectionCredential)
                    {
                        Credential.Username credentials = new Credential.Username();
                        credentials.GetCredential();
                        if (credentials.UserName != string.Empty)
                        {
                            dirsearch = new DirectorySearcher(new DirectoryEntry("LDAP://" + Other.Domain.GetDomainName, credentials.UserName, credentials.Password));
                        }
                        else
                            dirsearch = new DirectorySearcher(new DirectoryEntry("LDAP://" + Other.Domain.GetDomainName));
                    }
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
