using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Threading;
using System.IO;
namespace Puzzel
{
    public partial class Lockout_Status : Form
    {
        public Lockout_Status(string username)
        {
            InitializeComponent();
            Username = username;
        }

        public static string Username;
        public static string domainAddress = null;
        public void GetDomainControllers()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "dsquery.exe";
                p.StartInfo.Arguments = "server -o rdn";
                p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += new DataReceivedEventHandler(domainControllers);
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Nie można odnaleźć określonego pliku\n" + @"C:\Windows\System32\dsquery.exe");

            }
        }
        string domainController;

        void domainControllers(object sender, DataReceivedEventArgs e)
        {
            domainController = null;
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                domainController += (e.Data + ",");
            }));
        }

        private void Lockout_Status_Load(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            if (Username.Length > 1)
            {
                this.Text = Username;
                progress.RunWorkerAsync();
            }
        }

        private void WybierzUżytkownikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Lockout Status";
            LockoutStatusWyborUzytkownika lswu = new LockoutStatusWyborUzytkownika();
            lswu.ShowDialog();
            progress.RunWorkerAsync();
        }

        private void UpdateEntry()
        {
            var domaincontrooler = File.ReadAllLines("DefaultValue.txt");
            var domainControlerName = domaincontrooler[12].Split(',');
            for (int i = 0; i < domainControlerName.Count(); i++)
                GetUserPasswordDetails(domainControlerName[i]);
        }

        private void AddEntry()
        {
            var domaincontrooler = File.ReadAllLines("DefaultValue.txt");
            var domainControlerName = domaincontrooler[12].Split(',');
            for (int i = 0; i < domainControlerName.Count(); i++)
                GetUserPasswordDetails(domainControlerName[i]);
        }

        private void DeleteEntryRows()
        {
            if (this.dataGridView1.Rows.Count > 1)
                this.dataGridView1.Rows.Clear();
        }

        private void OdświeżZaznaczoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RowIndex = this.dataGridView1.CurrentCell.RowIndex;
            string dcName = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
            GetUserPasswordDetails(dcName);
        }

        private void Lockout_Status_Activated(object sender, EventArgs e)
        {
            if (Username.Length > 1)
                this.Text = Username;
        }
        string useraccaountLocked = null;
        string _badLogonCount = null;
        string _lastBadPasswordAttempt = null;
        string _lastPasswordSet = null;
        string _accountLockoutTime = null;
        public void GetUserPasswordDetails(string dcName)
        {

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
            {
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);

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
                    dataGridView1.Invoke(new MethodInvoker(() => this.dataGridView1.Rows.Add(dcName, useraccaountLocked, _badLogonCount, _lastBadPasswordAttempt, _lastPasswordSet, _accountLockoutTime)));
            } dataGridView1.ClearSelection();
        }

        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
        }

        private void odświerzWszystkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEntryRows();
            progress.RunWorkerAsync();
        }

        private void progress_DoWork(object sender, DoWorkEventArgs e)
        {
            AddEntry();
        }

        private void statusHasłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tempt = null;
            TimeSpan temp = (Convert.ToDateTime(_lastPasswordSet).AddDays(30) - DateTime.Now);
            if (temp > (DateTime.Now.AddDays(2) - DateTime.Now))
            {
                tempt += (temp.ToString("'Obecne hasło wynosi :'dd' dni 'hh'g'mm'm'ss's'") + "\n");
            }
            else if (temp < (DateTime.Now.AddDays(1) - DateTime.Now))
                tempt += (temp.ToString("'Obecne hasło wynosi :'dd' dzień 'hh'g'mm'm'ss's'") + "\n");
            MessageBox.Show("Maksymalna długość hasła dla " + Username + " wynosi 30 dni. \n\n " + (DateTime.Now - Convert.ToDateTime(_lastPasswordSet)).ToString("'Hasło wygasa za: 'dd' dni 'hh'g'mm'm'ss's'") + "\n\n " + tempt, "Status hasła");
        }

        private void odblokujZaznaczoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            string dcName = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, dcName))
            {
                UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, Username);
                uP.UnlockAccount();
            }
            MessageBox.Show("Konto odblokowane na kontrolerze: "+dcName);
        }
        
    }
}
