using System;
using System.Windows.Forms;

namespace Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(string ApplicationName)
        {
            InitializeComponent();
            if (ApplicationName != string.Empty)
                this.Text = ApplicationName + " - " + this.Text;
        }
        static string defaultDescription = "Najedź kursorem na opcję aby wyświetlić tutaj jej opis";
        static string logsHistoryDescription = "Ustawienie tej opcji będzie wyświetlać lub nie ostatnio wyszukiwane wartości";
        static string userMaxLogsDesctiption = "Zmiana tej wartości ustala maksymalną liczbę logowań użytkownika jaką można wyszukać";
        static string compMaxLogsDescription = "Zmiana tej wartości ustala maksymalną liczbę logowań do komputera jaką można wyszukać";
        static string customSourceSessionDescription = "Zezwala na wyszukiwanie sesji z ręcznie przygotowanej listy";
        static string autoOpenPortDescription = "Zmiana tej wartości wyłączy pytanie o otwarcie portu 135 (RPC) odpowiedzialny za wykonywanie niektórych funkcji - będzie to wykonywane automatycznie";
        static string autoUnlockFirewallDescription = "Zmiana tej wartości wyłączy pytanie o odblokowywanie Zdalnej Zapory - będzie to wykonywane automatycznie";
        static string autoSaveDataDescription = "Zamiana tej wartości wyłączy pytanie o zapisywanie danych użytkownika przy usuwaniu - będzie to wykonywane automatycznie";
        static string sessionShortcutDescription = "Ustaw skrót klawiszowy odpowiedzialny za rozłączanie się z sesji zdalnej. \nWystarczy zaznaczyć kursorem na pole tekstowe i nacisnąć klawisze";

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
                case "CheckBoxHistoryLog": 
                    {
                        DescriptionLabel.Text = logsHistoryDescription; 
                        break; 
                    }
                case "UserMaxLogs":
                    {
                        DescriptionLabel.Text = userMaxLogsDesctiption;
                        break;
                    }
                case "CompMaxLogs":
                    {
                        DescriptionLabel.Text = compMaxLogsDescription;
                        break;
                    }
                case "CustomSourceCheck":
                    {
                        DescriptionLabel.Text = customSourceSessionDescription;
                        break;
                    }
                case "AutoOpenPortCheck":
                    {
                        DescriptionLabel.Text = autoOpenPortDescription;
                        break;
                    }
                case "AutoUnlockFirewallCheck":
                    {
                        DescriptionLabel.Text = autoUnlockFirewallDescription;
                        break;
                    }
                case "SaveUserDataCheck":
                    {
                        DescriptionLabel.Text = autoSaveDataDescription;
                        break;
                    }
                case "SessionShortcutLabel":
                    {
                        DescriptionLabel.Text = sessionShortcutDescription;
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
                    case nameof(CheckBoxHistoryLog):
                        {
                            PuzzelLibrary.Settings.Values.HistoryLog = CheckBoxHistoryLog.Checked;
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
                            break; }
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
                    case nameof(numericUserLogs):
                        {
                            PuzzelLibrary.Settings.Values.UserMaxLogs = numericUserLogs.Value;
                            break;
                        }
                    case nameof(numericCompLogs):
                        {
                            PuzzelLibrary.Settings.Values.CompMaxLogs = numericCompLogs.Value;
                            break;
                        }
                }
            return;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("Settings.xml"))
            {
                PuzzelLibrary.Settings.Values.LoadValues();
            }
            else
            {
                PuzzelLibrary.Settings.Values.HistoryLog = CheckBoxHistoryLog.Checked;
                PuzzelLibrary.Settings.Values.CustomSource = CustomSourceCheck.Checked;
                PuzzelLibrary.Settings.Values.SaveUserData = SaveUserDataCheck.Checked;
                PuzzelLibrary.Settings.Values.AutoUnlockFirewall = AutoUnlockFirewallCheck.Checked;
                PuzzelLibrary.Settings.Values.AutoOpenPort = AutoOpenPortCheck.Checked;
                PuzzelLibrary.Settings.Values.SessionDisconectShortcut = SessionShortcutText.Text;
                PuzzelLibrary.Settings.Values.CustomSourceData = CustomSourceTextBox.Text;
                PuzzelLibrary.Settings.Values.UserMaxLogs = numericUserLogs.Value;
                PuzzelLibrary.Settings.Values.CompMaxLogs = numericCompLogs.Value;
            }
        }
    }
}
