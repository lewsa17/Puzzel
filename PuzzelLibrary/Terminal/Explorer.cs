using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cassia;
using System.Linq;

namespace PuzzelLibrary.Terminal
{
    public class Explorer
    {
        public ITerminalServer GetRemoteServer(string hostName) =>
            new TerminalServicesManager().GetRemoteServer(hostName);
        public static void LogOffSession(ITerminalServer Server, int sessionID)
        {
            using (ITerminalServer server = Server)
            {
                server.Open();
                ITerminalServicesSession session = server.GetSession(sessionID);
                session.Logoff();
                server.Close();
                MessageBox.Show(new Form() { TopMost = true }, "Sesja została rozłączona", "Rozłączanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string FormatedSession(string data, ITerminalServicesSession session)
        {
            data += (session.UserName);
            for (int i = 0; i < "Nazwa użytkownika     ".Length - session.UserName.Length; i++)
                data += (" ");

            data += (session.WindowStationName);
            for (int i = 0; i < "Nazwa Sesji   ".Length - session.WindowStationName.Length; i++)
                data += (" ");
            string IPAddress;
            if (session.ConnectionState != ConnectionState.Disconnected)
                IPAddress = (session.ClientIPAddress.ToString());
            else
                IPAddress = "niedostępne";
                for (int i = 0; i < "    IP klienta   ".Length - IPAddress.Length; i++)
                    data += " ";

            data += (session.SessionId);
            for (int i = 0; i < " Id   ".Length - session.SessionId.ToString().Length; i++)
                data += (" ");

            data += (session.ConnectionState);
            for (int i = 0; i < "Status        ".Length - session.ConnectionState.ToString().Length; i++)
                data += (" ");

            //Wyekstraktowanie całego czasu bezczynności
            int time = Convert.ToInt32(Math.Ceiling(((TimeSpan)session.IdleTime).TotalSeconds));
            double _time = 0;
            string idletime = "";
            if ((time / 3600) >= 1)
            {
                _time = (time / 3600);
                idletime += (Math.Ceiling(_time).ToString() + ":");
                time -= Convert.ToInt32(Math.Ceiling(_time)) * 3600;
            }
            if ((time / 60) > 1)
            {
                _time = (time / 60);
                idletime += (Math.Ceiling(_time).ToString() + ":");
                time -= Convert.ToInt32(Math.Ceiling(_time)) * 60;
            }

            idletime += (time.ToString());
            data += (idletime);
            for (int i = 0; i < "Czas bezczynności    ".Length - idletime.Length; i++)
                data += (" ");

            data += (session.LoginTime);
            data += ("\n");
            return data;
        }
        public IList<ITerminalServicesSession> FindSessions(ITerminalServer server)
        {
            server.Open();
            return server.GetSessions();
        }

        public ITerminalServicesSession FindSession(ITerminalServer server, int sessionID)
        {
            server.Open();
            return server.GetSession(sessionID);
        }

        public ITerminalServicesSession FindSession(ITerminalServer server, string SearchedLogin)
        {
            try
            {
                foreach (var currentSession in FindSessions(server))
                    if (string.Equals(currentSession.UserName, SearchedLogin, StringComparison.OrdinalIgnoreCase))
                        return currentSession;
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(e, server.ServerName);
            }
            catch (Exception e)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(e, server.ServerName);
            }
            return null;
        }

        public IEnumerable<ITerminalServicesProcess> GetExplorerProcess(ITerminalServer server)
        {
            server.Open();
            return server.GetProcesses();
        }

        public ITerminalServicesProcess GetProcess(ITerminalServer server, int processId)
        {
            server.Open();
            return server.GetProcess(processId);
        }
    }
}
