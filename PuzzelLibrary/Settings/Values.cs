using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace PuzzelLibrary.Settings
{
    public static class Values
    {
        public static bool HistoryLog { get; set; }
        public static decimal UserMaxLogs = 100;
        public static decimal CompMaxLogs = 100;
        public static bool CustomSource { get; set; }
        public static string CustomSourceData { get; set; }
        public static bool AutoOpenPort { get; set; }
        public static bool AutoUnlockFirewall { get; set; }
        public static bool SaveUserData { get; set; }
        public static string SessionDisconectShortcut { get; set; }
        public static bool AutostartUpdateCheck { set; get; }
        public static bool LocalUpdateCheck { get; set; }
        public static string LocalUpdatePath { get; set; }
        public static bool defaultCheckBoxesValue;
        public static string defaultTextBoxesValue;
        public static decimal defaultNumericUDValue = 5;
        public static void CommitChanges()
        {
            if (File.Exists("Settings.xml"))
                File.Delete("Settings.xml");
            XmlWriter writer = new SetSettings().CreateSettingsFile();
            SetSettings.CreateSettingValues(writer);
            SetSettings.CloseSettingsFile(writer);
        }

        public static void LoadValues()
        {
            if (File.Exists("Settings.xml"))
                GetSettings.LoadValues("Settings.xml");
            else CommitChanges();
        }
        public static void RestoreDefaultSettings(object sender)
        {
            if (sender is CheckBox check)
                check.Checked = defaultCheckBoxesValue;
            else if (sender is TextBox tbx)
                tbx.Text = defaultTextBoxesValue;
            else if (sender is RichTextBox rtb)
              rtb.Text = defaultTextBoxesValue;
            else if (sender is NumericUpDown numeric)
                numeric.Value = defaultNumericUDValue;
        }
    }
}
