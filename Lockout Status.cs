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
        public string domainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }

        string DomainController()
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
            return table;
        }
        public static string Username;
        public static string domainAddress = null;

        public void GetDomainControllers(ref string[] array)
        {
            array = DomainController().Split(',');
            Array.Resize(ref array, domainControllerName.Length - 1);
            domainControllerName = array;
        }
        
        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (Username.Length > 1)
            {
                this.Text = Username;
                AddEntry(sender);
            }
        }

        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            LockoutStatusWyborUzytkownika lswu = new LockoutStatusWyborUzytkownika();
            lswu.ShowDialog();
            DeleteEntryRows();
            AddEntry(sender);
        }

        private void UpdateEntry(object sender)
        {
            if (domainControllerName == null)
                GetDomainControllers(ref domainControllerName);
            else 
            for (int i = 0; i < domainControllerName.Count()-1; i++)
                GetUserPasswordDetails(domainControllerName[i]);
        }

        private void AddEntry(object sender)
        {
            GetDomainControllers(ref domainControllerName);
            foreach(string dcName in domainControllerName)
            {
                Thread thread = new Thread(() => GetUserPasswordDetails(dcName));
                thread.Start();
            }
            rett = 0;
        }

        private void DeleteEntryRows()
        {
            if (this.dataGridView1.Rows.Count > 1)
                this.dataGridView1.Rows.Clear();
        }

        private void OdświeżZaznaczoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != 0)
            {
                int RowIndex = this.dataGridView1.CurrentCell.RowIndex;
                string dcName = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
                GetUserPasswordDetails(dcName);
            }
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
            if (Username.Length > 1)
                this.Text = Username;
        }
        static string[] domainControllerName = {};
        string useraccaountLocked = null;
        string _badLogonCount = null;
        string _lastBadPasswordAttempt = null;
        string _lastPasswordSet = null;
        string _accountLockoutTime = null;
        int rett = 0;
        public void GetUserPasswordDetails(string dcName)
        {
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
            {
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                if (uP != null)
                {
                    
                    if (uP.IsAccountLockedOut())
                        useraccaountLocked = "Zablokowane";
                    else useraccaountLocked = "Odblokowane";

                    if (uP.BadLogonCount > 0)
                        _badLogonCount = uP.BadLogonCount.ToString();
                    else _badLogonCount = "0";

                    if (uP.LastBadPasswordAttempt != null)
                        _lastBadPasswordAttempt = DateTime.FromFileTime(uP.LastBadPasswordAttempt.Value.ToFileTime()).ToString();

                    if (uP.LastPasswordSet != null)
                        _lastPasswordSet = DateTime.FromFileTime(uP.LastPasswordSet.Value.ToFileTime()).ToString();

                    if (uP.AccountLockoutTime != null)
                        _accountLockoutTime = DateTime.FromFileTime(uP.AccountLockoutTime.Value.ToFileTime()).ToString();
                    else _accountLockoutTime = "0";

                    if (dataGridView1.InvokeRequired)
                    {
                        dataGridView1.Invoke(new MethodInvoker(() => this.dataGridView1.Rows.Add(dcName, useraccaountLocked, _badLogonCount, _lastBadPasswordAttempt, _lastPasswordSet, _accountLockoutTime)));
                    }
                    else dataGridView1.Rows.Add(dcName, useraccaountLocked, _badLogonCount, _lastBadPasswordAttempt, _lastPasswordSet, _accountLockoutTime);

                } else
                rett++;
                dataGridView1.ClearSelection();
            }
            if (rett == 3) MessageBox.Show(new Form() { TopMost = true }, "Podany login nie występuje w AD", "Wyszukiwanie danych", MessageBoxButtons.OK);
        }


        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }

        private void odświerzWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            AddEntry(sender);
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
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string dcName = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                {
                    UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                    uP.UnlockAccount();
                }
                MessageBox.Show("Konto zostało odblokowane");
            }
            else MessageBox.Show("Nic nie zaznaczono");
        }
    }
}
