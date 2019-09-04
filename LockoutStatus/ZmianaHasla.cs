using System;
using System.Linq;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace Puzzel
{
    public partial class ZmianaHasla : Form
    {
        public ZmianaHasla()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            bool UnlockAccout = checkBox1.Checked;
            bool PasswordExpired = checkBox2.Checked;
            string password = null;
            int counter = 0;
            if (textBox1.Text == textBox2.Text)
            {
                if (textBox1.Text.Length >= 8)
                { 
                    if (textBox1.Text.Any(char.IsUpper))
                    {
                        counter++;
                    }
                    if (textBox1.Text.Any(char.IsLower))
                    {
                        counter++;
                    }
                    if (textBox1.Text.Any(char.IsDigit))
                    {
                        counter++;
                    }
                    if (!textBox1.Text.Any(char.IsLetterOrDigit))
                    {
                        counter++;
                    }

                    if (counter >= 3)
                    {
                        password = textBox1.Text;
                    }
                    else MessageBox.Show("Sprawdź poprawność hasła czy zawiera dużą lub mała literę, cyfrę lub znak specjalny");
                }
                else MessageBox.Show("Podane hasło ma mniej niz 8 znaków");
                Lockout_Status.ustawhaslo(password, UnlockAccout, PasswordExpired);
            }
            else MessageBox.Show("Podane hasła nie są zgodne");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ZmianaHasla_Load(string UserName)
        {
            int i = 0;
            if (UserName != null)
                foreach (string dcName in Lockout_Status.DomainController())
                {
                    System.Threading.Thread th = new System.Threading.Thread(() => 
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
                    th.Priority = System.Threading.ThreadPriority.Highest;
                    th.Join();
                }
            if (i > 0)
                this.label4.Text = "Stan blokady konta w domenie: Zablokowane";
            else this.label4.Text = "Stan blokady konta w domenie: Odblokowane";
        }
    }
}
