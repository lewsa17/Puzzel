using System;
using System.Windows.Forms;
using PuzzelLibrary.LAPS;

namespace Forms.External
{
    public partial class LAPSui : Form
    {
        public string HostName { get; set; }
        public LAPSui()
        {
            InitializeComponent();
        }
        public LAPSui(string hostname)
        {
            HostName = hostname;
        }
        public void LoadPassword()
        {
            inputtedcomputerName.Text = HostName;
            var lapsproperties = CompPWD.GetPWD(HostName);
            textPassword.Text = lapsproperties[0].ToString();
            dateTimePasswordExpires.Value = DateTime.FromFileTime(Convert.ToInt64(lapsproperties[1]));
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
            if (HostName != null)
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
