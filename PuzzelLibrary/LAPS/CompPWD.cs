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
        static string LapsProperties1 => GetSettings.GetValuesFromXml("ExternalResources.xml", "LapsProperties1");
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
                var search = Search.ByComputerName(hostName, "distinguishedName")[0];
                if (search.Properties["distinguishedName"].ToString().Contains("_Graveyard"))
                    return true;
            }
            return false;
        }

        static string GetLocationInAD(string hostName)
        {
            if (IsInADExist(hostName))
            {
                var search = Search.ByComputerName(hostName, "distinguishedName")[0];
                return search.Properties["distinguishedName"][0].ToString();
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
        public static object[] GetPWD(string hostName)
        {
            if (IsInGraveyardExist(hostName))
            {
                ReleaseFromGraveyard(hostName);
            }
            string[] sCollection = new string[2];
            try
            {
                var search = Search.ByComputerName(hostName, new string[] { LapsProperties, LapsProperties1 })[0];
                if (search != null)
                {
                    sCollection[0] = search.Properties[LapsProperties][0].ToString();
                    sCollection[1] = search.Properties[LapsProperties1][0].ToString();
                }
            }
            catch (Exception) { };
            return sCollection;
        }
    }
}

