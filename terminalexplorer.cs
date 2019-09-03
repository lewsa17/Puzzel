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

        private void dynaProcessTab()
        {
            TabPage dynaProcessTab = new TabPage
            {
                Location = new System.Drawing.Point(4, 22),
                Name = "dynaProcesTab",
                Size = new System.Drawing.Size(703, 623),
                Text = "Procesy",
                UseVisualStyleBackColor = true
            };

            DataGridView dynaDataGridView = new DataGridView
            {
                ContextMenuStrip = ContextProcessMenu,
                GridColor = System.Drawing.Color.DarkGray,
                Location = new System.Drawing.Point(0, 0),
                MultiSelect = false,
                Name = "dataGridView2",
                RowHeadersVisible = false,
                SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect,
                Size = new System.Drawing.Size(703, 596),
                TabIndex = 1,
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


            Button dynaButton = new Button
            {
                Location = new System.Drawing.Point(627, 597),
                Size = new System.Drawing.Size(76, 23),
                Text = "Zamknij",
                UseVisualStyleBackColor = true,
            };

            Button dynaButton1 = new Button
            {
                Location = new System.Drawing.Point(457, 597),
                Size = new System.Drawing.Size(98, 23),
                Text = "Zamknij"
            };

            dynaButton1.Click += new EventHandler(procesyToolStripMenuItem_Click);
            dynaButton.Click += new EventHandler(zamykanieFormy);
            dynaProcessTab.Controls.AddRange(new Control[] 
            {
                new Label   {
                                AutoSize = true,
                                Location = new System.Drawing.Point(8, 602),
                                Size = new System.Drawing.Size(84, 13),
                                Text = "Lista procesów: "
                            },
                dynaButton,
                dynaButton1,
                dynaDataGridView
            });
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
            int selectedRowIndex = ((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).SelectedRows[0].Index;
            int selectedPID = Convert.ToInt16(((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Rows[selectedRowIndex].Cells[4].Value);
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
