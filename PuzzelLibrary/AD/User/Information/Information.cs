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
            if (GetUser(UserName) != null)
                return true;
            return false;
        }
        internal static List<UserPrincipal> GetUserInADControllers(string UserName)
        {
            List<UserPrincipal> userListFromADControllers = new List<UserPrincipal>();
            foreach (var DomainController in Other.Domain.GetDomainControllers())
                userListFromADControllers.Add(GetUser(UserName, DomainController));
            return userListFromADControllers;
        }
        public static UserPrincipal GetUser(string UserName)
        {
            using (PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, UserName);
                return oUserPrincipal;
            }
        }

        public static UserPrincipal GetUser(string UserName, string domainController)
        {
            using (PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, domainController))
            {
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, UserName);
                return oUserPrincipal;
            }
        }

        public class PasswordDetails
        {
            public string badLogonCount;
            public string lastBadPasswordAttempt;
            public string lastPasswordSet;
            public string userAccountLocked;
            public string userLockoutTime;
            public void GetUserPasswordDetails(string UserName, string domainController)
            {
                UserPrincipal uP = GetUser(UserName, domainController);
                if (uP != null)
                {
                    if (uP.BadLogonCount > 0)
                        badLogonCount = uP.BadLogonCount.ToString();
                    else badLogonCount = "0";

                    if (uP.LastBadPasswordAttempt != null)
                        lastBadPasswordAttempt = DateTime.FromFileTime(uP.LastBadPasswordAttempt.Value.ToFileTime()).ToString();

                    if (uP.LastPasswordSet != null)
                        lastPasswordSet = DateTime.FromFileTime(uP.LastPasswordSet.Value.ToFileTime()).ToString();

                    if (uP.AccountLockoutTime != null)
                    {
                        userAccountLocked = "Zablokowane";
                        userLockoutTime = DateTime.FromFileTime(uP.AccountLockoutTime.Value.ToFileTime()).ToString();
                    }
                    else
                    {
                        userAccountLocked = "Odblokowane";
                        userLockoutTime = "0";
                    }
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
            var rs = ByUserName(UserName);
            if (rs != null)
            {
                if (rs.GetDirectoryEntry().Properties["sAMAccountName"].Value != null)
                    loginName = rs.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();

                if (rs.GetDirectoryEntry().Properties["displayName"].Value != null)
                    displayName = rs.GetDirectoryEntry().Properties["displayName"].Value.ToString();

                if (rs.GetDirectoryEntry().Properties["title"].Value != null)
                    title = rs.GetDirectoryEntry().Properties["title"].Value.ToString();

                if (rs.GetDirectoryEntry().Properties["company"].Value != null)
                    company = rs.GetDirectoryEntry().Properties["company"].Value.ToString();

                if (rs.GetDirectoryEntry().Properties["department"].Value != null)
                    department = rs.GetDirectoryEntry().Properties["department"].Value.ToString();

                if (rs.GetDirectoryEntry().Properties["mail"].Value != null)
                    mail = (string)rs.GetDirectoryEntry().Properties["mail"].Value;

                if (rs.GetDirectoryEntry().Properties["homeDirectory"].Value != null)
                    homeDirectory = rs.GetDirectoryEntry().Properties["homeDirectory"].Value.ToString();

                    UserPrincipal user = GetUser(UserName);

                    if (user.Enabled != null)
                    {
                        if (user.Enabled == true) userEnabled = "TAK";
                        else userEnabled = "NIE";
                    }
                    else userEnabled = "błąd";

                    if (user.BadLogonCount >= 0)
                        badPwdCount = (int)user.BadLogonCount;

                    if (user.HomeDirectory != null)
                        homeDirectory = user.HomeDirectory;

                    if (user.PermittedWorkstations.Count > 0)
                    {
                        foreach (var permiWorks in user.PermittedWorkstations)
                        {
                            permittedWorkstation += permiWorks.ToString() + "\n\t\t\t\t\t\t";
                        }
                    }
                    else permittedWorkstation = "Wszystkie";

                    if (user.LastPasswordSet != null)
                    {
                        pwdLastSet = DateTime.FromFileTime(user.LastPasswordSet.Value.ToFileTime());
                    }
                    //if (user.PermittedLogonTimes != null)
                    //{
                    //    var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                    //    var time = new LogonTime(DayOfWeek.Monday,
                    //         new DateTime(2011, 1, 1, 8, 0, 0),
                    //         new DateTime(2011, 1, 1, 10, 0, 0), zone);
                    //    var times = new List<LogonTime>();
                    //    times.add(time);
                    //    var mask = PermittedLogonTimes.GetByteMask(times);

                    //    var times = PermittedLogonTimes.GetLogonTimes(mask);
                    //}
                    //    permittedLogonTime = user.PermittedLogonTimes;

                    if (user.GetGroups() != null)
                        foreach (var groups in user.GetGroups())
                            Groups += groups.SamAccountName + "\n\t\t\t\t\t\t";
                    if (user.LastBadPasswordAttempt != null)
                    {
                        lastBadPwdAttempt = DateTime.FromFileTime(user.LastBadPasswordAttempt.Value.ToFileTime());
                    }
                    if (user.HomeDrive != null)
                        homeDrive = (string)user.HomeDrive;

                    if (user.ScriptPath != null)
                        scriptPath = (string)user.ScriptPath;

                    if (user.PasswordNotRequired == true) passwordNotRequired = "NIE";
                    else if (user.PasswordNotRequired == false) passwordNotRequired = "TAK";

                    if (user.UserCannotChangePassword == true) userCannotChangePassword = "NIE";
                    else if (user.UserCannotChangePassword == false) userCannotChangePassword = "TAK";

                if (rs.GetDirectoryEntry().Properties["msRTCSIP-PrimaryUserAddress"].Value != null)
                {
                    SkypeLogin = rs.GetDirectoryEntry().Properties["msRTCSIP-PrimaryUserAddress"].Value.ToString();
                }
                else SkypeLogin = "Brak loginu";
                if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value != null)
                {
                    if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "True")
                        InternetAccessEnabled = "TAK";
                    if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "False")
                        InternetAccessEnabled = "NIE";
                }
                else InternetAccessEnabled = "Błąd, brak obiektu";

                if (rs.Properties.Contains("lastLogoff"))
                    if (rs.Properties["lastlogoff"][0].ToString() != "0")
                    {
                        long temp = (long)rs.GetDirectoryEntry().Properties["lastLogoff"].Value;
                        lastLogoff = DateTime.FromFileTime(temp);
                    }

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
                        accountExpires = DateTime.FromFileTime(temp);
                    }

                if (rs.GetDirectoryEntry().Properties.Contains("lockoutTime"))
                {
                    long temp = (long)rs.Properties["lockoutTime"][0];
                    lockoutTime = DateTime.FromFileTime(temp);
                }
            }
        }
    }
}
