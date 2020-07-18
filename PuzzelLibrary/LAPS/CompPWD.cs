using System;
using System.DirectoryServices;
using PuzzelLibrary.Settings;
using PuzzelLibrary.AD.Computer;

namespace PuzzelLibrary.LAPS
{
    public static class CompPWD
    {
        static string DirectoryEntryPath => GetSettings.GetValuesFromXml("ExternalResources.xml", "DirectoryEntryPath");
        static string LapsProperties => GetSettings.GetValuesFromXml("ExternalResources.xml", "LapsProperties");
        static bool IsInADExist(string hostName)
        {
            if (Search.ByComputerName(hostName) != null)
                return true;
            return false;
        }

        static bool IsInGraveyardExist(string hostName)
        {
            if (IsInADExist(hostName))
            {
                var search = Search.ByComputerName(hostName, "distinguishedName");
                if (search.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString().Contains("_Graveyard"))
                    return true;
            }
            return false;
        }

        static string GetLocationInAD(string hostName)
        {
            if (IsInADExist(hostName))
            {
                var search = Search.ByComputerName(hostName, "distinguishedName");
                return search.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString();
            }
            return string.Empty;
        }
        static void ReleaseFromGraveyard(string hostName)
        {
            string path = GetLocationInAD(hostName);
            if (!string.IsNullOrEmpty(path))
            {
                var currentDirectory = new DirectoryEntry("LDAP://" + path);
                var newDirectory = new DirectoryEntry("LDAP://" + DirectoryEntryPath);
                currentDirectory.MoveTo(newDirectory);
                newDirectory.CommitChanges();
            }
        }
        public static string GetPWD(string hostName)
        {
            if (IsInGraveyardExist(hostName))
            {
                ReleaseFromGraveyard(hostName);
            }

            try
            {
                var search = Search.ByComputerName(hostName, LapsProperties);
                if (search != null)
                    return search.GetDirectoryEntry().Properties[LapsProperties].Value.ToString();
            }
            catch (Exception) { };
            return string.Empty;
        }
    }
}

