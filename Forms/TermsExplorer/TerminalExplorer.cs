using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private void ZamykanieFormy(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Zamykaniestrony(object sender, EventArgs e)
        {
            tabControl1.Controls.Remove((TabPage)((Button)sender).Parent);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }
        private string _hostname = null;
        //private string _username = null;
        public object[] FindSession(string serverName, string SearchedLogin)
        {
            //int _retry = 0;
            object[] sessioninfo = null;
            try
            {
            //retry:
            //    if (_retry < 5)
            //    {
                    if (Ping.TCPPing(serverName, 135) == Ping.TCPPingStatus.Success)
                    {
                        using (ITerminalServer server = manager.GetRemoteServer(serverName))
                        {
                            server.Open();
                            foreach (ITerminalServicesSession session in server.GetSessions())
                            {
                                if (session.UserName == SearchedLogin)
                                {
                                    Array.Resize(ref sessioninfo, 7);
                                    sessioninfo[0] = session.SessionId;
                                    sessioninfo[1] = session.Server.ServerName;
                                    sessioninfo[2] = session.UserName;
                                    sessioninfo[3] = session.WindowStationName;
                                    sessioninfo[4] = session.ConnectionState;
                                    sessioninfo[5] = session.IdleTime;
                                    sessioninfo[6] = session.LoginTime;
                                }
                            }
                        }
                    }
                //    else { _retry++; goto retry; }
                //}
                //else MessageBox.Show(new Form() { TopMost = true, StartPosition = FormStartPosition.CenterParent },"Po kilku próbach nie udało się nawiązać połączenia","Nawiązywanie połączenia z serwerem "+serverName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);  
            }
            catch (Win32Exception)
            { }
            catch (Exception e)
            {
                LogsCollector.Loger(e, serverName);
            }
           return sessioninfo;
        }

        public void SzukanieSesji(string serverName)
        {
            //int _retry = 0;
            _hostname = serverName;
            try
            {
                if (dataGridView1 != null)
                    dataGridView1.Rows.Clear();
                //retry:
                //if (_retry < 5)
                //{
                //if (Ping.TCPPing(serverName, 135) == Ping.TCPPingStatus.Success)
                //{
                using (ITerminalServer server = manager.GetRemoteServer(serverName))
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
                //}
                //    else { _retry++; goto retry; }
                //}
                //else MessageBox.Show(new Form() { TopMost = true, StartPosition = FormStartPosition.CenterParent }, "Po kilku próbach nie udało się nawiązać połączenia", "Nawiązywanie połączenia z serwerem " + serverName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Win32Exception)
            {
                MessageBox.Show(new Form() { TopMost = true }, "Brak dostępu", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SzukanieSesji(_hostname);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //if (IDsesjiLabel.Text.Length > 0)
               // statusSesji(Convert.ToInt16(IDsesjiLabel.Text));
        }

        Label IDsesjiLabel;         Label rozdzielczoscLabel;         Label sprzetidLabel;         Label poziomszyfrowaniaLabel;
        Label glebiakolorowLabel;         Label produktidlabel;        Label katalogLabel;        Label adresipLabel;
        Label nazwaklientaLabel;        Label kartasieciowaLabel;        Label nazwauzytkownikaLabel;        Label label10;
        Label label9;        Label bajtyramkiwychodzace;        Label ramkiwychodzaceLabel;        Label bajtywychodzaceLabel;
        Label stopienkompresjiLabel;        Label bajtyramkiprzychodzaceLabel;        Label ramkiprzychodzaceLabel;
        Label bajtyprzychodzaceLabel;        Label label16;        Label label15;        Label label14;        Label label13;
        Label label12;        Label label11;        Label label8;        Label label7;        Label label6;        Label label5;
        Label label4;        Label label3;        Label label2;        Label label1;        Label statusZalogowlabel;

        private void OdswiezStatus( ITerminalServicesSession session, int selectedSessionID)
        {
            if (session.UserAccount != null)
            {
                IDsesjiLabel.Text = null;
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
        private void OdswiezProcess(object sender, ITerminalServer server, ITerminalServicesSession session, int selectedSessionID)
        {
            DataGridView dataGridView = null;
            TabPage tabPage = null;
            if (sender is ToolStripMenuItem)
            {
                dataGridView = (DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
                tabPage = (TabPage)dataGridView.Parent;
            }
            if (sender is Button)
            {
                tabPage = (TabPage)((Button)sender).Parent;
                dataGridView = (DataGridView)tabPage.Controls.Find("dataGridView2",true)[0];
            }
            var label = tabPage.Controls.Find("processCount", true)[0];
            dataGridView.Rows.Clear();
            foreach (ITerminalServicesProcess process in server.GetProcesses())
                if (process.SessionId == selectedSessionID)
                    dataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
            ((Label)label).Text = "Lista procesów: " + dataGridView.Rows.Count;
        }

        public void LogoffSession(string hostname, int sessionID)
        {
           using (ITerminalServer server = manager.GetRemoteServer(hostname))
           {
                server.Open();
                ITerminalServicesSession session = server.GetSession(sessionID);
                session.Logoff();
                server.Close();
                MessageBox.Show(new Form() { TopMost = true }, "Sesja została rozłączona", "Rozłączanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }

        public void ConnectToSession(string hostname, int sessionID)
        {
            try
            {
                using (ITerminalServer server = manager.GetRemoteServer(hostname))
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

        private void ContextMenus(object sender, EventArgs e)
        {
            int selectedSessionID = 0;
            int selectedRowIndex = 0;

            if (sender is ToolStripMenuItem)
            {
                selectedRowIndex = ((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).SelectedRows[0].Index;
                selectedSessionID = Convert.ToInt16(((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Rows[selectedRowIndex].Cells[3].Value);
            }
            if (sender is Button)
            {
                var tabpage = (TabPage)((Button)sender).Parent;
                if (tabpage.Name == "dynaProcesTab")
                {
                    DataGridView dgv = (DataGridView)tabpage.Controls.Find("dataGridView2", true)[0];
                    selectedSessionID = (int)dgv.Rows[0].Cells[3].Value;
                }
                else { if (IDsesjiLabel.Text != null) { selectedSessionID = Convert.ToInt16(IDsesjiLabel.Text); } }
            }
            try
            {
                using (ITerminalServer server = manager.GetRemoteServer(_hostname))
                {
                    server.Open();
                    ITerminalServicesSession session = server.GetSession(selectedSessionID);
                    if (sender is ToolStripMenuItem)
                    {
                        switch (((ToolStripMenuItem)sender).Name)
                        {
                            case "rozlaczToolStripMenuItem":
                                {
                                    session.Disconnect();
                                    MessageBox.Show(new Form() { TopMost = true }, "Sesja została rozłączona", "Rozłączanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Button4_Click(sender, e);
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
                                    MessageBox.Show(new Form() { TopMost = true }, "Sesja została wylogowana", "Wylogowywanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Button4_Click(sender, e);
                                    break;
                                }

                            case "statusToolStripMenuItem":
                                {
                                    DynaStatusTab(session, selectedSessionID);
                                    break;
                                }
                            case "procesyToolStripMenuItem":
                                {
                                    DynaProcessTab(server, session, selectedSessionID);
                                    break;
                                }

                            case "ZabijProcess":
                                {
                                    var processId = Convert.ToInt16(((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Rows[selectedRowIndex].Cells[4].Value);
                                    var process = server.GetProcess(processId);
                                    var tabPage = ((TabPage)((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Parent);
                                    var button = tabPage.Controls.Find("Refresh", true);
                                    process.Kill();
                                    OdswiezProcess(sender, server, session, selectedSessionID);
                                    MessageBox.Show("Zabito aplikację");
                                    break;
                                }

                        }
                    }
                    else
                        switch (((Button)sender).Name)
                        {
                            case "RefreshProcess":
                                {
                                    OdswiezProcess(sender, server, session, selectedSessionID);
                                    break;
                                }
                            case "RefreshStatus":
                                {
                                    OdswiezStatus(session, selectedSessionID);
                                    break;
                                }
                        }

                    server.Close();
                }
            }
            catch(Exception ex)
            {
                LogsCollector.Loger(ex, _hostname);
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
                Size = new System.Drawing.Size(61,4),
                Font = new System.Drawing.Font("Tahoma", 8F),
                ShowImageMargin = false,
            }; 
            ToolStripMenuItem killprocess = new ToolStripMenuItem { Text = "Zabij proces", Name = "ZabijProcess", };
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
                ReadOnly = false,
                MultiSelect = false,
                Name = "dataGridView2",
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Size = new System.Drawing.Size(629, 596),
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
                Text = "Lista procesów: ",
                Name = "processCount"
            };

            foreach (ITerminalServicesProcess process in server.GetProcesses())
                if (process.SessionId == selectedSessionID)
                    dynaDataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
            _processCount.Text = "Lista procesów: " + dynaDataGridView.Rows.Count;
            dynaProcessTabPage.Text += " (" + dynaDataGridView.Rows[0].Cells[1].Value.ToString() + ")";
            Button dynaButton = new Button
            {
                Location = new System.Drawing.Point(552, 597),
                Size = new System.Drawing.Size(76, 23),
                Text = "Zamknij",
                UseVisualStyleBackColor = true,
            };
            dynaButton.Click += new EventHandler(Zamykaniestrony);

            Button dynaButton1 = new Button
            {
                Location = new System.Drawing.Point(382, 597),
                Size = new System.Drawing.Size(98, 23),
                Text = "Odśwież teraz",
                Name = "RefreshProcess"
            };
            dynaButton1.Click += (ContextMenus);

            dynaProcessTabPage.Controls.AddRange
                (new Control[]
                {
                    _processCount,
                    dynaButton,
                    dynaButton1,
                    dynaDataGridView
                });
            dynaDataGridView.ContextMenuStrip = contextProcessMenuStrip;
            tabControl1.Controls.Add(dynaProcessTabPage);
            tabControl1.SelectedTab = dynaProcessTabPage;
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

            //dynaStatusTabPage.Text += " (" + dynaDataGridView.Rows[0].Cells[1].Value.ToString() + ")";
            Button dynaButton = new Button
            {
                Location = new System.Drawing.Point(552, 597),
                Size = new System.Drawing.Size(76, 23),
                Text = "Zamknij",
                UseVisualStyleBackColor = true,
            };
            dynaButton.Click += new EventHandler(Zamykaniestrony);

            Button dynaButton1 = new Button
            {
                Location = new System.Drawing.Point(382, 597),
                Size = new System.Drawing.Size(98, 23),
                Text = "Odśwież teraz",
                Name = "RefreshStatus"
            };
            

            IDsesjiLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(151, 3), Size = new System.Drawing.Size(0, 13), };
            rozdzielczoscLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 365), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            sprzetidLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 330), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            poziomszyfrowaniaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 295), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            glebiakolorowLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 260), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            produktidlabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 225), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            katalogLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 190), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            adresipLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 155), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            nazwaklientaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287,120), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            kartasieciowaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 85), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            nazwauzytkownikaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287,50), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };

            label10 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 365), Size = new System.Drawing.Size(75, 13), Text = "Rozdzielczość" };
            label9 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 330), Size = new System.Drawing.Size(51, 31), Text = "Sprzęt ID" };
            bajtyramkiwychodzace = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 120), Size = new System.Drawing.Size(13, 13), Text = "0" };
            ramkiwychodzaceLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 85), Size = new System.Drawing.Size(13, 13), Text = "0" };
            bajtywychodzaceLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 50), Size = new System.Drawing.Size(13, 13), Text = "0" };
            stopienkompresjiLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 155), Size = new System.Drawing.Size(29, 13), Text = "Brak" };
            bajtyramkiprzychodzaceLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 120), Size = new System.Drawing.Size(13, 13), Text = "0" };
            ramkiprzychodzaceLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 85), Size = new System.Drawing.Size(13, 13), Text = "0" };
            bajtyprzychodzaceLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 50), Size = new System.Drawing.Size(13, 13), Text = "0" };
            label16 = new Label { AutoSize = true, Location = new System.Drawing.Point(423, 20), Size = new System.Drawing.Size(70, 13), Text = "Wychodzące" };
            label15 = new Label { AutoSize = true, Location = new System.Drawing.Point(276, 20), Size = new System.Drawing.Size(74, 13), Text = "Przychodzące" };
            label14 = new Label { AutoSize = true, Location = new System.Drawing.Point(137, 120), Size = new System.Drawing.Size(73, 13), Text = "Bajtów/ramkę" };
            label13 = new Label { AutoSize = true, Location = new System.Drawing.Point(120, 155), Size = new System.Drawing.Size(90, 13), Text = "Stopień kompresji" };
            label12 = new Label { AutoSize = true, Location = new System.Drawing.Point(173, 85), Size = new System.Drawing.Size(37, 13), Text = "Ramki" };
            label11 = new Label { AutoSize = true, Location = new System.Drawing.Point(180, 50), Size = new System.Drawing.Size(30, 13), Text = "Bajty" };
            label8 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 295), Size = new System.Drawing.Size(99, 13), Text = "Poziom szyfrowania" };
            label7 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 260), Size = new System.Drawing.Size(79, 13), Text = "Głębia kolorów" };
            label6 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 225), Size = new System.Drawing.Size(58, 13), Text = "Produkt ID" };
            label5 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 190), Size = new System.Drawing.Size(43, 13), Text = "Katalog" };
            label4 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 155), Size = new System.Drawing.Size(47, 13), Text = "Adres IP" };
            label3 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 120), Size = new System.Drawing.Size(74, 13), Text = "Nazwa klienta" };
            label2 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 85), Size = new System.Drawing.Size(76, 13), Text = "Karta sieciowa" };
            label1 = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 50), Size = new System.Drawing.Size(102, 13), Text = "Nazwa użytkownika" };
            statusZalogowlabel = new Label { AutoSize = true, Location = new System.Drawing.Point(8, 3), Size = new System.Drawing.Size(139, 13), Text = "Status zalogowanej sesji ID" };

            GroupBox stanWeWy = new GroupBox
            {
                Location = new System.Drawing.Point(11, 400),
                Size = new System.Drawing.Size(510, 180),
                TabStop = false,
                Text = "Stan wejścia/wyjścia"
            };
            dynaButton1.Click += new EventHandler(ContextMenus);
            dynaStatusTabPage.Text += " (" + session.UserName + ")";
            stanWeWy.Controls.Add(bajtyramkiwychodzace);
            stanWeWy.Controls.Add(ramkiwychodzaceLabel);
            stanWeWy.Controls.Add(bajtywychodzaceLabel);
            stanWeWy.Controls.Add(stopienkompresjiLabel);
            stanWeWy.Controls.Add(bajtyramkiprzychodzaceLabel);
            stanWeWy.Controls.Add(ramkiprzychodzaceLabel);
            stanWeWy.Controls.Add(bajtyprzychodzaceLabel);
            stanWeWy.Controls.Add(label11);
            stanWeWy.Controls.Add(label12);
            stanWeWy.Controls.Add(label13);
            stanWeWy.Controls.Add(label14);
            stanWeWy.Controls.Add(label15);
            stanWeWy.Controls.Add(label16);
            dynaStatusTabPage.Controls.Add(dynaButton);
            dynaStatusTabPage.Controls.Add(dynaButton1);
            dynaStatusTabPage.Controls.Add(IDsesjiLabel);
            dynaStatusTabPage.Controls.Add(rozdzielczoscLabel);
            dynaStatusTabPage.Controls.Add(sprzetidLabel);
            dynaStatusTabPage.Controls.Add(poziomszyfrowaniaLabel);
            dynaStatusTabPage.Controls.Add(glebiakolorowLabel);
            dynaStatusTabPage.Controls.Add(produktidlabel);
            dynaStatusTabPage.Controls.Add(katalogLabel);
            dynaStatusTabPage.Controls.Add(adresipLabel);
            dynaStatusTabPage.Controls.Add(nazwaklientaLabel);
            dynaStatusTabPage.Controls.Add(kartasieciowaLabel);
            dynaStatusTabPage.Controls.Add(nazwauzytkownikaLabel);
            dynaStatusTabPage.Controls.Add(label10);
            dynaStatusTabPage.Controls.Add(label9);
            dynaStatusTabPage.Controls.Add(stanWeWy);
            dynaStatusTabPage.Controls.Add(label8);
            dynaStatusTabPage.Controls.Add(label7);
            dynaStatusTabPage.Controls.Add(label6);
            dynaStatusTabPage.Controls.Add(label5);
            dynaStatusTabPage.Controls.Add(label4);
            dynaStatusTabPage.Controls.Add(label3);
            dynaStatusTabPage.Controls.Add(label2);
            dynaStatusTabPage.Controls.Add(label1);
            dynaStatusTabPage.Controls.Add(statusZalogowlabel);
            
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
            tabControl1.Controls.Add(dynaStatusTabPage);
            tabControl1.SelectedTab = dynaStatusTabPage;
        }
    }
}

