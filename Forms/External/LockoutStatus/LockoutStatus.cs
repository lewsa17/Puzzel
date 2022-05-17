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
        public string domainAddress = PuzzelLibrary.Settings.Values.DomainController;

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
            if (!string.IsNullOrEmpty(domainAddress))
                domainControllers = PuzzelLibrary.AD.Other.Domain.GetCustomDomainControllers(domainAddress);
            else domainControllers = PuzzelLibrary.AD.Other.Domain.GetCurrentDomainControllers();
            int i = 0;
            foreach (string dcName in domainControllers)
            {
                System.Threading.Tasks.Task task = new(() =>
                {
                    GetUserPasswordDetails(dcName, -1);
                });
                task.Start();
                i++;
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
                {
                    int RowIndex = dataGridView.CurrentCell.RowIndex;
                    string dcName = dataGridView.Rows[RowIndex].Cells[0].Value.ToString();
                    GetUserPasswordDetails(dcName, RowIndex);
                }
        }

        private void LockoutStatus_Activated(object sender, EventArgs e)
        {
            if (Username.Length > 1)
                this.Text = Username;
        }
        public void GetUserPasswordDetails(string dcName, int rowIndex)
        {
            while (!IsHandleCreated)
                Thread.Sleep(200);
            try
            {
                BeginInvoke(new MethodInvoker(() => dataGridView.Cursor = Cursors.WaitCursor));
                var pd = new PuzzelLibrary.AD.User.Information.PasswordDetails();
                pd.GetUserPasswordDetails(Username, dcName);
                var site = PuzzelLibrary.AD.Computer.Search.ByComputerName(dcName, "serverReferenceBL")[0].Properties["serverReferenceBL"][0].ToString().Split(',')[2].Replace("CN=", "");
                switch (rowIndex >= 0)
                {
                    case true:
                        {
                            dataGridView.Invoke(new MethodInvoker(() => dataGridView.Rows[rowIndex].SetValues(dcName, site, pd.userAccountLocked, pd.badLogonCount, pd.lastBadPasswordAttempt, pd.lastPasswordSet, pd.userLockoutTime)));
                            break;
                        }
                    case false:
                        {
                            dataGridView.Invoke(new MethodInvoker(() => dataGridView.Rows.Add(dcName, site, pd.userAccountLocked, pd.badLogonCount, pd.lastBadPasswordAttempt, pd.lastPasswordSet, pd.userLockoutTime)));
                            break;
                        }
                }
                BeginInvoke(new MethodInvoker(() => dataGridView.Cursor = Cursors.Default));
            }
            catch (Exception e)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(e, dcName + "," + Username);
            }
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
                    value += cell.Value != null ? cell.Value.ToString() + "\t" : "";
                }
            }
            Clipboard.SetText(value);
        }
    }
}
