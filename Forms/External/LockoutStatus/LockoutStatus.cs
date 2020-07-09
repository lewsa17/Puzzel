using System;
using System.Windows.Forms;
using System.Threading;
using System.Linq;

namespace Forms.External.LockoutStatus
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

        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (Username.Length > 1)
            {
                this.Text = Username;
                //AddEntry();
            }
        }
        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
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
                    GetUserPasswordDetails(dcName);
                }
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
            if (Username.Length > 1)
                this.Text = Username;
        }

        public static void GetUserPasswordDetails(string dcName)
        {
            if (dataGridView1.Columns != null)
                try
                {
                    var pd = new PuzzelLibrary.AD.User.Information.Information.PasswordDetails();
                            if (dataGridView1.InvokeRequired)
                            {
                                dataGridView1.Invoke(new MethodInvoker(() => dataGridView1.Rows.Add(dcName, pd.userAccountLocked, pd.badLogonCount, pd.lastBadPasswordAttempt, pd.lastPasswordSet, pd.userLockoutTime)));
                            }
                            else dataGridView1.Rows.Add(dcName, pd.userAccountLocked, pd.badLogonCount, pd.lastBadPasswordAttempt, pd.lastPasswordSet, pd.userLockoutTime);

                        
                        //else
                        //    dataGridView1.ClearSelection();
                    
                }
                catch (Exception e)
                {
                    PuzzelLibrary.Debug.LogsCollector.GetLogs(e, dcName + "," + Username);
                }
        }


        private void ClearButtoonEntry(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }

        private void RefreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            AddEntry();
        }

        private void PasswordStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pd = new PuzzelLibrary.AD.User.Information.Information.PasswordDetails();
            string messagebox = null;
            DateTime pwdLastSet = Convert.ToDateTime(pd.lastPasswordSet);
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

        private void UnlockAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string dcName = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();

                if (PuzzelLibrary.AD.User.Operations.UnlockAccount(Username, dcName))
                       MessageBox.Show("Konto zostało odblokowane");
                else MessageBox.Show("Nie można odblokować konta z powodu błędu");

            Thread.Sleep(1000);
            MessageBox.Show("Konto zostało odblokowane");
            }
            else MessageBox.Show("Nic nie zaznaczono");
        }


    }
}
