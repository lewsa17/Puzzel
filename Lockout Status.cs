using System;
using System.Linq;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;

namespace Puzzel
{
    public partial class Lockout_Status : Form
    {
        public Lockout_Status(string username)
        {
            InitializeComponent();
            Username = username;
        }
        public static string domainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }

        public static string[] DomainController()
        {
            //DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://OU=Domain Controllers," + domainName());
            DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainName()));
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

            string[] array = null;
            array = table.Split(',');
            Array.Resize(ref array, array.Length - 1);

            return array;
        }
        public static string Username;
        public static string domainAddress = null;
        
        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (Username.Length > 1)
            {
                this.Text = Username;
                //AddEntrys();
            }
        }

        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            LockoutStatusWyborUzytkownika lswu = new LockoutStatusWyborUzytkownika();
            lswu.ShowDialog();
            DeleteEntryRows();
            AddEntry(Username);
        }
        public static void AddEntry(string Username)
        {
            string[] dcNames = DomainController();
            int i= 0;
            foreach (string dcName in dcNames)
            {
                Thread thread = new Thread(() =>
                    {
                        if (GetUserPasswordDetails(dcName, Username) == null)
                            i++;
                    });
                thread.Priority = ThreadPriority.Highest;
                thread.Start();
            }
        }

        public static string UserInfo()
        {
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + domainName());
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(sAMAccountName=" + Username + ")";
            search.PropertiesToLoad.Add("sAMAccountName");
            string text = null;
            if (search.FindOne() != null)
                text = search.FindOne().GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();
            else
            MessageBox.Show(new Form() { TopMost = true }, "Podany login nie występuje w AD", "Wyszukiwanie danych", MessageBoxButtons.OK);
            
            return text;
        }
        private void DeleteEntryRows()
        {
            if (dataGridView1.Rows.Count > 1)
                dataGridView1.Rows.Clear();
        }

        private void OdświeżZaznaczoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
                if (dataGridView1.CurrentCell.RowIndex != 0)
                {
                    int RowIndex = dataGridView1.CurrentCell.RowIndex;
                    string dcName = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
                    GetUserPasswordDetails(dcName, Username);
                }
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
            if (Username.Length > 1)
                this.Text = Username;
        }
        static string[] domainControllerName = {};

        //static string useraccaountLocked = null;
        //static string _badLogonCount = null;
        //static string _lastBadPasswordAttempt = null;
        static string _lastPasswordSet = null;
        //static string _accountLockoutTime = null;
        public static UserPrincipal GetUserPasswordDetails(string dcName, string Username)
        {
            string useraccaountLocked = null;
            string _badLogonCount = null;
            string _lastBadPasswordAttempt = null;
            string _accountLockoutTime = null;
            //if (dataGridView1.Columns != null)
            UserPrincipal uP = null;
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                {
                    uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                    if (uP != null)
                    {
                        if (uP.BadLogonCount > 0)
                            _badLogonCount = uP.BadLogonCount.ToString();
                        else _badLogonCount = "0";

                        if (uP.LastBadPasswordAttempt != null)
                            _lastBadPasswordAttempt = DateTime.FromFileTime(uP.LastBadPasswordAttempt.Value.ToFileTime()).ToString();

                        if (uP.LastPasswordSet != null)
                            _lastPasswordSet = DateTime.FromFileTime(uP.LastPasswordSet.Value.ToFileTime()).ToString();

                        if (uP.AccountLockoutTime != null)
                        {
                            useraccaountLocked = "Zablokowane";
                            _accountLockoutTime = DateTime.FromFileTime(uP.AccountLockoutTime.Value.ToFileTime()).ToString();
                        }
                        else
                        {
                            useraccaountLocked = "Odblokowane";
                            _accountLockoutTime = "0";
                        }

                        if (dataGridView1.InvokeRequired)
                        {
                            dataGridView1.Invoke(new MethodInvoker(() => dataGridView1.Rows.Add(dcName, useraccaountLocked, _badLogonCount, _lastBadPasswordAttempt, _lastPasswordSet, _accountLockoutTime)));
                        }
                        else dataGridView1.Rows.Add(dcName, useraccaountLocked, _badLogonCount, _lastBadPasswordAttempt, _lastPasswordSet, _accountLockoutTime);
                    }
                }
            }
            catch (Exception e)
            {
                Form1.Loger(e, dcName + "," + Username);
            }
            return uP;
        }
        
        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }

        private void odświerzWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            AddEntry(Username);
        }

        private void statusHasłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string messagebox = null;
            DateTime pwdLastSet = Convert.ToDateTime(_lastPasswordSet);
            TimeSpan pwdAge = DateTime.Now - pwdLastSet.AddHours(1);
            TimeSpan expirePwd = pwdLastSet.AddDays(30) - DateTime.Now;

            //pierwsza linijka
            messagebox += "Maksymalna długość hasła dla " + Username + " wynosi 30 dni.";
            //drugalinijka
            messagebox +=  "\n\n";
            //trzecia linijka
            if (pwdAge > (DateTime.Now.AddDays(2) - DateTime.Now))
            {
                messagebox += pwdAge.ToString("'Obecne hasło wynosi: 'dd' dni 'hh'g 'mm'm'");
            }
            else if (pwdAge < (DateTime.Now.AddDays(1) - DateTime.Now))
                messagebox += pwdAge.ToString("'Obecne hasło wynosi: 'dd' dni 'hh'g 'mm'm'");
            //czwarta linijka
            messagebox += "\n\n";
            //piąta linijka
            if (expirePwd > (DateTime.Now.AddDays(2) - DateTime.Now))
            {
                messagebox += expirePwd.ToString("'Hasło wygasa za: 'dd' dni 'hh'g 'mm'm'");
            }
            else if (expirePwd > (DateTime.Now.AddDays(1) - DateTime.Now))
            {
                messagebox += expirePwd.ToString("'Hasło wygasa za: 'dd' dni 'hh'g 'mm'm'");
            }

            MessageBox.Show(messagebox, "Status hasła");
        }

        private void odblokujZaznaczoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                //int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                //string dcName = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                foreach(string dcName in DomainController())
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                {
                    UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                    uP.UnlockAccount();
                }
                MessageBox.Show("Konto zostało odblokowane");
            }
            else MessageBox.Show("Nic nie zaznaczono");
        }

        public static string password = null;
        public static void zmianahasla()
        {
            if (password != null)
                foreach (string dcName in DomainController())
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                    {
                        UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                        uP.SetPassword(password);
                        uP.ExpirePasswordNow();
                        uP.Save();
                    }
            MessageBox.Show("Hasło zostało zmienione");
        }
    }
}
