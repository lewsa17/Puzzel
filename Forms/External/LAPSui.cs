using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;

namespace Forms
{
    public partial class LAPSui : Form
    {
        public static string HostName { get; set; }
        public LAPSui()
        {
            InitializeComponent();
            
        }
        public LAPSui(string hostname)
        {
            HostName = hostname;
        }

        // To Do
        // Szukanie ścieżki
        private static bool GraveYardExist(string HostName)
        {
            var search = OpenAccess(HostName);
            search.PropertiesToLoad.Add("distinguishedName");
            if (search.FindOne() != null)
            {
                var x = search.FindOne().GetDirectoryEntry().Properties["distinguishedName"].Value;
                if (x.ToString().Contains("_Graveyard"))
                {
                    return true;
                }
            }
            return false;
        }
        private static string GetLocationPath(string HostName)
        {
            var search = OpenAccess(HostName);
            search.PropertiesToLoad.Add("distinguishedName");
            if (search.FindOne() != null)
            {
                var x = search.FindOne().GetDirectoryEntry().Properties["distinguishedName"].Value;
                return x.ToString();
            }
            return null;
        }
        private static void MoveFromGraveYard(string HostName)
        {
            string path = string.Empty; // należy pobrać pełną nazwę ścieżkę
            DirectoryEntry de = new DirectoryEntry("LDAP://" + GetLocationPath(HostName));
            DirectoryEntry nde = new DirectoryEntry(ExternalResources.ldapcatalog);
            de.MoveTo(nde);
            nde.CommitChanges();
        }
        public static string LAPSpwd(string HostName)
        {
            string admpwd = null;
            if (GraveYardExist(HostName))
                MoveFromGraveYard(HostName);
            try
            {
                DirectorySearcher search = OpenAccess(HostName);
                search.PropertiesToLoad.Add(ExternalResources.ldapProperties);
                //search.PropertiesToLoad.Add("ms-Mcs-AdmPwdExpirationTime");
                if (search.FindOne() == null)
                    admpwd = "";
                else admpwd = search.FindOne().GetDirectoryEntry().Properties[ExternalResources.ldapProperties].Value.ToString();
                //var time = search.FindOne().GetDirectoryEntry().Properties[ExternalResources.ldapProperties1][0];
                search.Dispose();

                //if (search.FindOne() == null)
                //   var integer8 = "";
                //else 
                //var integer8 = search.FindOne().GetDirectoryEntry().Properties[ExternalResources.ldapProperties1].Value;
                //MessageBox.Show(integer8.ToString());
            }
            catch (Exception e)
            {
                LogsCollector.Loger(e, HostName);
            }
            return admpwd;
        }

        private static DirectorySearcher OpenAccess(string HostName)
        {
            using (DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName))
            {
                using (DirectorySearcher search = new DirectorySearcher(myLdapConnection)
                {
                    Filter = "(cn=" + HostName + ")"
                })
                {
                    return search;
                }
            }
        }

        public void LoadPassword(string hostname)
        {
            textBox1.Text = hostname;
            textBox2.Text = LAPSpwd(hostname);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = LAPSpwd(textBox1.Text);
        }

        private void LAPSui_Load(object sender, EventArgs e)
        {
            if (HostName != null)
            {
                LoadPassword(HostName);
                //textBox2.Refresh();
                //textBox2.Update();
            }
            //textBox2.ResumeLayout(false);
        }
    }
}
