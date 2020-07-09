using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace PuzzelLibrary.AD.User.Information
{
    interface IInformation
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
        string permittedWorkstation { get; set; }
        string SkypeLogin { get; set; }
        string Groups { get; set; }

    }
}
