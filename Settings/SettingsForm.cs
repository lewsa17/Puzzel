using System;
using System.Windows.Forms;

namespace Settings
{
    public partial class SettingsForm : Form
    {
        private System.Reflection.PropertyInfo[] SettingsValues = typeof(PuzzelLibrary.Settings.Values).GetProperties();
        private System.Collections.Generic.List<Control> controls = new();
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
        
        private void GetCollectionOfFieldSettings()
        {
            controls.Clear();
            GetAllControls(TabSettings, ref controls);
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
            SaveFromControlsToValues((Control)sender);
        }        

        private void SaveFromControlsToValues(Control ctrl)
        {
            foreach (var propertyInfo in SettingsValues)
                if (ctrl.Name.Contains(propertyInfo.Name))
                {
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "Boolean": { propertyInfo.SetValue(null, Convert.ToBoolean(((CheckBox)ctrl).Checked)); break; }
                        case "Decimal": { propertyInfo.SetValue(null, Convert.ToDecimal(((NumericUpDown)ctrl).Value)); break; }
                        case "String": { propertyInfo.SetValue(null, Convert.ToString(((TextBoxBase)ctrl).Text)); break; }
                    }
                }
        }
        private void LoadValuesToControls(Control ctrl)
        {
            foreach (var value in SettingsValues)
            {
                if (ctrl.Name.Contains(value.Name))
                    switch (ctrl.GetType().Name)
                    {
                        case "TextBox": { ((TextBox)ctrl).Text = Convert.ToString(value.GetValue(null)); break; }
                        case "RichTextBox": { ((RichTextBox)ctrl).Text = Convert.ToString(value.GetValue(null)); break; }
                        case "NumericUpDown": { ((NumericUpDown)ctrl).Value = Convert.ToDecimal(value.GetValue(null)); break; }
                        case "CheckBox": { ((CheckBox)ctrl).Checked = Convert.ToBoolean(value.GetValue(null)); break; }
                    }
            }
        }
        private void OnLoad()
        {
            GetCollectionOfFieldSettings();
            if (System.IO.File.Exists("Settings.xml"))
            {
                PuzzelLibrary.Settings.Values.LoadValues();
                foreach (var ctrl in controls)
                {
                    LoadValuesToControls(ctrl);
                }
            }
            else
            {
                foreach (var objSettings in controls)
                {
                    if (objSettings != SessionDisconectShortcutText)
                        PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
                    SaveFromControlsToValues(objSettings);
                }
            }
        }

        private void RestoreDefaultSettings(object sender, EventArgs e)
        {
            foreach (var objSettings in controls)
                PuzzelLibrary.Settings.Values.RestoreDefaultSettings(objSettings);
        }
    }
}
