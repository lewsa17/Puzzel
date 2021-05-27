using System;
using System.Windows.Forms;

namespace Forms.External
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm(string UserName)
        {
            userName = UserName;
            InitializeComponent();
            CheckIfAccountIsLocked(UserName);
        }
        private string userName { get; set; }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool unlockAccount = checkPaswordMustBeChanged.Checked;
            bool PasswordExpired = checkUnlockAccount.Checked;
            string password = textNewPassword.Text;
            string confirmedPassword = textConfirmPassword.Text;
            var operation = new PuzzelLibrary.AD.User.AccountOperations();
            operation.ChangePassword(userName, password, confirmedPassword, unlockAccount, PasswordExpired);
            if (operation.PasswordIsChanged)
                MessageBox.Show("Hasło zostało zmienione");
            else MessageBox.Show("Hasło nie zostało zmienione");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CheckIfAccountIsLocked(string UserName)
        {                
            if (new PuzzelLibrary.AD.User.AccountOperations().IsAccountLocked(UserName))
                this.labelAccountIsLocked.Text = "Stan blokady konta w domenie: Zablokowane";
            else this.labelAccountIsLocked.Text = "Stan blokady konta w domenie: Odblokowane";
        }
    }
}
