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
            inputedcomputerName.Text = HostName;
            textPassword.Text = CompPWD.GetPWD(HostName);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }
        private void btnGetPwd(object sender, EventArgs e)
        {
            textPassword.Text = CompPWD.GetPWD(inputedcomputerName.Text);
        }

        private void LAPSui_Load(object sender, EventArgs e)
        {
            if (HostName != null)
            {
                LoadPassword();
            }
        }
    }
}
