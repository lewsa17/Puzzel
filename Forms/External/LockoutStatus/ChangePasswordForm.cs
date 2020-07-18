using System;
using System.Linq;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Threading;

namespace Forms.External
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }
        public static string[] DomainControllers()
        {
            return PuzzelLibrary.AD.Other.Domain.GetDomainControllers();
        }
        public string userName { get; set; }
        
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool UnlockAccout = checkPaswordMustBeChanged.Checked;
            bool PasswordExpired = checkUnlockAccount.Checked;
            string password = null;
            int counter = 0;

            if (textNewPassword.Text == textConfirmPassword.Text)
            {
                if (textNewPassword.Text.Length >= 8)
                { 
                    if (textNewPassword.Text.Any(char.IsUpper))
                    {
                        counter++;
                    }
                    if (textNewPassword.Text.Any(char.IsLower))
                    {
                        counter++;
                    }
                    if (textNewPassword.Text.Any(char.IsDigit))
                    {
                        counter++;
                    }
                    if (!textNewPassword.Text.Any(char.IsLetterOrDigit))
                    {
                        counter++;
                    }
                    if (counter >= 3)
                    {
                        password = textNewPassword.Text;
                    }
                    else MessageBox.Show("Sprawdź poprawność hasła czy zawiera dużą lub mała literę, cyfrę lub znak specjalny");
                }
                else MessageBox.Show("Podane hasło ma mniej niż 8 znaków");
                ConfirmPassword(password, UnlockAccout, PasswordExpired);
            }
            else MessageBox.Show("Podane hasła nie są zgodne");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ConfirmPassword(string password, bool unlockAccount, bool passwordExpired)
        {
            if (password != null)
                foreach (string dcName in DomainControllers())
                {
                    Thread thread = new Thread(() =>
                    {
                        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                        {
                            UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                            uP.SetPassword(password);
                            if (unlockAccount)
                                uP.UnlockAccount();
                            if (passwordExpired)
                                uP.ExpirePasswordNow();
                            uP.Save();
                        }
                    }); thread.Start();
                    thread.Priority = ThreadPriority.Highest;
                    thread.Join();
                }
            MessageBox.Show("Hasło zostało zmienione");
        }
        public void CheckIfAccountIsLocked(string UserName)
        {
            int i = 0;
            if (UserName != null)
                foreach (string dcName in DomainControllers())
                {
                    Thread th = new Thread(() => 
                    {
                        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                        {
                            UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserName);
                            if (uP != null)
                            {
                                if (uP.AccountLockoutTime != null)
                                    i++;
                            }
                        }
                    });
                    th.Start();
                    th.Priority = ThreadPriority.Highest;
                    th.Join();
                }
            if (i > 0)
                this.labelAccountIsLocked.Text = "Stan blokady konta w domenie: Zablokowane";
            else this.labelAccountIsLocked.Text = "Stan blokady konta w domenie: Odblokowane";
        }
    }
}
