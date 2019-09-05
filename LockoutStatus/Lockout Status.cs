using System;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;
using System.Linq;

namespace Puzzel.LockoutStatus
{
    public partial class Lockout_Status :  Form
    {
        public static string userName { get; set; }
        public static string _lastPasswordSet { get; set; }

        public Lockout_Status(string _userName)
        {
            InitializeComponent();
            userName = _userName;
        }
        public static string DomainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }
        public static string[] DomainControllers()
        {
            DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + DomainName()));
            SearchResult search1 = search.FindOne();
            string table = null;
            foreach (string line in (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value)
            {
                string[] words = line.Split(',');
                table += words[1].Replace("CN=", "") + ",";
            }
            return table.Substring(0, table.Length - 1).Split(',');
        }
        public static string domainAddress = null;        
        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (userName.Length > 1)
            {
                this.Text = userName;
            }
        }
        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            LockoutStatusWyborUzytkownika lswu = new LockoutStatusWyborUzytkownika();
            lswu.ShowDialog();
            DeleteEntryRows();
            AddEntry(userName);
        }
        public static void AddEntry(string Username)
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

        public static string CheckUserInDomain(string userName)
        {
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + DomainName());
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(sAMAccountName=" + userName + ")";
            search.PropertiesToLoad.Add("sAMAccountName");
            string text = null;
            if (search.FindOne() != null)
                text = search.FindOne().GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();
            else
                MessageBox.Show(new Form() { TopMost = true }, "Podany login nie występuje w AD", "", MessageBoxButtons.OK);            
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
                    GetUserPasswordDetails(dcName, userName);
                }
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
            if (userName.Length > 1)
                this.Text = userName;
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
                if (dataGridView1.Columns.Count > 0)
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
                LogsCollector.Loger(e, dcName + "," + Username);
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
            AddEntry(userName);
        }

        private void StatusHasłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string messagebox = null;
            DateTime pwdLastSet = Convert.ToDateTime(_lastPasswordSet);
            TimeSpan pwdAge = DateTime.Now - pwdLastSet.AddHours(1);
            TimeSpan expirePwd = pwdLastSet.AddDays(30) - DateTime.Now;

            //pierwsza linijka
            messagebox += "Maksymalna długość hasła dla " + userName + " wynosi 30 dni.";
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
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                uP.UnlockAccount();
                uP.Save();
            }
            Thread.Sleep(3000);
            MessageBox.Show("Konto zostało odblokowane");
        }

        
    }
}
