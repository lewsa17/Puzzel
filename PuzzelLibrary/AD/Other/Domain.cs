using System;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.Other
{
    public class Domain
    {
        public static string[] GetCurrentDomainControllers()
        {
            DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + AD.Other.Domain.GetDomainName));
            //search.Filter = "(sAMAccountName=" + username + ")";
            SearchResult search1 = search.FindOne();
            //SearchResultCollection collection = search.FindAll();
            object[] lines = (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value;
            string table = null;
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                table += words[1].Replace("CN=", "") + ",";
            }

            string[] array = null;
            array = table.Split(',');
            Array.Resize(ref array, array.Length - 1);

            return array;
        }
        public static string GetDomainName => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

        public static string[] GetCustomDomainControllers(string domainName)
        {
            DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainName));
            //search.Filter = "(sAMAccountName=" + username + ")";
            SearchResult search1 = search.FindOne();
            //SearchResultCollection collection = search.FindAll();
            object[] lines = (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value;
            string table = null;
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                table += words[1].Replace("CN=", "") + ",";
            }

            string[] array = null;
            array = table.Split(',');
            Array.Resize(ref array, array.Length - 1);

            return array;
        }
    }
}
