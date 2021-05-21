using System;
using System.Windows.Forms;

namespace Forms.External
{
    public partial class LockoutStatusCustom : Form
    {
        public LockoutStatusCustom()
        {
            InitializeComponent();
            if (PuzzelLibrary.AD.Connection.Credentials.Available)
            {
                alternateCredCheck.Checked = true;
                DomainText.Text = PuzzelLibrary.AD.Connection.Credentials.Domain;
                PasswordText.Text = PuzzelLibrary.AD.Connection.Credentials.Password;
                UserNameText.Text = PuzzelLibrary.AD.Connection.Credentials.UserName;
            }

        }
        internal string domainAddress;
        internal string Username;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Username = textUserName.Text;
            domainAddress = PuzzelLibrary.AD.Connection.Credentials.DomainName = textDomainName.Text;
            if (alternateCredCheck.Checked)
            {
                PuzzelLibrary.AD.Connection.Credentials.Domain = DomainText.Text;
                PuzzelLibrary.AD.Connection.Credentials.Password = PasswordText.Text;
                PuzzelLibrary.AD.Connection.Credentials.UserName = UserNameText.Text;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void LockoutStatusCustoma_Load(object sender, EventArgs e)
        {
            if (LockoutStatus.Username.Length > 1)
                this.textUserName.Text = LockoutStatus.Username;
            this.textDomainName.Text = PuzzelLibrary.AD.Other.Domain.GetDomainName;

            if (PuzzelLibrary.AD.Connection.Credentials.Available)
            {
                alternateCredCheck.Checked = true;
                DomainText.Text = PuzzelLibrary.AD.Connection.Credentials.Domain;
                PasswordText.Text = PuzzelLibrary.AD.Connection.Credentials.Password;
                UserNameText.Text = PuzzelLibrary.AD.Connection.Credentials.UserName;
            }
        }
        private void EnterKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void alternateCredCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                UserNameText.ReadOnly = false;
                PasswordText.ReadOnly = false;
                DomainText.ReadOnly = false;
            }
            else
            {
                UserNameText.ReadOnly = true;
                PasswordText.ReadOnly = true;
                DomainText.ReadOnly = true;
            }
        }
    }
}
