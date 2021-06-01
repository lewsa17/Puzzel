using System;
using System.Windows.Forms;
using PuzzelLibrary.LAPS;

namespace Forms.External
{
    public partial class LAPSui : Form
    {             
        public LAPSui(string hostname)
        {
            InitializeComponent();
            inputtedcomputerName.Text = hostname;
        }
        public void LoadPassword()
        {
            setButton.Enabled = true;
            var lapsproperties = CompPWD.GetPWD(inputtedcomputerName.Text);
            textPassword.Text = lapsproperties[0] != null ? lapsproperties[0].ToString() : string.Empty;
            if (lapsproperties[1] != null)
                dateTimePasswordExpires.Value = DateTime.FromFileTime(Convert.ToInt64(lapsproperties[1]));
            else setButton.Enabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }
        private void btnGetPwd(object sender, EventArgs e)
        {
            LoadPassword();
        }
        private void LAPSui_Load(object sender, EventArgs e)
        {
            if (inputtedcomputerName.Text != null)
            {
                LoadPassword();
            }
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            CompPWD.setPWD(inputtedcomputerName.Text, dateTimePasswordExpires.Value.ToFileTime().ToString());
            MessageBox.Show("Zmiana została wprowadzona.\n" +
                            "Przy nabliżej aktualizacji polis komputer pobierze nowe", 
                            "Zmiana hasła", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question);
        }
    }
}
