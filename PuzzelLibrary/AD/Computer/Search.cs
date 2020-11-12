using System;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.Computer
{
    public class Search
    {
        static public SearchResult ByComputerName(string hostName)
        {
            var ds = Connection.Initiate.GetDirectorySearcher();
            if (ds != null)
            {
                ds.Filter = "(cn=" + hostName + ")";
                ds.SearchScope = SearchScope.Subtree;
                ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
                SearchResult compObject = ds.FindOne();

                if (compObject != null)
                    return compObject;
            }
            return null;
        }

        static public SearchResultCollection ByComputerName(string hostName, params string[] propertiesToLoad)
        {
            var ds = Connection.Initiate.GetDirectorySearcher();
            if (ds != null)
            {
                ds.Filter = "(cn=" + hostName + ")";
                ds.SearchScope = SearchScope.Subtree;
                ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
                foreach (var propertytoLoad in propertiesToLoad)
                    ds.PropertiesToLoad.Add(propertytoLoad);
                var compObject = ds.FindAll();

                if (compObject != null)
                    return compObject;
            }
            return null;
        }
    }
}
