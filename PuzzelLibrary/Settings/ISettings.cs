using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzelLibrary.Settings
{
    interface ISettings
    {
        string UserName { get; }
        string Password { get; }
        string Version { get; }
    }
}
