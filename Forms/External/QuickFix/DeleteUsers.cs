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
            if (UsersNames != null)
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
        private bool MessageToUser(string Title, string Message)
        {
            using (Form owner = new Form { TopMost = true })
            {
                if (MessageBox.Show(owner, Message, Title, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                return false;
            }
        }
        private void BtnDeleteUsers_Click(object sender, EventArgs e)
        {
            if (MessageToUser("Czy chcesz usunąć użytkownika z komputera?", "Usuwanie użytkownika"))
                if (MessageToUser("Czy jesteś pewien?", "Usuwanie użytkownika"))
                {
                    var UserObj = ComboBoxUsers.SelectedItem.ToString();
                    var objSID = new NTAccount(UserObj);
                    var keepData = true;
                    if (PuzzelLibrary.Settings.Values.SaveUserData == false)
                        keepData = MessageToUser("Czy chcesz zachować dane?", "Usuwanie użytkownika");
                    try
                    {
                        var objUser = objSID.Translate(typeof(SecurityIdentifier));
                        new PuzzelLibrary.QuickFix.DeleteUsers(_HostName).saveDeleteUserData(UserObj, keepData);
                    }
                    catch (IdentityNotMappedException)
                    {
                        new PuzzelLibrary.QuickFix.DeleteUsers(_HostName).saveDeleteUserData(UserObj, keepData);
                    }
                }
        }
    }
}

