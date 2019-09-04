using System;
using System.Windows.Forms;

namespace Puzzel
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
            Puzzel.Lockout_Status.Username = textBox1.Text;
            Puzzel.Lockout_Status.domainAddress = textBox2.Text;
            Close();
        }

        private void LockoutStatusWyborUzytkownika_Load(object sender, EventArgs e)
        {
            if (Puzzel.Lockout_Status.Username.Length > 1)
                this.textBox1.Text = Puzzel.Lockout_Status.Username;
            this.textBox2.Text = domainName();
        }

        private void EnterPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Puzzel.Lockout_Status.Username = textBox1.Text;
                Puzzel.Lockout_Status.domainAddress = textBox2.Text;
                Close();
            }
        }
    }

}
