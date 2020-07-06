using System;
using System.Linq;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;

namespace Forms.External.LockoutStatus
{
    public partial class ZmianaHasla : Form
    {
        public ZmianaHasla()
        {
            InitializeComponent();
        }
        public static string DomainName() => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; 
        public static string[] DomainControllers()
        {
            //DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://OU=Domain Controllers," + domainName());
            using (DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + DomainName())))
            {
                //search.Filter = "(sAMAccountName=" + username + ")";
                SearchResult search1 = search.FindOne();
                //SearchResultCollection collection = search.FindAll();
                object[] lines = (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value;
                string table = null;
                foreach (string line in lines)
                {
                    string[] words = line.Split(',');
                    table += words[1].Replace("CN=", "") + ",";
                }

                string[] array;
                array = table.Split(',');
                Array.Resize(ref array, array.Length - 1);

                return array;
            }
        }
        public string userName { get; set; }
        
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
                else MessageBox.Show("Podane hasło ma mniej niż 8 znaków");
                UstawHaslo(password, UnlockAccout, PasswordExpired);
            }
            else MessageBox.Show("Podane hasła nie są zgodne");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void UstawHaslo(string password, bool unlockAccount, bool passwordExpired)
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
        public void ZmianaHaslaLoadForm(string UserName)
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
                this.label4.Text = "Stan blokady konta w domenie: Zablokowane";
            else this.label4.Text = "Stan blokady konta w domenie: Odblokowane";
        }
    }
}
