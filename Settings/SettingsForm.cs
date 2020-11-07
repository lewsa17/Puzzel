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
            Control[] ListOfFieldWithSettings = { AutoOpenPortCheck, AutoUnlockFirewallCheck, HistoryLogCheck, CustomSourceCheck, SaveUserDataCheck, SessionShortcutText, CustomSourceTextBox, NumbersOfCompLogs, NumbersOfUserLogs };
            return ListOfFieldWithSettings;
        }

        static string defaultDescription = "Najedź kursorem na opcję aby wyświetlić tutaj jej opis";
        static string HistoryLogDescription = "Ustawienie tej opcji będzie wyświetlać lub nie ostatnio wyszukiwanej wartości";
        static string NumbersOfUserLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań użytkownika jaką można wyszukać";
        static string NumbersOfCompLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań do komputera jaką można wyszukać";
        static string CustomSourceDescription = "Zezwala na wyszukiwanie sesji z ręcznie przygotowanej listy";
        static string AutoOpenPortDescription = "Zmiana tej wartości wyłączy pytanie o otwarcie portu 135 (RPC) odpowiedzialny za wykonywanie niektórych funkcji - będzie to wykonywane automatycznie";
        static string AutoUnlockFirewallDescription = "Zmiana tej wartości wyłączy pytanie o odblokowywanie Zdalnej Zapory - będzie to wykonywane automatycznie";
        static string SaveUserDataCheckDescription = "Zamiana tej wartości wyłączy pytanie o zapisywanie danych użytkownika przy usuwaniu - będzie to wykonywane automatycznie";
        static string SessionShortcutDescription = "Ustaw skrót klawiszowy odpowiedzialny za rozłączanie się z sesji zdalnej. \nWystarczy zaznaczyć kursorem na pole tekstowe i nacisnąć klawisze";
        static string LocalUpdateDescription = "Zmienia miejsce wyszukiwania aktualizacji / ze zdalnie na lokalnie";
        static string AutoStartUpdateDescription = "Automatyczne sprawdzanie aktualizacji przy uruchomieniu";


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
            if (sender is CheckBox)
            Name = ((CheckBox)sender).Name;
            if (sender is Label)
                Name = ((Label)sender).Name;
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
                        DescriptionLabel.Text = CustomSourceDescription;
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
            if (sender is CheckBox)
            {
                switch (((CheckBox)sender).Name)
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
            if (sender is TextBox)
            {
                switch (((TextBox)sender).Name)
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
                }
                return;
            }
            if (sender is RichTextBox)
            {
                switch (((RichTextBox)sender).Name)
                {
                    case nameof(CustomSourceTextBox):
                        {
                            PuzzelLibrary.Settings.Values.CustomSourceData = CustomSourceTextBox.Text;
                            break;
                        }
                }
            return;
            }
            if (sender is NumericUpDown)
            {
                switch (((NumericUpDown)sender).Name)
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
            }
        }

        private void RestoreDefaultSettings(object sender, EventArgs e)
        {
            foreach (var objSettings in GetCollectionOfFieldSettings())
                PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
        }
    }
}
