using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PuzzelLibrary.Settings
{
    public interface IValues
    {
        static bool HistoryLog { get; set; }
        static long UserMaxLogs { get; set; }
        static long CompMaxLogs { get; set; }
        static bool CustomSource { get; set; }
        static bool AutoOpenPort { get; set; }
        static bool AutoUnlockFirewall { get; set; }
        static bool SaveUserData { get; set; }

    }
}
