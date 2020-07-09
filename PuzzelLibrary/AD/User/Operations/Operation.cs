using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;

namespace PuzzelLibrary.AD.User
{
    public static class Operations
    {
        public static bool UnlockAccount(string userName, string controllerName)
        {
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Domain, controllerName))
                {
                    UserPrincipal uP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
                    uP.UnlockAccount();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
