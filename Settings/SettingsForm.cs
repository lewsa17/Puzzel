using System;
using System.Windows.Forms;

namespace Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(string ApplicationName)
        {
            InitializeComponent();
            OnLoad();
            if (ApplicationName != string.Empty)
                this.Text = ApplicationName + " - " + this.Text;
        }
        private Control[] GetCollectionOfFieldSettings()
        {
            Control[] ListOfFieldWithSettings = { NumbersOfUserLogs, NumbersOfCompLogs, HistoryLogCheck, CustomSourceCheck, LocalUpdateCheck, AutoStartUpdateCheck, SaveUserDataCheck, AutoUnlockFirewallCheck, AutoOpenPortCheck, CheckLogsBeforeStartUpCheck, SessionShortcutText, LocalUpdateTextBox, ComputerLogsFolderTextBox, ComputerSNFileTextBox, TerminalLogsSNFileTextBox, TerminalLogsFileTextBox, TerminalLogsFolderTextBox, CustomSourceTextBox, MotpServersTextBox, MotpLogNameTextBox, ComputerInputCheck };
            return ListOfFieldWithSettings;
        }

        static readonly string defaultDescription = "Najedź kursorem na opcję aby wyświetlić tutaj jej opis";
        public static readonly string HistoryLogDescription = "Ustawienie tej opcji będzie wyświetlać lub nie ostatnio wyszukiwanej wartości";
        public static readonly string UserMaxLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań użytkownika jaką można wyszukać";
        public static readonly string CompMaxLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań do komputera jaką można wyszukać";
        public static readonly string CustomSourceCheckDescription = "Zezwala na wyszukiwanie sesji z ręcznie przygotowanej listy";
        public static readonly string CustomSourceTextBoxDescription = "Podaj nazwę terminali z których będa wyszukiwane sesje, musi być odzielone przecinkami";
        public static readonly string AutoOpenPortDescription = "Zmiana tej wartości wyłączy pytanie o otwarcie portu 135 (RPC) odpowiedzialny za wykonywanie niektórych funkcji - będzie to wykonywane automatycznie";
        public static readonly string AutoUnlockFirewallDescription = "Zmiana tej wartości wyłączy pytanie o odblokowywanie Zdalnej Zapory - będzie to wykonywane automatycznie";
        public static readonly string SaveUserDataCheckDescription = "Zamiana tej wartości wyłączy pytanie o zapisywanie danych użytkownika przy usuwaniu - będzie to wykonywane automatycznie";
        public static readonly string SessionShortcutDescription = "Ustaw skrót klawiszowy odpowiedzialny za rozłączanie się od sesji zdalnej. \nWystarczy zaznaczyć kursorem na pole tekstowe i nacisnąć klawisze\nDziała tylko do serwera terminali 2008R2";
        public static readonly string LocalUpdateDescription = "Zmienia miejsce wyszukiwania aktualizacji / ze zdalnie na lokalnie";
        public static readonly string AutoStartUpdateDescription = "Automatyczne sprawdzanie aktualizacji przy uruchomieniu";
        public static readonly string TerminalLogsSNFileDescription = "Podaj nazwę pliku zawierającego numery seryjne terminali";
        public static readonly string TerminalLogsFileDescription = "Podaj nazwy plików odzielone przecinkiem zawierające logi terminali";
        public static readonly string TerminalLogsFolderDescription = "Podaj lokalizację zawierająca logi terminali";
        public static readonly string ComputerSNFileDescription = "Podaj nazwę pliku zawierającego numery seryjne komputerów";
        public static readonly string ComputerLogsFolderDescription = "Podaj lokalizację zawierająca logi komputera";
        public static readonly string CheckLogsBeforeStartUpDescription = "Ustaw czy podczas uruchomienia logi mają być odświeżane";
        public static readonly string MotpServersDescription = "Podaj nazawy hosta dla serwerów motp (Odzielone , lub ;)";
        public static readonly string MotpLogNameDescription = "Podaj nazwę dziennika dla serwera motp";
        public static readonly string ComputerInputDescription = "Ustawienie tej wartości spowododuje podstawianie ostatnio używanej nazwy komputera przy wyszukiwaniu użytkownika";

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
            string Name = string.Empty;
            if (sender is CheckBox check)
                Name = check.Name;
            if (sender is Label label)
                Name = label.Name;
            if (sender is TextBox tbx)
                Name = tbx.Name;
            if (sender is RichTextBox rcbx)
                Name = rcbx.Name;
            foreach (var Value in typeof(SettingsForm).GetFields())
            {
                var replacedname = Value.Name.Replace("Description", "");
                if (Name.Contains(Value.Name.Replace("Description", "")))
                {
                    DescriptionLabel.Text = Value.GetValue(null).ToString();
                    break;
                }
            }        
        }
        private void MouseOut(object sender, EventArgs e)
        {
            DescriptionLabel.Text = defaultDescription;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            PuzzelLibrary.Settings.Values.CommitChanges();
            MessageBox.Show("Ustawienia zostały zapisane.\nZmiany wejdą w życie po ponownym uruchomieniu aplikacji","Zapisywanie ustawień",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void EnablingTextBox(object sender, EventArgs e)
        {
            if (CustomSourceCheck.Checked)
            {
                CustomSourceTextBox.Enabled = true;
            }
            else CustomSourceTextBox.Enabled = false;

            if (LocalUpdateCheck.Checked)
            {
                LocalUpdateTextBox.Enabled = true;
            }
            else LocalUpdateTextBox.Enabled = false;
        }

        private void SessionShortcutText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Alt && !e.Shift && !e.KeyCode.ToString().Contains("Oem"))
            SessionShortcutText.Text = e.Modifiers.ToString() + " + " + new KeysConverter().ConvertToString(e.KeyCode);

        }
        private void OnChangeSaveProperty(object sender, EventArgs e)
        {
            foreach (var Value in typeof(PuzzelLibrary.Settings.Values).GetProperties())
            {
                if (sender is ComboBox)
                {
                    return;
                }
                if (sender is CheckBox check)
                {
                    if (check.Name.Contains(Value.Name))
                    {
                        Value.SetValue(null, check.Checked);
                    }
                    switch (check.Name)
                    {
                        case nameof(CheckLogsBeforeStartUpCheck):
                            {
                                PuzzelLibrary.Settings.Values.CheckLogsBeforeStartUp = CheckLogsBeforeStartUpCheck.Checked;
                                break;
                            }
                        case nameof(HistoryLogCheck):
                            {
                                PuzzelLibrary.Settings.Values.HistoryLog = HistoryLogCheck.Checked;
                                break;
                            }
                        case nameof(CustomSourceCheck):
                            {
                                PuzzelLibrary.Settings.Values.CustomSource = CustomSourceCheck.Checked;
                                break;
                            }
                        case nameof(SaveUserDataCheck):
                            {
                                PuzzelLibrary.Settings.Values.SaveUserData = SaveUserDataCheck.Checked;
                                break;
                            }
                        case nameof(AutoUnlockFirewallCheck):
                            {
                                PuzzelLibrary.Settings.Values.AutoUnlockFirewall = AutoUnlockFirewallCheck.Checked;
                                break;
                            }
                        case nameof(AutoOpenPortCheck):
                            {
                                PuzzelLibrary.Settings.Values.AutoOpenPort = AutoOpenPortCheck.Checked;
                                break;
                            }
                        case nameof(LocalUpdateCheck):
                            {
                                PuzzelLibrary.Settings.Values.LocalUpdateCheck = LocalUpdateCheck.Checked;
                                break;
                            }
                        case nameof(AutoStartUpdateCheck):
                            {
                                PuzzelLibrary.Settings.Values.AutostartUpdateCheck = AutoStartUpdateCheck.Checked;
                                break;
                            }
                        case nameof(ComputerInputCheck):
                            {
                                PuzzelLibrary.Settings.Values.ComputerInput = ComputerInputCheck.Checked;
                                break;
                            }
                    }
                    return;
                }
                if (sender is TextBox tbx)
                {
                    if (tbx.Name.Contains(Value.Name))
                    {
                        Value.SetValue(typeof(PuzzelLibrary.Settings.Values), tbx.Text);
                    }
                    switch (tbx.Name)
                    {
                        case nameof(SessionShortcutText):
                            {
                                PuzzelLibrary.Settings.Values.SessionDisconectShortcut = SessionShortcutText.Text;
                                break;
                            }
                        case nameof(LocalUpdateTextBox):
                            {
                                PuzzelLibrary.Settings.Values.LocalUpdatePath = LocalUpdateTextBox.Text;
                                break;
                            }
                        case nameof(TerminalLogsFileTextBox):
                            {
                                PuzzelLibrary.Settings.Values.TerminalLogsFile = TerminalLogsFileTextBox.Text;
                                break;
                            }
                        case nameof(TerminalLogsFolderTextBox):
                            {
                                PuzzelLibrary.Settings.Values.TerminalLogsFolder = TerminalLogsFolderTextBox.Text;
                                break;
                            }
                        case nameof(TerminalLogsSNFileTextBox):
                            {
                                PuzzelLibrary.Settings.Values.TerminalLogsSNFile = TerminalLogsSNFileTextBox.Text;
                                break;
                            }
                        case nameof(ComputerLogsFolderTextBox):
                            {
                                PuzzelLibrary.Settings.Values.ComputerLogsFolder = ComputerLogsFolderTextBox.Text;
                                break;
                            }
                        case nameof(ComputerSNFileTextBox):
                            {
                                PuzzelLibrary.Settings.Values.ComputerSNFile = ComputerSNFileTextBox.Text;
                                break;
                            }
                        case nameof(MotpLogNameTextBox):
                            {
                                PuzzelLibrary.Settings.Values.MotpLogName = MotpLogNameTextBox.Text;
                                break;
                            }
                        case nameof(MotpServersTextBox):
                            {
                                PuzzelLibrary.Settings.Values.MotpServers = MotpServersTextBox.Text;
                                break;
                            }
                    }
                    return;
                }
                if (sender is RichTextBox rtbx)
                {
                    if (rtbx.Name.Contains(Value.Name))
                    {
                        Value.SetValue(null, rtbx.Text);
                    }
                    switch (rtbx.Name)
                    {
                        case nameof(CustomSourceTextBox):
                            {
                                PuzzelLibrary.Settings.Values.CustomSourceData = CustomSourceTextBox.Text;
                                break;
                            }
                    }
                    return;
                }
                if (sender is NumericUpDown numeric)
                {
                    if (numeric.Name.Contains(Value.Name))
                    {
                        Value.SetValue(null, numeric.Value);
                    }
                    switch (numeric.Name)
                    {
                        case nameof(NumbersOfUserLogs):
                            {
                                PuzzelLibrary.Settings.Values.UserMaxLogs = NumbersOfUserLogs.Value;
                                break;
                            }
                        case nameof(NumbersOfCompLogs):
                            {
                                PuzzelLibrary.Settings.Values.CompMaxLogs = NumbersOfCompLogs.Value;
                                break;
                            }
                    }
                    return;
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
                SessionShortcutText.Text = PuzzelLibrary.Settings.Values.SessionDisconectShortcut;
                CustomSourceTextBox.Text = PuzzelLibrary.Settings.Values.CustomSourceData;
                NumbersOfUserLogs.Value = PuzzelLibrary.Settings.Values.UserMaxLogs;
                NumbersOfCompLogs.Value = PuzzelLibrary.Settings.Values.CompMaxLogs;
                LocalUpdateCheck.Checked = PuzzelLibrary.Settings.Values.LocalUpdateCheck;
                LocalUpdateTextBox.Text = PuzzelLibrary.Settings.Values.LocalUpdatePath;
                AutoStartUpdateCheck.Checked = PuzzelLibrary.Settings.Values.AutostartUpdateCheck;
                TerminalLogsFolderTextBox.Text = PuzzelLibrary.Settings.Values.TerminalLogsFolder;
                TerminalLogsSNFileTextBox.Text = PuzzelLibrary.Settings.Values.TerminalLogsSNFile;
                TerminalLogsFileTextBox.Text = PuzzelLibrary.Settings.Values.TerminalLogsFile;
                ComputerSNFileTextBox.Text = PuzzelLibrary.Settings.Values.ComputerSNFile;
                ComputerLogsFolderTextBox.Text = PuzzelLibrary.Settings.Values.ComputerLogsFolder;
                CheckLogsBeforeStartUpCheck.Checked = PuzzelLibrary.Settings.Values.CheckLogsBeforeStartUp;
                MotpServersTextBox.Text = PuzzelLibrary.Settings.Values.MotpServers;
                MotpLogNameTextBox.Text = PuzzelLibrary.Settings.Values.MotpLogName;
                ComputerInputCheck.Checked = PuzzelLibrary.Settings.Values.ComputerInput;
            }
            else
            {
                foreach (var objSettings in GetCollectionOfFieldSettings())
                    if (objSettings != SessionShortcutText)
                        PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
                PuzzelLibrary.Settings.Values.HistoryLog = HistoryLogCheck.Checked;
                PuzzelLibrary.Settings.Values.CustomSource = CustomSourceCheck.Checked;
                PuzzelLibrary.Settings.Values.SaveUserData = SaveUserDataCheck.Checked;
                PuzzelLibrary.Settings.Values.AutoUnlockFirewall = AutoUnlockFirewallCheck.Checked;
                PuzzelLibrary.Settings.Values.AutoOpenPort = AutoOpenPortCheck.Checked;
                PuzzelLibrary.Settings.Values.SessionDisconectShortcut = SessionShortcutText.Text;
                PuzzelLibrary.Settings.Values.CustomSourceData = CustomSourceTextBox.Text;
                PuzzelLibrary.Settings.Values.UserMaxLogs = NumbersOfUserLogs.Value;
                PuzzelLibrary.Settings.Values.CompMaxLogs = NumbersOfCompLogs.Value;
                PuzzelLibrary.Settings.Values.LocalUpdateCheck = LocalUpdateCheck.Checked;
                PuzzelLibrary.Settings.Values.LocalUpdatePath = LocalUpdateTextBox.Text;
                PuzzelLibrary.Settings.Values.AutostartUpdateCheck = AutoStartUpdateCheck.Checked;
                PuzzelLibrary.Settings.Values.TerminalLogsFolder = TerminalLogsFolderTextBox.Text;
                PuzzelLibrary.Settings.Values.TerminalLogsSNFile = TerminalLogsSNFileTextBox.Text;
                PuzzelLibrary.Settings.Values.TerminalLogsFile = TerminalLogsFileTextBox.Text;
                PuzzelLibrary.Settings.Values.ComputerLogsFolder = ComputerLogsFolderTextBox.Text;
                PuzzelLibrary.Settings.Values.ComputerSNFile = ComputerSNFileTextBox.Text;
                PuzzelLibrary.Settings.Values.CheckLogsBeforeStartUp = CheckLogsBeforeStartUpCheck.Checked;
                PuzzelLibrary.Settings.Values.MotpLogName = MotpLogNameTextBox.Text;
                PuzzelLibrary.Settings.Values.MotpServers= MotpServersTextBox.Text;
                PuzzelLibrary.Settings.Values.ComputerInput = ComputerInputCheck.Checked;
            }
        }

        private void RestoreDefaultSettings(object sender, EventArgs e)
        {
            foreach (var objSettings in GetCollectionOfFieldSettings())
                PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
        }
    }
}
