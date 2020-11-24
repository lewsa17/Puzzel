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
        Control[] ListOfFieldWithSettings = { localUpdateCheck, localUpdateTextBox, AutostartUpdateCheck,AutoOpenPortCheck, AutoUnlockFirewallCheck, HistoryLogCheck, CustomSourceCheck, SaveUserDataCheck, SessionShortcutText, CustomSourceTextBox, NumbersOfCompLogs, NumbersOfUserLogs, TerminalLogsFileTextBox,TerminalLogsFolderTextBox,TerminalLogsSNFileTextBox };
            return ListOfFieldWithSettings;
        }

        static readonly string defaultDescription = "Najedź kursorem na opcję aby wyświetlić tutaj jej opis";
        static readonly string HistoryLogDescription = "Ustawienie tej opcji będzie wyświetlać lub nie ostatnio wyszukiwanej wartości";
        static readonly string NumbersOfUserLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań użytkownika jaką można wyszukać";
        static readonly string NumbersOfCompLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań do komputera jaką można wyszukać";
        static readonly string CustomSourceCheckDescription = "Zezwala na wyszukiwanie sesji z ręcznie przygotowanej listy";
        static readonly string CustomSourceTextBoxDescription = "Podaj nazwę terminali z których będa wyszukiwane sesje, musi być odzielone przecinkami";
        static readonly string AutoOpenPortDescription = "Zmiana tej wartości wyłączy pytanie o otwarcie portu 135 (RPC) odpowiedzialny za wykonywanie niektórych funkcji - będzie to wykonywane automatycznie";
        static readonly string AutoUnlockFirewallDescription = "Zmiana tej wartości wyłączy pytanie o odblokowywanie Zdalnej Zapory - będzie to wykonywane automatycznie";
        static readonly string SaveUserDataCheckDescription = "Zamiana tej wartości wyłączy pytanie o zapisywanie danych użytkownika przy usuwaniu - będzie to wykonywane automatycznie";
        static readonly string SessionShortcutDescription = "Ustaw skrót klawiszowy odpowiedzialny za rozłączanie się od sesji zdalnej. \nWystarczy zaznaczyć kursorem na pole tekstowe i nacisnąć klawisze\nDziała tylko do serwera terminali 2008R2";
        static readonly string LocalUpdateDescription = "Zmienia miejsce wyszukiwania aktualizacji / ze zdalnie na lokalnie";
        static readonly string AutoStartUpdateDescription = "Automatyczne sprawdzanie aktualizacji przy uruchomieniu";
        static readonly string TerminalLogsSNFileDescription = "Podaj nazwę pliku zawierającego numery seryjne terminali";
        static readonly string TerminalLogsFileDescription = "Podaj nazwy plików odzielone przecinkiem zawierające logi terminali";
        static readonly string TerminalLogsFolderDescription = "Podaj lokalizację zawierająca logi terminali";

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
            switch (Name)
            {
                case nameof(HistoryLogCheck):
                    {
                        DescriptionLabel.Text = HistoryLogDescription;
                        break;
                    }
                case nameof(UserMaxLogs):
                    {
                        DescriptionLabel.Text = NumbersOfUserLogsDescription;
                        break;
                    }
                case nameof(CompMaxLogs):
                    {
                        DescriptionLabel.Text = NumbersOfCompLogsDescription;
                        break;
                    }
                case nameof(CustomSourceCheck):
                    {
                        DescriptionLabel.Text = CustomSourceCheckDescription;
                        break;
                    }
                case nameof(AutoOpenPortCheck):
                    {
                        DescriptionLabel.Text = AutoOpenPortDescription;
                        break;
                    }
                case nameof(AutoUnlockFirewallCheck):
                    {
                        DescriptionLabel.Text = AutoUnlockFirewallDescription;
                        break;
                    }
                case nameof(SaveUserDataCheck):
                    {
                        DescriptionLabel.Text = SaveUserDataCheckDescription;
                        break;
                    }
                case nameof(SessionShortcutLabel):
                    {
                        DescriptionLabel.Text = SessionShortcutDescription;
                        break;
                    }
                case nameof(localUpdateCheck):
                    {
                        DescriptionLabel.Text = LocalUpdateDescription;
                        break;
                    }
                case nameof(AutostartUpdateCheck):
                    {
                        DescriptionLabel.Text = AutoStartUpdateDescription;
                        break;
                    }
                case nameof(TerminalLogsFileLabel):
                    {
                        DescriptionLabel.Text = TerminalLogsFileDescription;
                        break;
                    }
                case nameof(TerminalLogsFileTextBox):
                    {
                        DescriptionLabel.Text = TerminalLogsFileDescription;
                        break;
                    }
                case nameof(TerminalLogsFolderLabel):
                    {
                        DescriptionLabel.Text = TerminalLogsFolderDescription;
                        break;
                    }
                case nameof(TerminalLogsFolderTextBox):
                    {
                        DescriptionLabel.Text = TerminalLogsFolderDescription;
                        break;
                    }
                case nameof(TerminalLogsSNFileLabel):
                    {
                        DescriptionLabel.Text = TerminalLogsSNFileDescription;
                        break; 
                    }
                case nameof(TerminalLogsSNFileTextBox):
                    {
                        DescriptionLabel.Text = TerminalLogsSNFileDescription;
                        break;
                    }
                case nameof(localUpdateTextBox):
                    { 
                        DescriptionLabel.Text = LocalUpdateDescription;
                        break;
                    }
                case nameof(CustomSourceTextBox):
                    {
                        DescriptionLabel.Text = CustomSourceTextBoxDescription;
                        break;
                    }
                case nameof(SessionShortcutText):
                    {
                        DescriptionLabel.Text = SessionShortcutDescription;
                        break;
                    }
            };               
        
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

            if (localUpdateCheck.Checked)
            {
                localUpdateTextBox.Enabled = true;
            }
            else localUpdateTextBox.Enabled = false;
        }

        private void SessionShortcutText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Alt && !e.Shift && !e.KeyCode.ToString().Contains("Oem"))
            SessionShortcutText.Text = e.Modifiers.ToString() + " + " + new KeysConverter().ConvertToString(e.KeyCode);

        }
        private void OnChangeSaveProperty(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            { 
                return;
            }
            if (sender is CheckBox check)
            {
                switch (check.Name)
                {
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
                    case nameof(localUpdateCheck):
                        {
                            PuzzelLibrary.Settings.Values.LocalUpdateCheck = localUpdateCheck.Checked;
                            break;
                        }
                    case nameof(AutostartUpdateCheck):
                        {
                            PuzzelLibrary.Settings.Values.AutostartUpdateCheck = AutostartUpdateCheck.Checked;
                            break;
                        }
                }
                return;
            }
            if (sender is TextBox tbx)
            {
                switch (tbx.Name)
                {
                    case nameof(SessionShortcutText):
                        {
                            PuzzelLibrary.Settings.Values.SessionDisconectShortcut = SessionShortcutText.Text;
                            break;
                        }
                    case nameof(localUpdateTextBox):
                        {
                            PuzzelLibrary.Settings.Values.LocalUpdatePath = localUpdateTextBox.Text;
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
                }
                return;
            }
            if (sender is RichTextBox rtbx)
            {
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
                localUpdateCheck.Checked = PuzzelLibrary.Settings.Values.LocalUpdateCheck;
                localUpdateTextBox.Text = PuzzelLibrary.Settings.Values.LocalUpdatePath;
                AutostartUpdateCheck.Checked = PuzzelLibrary.Settings.Values.AutostartUpdateCheck;
                TerminalLogsFolderTextBox.Text = PuzzelLibrary.Settings.Values.TerminalLogsFolder;
                TerminalLogsSNFileTextBox.Text = PuzzelLibrary.Settings.Values.TerminalLogsSNFile;
                TerminalLogsFileTextBox.Text = PuzzelLibrary.Settings.Values.TerminalLogsFile;
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
                PuzzelLibrary.Settings.Values.LocalUpdateCheck = localUpdateCheck.Checked;
                PuzzelLibrary.Settings.Values.LocalUpdatePath = localUpdateTextBox.Text;
                PuzzelLibrary.Settings.Values.AutostartUpdateCheck = AutostartUpdateCheck.Checked;
                PuzzelLibrary.Settings.Values.TerminalLogsFolder = TerminalLogsFolderTextBox.Text;
                PuzzelLibrary.Settings.Values.TerminalLogsSNFile = TerminalLogsSNFileTextBox.Text;
                PuzzelLibrary.Settings.Values.TerminalLogsFile = TerminalLogsFileTextBox.Text;
            }
        }

        private void RestoreDefaultSettings(object sender, EventArgs e)
        {
            foreach (var objSettings in GetCollectionOfFieldSettings())
                PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
        }
    }
}