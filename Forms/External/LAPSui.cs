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
            textBox1.Text = HostName;
            textBox2.Text = CompPWD.GetPWD(HostName);
        }
        private void btnClose(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }
        private void btnGetPwd(object sender, EventArgs e)
        {
            textBox2.Text = CompPWD.GetPWD(textBox1.Text);
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
