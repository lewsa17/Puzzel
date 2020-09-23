using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace PuzzelLibrary.Settings
{
   public class Values : IValues
    {
        public static bool HistoryLog { get; set; }
        public static decimal UserMaxLogs { get; set; }
        public static decimal CompMaxLogs { get; set; }
        public static bool CustomSource { get; set; }
        public static string CustomSourceData { get; set; }
        public static bool AutoOpenPort { get; set; }
        public static bool AutoUnlockFirewall { get; set; }
        public static bool SaveUserData { get; set; }
        public static string SessionDisconectShortcut { get; set; }

        public static void CommitChanges()
        {
            XmlWriter writer = null;
            if (File.Exists("Settings.xml"))
                File.Delete("Settings.xml");
            writer = new SetSettings().CreateSettingsFile();
            SetSettings.CreateSettingValues(writer);
            SetSettings.CloseSettingsFile(writer);
        }
        public static void LoadValues()
        {

        }
    }
}
