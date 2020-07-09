using System;
using System.Collections.Generic;
using System.Text;
using PuzzelLibrary.Settings;

namespace PuzzelLibrary.AD.Connection.Credential
{
    internal class Username : IUsername
    {
        private string _UserName;
        private string _Password;

        public string UserName { get  { return _UserName; } }
        public string Password { get  { return _Password; } }

        public Username() 
        {
            GetCredential();
        }
        public void GetCredential()
        {
            var get = new GetSettings();
            this._UserName = get.UserName;
            this._Password = get.Password;
        }        
        public void SetCredential(string userName, string passWord)
        {
            var set = new SetSettings();
            set.UserName = userName;
            set.Password = passWord;
            set.Save();
        }
    }
}
