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
            var txt = CompPWD.GetPWD(HostName);
            textPassword.Text = txt[0].ToString();
            long text = Convert.ToInt64(txt[1]);
            textPasswordExpires.Text = DateTime.FromFileTime(text).ToString();
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
            if (string.IsNullOrEmpty(HostName))
            {
                LoadPassword();
            }
        }
    }
}
