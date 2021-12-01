using System;
using Cassia;
using System.ComponentModel;
using System.Windows.Forms;
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
                    string[] Keys = { "Control", "Multiply" };

                    Keys = Settings.Values.SessionDisconectShortcut.Split('+');
                    var consoleKey = (ConsoleKey)TypeDescriptor.GetConverter(typeof(ConsoleKey)).ConvertFromString(Keys[1]);
                    var remoteControlHotkeyModifiers = (RemoteControlHotkeyModifiers)TypeDescriptor.GetConverter(typeof(RemoteControlHotkeyModifiers)).ConvertFromString(Keys[0]);
                    server.GetSession(sessionID).StartRemoteControl(consoleKey, remoteControlHotkeyModifiers);
                    server.Close();
                }
            }
            catch (Win32Exception e)
            {
                MessageBox.Show(new Form() { TopMost = true }, e.Message /*"Nie można się podłączyć ponieważ sesja jest rozłączona lub użytkownik nie jest obecnie zalogowany."*/, "Podłączanie do sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static string[] GetTerminalServers => Settings.Values.CustomDataSource.Split(",");

        public ITerminalServicesSession SessionIDServer;
        public string ActiveSession(string TermServerName, string SearchedLogin)
        {
            System.Text.StringBuilder data = new System.Text.StringBuilder();
            var session = new Explorer().FindSession(new Explorer().GetRemoteServer(TermServerName), SearchedLogin);

            if (session != null)
            {
                data.Append(TermServerName + " --------------------------------\n");
                data.Append("Nazwa użytkownika     Nazwa Sesji   IP klienta       Id    Status        Czas bezczynności    Czas logowania\n");
                SessionIDServer = (session);
                data.Append(new Explorer().FormatedSession(session));
            }
            return data.ToString();
        }
    }
}
