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
            string[] domainControllers = null;
            if (domainAddress != null)
                domainControllers = PuzzelLibrary.AD.Other.Domain.GetCustomDomainControllers(domainAddress);
            else domainControllers = PuzzelLibrary.AD.Other.Domain.GetCurrentDomainControllers();
            foreach (string dcName in domainControllers)
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
            pd.GetUserPasswordDetails(Username, PuzzelLibrary.AD.Other.Domain.GetCurrentDomainControllers()[0]);
            System.Text.StringBuilder messagebox = new();
            DateTime pwdLastSet = pd.lastPasswordSet;
            DateTime expirePwd = pd.passwordExpiryTime;
            
            //pierwszalinijka
            messagebox.Append("Maksymalna długość hasła dla " + Username + " wynosi " + (expirePwd - pwdLastSet).Days.ToString() + " dni");
            //drugalinijka
            messagebox.Append("\n\n");
            //trzecia linijka
            messagebox.Append("Hasło obowiązuje do :" + pwdLastSet.ToShortDateString() + " " + pwdLastSet.ToLongTimeString());
            //czwarta linijka
            messagebox.Append("\n\n");
            //piąta linijka
            messagebox.Append("Hasło wygasa w: " + expirePwd.ToShortDateString() + " " + expirePwd.ToLongTimeString());

            MessageBox.Show(messagebox.ToString(), "Status hasła");
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
