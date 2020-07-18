namespace PuzzelLibrary.QuickFix
{
    public class DeleteUsers
    {
        public DeleteUsers(string hostname)
        {
            _HostName = hostname;
        }
        string _HostName { get; set; }

        public void saveDeleteUserData(string UserObj, bool saveFolder)
        {
            var UsersNames = new Registry.RegEnum().GetSubKeyNames(_HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList");
            foreach (var user in UsersNames)
            {
                var users = new Registry.RegEnum().GetValue(_HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + user, "ProfileImagePath");
                var count = UserObj.IndexOf("\\");
                var _userObj = UserObj.Remove(0, count + 1);
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
            string appName = ProcessExecutable.ProcExec.PSexec(_HostName);
            ProcessExecutable.ProcExec.StartSimpleProcess(appName, "cmd / c ren " + user + " " + user.Replace(@"C: \Users\", "") + "_old");
        }

        private void DeleteUserFolder(string user)
        {
            string appName = ProcessExecutable.ProcExec.PSexec(_HostName);
            ProcessExecutable.ProcExec.StartSimpleProcess(appName, "cmd /c rmdir /Q /S " + user);
        }
    }
}
