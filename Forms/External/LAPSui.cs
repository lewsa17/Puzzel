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
            var lapsproperties = CompPWD.GetPWD(HostName);
            textPassword.Text = lapsproperties[0].ToString();
            textPasswordExpires.Text = DateTime.FromFileTime(Convert.ToInt64(lapsproperties[1])).ToString();
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
    }
}
