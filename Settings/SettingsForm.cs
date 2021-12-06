using System;
using System.Windows.Forms;

namespace Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(string ApplicationName)
        {
            InitializeComponent();
            if (Environment.OSVersion.Version.Major == 10 ||
                Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor > 1)
                this.DescriptionBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            OnLoad();
            if (ApplicationName != string.Empty)
                this.Text = ApplicationName + " - " + this.Text;
        }

        private void GetAllControls(Control container, ref System.Collections.Generic.List<Control> ctrl)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c, ref ctrl);
                if (c is TextBox | c is RichTextBox | c is CheckBox | c is NumericUpDown)
                    ctrl.Add(c);
            }
        }
        private Control[] GetCollectionOfFieldSettings()
        {
            System.Collections.Generic.List<Control> controls = new();
            GetAllControls(TabSettings, ref controls);
            return controls.ToArray();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ChangeChecked(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                ((CheckBox)sender).Text = "Włączone";
            }
            else ((CheckBox)sender).Text = "Wyłaczone";
            OnChangeSaveProperty(sender, e);
        }
        private void MouseOn(object sender, EventArgs e)
        {         
            foreach (var Value in typeof(Descriptions).GetFields())
            {
                if (((Control)sender).Name.Contains(Value.Name))
                {
                    DescriptionLabel.Text = Value.GetValue(null).ToString();
                    break;
                }
            }        
        }
        private void MouseOut(object sender, EventArgs e)
        {
            DescriptionLabel.Text = Descriptions._default;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            PuzzelLibrary.Settings.Values.CommitChanges();
            MessageBox.Show("Ustawienia zostały zapisane.\nZmiany wejdą w życie po ponownym uruchomieniu aplikacji","Zapisywanie ustawień",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void EnablingTextBox(object sender, EventArgs e)
        {
            CustomDataSourceTextBox.Enabled = CustomSourceCheck.Checked;
            LocalUpdatePathText.Enabled = LocalUpdateCheck.Checked;
        }

        private void SessionShortcutText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Alt && !e.Shift && !e.KeyCode.ToString().Contains("Oem"))
            SessionDisconectShortcutText.Text = e.Modifiers.ToString() + " + " + new KeysConverter().ConvertToString(e.KeyCode);

        }
        private void OnChangeSaveProperty(object sender, EventArgs e)
        {
            foreach (var propertyInfo in typeof(PuzzelLibrary.Settings.Values).GetProperties())
                if (((Control)sender).Name.Contains(propertyInfo.Name))
                {
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "Boolean": { propertyInfo.SetValue(null, Convert.ToBoolean(((CheckBox)sender).Checked)); break; }
                        case "Decimal": { propertyInfo.SetValue(null, Convert.ToDecimal(((NumericUpDown)sender).Value)); break; }
                        case "String" : { propertyInfo.SetValue(null, Convert.ToString(((TextBoxBase)sender).Text)); break; }
                    }
                }
        }
        

        private void OnLoad()
        {
            if (System.IO.File.Exists("Settings.xml"))
            {
                PuzzelLibrary.Settings.Values.LoadValues();
                HistoryLogCheck.Checked = PuzzelLibrary.Settings.Values.HistoryLog;
                CustomSourceCheck.Checked = PuzzelLibrary.Settings.Values.CustomSource;
                SaveUserDataCheck.Checked = PuzzelLibrary.Settings.Values.SaveUserData;
                AutoUnlockFirewallCheck.Checked = PuzzelLibrary.Settings.Values.AutoUnlockFirewall;
                AutoOpenPortCheck.Checked = PuzzelLibrary.Settings.Values.AutoOpenPort;
                SessionDisconectShortcutText.Text = PuzzelLibrary.Settings.Values.SessionDisconectShortcut;
                CustomDataSourceTextBox.Text = PuzzelLibrary.Settings.Values.CustomDataSource;
                UserMaxLogsNumeric.Value = PuzzelLibrary.Settings.Values.UserMaxLogs;
                CompMaxLogsNumeric.Value = PuzzelLibrary.Settings.Values.CompMaxLogs;
                LocalUpdateCheck.Checked = PuzzelLibrary.Settings.Values.LocalUpdateCheck;
                LocalUpdatePathText.Text = PuzzelLibrary.Settings.Values.LocalUpdatePath;
                AutoStartUpdateCheck.Checked = PuzzelLibrary.Settings.Values.AutostartUpdateCheck;
                TerminalLogsFolderText.Text = PuzzelLibrary.Settings.Values.TerminalLogsFolder;
                TerminalLogsSNFileText.Text = PuzzelLibrary.Settings.Values.TerminalLogsSNFile;
                TerminalLogsFileText.Text = PuzzelLibrary.Settings.Values.TerminalLogsFile;
                ComputerSNFileText.Text = PuzzelLibrary.Settings.Values.ComputerSNFile;
                ComputerLogsFolderTextBox.Text = PuzzelLibrary.Settings.Values.ComputerLogsFolder;
                CheckLogsBeforeStartUpCheck.Checked = PuzzelLibrary.Settings.Values.CheckLogsBeforeStartUp;
                MotpServersText.Text = PuzzelLibrary.Settings.Values.MotpServers;
                MotpLogNameText.Text = PuzzelLibrary.Settings.Values.MotpLogName;
                ComputerInputCheck.Checked = PuzzelLibrary.Settings.Values.ComputerInput;
                EventLogTableViewCheck.Checked = PuzzelLibrary.Settings.Values.EventLogTableView;
                DomainControllerText.Text = PuzzelLibrary.Settings.Values.DomainController;
            }
            else
            {
                foreach (var objSettings in GetCollectionOfFieldSettings())
                    if (objSettings != SessionDisconectShortcutText)
                        PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);

                PuzzelLibrary.Settings.Values.HistoryLog = HistoryLogCheck.Checked;
                PuzzelLibrary.Settings.Values.CustomSource = CustomSourceCheck.Checked;
                PuzzelLibrary.Settings.Values.SaveUserData = SaveUserDataCheck.Checked;
                PuzzelLibrary.Settings.Values.AutoUnlockFirewall = AutoUnlockFirewallCheck.Checked;
                PuzzelLibrary.Settings.Values.AutoOpenPort = AutoOpenPortCheck.Checked;
                PuzzelLibrary.Settings.Values.SessionDisconectShortcut = SessionDisconectShortcutText.Text;
                PuzzelLibrary.Settings.Values.CustomDataSource = CustomDataSourceTextBox.Text;
                PuzzelLibrary.Settings.Values.UserMaxLogs = UserMaxLogsNumeric.Value;
                PuzzelLibrary.Settings.Values.CompMaxLogs = CompMaxLogsNumeric.Value;
                PuzzelLibrary.Settings.Values.LocalUpdateCheck = LocalUpdateCheck.Checked;
                PuzzelLibrary.Settings.Values.LocalUpdatePath = LocalUpdatePathText.Text;
                PuzzelLibrary.Settings.Values.AutostartUpdateCheck = AutoStartUpdateCheck.Checked;
                PuzzelLibrary.Settings.Values.TerminalLogsFolder = TerminalLogsFolderText.Text;
                PuzzelLibrary.Settings.Values.TerminalLogsSNFile = TerminalLogsSNFileText.Text;
                PuzzelLibrary.Settings.Values.TerminalLogsFile = TerminalLogsFileText.Text;
                PuzzelLibrary.Settings.Values.ComputerLogsFolder = ComputerLogsFolderTextBox.Text;
                PuzzelLibrary.Settings.Values.ComputerSNFile = ComputerSNFileText.Text;
                PuzzelLibrary.Settings.Values.CheckLogsBeforeStartUp = CheckLogsBeforeStartUpCheck.Checked;
                PuzzelLibrary.Settings.Values.MotpLogName = MotpLogNameText.Text;
                PuzzelLibrary.Settings.Values.MotpServers= MotpServersText.Text;
                PuzzelLibrary.Settings.Values.ComputerInput = ComputerInputCheck.Checked;
                PuzzelLibrary.Settings.Values.EventLogTableView = EventLogTableViewCheck.Checked;
                PuzzelLibrary.Settings.Values.DomainController = DomainControllerText.Text;
            }
        }

        private void RestoreDefaultSettings(object sender, EventArgs e)
        {
            foreach (var objSettings in GetCollectionOfFieldSettings())
                PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
        }
    }
}
