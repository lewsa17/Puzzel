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
            string data = string.Empty;
            if (Settings.Values.AutoOpenPort)
            {
                if (QuickFix.Unlock.UnlockRemoteRPC(HostName, Microsoft.Win32.RegistryHive.LocalMachine, @"SYSTEM\CurrentControlSet\Control\Terminal Server"))
                {
                    data += (HostName + " --------------------------------\n");
                    data += ("Nazwa użytkownika     Nazwa Sesji    Id    Status        Czas bezczynności    Czas logowania\n");
                    foreach (var session in GetActiveSession(HostName))
                    {
                        data = new Explorer().FormatedSession(data, session);
                    }
                }
            }
            else { data += ("Nie posiadasz uprawnień aby odblokować RPC"); }
            return data;
        }
    }
}
