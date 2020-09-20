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
        const string defaultDescription = "Najedź kursorem na opcję aby wyświetlić tutaj opis";
        const string logsHistoryDescription = "Ustawienie tej opcji będzie wyświetlać lub nie ostatnio wyszukiwanych wartości";
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
        }
        private void MouseOn(object sender, EventArgs e)
        {
            var Name = ((CheckBox)sender).Name;
            switch (Name)
            {
                case "CheckBoxHistoryLog": 
                    {
                        DescriptionLabel.Text = logsHistoryDescription; 
                        break; 
                    }
            };
                
        
        }
        private void MouseOut(object sender, EventArgs e)
        {
            DescriptionLabel.Text = defaultDescription;
        }
    }
}
