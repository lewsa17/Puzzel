using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzelLibrary.AD.Connection.Credential
{
    interface IUsername
    {
        string UserName { get; }
        string Password { get; }
        void GetCredential();
        void SetCredential(string userName, string passWord);

    }
}
