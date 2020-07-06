using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzel.QuickFix
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
            var UsersNames = new Registry.RegEnum().GetSubKeyNames(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList");
            foreach (string user in UsersNames)
            {
                var objSID = new SecurityIdentifier(user);
                if (objSID.BinaryLength > 14)
                {
                    IdentityReference objUser = null;
                    try { objUser = objSID.Translate(typeof(NTAccount)); }
                    catch (IdentityNotMappedException)
                    {
                        var userName = new Registry.RegEnum().GetValue(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + user, "ProfileImagePath");
                        comboBox1.Items.Add(userName.ToString().Replace("C:\\Users", HostName));
                    }
                    if (objUser != null)
                        comboBox1.Items.Add(objUser.Value);
                }
            }
        }

        private void saveDeleteUserData(string UserObj, bool saveFolder)
        {
            var UsersNames = new Registry.RegEnum().GetSubKeyNames(_HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList");
            foreach (var user in UsersNames)
            {
                var users = new Registry.RegEnum().GetValue(_HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + user, "ProfileImagePath");
                var count = UserObj.IndexOf("\\");
                var _userObj = UserObj.Remove(0, count+1);
                if (users.ToString().Contains(_userObj))
                {
                    new Registry.RegErase().SubKeyRecursive(_HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", user);
                    if (saveFolder)
                        RenameUserFolder(users.ToString());
                    else
                        DeleteUserFolder(users.ToString());
                }
            }
        }

        private void RenameUserFolder(string user)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript("Invoke-Command -ComputerName " + _HostName + " {cmd /c ren " + user + " " + user.Replace(@"C:\Users\", "") + "_old}");
                //System.IO.Directory.Move(@"\\" + _HostName + @"\" + user, @"\\" + _HostName + @"\" + user + "_old");
                ps.Invoke();
            }
            return;
        }

        private void DeleteUserFolder(string user)
        {
            //System.IO.Directory.Delete(@"\\" + _HostName + @"\" + user,true);
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript("Invoke-Command -ComputerName " + _HostName + " {cmd /c rmdir /Q /S " + user + "}");
                ps.Invoke();
            }
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Form owner = new Form { TopMost = true })
            {
                if (MessageBox.Show(owner, "Czy chcesz usunąć użytkownika z komputera?", "Usuwanie użytkownika", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var UserObj = comboBox1.SelectedItem.ToString();
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
                                        saveDeleteUserData(UserObj, true);
                                    }
                                    catch (IdentityNotMappedException)
                                    {
                                        saveDeleteUserData(UserObj, true);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        var objUser = objSID.Translate(typeof(SecurityIdentifier));
                                        saveDeleteUserData(UserObj, false);
                                    }
                                    catch (IdentityNotMappedException)
                                    {
                                        saveDeleteUserData(UserObj, false);
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
