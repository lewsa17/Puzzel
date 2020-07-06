using System;
using System.Windows.Forms;
using Cassia;

namespace Forms
{
    public partial class terminalExplorerSendMessage : Form
    {
        public terminalExplorerSendMessage(string hostname, int sessionID)
        {
            _sessionID = sessionID;
            _hostname = hostname;
            InitializeComponent();
        }
        string _hostname = null;
        int _sessionID = 0;
        private void button1_Click(object sender, EventArgs e)
        {
         ITerminalServicesManager manager = new TerminalServicesManager();
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                ITerminalServicesSession session = server.GetSession(_sessionID);
                session.MessageBox(richTextBox1.Text, textBox1.Text);
                this.Close();
            }
        }
    }
}
