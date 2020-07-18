using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseTabPage(object sender, EventArgs e)
        {
            tabControl.Controls.Remove((TabPage)((Button)sender).Parent);
            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
        }

        Label IDsesjiLabel; Label rozdzielczoscLabel; Label sprzetidLabel; Label poziomszyfrowaniaLabel;
        Label glebiakolorowLabel; Label produktidlabel; Label katalogLabel; Label adresipLabel;
        Label nazwaklientaLabel; Label kartasieciowaLabel; Label nazwauzytkownikaLabel; Label label10;
        Label label9; Label bajtyramkiwychodzace; Label ramkiwychodzaceLabel; Label bajtywychodzaceLabel;
        Label stopienkompresjiLabel; Label bajtyramkiprzychodzaceLabel; Label ramkiprzychodzaceLabel;
        Label bajtyprzychodzaceLabel; Label label16; Label label15; Label label14; Label label13;
        Label label12; Label label11; Label label8; Label label7; Label label6; Label label5;
        Label label4; Label label3; Label label2; Label label1; Label statusZalogowlabel;
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
                DataGridView.Rows.Clear();
                GetSessionsToDataGridView();
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
                    labelSessionCount.BeginInvoke(new Action(() => labelSessionCount.Text = "Aktywne sesje: " + sessions.Count));    
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
        private void RefreshProcesses(object sender, ITerminalServer server, ITerminalServicesSession session, int selectedSessionID)
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
                dataGridView = (DataGridView)tabPage.Controls.Find("dataGridView2", true)[0];
            }
            var label = tabPage.Controls.Find("processCount", true)[0];
            dataGridView.Rows.Clear();
            foreach (ITerminalServicesProcess process in new PuzzelLibrary.Terminal.Explorer().GetExplorerProcess(server))
                if (process.SessionId == selectedSessionID)
                    dataGridView.Rows.Add(session.Server.ServerName, session.UserName, session.WindowStationName, process.SessionId, process.ProcessId, process.ProcessName);
            ((Label)label).Text = "Lista procesów: " + dataGridView.Rows.Count;
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
                using (ITerminalServer server = new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(HostName))
                {
                    server.Open();
                    ITerminalServicesSession session = server.GetSession(selectedSessionID);
                    if (sender is ToolStripMenuItem)
                    {
                        switch (((ToolStripMenuItem)sender).Name)
                        {
                            case "menuItemSessionDisconnect":
                                {
                                    session.Disconnect();
                                    MessageBox.Show(new Form() { TopMost = true }, "Sesja została rozłączona", "Rozłączanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BtnRefresh_Click(sender, e);
                                    break;
                                }

                            case "menuItemSessionSendMessage":
                                {
                                    using (var terms = new ExplorerFormSendMessage(HostName, selectedSessionID))
                                    {
                                        terms.ShowDialog();
                                        MessageBox.Show("Wiadomość wysłano", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    break;
                                }

                            case "menuItemSessionRemoteControl":
                                {
                                    server.GetSession(selectedSessionID).StartRemoteControl(ConsoleKey.Multiply, RemoteControlHotkeyModifiers.Control);
                                    break;
                                }

                            case "menuItemSessionLogoff":
                                {
                                    session.Logoff();
                                    MessageBox.Show(new Form() { TopMost = true }, "Sesja została wylogowana", "Wylogowywanie sesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    BtnRefresh_Click(sender, e);
                                    break;
                                }

                            case "menuItemSessionStatus":
                                {
                                    DynaStatusTab(session, selectedSessionID);
                                    break;
                                }
                            case "menuItemSessionProcesses":
                                {
                                    DynaProcessTab(server, session, selectedSessionID);
                                    break;
                                }

                            case "menuItemProcessKill":
                                {
                                    var processId = Convert.ToInt16(((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Rows[selectedRowIndex].Cells[4].Value);
                                    var process = server.GetProcess(processId);
                                    var tabPage = ((TabPage)((DataGridView)((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl).Parent);
                                    var button = tabPage.Controls.Find("Refresh", true);
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
                            case "btnRefreshNow":
                                {
                                    RefreshProcesses(sender, server, session, selectedSessionID);
                                    break;
                                }
                            case "RefreshStatus":
                                {
                                    RefreshStatus(session, selectedSessionID);
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
                Size = new System.Drawing.Size(61, 4),
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
            dynaButton.Click += new EventHandler(CloseTabPage);

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

            //dynaStatusTabPage.Text += " (" + dynaDataGridView.Rows[0].Cells[1].Value.ToString() + ")";
            Button dynaButton = new Button
            {
                Location = new System.Drawing.Point(552, 597),
                Size = new System.Drawing.Size(76, 23),
                Text = "Zamknij",
                UseVisualStyleBackColor = true,
            };
            dynaButton.Click += new EventHandler(CloseTabPage);

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
            nazwaklientaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 120), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            kartasieciowaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 85), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };
            nazwauzytkownikaLabel = new Label { AutoSize = true, Location = new System.Drawing.Point(287, 50), Size = new System.Drawing.Size(66, 13), Text = "brak danych" };

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
            tabControl.Controls.Add(dynaStatusTabPage);
            tabControl.SelectedTab = dynaStatusTabPage;
        }

        
    }
}
