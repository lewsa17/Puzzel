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

        public static string domainName() => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; 

        private void button1_Click(object sender, EventArgs e)
        {
            LockoutStatus._userName = textBox1.Text;
            LockoutStatus.domainAddress = textBox2.Text;
            Close();
        }

        private void LockoutStatusWyborUzytkownika_Load(object sender, EventArgs e)
        {
            if (LockoutStatus._userName.Length > 1)
                this.textBox1.Text =LockoutStatus._userName;
            this.textBox2.Text = domainName();
        }

        private void EnterPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LockoutStatus._userName = textBox1.Text;
                LockoutStatus.domainAddress = textBox2.Text;
                Close();
            }
        }
    }
}
