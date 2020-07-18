using System;
using System.DirectoryServices.AccountManagement;

namespace PuzzelLibrary.AD.User
{
    public class AccountOperations
    {
        private bool UnlockAccount(UserPrincipal userObject)
        {
            try
            {
                userObject.UnlockAccount();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UnlockAccount(string UserName)
        {
            try
            {
                foreach(var userObject in Information.GetUserInADControllers(UserName))
                    UnlockAccount(userObject);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool isAccountLocked(string userName)
        {
                foreach (var userObject in Information.GetUserInADControllers(userName))
                    if (isAccountLocked(userObject))
                        return true;
                return false;
        }
        private bool isAccountLocked(UserPrincipal userObject)
        {
            if (userObject != null)
                if (userObject.AccountLockoutTime != null)
                    return true;
            return false;
        }
        private bool isUpper(string passowrd)
        {
            foreach (var letter in passowrd)
                if (char.IsUpper(letter))
                    return true;
            return false;
        }
        private bool isLower(string passowrd)
        {
            foreach (var letter in passowrd)
                if (char.IsLower(letter))
                    return true;
            return false;
        }
        private bool isDigit(string passowrd)
        {
            foreach (var letter in passowrd)
                if (char.IsDigit(letter))
                    return true;
            return false;
        }
        private bool isLetterOrDigit(string passowrd)
        {
            foreach (var letter in passowrd)
                if (!char.IsLetterOrDigit(letter))
                    return true;
            return false;
        }
        private bool CheckRequirementsOfPassword(string password)
        {
            int requirements = 0;
            if (isUpper(password)) requirements++;
            if (isLower(password)) requirements++;
            if (isDigit(password)) requirements++;
            if (isLetterOrDigit(password)) requirements++;
            if (requirements > 3)
                return true;
            return false;
        }
        public void ChangePassword(string UserName, string password, string confirmedPassword, bool unlockAccount, bool passwordExpired)
        {
            if (password == confirmedPassword)
            {
                //var passwordLength = GetPasswordLegthFromAD(UserName);
                if (password.Length >= 12/*passwordLength*/)
                {
                    if(CheckRequirementsOfPassword(password))
                    {
                        try
                        {
                            foreach (var userObject in Information.GetUserInADControllers(UserName))
                                ChangePassword(userObject, password, unlockAccount, passwordExpired);
                            PasswordIsChanged = true;
                        }
                        catch (Exception)
                        {
                            PasswordIsChanged = false;
                        }
                    }
                    else System.Windows.Forms.MessageBox.Show("Sprawdź poprawność hasła czy zawiera dużą lub mała literę, cyfrę lub znak specjalny");
                }
                else System.Windows.Forms.MessageBox.Show("Podane hasło ma mniej niż 12"/*PasswordLength*/+" znaków");
            }
            else System.Windows.Forms.MessageBox.Show("Podane hasła nie są zgodne");
        }
        public bool PasswordIsChanged { get; set; }
        private void ChangePassword(UserPrincipal userObject, string password, bool unlockAccount, bool passwordExpired)
        {
            userObject.SetPassword(password);
            if (isAccountLocked(userObject))
                userObject.UnlockAccount();
            if (passwordExpired)
                userObject.ExpirePasswordNow();
            userObject.Save();
        }
    }
}
