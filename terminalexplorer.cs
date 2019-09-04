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

        private void zamykaniestrony (object sender, EventArgs e)
        {
            tabControl1.Controls.Remove((TabPage)((Button)sender).Parent);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (IDsesjiLabel.Text.Length > 0)
            statusSesji(Convert.ToInt16(IDsesjiLabel.Text));
        }

        private void ContextMenus(object sender, EventArgs e)
        {
            int selectedRowIndex = ((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).SelectedRows[0].Index;
            int selectedSessionID = Convert.ToInt16(((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Rows[selectedRowIndex].Cells[3].Value);
            using (ITerminalServer server = manager.GetRemoteServer(_hostname))
            {
                server.Open();
                ITerminalServicesSession session = server.GetSession(selectedSessionID);

                switch (((ToolStripMenuItem)sender).Name)
                {
                    case "rozlaczToolStripMenuItem":
                        {
                            session.Disconnect();
                            break;
                        }

                    case "wyslijWiadomoscToolStripMenuItem":
                        {
                            new terminalExplorerSendMessage(_hostname, selectedSessionID).ShowDialog();
                            MessageBox.Show("Wiadomość wysłano", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }

                    case "zdalnaKontrolaToolStripMenu":
                        {
                            server.GetSession(selectedSessionID).StartRemoteControl(ConsoleKey.Multiply, RemoteControlHotkeyModifiers.Control);
                            break;
                        }

                    case "wylogujToolStripMenuItem":
                        {
                            session.Logoff();
                            break;
                        }

                    case "statusToolStripMenuItem":
                        {
                            tabControl1.SelectedTab = statusTab;
                            statusSesji(selectedSessionID);
                            break;
                        }
                    case "procesyToolStripMenuItem":
                        {
                            /*dataGridView2.Rows.Clear();
                            tabControl1.SelectedTab = procesTab;
                            foreach (ITerminalServicesProcess process in server.GetProcesses())
                                if (process.SessionId == selectedSessionID)
                                    dataGridView2.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
                            processCount.Text = "Lista procesów: " + dataGridView2.Rows.Count;*/
                            dynaProcessTab(server,session, selectedSessionID);
                            break;
                        }

                    case "ZabijProcess":
                        {
                            var processId = Convert.ToInt16(((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Rows[selectedRowIndex].Cells[4].Value); ;
                            var process = server.GetProcess(processId);
                            process.Kill();
                            MessageBox.Show("Zabito aplikację");
                            break;
                        }
                }
                server.Close();
            }
        }

        private void dynaProcessTab(ITerminalServer server, ITerminalServicesSession session, int selectedSessionID)
        {
            TabPage dynaProcessTabPage = new TabPage
            {
                Location = new System.Drawing.Point(4, 22),
                Name = "dynaProcesTab",
                Size = new System.Drawing.Size(703, 623),
                Text = "Procesy",
                UseVisualStyleBackColor = true
            };

            DataGridView dynaDataGridView = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders,
                BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                ContextMenuStrip = ContextProcessMenu,
                GridColor = System.Drawing.Color.DarkGray,
                Location = new System.Drawing.Point(0, 0),
                MultiSelect = false,
                Name = "dataGridView2",
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new System.Drawing.Size(703, 596),
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    BackColor = System.Drawing.SystemColors.Control,
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238))),
                    ForeColor = System.Drawing.SystemColors.WindowText,
                    SelectionBackColor = System.Drawing.SystemColors.Control,
                    SelectionForeColor = System.Drawing.SystemColors.WindowText,
                    WrapMode = DataGridViewTriState.False,
                },
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
            };
            dynaDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                    new DataGridViewTextBoxColumn   {  HeaderText = "Serwer",      Width = 64  },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Użytkownik",  Width = 86  },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Sesja",       Width = 57  },
                    new DataGridViewTextBoxColumn   {  HeaderText = "ID",          Width = 42  },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Proces ID",   Width = 78  },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Obraz",       Width = 59  }
            });


            Label _processCount = new Label
            {
                AutoSize = true,
                Location = new System.Drawing.Point(8, 602),
                Size = new System.Drawing.Size(84, 13),
                Text = "Lista procesów: "
            };

            Button dynaButton = new Button
            {
                Location = new System.Drawing.Point(627, 597),
                Size = new System.Drawing.Size(76, 23),
                Text = "Zamknij",
                UseVisualStyleBackColor = true,
            };
            dynaButton.Click += new EventHandler(zamykaniestrony);

            Button dynaButton1 = new Button
            {
                Location = new System.Drawing.Point(457, 597),
                Size = new System.Drawing.Size(98, 23),
                Text = "Odśwież teraz"
            };
            dynaButton1.Click += (object sender, EventArgs e) =>
            {
                dynaDataGridView.Rows.Clear();
                tabControl1.SelectedTab = dynaProcessTabPage;
                foreach (ITerminalServicesProcess process in server.GetProcesses())
                    if (process.SessionId == selectedSessionID)
                        dynaDataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
                _processCount.Text = "Lista procesów: " + dynaDataGridView.Rows.Count;
                dynaProcessTab(server, session, selectedSessionID);
            };
            dynaProcessTabPage.Controls.AddRange
                (new Control[]
                {
                    _processCount,
                    dynaButton,
                    dynaButton1,
                    dynaDataGridView
                });
            tabControl1.Controls.Add(dynaProcessTabPage);
            tabControl1.SelectedTab = dynaProcessTabPage;
            foreach (ITerminalServicesProcess process in server.GetProcesses())
                if (process.SessionId == selectedSessionID)
                    dynaDataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
            _processCount.Text = "Lista procesów: " + dynaDataGridView.Rows.Count;

        }
    }
}
