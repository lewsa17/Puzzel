using System;
using System.Windows.Forms;

namespace Forms.External.Explorer
{
    public partial class ExplorerFormSendMessage : Form
    {
        private string hostName;
        private int selectedSessionID;
        public ExplorerFormSendMessage(string _hostName, int _selectedSessionID)
        {
            hostName = _hostName;
            selectedSessionID = _selectedSessionID;
            InitializeComponent();
        }
        private void SendMessage(object sender, EventArgs e)
        {
            var session = new PuzzelLibrary.Terminal.Explorer().FindSession(new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(hostName), selectedSessionID);
                session.MessageBox(richTextBoxContents.Text, textBoxTitleValue.Text);
                this.Close();
            
        }
    }
}
