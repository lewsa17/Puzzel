using PuzzelLibrary.Settings;
using System.Windows.Forms;

namespace PuzzelLibrary.AD.Connection
{
    public static class Credentials
    {
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static string Domain = string.Empty;
        public static string DomainName = Values.DomainController;
        public static bool Available
        {
            get => UserName.Length > 1 && Password.Length > 1 && Domain.Length > 1;
        }
    }
}
