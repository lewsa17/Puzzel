﻿using System.ComponentModel;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Forms.External.QuickFix;
using System.Collections.Generic;
using Cassia;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeAdditionals();
            this.Text += " " + PuzzelLibrary.Version.GetVersion();
            UserLoggedVisibility();
            PuzzelLibrary.Settings.Values.LoadValues();
        }
        public static int ProgressBarValue = 0;
        public static int ProgressMax = 0;
        public readonly Stopwatch stopWatch = new Stopwatch();
        private static Thread progressBar;
        private string comboBoxCompLast;
        private string comboBoxLoginLast;
        delegate void ReplaceRichTextBoxEventHandler(string message);
        private delegate void Statusbp1TextEventHandler(string text);
        private delegate void Statusbp2TextEventHandler(string text);
        private delegate void updateComboBoxEventHandler(string message);
        private delegate void UpdateRichTextBoxEventHandler(string message);
        public static string ComputerInfo_TEMP { get; set; }
        public bool isAdminRole = false;
        private void UserLoggedVisibility()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                this.Text += " (Administrator)"; 
                isAdminRole = true;
            }
            else this.Text += " (" + principal.Identity.Name + ")";
        }
        public static void ReplaceRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
                richTextBox1.Invoke(new ReplaceRichTextBoxEventHandler(ReplaceRichTextBox), new object[] { message });
            else { richTextBox1.Text = message; }
        }
        public static void UpdateRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
                richTextBox1.Invoke(new UpdateRichTextBoxEventHandler(UpdateRichTextBox), new object[] { message });
            else { richTextBox1.AppendText(message); }
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        private bool isFileAvailable(string pathFileName)
        {
            if (File.Exists(pathFileName))
                return true;
            else
            {
                ReplaceRichTextBox("Nie można odnaleźć określonego pliku\n");
                UpdateRichTextBox(pathFileName);
            }
            return false;
        }
        private bool isHostAvailable(string HostName)
        {
            if (isNameValid(HostName))
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName) == System.Net.NetworkInformation.IPStatus.Success)
                    return true;
                else UpdateRichTextBox("Stacja: " + HostName + " nie jest widoczna na sieci");
            return false;
        }
        private bool isNameValid(string Name)
        {
            ReplaceRichTextBox(null);
            if (Name.Length > 2)
                return true;
            else UpdateRichTextBox("Za krótka nazwa");
            return false;
        }
        private bool isPortOpened(string HostName, int Port)
        {
            if (isNameValid(HostName))
                if (PuzzelLibrary.NetDiag.Ping.TCPPing(HostName, Port) == PuzzelLibrary.NetDiag.Ping.TCPPingStatus.Success)
                    return true;
                UpdateRichTextBox("Badanie " + HostName + " zakończone porażką. Port " + numericTCP.Value.ToString() + " prawdopoodobnie jest zamknięty.");
            return false;
        }
        private void ActivateOffice(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
                UpdateRichTextBox(PuzzelLibrary.QuickFix.ActivateOffice.Activate(HostName()));
        }
        private void ActiveSession(object sender, EventArgs e)
        {
            if(isNameValid(HostName()))
            UpdateRichTextBox(new PuzzelLibrary.Terminal.CompExplorer().ActiveSession(HostName()));
        }
        private void AdmTools(object sender, EventArgs e)
        {
            StartTime();
            string arguments = null;
            if (sender is ToolStripMenuItem)
            {
                if (((ToolStripMenuItem)sender) == menuItemLusrmgr)
                    arguments = "lusrmgr.msc";

                if (((ToolStripMenuItem)sender) == menuItemTaskshedule)
                    arguments = "taskschd.msc";

                if (((ToolStripMenuItem)sender) == menuItemServices)
                    arguments = "services.msc";

                if (((ToolStripMenuItem)sender) == menuItemEventViewer)
                    arguments = "eventvwr.msc";
                if (((ToolStripMenuItem)sender) == menuItemWindowsFirewall)
                {
                    var OSName = PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "Caption");
                    if (OSName.Contains("Windows 7"))
                        PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcessWithWaitingForExit("netsh", "-r " + HostName() + " firewall set service RemoteAdmin enable");
                    else { PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcessWithWaitingForExit("netsh", "-r " + HostName() + "set rule name = \"Windows Defender Firewall Remote Management (RPC)\" new enable= yes"); }
                    arguments = "wf.msc";
                }
            }
            if (sender is Button)
                if (((Button)sender) == btnManagement)
                    arguments = "compmgmt.msc";
            if (isHostAvailable(HostName()))
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mmc.exe", arguments + @" /computer:\\" + HostName());
            else
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mmc.exe", arguments);
            StopTime();
        }
        private void AppendStatusbp1text(string text)
        {
            if (statusBar1.InvokeRequired)
                statusBar1.Invoke(new Statusbp1TextEventHandler(AppendStatusbp1text), new object[] { text });
            else statusBP1.Text += text;
        }
        private void BtnCollapseTCP(object sender, EventArgs e)
        {
            if (panelTCP.Width == 351)
            {
                btnCollapseTCP.Text = "Rozwiń";
                panelTCP.Width = 63;
            }
            else
            {
                btnCollapseTCP.Text = "Zwiń";
                panelTCP.Width = 351;
            }
        }
        private void btnDW_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isNameValid(HostName()))
                try
                {
                    string FilePath = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "DWPath");
                    if (isFileAvailable(FilePath))
                    {
                        if (sender is Button)
                            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(FilePath, "-m:" + HostName() + " -x -a:1");
                        else
                        {
                            string login = null;
                            string pwd = null;
                            if (sender is ToolStripMenuItem)
                            {
                                if (((ToolStripMenuItem)sender).Name.Contains("LAPS"))
                                {
                                    login = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "LAPSLogin");
                                    pwd = PuzzelLibrary.LAPS.CompPWD.GetPWD(HostName());
                                }
                                else
                                {
                                    login = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ELogin");
                                    pwd = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ELoginPWD");
                                }
                                if (pwd.Length > 1)
                                    PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(FilePath, "-m:" + HostName() + " -x -a:2 -u:" + login + " -p:" + pwd + " -d:");
                                else MessageBox.Show("Brak hasła");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "btnDW_Click");
                }
            StopTime();
        }
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isHostAvailable(HostName()))
            {
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("explorer.exe", @"\\" + HostName() + @"\c$");
            }
            StopTime();
        }
        private void btnFlushDNS_Click(object sender, EventArgs e)
        {
            StartTime();
            ReplaceRichTextBox(null);
            StartWinSysApplication("ipconfig.exe", "/flushdns");
            StopTime();
        }
        private void btnLoginCompLog_Click(object sender, EventArgs e)
        {
            StartTime();
            comboBoxFindedSessions.Items.Clear();
            comboBoxFindedSessions.Text = "";
            string pole = string.Empty;
            int counter = 0;
            string rodzaj = string.Empty;
            if (sender == btnUserLog)
                if (isNameValid(UserName()))
                {
                    counter = (int)numericLogin.Value;
                    rodzaj = "User";
                    pole = UserName();
                    if (UserName() != comboBoxLoginLast)
                    {
                        comboBoxLoginLast = pole;
                        comboBoxLogin.Items.Add(comboBoxLoginLast);
                    }
                }
            if (sender == btnCompLog)
                if (isNameValid(HostName()))
                {
                    counter = (int)numericComputer.Value;
                    pole = HostName();
                    rodzaj = "Computer";
                    if (HostName() != comboBoxCompLast)
                    {
                        comboBoxCompLast = pole;
                        comboBoxComputer.Items.Add(comboBoxCompLast);
                    }
                }
            UpdateRichTextBox(new PuzzelLibrary.LogonData.Captcher().SearchLogs(counter, pole, rodzaj));
            statusBar1.Focus();
            StopTime();
        }
        private void btnPing_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isNameValid(HostName()))
            {
                StartWinSysApplication("ping.exe", "-n 2 " + HostName());
                StartWinSysApplication("nbtstat.exe", "-a " + HostName() + " -c");
            }
            StopTime();
        }
        private void btnRDP_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isHostAvailable(HostName()))
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mstsc.exe", "/v " + HostName());
            StopTime();
        }
        private void BtnTestTCP_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isPortOpened(HostName(), (int)numericTCP.Value))
                UpdateRichTextBox("Badanie " + HostName() + " zakończone sukcesem. Port " + numericTCP.Value.ToString() + " jest otwarty.");
            StopTime();
        }
        private void ChangePassword(object sender, EventArgs e)
        {
            if (isNameValid(UserName()))
                if (PuzzelLibrary.AD.User.Information.IsUserAvailable(UserName()))
                {
                    External.ChangePasswordForm zh = new External.ChangePasswordForm(UserName());
                    zh.Show();
                }
        }
        private void MenuItemCMD_Click(object sender, EventArgs e)
        {
            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("cmd", "/u");
        }
        private void CMDRemoteCustomAuth(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
            {
                Additional.RemoteShellCustomAuth customAuthForm = new Additional.RemoteShellCustomAuth();
                customAuthForm.ShowDialog();
                var applicationName = PuzzelLibrary.ProcessExecutable.ProcExec.PSexec(HostName());
                if (isFileAvailable(Directory.GetCurrentDirectory() + @"\" + applicationName))
                    PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(applicationName, @"\\" + HostName() + " -u " + customAuthForm.Login + "-p " + customAuthForm.Password + "  cmd");
            }
        }
        private void MenuItemCMDSYSTEM_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isHostAvailable(HostName()))
            {
                var applicationName = PuzzelLibrary.ProcessExecutable.ProcExec.PSexec(HostName());
                if (isFileAvailable(Directory.GetCurrentDirectory() + @"\" + applicationName))
                    PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(applicationName, @"\\" + HostName() + " -s  cmd");
            }
            StopTime();
        }

        class RDPValues
        {
            internal string serverName { get; set; }
            internal int sessionID { get; set; }
            internal void GetSIdServerNameFromCombo(ComboBox SessionServer)
            {
                var SIdServerName = SessionServer.Items[SessionServer.SelectedIndex].ToString().Split(' ');
                this.sessionID = Convert.ToInt16(SIdServerName[0]);
                this.serverName = SIdServerName[1];

            }
        }
        private void ConnectToSession(object sender, EventArgs e)
        {
            StartTime();
            if (isNameValid(comboBoxFindedSessions.Text))
            {
                string[] IDSessionServerName = null;
                try
                {
                    if (comboBoxFindedSessions.Items.Count > 0)
                    {
                        if (comboBoxFindedSessions.SelectedIndex >= 0)
                        {
                            var rdpValues = new RDPValues();
                            rdpValues.GetSIdServerNameFromCombo(comboBoxFindedSessions);
                            var ADCompResult = PuzzelLibrary.AD.Computer.Search.ByComputerName(rdpValues.serverName, "operatingSystemVersion");
                            var osVersionComplete = ADCompResult.GetDirectoryEntry().Properties["operatingSystemVersion"].Value.ToString().Split(" ");
                            double osVersion = Convert.ToDouble(osVersionComplete[0]);
                            if (osVersion > 6.1)
                            {
                                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mstsc.exe", "/v:" + rdpValues.serverName + " /shadow:" + rdpValues.sessionID + " /control /NoConsentPrompt");
                            }
                            else
                            {
                                PuzzelLibrary.Terminal.TerminalExplorer Term = new PuzzelLibrary.Terminal.TerminalExplorer();
                                Term.ConnectToSession(rdpValues.serverName, rdpValues.sessionID);
                            }
                        }
                        else ReplaceRichTextBox("Nie wybrano aktywnej sesji");
                    }
                    else ReplaceRichTextBox("Nie ma żadnej aktywnej sesji");
                }
                catch (ArgumentOutOfRangeException)
                {
                    ReplaceRichTextBox("Nie wybrano żadnego terminala lub nie znaleziono żadnej sesji\n");
                    MessageBox.Show("Nie wybrano żadnego terminala lub nie znalazł żadnej sesji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Win32Exception ex)
                {
                    PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, IDSessionServerName[1]);
                }
            }
            else ReplaceRichTextBox("Nie można się połączyć ponieważ nie została wybrana sesja");
            StopTime();
        }
        private void contextMenuItemCopy_Click(object sender, EventArgs e)
        {
            try
            {
                CloseClipboard();
                if (richTextBox1.Focused)
                    if (richTextBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(richTextBox1.SelectedText) && !string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                        Clipboard.SetText(richTextBox1.SelectedText.Trim(' '));

                if (comboBoxFindedSessions.Focused)
                    if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                        Clipboard.SetText(comboBoxFindedSessions.SelectedText.Trim(' '));

                if (comboBoxLogin.Focused)
                    if (comboBoxLogin.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxLogin.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxLogin.SelectedText))
                        Clipboard.SetText(comboBoxLogin.SelectedText.Trim(' '));

                if (comboBoxComputer.Focused)
                    if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                        Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "contextMenuItemCopy_Click");
            }
        }
        private void contextMenuItemCut_Click(object sender, EventArgs e)
        {
            try
            {
                CloseClipboard();
                if (richTextBox1.Focused)
                    if (richTextBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(richTextBox1.SelectedText) && !string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                    {
                        richTextBox1.Cut();
                        Clipboard.SetText(Clipboard.GetText().Trim(' '));
                    }

                if (comboBoxFindedSessions.Focused)
                    if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                    {
                        Clipboard.SetText(comboBoxFindedSessions.SelectedText);
                        comboBoxFindedSessions.Text = comboBoxFindedSessions.Text.Remove(comboBoxFindedSessions.SelectionStart, comboBoxFindedSessions.SelectionLength);
                        Clipboard.SetText(Clipboard.GetText().Trim(' '));
                    }
                if (comboBoxLogin.Focused)
                    if (comboBoxLogin.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxLogin.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxLogin.SelectedText))
                    {
                        Clipboard.SetText(comboBoxLogin.SelectedText.Trim(' '));
                        comboBoxLogin.Text = comboBoxLogin.Text.Remove(comboBoxLogin.SelectionStart, comboBoxLogin.SelectionLength);
                    }
                if (comboBoxComputer.Focused)
                    if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                    {
                        Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
                        comboBoxComputer.Text = comboBoxComputer.Text.Remove(comboBoxComputer.SelectionStart, comboBoxComputer.SelectionLength);
                    }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "contextMenuItemCut_Click");
            }
        }
        private void contextMenuItemPaste_Click(object sender, EventArgs e)
        {
            try
            {
                CloseClipboard();
                if (richTextBox1.Focused)
                    richTextBox1.Paste();

                if (comboBoxFindedSessions.Focused)
                    comboBoxFindedSessions.Text = Clipboard.GetText(TextDataFormat.UnicodeText);

                if (comboBoxLogin.Focused)
                    comboBoxLogin.Text = Clipboard.GetText(TextDataFormat.UnicodeText);

                if (comboBoxComputer.Focused)
                    comboBoxComputer.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "contextMenuItemPaste_Click");
            }
        }
        private void contextMenuItemSearch_Click(object sender, EventArgs e)
        {
            WyszukiwanieDanych();
        }
        private void contextMenuItemSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Focused)
                    richTextBox1.SelectAll();

                if (comboBoxFindedSessions.Focused)
                    comboBoxFindedSessions.SelectAll();

                if (comboBoxLogin.Focused)
                    comboBoxLogin.SelectAll();

                if (comboBoxComputer.Focused)
                    comboBoxComputer.SelectAll();
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "contextMenuItemSelectAll_Click");
            }
        }
        private void DeleteUsers_Click(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
            {
                using (DeleteUsers deleteUsers = new DeleteUsers(HostName()))
                {
                    deleteUsers.ShowDialog();
                }
            }
        }
        private void DHCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTime();
            if (isFileAvailable(Directory.GetCurrentDirectory() + @"\dhcp.msc"))
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mmc.exe", "dhcp.msc");
            StopTime();
        }        private void EnableIEHosting_Click(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
                PuzzelLibrary.QuickFix.IEHosting.EnableCompatibilityFramework4inIE(HostName());
        }
        private void FindSessionBtn_Click(object sender, EventArgs e)
        {
            comboBoxFindedSessions.Items.Clear();
            Task th = new Task(() =>
            {
                try
                {
                    StartTime();
                    if (isNameValid(UserName()))
                    {
                        string data = string.Empty;
                        if (new PuzzelLibrary.AD.User.SearchInformation.Search().ByUserName(UserName()) != null)
                        {
                            var termServers = PuzzelLibrary.Terminal.TerminalExplorer.GetTerminalServers.Split(",");
                            foreach (string server in termServers)
                            {
                                Thread thread = new Thread(() =>
                                {
                                    PuzzelLibrary.Terminal.TerminalExplorer TE = new PuzzelLibrary.Terminal.TerminalExplorer();
                                    var task = Task<string>.Run(() => { return TE.ActiveSession(server, UserName()); });
                                    UpdateRichTextBox(task.Result);
                                    task.ContinueWith(antecedent =>
                                    {
                                        var sessions = Task<ITerminalServicesSession>.Run(() => { return TE.SessionIDServer; });
                                        sessions.ContinueWith(antecedent =>
                                        {
                                            comboBoxFindedSessions.Invoke(new MethodInvoker(() =>
                                    {
                                        if (antecedent.Result != null)
                                            comboBoxFindedSessions.Items.Add(antecedent.Result.SessionId + " " + antecedent.Result.Server.ServerName);
                                    }));
                                        }, TaskContinuationOptions.OnlyOnRanToCompletion);
                                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                                });
                                thread.Start();
                            }
                        }
                        else ReplaceRichTextBox("Nie znaleziono użytkownika w AD");
                    }
                }
                finally
                {
                    Thread.Sleep(8000);
                        comboBoxFindedSessions.Invoke(new MethodInvoker(() =>
                        {
                            if (comboBoxFindedSessions.Items.Count > 0)
                                comboBoxFindedSessions.SelectedIndex = 0;
                        }));
                        StopTime();
                }
            });
            th.Start();
        }
    
        private void FindSessions(object sender, EventArgs e)
        {
            string _HostName = string.Empty;
            if (sender is ToolStripMenuItem)
                if (((ToolStripMenuItem)sender).Text == "Ręczna nazwa")
                {
                    External.Explorer.ExplorerFormCustomSearch CustomTermsNameForms = new External.Explorer.ExplorerFormCustomSearch();
                    CustomTermsNameForms.ShowDialog();
                    _HostName = CustomTermsNameForms.TerminalName;
                }
                else if (sender == menuItemSessions)
                    if (HostName() == string.Empty || HostName().Length == 0)
                    {
                        _HostName = "localhost";
                    }
                    else _HostName = HostName();
                else _HostName = ((ToolStripMenuItem)sender).Text;

                Thread thread;
            External.Explorer.ExplorerForm explorer = new External.Explorer.ExplorerForm(_HostName);
            explorer.HostName = _HostName;
            thread = new Thread(() => explorer.GetSessionsToDataGridView());
            thread.Start();
            explorer.Show();
        }
        private string HostName()
        {
            string _HostName = null;
            if (comboBoxComputer.InvokeRequired)
                comboBoxComputer.Invoke(new MethodInvoker(() => _HostName = comboBoxComputer.Text.ToUpper()));
            else _HostName = comboBoxComputer.Text.ToUpper();
            return _HostName;
        }
        private void Info_z_AD_Click(object sender, EventArgs e)
        {
            StartTime();
            if (InfozAD.IsBusy != true)
                InfozAD.RunWorkerAsync();
            StopTime();
        }
        private void InfozAD_DoWork(object sender, DoWorkEventArgs e)
        {
            StartTime();
            if (isNameValid(UserName()))
            {
                if (PuzzelLibrary.AD.User.Information.IsUserAvailable(UserName()))
                {
                    var user = new PuzzelLibrary.AD.User.Information(UserName());
                    //1 linijka
                    TimeSpan temp = (user.pwdLastSet.AddDays(30) - DateTime.Now);
                    if (temp > (DateTime.Now.AddDays(2) - DateTime.Now))
                        UpdateRichTextBox(temp.ToString("'Hasło wygasa za: 'dd' dni 'hh'g'mm'm'ss's'") + "\n");
                    else if (temp < (DateTime.Now.AddDays(1) - DateTime.Now))
                        UpdateRichTextBox(temp.ToString("'Hasło wygasa za: 'dd' dzień 'hh'g'mm'm'ss's'") + "\n");
                    //2 linijka
                    UpdateRichTextBox("\n");
                    //3 linijka
                    UpdateRichTextBox("---------------------------------" + "\n");
                    //4 linijka
                    UpdateRichTextBox("Nazwa użytkownika:\t\t\t" + user.loginName + "\n");
                    //5 linijka
                    UpdateRichTextBox("Pełna nazwa:\t\t\t\t" + user.displayName + "\n");
                    //6 linijka
                    UpdateRichTextBox("Komentarz:\t\t\t\t\t" + user.title + "\n");
                    //7 linijka
                    UpdateRichTextBox("Firma zatrudniająca:\t\t\t" + user.company + "\n");
                    //8 linijka
                    UpdateRichTextBox("Mail:\t\t\t\t\t\t" + user.mail + "\n");
                    //9 linijka
                    UpdateRichTextBox("Adres logowania Skype: \t\t\t" + user.SkypeLogin.Replace("sip:", "") + "\n");
                    //10 linijka
                    UpdateRichTextBox("Konto jest aktywne:\t\t\t" + user.userEnabled + "\n");
                    //11 linijka
                    UpdateRichTextBox("\n");
                    //12 linijka
                    UpdateRichTextBox("Konto wygasa:\t\t\t\t" + user.accountExpires + "\n");  //działa ale jest zła strefa czasowa
                                                                                              //13 linijka\
                    if (user.pwdLastSet < user.lockoutTime)
                        UpdateRichTextBox("Konto zablokowane:\t\t\t" + user.lockoutTime + "\n");
                    else UpdateRichTextBox("Konto zablokowane:\t\t\t" + "0" + "\n");
                    //14 linijka
                    if (user.lastBadPwdAttempt.Year != 1)
                        UpdateRichTextBox("Ostatnie błędne logowanie:\t\t" + user.lastBadPwdAttempt + "\n"); //działa ale potrzebna jest deklaracja serwera
                    else UpdateRichTextBox("Ostatnie błędne logowanie:\t\t" + 0 + "\n");
                    //15 linijka
                    UpdateRichTextBox("Ilość błędnych prób logowania:\t" + user.badPwdCount + "\n"); //działa serwerów są 4
                                                                                                     //16 linijka                                                                            
                    UpdateRichTextBox("Dostęp do internetu:\t\t\t" + user.InternetAccessEnabled + "\n");
                    //17 linijka
                    UpdateRichTextBox("Hasło ostatnio ustawiono:\t\t" + user.pwdLastSet + "\n");
                    //18 linijka
                    UpdateRichTextBox("Hasło wygasa:\t\t\t\t" + user.pwdLastSet.AddDays(30) + "\n");
                    //19 linijka
                    UpdateRichTextBox("Hasło może być zmienione:\t\t" + user.pwdLastSet.AddDays(1) + "\n");
                    //20 linijka
                    UpdateRichTextBox("\n");
                    //21 linijka
                    UpdateRichTextBox("Ostatnie logowanie:\t\t\t" + user.lastLogon + "\n");
                    //22 linijka
                    if (user.lastLogoff > user.lastLogon)
                        UpdateRichTextBox("Ostatnie wylogowanie:\t\t\t\t" + user.lastLogoff + "\n");
                    else UpdateRichTextBox("Ostatnie wylogowanie:\t\t\t" + "0" + "\n");
                    //23 linijka
                    UpdateRichTextBox("\n");
                    //24 linijka
                    UpdateRichTextBox("Czy hasło jest wymagane? \t\t" + user.passwordNotRequired + "\n");
                    //25 linijka
                    UpdateRichTextBox("Użytkownik nie może zmienić hasła \t" + user.userCannotChangePassword + "\n");
                    //26 linijka
                    UpdateRichTextBox(/*Allowed_workstions() */"Dozwolone stacje robocze:\t\t" + user.permittedWorkstation + "\n");
                    //27 linijka
                    UpdateRichTextBox("Skrypt logowania:\t\t\t\t" + user.scriptPath + "\n");
                    //28 linijka
                    UpdateRichTextBox("Katalog macierzysty:\t\t\t" + user.homeDirectory + "\n");
                    //29 linijka
                    UpdateRichTextBox("Dysk macierzysty:\t\t\t\t" + user.homeDrive + "\n");
                    //30 linijka
                    UpdateRichTextBox("\n");
                    //31 linijka
                    //UpdateRichTextBox(/*Allowed_Hours()*/ permittedLogonTime.ToString());
                    UpdateRichTextBox("\n");
                    //32 linijka
                    UpdateRichTextBox(/*MembersOf()*/"Członkostwa grup:\t\t\t\t" + user.Groups);
                }
                else UpdateRichTextBox("Nie znaleziono użytkownika w AD");
            }
            StopTime();
        }
        private void InitializeAdditionals()
        {
            var termservers = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "Terminals").Split(",");
            List<string> terms = new List<string>();
            terms.AddRange(termservers);
            terms.Sort();
            foreach (string t in terms)
            {
                TerminalUniversalToolStripMenuItem = new ToolStripMenuItem() { Name = t, Text = t };
                TerminalUniversalToolStripMenuItem.Click += new EventHandler(FindSessions);
                if (menuItemTermimalExplorer.DropDownItems[menuItemTermimalExplorer.DropDownItems.Count - 1].Name.Contains(t.Remove(t.Length - 1)))
                    menuItemTermimalExplorer.DropDownItems.Add(TerminalUniversalToolStripMenuItem);
                else menuItemTermimalExplorer.DropDownItems.AddRange(new ToolStripItem[]{ new ToolStripSeparator(), TerminalUniversalToolStripMenuItem });
            }
            string dw = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "DW");
            string eadm = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ELogin");
            string lapslogn = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "LAPSLogin");
            this.btnDW.Text = dw;
            this.DWMenuContext.Text = dw;
            this.menuItemDWEadm.Text = dw + "(" + eadm + ")";
            this.menuItemDWLAPS.Text = dw + "(" + lapslogn + ")";
        }
        private void Keys_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ComboBox || sender is NumericUpDown)
                if (e.KeyCode == Keys.Enter)
                {
                    if (sender == comboBoxLogin  || sender == numericLogin)
                        btnLoginCompLog_Click(btnUserLog, e);

                    if (sender == comboBoxComputer || sender == numericComputer)
                        btnLoginCompLog_Click(btnCompLog, e);
                }
            if (sender is RichTextBox)
            {
                if (e.Control && e.KeyCode == Keys.F)
                    SearchData();

                //if (e.Control && e.KeyCode == Keys.Z)
                //    richTextBox1.Undo();

                //if (e.Control && e.KeyCode == Keys.Y)
                //    richTextBox1.Redo(); 
            }
        }
        private void Keys_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                CloseClipboard();

                if (e.Control && e.KeyCode == Keys.C)
                {
                    Clipboard.Clear();
                    if (richTextBox1.Focused)
                        if (richTextBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(richTextBox1.SelectedText) && !string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                            Clipboard.SetText(richTextBox1.SelectedText.Trim(' '));

                    if (comboBoxFindedSessions.Focused)
                        if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                        {
                            comboBoxFindedSessions.Text = comboBoxFindedSessions.Text.Trim(' ');
                            comboBoxFindedSessions.SelectAll();
                            Clipboard.SetText(comboBoxFindedSessions.SelectedText.Trim());
                        }
                    if (comboBoxLogin.Focused)
                        if (comboBoxLogin.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxLogin.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxLogin.SelectedText))
                        {
                            comboBoxLogin.Text = comboBoxLogin.Text.Trim(' ');
                            comboBoxLogin.SelectAll();
                            Clipboard.SetText(comboBoxLogin.SelectedText.Trim(' '));
                        }
                    if (comboBoxComputer.Focused)
                        if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                        {
                            comboBoxComputer.Text = comboBoxComputer.Text.Trim(' ');
                            comboBoxLogin.SelectAll();
                            Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
                        }
                }

                if (e.Control && e.KeyCode == Keys.V)
                {
                    if (richTextBox1.Focused)
                        richTextBox1.Paste();

                    if (comboBoxFindedSessions.Focused)
                        Clipboard.GetDataObject();
                    
                    if (comboBoxLogin.Focused)
                        Clipboard.GetDataObject();
                    
                    if (comboBoxComputer.Focused)
                        Clipboard.GetDataObject();
                }

                if (e.Control && e.KeyCode == Keys.X)
                {
                    Clipboard.Clear();
                    if (richTextBox1.Focused)
                        if (richTextBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(richTextBox1.SelectedText) && !string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                        {
                            richTextBox1.Cut();
                            Clipboard.SetText(Clipboard.GetText().Trim(' '));
                        }
                    if (comboBoxFindedSessions.Focused)
                        if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                        {
                            Clipboard.SetText(comboBoxFindedSessions.SelectedText);
                            comboBoxFindedSessions.Text.Remove(comboBoxFindedSessions.SelectionStart, comboBoxFindedSessions.SelectionLength);
                        }
                    if (comboBoxLogin.Focused)
                        if (comboBoxLogin.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxLogin.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxLogin.SelectedText))
                        {
                            comboBoxLogin.Text = comboBoxLogin.Text.Trim(' ');
                            comboBoxLogin.SelectAll();
                            Clipboard.SetText(comboBoxLogin.SelectedText.Trim(' '));
                            comboBoxLogin.Text.Remove(comboBoxLogin.SelectionStart, comboBoxLogin.SelectionLength);
                        }
                    if (comboBoxComputer.Focused)
                        if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                        {
                            comboBoxComputer.Text = comboBoxComputer.Text.Trim(' ');
                            comboBoxComputer.SelectAll();
                            Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
                            comboBoxComputer.Text.Remove(comboBoxComputer.SelectionStart, comboBoxComputer.SelectionLength);
                        }
                }
                if (e.Control && e.KeyCode == Keys.A)
                {
                    if (richTextBox1.Focused)
                        richTextBox1.SelectAll();

                    if (comboBoxFindedSessions.Focused)
                        comboBoxFindedSessions.SelectAll();

                    if (comboBoxLogin.Focused)
                        comboBoxLogin.SelectAll();

                    if (comboBoxComputer.Focused)
                        comboBoxComputer.SelectAll();
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, sender + " " + e.KeyCode);
            }
        }
        private void KomputerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Start();
        }
        private void KomputerInfoCOMM()
        {
            StartTime();
            ReplaceRichTextBox(PuzzelLibrary.WMI.ComputerInfo.AllComputerInfo(HostName()));
            StopTime();
        }
        private void KomputerInfoMenuStrip(object sender, EventArgs e)
        {
            StartTime();
            if (isHostAvailable(HostName()))
                if (isPortOpened(HostName(), 135))
                {
                    UpdateRichTextBox("Nazwa komputera: ");
                    UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryComputerSystem, "DNSHostName"));
                    UpdateRichTextBox("----------------------------------------\n");
                    if (sender is ToolStripMenuItem)
                    {
                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoUptime)
                        {
                            UpdateRichTextBox("Uptime: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "LastBootUpTime"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoSNPN)
                        {
                            UpdateRichTextBox("SN: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryComputerSystemProduct, "IdentifyingNumber"));
                            UpdateRichTextBox("PN: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathWMI, PuzzelLibrary.WMI.ComputerInfo.querySystemInformation, "SystemSKU"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoModel)
                        {
                            UpdateRichTextBox("MODEL: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryComputerSystem, "Model"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoOS)
                        {
                            UpdateRichTextBox("OS: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoRAM)
                        {
                            UpdateRichTextBox("Pamięć TOTAL: \n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryPhysicalMemory, "Capacity"));
                            UpdateRichTextBox("\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoProcessor)
                        {
                            UpdateRichTextBox("CPU \n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProcessor, "Name"));
                            UpdateRichTextBox("Rdzenie: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProcessor, "NumberOfCores"));
                            UpdateRichTextBox("Wątki: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProcessor, "NumberOfLogicalProcessors"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoLoggedUser)
                        {
                            ActiveSession(sender, e);
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoProfile)
                        {
                            UpdateRichTextBox("Profile\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryDesktop, "Name"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoDrives)
                        {
                            UpdateRichTextBox("Dyski: \n");
                            UpdateRichTextBox(ComputerInfo_TEMP += ("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n"));
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoPrinters)
                        {
                            UpdateRichTextBox("Drukarki sieciowe\n\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryPrinterConfiguration, "DeviceName"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoShares)
                        {
                            UpdateRichTextBox("Udziały\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryShare, "Name", "Path", "Description"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoAutostart)
                        {
                            UpdateRichTextBox("AutoStart\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryStartupCommand, "Caption", "Command"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoPath)
                        {
                            UpdateRichTextBox("Środowisko uruchomieniowe\n");
                            UpdateRichTextBox("Nazwa zmiennej           Wartość zmiennej\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryEnvironment, "Name", "VariableValue"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoNetworkRes)
                        {
                            UpdateRichTextBox("Zasoby sieciowe\n\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryNetworkConnection, "LocalName", "RemoteName"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoDisplay)
                        {
                            UpdateRichTextBox("Podłączone ekrany\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status"));
                        }

                        if (((ToolStripMenuItem)sender) == menuItemComputerInfoBios)
                        {
                            UpdateRichTextBox("BIOS\n\n");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryBios, "Manufacturer", "BIOSVersion", "SMBIOSBIOSVersion", "ReleaseDate"));
                        }
                    }
                    if (sender is Button)
                    {
                        if (((Button)sender) == btnNetworkInterfaces)
                        {
                            UpdateRichTextBox("Karty Sieciowe: ");
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryNetworkAdapterConfiguration, "IPEnabled", "Description", "DNSDomainSuffixSearchOrder", "DNSHostName", "IPAddress", "IPSubnet", "MACAddress"));
                        }

                        if (((Button)sender) == btnProgramList)
                            UpdateRichTextBox(PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProduct));

                        if (((Button)sender) == btnCompInfo)
                            KomputerInfoMethod();
                    }
                }
            StopTime();
        }
        private void KomputerInfoMethod()
        {
            using (Form owner = new Form() { TopMost = true })
                if (MessageBox.Show(owner, "Wyszukiwanie może chwile potrwać, zezwolić ?", "Wyszukiwanie danych", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (!backgroundWorkerComputerInfo.IsBusy)
                    {
                        ReplaceRichTextBox(null);
                        Additional.Progress loadingForm = new Additional.Progress(19);
                        Thread progress;
                        progress = new Thread(loadingForm.progress);
                        progress.Start();
                        progressBar = new Thread(KomputerInfoCOMM);
                        backgroundWorkerComputerInfo.RunWorkerAsync();
                    }
        }
        private void LogoffSession(object sender, EventArgs e)
        {
            StartTime();
            if (isNameValid(comboBoxFindedSessions.Text))
            {
                string[] IDSessionServerName = null;
                try
                {
                    if (comboBoxFindedSessions.Items.Count > 0)
                        if (comboBoxFindedSessions.SelectedIndex >= 0)
                        {
                            IDSessionServerName = comboBoxFindedSessions.Items[comboBoxFindedSessions.SelectedIndex].ToString().Split(' ');
                            PuzzelLibrary.Terminal.Explorer.LogOffSession(new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(IDSessionServerName[1]), Convert.ToInt16(IDSessionServerName[0]));

                        }
                        else ReplaceRichTextBox("Nie wybrano aktywnej sesji");
                    else ReplaceRichTextBox("Nie ma żadnej aktywnej sesji");
                }
                catch (ArgumentOutOfRangeException)
                {
                    ReplaceRichTextBox("Nie wybrano żadnego terminala lub nie znalazł żadnej sesji\n");
                    MessageBox.Show("Nie wybrano żadnego terminala lub nie znalazł żadnej sesji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Win32Exception ex)
                {
                    PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, IDSessionServerName[1]);
                }
            }
            StopTime();
        }
        private void menuItemLockoutStatus_Click(object sender, EventArgs e)
        {
            if (isNameValid(UserName())) 
            {
                External.LockoutStatus LS = new External.LockoutStatus(UserName());
                if (PuzzelLibrary.AD.User.Information.IsUserAvailable(UserName()))
                {
                    LS.AddEntry();
                    LS.Show();
                }
                else
                    LS.Show();
            }
            else MessageBox.Show("Brak użytkownika w AD");
        }
        private void menuItemRDPOpen_Click(object sender, EventArgs e)
        {
            StartTime();
            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mstsc.exe", "");
            StopTime();
        }
        private void RemotePowerShell_Click(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("powershell", "-noexit Enter-PSSession -ComputerName " + HostName());
        }
        private void RemotePowerShellCustomAuth_Click(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
            {
                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("powershell", "-noexit Enter-PSSession -ComputerName " + HostName() + " -Credential DOMENA\\login");
            }
        }
        private void Profilsieciowy(object sender, EventArgs e)
        {
            StartTime();
            if (isNameValid(UserName()))
            {
                string folder = null;
                if (((Button)sender) == btnProfilVFS)
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "VFS");

                if (((Button)sender) == btnProfilERI)
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ERI");

                if (((Button)sender) == btnProfilTS)
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "NET");

                if (((Button)sender) == btnProfilEXT)
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "EXT");
                if (!string.IsNullOrEmpty(folder))
                    if (Directory.Exists(Path.Combine(folder, UserName())))
                        PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("explorer.exe", folder + UserName());
                    else MessageBox.Show("Brak dostępu do zasobu");
            }
            StopTime();
        }
        private void pwdLAPS(object sender, EventArgs e)
        {
            if (isNameValid(HostName()))
            {
                External.LAPSui lAPSui = new External.LAPSui();
                lAPSui.HostName = HostName();
                lAPSui.LoadPassword();
                lAPSui.Show();
            }
        }
        private void RemoteCMD_Click(object sender, EventArgs e)
        {
            StartTime();
            try
            {
                if (isHostAvailable(HostName()))
                {
                    var OSName = PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "osarchitecture");
                    string applicationName = null;
                    if (OSName.Contains("64-bit"))
                        applicationName = "PsExec64.exe";
                    else applicationName = "PsExec.exe";

                    if (isFileAvailable(Directory.GetCurrentDirectory() + @"\" + applicationName))
                        PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(applicationName, @"\\" + HostName() + " -user " + System.Environment.UserDomainName + @"\" + System.Environment.UserName + " cmd");
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, HostName() + "," + PuzzelLibrary.WMI.ComputerInfo.pathCIMv2 + "," + PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem);
            }
            StopTime();
        }
        private void RemotePingTracert(object sender, EventArgs e)
        {
            using (Additional.RemotePingTracert PingTracert = new Additional.RemotePingTracert())
            {
                PingTracert.ShowDialog();
                if (sender == btnRemotePing)
                {
                    PuzzelLibrary.NetDiag.RemotePing ping = new PuzzelLibrary.NetDiag.RemotePing(HostName());
                    UpdateRichTextBox(ping.StartRemotePing(PingTracert.GetHost, PingTracert.GetCounter));
                }
                else
                {
                    PuzzelLibrary.NetDiag.RemoteTracert tracert = new PuzzelLibrary.NetDiag.RemoteTracert(HostName());
                    UpdateRichTextBox(tracert.StartRemoteTracert(PingTracert.GetHost));
                }
            }
        }
        private void SearchData()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.HideSelection = false;
            Additional.SearchingMainForm wyszukiwarka = new Additional.SearchingMainForm();
            wyszukiwarka.Show();
        }
        private void StartTime()
        {
            stopWatch.Start();
            UpdateStatusbp2text("Obliczam");
            UpdateStatusbp1text("Czekaj");
        }
        private void StartWinSysApplication(string FileName, string Arguments)
        {
            UpdateRichTextBox(PuzzelLibrary.ProcessExecutable.ProcExec.StartExtendedProcess(FileName, Arguments));
        }
        private void StopTime()
        {
            stopWatch.Stop();
            UpdateStatusbp1text("Gotowe");
            UpdateStatusbp2text("Czas: " + stopWatch.Elapsed.Seconds + "s " + stopWatch.Elapsed.Milliseconds + "ms ");
            stopWatch.Reset();
        }
        private void UpdateComboBox(string message)
        {
            if (comboBoxFindedSessions.InvokeRequired)
                comboBoxFindedSessions.Invoke(new updateComboBoxEventHandler(UpdateComboBox), new object[] { message });
            else comboBoxFindedSessions.Items.Add(message);
        }
        private void UpdateStatusbp1text(string text)
        {
            if (statusBar1.InvokeRequired)
                statusBar1.Invoke(new Statusbp1TextEventHandler(UpdateStatusbp1text), new object[] { text });
            else statusBP1.Text = text;
        }
        private void UpdateStatusbp2text(string text)
        {
            if (statusBar1.InvokeRequired)
                statusBar1.Invoke(new Statusbp1TextEventHandler(UpdateStatusbp2text), new object[] { text });
            else statusBP2.Text = text;
        }
        private string UserName()
        {
            string _UserName = null;
            if (comboBoxLogin.InvokeRequired)
                comboBoxLogin.Invoke(new MethodInvoker(() => _UserName = comboBoxLogin.Text));
            else _UserName = comboBoxLogin.Text;
            return _UserName;
        }        private void WinEnvironment_Click(object sender, EventArgs e)
        {
            if (isHostAvailable(HostName()))
                using (EnvironmentVariable env = new EnvironmentVariable(HostName()))
                    env.ShowDialog();
        }
        private void WyszukiwanieDanych()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.HideSelection = false;
            Additional.SearchingMainForm wyszukiwarka = new Additional.SearchingMainForm();
            wyszukiwarka.Show();
        }
        private void Powershell_Click(object sender, EventArgs e)
        {
            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("powershell", "-noexit");
        }
    }
}
