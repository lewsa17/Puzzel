using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cassia;

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
                session.Logoff(false);
                server.Close();
                MessageBox.Show(new Form() { TopMost = true }, "Wysłano instrukcję wyłączenia sesji", "Rozłączanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public string FormatedSession(ITerminalServicesSession session)
        {
            System.Text.StringBuilder data = new System.Text.StringBuilder();
            data.Append(session.UserName);
            for (int i = 0; i < "Nazwa użytkownika     ".Length - session.UserName.Length; i++)
                data.Append(" ");

            data.Append(session.WindowStationName);
            for (int i = 0; i < "Nazwa Sesji   ".Length - session.WindowStationName.Length; i++)
                data.Append(" ");
            string IPAddress;
            if (session.ConnectionState != ConnectionState.Disconnected && session.ClientProtocolType != ClientProtocolType.Console)
            {
                IPAddress = session.ClientIPAddress != null ? session.ClientIPAddress.ToString() : "Niedostępne";
            }
            else IPAddress = "Niedostępne";
            data.Append(IPAddress);
            for (int i = 0; i < "    IP klienta   ".Length - IPAddress.Length; i++)
                data.Append(" ");

            data.Append(session.SessionId);
            for (int i = 0; i < " Id   ".Length - session.SessionId.ToString().Length; i++)
                data.Append(" ");

            data.Append(session.ConnectionState);
            for (int i = 0; i < "Status        ".Length - session.ConnectionState.ToString().Length; i++)
                data.Append(" ");

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
            data.Append(idletime);
            for (int i = 0; i < "Czas bezczynności    ".Length - idletime.Length; i++)
                data.Append(" ");

            data.Append(session.LoginTime);
            data.Append("\n");
            return data.ToString();
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
