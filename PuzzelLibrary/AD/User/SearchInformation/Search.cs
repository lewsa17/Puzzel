﻿using System;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.User.SearchInformation
{
    public class Search
    {

        public SearchResult ByUserName(string username)
        {
            var ds = Connection.Initiate.GetDirectorySearcher();
            try
            {
                if (ds != null)
                {
                    ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(sAMAccountName=" + username + "))";
                    ds.SearchScope = SearchScope.Subtree;
                    ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
                    SearchResult userObject = ds.FindOne();

                    if (userObject != null)
                        return userObject;
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("User not found!", "Search Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException) { System.Windows.Forms.MessageBox.Show("Brak połączenia z AD"); }
            return null;
        }

        private static SearchResult ByEmail(string email)
        {
            var ds = Connection.Initiate.GetDirectorySearcher();
            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(mail=" + email + "))";
            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
            SearchResult userObject = ds.FindOne();

            if (userObject != null)
                return userObject;
            else
            {
                Console.WriteLine("Search Information");
                Console.WriteLine("User not found");
                //MessageBox.Show("User not found!", "Search Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
    }
}
