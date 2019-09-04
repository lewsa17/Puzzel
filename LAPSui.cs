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
		public static string HostName = null;
        public LAPSui()
        {
            InitializeComponent();
            
        }
        public static PwdLcl(string computername)
        {
			string admpwd = null;
            try
            {
            	DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName);
            	DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            	search.Filter = "(cn=" + computername + ")";
            	search.PropertiesToLoad.Add(Working[13].Remove(4));
            	if (search.FindOne() == null)
           	    	admPwd = "";
            	else admPwd = search.FindOne().GetDirectoryEntry().Properties[Working[13].Remove(4)].Value.ToString();
			}
            catch (Exception e)
            {
                Form1.Loger(e, computername);
            }
            return admPwd;
        }
        public void loadPassword(string hostname)
        {
                //admPwd = PwdLcl(hostname);
            textBox1.Text = hostname;
            textBox2.Text = PwdLcl(hostname); //admPwd[0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = PwdLcl(textBox1.Text);
		}
			
		private void LAPSui_Load(object sender, EventArgs e)
		{
            
            if (HostName != null)
            {
                loadPassword(HostName);
                textBox2.Refresh();
                textBox2.Update();
            }
            textBox2.ResumeLayout(false);
        }
    }
}
