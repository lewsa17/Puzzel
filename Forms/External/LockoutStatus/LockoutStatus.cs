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
        public string domainAddress = null;

        private void LockoutStatus_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (Username.Length > 1)
            {
                this.Text = Username;
            }
        }
        private void MenuItemSelectUser_Click(object sender, EventArgs e)
        {
            LockoutStatusCustom custom = new();
            if (custom.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(custom.Username))
                {
                    domainAddress = custom.domainAddress;
                    Username = custom.Username;
                    this.Text = Username;
                    DeleteEntryRows();
                    AddEntry();
                }
                else this.Text = "Lockout Status";
            }
        }
        public void AddEntry()
        {
            string[] domainControllers = null;
            if (domainAddress != null)
                domainControllers = PuzzelLibrary.AD.Other.Domain.GetCustomDomainControllers(domainAddress);
            else domainControllers = PuzzelLibrary.AD.Other.Domain.GetCurrentDomainControllers();
            foreach (string dcName in domainControllers)
            {
                Thread thread = new(() => GetUserPasswordDetails(dcName));
                thread.Start();
            }
        }
        private void DeleteEntryRows()
        {
            if (dataGridView.Rows.Count > 1)
                dataGridView.Rows.Clear();
        }

        private void MenuItemRefreshSelected_Click(object sender, EventArgs e)
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
        public void GetUserPasswordDetails(string dcName)
        {
            if (this.IsHandleCreated)
                Invoke(new MethodInvoker(() => Cursor = Cursors.WaitCursor));
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
            Invoke(new MethodInvoker(() => Cursor = Cursors.Default));
        }
        private void MenuItemClearAll_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }
        private void MenuItemRefreshAll_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            AddEntry();
        }
        private void MenuItemPasswordStatus_Click(object sender, EventArgs e)
        {
            var pd = new PuzzelLibrary.AD.User.Information.PasswordDetails();
            pd.GetUserPasswordDetails(Username, domainAddress);
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
                if (new PuzzelLibrary.AD.User.AccountOperations().UnlockAccount(Username))
                       MessageBox.Show("Konto zostało odblokowane");
                else MessageBox.Show("Nie można odblokować konta z powodu błędu");
            }
            else MessageBox.Show("Nic nie zaznaczono");
        }
        private void CopyValueClick(object sender, EventArgs e)
        {
            string value = string.Empty;
            if (sender == contextMenuItemCopyValue)
            {
                value = dataGridView.CurrentCell.Value.ToString();
            }
            if (sender == contextMenuItemCopySelectedRow)
            {
                var cells = dataGridView.SelectedRows[0].Cells;
                foreach (DataGridViewCell cell in cells)
                {
                    value += cell.Value.ToString() + "\t";
                }
            }
            Clipboard.SetText(value);
        }
    }
}
