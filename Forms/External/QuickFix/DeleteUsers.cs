using System;
using System.Security.Principal;
using PuzzelLibrary.Registry;
using System.Windows.Forms;

namespace Forms.External.QuickFix
{
    public partial class DeleteUsers : Form
    {
        public DeleteUsers(string HostName)
        {
            InitializeComponent();
            _HostName = HostName;
            LoadInfo(HostName);
        }
        string _HostName { get; set; }
        public void LoadInfo(string HostName)
        {
            var UsersNames = new RegEnum().GetSubKeyNames(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList");
            foreach (string user in UsersNames)
            {
                var objSID = new SecurityIdentifier(user);
                if (objSID.BinaryLength > 14)
                {
                    IdentityReference objUser = null;
                    try { objUser = objSID.Translate(typeof(NTAccount)); }
                    catch (IdentityNotMappedException)
                    {
                        var userName = new RegEnum().GetValue(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + user, "ProfileImagePath");
                        ComboBoxUsers.Items.Add(userName.ToString().Replace("C:\\Users", HostName));
                    }
                    if (objUser != null)
                        ComboBoxUsers.Items.Add(objUser.Value);
                }
            }
        }
        private void BtnDeleteUsers_Click(object sender, EventArgs e)
        {
            using (Form owner = new Form { TopMost = true })
            {
                if (MessageBox.Show(owner, "Czy chcesz usunąć użytkownika z komputera?", "Usuwanie użytkownika", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var UserObj = ComboBoxUsers.SelectedItem.ToString();
                    var objSID = new NTAccount(UserObj);
                    using (Form owner1 = new Form { TopMost = true })
                    {
                        if (MessageBox.Show(owner1, "Czy jesteś pewien?", "Usuwanie użytkownika", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (Form owner2 = new Form { TopMost = true })
                            {
                                if (MessageBox.Show(owner2, "Czy chcesz zachować dane?", "Usuwanie użytkownika", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        var objUser = objSID.Translate(typeof(SecurityIdentifier));
                                        new PuzzelLibrary.QuickFix.DeleteUsers(_HostName).saveDeleteUserData(UserObj, true);
                                    }
                                    catch (IdentityNotMappedException)
                                    {
                                        new PuzzelLibrary.QuickFix.DeleteUsers(_HostName).saveDeleteUserData(UserObj, true);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        var objUser = objSID.Translate(typeof(SecurityIdentifier));
                                        new PuzzelLibrary.QuickFix.DeleteUsers(_HostName).saveDeleteUserData(UserObj, false);
                                    }
                                    catch (IdentityNotMappedException)
                                    {
                                        new PuzzelLibrary.QuickFix.DeleteUsers(_HostName).saveDeleteUserData(UserObj, false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
