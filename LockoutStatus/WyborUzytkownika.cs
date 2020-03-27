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

        public static string domainName() => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; 

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            LockoutStatus._userName = textBox1.Text;
            LockoutStatus.domainAddress = textBox2.Text;
=======
            Puzzel.Lockout_Status.Username = textBox1.Text;
            Puzzel.Lockout_Status.domainAddress = textBox2.Text;
>>>>>>> parent of fc44d59... ## version 0.112.190703
            Close();
        }

        private void LockoutStatusWyborUzytkownika_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (LockoutStatus._userName.Length > 1)
                this.textBox1.Text =LockoutStatus._userName;
=======
            if (Puzzel.Lockout_Status.Username.Length > 1)
                this.textBox1.Text = Puzzel.Lockout_Status.Username;
>>>>>>> parent of fc44d59... ## version 0.112.190703
            this.textBox2.Text = domainName();
        }

        private void EnterPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
<<<<<<< HEAD
                LockoutStatus._userName = textBox1.Text;
                LockoutStatus.domainAddress = textBox2.Text;
=======
                Puzzel.Lockout_Status.Username = textBox1.Text;
                Puzzel.Lockout_Status.domainAddress = textBox2.Text;
>>>>>>> parent of fc44d59... ## version 0.112.190703
                Close();
            }
        }
    }
}
