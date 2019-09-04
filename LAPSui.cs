using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.DirectoryServices;
using System.Threading;
using System.Windows.Forms;

namespace Puzzel
{
    public partial class LAPSui : Form
    {
        string admPwd = null;
        public LAPSui()
        {
            InitializeComponent();
        }
        string PwdLcl(string computername)
        {
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName);
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(cn=" + computername + ")";
            search.PropertiesToLoad.Add(Working[13].Remove(4));
            string admpwd = null;
            if (search.FindOne().GetDirectoryEntry().Properties[Working[13].Remove(4)].Value == null)
                admPwd = "";
            else admPwd = search.FindOne().GetDirectoryEntry().Properties[Working[13].Remove(4)].Value.ToString();
		return admPwd;
        }
        public void loadPassword(string hostname)
        {
                admPwd = PwdLcl(hostname);
            textBox1.Text = hostname;
            textBox2.Text = admPwd[0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = PwdLcl(textBox1.Text);
        }
    }
}
