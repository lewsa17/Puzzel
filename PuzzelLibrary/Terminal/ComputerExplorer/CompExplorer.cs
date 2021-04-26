using Cassia;
using System.Collections.Generic;
using System.Linq;

namespace PuzzelLibrary.Terminal
{
    public class CompExplorer
    {
        private IEnumerable<ITerminalServicesSession> GetRemoteComputerSessions(string hostName)
        {
            var server = new Explorer().GetRemoteServer(hostName);
            server.Open();
            var sessions = from session in server.GetSessions()
                           where session.UserName != ""
                           select session;
            return sessions;
        }

        public IEnumerable<ITerminalServicesSession> GetActiveSession(string hostName) =>
            GetRemoteComputerSessions(hostName);

        public string ActiveSession(string HostName)
        {
            System.Text.StringBuilder data = new System.Text.StringBuilder();

            QuickFix.UnlockRPC rPC = new QuickFix.UnlockRPC(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Terminal Server");
            if (rPC.IsOpen)
                GetSession(HostName, data);
            else if (rPC.IsAccessDenied)
            {
                if (Settings.Values.AutoOpenPort)
                {
                    GetSession(HostName, data);
                }
                else if (System.Windows.Forms.MessageBox.Show("Czy chcesz odblokować port", "Zdalne odblokowanie portu RPC", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    GetSession(HostName, data);
                }
                else data.Append("Operacja nieudana");
            }
            else data.Append("Brak uprawnień do wykonania operacji");
            return data.ToString();
        }

        private void GetSession(string HostName, System.Text.StringBuilder data)
        {
            data.Append(HostName + " --------------------------------\n");
            data.Append("Nazwa użytkownika     Nazwa Sesji   IP klienta       Id    Status        Czas bezczynności    Czas logowania\n");
            foreach (var session in GetActiveSession(HostName))
            {
                data.Append(new Explorer().FormatedSession(session));
            }
        }
    }
}
