using System;
using System.Windows.Forms;
using System.Threading;

namespace Forms.External
{
    public partial class LockoutStatus :  Form
    {
        public LockoutStatus(string username)
        {
            InitializeComponent();
            Username = username;
        }        
        public static string Username;
        public static string domainAddress = null;

        private void LockoutStatus_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (Username.Length > 1)
            {
                this.Text = Username;
                //AddEntry();
            }
        }
        private void menuItemSelectUser_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            LockoutStatusCustom custom = new LockoutStatusCustom();
            custom.ShowDialog();
            DeleteEntryRows();
            AddEntry();
        }
        public void AddEntry()
        {
            foreach(string dcName in PuzzelLibrary.AD.Other.Domain.GetDomainControllers())
            {
                Thread thread = new Thread(() => GetUserPasswordDetails(dcName));
                thread.Start();
            }
        }
        private void DeleteEntryRows()
        {
            if (dataGridView.Rows.Count > 1)
                dataGridView.Rows.Clear();
        }

        private void menuItemRefreshSelected_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
                if (dataGridView.CurrentCell.RowIndex != 0)
                {
                    int RowIndex = dataGridView.CurrentCell.RowIndex;
                    string dcName = dataGridView.Rows[RowIndex].Cells[0].Value.ToString();
                    GetUserPasswordDetails(dcName);
                }
        }
        private void LockoutStatus_Activated(object sender, EventArgs e)
        {
            if (Username.Length > 1)
                this.Text = Username;
        }
        public static void GetUserPasswordDetails(string dcName)
        {
            if (dataGridView.Columns != null)
                try
                {
                    var pd = new PuzzelLibrary.AD.User.Information.PasswordDetails();
                    pd.GetUserPasswordDetails(Username, dcName);
                    if (dataGridView.InvokeRequired)
                    {
                        dataGridView.Invoke(new MethodInvoker(() => dataGridView.Rows.Add(dcName, pd.userAccountLocked, pd.badLogonCount, pd.lastBadPasswordAttempt, pd.lastPasswordSet, pd.userLockoutTime)));
                    }
                    else dataGridView.Rows.Add(dcName, pd.userAccountLocked, pd.badLogonCount, pd.lastBadPasswordAttempt, pd.lastPasswordSet, pd.userLockoutTime);
                }
                catch (Exception e)
                {
                    PuzzelLibrary.Debug.LogsCollector.GetLogs(e, dcName + "," + Username);
                }
        }
        private void menuItemClearAll_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }
        private void menuItemRefreshAll_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            AddEntry();
        }
        private void menuItemPasswordStatus_Click(object sender, EventArgs e)
        {
            var pd = new PuzzelLibrary.AD.User.Information.PasswordDetails();
            string messagebox = null;
            DateTime pwdLastSet = Convert.ToDateTime(pd.lastPasswordSet);
            TimeSpan pwdAge = DateTime.Now - pwdLastSet.AddHours(1);
            //msDS-UserPasswordExpiryTimeComputed
            TimeSpan expirePwd = pwdLastSet.AddDays(30) - DateTime.Now;

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
        private void UnlockAll_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count != 0)
            {
                int selectedRowIndex = dataGridView.SelectedRows[0].Index;
                string dcName = dataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString();

                if (new PuzzelLibrary.AD.User.AccountOperations().UnlockAccount(Username))
                       MessageBox.Show("Konto zostało odblokowane");
                else MessageBox.Show("Nie można odblokować konta z powodu błędu");
            }
            else MessageBox.Show("Nic nie zaznaczono");
        }
    }
}
