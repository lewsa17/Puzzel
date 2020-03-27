using System;
using System.Windows.Forms;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Threading;

namespace Puzzel
{
<<<<<<< HEAD
    public partial class LockoutStatus :  Form
    {
        public static string _userName { get; set; }
        private static string _lastPasswordSet { get; set; }

        public LockoutStatus(string userName)
        {
            InitializeComponent();
            _userName = userName;
=======
    public partial class Lockout_Status : Form
    {
        public Lockout_Status(string username)
        {
            InitializeComponent();
            Username = username;
>>>>>>> parent of fc44d59... ## version 0.112.190703
        }
        public static string DomainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }
        public static string[] DomainController()
        {
<<<<<<< HEAD
            using (DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + DomainName())))
=======
            //DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://OU=Domain Controllers," + domainName());
            DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + DomainName()));
            //search.Filter = "(sAMAccountName=" + username + ")";
            SearchResult search1 = search.FindOne();
            //SearchResultCollection collection = search.FindAll();
            object[] lines = (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value;
            string table = null;
            foreach (string line in lines)
>>>>>>> parent of fc44d59... ## version 0.112.190703
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
<<<<<<< HEAD
        }
        public static string domainAddress { get; set; }
        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (_userName.Length > 1)
            {
                this.Text = _userName;
=======

#pragma warning disable IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
            string[] array = null;
#pragma warning restore IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
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
>>>>>>> parent of fc44d59... ## version 0.112.190703
            }
        }
        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            using (LockoutStatusWyborUzytkownika lswu = new LockoutStatusWyborUzytkownika())
                lswu.ShowDialog();
            DeleteEntryRows();
<<<<<<< HEAD
            AddEntry(_userName);
        }
        public static void AddEntry(string Username)
        {
            try
=======
            AddEntry(Username);
        }
        public static void AddEntry(string Username)
        {
            string[] dcNames = DomainController();
            int i = 0;
            foreach (string dcName in dcNames)
>>>>>>> parent of fc44d59... ## version 0.112.190703
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

        public static string UserInfo(string usrname)
        {
<<<<<<< HEAD
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
=======
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + DomainName());
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(sAMAccountName=" + usrname + ")";
            search.PropertiesToLoad.Add("sAMAccountName");
            string text = null;
            if (search.FindOne() != null)
                text = search.FindOne().GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();
            else
                MessageBox.Show(new Form() { TopMost = true }, "Podany login nie występuje w AD", "", MessageBoxButtons.OK);            
            return text;
>>>>>>> parent of fc44d59... ## version 0.112.190703
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
<<<<<<< HEAD
                    GetUserPasswordDetails(dcName, _userName);
=======
                    GetUserPasswordDetails(dcName, Username);
>>>>>>> parent of fc44d59... ## version 0.112.190703
                }
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (_userName.Length > 1)
                this.Text = _userName;
=======
            if (Username.Length > 1)
                this.Text = Username;
>>>>>>> parent of fc44d59... ## version 0.112.190703
        }
        static string _lastPasswordSet = null;

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
<<<<<<< HEAD
            AddEntry(_userName);
=======
            AddEntry(Username);
>>>>>>> parent of fc44d59... ## version 0.112.190703
        }

        private void StatusHasłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string messagebox = null;
            DateTime pwdLastSet = Convert.ToDateTime(_lastPasswordSet);
            TimeSpan pwdAge = DateTime.Now - pwdLastSet.AddHours(1);
            TimeSpan expirePwd = pwdLastSet.AddDays(30) - DateTime.Now;

            //pierwsza linijka
<<<<<<< HEAD
            messagebox += "Maksymalna długość hasła dla " + _userName + " wynosi 30 dni.";
=======
            messagebox += "Maksymalna długość hasła dla " + Username + " wynosi 30 dni.";
>>>>>>> parent of fc44d59... ## version 0.112.190703
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

        private void OdblokujZaznaczoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            string dcName = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
            {
<<<<<<< HEAD
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, _userName);
=======
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
>>>>>>> parent of fc44d59... ## version 0.112.190703
                uP.UnlockAccount();
                uP.Save();
            }
            Thread.Sleep(3000);
            MessageBox.Show("Konto zostało odblokowane");
        }

        public static void Ustawhaslo(string password, bool UnlockAccount, bool PasswordExpired)
        {
            if (password != null)
                foreach (string dcName in DomainController())
                {
                    Thread thread = new Thread(() =>
                    {
                        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
                        {
                            UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                            uP.SetPassword(password);
                            if (UnlockAccount)
                                uP.UnlockAccount();
                            if (PasswordExpired)
                                uP.ExpirePasswordNow();
                            uP.Save();
                        }
                    }); thread.Start();
                    thread.Priority = ThreadPriority.Highest;
                    thread.Join();
                }
            MessageBox.Show("Hasło zostało zmienione");
        }
    }
}
