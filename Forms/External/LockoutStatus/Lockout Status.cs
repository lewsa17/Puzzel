using System;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;
using System.Linq;

namespace Forms.External.LockoutStatus
{
    public partial class LockoutStatus :  Form
    {
        public static string _userName { get; set; }
        private static string _lastPasswordSet { get; set; }

        public LockoutStatus(string userName)
        {
            InitializeComponent();
            _userName = userName;
        }
        public static string DomainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }
        public static string[] DomainControllers()
        {
            using (DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + DomainName())))
            {
                SearchResult search1 = search.FindOne();
                string table = null;
                foreach (string line in (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value)
                {
                    string[] words = line.Split(',');
                    table += words[1].Replace("CN=", "") + ",";
                }
                return table.Substring(0, table.Length - 1).Split(',');
            }
        }
        public static string domainAddress { get; set; }
        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (_userName.Length > 1)
            {
                this.Text = _userName;
            }
        }
        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            using (LockoutStatusWyborUzytkownika lswu = new LockoutStatusWyborUzytkownika())
                lswu.ShowDialog();
            DeleteEntryRows();
            AddEntry(_userName);
        }
        public static void AddEntry(string Username)
        {
            try
            {
                string[] dcNames = DomainControllers();
                int i = 0;
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
            catch (Exception)
            {

                throw;
            }
        }

        public static string CheckUserInDomain(string userName)
        {
            using (DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + DomainName()))
            {
                using (DirectorySearcher search = new DirectorySearcher(myLdapConnection))
                {
                    search.Filter = "(sAMAccountName=" + userName + ")";
                    search.PropertiesToLoad.Add("sAMAccountName");
                    string text = null;
                    if (search.FindOne() != null)
                        text = search.FindOne().GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();
                    else
                    {
                        using (Form owner = new Form() { TopMost = true })
                        {
                            MessageBox.Show(owner, "Podany login nie występuje w AD", "", MessageBoxButtons.OK);
                        }
                    }

                    return text;
                }
            }
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
                    GetUserPasswordDetails(dcName, _userName);
                }
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
            if (_userName.Length > 1)
                this.Text = _userName;
        }

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
                if (dataGridView1.ColumnCount > 0)
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
                            else _lastPasswordSet = "Zmień hasło";

                        if (uP.AccountLockoutTime != null)
                        {
                            useraccaountLocked = "Zablokowane";
                            _accountLockoutTime = DateTime.FromFileTime(uP.AccountLockoutTime.Value.ToFileTime()).ToString();
                        }
                        else
                        {
                            useraccaountLocked = "Odblokowane";
                            _accountLockoutTime = "Niedostępne";
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
                //LogsCollector.Loger(e, dcName + "," + Username);
            }
            return uP;
        }
        
        private void WyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }

        private void OdświerzWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            AddEntry(_userName);
        }

        private void StatusHasłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string messagebox = null;
            DateTime pwdLastSet = Convert.ToDateTime(_lastPasswordSet);
            TimeSpan pwdAge = DateTime.Now - pwdLastSet.AddHours(1);
            TimeSpan expirePwd = pwdLastSet.AddDays(30) - DateTime.Now;

            //pierwsza linijka
            messagebox += "Maksymalna długość hasła dla " + _userName + " wynosi 30 dni.";
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

        private void OdblokujKonto(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            string dcName = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
            {
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, _userName);
                uP.UnlockAccount();
                uP.Save();
            }
            Thread.Sleep(3000);
            MessageBox.Show("Konto zostało odblokowane");
        }

        
    }
}
