using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace Puzzel
{
    public partial class LockoutStatusWyborUzytkownika : Form
    {
        public LockoutStatusWyborUzytkownika()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        internal void getDomainAddress(string path, string query, string arg1)
        {
            ManagementScope scope = new ManagementScope();
            try
            {
                ConnectionOptions options = new ConnectionOptions()
                {
                    EnablePrivileges = true
                };

                scope = new ManagementScope(@"\\localhost" + path, options);
                scope.Connect();

                SelectQuery Squery = new SelectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, Squery);

                using (ManagementObjectCollection queryCollection = searcher.Get())
                {
                    foreach (ManagementObject m in queryCollection)
                    {
                        if (m[arg1] != null)
                           this.textBox2.Text = m[arg1].ToString();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Puzzel.Lockout_Status.Username = textBox1.Text;
            Puzzel.Lockout_Status.domainAddress = textBox2.Text;
            Close();
        }

        private void LockoutStatusWyborUzytkownika_Load(object sender, EventArgs e)
        {
            getDomainAddress(@"\root\CIMV2", "Win32_ComputerSystem", "domain");
            if (Puzzel.Lockout_Status.Username.Length > 1)
                this.textBox1.Text = Puzzel.Lockout_Status.Username;
        }
    }

}
