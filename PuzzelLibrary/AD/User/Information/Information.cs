using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace PuzzelLibrary.AD.User
{
    public class Information : SearchInformation.Search, IInformation
    {
        public string LoginName { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Mail { get; set; }
        public string UserEnabled { get; set; }
        public DateTime AccountExpires { get; set; }
        public DateTime LockoutTime { get; set; }
        public DateTime badPasswordTime { get; set; }
        public int badPwdCount { get; set; }
        public string InternetAccessEnabled { get; set; }
        public DateTime pwdLastSet { get; set; }
        public DateTime lastBadPwdAttempt { get; set; }
        public DateTime lastLogon { get; set; }
        public DateTime lastLogoff { get; set; }
        public DateTime PasswordExpiryTime { get; set; }
        public string scriptPath { get; set; }
        public string homeDirectory { get; set; }
        public string homeDrive { get; set; }
        public string userCannotChangePassword { get; set; }
        public string passwordNotRequired { get; set; }
        public string permittedWorkstation { get; set; }
        public string SkypeLogin { get; set; }
        public string[] Groups { get; set; }

        public Information(string UserName)
        {
            ShowUserInformation(UserName);
        }
        public static bool IsUserAvailable(string UserName)
        {
            if (!string.IsNullOrEmpty(UserName) && UserName.Length > 0)
                if (new SearchInformation.Search().ByUserName(UserName) != null)
                    return true;
            return false;
        }
        internal static List<UserPrincipal> GetUserInADControllers(string UserName)
        {
            List<UserPrincipal> userListFromADControllers = new();
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
                PrincipalContext oPrincipalContext;
                if (Connection.Credentials.Available)
                {
                    oPrincipalContext = new PrincipalContext(ContextType.Domain, Connection.Credentials.Domain, Connection.Credentials.UserName, Connection.Credentials.Password);
                    if (!oPrincipalContext.ValidateCredentials(Connection.Credentials.UserName, Connection.Credentials.Password))
                        return null;
                }
                else if (!string.IsNullOrEmpty(Connection.Credentials.DomainName))
                {
                    oPrincipalContext = new PrincipalContext(ContextType.Domain, Connection.Credentials.DomainName);
                }
                else oPrincipalContext = new PrincipalContext(ContextType.Domain);

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
                if (NetDiag.Ping.Pinging(domainController) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    PrincipalContext oPrincipalContext;
                    if (Connection.Credentials.Available)
                    {
                        oPrincipalContext = new PrincipalContext(ContextType.Domain, domainController, Connection.Credentials.UserName, Connection.Credentials.Password);
                        if (!oPrincipalContext.ValidateCredentials(Connection.Credentials.UserName, Connection.Credentials.Password))
                            return null;
                    }
                    else oPrincipalContext = new PrincipalContext(ContextType.Domain, domainController);

                    UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, UserName);
                    return oUserPrincipal;
                }
                else return null;
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
            public void GetUserPasswordDetails(string UserName, string domainController)
            {
                UserPrincipal uP = GetUser(UserName, domainController);
                var rs = new SearchInformation.Search().ByUserName(UserName, new string[] { "msDS-UserPasswordExpiryTimeComputed" });
                if (uP != null)
                {
                    badLogonCount = uP.BadLogonCount > 0 ? uP.BadLogonCount : 0;
                    lastBadPasswordAttempt = uP.LastBadPasswordAttempt != null ? DateTime.FromFileTime(uP.LastBadPasswordAttempt.Value.ToFileTime()) : DateTime.MinValue;
                    lastPasswordSet = uP.LastPasswordSet != null ? DateTime.FromFileTime(uP.LastPasswordSet.Value.ToFileTime()) : DateTime.MinValue;
                    userAccountLocked = uP.IsAccountLockedOut() == true ? "Zablokowane" : "Odblokowane";
                    userLockoutTime = uP.AccountLockoutTime != null ? DateTime.FromFileTime(uP.AccountLockoutTime.Value.ToFileTime()) : DateTime.MinValue;
                    passwordExpiryTime = (rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0] != null) ? DateTime.FromFileTime((long)rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0]) : DateTime.MinValue;
                }
                else
                {
                    userAccountLocked = "Niedostępne";
                }
            }
        }
        public ArrayList GetUserGroups(string UserName)
        {
            ArrayList myItems = new();
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
                Title = rs.GetDirectoryEntry().Properties["title"].Value != null ? rs.GetDirectoryEntry().Properties["title"].Value.ToString() : string.Empty;

                Company = rs.GetDirectoryEntry().Properties["company"].Value != null ? rs.GetDirectoryEntry().Properties["company"].Value.ToString() : string.Empty;

                Department = rs.GetDirectoryEntry().Properties["department"].Value != null ? rs.GetDirectoryEntry().Properties["department"].Value.ToString() : string.Empty;

                UserPrincipal user = GetUser(UserName);
                DisplayName = user.DisplayName;
                LoginName = user.SamAccountName != null ? user.SamAccountName : string.Empty;
                Mail = user.EmailAddress != null ? user.EmailAddress : string.Empty;
                UserEnabled = user.Enabled == true ? UserEnabled = "TAK" : "NIE";
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

                var _groups = user.GetGroups(user.Context);
                if (_groups != null)
                {
                    List<string> members = new();
                    foreach (var groups in _groups)
                        members.Add(groups.SamAccountName);
                    members.Sort();
                    Groups = members.ToArray();
                }
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

                if (rs.Properties.Contains("lastlogoff"))
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
                        AccountExpires = DateTime.FromFileTime(temp);
                    }

                LockoutTime = rs.Properties.Contains("lockoutTime") == true ? DateTime.FromFileTime((long)rs.Properties["lockoutTime"][0]) : DateTime.MinValue;
            }
            PasswordExpiryTime = (rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0] != null) ? (DateTime.FromFileTime((long)rs.Properties["msDS-UserPasswordExpiryTimeComputed"][0])) : DateTime.MinValue;
        }
    }
}