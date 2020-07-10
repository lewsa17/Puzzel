using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Management;
using System.Threading;
using System.Runtime.InteropServices;
using Forms.External.QuickFix;
using System.Management.Automation;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeNames();
            this.Text += " " + PuzzelLibrary.Version.GetVersion();
        }
        private static Thread progressBar;
        public static int ProgressMax = 0;
        public static int ProgressBarValue = 0;
        private delegate void UpdateRichTextBoxEventHandler(string message);
        public static void UpdateRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new UpdateRichTextBoxEventHandler(UpdateRichTextBox), new object[] { message });
            }
            else { richTextBox1.AppendText(message); }
        }

        private delegate void Statusbp1TextEventHandler(string text);

        private void UpdateStatusbp1text(string text)
        {
            if (statusBar1.InvokeRequired)
            {
                statusBar1.Invoke(new Statusbp1TextEventHandler(UpdateStatusbp1text), new object[] { text });
            }
            else statusBP1.Text = text;
        }

        private void AppendStatusbp1text(string text)
        {
            if (statusBar1.InvokeRequired)
            {
                statusBar1.Invoke(new Statusbp1TextEventHandler(AppendStatusbp1text), new object[] { text });
            }
            else statusBP1.Text += text;
        }

        private delegate void Statusbp2TextEventHandler(string text);
        private void UpdateStatusbp2text(string text)
        {
            if (statusBar1.InvokeRequired)
            {
                statusBar1.Invoke(new Statusbp1TextEventHandler(UpdateStatusbp2text), new object[] { text });
            }
            else statusBP2.Text = text;
        }

        private delegate void ReplaceRichTextBoxEventHandler(string message);
        public static void ReplaceRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new ReplaceRichTextBoxEventHandler(ReplaceRichTextBox), new object[] { message });
            }
            else { richTextBox1.Text = message; }
        }

        private void btnRDP_Click(object sender, EventArgs e)
        {
            StartTime();
            if (HostName().Length > 0)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mstsc.exe", "/v " + HostName());
                }
                else ReplaceRichTextBox("Niewidoczny na sieci");
            }
            else ReplaceRichTextBox("Nie podano nazwy hosta");
            StopTime();
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox(); if (HostName().Length > 0)
            {
                StartWinSysApplication("ping.exe", "-n 2 " + HostName());
                StartWinSysApplication("nbtstat.exe", "-a " + HostName() + " -c");
            }
            else ReplaceRichTextBox("Nie podano nazwy hosta");
            StopTime();
        }
        private void StartWinSysApplication(string FileName, string Arguments)
        {
            UpdateRichTextBox(PuzzelLibrary.ProcessExecutable.ProcExec.StartExtendedProcess(FileName, Arguments));
        }
        private void Profilsieciowy(object sender, EventArgs e)
        {
            StartTime();
            if (UserName().Length > 1)
            {
                string folder = null;
                if (((Button)sender).Name == "btnProfil_VFS")
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "VFS");

                if (((Button)sender).Name == "btnProfil_ERI")
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ERI");

                if (((Button)sender).Name == "btnProfil_TS")
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "NET");

                if (((Button)sender).Name == "btnProfil_EXT")
                    folder = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "EXT");
                if (!string.IsNullOrEmpty(folder))
                    if (Directory.Exists(Path.Combine(folder, UserName())))
                        PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("explorer.exe", folder + UserName());
                    else ReplaceRichTextBox("Katalog jest niedostępny");
            }
            else ReplaceRichTextBox("Nie podano nazwy użytkownika");
            StopTime();
        }

        private void btnExplorer_Click(object sender, EventArgs e)
        {
            StartTime();
            if (HostName().Length > 0)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("explorer.exe", @"\\" + HostName() + @"\c$");
                }
                else ReplaceRichTextBox("Nie odpowiada w sieci");
            }
            else ReplaceRichTextBox("Nie podano nazwy hosta");
            StopTime();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.MaximumSize = new System.Drawing.Size(Width - 19, Height - 302);
                richTextBox1.MinimumSize = new System.Drawing.Size(Width - 19, Height - 302);
                richTextBox1.ClientSize = new System.Drawing.Size(Width - 19, Height - 302);
                groupBoxUserInfo.Width = Width - 19;
                groupBoxComputerInfo.Width = Width - 19;
                groupBoxOtherTools.Width = Width - 19;
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, WindowState.ToString());
            }
        }

        private void ConnectToSession(object sender, EventArgs e)
        {
            StartTime();
            if (comboBoxFindedSessions.Text.Length > 1)
            {
                string[] IDSessionServerName = null;
                try
                {
                    if (comboBoxFindedSessions.Items.Count > 0)
                    {
                        if (comboBoxFindedSessions.SelectedIndex >= 0)
                        {
                            IDSessionServerName = comboBoxFindedSessions.Items[comboBoxFindedSessions.SelectedIndex].ToString().Split(' ');
                            PuzzelLibrary.Terminal.TerminalExplorer Term = new PuzzelLibrary.Terminal.TerminalExplorer();
                            Term.ConnectToSession(IDSessionServerName[1], Convert.ToInt16(IDSessionServerName[0]));
                        }
                        else ReplaceRichTextBox("Nie wybrano aktywnej sesji");
                    }
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
            else ReplaceRichTextBox("Nie można się połączyć ponieważ nie została wybrana sesja");
            StopTime();
        }
        private static void ClearRichTextBox(/*string sign*/)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new MethodInvoker(() => { richTextBox1.Clear(); }));
            }
            else richTextBox1.Clear();
        }
        private string comboBoxLoginLast;
        private string comboBoxCompLast;
        private void btnLoginCompLog_Click(object sender, EventArgs e)
        {
            StartTime();
            ReplaceRichTextBox(null);
            comboBoxFindedSessions.Items.Clear();
            comboBoxFindedSessions.Text = "";
            if (sender == btnUserLog)
            {
                SearchLogs(btnUserLog, e, numericLogin.Value, UserName(), "User");
            }
            if (sender == btnCompLog)
            {
                SearchLogs(btnCompLog, e, numericComputer.Value, HostName(), "Computer");
            }
            statusBar1.Focus();
            StopTime();
        }

        private void SearchLogs(object sender, EventArgs e, decimal counter, string pole, string rodzaj)
        {
            int NameLength = pole.Length;

            if (NameLength > 1)
            {
                if (sender == btnUserLog)
                    if (pole.Length > 0)
                        if (pole != comboBoxLoginLast)
                        {
                            comboBoxLoginLast = pole;
                            comboBoxLogin.Items.Add(comboBoxLoginLast);
                        }
                if (sender == btnCompLog)
                    if (pole.Length > 0)
                        if (pole != comboBoxCompLast)
                        {
                            comboBoxCompLast = pole;
                            comboBoxComputer.Items.Add(comboBoxCompLast);
                        }
                UpdateRichTextBox(PuzzelLibrary.LogonData.Captcher.SearchLogs(sender, e, Name, counter, pole, rodzaj));

                //if (comboBoxLogin.InvokeRequired)
                //    comboBoxLogin.Invoke(new MethodInvoker(() =>
                //    {
                //        comboBoxLogin.Text = "";
                //        comboBoxLogin.Items.Clear();
                //    }));
            }
            else ReplaceRichTextBox("Nie podano nazwy użytkownika");
        }
        private void Keys_KeyDown(object sender, KeyEventArgs e)
        {
            if ((sender is ComboBox && ((ComboBox)sender) != comboBoxFindedSessions) || (sender is Button && (((Button)sender).Name == "btnCompInfo" || ((Button)sender).Name == "btnCompLog")))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (sender == comboBoxLogin)
                    {
                        SearchLogs(btnUserLog, e, numericLogin.Value, UserName(), "User");
                    }
                    if (sender == comboBoxComputer)
                    {
                        SearchLogs(btnCompLog, e, numericComputer.Value, HostName(), "Computer");
                    }
                }
            }

            if (sender is RichTextBox)
            {
                if (e.Control && e.KeyCode == Keys.F)
                {
                    SearchData();
                }

                //if (e.Control && e.KeyCode == Keys.Z)
                //    richTextBox1.Undo();

                //if (e.Control && e.KeyCode == Keys.Y)
                //    richTextBox1.Redo(); 
            }
        }
        private void SearchData()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.HideSelection = false;
            Additional.SearchingMainForm wyszukiwarka = new Additional.SearchingMainForm();
            wyszukiwarka.Show();
        }
        private void LogoffSession(object sender, EventArgs e)
        {
            StartTime();
            if (comboBoxFindedSessions.Text.Length > 1)
            {
                string[] IDSessionServerName = null;
                try
                {
                    if (comboBoxFindedSessions.Items.Count > 0)
                    {
                        if (comboBoxFindedSessions.SelectedIndex >= 0)
                        {
                            IDSessionServerName = comboBoxFindedSessions.Items[comboBoxFindedSessions.SelectedIndex].ToString().Split(' ');
                            PuzzelLibrary.Terminal.Explorer.LogOffSession(new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(IDSessionServerName[1]), Convert.ToInt16(IDSessionServerName[0]));

                        }
                        else ReplaceRichTextBox("Nie wybrano aktywnej sesji");
                    }
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
            else ReplaceRichTextBox("Nie można wylogować ponieważ nie została wybrana sesja");

            StopTime();
        }
        private void WyszukiwanieSesji_TerminalExplorer(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Text == "Ręczna nazwa")
            {
                External.Explorer.ExplorerFormCustomSearch podajNazweTerminala = new External.Explorer.ExplorerFormCustomSearch();
                podajNazweTerminala.ShowDialog();
            }
            Thread thread;
            External.Explorer.ExplorerForm explorer = new External.Explorer.ExplorerForm(((ToolStripMenuItem)sender).Text);
            explorer.HostName = HostName();
            thread = new Thread(() => explorer.GetSessionsToDataGridView());
            thread.Start();
            explorer.Show();
        }
    

        public static string ComputerInfo_TEMP { get; set; }
        private void btnDW_Click(object sender, EventArgs e)
        {
            StartTime();
            try
            {
                string FilePath = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "DWPath");
                if (File.Exists(FilePath))
                {
                    if (sender is Button)
                    {
                        PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(FilePath, "-m:" + HostName() + " -x -a:1");
                    }
                    else
                    {
                        string login = null;
                        string pwd = null;
                        if (sender is ToolStripMenuItem)
                        {
                            if (((ToolStripMenuItem)sender).Text.Contains("LAPS"))
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
                            {
                                PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(FilePath, "-m:" + HostName() + " -x -a:2 -u:" + login + " -p:" + pwd + " -d:");
                            }
                            else MessageBox.Show("Brak hasła");
                        }
                    }
                }
                else
                {
                    ReplaceRichTextBox("Nie można odnaleźć określonego pliku\n");
                    UpdateRichTextBox(FilePath);
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "DWButton_Click");
            }
            StopTime();
        }

        private void Info_z_AD_Click(object sender, EventArgs e)
        {
            StartTime();
            if (InfozAD.IsBusy != true)
            {
                InfozAD.RunWorkerAsync();
            }
            StopTime();
        }
        private void InfozAD_DoWork(object sender, DoWorkEventArgs e)
        {
            StartTime();
            ClearRichTextBox();
                if (UserName().Length != 0)
                {
                    var user = new PuzzelLibrary.AD.User.Information(UserName());
                    if (user != null)
                    {
                        //1 linijka
                        TimeSpan temp = (user.pwdLastSet.AddDays(30) - DateTime.Now);
                        if (temp > (DateTime.Now.AddDays(2) - DateTime.Now))
                        {
                            UpdateRichTextBox(temp.ToString("'Hasło wygasa za: 'dd' dni 'hh'g'mm'm'ss's'") + "\n");
                        }
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
                        UpdateRichTextBox(/*MembersOf()*/"Członkostwa grup:\t\t\t\t" + user.Groups.ToString());
                    }
                    else UpdateRichTextBox("Nie znaleziono użytkownika w AD");
                }
                else UpdateRichTextBox("Nie podano nazwy użytkownika");
                StopTime();
            }

        private void btnFlushDNS_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox();
            StartWinSysApplication("ipconfig.exe", "/flushdns");
            StopTime();
        }

        private void KomputerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Start();
        }

        private void KomputerInfoCOMM()
        {
            StartTime();
            PuzzelLibrary.WMI.ComputerInfo.AllComputerInfo(HostName());
            ReplaceRichTextBox(ComputerInfo_TEMP);
            ComputerInfo_TEMP = null;
            StopTime();
        }

        public readonly Stopwatch stopWatch = new Stopwatch();

        private void StartTime()
        {
            stopWatch.Start();
            UpdateStatusbp1text("Czekaj");
            //timer1.Start();
        }

        private void StopTime()
        {
            //timer1.Stop();
            stopWatch.Stop();
            UpdateStatusbp1text("Gotowe");
            UpdateStatusbp2text("Czas: " + stopWatch.Elapsed.Seconds + "s " + stopWatch.Elapsed.Milliseconds + "ms ");
            stopWatch.Reset();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Thread timer = new Thread(() =>
            {
                Thread.Sleep(100);
                while (stopWatch.IsRunning)
                    if (statusBar1.InvokeRequired)
                        statusBar1.Invoke(new MethodInvoker(() =>
                        {
                            AppendStatusbp1text("*");
                            if (statusBP1.Text.Length == 16)
                            {
                                UpdateStatusbp1text("Czekaj");
                            }
                        }));
                    else
                    {
                        AppendStatusbp1text("*");
                        if (statusBP1.Text.Length == 16)
                        {
                            UpdateStatusbp1text("Czekaj");
                        }
                    }
            });
            timer.Start();
        }

        private string[] termservers()
        {
            using (FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + @"\Terms.lst", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    return sr.ReadToEnd().Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        private void FindSessionBtn_Click(object sender, EventArgs e)
        {
            comboBoxFindedSessions.Items.Clear();
            richTextBox1.Clear();
            int aktywnesesje = 0;
            try
            {
                StartTime();
                if (UserName().Length > 1)
                {
                    if (PuzzelLibrary.AD.User.Information.IsUserAvailable(UserName()))
                        foreach (string terms in termservers())
                        {
                            //Thread.Sleep(250);
                            Thread th = new Thread(() =>
                            {
                                PuzzelLibrary.Terminal.Explorer   ts = new PuzzelLibrary.Terminal.Explorer();
                                object[] combo = ts.FindSession(new PuzzelLibrary.Terminal.Explorer().GetRemoteServer(terms), UserName()).ToArray();
                                if (combo != null)
                                {
                                    Debug.WriteLine("Znaleziono aktywną sesję");
                                    aktywnesesje++;
                                    UpdateComboBox(combo[0] + " " + combo[1]);
                                    if (comboBoxFindedSessions.InvokeRequired)
                                    {
                                        Thread.Sleep(500);
                                        comboBoxFindedSessions.Invoke(new MethodInvoker(() =>
                                        {
                                            if (comboBoxFindedSessions.Items.Count > 0)
                                                comboBoxFindedSessions.SelectedIndex = 0;
                                        }));
                                    }
                                    else comboBoxFindedSessions.SelectedIndex = 0;
                                    UpdateRichTextBox(combo[1] + " --------------------------------\n");
                                    UpdateRichTextBox("Nazwa użytkownika     Nazwa Sesji    Id    Status        Czas bezczynności    Czas logowania\n");

                                    UpdateRichTextBox(combo[2].ToString());
                                    for (int i = 0; i < "Nazwa użytkownika     ".Length - combo[2].ToString().Length; i++)
                                        UpdateRichTextBox(" ");

                                    UpdateRichTextBox(combo[3].ToString());
                                    for (int i = 0; i < "Nazwa Sesji    ".Length - combo[3].ToString().Length; i++)
                                        UpdateRichTextBox(" ");

                                    UpdateRichTextBox(combo[0].ToString());
                                    for (int i = 0; i < "Id    ".Length - combo[0].ToString().Length; i++)
                                        UpdateRichTextBox(" ");

                                    UpdateRichTextBox(combo[4].ToString());
                                    for (int i = 0; i < "Status        ".Length - combo[4].ToString().Length; i++)
                                        UpdateRichTextBox(" ");

                                    //Wyekstraktowanie całej czasu bezczynności
                                    int time = Convert.ToInt32(Math.Ceiling(((TimeSpan)combo[5]).TotalSeconds));
                                    double _time = 0;
                                    string idletime = "";
                                    if ((time / 3600) >= 1)
                                    {
                                        _time = (time / 3600);
                                        idletime += (Math.Ceiling(_time).ToString() + ":");
                                        time -= Convert.ToInt32(Math.Ceiling(_time)) * 3600;
                                    }
                                    if ((time / 60) > 1)
                                    {
                                        _time = (time / 60);
                                        idletime += (Math.Ceiling(_time).ToString() + ":");
                                        time -= Convert.ToInt32(Math.Ceiling(_time)) * 60;
                                    }

                                    idletime += (time.ToString());
                                    UpdateRichTextBox(idletime);
                                    for (int i = 0; i < "Czas bezczynności    ".Length - idletime.Length; i++)
                                        UpdateRichTextBox(" ");

                                    UpdateRichTextBox(combo[6].ToString());
                                    UpdateRichTextBox("\n");
                                    if (aktywnesesje == 0) { ReplaceRichTextBox("Nie znaleziono sesji"); }
                                }
                            });
                            th.Start();
                        }
                }
                else ReplaceRichTextBox("Nie podano loginu");
            }
            finally
            {
                StopTime();
            }
        }

        private delegate void updateComboBoxEventHandler(string message);
        private void UpdateComboBox(string message)
        {
            if (comboBoxFindedSessions.InvokeRequired)
            {
                comboBoxFindedSessions.Invoke(new updateComboBoxEventHandler(UpdateComboBox), new object[] { message });
            }
            else { comboBoxFindedSessions.Items.Add(message); }
        }
        private string OsName(string nazwaKomputera, string path, string query)
        {
            string osarch = null;
            ManagementScope scope = new ManagementScope();
            try
            {
                ConnectionOptions options = new ConnectionOptions()
                {
                    EnablePrivileges = true
                };
                scope = new ManagementScope(@"\\" + nazwaKomputera + path, options);
                scope.Connect();
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new SelectQuery(query)))
                {
                    using (ManagementObjectCollection queryCollection = searcher.Get())
                        foreach (ManagementObject m in queryCollection)
                        {
                            //osname = m["caption"].ToString();
                            osarch = m["osarchitecture"].ToString();
                        }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Dostęp zabroniony na obecnych poświadczeniach", "Łączenie z WMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Nie można się połączyć z powodu błędu: " + ex.Message, "Łączenie z WMI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return osarch;
        }
        private void RemoteCMD_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox();
            try
            {
                if (HostName().Length > 0)
                {
                    if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        var OSName = OsName(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem);
                        string applicationName = null;
                        if (OSName.Contains("64-bit"))
                            applicationName = "PsExec64.exe";
                        else applicationName = "PsExec.exe";

                        if (File.Exists(Directory.GetCurrentDirectory() + @"\" + applicationName))
                        {
                            Process.Start(applicationName, @"\\" + HostName() +" -user "+System.Environment.UserDomainName+@"\"+System.Environment.UserName + " cmd");
                        }
                        else
                        {
                            ReplaceRichTextBox("Nie można odnaleźć określonego pliku\n");
                            UpdateRichTextBox(Directory.GetCurrentDirectory() + @"\" + applicationName);
                        }
                    }
                    else
                        ReplaceRichTextBox("Stacja: " + HostName() + " nie jest widoczna na sieci");
                }
                else UpdateRichTextBox("Nie podałeś nazwy hosta");
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, HostName() + "," + PuzzelLibrary.WMI.ComputerInfo.pathCIMv2 + "," + PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem);
            }
            StopTime();
        }

        private void KomputerInfoMenuStrip(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox();
            if (HostName().Length > 0)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    if (PuzzelLibrary.NetDiag.Ping.TCPPing(HostName(), 135) == PuzzelLibrary.NetDiag.Ping.TCPPingStatus.Success)
                    {
                        ComputerInfo_TEMP += ("Nazwa komputera: ");
                        PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryComputerSystem, "DNSHostName");
                        ComputerInfo_TEMP += ("----------------------------------------\n");
                        if (sender is ToolStripMenuItem)
                        {
                            if (((ToolStripMenuItem)sender).Name == "uptimeToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Uptime: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "LastBootUpTime");
                            }

                            if (((ToolStripMenuItem)sender).Name == "nrSeryjnyINrPartiiToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("SN: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryComputerSystemProduct, "IdentifyingNumber");
                                ComputerInfo_TEMP += ("PN: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathWMI, PuzzelLibrary.WMI.ComputerInfo.querySystemInformation, "SystemSKU");
                            }

                            if (((ToolStripMenuItem)sender).Name == "modelToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("MODEL: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryComputerSystem, "Model");
                            }

                            if (((ToolStripMenuItem)sender).Name == "oSToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("OS: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version");
                            }

                            if (((ToolStripMenuItem)sender).Name == "pamięćRAMToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Pamięć TOTAL: \n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryPhysicalMemory, "Capacity");
                                ComputerInfo_TEMP += ("\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber");
                            }

                            if (((ToolStripMenuItem)sender).Name == "procesorToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("CPU \n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProcessor, "Name");
                                ComputerInfo_TEMP += ("Rdzenie: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProcessor, "NumberOfCores");
                                ComputerInfo_TEMP += ("Wątki: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProcessor, "NumberOfLogicalProcessors");
                            }

                            if (((ToolStripMenuItem)sender).Name == "zalogowanyUżytkownikToolStripMenuItem")
                            {
                                //ComputerInfo_TEMP += ("Użytkownik: ");
                                //ComputerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "UserName");
                                ComputerInfo_TEMP = null;
                                ActiveSession(sender, e);
                            }

                            if (((ToolStripMenuItem)sender).Name == "profileUżytkownikówToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Profile\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryDesktop, "Name");
                            }

                            if (((ToolStripMenuItem)sender).Name == "dyskiToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Dyski: \n");
                                ComputerInfo_TEMP += ("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size");
                            }

                            if (((ToolStripMenuItem)sender).Name == "drukarkiSiecioweToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Drukarki sieciowe\n\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryPrinterConfiguration, "DeviceName");
                            }

                            if (((ToolStripMenuItem)sender).Name == "udziałyToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Udziały\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryShare, "Name", "Path", "Description");
                            }

                            if (((ToolStripMenuItem)sender).Name == "autostartToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("AutoStart\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryStartupCommand, "Caption", "Command");
                            }

                            if (((ToolStripMenuItem)sender).Name == "pATHToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Środowisko uruchomieniowe\n");
                                ComputerInfo_TEMP += ("Nazwa zmiennej           Wartość zmiennej\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryEnvironment, "Name", "VariableValue");
                            }

                            if (((ToolStripMenuItem)sender).Name == "zasobySiecioweToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Zasoby sieciowe\n\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryNetworkConnection, "LocalName", "RemoteName");
                            }

                            if (((ToolStripMenuItem)sender).Name == "ekranyPodłączoneToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Podłączone ekrany\n\n");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status");
                            }

                            if (((ToolStripMenuItem)sender).Name == "bIOSToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("BIOS\n\n");
                                PuzzelLibrary.WMI.ComputerInfo.Fast2(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryBios);
                            }
                        }
                        if (sender is Button)
                        {
                            if (((Button)sender).Name == "BtnKarty_sieciowe")
                            {
                                ComputerInfo_TEMP += ("Karty Sieciowe: ");
                                PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryNetworkAdapterConfiguration, "IPEnabled", "Description", "DNSDomainSuffixSearchOrder", "DNSHostName", "IPAddress", "IPSubnet", "MACAddress");
                            }

                            if (((Button)sender).Name == "BtnLista_program")
                            {
                                PuzzelLibrary.WMI.ComputerInfo.Fast(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryProduct);
                            }

                            if (((Button)sender).Name == "BtnKomputerInfo")
                            {
                                KomputerInfoMethod();
                            }
                        }
                        UpdateRichTextBox(ComputerInfo_TEMP);
                        ComputerInfo_TEMP = null;
                    }
                    else UpdateRichTextBox("Serwer RPC jest niedostępny dla : " + HostName());
                }
                else UpdateRichTextBox("Stacja: " + HostName() + " nie jest widoczna w sieci");
            }
            else UpdateRichTextBox("Nie podałeś nazwy hosta");
            StopTime();
        }

        private void KomputerInfoMethod()
        {
            using (Form owner = new Form() { TopMost = true })
            {
                if (MessageBox.Show(owner, "Wyszukiwanie może chwile potrwać, zezwolić ?", "Wyszukiwanie danych", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (!komputerInfo.IsBusy)
                    {
                        ClearRichTextBox();
                        Forms.MainForm.ProgressMax = 19;
                        Additional.LoadingForm loadingForm = new Additional.LoadingForm();
                        System.Threading.Thread progress;
                        progress = new System.Threading.Thread(loadingForm.progress);
                        progress.Start();
                        progressBar = new System.Threading.Thread(KomputerInfoCOMM);
                        komputerInfo.RunWorkerAsync();
                    }
            }
        }

        private void Narzedziaadministracyjne(object sender, EventArgs e)
        {
            StartTime();
            string arguments = null;

            if (sender is ToolStripMenuItem)
            {
                if (((ToolStripMenuItem)sender).Name == "użytkownicyIGrupyLokalneToolStripMenuItem")
                    arguments = "lusrmgr.msc";

                if (((ToolStripMenuItem)sender).Name == "harmonogramZadańToolStripMenuItem")
                    arguments = "taskschd.msc";

                if (((ToolStripMenuItem)sender).Name == "usługiToolStripMenuItem")
                    arguments = "services.msc";

                if (((ToolStripMenuItem)sender).Name == "dziennikZdarzeńToolStripMenuItem")
                    arguments = "eventvwr.msc";
                if (((ToolStripMenuItem)sender).Name == "zaawansowanaZaporaToolStripMenuItem")
                {
                    PuzzelLibrary.WMI.ComputerInfo.GetInfo(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem, "Caption");
                    if (ComputerInfo_TEMP.Contains("Windows 7"))
                    {
                        Process.Start("netsh", "-r " + HostName() + " firewall set service RemoteAdmin enable").WaitForExit();
                    }
                    else { Process.Start("netsh", "-r " + HostName() + "set rule name = \"Windows Defender Firewall Remote Management (RPC)\" new enable= yes").WaitForExit(); }
                    arguments = "wf.msc";
                }
            }
            if (sender is Button)
            {
                if (((Button)sender).Name == "BtnZarzadzanie")
                    arguments = "compmgmt.msc";

            }
            if (HostName().Length > 0)
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    Process.Start("mmc.exe", arguments + @" /computer:\\" + HostName());
                }
                else
                {
                    ClearRichTextBox();
                    Process.Start("mmc.exe", arguments);
                }
            StopTime();
        }

        private void DHCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTime();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\dhcp.msc"))
                Process.Start("mmc.exe", "dhcp.msc");
            else
                UpdateRichTextBox("Brak pliku" + Directory.GetCurrentDirectory() + @"\dhcp.msc");
            StopTime();
        }

        private string HostName()
        {
            string _HostName = null;
            if (comboBoxComputer.InvokeRequired)
                comboBoxComputer.Invoke(new MethodInvoker(() => _HostName = comboBoxComputer.Text.ToUpper()));
            else _HostName = comboBoxComputer.Text.ToUpper();
            return _HostName;
        }
        private string UserName()
        {
            string _UserName = null;
            if (comboBoxLogin.InvokeRequired)
                comboBoxLogin.Invoke(new MethodInvoker(() => _UserName = comboBoxLogin.Text));
            else _UserName = comboBoxLogin.Text;
            return _UserName;
        }

        private void LockoutStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PuzzelLibrary.AD.User.Information.IsUserAvailable(UserName()))
            {
                External.LockoutStatus LS = new External.LockoutStatus(UserName());
                if (UserName().Length > 0)
                {
                    LS.AddEntry();
                    LS.Show();
                }
                else
                    LS.Show();
            }
            else MessageBox.Show("Brak użytkownika w AD");
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
        private void CMDMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("cmd", "/u");
        }

        private void PowershellMenuItem2_Click(object sender, EventArgs e)
        {
            Process.Start("powershell", "-noexit Enter-PSSession -ComputerName " + HostName());
        }

        private void CMDSYSTEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox();
            if (HostName().Length > 0)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    var OSName = OsName(HostName(), PuzzelLibrary.WMI.ComputerInfo.pathCIMv2, PuzzelLibrary.WMI.ComputerInfo.queryOperatingSystem);
                    string applicationName = null;
                    if (OSName.Contains("64-bit"))
                        applicationName = "PsExec64.exe";
                    else applicationName = "PsExec.exe";

                    if (File.Exists(Directory.GetCurrentDirectory() + @"\" + applicationName))
                    {
                        Process.Start(applicationName, @"\\" + HostName() + " -s  cmd");
                    }
                    else
                    {
                        UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                        UpdateRichTextBox(Directory.GetCurrentDirectory() + @"\" + applicationName);
                    }
                }
                else UpdateRichTextBox("Stacja: " + HostName() + " nie jest widoczna na sieci");
            }
            else UpdateRichTextBox("Nie podałeś nazwy hosta");
            StopTime();
        }
        private void menuItemRDPOpen_Click(object sender, EventArgs e)
        {
            StartTime();
            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess("mstsc.exe", "");
            StopTime();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        private void Keys_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                CloseClipboard();
                //if (e.KeyCode == Keys.Enter)
                //{
                //    if (sender is TextBox /*|| (sender is ComboBox && ((ComboBox)sender).Name != "comboBox1")*/)
                //    {
                //        SzukajLogow(sender, e);
                //    }
                //}
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
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxFindedSessions.SelectedText.Trim());
                        }
                    if (comboBoxLogin.Focused)
                        if (comboBoxLogin.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxLogin.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxLogin.SelectedText))
                        {
                            comboBoxLogin.Text = comboBoxLogin.Text.Trim(' ');
                            comboBoxLogin.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxLogin.SelectedText.Trim(' '));
                        }
                    if (comboBoxComputer.Focused)
                        if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                        {
                            comboBoxComputer.Text = comboBoxComputer.Text.Trim(' ');
                            comboBoxLogin.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
                        }
                }

                if (e.Control && e.KeyCode == Keys.V)
                {
                    if (richTextBox1.Focused)
                    {
                        richTextBox1.Paste();
                    }
                    if (comboBoxFindedSessions.Focused)
                    {
                        Clipboard.GetDataObject();
                    }
                    if (comboBoxLogin.Focused)
                    {
                        Clipboard.GetDataObject();
                    }
                    if (comboBoxComputer.Focused)
                    {
                        Clipboard.GetDataObject();
                    }
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
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxFindedSessions.SelectedText);
                            comboBoxFindedSessions.Text.Remove(comboBoxFindedSessions.SelectionStart, comboBoxFindedSessions.SelectionLength);
                            //Clipboard.SetText(Clipboard.GetText().Trim(' '));
                        }
                    if (comboBoxLogin.Focused)
                        if (comboBoxLogin.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxLogin.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxLogin.SelectedText))
                        {
                            comboBoxLogin.Text = comboBoxLogin.Text.Trim(' ');
                            comboBoxLogin.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxLogin.SelectedText.Trim(' '));
                            comboBoxLogin.Text.Remove(comboBoxLogin.SelectionStart, comboBoxLogin.SelectionLength);
                            //Clipboard.SetText(Clipboard.GetText().Trim(' '));
                        }
                    if (comboBoxComputer.Focused)
                        if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                        {
                            comboBoxComputer.Text = comboBoxComputer.Text.Trim(' ');
                            comboBoxComputer.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
                            comboBoxComputer.Text.Remove(comboBoxComputer.SelectionStart, comboBoxComputer.SelectionLength);
                            //Clipboard.SetText(Clipboard.GetText().Trim(' '));
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
        //private void LoadingShortcuts()
        //{
        //    ShortCut.SetKeyCode("CTRL+C");
        //    ShortCut.SetKeyCode("CTRL+X");
        //    ShortCut.SetKeyCode("CTRL+V");
        //    ShortCut.SetKeyCode("CTRL+F");

        //    Ustawienia settings = new Ustawienia();
        //    var setts = settings.LoadSettings();
        //    if (setts != null)
        //        for (int i = 0; i < 21; i++) 
        //    {
        //        ShortCut.SetKeyCode(setts[i,1]);
        //    }
        //}
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
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "Kopiowanie_ContextMenuText");
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
                        // Clipboard.SetText(Clipboard.GetText());
                    }
                if (comboBoxComputer.Focused)
                    if (comboBoxComputer.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxComputer.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxComputer.SelectedText))
                    {
                        Clipboard.SetText(comboBoxComputer.SelectedText.Trim(' '));
                        comboBoxComputer.Text = comboBoxComputer.Text.Remove(comboBoxComputer.SelectionStart, comboBoxComputer.SelectionLength);
                        // Clipboard.SetText(Clipboard.GetText());
                    }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "Wycinanie_ContextMenuText");
            }
        }
        private void contextMenuItemPaste_Click(object sender, EventArgs e)
        {
            try
            {
                CloseClipboard();
                if (richTextBox1.Focused)
                {
                    richTextBox1.Paste();
                }
                if (comboBoxFindedSessions.Focused)
                {
                    comboBoxFindedSessions.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
                if (comboBoxLogin.Focused)
                {
                    comboBoxLogin.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
                if (comboBoxComputer.Focused)
                {
                    comboBoxComputer.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "Wklej_ContextMenuText");
            }
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
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "zaznaczWszystko_ConcetxtMenuText");
            }
        }

        private void WyszukiwanieDanych()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.HideSelection = false;
            Additional.SearchingMainForm wyszukiwarka = new Additional.SearchingMainForm();
            wyszukiwarka.Show();
        }
        private void contextMenuItemSearch_Click(object sender, EventArgs e)
        {
            WyszukiwanieDanych();
        }
        private void pwdLAPS(object sender, EventArgs e)
        {
            if (HostName().Length > 0)
            {
                External.LAPSui lAPSui = new External.LAPSui();
                lAPSui.HostName = HostName();
                lAPSui.LoadPassword();
                lAPSui.Show();
            }
            else MessageBox.Show("Nie podano nazwy komputera");
        }
        private void Zmianahasla(object sender, EventArgs e)
        {
            if (UserName().Length > 0)
            {
                if (PuzzelLibrary.AD.User.Information.IsUserAvailable(UserName()))
                {
                    External.ZmianaHasla zh = new External.ZmianaHasla();
                    zh.ZmianaHaslaLoadForm(UserName());
                    zh.Show();
                }
            }
            else UpdateRichTextBox("Nie podano loginu");
        }

        //private void Ustawienia_Click(object sender, EventArgs e)
        //{
        //    using (Ustawienia ustawienia = new Ustawienia())
        //    {
        //        ustawienia.ShowDialog();
        //    }
        //}

        private void EnableIEHosting_Click(object sender, EventArgs e)
        {
            if (HostName().Length > 2)
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                    PuzzelLibrary.QuickFix.IEHosting.EnableCompatibilityFramework4inIE(HostName());
                else UpdateRichTextBox("Za krótka nazwa komputera");
        }

        private void WinEnvironment_Click(object sender, EventArgs e)
        {
            if (HostName().Length > 2)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    using (EnvironmentVariable env = new EnvironmentVariable(HostName()))
                    {
                        env.ShowDialog();
                    }
                }
            }
            else UpdateRichTextBox("Za krótka nazwa komputera");
        }

        private void ActiveSession(object sender, EventArgs e)
        {
            ReplaceRichTextBox(null);
            UpdateRichTextBox(new PuzzelLibrary.Terminal.CompExplorer().ActiveSession(HostName()));
        }
        private void processComputer(object sender, EventArgs e)
        {
            Thread thread;
            External.Explorer.ExplorerForm explorer = new External.Explorer.ExplorerForm(((ToolStripMenuItem)sender).Text);
            explorer.HostName = HostName();
            thread = new Thread(() => explorer.GetSessionsToDataGridView());
            thread.Start();
            explorer.Show();
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

        private void BtnTestTCP_Click(object sender, EventArgs e)
        {
            StartTime();
            ReplaceRichTextBox(null);
            if (HostName().Length > 2)
                if (PuzzelLibrary.NetDiag.Ping.TCPPing(HostName(), (int)numericTCP.Value) == PuzzelLibrary.NetDiag.Ping.TCPPingStatus.Success)
                {
                    UpdateRichTextBox("Badanie " + HostName() + " ukończone sukcesem. Port " + numericTCP.Value.ToString() + " jest otwarty.");
                }
                else UpdateRichTextBox("Badanie " + HostName() + " ukończone porażką. Port " + numericTCP.Value.ToString() + " prawdopoodobnie jest zamknięty.");
            else UpdateRichTextBox("Za krótka nazwa komputera");
            StopTime();
        }
        private void DeleteUsers_Click(object sender, EventArgs e)
        {
            if (HostName().Length > 2)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    using (DeleteUsers deleteUsers = new DeleteUsers(HostName()))
                    {
                        deleteUsers.ShowDialog();
                    }
                }
            }
            else UpdateRichTextBox("Za krótka nazwa komputera");
        }

        private void InitializeNames()
        {
            string dw = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "DW");
            string eadm = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ELogin");
            string lapslogn = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "LAPSLogin");
            this.btnDW.Text = dw;
            this.DWMenuContext.Text = dw;
            this.menuItemDWEadm.Text = dw + "(" + eadm + ")";
            this.menuItemDWLAPS.Text = dw + "(" + lapslogn + ")";
        }
        private void ActivateOffice(object sender, EventArgs e)
        {
            if (HostName().Length > 2)
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                    PuzzelLibrary.QuickFix.ActivateOffice2016.Active(HostName());
                else UpdateRichTextBox("Za krótka nazwa komputera");
        }
    }
}
