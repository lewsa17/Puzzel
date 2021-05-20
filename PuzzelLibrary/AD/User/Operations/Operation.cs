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
        public bool IsAccountLocked(string userName)
        {
                foreach (var userObject in Information.GetUserInADControllers(userName))
                    if (IsAccountLocked(userObject))
                        return true;
                return false;
        }
        private bool IsAccountLocked(UserPrincipal userObject)
        {
            if (userObject != null)
                if (userObject.AccountLockoutTime != null)
                    return true;
            return false;
        }
        private bool IsUpper(string passowrd)
        {
            foreach (var letter in passowrd)
                if (char.IsUpper(letter))
                    return true;
            return false;
        }
        private bool IsLower(string passowrd)
        {
            foreach (var letter in passowrd)
                if (char.IsLower(letter))
                    return true;
            return false;
        }
        private bool IsDigit(string passowrd)
        {
            foreach (var letter in passowrd)
                if (char.IsDigit(letter))
                    return true;
            return false;
        }
        private bool IsLetterOrDigit(string passowrd)
        {
            foreach (var letter in passowrd)
                if (!char.IsLetterOrDigit(letter))
                    return true;
            return false;
        }
        private bool CheckRequirementsOfPassword(string password)
        {
            int requirements = 0;
            if (IsUpper(password)) requirements++;
            if (IsLower(password)) requirements++;
            if (IsDigit(password)) requirements++;
            if (IsLetterOrDigit(password)) requirements++;
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
            if (IsAccountLocked(userObject))
                userObject.UnlockAccount();
            if (passwordExpired)
                userObject.ExpirePasswordNow();
            userObject.Save();
        }
    }
}
