using System;
using System.ComponentModel;
using System.Windows.Forms;
using Cassia;

namespace Forms.External.Explorer
{
    public partial class ExplorerForm : Form
    {
        public ExplorerForm(string name)
        {
            InitializeComponent();
            this.Text = this.Text + " Connected to:(" + name + ")";
        }
        public string HostName { get; set; }

        private void CloseTabForm(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != tabPageSession)
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
                tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
            }
            else
            {
                this.Close();
            }
        }

        Label IDSessionLabel; Label resolutionValueLabel; Label hardwareIDValueLabel; Label encryptionLevelValueLabel;
        Label depthValueLabel; Label productidValueLabel; Label catalogValueLabel; Label addressIPValueLabel;
        Label hostNameValueLabel; Label nicValueLabel; Label userNameValueLabel; Label resolutionLabel;
        Label hardwareIDLabel; Label bytesFramesOutLabel; Label framesOutLabel; Label bytesOutLabel;
        Label compressionLevelLabel; Label bytesFramesInLabel; Label framesInLabel;
        Label bytesInLabel; Label outPacketLabel; Label inPacketLabel; Label bytesPerFrameLabel; Label compressionLabel;
        Label framesLabel; Label bytesLabel; Label encryptionLabel; Label depthLabel; Label productIDLabel; Label catalogLabel;
        Label addressIPLabel; Label hostNameLabel; Label nicLabel; Label userNameLabel; Label statusSessionLabel;

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != tabPageSession)
            {
                ContextMenus(sender, e);
            }
            else
            {
                DataGridView.Rows.Clear();
                GetSessionsToDataGridView();
            }
        }
        public void GetSessionsToDataGridView()
        {
            try
            {
                if (DataGridView != null)
                    DataGridView.Rows.Clear();

                var Server = new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(HostName);
                var sessions = new PuzzelLibrary.Terminal.Explorer().FindSessions(Server);
                    foreach (ITerminalServicesSession session in sessions)
                    {
                        if (session.UserAccount != null)
                            DataGridView.BeginInvoke(new Action(() =>
                            DataGridView.Rows.Add(
                            session.Server.ServerName,
                            session.UserName,
                            session.WindowStationName,
                            session.SessionId,
                            session.ConnectionState,
                            session.IdleTime,
                            session.LoginTime)));
                    }
                labelSessionCount.BeginInvoke(new Action(() => labelSessionCount.Text = "Aktywne sesje: " + DataGridView.RowCount));
            }
            catch (Win32Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "Brak dostępu", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void RefreshStatus(ITerminalServicesSession session, int selectedSessionID)
        {
            if (session.UserAccount != null)
            {
                IDSessionLabel.Text = null;
                IDSessionLabel.Text = selectedSessionID.ToString();
                userNameValueLabel.Text = session.UserName;
                hostNameValueLabel.Text = session.ClientName;

                if (session.ClientIPAddress != null)
                {
                    addressIPValueLabel.Text = session.ClientIPAddress.ToString();
                }
                else
                {
                    addressIPValueLabel.Text = "brak danych";
                }
                catalogValueLabel.Text = session.ClientDirectory;
                productidValueLabel.Text = session.ClientProductId.ToString();
                depthValueLabel.Text = session.ClientDisplay.BitsPerPixel.ToString();
                hardwareIDValueLabel.Text = session.ClientHardwareId.ToString();
                resolutionValueLabel.Text = (session.ClientDisplay.HorizontalResolution + " x " + session.ClientDisplay.VerticalResolution).ToString();

                bytesInLabel.Text = session.IncomingStatistics.Bytes.ToString();
                framesInLabel.Text = session.IncomingStatistics.Frames.ToString();
                if (session.IncomingStatistics.Bytes > 0 && session.IncomingStatistics.Frames > 0)
                    bytesFramesInLabel.Text = Math.Floor(Convert.ToDecimal(session.IncomingStatistics.Bytes / session.IncomingStatistics.Frames)).ToString();
                else bytesFramesOutLabel.Text = "brak danych";

                bytesOutLabel.Text = session.OutgoingStatistics.Bytes.ToString();
                framesOutLabel.Text = session.OutgoingStatistics.Frames.ToString();

                if (session.OutgoingStatistics.Bytes > 0 && session.OutgoingStatistics.Frames > 0)
                    bytesFramesOutLabel.Text = Math.Floor(Convert.ToDecimal(session.OutgoingStatistics.Bytes / session.OutgoingStatistics.Frames)).ToString();
                else bytesFramesOutLabel.Text = "brak danych";
            }
            framesOutLabel.Refresh();
            bytesFramesOutLabel.Refresh();
            bytesOutLabel.Refresh();
            bytesFramesInLabel.Refresh();
            framesInLabel.Refresh();
            bytesInLabel.Refresh();
            resolutionValueLabel.Refresh();
            hardwareIDValueLabel.Refresh();
            depthValueLabel.Refresh();
            productidValueLabel.Refresh();
            catalogValueLabel.Refresh();
            addressIPValueLabel.Refresh();
            IDSessionLabel.Refresh();
            hostNameValueLabel.Refresh();
            hostNameValueLabel.Refresh();
        }
        private void RefreshProcesses(object sender, ITerminalServer server, ITerminalServicesSession session, int selectedSessionID)
        {
            var tabPage = tabControl.SelectedTab;
            var dataGridView = (DataGridView)tabPage.Controls.Find("DataGridView", true)[0];
            dataGridView.Rows.Clear();
            foreach (ITerminalServicesProcess process in new PuzzelLibrary.Terminal.Explorer().GetExplorerProcess(server))
                if (process.SessionId == selectedSessionID)
                    dataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
            labelSessionCount.Text = "Lista procesów: " + dataGridView.Rows.Count;
        }

        private void ContextMenus(object sender, EventArgs e)
        {
            int selectedSessionID = 0;
            DataGridView datagridview = null;
            int selectedRowIndex = 0;
            if (tabControl.SelectedTab.Name != "dynaStatusTab")
            {
                var tabpage = tabControl.SelectedTab;
                datagridview = (DataGridView)tabpage.Controls.Find("DataGridView", true)[0];
                selectedRowIndex = datagridview.SelectedRows[0].Index;
                selectedSessionID = Convert.ToInt16(datagridview.Rows[selectedRowIndex].Cells[3].Value);
            }
            else
                selectedSessionID = Convert.ToInt16(IDSessionLabel.Text);

            try
            {
                using (ITerminalServer server = new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(HostName))
                {
                    server.Open();
                    ITerminalServicesSession session = server.GetSession(selectedSessionID);
                    if (sender is ToolStripMenuItem)
                    {
                        switch (((ToolStripMenuItem)sender).Name)
                        {
                            case nameof(menuItemSessionDisconnect):
                                {
                                    session.Disconnect();
                                    MessageBox.Show(new Form() { TopMost = true }, "Sesja została rozłączona", "Rozłączanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BtnRefresh_Click(sender, e);
                                    break;
                                }

                            case nameof(menuItemSessionSendMessage):
                                {
                                    using (var terms = new ExplorerFormSendMessage(HostName, selectedSessionID))
                                    {
                                        terms.ShowDialog();
                                        MessageBox.Show("Wiadomość wysłano", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    break;
                                }

                            case nameof(menuItemSessionRemoteControl):
                                {
                                    var ADCompResult = PuzzelLibrary.AD.Computer.Search.ByComputerName(HostName, "operatingSystemVersion");
                                    var osVersionComplete = ADCompResult[0].GetDirectoryEntry().Properties["operatingSystemVersion"].Value.ToString().Split(" ");
                                    double osVersion = Convert.ToDouble(osVersionComplete[0].Replace('.', ','));
                                    if (osVersion > 6.1)
                                    {
                                        PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mstsc.exe", "/v:" + HostName + " /shadow:" + selectedSessionID + " /control /NoConsentPrompt");
                                    }
                                    else
                                    {
                                        PuzzelLibrary.Terminal.TerminalExplorer Term = new PuzzelLibrary.Terminal.TerminalExplorer();
                                        Term.ConnectToSession(HostName, selectedSessionID);
                                    }
                                    break;
                                }

                            case nameof(menuItemSessionLogoff):
                                {
                                    session.Logoff();
                                    MessageBox.Show(new Form() { TopMost = true }, "Sesja została wylogowana", "Wylogowywanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BtnRefresh_Click(sender, e);
                                    break;
                                }

                            case nameof(menuItemSessionStatus):
                                {
                                    DynaStatusTab(session, selectedSessionID);
                                    break;
                                }
                            case nameof(menuItemSessionProcesses):
                                {
                                    DynaProcessTab(server, session, selectedSessionID);
                                    break;
                                }

                            case "KillProcess":
                                {
                                    var processId = Convert.ToInt16(datagridview.Rows[selectedRowIndex].Cells[4].Value);
                                    var process = server.GetProcess(processId);
                                    process.Kill();
                                    RefreshProcesses(sender, server, session, selectedSessionID);
                                    MessageBox.Show("Zabito aplikację");
                                    break;
                                }

                        }
                    }
                    else
                        switch (((Button)sender).Name)
                        {
                            case nameof(btnRefreshNow):
                                {
                                    if (tabControl.SelectedTab.Name == "dynaProcesTab")
                                    {
                                        RefreshProcesses(sender, server, session, selectedSessionID);
                                        break;
                                    }

                                    if (tabControl.SelectedTab.Name == "dynaStatusTab")
                                    {
                                        RefreshStatus(session, selectedSessionID);
                                        break;
                                    }
                                    break;
                                }
                        }

                    server.Close();
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, HostName);
            }
        }

        private void DynaProcessTab(ITerminalServer server, ITerminalServicesSession session, int selectedSessionID)
        {
            TabPage dynaProcessTabPage = new TabPage
            {
                Location = new System.Drawing.Point(4, 22),
                Name = "dynaProcesTab",
                Size = new System.Drawing.Size(629, 623),
                Text = "Procesy",
                UseVisualStyleBackColor = true
            };

            ContextMenuStrip contextProcessMenuStrip = new ContextMenuStrip
            {
                Font = new System.Drawing.Font("Tahoma", 8F),
                ShowImageMargin = false,
            };
            ToolStripMenuItem killprocess = new ToolStripMenuItem { Text = "Zabij proces", Name = "KillProcess" };
            killprocess.Click += new EventHandler(ContextMenus);
            contextProcessMenuStrip.Items.Add(killprocess);
            DataGridView dynaDataGridView = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders,
                BackgroundColor = System.Drawing.SystemColors.ControlLightLight,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                GridColor = System.Drawing.Color.DarkGray,
                Location = new System.Drawing.Point(0, 0),
                ReadOnly = true,
                MultiSelect = false,
                Name = "DataGridView",
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = DataGridView.Size,
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
                    new DataGridViewTextBoxColumn   {  HeaderText = "Serwer",      Width = 64 },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Użytkownik",  Width = 86 },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Sesja",       Width = 57 },
                    new DataGridViewTextBoxColumn   {  HeaderText = "ID",          Width = 42 },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Proces ID",   Width = 78 },
                    new DataGridViewTextBoxColumn   {  HeaderText = "Obraz",       Width = 59, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill  }
            });

            foreach (ITerminalServicesProcess process in server.GetProcesses())
                if (process.SessionId == selectedSessionID)
                    dynaDataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
            labelSessionCount.Text = "Lista procesów: " + dynaDataGridView.Rows.Count;
            dynaProcessTabPage.Text += " (" + dynaDataGridView.Rows[0].Cells[1].Value.ToString() + ")";

            dynaProcessTabPage.Controls.AddRange
                (new Control[]
                {
                    dynaDataGridView
                });
            dynaDataGridView.ContextMenuStrip = contextProcessMenuStrip;
            tabControl.Controls.Add(dynaProcessTabPage);
            tabControl.SelectedTab = dynaProcessTabPage;
        }

        private void DynaStatusTab(ITerminalServicesSession session, int selectedSessionID)
        {
            TabPage dynaStatusTabPage = new TabPage
            {
                Location = new System.Drawing.Point(4, 22),
                Name = "dynaStatusTab",
                Size = new System.Drawing.Size(629, 623),
                Text = "Status",
                UseVisualStyleBackColor = true,
                Padding = new System.Windows.Forms.Padding(3)
            };

            IDSessionLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(151, 3), Size = new System.Drawing.Size(0, 13), };
            resolutionValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 365), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            hardwareIDValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 330), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            encryptionLevelValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 295), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            depthValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 260), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            productidValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 225), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            catalogValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 190), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            addressIPValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 155), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            hostNameValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 120), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            nicValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 85), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            userNameValueLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 50), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };

            resolutionLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 365), Size = new System.Drawing.Size(75, 13), Text = "Rozdzielczość" };
            hardwareIDLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 330), Size = new System.Drawing.Size(51, 31), Text = "Sprzęt ID" };
            bytesFramesOutLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 120), Size = new System.Drawing.Size(13, 13), Text = "0" };
            framesOutLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 85), Size = new System.Drawing.Size(13, 13), Text = "0" };
            bytesOutLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 50), Size = new System.Drawing.Size(13, 13), Text = "0" };
            compressionLevelLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 155), Size = new System.Drawing.Size(29, 13), Text = "Brak" };
            bytesFramesInLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 120), Size = new System.Drawing.Size(13, 13), Text = "0" };
            framesInLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 85), Size = new System.Drawing.Size(13, 13), Text = "0" };
            bytesInLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 50), Size = new System.Drawing.Size(13, 13), Text = "0" };
            outPacketLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 20), Size = new System.Drawing.Size(70, 13), Text = "Wychodzące" };
            inPacketLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 20), Size = new System.Drawing.Size(74, 13), Text = "Przychodzące" };
            bytesPerFrameLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(137, 120), Size = new System.Drawing.Size(73, 13), Text = "Bajtów/ramkę" };
            compressionLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(120, 155), Size = new System.Drawing.Size(90, 13), Text = "Stopień kompresji" };
            framesLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(173, 85), Size = new System.Drawing.Size(37, 13), Text = "Ramki" };
            bytesLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(180, 50), Size = new System.Drawing.Size(30, 13), Text = "Bajty" };
            encryptionLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 295), Size = new System.Drawing.Size(99, 13), Text = "Poziom szyfrowania" };
            depthLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 260), Size = new System.Drawing.Size(79, 13), Text = "Głębia kolorów" };
            productIDLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 225), Size = new System.Drawing.Size(58, 13), Text = "Produkt ID" };
            catalogLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 190), Size = new System.Drawing.Size(43, 13), Text = "Katalog" };
            addressIPLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 155), Size = new System.Drawing.Size(47, 13), Text = "Adres IP" };
            hostNameLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 120), Size = new System.Drawing.Size(74, 13), Text = "Nazwa klienta" };
            nicLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 85), Size = new System.Drawing.Size(76, 13), Text = "Karta sieciowa" };
            userNameLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 50), Size = new System.Drawing.Size(102, 13), Text = "Nazwa użytkownika" };
            statusSessionLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 3), Size = new System.Drawing.Size(139, 13), Text = "Status zalogowanej sesji ID" };

            GroupBox statusIO = new GroupBox
            {
                Location = new System.Drawing.Point(11, 400),
                Size = new System.Drawing.Size(510, 180),
                TabStop = false,
                Text = "Stan wejścia/wyjścia"
            };
            dynaStatusTabPage.Text += " (" + session.UserName + ")";
            statusIO.Controls.Add(bytesFramesOutLabel);
            statusIO.Controls.Add(framesOutLabel);
            statusIO.Controls.Add(bytesOutLabel);
            statusIO.Controls.Add(compressionLevelLabel);
            statusIO.Controls.Add(bytesFramesInLabel);
            statusIO.Controls.Add(framesInLabel);
            statusIO.Controls.Add(bytesInLabel);
            statusIO.Controls.Add(bytesLabel);
            statusIO.Controls.Add(framesLabel);
            statusIO.Controls.Add(compressionLabel);
            statusIO.Controls.Add(bytesPerFrameLabel);
            statusIO.Controls.Add(inPacketLabel);
            statusIO.Controls.Add(outPacketLabel);
            dynaStatusTabPage.Controls.Add(IDSessionLabel);
            dynaStatusTabPage.Controls.Add(resolutionValueLabel);
            dynaStatusTabPage.Controls.Add(hardwareIDValueLabel);
            dynaStatusTabPage.Controls.Add(encryptionLevelValueLabel);
            dynaStatusTabPage.Controls.Add(depthValueLabel);
            dynaStatusTabPage.Controls.Add(productidValueLabel);
            dynaStatusTabPage.Controls.Add(catalogValueLabel);
            dynaStatusTabPage.Controls.Add(addressIPValueLabel);
            dynaStatusTabPage.Controls.Add(hostNameValueLabel);
            dynaStatusTabPage.Controls.Add(nicValueLabel);
            dynaStatusTabPage.Controls.Add(userNameValueLabel);
            dynaStatusTabPage.Controls.Add(resolutionLabel);
            dynaStatusTabPage.Controls.Add(hardwareIDLabel);
            dynaStatusTabPage.Controls.Add(statusIO);
            dynaStatusTabPage.Controls.Add(encryptionLabel);
            dynaStatusTabPage.Controls.Add(depthLabel);
            dynaStatusTabPage.Controls.Add(productIDLabel);
            dynaStatusTabPage.Controls.Add(catalogLabel);
            dynaStatusTabPage.Controls.Add(addressIPLabel);
            dynaStatusTabPage.Controls.Add(hostNameLabel);
            dynaStatusTabPage.Controls.Add(nicLabel);
            dynaStatusTabPage.Controls.Add(userNameLabel);
            dynaStatusTabPage.Controls.Add(statusSessionLabel);

            if (session.UserAccount != null)
            {
                IDSessionLabel.Text = selectedSessionID.ToString();
                userNameValueLabel.Text = session.UserName;
                hostNameValueLabel.Text = session.ClientName;

                if (session.ClientIPAddress != null)
                {
                    addressIPValueLabel.Text = session.ClientIPAddress.ToString();
                }
                else
                {
                    addressIPValueLabel.Text = "brak danych";
                }
                catalogValueLabel.Text = session.ClientDirectory;
                productidValueLabel.Text = session.ClientProductId.ToString();
                depthValueLabel.Text = session.ClientDisplay.BitsPerPixel.ToString();
                hardwareIDValueLabel.Text = session.ClientHardwareId.ToString();
                resolutionValueLabel.Text = (session.ClientDisplay.HorizontalResolution + " x " + session.ClientDisplay.VerticalResolution).ToString();

                bytesInLabel.Text = session.IncomingStatistics.Bytes.ToString();
                framesInLabel.Text = session.IncomingStatistics.Frames.ToString();
                if (session.IncomingStatistics.Bytes > 0 && session.IncomingStatistics.Frames > 0)
                    bytesFramesInLabel.Text = Math.Floor(Convert.ToDecimal(session.IncomingStatistics.Bytes / session.IncomingStatistics.Frames)).ToString();
                else bytesFramesOutLabel.Text = "brak danych";

                bytesOutLabel.Text = session.OutgoingStatistics.Bytes.ToString();
                framesOutLabel.Text = session.OutgoingStatistics.Frames.ToString();

                if (session.OutgoingStatistics.Bytes > 0 && session.OutgoingStatistics.Frames > 0)
                    bytesFramesOutLabel.Text = Math.Floor(Convert.ToDecimal(session.OutgoingStatistics.Bytes / session.OutgoingStatistics.Frames)).ToString();
                else bytesFramesOutLabel.Text = "brak danych";
            }
            tabControl.Controls.Add(dynaStatusTabPage);
            tabControl.SelectedTab = dynaStatusTabPage;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "dynaProcesTab")
            {
                var dataGridView = (DataGridView)tabControl.SelectedTab.Controls.Find("DataGridView", true)[0];
                labelSessionCount.Text = "Lista procesów: " + dataGridView.Rows.Count;
            }
            if (tabControl.SelectedTab == tabPageSession)
            {
                labelSessionCount.Text = "Aktywne sesje: " + DataGridView.Rows.Count;
            }
        }

    }
}
