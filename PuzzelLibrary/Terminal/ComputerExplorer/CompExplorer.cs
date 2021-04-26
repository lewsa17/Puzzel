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
            if (Settings.Values.AutoOpenPort)
            {
                if (QuickFix.Unlock.UnlockRemoteRPC(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Terminal Server"))
                {
                    data.Append(HostName + " --------------------------------\n");
                    data.Append("Nazwa użytkownika     Nazwa Sesji    Id    Status        Czas bezczynności    Czas logowania\n");
                    foreach (var session in GetActiveSession(HostName))
                    {
                        data.Append(new Explorer().FormatedSession(data, session));
                    }
                }
            }
            else { data.Append("Nie posiadasz uprawnień aby odblokować RPC"); }
            return data.ToString();
        }
    }
}
