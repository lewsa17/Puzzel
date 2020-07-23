using System;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class RemoteShellCustomAuth : Form
    {
        public RemoteShellCustomAuth()
        {
            InitializeComponent();
        }

        public string Login { get; set; }
        public string Password { get; set; }

        private void BtnClick(object sender, EventArgs e)
        {
            Login = textLogin.Text;
            Password = textPassword.Text;
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
