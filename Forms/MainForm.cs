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
        }
        private static Thread progressBar;// = new System.Threading.Thread(InvokeProgress);
        //public DirectorySearcher dirsearch = null;
        public static string DomainName() => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        public static int ProgressMax = 0;
        public static int ProgressBarValue = 0;
        //public static string[] UserLogs;
        //public static string[] ComputerLogs;
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

        private void PulpitZdalny_Click(object sender, EventArgs e)
        {
            StartTime();
            if (HostName().Length > 0)
            {
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(PuzzelLibrary.ExternalResources.rdp, PuzzelLibrary.ExternalResources.rdpargs + HostName());
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
                groupBox1.Width = Width - 19;
                groupBox3.Width = Width - 19;
                groupBox4.Width = Width - 19;
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
        void POutputHandler(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                UpdateRichTextBox(((e.Data) ?? string.Empty) + "\n");
            }));
        }

        //private delegate void ClearRichTextBoxEventHandler(string sign);
        private static void ClearRichTextBox(/*string sign*/)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new MethodInvoker(() => { richTextBox1.Clear(); }));
            }
            else richTextBox1.Clear();
        }

        string combobox2_last = null;
        string combobox3_last = null;
        private void SzukajLogow(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task thread = null;
            ClearRichTextBox();
            comboBoxFindedSessions.Items.Clear();
            comboBoxFindedSessions.Text = "";
            StartTime();
            int NameLength = 0;
            string folderName = null;
            decimal counter = 0;
            string NameZ = null;

            if (((Button)sender).Name == "BtnUserLog")
            {
                folderName = "User";
                counter = numericUpDown1.Value;
                NameZ = UserName();
                NameLength = NameZ.Length;
            }
            if (((Button)sender).Name == "BtnKomputerLog")
            {
                folderName = "Computer";
                counter = numericUpDown2.Value;
                NameZ = HostName();
                NameLength = NameZ.Length;
            }
            if (NameLength > 1)
            {
                if (sender == BtnUserLog)
                    if (comboBox2.Text.Length > 0)
                        if (comboBox2.Text != combobox2_last)
                        {
                            combobox2_last = comboBox2.Text;
                            comboBox2.Items.Add(combobox2_last);
                        }
                if (sender == BtnKomputerLog)
                    if (comboBox3.Text.Length > 0)
                        if (comboBox3.Text != combobox3_last)
                        {
                            combobox3_last = comboBox3.Text;
                            comboBox3.Items.Add(combobox3_last);
                        }

                if (Directory.Exists(PuzzelLibrary.ExternalResources.logsDirectory))
                {
                    int invalidPathChars = 0;

                    foreach (char invalidPathChar in Path.GetInvalidFileNameChars())
                    {
                        if (NameZ.Contains(invalidPathChar))
                            invalidPathChars++;
                    }
                    if (invalidPathChars == 0)
                    {
                        PuzzelLibrary.LogonData.Logi.contains(NameZ, folderName);
                        if (PuzzelLibrary.LogonData.Logi.LogNames().Length > 0)
                        {
                            foreach (string LogsName in PuzzelLibrary.LogonData.Logi.LogNames())
                            {
                                thread = new System.Threading.Tasks.Task(() =>
                                PuzzelLibrary.LogonData.Logi.loGi(LogsName, folderName, counter));
                                thread.RunSynchronously();
                            }
                        }
                        else ReplaceRichTextBox("Brak w logach");
                    }
                    else ReplaceRichTextBox("Użyto niedozwolonych znaków w loginie lub nazwie komputera");
                }
                else MessageBox.Show("Brak dostępu do zasobu");

                if (comboBoxFindedSessions.InvokeRequired)
                    comboBoxFindedSessions.Invoke(new MethodInvoker(() =>
                    {
                        comboBoxFindedSessions.Text = "";
                        comboBoxFindedSessions.Items.Clear();
                    }));
            }
            else ReplaceRichTextBox("Za mało danych");

            if (thread == null || thread.IsCompleted)
            {
                statusBar1.Focus();
                StopTime();
            }
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
        public static string terminalName = null;
        private void WyszukiwanieSesji_TerminalExplorer(object sender, EventArgs e)
        {
            terminalName = ((ToolStripMenuItem)sender).Text;
            if (terminalName == "Ręczna nazwa")
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
        private void DWButton_Click(object sender, EventArgs e)
        {
            StartTime();
            try
            {
                string FilePath = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "DW");
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
                                login = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "LAPSLOGIN");
                                pwd = PuzzelLibrary.LAPS.CompPWD.GetPWD(HostName());
                            }
                            else
                            {
                                login = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "ELOGIN");
                                pwd = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "eadmpwd");
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
        private void Button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ClientSize.ToString() + "\n"
                + richTextBox1.ClientSize.ToString() + "\n"
                + Size.ToString() + "\n"
                + richTextBox1.Size.ToString());

            /*
            // domainController = null;
            //getDomainControllers();
            DomainController();
            //if(!ladujLogiWTle.IsBusy)
            //ladujLogiWTle.RunWorkerAsync();

            if (domainController != null && domainController.Length > 1)
            {
                MessageBox.Show(domainController[1]);
            }
            */
        }
        /*
        static AutoCompleteStringCollection ComputerCollection = new AutoCompleteStringCollection();
        static AutoCompleteStringCollection UserCollection = new AutoCompleteStringCollection();

        
           private void AutoComplete(object sender, EventArgs e)
        {
            //string[] log =null;
            string name = null;
            AutoCompleteStringCollection autocompl = null;
            if (((TextBox)sender).Name == "textBox1")
            {
                //log = UserLogs;
                name = UserName();
                autocompl = Program.UserCollection;
            }
            if (((TextBox)sender).Name == "textBox2")
            {
                //log = ComputerLogs;
                name = HostName();
                autocompl = Program.ComputerCollection;
            }
            try
            {
                if (!ladujLogiWTle.IsBusy)
                    //if (log.Count() > 0 && log !=null)
                    if (autocompl != null && autocompl.Count > 0)
                        if //((name != null) && 
                        (name.Length > 3)//)
                        {
                            //autocompl.AddRange(log);
                            ((TextBox)sender).AutoCompleteCustomSource = autocompl;
                            ((TextBox)sender).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((TextBox)sender).AutoCompleteSource = AutoCompleteSource.CustomSource;
                        }
                        else
                        {
                            ((TextBox)sender).AutoCompleteSource = AutoCompleteSource.None;
                            ((TextBox)sender).AutoCompleteMode = AutoCompleteMode.None;
                        }
                    else
                    {
                        ladujLogiWTle.RunWorkerAsync();
                    }
            }
            catch (Exception)
            {
                throw;
            }
        }
        */
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
        private void ZdalneCMD_Click(object sender, EventArgs e)
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
            if (comboBox3.InvokeRequired)
                comboBox3.Invoke(new MethodInvoker(() => _HostName = comboBox3.Text.ToUpper()));
            else _HostName = comboBox3.Text.ToUpper();
            return _HostName;
        }
        private string UserName()
        {
            string _UserName = null;
            if (comboBox2.InvokeRequired)
                comboBox2.Invoke(new MethodInvoker(() => _UserName = comboBox2.Text));
            else _UserName = comboBox2.Text;
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

        public static string PingLicznik = "1";
        int licz = 0;
        public static string PingRemoteHost = null;
        private void RemotePing_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox();
            using (Additional.RemotePingTracert remotePing_Tracert = new Additional.RemotePingTracert())
            {
                remotePing_Tracert.ShowDialog();
            }

            if (PingRemoteHost != null)
            {
                if (PingLicznik == null)
                    PingLicznik = "5";
                using (StreamWriter SW = new StreamWriter("remoteping.cmd"))
                {
                    SW.WriteLine("PsExec64.exe " + @"\\" + HostName() + " ping " + PingRemoteHost + " -n " + PingLicznik + " 1> " + Directory.GetCurrentDirectory() + @"\temp.log");
                    SW.Close();
                }

                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.Arguments = "/c remoteping.cmd";
                    p.Start();
                    p.WaitForExit();
                }

                if (File.Exists(Directory.GetCurrentDirectory() + @"\temp.log"))
                {
                    using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\temp.log"))
                    {
                        PingRemoteHost = (sr.ReadToEnd());
                        sr.Close();
                    }
                }

                if (PingRemoteHost.Contains("Odpowied"))
                {
                    licz = PingRemoteHost.IndexOf("Odpowied");
                    PingRemoteHost = PingRemoteHost.Replace(PingRemoteHost[licz + 8], 'ź');
                    PingRemoteHost = PingRemoteHost.Replace("bźźdzenia", "błądzenia");
                    PingRemoteHost = PingRemoteHost.Replace("bajtźw", "bajtów");
                    PingRemoteHost = PingRemoteHost.Replace("wysźane", "wysłane");
                    PingRemoteHost = PingRemoteHost.Replace("pakietźw", "pakietów");
                    PingRemoteHost = PingRemoteHost.Replace("Wysźane", "Wysłane");
                    PingRemoteHost = PingRemoteHost.Replace("źredni", "średni");
                }
                UpdateRichTextBox(PingRemoteHost);
                PingRemoteHost = null;
                PingLicznik = null;
                licz = 0;

            }
            if (File.Exists("remoteping.cmd"))
                File.Delete("remoteping.cmd");
            if (File.Exists("temp.log"))
                File.Delete("temp.log");
            StopTime();
        }

        private void RemoteTracert_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox();
            using (Additional.RemotePingTracert remotePing_Tracert = new Additional.RemotePingTracert())
            {
                remotePing_Tracert.ShowDialog();
            }
            if (PingRemoteHost != null)
            {
                using (StreamWriter SW = new StreamWriter("remotetracert.cmd"))
                {
                    SW.WriteLine("PsExec64.exe " + @"\\" + HostName() + " tracert " + PingRemoteHost + " 1> " + Directory.GetCurrentDirectory() + @"\temp.log");
                    SW.Close();
                }

                using (Process p = new Process())
                {
                    p.StartInfo.FileName = "CMD";
                    p.StartInfo.Arguments = "/c remotetracert.cmd";
                    p.Start();
                    p.WaitForExit();
                }

                if (File.Exists(Directory.GetCurrentDirectory() + @"\temp.log"))
                {
                    using (StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\temp.log"))
                    {
                        PingRemoteHost = (sr.ReadToEnd());
                        sr.Close();
                    }
                }
                if (PingRemoteHost.Contains("ledzenie"))
                {
                    licz = PingRemoteHost.IndexOf("ledzenie");
                    PingRemoteHost = PingRemoteHost.Replace(PingRemoteHost[licz - 1], 'ź');
                    PingRemoteHost = PingRemoteHost.Replace("źledzenie", "Śledzenie");
                    PingRemoteHost = PingRemoteHost.Replace("maksymalnź", "maksymalną");
                    PingRemoteHost = PingRemoteHost.Replace("liczbź", "liczbą");
                    PingRemoteHost = PingRemoteHost.Replace("przeskokźw", "przeskoków");
                    PingRemoteHost = PingRemoteHost.Replace("zakoźczone", "zakończone");
                }
                UpdateRichTextBox(PingRemoteHost);
                PingRemoteHost = null;
                licz = 0;
            }
            if (File.Exists("remotetracert.cmd"))
                File.Delete("remotetracert.cmd");
            if (File.Exists("temp.log"))
                File.Delete("temp.log");
            StopTime();
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
        private void RDPBezPustyContextMenu_Click(object sender, EventArgs e)
        {
            StartTime();
            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcess(PuzzelLibrary.ExternalResources.rdp, "");
            StopTime();
        }

        private void Keys_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).Name != "comboBox1")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (sender == comboBox2)
                    {
                        SzukajLogow(BtnUserLog, e);
                    }
                    if (sender == comboBox3)
                    {
                        SzukajLogow(BtnKomputerLog, e);
                    }
                }
            }
            if (sender is RichTextBox)
            {
                if (e.Control && e.KeyCode == Keys.F)
                {
                    WyszukiwanieDanych();
                }

                //if (e.Control && e.KeyCode == Keys.Z)
                //    richTextBox1.Undo();

                //if (e.Control && e.KeyCode == Keys.Y)
                //    richTextBox1.Redo(); 
            }
            //if (sender is Button)
            //{
            string firstKey = null;
            //string secondKey = null;
            if (e.Control)
                firstKey = "CTRL";
            if (e.Alt)
                firstKey = "ALT";
            string Name = null;


            string[,] settings = null;// Ustawienia.LoadSettings();
            for (int i = 0; i < 21; i++)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));

                string[] splittedShortcut = settings[i, 1].Split('+');
                if (firstKey == splittedShortcut[0] && e.KeyCode == (Keys)converter.ConvertFromString(splittedShortcut[1]))
                    Name = settings[i, 0];
            }
            switch (Name)
            {
                case "DW":
                    {
                        DWButton_Click(BtnDW, e);
                        break;
                    }
                case "ExplorerC":
                    {
                        btnExplorer_Click(btnExplorer, e);
                        break;
                    }
                case "Info_z_AD":
                    {
                        Info_z_AD_Click(BtnInfo_z_AD, e);
                        break;
                    }
                case "Karty_sieciowe":
                    {
                        KomputerInfoMenuStrip(BtnKarty_sieciowe, e);
                        break;
                    }
                case "KomputerInfo":
                    {
                        KomputerInfoMenuStrip(BtnKomputerLog, e);
                        break;
                    }
                case "KomputerLog":
                    {
                        SzukajLogow(BtnKomputerLog, e);
                        break;
                    }
                case "Lista_program":
                    {
                        KomputerInfoMenuStrip(BtnLista_program, e);
                        break;
                    }
                case "Logoff":
                    {
                        LogoffSession(BtnLogoff, e);
                        break;
                    }
                case "Ping":
                    {
                        btnPing_Click(btnPing, e);
                        break;
                    }
                case "Polacz":
                    {
                        ConnectToSession(BtnPolacz, e);
                        break;
                    }
                case "Profil_ERI":
                    {
                        Profilsieciowy(BtnProfil_ERI, e);
                        break;
                    }
                case "Profil_EXT":
                    {
                        Profilsieciowy(BtnProfil_EXT, e);
                        break;
                    }
                case "Profil_TS":
                    {
                        Profilsieciowy(BtnProfil_TS, e);
                        break;
                    }
                case "Profil_VFS":
                    {
                        Profilsieciowy(BtnProfil_VFS, e);
                        break;
                    }
                case "Pulpit_Zdalny":
                    {
                        PulpitZdalny_Click(btnPulpit_Zdalny, e);
                        break;
                    }
                case "Remote_Ping":
                    {
                        RemotePing_Click(BtnRemote_Ping, e);
                        break;
                    }
                case "Remote_Tracert":
                    {
                        RemoteTracert_Click(BtnRemote_Tracert, e);
                        break;
                    }
                case "Szukaj_sesji":
                    {
                        FindSessionBtn_Click(BtnFindSession, e);
                        break;
                    }
                case "UserLog":
                    {
                        SzukajLogow(BtnUserLog, e);
                        break;
                    }
                case "Zarzadzanie":
                    {
                        Narzedziaadministracyjne(BtnZarzadzanie, e);
                        break;
                    }
                case "ZdalneCMD":
                    {
                        ZdalneCMD_Click(BtnZdalneCMD, e);
                        break;
                    }
            }
            //} 
        }

        //Properties.Settings settings = new Properties.Settings();
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

                    if (textBox1.Focused)
                        if (textBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox1.SelectedText) && !string.IsNullOrWhiteSpace(textBox1.SelectedText))
                            Clipboard.SetText(textBox1.SelectedText.Trim(' '));

                    if (textBox2.Focused)
                        if (textBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox2.SelectedText) && !string.IsNullOrWhiteSpace(textBox2.SelectedText))
                            Clipboard.SetText(textBox2.SelectedText.Trim(' '));

                    if (comboBoxFindedSessions.Focused)
                        if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                        {
                            comboBoxFindedSessions.Text = comboBoxFindedSessions.Text.Trim(' ');
                            comboBoxFindedSessions.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBoxFindedSessions.SelectedText.Trim());
                        }
                    if (comboBox2.Focused)
                        if (comboBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox2.SelectedText) && !string.IsNullOrWhiteSpace(comboBox2.SelectedText))
                        {
                            comboBox2.Text = comboBox2.Text.Trim(' ');
                            comboBox2.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBox2.SelectedText.Trim(' '));
                        }
                    if (comboBox3.Focused)
                        if (comboBox3.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox3.SelectedText) && !string.IsNullOrWhiteSpace(comboBox3.SelectedText))
                        {
                            comboBox3.Text = comboBox3.Text.Trim(' ');
                            comboBox2.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBox3.SelectedText.Trim(' '));
                        }
                }

                if (e.Control && e.KeyCode == Keys.V)
                {
                    if (richTextBox1.Focused)
                    {
                        richTextBox1.Paste();
                    }
                    if (textBox1.Focused)
                    {
                        textBox1.Paste();
                    }
                    if (textBox2.Focused)
                    {
                        textBox2.Paste();
                    }
                    if (comboBoxFindedSessions.Focused)
                    {
                        Clipboard.GetDataObject();
                    }
                    if (comboBox2.Focused)
                    {
                        Clipboard.GetDataObject();
                    }
                    if (comboBox3.Focused)
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

                    if (textBox1.Focused)
                        if (textBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox1.SelectedText) && !string.IsNullOrWhiteSpace(textBox1.SelectedText))
                        {
                            textBox1.Cut();
                            Clipboard.SetText(Clipboard.GetText().Trim(' '));
                        }

                    if (textBox2.Focused)
                        if (textBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox2.SelectedText) && !string.IsNullOrWhiteSpace(textBox2.SelectedText))
                        {
                            textBox2.Cut();
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
                    if (comboBox2.Focused)
                        if (comboBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox2.SelectedText) && !string.IsNullOrWhiteSpace(comboBox2.SelectedText))
                        {
                            comboBox2.Text = comboBox2.Text.Trim(' ');
                            comboBox2.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBox2.SelectedText.Trim(' '));
                            comboBox2.Text.Remove(comboBox2.SelectionStart, comboBox2.SelectionLength);
                            //Clipboard.SetText(Clipboard.GetText().Trim(' '));
                        }
                    if (comboBox3.Focused)
                        if (comboBox3.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox3.SelectedText) && !string.IsNullOrWhiteSpace(comboBox3.SelectedText))
                        {
                            comboBox3.Text = comboBox3.Text.Trim(' ');
                            comboBox3.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBox3.SelectedText.Trim(' '));
                            comboBox3.Text.Remove(comboBox3.SelectionStart, comboBox3.SelectionLength);
                            //Clipboard.SetText(Clipboard.GetText().Trim(' '));
                        }
                }
                if (e.Control && e.KeyCode == Keys.A)
                {
                    if (richTextBox1.Focused)
                        richTextBox1.SelectAll();

                    if (textBox1.Focused)
                        textBox1.SelectAll();

                    if (textBox2.Focused)
                        textBox2.SelectAll();

                    if (comboBoxFindedSessions.Focused)
                        comboBoxFindedSessions.SelectAll();

                    if (comboBox2.Focused)
                        comboBox2.SelectAll();

                    if (comboBox3.Focused)
                        comboBox3.SelectAll();
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
        private void KopiujMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                CloseClipboard();
                if (richTextBox1.Focused)
                    if (richTextBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(richTextBox1.SelectedText) && !string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                        Clipboard.SetText(richTextBox1.SelectedText.Trim(' '));

                if (textBox1.Focused)
                    if (textBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox1.SelectedText) && !string.IsNullOrWhiteSpace(textBox1.SelectedText))
                        Clipboard.SetText(textBox1.SelectedText.Trim(' '));

                if (textBox2.Focused)
                    if (textBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox2.SelectedText) && !string.IsNullOrWhiteSpace(textBox2.SelectedText))
                        Clipboard.SetText(textBox2.SelectedText.Trim(' '));

                if (comboBoxFindedSessions.Focused)
                    if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                        Clipboard.SetText(comboBoxFindedSessions.SelectedText.Trim(' '));

                if (comboBox2.Focused)
                    if (comboBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox2.SelectedText) && !string.IsNullOrWhiteSpace(comboBox2.SelectedText))
                        Clipboard.SetText(comboBox2.SelectedText.Trim(' '));

                if (comboBox3.Focused)
                    if (comboBox3.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox3.SelectedText) && !string.IsNullOrWhiteSpace(comboBox3.SelectedText))
                        Clipboard.SetText(comboBox3.SelectedText.Trim(' '));
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "Kopiowanie_ContextMenuText");
            }
        }

        private void WytnijMenuItem1_Click(object sender, EventArgs e)
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

                if (textBox1.Focused)
                    if (textBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox1.SelectedText) && !string.IsNullOrWhiteSpace(textBox1.SelectedText))
                    {
                        textBox1.Cut();
                        Clipboard.SetText(Clipboard.GetText().Trim(' '));
                    }

                if (textBox2.Focused)
                    if (textBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox2.SelectedText) && !string.IsNullOrWhiteSpace(textBox2.SelectedText))
                    {
                        textBox2.Cut();
                        Clipboard.SetText(Clipboard.GetText().Trim(' '));
                    }

                if (comboBoxFindedSessions.Focused)
                    if (comboBoxFindedSessions.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBoxFindedSessions.SelectedText) && !string.IsNullOrWhiteSpace(comboBoxFindedSessions.SelectedText))
                    {
                        Clipboard.SetText(comboBoxFindedSessions.SelectedText);
                        comboBoxFindedSessions.Text = comboBoxFindedSessions.Text.Remove(comboBoxFindedSessions.SelectionStart, comboBoxFindedSessions.SelectionLength);
                        Clipboard.SetText(Clipboard.GetText().Trim(' '));
                    }
                if (comboBox2.Focused)
                    if (comboBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox2.SelectedText) && !string.IsNullOrWhiteSpace(comboBox2.SelectedText))
                    {
                        Clipboard.SetText(comboBox2.SelectedText.Trim(' '));
                        comboBox2.Text = comboBox2.Text.Remove(comboBox2.SelectionStart, comboBox2.SelectionLength);
                        // Clipboard.SetText(Clipboard.GetText());
                    }
                if (comboBox3.Focused)
                    if (comboBox3.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox3.SelectedText) && !string.IsNullOrWhiteSpace(comboBox3.SelectedText))
                    {
                        Clipboard.SetText(comboBox3.SelectedText.Trim(' '));
                        comboBox3.Text = comboBox3.Text.Remove(comboBox3.SelectionStart, comboBox3.SelectionLength);
                        // Clipboard.SetText(Clipboard.GetText());
                    }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "Wycinanie_ContextMenuText");
            }
        }
        private void WklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseClipboard();
                if (richTextBox1.Focused)
                {
                    richTextBox1.Paste();
                }
                if (textBox1.Focused)
                {
                    textBox1.Paste();
                }
                if (textBox2.Focused)
                {
                    textBox2.Paste();
                }
                if (comboBoxFindedSessions.Focused)
                {
                    comboBoxFindedSessions.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
                if (comboBox2.Focused)
                {
                    comboBox2.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
                if (comboBox3.Focused)
                {
                    comboBox3.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "Wklej_ContextMenuText");
            }
        }
        private void ZaznaczWszystkoMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Focused)
                    richTextBox1.SelectAll();

                if (textBox1.Focused)
                    textBox1.SelectAll();

                if (textBox2.Focused)
                    textBox2.SelectAll();

                if (comboBoxFindedSessions.Focused)
                    comboBoxFindedSessions.SelectAll();

                if (comboBox2.Focused)
                    comboBox2.SelectAll();

                if (comboBox3.Focused)
                    comboBox3.SelectAll();
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "zaznaczWszystko_ConcetxtMenuText");
            }
        }

        public static int IDrtb = 0;
        public static int statusOkna = 0;
        private void WyszukiwanieDanych()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.HideSelection = false;
            Additional.SearchingMainForm wyszukiwarka = new Additional.SearchingMainForm();
            wyszukiwarka.Show();
        }
        private void WyszukajMenuItem_Click(object sender, EventArgs e)
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

        private void EnableDotNET4CompatibilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HostName().Length > 2)
                if (PuzzelLibrary.NetDiag.Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                    PuzzelLibrary.QuickFix.IEHosting.EnableCompatibilityFramework4inIE(HostName());
                else UpdateRichTextBox("Za krótka nazwa komputera");
        }

        private void zmiennaŚrodowiskowaToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (panel1.Width == 351)
            {
                btnCollapseTCP.Text = "Rozwiń";
                panel1.Width = 63;
            }
            else
            {
                btnCollapseTCP.Text = "Zwiń";
                panel1.Width = 351;
            }
        }

        private void BtnTestTCP_Click(object sender, EventArgs e)
        {
            StartTime();
            ReplaceRichTextBox(null);
            if (HostName().Length > 2)
                if (PuzzelLibrary.NetDiag.Ping.TCPPing(HostName(), (int)numericUpDown3.Value) == PuzzelLibrary.NetDiag.Ping.TCPPingStatus.Success)
                {
                    UpdateRichTextBox("Badanie " + HostName() + " ukończone sukcesem. Port " + numericUpDown3.Value.ToString() + " jest otwarty.");
                }
                else UpdateRichTextBox("Badanie " + HostName() + " ukończone porażką. Port " + numericUpDown3.Value.ToString() + " prawdopoodobnie jest zamknięty.");
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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void InitializeNames()
        {
            this.BtnDW.Text = PuzzelLibrary.ExternalResources.dw;
            this.DWMenuContext.Text = PuzzelLibrary.ExternalResources.dw;
            this.EAdminDWMenuContext.Text = PuzzelLibrary.ExternalResources.dw + "(" + PuzzelLibrary.ExternalResources.eadm + ")";
            this.LAPSDWContextMenu.Text = PuzzelLibrary.ExternalResources.dw + "(" + PuzzelLibrary.ExternalResources.lapslogn + ")";
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
