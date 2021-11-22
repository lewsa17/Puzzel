using System;

namespace PuzzelLibrary.AD.User
{
    interface IInformation
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
        public string scriptPath { get; set; }
        public string homeDirectory { get; set; }
        public string homeDrive { get; set; }
        public string userCannotChangePassword { get; set; }
        public string passwordNotRequired { get; set; }
        string permittedWorkstation { get; set; }
        string SkypeLogin { get; set; }
        string[] Groups { get; set; }

    }
}
