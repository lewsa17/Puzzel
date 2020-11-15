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
        static bool InADExist(string hostName)
        {
            if (Search.ByComputerName(hostName) != null)
                return true;
            return false;
        }

        static bool InGraveyardExist(string hostName)
        {
            if (InADExist(hostName))
            {
                var search = Search.ByComputerName(hostName, "distinguishedName")[0];
                if (search.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString().Contains("_Graveyard"))
                    return true;
            }
            return false;
        }

        static string GetLocationInAD(string hostName)
        {
            if (InADExist(hostName))
            {
                var search = Search.ByComputerName(hostName, "distinguishedName")[0];
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
        public static object[] GetPWD(string hostName)
        {
            if (InGraveyardExist(hostName))
            {
                ReleaseFromGraveyard(hostName);
            }
            object[] sCollection = new object[2];
            try
            {
                var search = Search.ByComputerName(hostName, new string[] { LapsProperties, LapsProperties1 })[0];
                if (search != null)
                {
                    sCollection[0] = search.Properties[LapsProperties][0];
                    sCollection[1] = search.Properties[LapsProperties1][0];
                }
            }
            catch (Exception) { };
            return sCollection;
        }
        public static void setPWD(string hostName, string value)
        {
            var cn = new Change();
            cn.Property(hostName, LapsProperties1, value);
        }
    }
}

