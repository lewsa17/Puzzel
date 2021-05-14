using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace PuzzelLibrary.AD.User
{
    public class Information : SearchInformation.Search, IInformation
    {
        public string loginName { get; set; }
        public string displayName { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string department { get; set; }
        public string mail { get; set; }
        public string userEnabled { get; set; }
        public DateTime accountExpires { get; set; }
        public DateTime lockoutTime { get; set; }
        public DateTime badPasswordTime { get; set; }
        public int badPwdCount { get; set; }
        public string InternetAccessEnabled { get; set; }
        public DateTime pwdLastSet { get; set; }
        public DateTime lastBadPwdAttempt { get; set; }
        public DateTime lastLogon { get; set; }
        public DateTime lastLogoff { get; set; }
        public DateTime passwordExpiryTime { get; set; }
        public string scriptPath { get; set; }
        public string homeDirectory { get; set; }
        public string homeDrive { get; set; }
        public string userCannotChangePassword { get; set; }
        public string passwordNotRequired { get; set; }
        public string permittedWorkstation { get; set; }
        public string SkypeLogin { get; set; }
        public string Groups { get; set; }

        public Information(string UserName)
        {
            ShowUserInformation(UserName);
        }
        public static bool IsUserAvailable(string UserName)
        {
            if (!string.IsNullOrEmpty(UserName) && UserName.Length > 0)
                if (GetUser(UserName) != null)
                    return true;
            return false;
        }
        public static class CustomCredentials
        {
            public static string UserName = string.Empty;
            public static string Password = string.Empty;
            public static string Domain = string.Empty;
            public static bool Available 
            {
                get => UserName.Length > 1 && Password.Length > 1 && Domain.Length > 1;
            }
        }
        internal static List<UserPrincipal> GetUserInADControllers(string UserName)
        {
            List<UserPrincipal> userListFromADControllers = new List<UserPrincipal>();
            foreach (var DomainController in Other.Domain.GetCurrentDomainControllers())
            {
                var user = GetUser(UserName, DomainController);
                if (user != null)
                    userListFromADControllers.Add(user);
            }
            return userListFromADControllers;
        }
        public static UserPrincipal GetUser(string UserName)
        {
            try
            {
                PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain);
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, UserName);
                return oUserPrincipal;
            }
            catch(Exception e)
            {
                Debug.LogsCollector.GetLogs(e, UserName);
            }
            return null;
        }

        public static UserPrincipal GetUser(string UserName, string domainController)
        {
            try
            {
                PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, domainController, CustomCredentials.UserName, CustomCredentials.Password);
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, UserName);
                return oUserPrincipal;
            }
            catch (Exception e)
            {
                Debug.LogsCollector.GetLogs(e, UserName);
            }
            return null;
        }
        public class PasswordDetails
        {
            public int badLogonCount;
            public DateTime lastBadPasswordAttempt;
            public DateTime lastPasswordSet;
            public string userAccountLocked;
            public DateTime userLockoutTime;
            public DateTime passwordExpiryTime;
            private static void UserExtensions(string UserName)
            {

            }
            public void GetUserPasswordDetails(string UserName, string domainController)
            {
                UserPrincipal uP = GetUser(UserName, domainController);
                var rs = new SearchInformation.Search().ByUserName(UserName, new string[] { "msDS-UserPasswordExpiryTimeComputed" });
                if (uP != null)
                {
                    badLogonCount = uP.BadLogonCount > 0 ? uP.BadLogonCount : 0;
                    lastBadPasswordAttempt = uP.LastBadPasswordAttempt != null ? DateTime.FromFileTime(uP.LastBadPasswordAttempt.Value.ToFileTime()) : DateTime.MinValue;
                    lastPasswordSet = uP.LastPasswordSet != null ? DateTime.FromFileTime(uP.LastPasswordSet.Value.ToFileTime()) : DateTime.MinValue;
                    userAccountLocked = uP.AccountLockoutTime != null ? "Zablokowane" : "Odblokowane";
                    userLockoutTime = uP.AccountLockoutTime != null ? DateTime.FromFileTime(uP.AccountLockoutTime.Value.ToFileTime()) : DateTime.MinValue;
                    passwordExpiryTime = (rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0] != null) ? DateTime.FromFileTime((long)rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0]) : DateTime.MinValue;
                }
            }
        }
        public ArrayList GetUserGroups(string UserName)
        {
            ArrayList myItems = new ArrayList();
            UserPrincipal user = GetUser(UserName);
            PrincipalSearchResult<Principal> oPrincipalSearcherResult = user.GetGroups();
            foreach (Principal oResult in oPrincipalSearcherResult)
            {
                myItems.Add(oResult.Name);
            }
            return myItems;
        }
        private void ShowUserInformation(string UserName)
        {
            string[] propertiesToLoad = new string[] { "title", "company", "department", "msRTCSIP-PrimaryUserAddress", "msRTCSIP-InternetAccessEnabled", "lastLogoff", "lastlogon", "accountExpires", "lockoutTime", "msDS-UserPasswordExpiryTimeComputed" };

            var rs = ByUserName(UserName, propertiesToLoad);
            if (rs != null)
            {
                title = rs.GetDirectoryEntry().Properties["title"].Value != null ? rs.GetDirectoryEntry().Properties["title"].Value.ToString() : string.Empty;

                company = rs.GetDirectoryEntry().Properties["company"].Value != null ? rs.GetDirectoryEntry().Properties["company"].Value.ToString() : string.Empty;

                department = rs.GetDirectoryEntry().Properties["department"].Value != null ? rs.GetDirectoryEntry().Properties["department"].Value.ToString() : string.Empty;

                UserPrincipal user = GetUser(UserName);
                displayName = user.DisplayName;
                loginName = user.SamAccountName != null ? user.SamAccountName : string.Empty;
                mail = user.EmailAddress != null ? user.EmailAddress : string.Empty;
                userEnabled = user.Enabled == true ? userEnabled = "TAK" : "NIE";
                badPwdCount = user.BadLogonCount >= 0 ? (int)user.BadLogonCount : int.MinValue;
                homeDirectory = user.HomeDirectory != null ? user.HomeDirectory : string.Empty;

                if (user.PermittedWorkstations.Count > 0)
                {
                    foreach (var permiWorks in user.PermittedWorkstations)
                    {
                        permittedWorkstation += permiWorks.ToString() + "\n\t\t\t\t\t\t";
                    }
                }
                else permittedWorkstation = "Wszystkie";

                pwdLastSet = user.LastPasswordSet != null ? DateTime.FromFileTime(user.LastPasswordSet.Value.ToFileTime()) : DateTime.MinValue;
                
                if (user.GetGroups() != null)
                    foreach (var groups in user.GetGroups())
                        Groups += groups.SamAccountName + "\n\t\t\t\t\t\t";
                lastBadPwdAttempt = user.LastBadPasswordAttempt != null ? DateTime.FromFileTime(user.LastBadPasswordAttempt.Value.ToFileTime()) : DateTime.MinValue;
                homeDrive = user.HomeDrive != null ? (string)user.HomeDrive : string.Empty;


                scriptPath = user.ScriptPath != null ? (string)user.ScriptPath : string.Empty;

                passwordNotRequired = user.PasswordNotRequired == true ? "NIE" : "TAK";

                userCannotChangePassword = user.UserCannotChangePassword == true ? "NIE" : "TAK";

                SkypeLogin = rs.GetDirectoryEntry().Properties["msRTCSIP-PrimaryUserAddress"].Value != null ? rs.GetDirectoryEntry().Properties["msRTCSIP-PrimaryUserAddress"].Value.ToString().Replace("sip:", "") : "Brak loginu";

                if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value != null)
                {
                    InternetAccessEnabled = rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "True" ? "TAK" : "NIE";
                }
                else InternetAccessEnabled = "Brak uprawnień";

                lastLogoff = rs.Properties["lastlogoff"][0].ToString() != "0" ? DateTime.FromFileTime((long)rs.GetDirectoryEntry().Properties["lastLogoff"].Value) : DateTime.MinValue;

                if (rs.Properties.Contains("lastlogon"))
                    if (rs.Properties["lastLogon"][0].ToString() != "0")
                    {
                        long temp = (long)rs.Properties["lastLogon"][0];
                        lastLogon = DateTime.FromFileTime(temp);
                    }

                if (rs.Properties.Contains("accountExpires"))
                    if (rs.GetDirectoryEntry().Properties["accountExpires"] != null)
                    {
                        long temp = (long)rs.Properties["accountExpires"][0];
                        temp = (temp > DateTime.MaxValue.ToFileTime()) ? 0 : temp;
                        accountExpires = DateTime.FromFileTime(temp);
                    }

                lockoutTime = rs.Properties.Contains("lockoutTime") == true ? DateTime.FromFileTime((long)rs.Properties["lockoutTime"][0]) : DateTime.MinValue;
            }
            passwordExpiryTime = (rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0] != null) ? (DateTime.FromFileTime((long)rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0])) : DateTime.MinValue;
        }
    }
}