using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzel
{
    public partial class Ustawienia : Form
    {
        public Ustawienia()
        {
            InitializeComponent();
        }

        private const string MessageText = "Ustawienia zostały zapisane";
        private const string MessageCaption = "Zapisywanie ustawień";
        private const string V = "BRAK";
        Properties.Settings Settings;
        string[,] settingsArray = new string[21, 2];
        //object activeButton = null;
        private void SetValueSettings(object sender)
        {
            string shortcut = null;
            if (comboBox4.Text != "BRAK")
            {
                shortcut += comboBox4.Text + "+";
            }
            else shortcut += "BRAK+";
            if (comboBox5.Text != "BRAK")
            {
                shortcut += comboBox5.Text/* + "+"*/;
            }
            else shortcut += "BRAK"/*+"*/;
            //if (comboBox6.Text != "BRAK")
            //{
            //    shortcut += comboBox6.Text;
            //}
            Button btn = (Button)sender;
            for (int i = 0; i < 21; i++)
            {
                if (settingsArray[i, 0] != null)
                {
                    if (settingsArray[i, 0] == btn.Name)
                    {
                        settingsArray[i, 0] = btn.Name;
                        settingsArray[i, 1] = shortcut;
                        break;
                    }
                }
                else
                {
                    settingsArray[i, 0] = btn.Name;
                    settingsArray[i, 1] = shortcut;
                    break;
                }
            }
            infoSettingsSaved = false;
        }
        bool infoSettingsSaved = false;

        private void SaveValueSettings(string ButtonName, string value)
        {
            switch (ButtonName)
            {
                case "DW":
                    {
                        Settings.DW = value;
                        break;
                    }
                case "ExplorerC":
                    {
                        Settings.ExplorerC = value;
                        break;
                    }
                case "Info_z_AD":
                    {
                        Settings.Info_z_AD = value;
                        break;
                    }
                case "Karty_sieciowe":
                    {
                        Settings.Karty_sieciowe = value;
                        break;
                    }
                case "KomputerInfo":
                    {
                        Settings.KomputerInfo = value;
                        break;
                    }
                case "KomputerLog":
                    {
                        Settings.KomputerLog = value;
                        break;
                    }
                case "Lista_program":
                    {
                        Settings.Lista_program = value;
                        break;
                    }
                case "Logoff":
                    {
                        Settings.Logoff = value;
                        break;
                    }
                case "Ping":
                    {
                        Settings.Ping = value;
                        break;
                    }
                case "Polacz":
                    {
                        Settings.Polacz = value;
                        break;
                    }
                case "Profil_ERI":
                    {
                        Settings.Profil_ERI = value;
                        break;
                    }
                case "Profil_EXT":
                    {
                        Settings.Profil_EXT = value;

                        break;
                    }
                case "Profil_TS":
                    {
                        Settings.Profil_TS = value;
                        break;
                    }
                case "Profil_VFS":
                    {
                        Settings.Profil_VFS = value;
                        break;
                    }
                case "Pulpit_Zdalny":
                    {
                        Settings.Pulpit_Zdalny = value;
                        break;
                    }
                case "Remote_Ping":
                    {
                        Settings.Remote_Ping = value;
                        break;
                    }
                case "Remote_Tracert":
                    {
                        Settings.Remote_Tracert = value;
                        break;
                    }
                case "Szukaj_sesji":
                    {
                        Settings.Szukaj_sesji = value;
                        break;
                    }
                case "UserLog":
                    {
                        Settings.UserLog = value;
                        break;
                    }
                case "Zarzadzanie":
                    {
                        Settings.Zarzadzanie = value;
                        break;
                    }
                case "ZdalneCMD":
                    {
                        Settings.ZdalneCMD = value;
                        break;
                    }
            }
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            Settings = new Properties.Settings();
            if (lastUsedButton == null)
                SetValueSettings(lastUsedButton);
            for (int i = 0; i < 21; i++)
            {
                SaveValueSettings(settingsArray[i, 0], settingsArray[i, 1]);
                //this.DataBindings.Add(new Binding("Name", Settings, settingsArray[i,0]));
            }
            Settings.Save();
            infoSettingsSaved = true;
            using (Form owner = new Form() { TopMost = true })
            {
                MessageBox.Show(owner, MessageText, MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        object lastUsedButton { get; set; }

    public static string[,] LoadSettings()
        {
            string[,] shortcut = new string[21,2];

            Properties.Settings Settings = new Properties.Settings();
            if (!string.IsNullOrEmpty(Settings.DW))
            {
                shortcut[0, 0] = "DW";
                shortcut[0, 1] = Settings.DW;
            }
            if (!string.IsNullOrEmpty(Settings.ExplorerC))
            {
                shortcut[1, 0] = "ExplorerC";
                shortcut[1, 1] = Settings.ExplorerC;
            }
            if (!string.IsNullOrEmpty(Settings.Info_z_AD))
            {
                shortcut[2, 0] = "Info_z_AD";
                shortcut[2, 1] = Settings.Info_z_AD;
            }
            if (!string.IsNullOrEmpty(Settings.Karty_sieciowe))
            {
                shortcut[3, 0] = "Karty_sieciowe";
                shortcut[3, 1] = Settings.Karty_sieciowe;
            }
            if (!string.IsNullOrEmpty(Settings.KomputerInfo))
            {
                shortcut[4, 0] = "KomputerInfo";
                shortcut[4, 1] = Settings.KomputerInfo;
            }
            if (!string.IsNullOrEmpty(Settings.KomputerLog))
            {
                shortcut[5, 0] = "KomputerLog";
                shortcut[5, 1] = Settings.KomputerLog;
            }
            if (!string.IsNullOrEmpty(Settings.Lista_program))
            {
                shortcut[6, 0] = "Lista_program";
                shortcut[6, 1] = Settings.Lista_program;
            }
            if (!string.IsNullOrEmpty(Settings.Logoff))
            {
                shortcut[7, 0] = "Logoff";
                shortcut[7, 1] = Settings.Logoff;
            }
            if (!string.IsNullOrEmpty(Settings.Ping))
            {
                shortcut[8, 0] = "Ping";
                shortcut[8, 1] = Settings.Ping;
            }
            if (!string.IsNullOrEmpty(Settings.Polacz))
            {
                shortcut[9, 0] = "Polacz";
                shortcut[9, 1] = Settings.Polacz;
            }
            if (!string.IsNullOrEmpty(Settings.Profil_ERI))
            {
                shortcut[10, 0] = "Profil_ERI";
                shortcut[10, 1] = Settings.Profil_ERI;
            }
            if (!string.IsNullOrEmpty(Settings.Profil_EXT))
            {
                shortcut[11, 0] = "Profil_EXT";
                shortcut[11, 1] = Settings.Profil_EXT;
            }
            if (!string.IsNullOrEmpty(Settings.Profil_TS))
            {
                shortcut[12, 0] = "Profil_TS";
                shortcut[12, 1] = Settings.Profil_TS;
            }
            if (!string.IsNullOrEmpty(Settings.Profil_VFS))
            {
                shortcut[13, 0] = "Profil_VFS";
                shortcut[13, 1] = Settings.Profil_VFS;
            }
            if (!string.IsNullOrEmpty(Settings.Pulpit_Zdalny))
            {
                shortcut[14, 0] = "Pulpit_Zdalny";
                shortcut[14, 1] = Settings.Pulpit_Zdalny;
            }
            if (!string.IsNullOrEmpty(Settings.Ping))
            {
                shortcut[15, 0] = "Ping";
                shortcut[15, 1] = Settings.Remote_Ping;
            }
            if (!string.IsNullOrEmpty(Settings.Remote_Tracert))
            {
                shortcut[16, 0] = "Remote_Tracert";
                shortcut[16, 1] = Settings.Remote_Tracert;
            }
            if (!string.IsNullOrEmpty(Settings.Szukaj_sesji))
            {
                shortcut[17, 0] = "Szukaj_sesji";
                shortcut[17, 1] = Settings.Szukaj_sesji;
            }
            if (!string.IsNullOrEmpty(Settings.UserLog))
            {
                shortcut[18, 0] = "UserLog";
                shortcut[18, 1] = Settings.UserLog;
            }
            if (!string.IsNullOrEmpty(Settings.Zarzadzanie))
            {
                shortcut[19, 0] = "Zarzadzanie";
                shortcut[19, 1] = Settings.Zarzadzanie;
            }
            if (!string.IsNullOrEmpty(Settings.ZdalneCMD))
            {
                shortcut[20, 0] = "ZdalneCMD";
                shortcut[20, 1] = Settings.ZdalneCMD;
            }
            return shortcut;
        }
        public string LoadValueSettings(string name)
        {
            string shortcut = "BRAK+BRAK"/*+BRAK"*/;
            switch (name)
            {
                case "DW":
                    {
                        if (string.IsNullOrEmpty(Settings.DW) )
                        {
                            shortcut = Settings.DW;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "ExplorerC":
                    {
                        if (string.IsNullOrEmpty(Settings.ExplorerC))
                        {
                            shortcut = Settings.ExplorerC;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Info_z_AD":
                    {
                        if (string.IsNullOrEmpty(Settings.Info_z_AD))
                        {
                            shortcut = Settings.Info_z_AD;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Karty_sieciowe":
                    {
                        if (string.IsNullOrEmpty(Settings.Karty_sieciowe))
                        {
                            shortcut = Settings.Karty_sieciowe;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "KomputerInfo":
                    {
                        if (string.IsNullOrEmpty(Settings.KomputerInfo))
                        {
                            shortcut = Settings.KomputerInfo;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "KomputerLog":
                    {
                        if (string.IsNullOrEmpty(Settings.KomputerLog))
                        {
                            shortcut = Settings.KomputerLog;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Lista_program":
                    {
                        if (string.IsNullOrEmpty(Settings.Lista_program))
                        {
                            shortcut = Settings.Lista_program;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Logoff":
                    {
                        if (string.IsNullOrEmpty(Settings.Logoff))
                        {
                            shortcut = Settings.Logoff;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Ping":
                    {
                        if (string.IsNullOrEmpty(Settings.Ping))
                        {
                            shortcut = Settings.Ping;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Polacz":
                    {
                        if (string.IsNullOrEmpty(Settings.Polacz))
                        {
                            shortcut = Settings.Polacz;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Profil_ERI":
                    {
                        if (string.IsNullOrEmpty(Settings.Profil_ERI))
                        {
                            shortcut = Settings.Profil_ERI;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Profil_EXT":
                    {
                        if (string.IsNullOrEmpty(Settings.Profil_EXT))
                        {
                            shortcut = Settings.Profil_EXT;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Profil_TS":
                    {
                        if (string.IsNullOrEmpty(Settings.Profil_TS))
                        {
                            shortcut = Settings.Profil_TS;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Profil_VFS":
                    {
                        if (string.IsNullOrEmpty(Settings.Profil_VFS))
                        {
                            shortcut = Settings.Profil_VFS;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Pulpit_Zdalny":
                    {
                        if (string.IsNullOrEmpty(Settings.Pulpit_Zdalny))
                        {
                            shortcut = Settings.Pulpit_Zdalny;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Remote_Ping":
                    {
                        if (string.IsNullOrEmpty(Settings.Ping))
                        {
                            shortcut = Settings.Remote_Ping;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Remote_Tracert":
                    {
                        if (string.IsNullOrEmpty(Settings.Remote_Tracert))
                        {
                            shortcut = Settings.Remote_Tracert;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Szukaj_sesji":
                    {
                        if (string.IsNullOrEmpty(Settings.Szukaj_sesji))
                        {
                            shortcut = Settings.Szukaj_sesji;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "UserLog":
                    {
                        if (string.IsNullOrEmpty(Settings.UserLog))
                        {
                            shortcut = Settings.UserLog;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "Zarzadzanie":
                    {
                        if (string.IsNullOrEmpty(Settings.Zarzadzanie))
                        {
                            shortcut = Settings.Zarzadzanie;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
                case "ZdalneCMD":
                    {
                        if (string.IsNullOrEmpty(Settings.ZdalneCMD))
                        {
                            shortcut = Settings.ZdalneCMD;
                        }
                        else
                        {
                            for (int i = 0; i < 21; i++)
                            {
                                if (settingsArray[i, 0] == ((Button)lastUsedButton).Name)
                                {
                                    shortcut = settingsArray[i, 1];
                                }
                            }
                        }
                        break;
                    }
            }
            return shortcut;
        }


        public Button[] buttons()
        {
            Button[] button = { DW, ExplorerC, Info_z_AD,
                Karty_sieciowe, KomputerInfo, KomputerLog, Lista_program,
                Logoff, Ping, Polacz, Profil_ERI, Profil_EXT, Profil_TS,
                Profil_VFS, Pulpit_Zdalny, Remote_Ping, Remote_Tracert,
                Szukaj_sesji, UserLog, Zarzadzanie, ZdalneCMD };
            return button;
        }

        
        private void Object_Click(object sender, EventArgs e)
        {
            if (lastUsedButton != null)
                SetValueSettings(lastUsedButton);
            Control[] Combo = { comboBox1, comboBox2, comboBox3 };
            var button = buttons();
            string shortcut = "BRAK+BRAK"/*+BRAK"*/;
            lastUsedButton = sender;    
            Settings = new Properties.Settings();
            if (sender is ComboBox)
            {
                foreach (ComboBox combo_ in Combo)
                { }
            }
            if (sender is Button)
            {
                using (Button btn = (Button)sender)
                {
                    shortcut = LoadValueSettings(btn.Name);

                    foreach (Button _button in button)
                    {
                        _button.FlatStyle = FlatStyle.Standard;
                        _button.FlatAppearance.BorderColor = Color.Gray;
                    }
                    btn.FlatAppearance.BorderColor = Color.Red;
                    btn.FlatStyle = FlatStyle.Flat;
                }
                //activeButton = btn;
                string[] combo = shortcut.Split('+');
                if (combo.Length == 2/*3*/)
                {
                    comboBox4.Text = combo[0];
                    comboBox5.Text = combo[1];
                    //comboBox6.Text = combo[2];
                }
                else
                {
                    comboBox4.Text = V;
                    comboBox5.Text = V;
                    //comboBox6.Text = V;
                }
            }
        }
        private class formSettings : ApplicationSettingsBase
        {
            [UserScopedSetting()]
            [DefaultSettingValue(null)]
            public string btnshortcut
            {
                get
                {
                    return (string)this[nameof(btnshortcut)];
                }
                set { this[nameof(btnshortcut)] = (string)value; }
            }
        }

        private void RestoreSettings_Click(object sender, EventArgs e)
        {
            string LocalAppdataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string localappdata = System.IO.Path.Combine(LocalAppdataFolderPath, "Jakub@Sypek");
            string AppdataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appdata = System.IO.Path.Combine(AppdataFolderPath, "Jakub@Sypek");
            if (System.IO.Directory.Exists(localappdata) || System.IO.Directory.Exists(appdata))
            {
                if (System.IO.Directory.Exists(localappdata))
                    System.IO.Directory.Delete(localappdata, true);
                if (System.IO.Directory.Exists(appdata))
                    System.IO.Directory.Delete(appdata, true);
                MessageBox.Show("Ustawienia zostały przywrócone","Przywracanie ustawień domyślnych",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void PrzywróćUstawieniaDomyślneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 21; i++)
            {
                if (settingsArray[i, 0] == ((Button)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Name)
                {
                    SaveValueSettings(settingsArray[i, 0], "BRAK+BRAK");
                    Settings.Save();
                    settingsArray[i, 0] = null; 
                    settingsArray[i, 1] = null;
                    MessageBox.Show("Ustawienia dla tego elementu zostały przywrócone");
                }
            }
        }

        private void Ustawienia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (infoSettingsSaved == false)
            {
                using (Form owner = new Form() { TopMost = true })
                {
                    if (MessageBox.Show(owner, "Czy chcesz zapisać ustawienia?", "Zapisywanie ustawień", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SaveSettings_Click(sender, e);
                    }
                    else MessageBox.Show(owner, "Ustawienia nie zostały zapisane", "Zapisywanie ustawień", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Ustawienia_Load(object sender, EventArgs e)
        {
            ShortcutKeys();
        }
        private void ShortcutKeys()
        {
            //object[] keys = new object[] { Keys.Control, Keys.Alt, Keys.Shift };
            object[] letterKeys = new object[] { Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.X, Keys.Y, Keys.Z, Keys.Enter, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12 };
            //comboBox4.Items.AddRange(keys);
            comboBox5.Items.AddRange(/*keys*/letterKeys);
            //comboBox6.Items.AddRange(letterKeys);
            
        }
        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            ShortcutKeys();
            var button = buttons();
            var keys = LoadSettings();
            string[] shortcuts = { "CTRL+C", "CTRL+X", "CTRL+V" };
            //string buttonWithBorderColorRed = null;

            foreach (string shortcut in shortcuts)
            { var shorts = shortcut.Split('+');
                if (comboBox4.Text == shorts[0])
                    comboBox5.Items.Remove(shorts[1]);
            }

            var buttonWithBorderColorRed = from _button in button
                                           where _button.FlatAppearance.BorderColor == Color.Red
                                           select _button.Name;
            //foreach (Button _button in button)
            //{
            //    if (_button.FlatAppearance.BorderColor == Color.Red)
            //        buttonWithBorderColorRed = _button.Name;
            //}
            for (int i = 0; i < 21; i++) 
            {
                if (keys[i, 1] != null)
                {
                    if (keys[i, 0] != buttonWithBorderColorRed.First())
                    {
                        var _key = keys[i, 1].Split('+');
                        if (comboBox4.Text == _key[0])
                        {
                            comboBox5.Items.Remove(_key[1]);
                        }
                    }
                }
            }
        }
    }
}
