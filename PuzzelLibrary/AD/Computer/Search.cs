﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

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

        static public SearchResult ByComputerName(string hostName, string propertiesToLoad)
        {
            var ds = Connection.Initiate.GetDirectorySearcher();
            if (ds != null)
            {
                ds.Filter = "(cn=" + hostName + ")";
                ds.SearchScope = SearchScope.Subtree;
                ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
                ds.PropertiesToLoad.Add(propertiesToLoad);
                SearchResult compObject = ds.FindOne();

                if (compObject != null)
                    return compObject;
            }
            return null;
        }
    }
}
