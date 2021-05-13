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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            LockoutStatus.Username = textUserName.Text;
            LockoutStatus.domainAddress = textDomainName.Text;
            PuzzelLibrary.AD.User.Information.CustomCredentials.Domain = DomainText.Text;
            PuzzelLibrary.AD.User.Information.CustomCredentials.Password = PasswordText.Text;
            PuzzelLibrary.AD.User.Information.CustomCredentials.UserName = UserNameText.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void LockoutStatusCustoma_Load(object sender, EventArgs e)
        {
            if (LockoutStatus.Username.Length > 1)
                this.textUserName.Text = LockoutStatus.Username;
            this.textDomainName.Text = PuzzelLibrary.AD.Other.Domain.GetDomainName;
        }
        private void EnterKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LockoutStatus.Username = textUserName.Text;
                LockoutStatus.domainAddress = textDomainName.Text;
                Close();
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
