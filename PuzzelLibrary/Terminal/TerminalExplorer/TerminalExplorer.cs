using System;
using Cassia;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PuzzelLibrary.Terminal
{
    public class TerminalExplorer
    {
        public void ConnectToSession(string hostname, int sessionID)
        {
            try
            {
                using (ITerminalServer server = new Explorer().GetRemoteServer(hostname))
                {
                    server.Open();
                    server.GetSession(sessionID).StartRemoteControl(ConsoleKey.Multiply, RemoteControlHotkeyModifiers.Control);
                    server.Close();
                }
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(new Form() { TopMost = true }, e.Message /*"Nie można się podłączyć ponieważ sesja jest rozłączona lub użytkownik nie jest obecnie zalogowany."*/, "Podłączanie do sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static string GetTerminalServers => Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "Terminals");

        public static IList<ITerminalServicesSession> SessionIDServer;
        public string ActiveSession(string TermServerName, string SearchedLogin)
        {
            string data = string.Empty;
            foreach (var session in new Explorer().FindSession(new Explorer().GetRemoteServer(TermServerName), SearchedLogin))
            {
                SessionIDServer.Add(session);
                data = new Explorer().FormatedSession(data, session);
            }
            return data;
        }
    }
}
