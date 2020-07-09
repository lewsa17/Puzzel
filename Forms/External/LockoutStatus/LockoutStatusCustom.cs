using System;
using System.Windows.Forms;

namespace Forms.External
{
    public partial class LockoutStatusCustom : Form
    {
        public LockoutStatusCustom()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LockoutStatus.Username = textBox1.Text;
            LockoutStatus.domainAddress = textBox2.Text;
            Close();
        }

        private void LockoutStatusWyborUzytkownika_Load(object sender, EventArgs e)
        {
            if (LockoutStatus.Username.Length > 1)
                this.textBox1.Text = LockoutStatus.Username;
            this.textBox2.Text = PuzzelLibrary.AD.Other.Domain.GetDomainName;
        }

        private void EnterPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LockoutStatus.Username = textBox1.Text;
                LockoutStatus.domainAddress = textBox2.Text;
                Close();
            }
        }
    }
}
