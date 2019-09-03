using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Cassia;

namespace Puzzel
{
    public partial class TerminalExplorer : Form
    {
        public TerminalExplorer()
        {
            InitializeComponent();
        }

        public ITerminalServicesManager manager = new TerminalServicesManager();
        private void zamykanieFormy(object sender, EventArgs e)
        {
            this.Close();
        }

        public string _hostname = null;
        public string _username = null;
        public void szukanieSesji(string hostname)
        {
            _hostname = hostname;
            using (ITerminalServer server = manager.GetRemoteServer(hostname))
            {
                server.Open();
                IList<ITerminalServicesSession> sessions;
                sessions = server.GetSessions();
                foreach (ITerminalServicesSession session in sessions)
                {
                    if (session.UserAccount != null)
                            dataGridView1.BeginInvoke(new Action(() => 
                        dataGridView1.Rows.Add(
                            session.Server.ServerName,
                            session.UserName,
                            session.WindowStationName,
                            session.SessionId,
                            session.ConnectionState,
                            session.IdleTime,
                            session.LoginTime)));
                }
                server.Close();
                sessionCount.BeginInvoke(new Action(() => sessionCount.Text = "Aktywne sesje: " + dataGridView1.Rows.Count));
            }
        }

        public void statusSesji(int selectedSessionID)
        {
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                ITerminalServicesSession session = server.GetSession(selectedSessionID);
                if (session.UserAccount != null)
                {
                    IDsesjiLabel.Text = selectedSessionID.ToString();
                    nazwauzytkownikaLabel.Text = session.UserName;
                    nazwaklientaLabel.Text = session.ClientName;

                    if (session.ClientIPAddress != null)
                    {
                        adresipLabel.Text = session.ClientIPAddress.ToString();
                    }
                    else
                    {
                        adresipLabel.Text = "brak danych";
                    }
                    katalogLabel.Text = session.ClientDirectory;
                    produktidlabel.Text = session.ClientProductId.ToString();
                    glebiakolorowLabel.Text = session.ClientDisplay.BitsPerPixel.ToString();
                    sprzetidLabel.Text = session.ClientHardwareId.ToString();
                    rozdzielczoscLabel.Text = (session.ClientDisplay.HorizontalResolution + " x " + session.ClientDisplay.VerticalResolution).ToString();

                    bajtyprzychodzaceLabel.Text = session.IncomingStatistics.Bytes.ToString();
                    ramkiprzychodzaceLabel.Text = session.IncomingStatistics.Frames.ToString();
                    if (session.IncomingStatistics.Bytes > 0 && session.IncomingStatistics.Frames > 0) 
                    bajtyramkiprzychodzaceLabel.Text = Math.Floor(Convert.ToDecimal(session.IncomingStatistics.Bytes / session.IncomingStatistics.Frames)).ToString();
                    else bajtyramkiwychodzace.Text = "brak danych";

                    bajtywychodzaceLabel.Text = session.OutgoingStatistics.Bytes.ToString();
                    ramkiwychodzaceLabel.Text = session.OutgoingStatistics.Frames.ToString();

                    if (session.OutgoingStatistics.Bytes > 0 && session.OutgoingStatistics.Frames > 0)
                        bajtyramkiwychodzace.Text = Math.Floor(Convert.ToDecimal(session.OutgoingStatistics.Bytes / session.OutgoingStatistics.Frames)).ToString();
                    else bajtyramkiwychodzace.Text = "brak danych";
                }
                server.Close();
            }
            ramkiwychodzaceLabel.Refresh();
            bajtyramkiwychodzace.Refresh();
            bajtywychodzaceLabel.Refresh();
            bajtyramkiprzychodzaceLabel.Refresh();
            ramkiprzychodzaceLabel.Refresh();
            bajtyprzychodzaceLabel.Refresh();
            rozdzielczoscLabel.Refresh();
            sprzetidLabel.Refresh();
            glebiakolorowLabel.Refresh();
            produktidlabel.Refresh();
            katalogLabel.Refresh();
            adresipLabel.Refresh();
            IDsesjiLabel.Refresh();
            nazwaklientaLabel.Refresh();
            nazwaklientaLabel.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            szukanieSesji(_hostname);
        }
        int selectedSessionID;
        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            selectedSessionID = Convert.ToInt16(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);
            tabControl1.SelectedTab = statusTab;
            statusSesji(selectedSessionID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statusSesji(selectedSessionID);
        }

        private void wyslijWiadomoscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            selectedSessionID = Convert.ToInt16(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);
            terminalExplorerSendMessage tesm = new terminalExplorerSendMessage(_hostname, selectedSessionID);
            tesm.ShowDialog();
            MessageBox.Show("Wiadomość wysłano", "Informacja");
        }

        private void wylogujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            selectedSessionID = Convert.ToInt16(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                ITerminalServicesSession session = server.GetSession(selectedSessionID);
                session.Logoff();
                server.Close();
            }
        }

        private void rozlaczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            selectedSessionID = Convert.ToInt16(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                ITerminalServicesSession session = server.GetSession(selectedSessionID);
                session.Disconnect();
                server.Close();
            }
        }

        private void zdalnaKontrolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            selectedSessionID = Convert.ToInt16(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);
            string _server = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            using (ITerminalServer server = manager.GetRemoteServer(_server))
            {
                server.Open();
                server.GetSession(selectedSessionID).StartRemoteControl(ConsoleKey.Multiply, RemoteControlHotkeyModifiers.Control);
                server.Close();
            } 
        }

        private void procesyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            selectedSessionID = Convert.ToInt16(dataGridView1.Rows[selectedRowIndex].Cells[3].Value);
            tabControl1.SelectedTab = procesTab;
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                //ITerminalServicesSession session = server.GetSession(selectedSessionID);
                // session.GetProcesses();
                foreach (ITerminalServicesProcess process in server.GetProcesses())
                {
                    if (process.SessionId == selectedSessionID)
                    {
                        ITerminalServicesSession session = server.GetSession(process.SessionId);
                        dataGridView2.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
                    }
                }

                server.Close();
                processCount.Text = "Lista procesów: " + dataGridView2.Rows.Count;
            }
        }

        private void ZabijProcess_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView2.SelectedRows[0].Index;
            int selectedPID = Convert.ToInt16(dataGridView2.Rows[selectedRowIndex].Cells[4].Value);

            var processId = selectedPID;
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                var process = server.GetProcess(processId);
                process.Kill();
            }

            MessageBox.Show("Zabito aplikację");
        }
    }
    
}
