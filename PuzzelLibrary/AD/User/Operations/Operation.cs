using System;
using System.DirectoryServices.AccountManagement;

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
