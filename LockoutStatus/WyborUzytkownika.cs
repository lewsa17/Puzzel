using System;
using System.Windows.Forms;

namespace Puzzel.LockoutStatus
{
    public partial class LockoutStatusWyborUzytkownika : Form
    {
        public LockoutStatusWyborUzytkownika()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string domainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }

        private void button1_Click(object sender, EventArgs e)
        {
            Lockout_Status.userName = textBox1.Text;
            Lockout_Status.domainAddress = textBox2.Text;
            Close();
        }

        private void LockoutStatusWyborUzytkownika_Load(object sender, EventArgs e)
        {
            if (Lockout_Status.userName.Length > 1)
                this.textBox1.Text =Lockout_Status.userName;
            this.textBox2.Text = domainName();
        }

        private void EnterPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Lockout_Status.userName = textBox1.Text;
                Lockout_Status.domainAddress = textBox2.Text;
                Close();
            }
        }
    }
}
