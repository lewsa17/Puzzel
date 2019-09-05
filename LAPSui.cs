using System;
using System.DirectoryServices;
using System.Windows.Forms;

namespace Puzzel
{
    public partial class LAPSui : Form
    {
        public static string HostName = null;
        public LAPSui()
        {
            InitializeComponent();
            
        }
        public static string PwdLcl(string computername)
        {
            string admPwd = null;
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
                LogsCollector.Loger(e, computername);
            }
            return admPwd;
        }
        public void loadPassword(string hostname)
        {
            textBox1.Text = hostname;
            textBox2.Text = PwdLcl(hostname);
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
                //textBox2.Refresh();
                //textBox2.Update();
            }
            //textBox2.ResumeLayout(false);
        }
    }
}
