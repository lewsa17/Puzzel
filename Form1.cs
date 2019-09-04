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
using System.Management.Automation;
namespace Puzzel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Working = File.ReadAllLines("DefaultValue.txt");
            InitializeComponent();

            /*
            AutoGettingLogs.Start();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\UserLogCache.log") && File.Exists(Directory.GetCurrentDirectory() + @"\ComputerLogCache.log.log"))
            {
                Logi logi = new Logi(UserName(), HostName());
                progressBar = new System.Threading.Thread(logi.LoadLogs);
                Puzzel.Form1.ProgressMax = 2;
                LoadingForm loadingForm = new LoadingForm();
                System.Threading.Thread progress = new System.Threading.Thread(loadingForm.progress);
                progressBar.Start();
                progress.Start();
            }
            else
            {
                progressBar = new System.Threading.Thread(GetLogs);
                Puzzel.Form1.ProgressMax = 8;
                LoadingForm loadingForm = new LoadingForm();
                System.Threading.Thread progress = new System.Threading.Thread(loadingForm.progress);
                progressBar.Start();
                progress.Start();
            }*/

        }/*
        string[] Working = null;
        private void GetLogs()
        {
            Logi logi = new Logi(UserName(), HostName());
            logi.GetLogs();
            logi.SaveLogs();
            logi.LoadLogs();
        }*/
        public static void InvokeProgress()
        { /*Progress progress = new Progress();
            if (progress.InvokeRequired)
            {
                progress.Invoke(new MethodInvoker(() =>
                {
                    progress.Show();
                }));
            }*/
            
        }
        public static Thread progressBar;// = new System.Threading.Thread(InvokeProgress);
        public DirectorySearcher dirsearch = null;
        public string domainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }
        public static int ProgressMax = 0;
        public static int ProgressBarValue = 0;
        //public static string[] UserLogs;
        //public static string[] ComputerLogs;
        string[] domainControllerName = { };
        public void getDomainControllers()
        {
            domainControllerName = DomainController().Split(',');
        }

        public static string domainController2;
        string[] domainController = new string[4];
        int licznik_dla_controlera = 0;
        void DomainControllersa(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                domainController[licznik_dla_controlera]+= (e.Data) ?? string.Empty;
            }));
            licznik_dla_controlera++;
        }
        private delegate void UpdateRichTextBoxEventHandler(string message);
        private void UpdateRichTextBox(string message)
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
        private void ReplaceRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new ReplaceRichTextBoxEventHandler(ReplaceRichTextBox), new object[] { message });
            }
            else { richTextBox1.Text = message; }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            startTime();
            Puzzel.Ping.Pinging(HostName());
            if (PingStatus == 0)
            {
                ProcExec Exec = new ProcExec(ProcExec.rdp, ProcExec.rdp_args + HostName());
            }
            else ReplaceRichTextBox("Niewidoczny na sieci");
            stopTime();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox(null);
            if (HostName().Length > 0)
            {
                Process p = new Process();
                p.StartInfo.FileName = @"ping";
                p.StartInfo.Arguments = "-n 2 " + HostName();
                p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += new DataReceivedEventHandler(pOutputHandler);
                p.Start();
                p.BeginOutputReadLine();
                p.WaitForExit();

                Process n = new Process();
                n.StartInfo.FileName = @"C:\Windows\sysnative\nbtstat.exe";
                n.StartInfo.Arguments = @"-a " + HostName() + " -c";
                n.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
                n.StartInfo.CreateNoWindow = true;
                n.StartInfo.UseShellExecute = false;
                n.StartInfo.RedirectStandardOutput = true;
                n.OutputDataReceived += new DataReceivedEventHandler(pOutputHandler);
                n.Start();
                n.BeginOutputReadLine();
                n.WaitForExit();
            }
            else MessageBox.Show("Brak danych w 2 polu tekstowym");
            stopTime();
        }

        private void profilsieciowy(object sender, EventArgs e)
        {
            startTime();
            string folder = null;
            if (((Button)sender).Name == "button4")
                folder = ProcExec.vfs;

            if (((Button)sender).Name == "button3")
                folder = ProcExec.eri;

            if (((Button)sender).Name == "button6")
                folder = ProcExec.net;

            if (((Button)sender).Name == "button5")
                folder = ProcExec.ext;

            ProcExec Exec = new ProcExec();
            if (Directory.Exists(folder))
                Exec.ProcExecIF(ProcExec.explorer, folder + UserName());
            else ReplaceRichTextBox("Katalog jest niedostępny");
            stopTime();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            startTime();
            Puzzel.Ping.Pinging(HostName());
            if (HostName().Length > 1)
            {
                if (PingStatus == 0)
                {
                    ProcExec Exec = new ProcExec(ProcExec.explorer, @"\\" + HostName() + @"\c$");
                }
                else ReplaceRichTextBox("Nie odpowiada w sieci");
            }
            else ReplaceRichTextBox("Za mało danych");
            stopTime();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            startTime();
            if (programList.IsBusy != true) {
                programList.RunWorkerAsync();
            }
            stopTime();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ClearRichTextBox(null);
            if (HostName().Length > 0)
            {
                startTime();
                Puzzel.Ping.Pinging(HostName());
                if (PingStatus == 0)
                {
                    ComputerInfo computerInfo = new ComputerInfo();
                    ComputerInfo_TEMP += ("Nazwa komputera: ");
                    computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "DNSHostName");
                    ComputerInfo_TEMP += ("----------------------------------------\n");
                    ComputerInfo_TEMP += ("Karty Sieciowe: ");
                    computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryNetworkAdapterConfiguration, "IPEnabled", "Description", "DNSDomainSuffixSearchOrder", "DNSHostName", "IPAddress", "IPSubnet", "MACAddress");
                    UpdateRichTextBox(ComputerInfo_TEMP);
                    ComputerInfo_TEMP = null;
                }
                else return;
            }
            else UpdateRichTextBox("Brak podanej nazwy komputera");
            stopTime();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                try
                {
                    int height = Form1.ActiveForm.Height - 511;
                    int width = Form1.ActiveForm.Width - 1190;
                    groupBox1.Width = width + 1172;
                    groupBox3.Width = width + 1172;
                    groupBox4.Width = width + 1172;
                    richTextBox1.Width = width + 1173;
                    richTextBox1.Height = height + 230;
                }
                catch (System.NullReferenceException)
                {
                    return;
                }
        }

        public void button8_Click(object sender, EventArgs e)
        {
            startTime();
            try
            {
                string temp1 = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                if (comboBox1.SelectedIndex >= 0)
                {
                    string[] temp = temp1.Split(' ');
                    ProcExec Exec = new ProcExec(@"C:\Windows\sysnative\shadow.exe", temp[0] + " /server:" + temp[1]);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                UpdateRichTextBox("Nie wybrano żadnego terminala lub nie znalazł żadnej sesji\n");
                MessageBox.Show("Nie wybrano żadnego terminala lub nie znalazł żadnej sesji", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception)
            {
                UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                UpdateRichTextBox(@"C:\Windows\System32\shadow.exe");
            }
            stopTime();
        }
        void pOutputHandler(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                UpdateRichTextBox(((e.Data) ?? string.Empty) + "\n");
            }));
        }
        string sesjelogs;
        void sesje(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                sesjelogs += e.Data + "\n";
            }));
        }

        void netuserdomainbloop(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netuserdomain += e.Data + "\n";
            }));
        }


        public static int PingStatus;


        private delegate void ClearRichTextBoxEventHandler(string sign);
        private void ClearRichTextBox(string sign)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new ClearRichTextBoxEventHandler(ClearRichTextBox), new object[] { sign });
            }
            else ReplaceRichTextBox(null);
        }

        private void SearchbySama(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine(e.Data);
            this.BeginInvoke(new MethodInvoker(() =>
        {
            ImieNazwisko += (((e.Data) ?? string.Empty));
        }));

        }
        private string ImieNazwisko = null;
        private void SearchNameBysAMA(string UserName)
        {
            Process n = new Process();
            n.StartInfo.FileName = @"C:\Windows\sysnative\dsquery.exe";
            n.StartInfo.Arguments = @"user -o rdn -samid " + UserName;
            n.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
            n.StartInfo.CreateNoWindow = true;
            n.StartInfo.UseShellExecute = false;
            n.StartInfo.RedirectStandardOutput = true;
            n.OutputDataReceived += new DataReceivedEventHandler(SearchbySama);
            n.Start();
            n.BeginOutputReadLine();
            n.WaitForExit();
            stopTime();
        }

        string[] LogsNames = null;
        private void contains(string pole, string rodzaj)
        {
            if (!string.IsNullOrEmpty(pole) | !string.IsNullOrWhiteSpace(pole))
            {
            	if (Directory.Exists(Working[8].Remove(8)))
                {
                    LogsNames = Directory.GetFiles(Working[8].Remove(8) + rodzaj + @"\", "*" + pole + "*_logons.log", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < LogsNames.Length; i++)
                    {
                        LogsNames[i] = Path.GetFileNameWithoutExtension(LogsNames[i]);
                        LogsNames[i] = LogsNames[i].Replace("_logons", "");
                    }
                }
                else MessageBox.Show("Brak dostępu do zasobu");
            }
            else ReplaceRichTextBox("Pole puste lub niepotrzebna spacja");
        }

        private void loGi(string pole, string rodzaj, decimal licznik)
        {
            startTime();
            FileStream fileStream = new FileStream(Working[8].Remove(8) + rodzaj + @"\" + pole + "_logons.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            
            StreamReader sr = new StreamReader(fileStream);
            long fsize = fileStream.Length;
            decimal lines = licznik;
            int lineMaxLenOptim = 255;
            long pos = fsize - lineMaxLenOptim * (long)lines;
            if (pos > 0)
            {
                sr.BaseStream.Position = pos;
                sr.BaseStream.Seek(pos, SeekOrigin.Begin);
            }
            char line = '\n';
            string[] LogCompLogs = sr.ReadToEnd().Split(line);
            Array.Resize(ref LogCompLogs, LogCompLogs.Length - 1);
            Array.Reverse(LogCompLogs);
            Array.Resize(ref LogCompLogs, LogCompLogs.Length - 1);

            int maxLines = LogCompLogs.Length;
            decimal a = licznik;
            string[] word;
            string[] words;
            word = LogCompLogs[1].Split(';');
            UpdateRichTextBox(string.Format("{0,-13}{1,-16}{2,-30}{3,-12}{4,-28}{5,-10}", "LOGOWANIE", "KOMPUTER", "NAZWA", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));
            if (a < maxLines)
                for (int i = 0; i < a; i++)
                {
                    words = LogCompLogs[i].Split(';');
                    UpdateRichTextBox(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                }
            else
                for (int i = 0; i < maxLines; i++)
                {
                    words = LogCompLogs[i].Split(';');
                    UpdateRichTextBox(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                }

            //UpdateRichTextBox(sb.ToString());
            stopTime();
        }

        string senderZ = null;
        decimal counter = 0;
        int counterlist = 0;
        string NameZ = null;
        private void szukajLogow(object sender, EventArgs e)
        {
            BackgroundWorker ladujWtle = new BackgroundWorker();
            if (!ladujWtle.IsBusy)
            {
                if (sender is Button)
                {
                    if (((Button)sender).Name == "button1")
                    {
                        senderZ = "User";
                        counterlist = textBox1.Text.Length;
                        counter = numericUpDown1.Value;
                        NameZ = UserName();
                    }
                    if (((Button)sender).Name == "button10")
                    {
                        senderZ = "Computer";
                        counterlist = textBox2.Text.Length;
                        counter = numericUpDown2.Value;
                        NameZ = HostName();
                    }
                }
                if (sender is TextBox)
                {
                    if (((TextBox)sender).Name == "textBox1")
                    {
                        senderZ = "User";
                        counterlist = textBox1.Text.Length;
                        counter = numericUpDown1.Value;
                        NameZ = UserName();
                    }
                    if (((TextBox)sender).Name == "textBox2")
                    {
                        senderZ = "Computer";
                        counterlist = textBox2.Text.Length;
                        counter = numericUpDown2.Value;
                        NameZ = HostName();
                    }
                }

                ladujWtle.DoWork += (object sendzer, DoWorkEventArgs dwea) =>
                {
                    ClearRichTextBox(null);
                    startTime();
                    if (counterlist > 2)
                    {
                        contains(NameZ, senderZ);
                        if (LogsNames.Count() > 0)
                        {
                            foreach (string LogsName in LogsNames)
                                loGi(LogsName, senderZ, counter);
                        }
                        else ReplaceRichTextBox("Brak w logach");
                    }
                    else ReplaceRichTextBox("Za mało danych");

                    if (comboBox1.InvokeRequired)
                        comboBox1.Invoke(new MethodInvoker(() =>
                        {
                            comboBox1.Text = "";
                            comboBox1.Items.Clear();
                        }));
                    stopTime();
                };
                ladujWtle.RunWorkerAsync();
            }
            else MessageBox.Show("Wyszukiwanie nadal trwa...", "Wyszukiwanie danych");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            startTime();

            if (comboBox1.Items.Count > 0)
            {
                string wybranaLinijka = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                if (comboBox1.SelectedIndex >= 0)
                {
                    string[] SlowowTekscie = wybranaLinijka.Split(' ');
                    Process session = new Process();
                    session.StartInfo.FileName = @"C:\Windows\sysnative\logoff.exe";
                    session.StartInfo.Arguments = SlowowTekscie[0] + " /server:" + SlowowTekscie[1];
                    session.StartInfo.CreateNoWindow = true;
                    session.StartInfo.UseShellExecute = false;
                    session.Start();
                    session.WaitForExit();
                    MessageBox.Show("Sesja została wylogowana");
                }
            }
            stopTime();
        }


        public static string ComputerInfo_TEMP;
        private void button13_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox(null);
            Puzzel.Ping.Pinging(HostName());
            if (textBox2.Text.Length > 1)
            {
                if (PingStatus == 0)
                {
                    if (MessageBox.Show(new Form() { TopMost = true }, "Wyszukiwanie może chwile potrwać, zezwolić ?", "Wyszukiwanie danych", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        if (!komputerInfo.IsBusy)
                        {
                            Puzzel.Form1.ProgressMax = 19;
                            LoadingForm loadingForm = new LoadingForm();
                            System.Threading.Thread progress;
                            progress = new System.Threading.Thread(loadingForm.progress);
                            //Progress pgclass = new Progress();
                            progress.Start();
                            progressBar = new System.Threading.Thread(komputerInfoCOMM);
                            komputerInfo.RunWorkerAsync();
                        }
                }
                else
                    UpdateRichTextBox("Stacja: " + HostName() + " nie jest widoczna na sieci");
            }
            else UpdateRichTextBox("Nie podałeś nazwy hosta");
            stopTime();
        }
        
        private void button15_Click(object sender, EventArgs e)
        {
            startTime();
            if(File.Exists(Working[9].Remove(13)))
            {
                ProcExec Exec = new ProcExec(Working[9].Remove(13), "-m:" + HostName() + " -x -a:1");
            }
            else
            {
                UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                UpdateRichTextBox(Working[9].Remove(13));
            }
            stopTime();
        }

        private SearchResult SearchByUserName(DirectorySearcher ds, string username)
        {
            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(sAMAccountName=" + username + "))";
            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
            SearchResult userObject = ds.FindOne();

            if (userObject != null)
                return userObject;
            else
                return null;
        }

        private SearchResult SearchByEmail(DirectorySearcher ds, string email)
        {
            ds.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(mail=" + email + "))";
            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
            SearchResult userObject = ds.FindOne();

            if (userObject != null)
                return userObject;
            else
                return null;
        }

        private string SearchProperty(string propertyName)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domainName());
            DirectorySearcher searcher = new DirectorySearcher(entry);
            SearchResult searchResult = searcher.FindOne();
            ResultPropertyValueCollection valueCollection = searchResult.Properties[propertyName];
            string temp = null;
            if (valueCollection != null)
                temp = valueCollection.ToString();
            return temp;
        }

        private void GetInfo(string domain)
        {
            Cursor.Current = Cursors.WaitCursor;
            SearchResult rs = null;
            if (UserName().Trim().IndexOf("@") > 0)
                rs = SearchByEmail(GetDirectorySearcher(domain), UserName().Trim());
            else
                rs = SearchByUserName(GetDirectorySearcher(domain), UserName().Trim());

            if (rs != null)
                ShowUserInformation(rs);
            else
                MessageBox.Show("User not found!", "Search Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DirectorySearcher GetDirectorySearcher(string domain)
        {
            if (dirsearch == null)
            {
                try
                {
                    dirsearch = new DirectorySearcher(new DirectoryEntry("LDAP://" + domain));
                }
                catch (DirectoryServicesCOMException e)
                {
                    MessageBox.Show("connection credential is wrong, please check", "error info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Message.ToString();
                }
                return dirsearch;
            }
            else return dirsearch;
        }

        public string loginName = null;
        public string displayName = null;
        public string title = null;
        public string company = null;
        public string department = null;
        public string mail = null;
        public string userEnabled = null;
        public DateTime accountExpires;
        public DateTime lockoutTime;
        public DateTime badPasswordTime;
        public int badPwdCount;
        public string InternetAccessEnabled;
        public DateTime pwdLastSet;
        public DateTime lastBadPwdAttempt;
        public DateTime lastLogon;
        public DateTime lastLogoff;
        public string scriptPath = null;
        public string homeDirectory = null;
        public string homeDrive = null;
        public string userCannotChangePassword = null;
        public string passwordNotRequired = null;

        private void ShowUserInformation(SearchResult rs)
        {
            if (rs.GetDirectoryEntry().Properties["sAMAccountName"].Value != null)
                loginName = rs.GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["displayName"].Value != null)
                displayName = rs.GetDirectoryEntry().Properties["displayName"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["title"].Value != null)
                title = rs.GetDirectoryEntry().Properties["title"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["company"].Value != null)
                company = rs.GetDirectoryEntry().Properties["company"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["department"].Value != null)
                department = rs.GetDirectoryEntry().Properties["department"].Value.ToString();

            if (rs.GetDirectoryEntry().Properties["mail"].Value != null)
                mail = (string)rs.GetDirectoryEntry().Properties["mail"].Value;

            if (rs.GetDirectoryEntry().Properties["homeDirectory"].Value != null)
                homeDirectory = rs.GetDirectoryEntry().Properties["homeDirectory"].Value.ToString();

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, textBox1.Text);
                //? - to mark DateTime type as nullable

                if (user.Enabled != null)
                {
                    if (user.Enabled == true) userEnabled = "TAK";
                    if (user.Enabled == false) userEnabled = "NIE";
                } else userEnabled = "błąd";

                if (user.BadLogonCount >= 0)
                    badPwdCount = (int)user.BadLogonCount;

                if (user.HomeDirectory != null)
                    homeDirectory = user.HomeDirectory;

                if (user.HomeDrive != null)
                    homeDrive = (string)user.HomeDrive;

                if (user.LastBadPasswordAttempt != null)
                    lastBadPwdAttempt = (DateTime)user.LastBadPasswordAttempt;

                if (user.ScriptPath != null)
                    scriptPath = (string)user.ScriptPath;

                if (user.PasswordNotRequired)
                {
                    if (user.PasswordNotRequired == true) passwordNotRequired = "NIE";
                    if (user.PasswordNotRequired == false) passwordNotRequired = "TAK";
                } else passwordNotRequired = "Błąd";

                if (user.UserCannotChangePassword)
                {
                    if (user.UserCannotChangePassword == true) userCannotChangePassword = "NIE";
                    if (user.UserCannotChangePassword == false) userCannotChangePassword = "TAK";
                } else userCannotChangePassword = "Błąd";
            }

            if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value != null)
            {
                if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "True")
                    InternetAccessEnabled = "TAK";
                if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "False")
                    InternetAccessEnabled = "NIE";
            } else InternetAccessEnabled = "Błąd, brak obiektu";

            if (rs.GetDirectoryEntry().Properties["pwdLastSet"].Value != null)
            {
                long temp = (long)rs.Properties["pwdLastSet"][0];
                pwdLastSet = DateTime.FromFileTime(temp);
            }

            if (rs.GetDirectoryEntry().Properties["badPasswordTime"].Value != null)
            {
                long temp = (long)rs.Properties["badPasswordTime"][0];
                badPasswordTime = DateTime.FromFileTime(temp);
            }

            if (rs.GetDirectoryEntry().Properties["lastLogoff"].Value != null)
            {
                long temp = (long)rs.Properties["lastLogoff"][0];
                lastLogoff = DateTime.FromFileTime(temp);
            }

            if (rs.GetDirectoryEntry().Properties["lastLogon"].Value != null)
            {
                long temp = (long)rs.Properties["lastLogon"][0];
                lastLogon = DateTime.FromFileTime(temp);
            }

            if (rs.GetDirectoryEntry().Properties["accountExpires"] != null)
            {
                long temp = (long)rs.Properties["accountExpires"][0];
                accountExpires = DateTime.FromFileTime(temp);
            }

            if (rs.GetDirectoryEntry().Properties["lockoutTime"] != null)
            {
                long temp = (long)rs.Properties["lockoutTime"][0];
                lockoutTime = DateTime.FromFileTime(temp);
            }
        }

        public UserPrincipal GetUser(string UserName)
        {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain);

            UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, UserName);
            return oUserPrincipal;
        }

        public ArrayList getUserGroups(string UserName)
        {
            ArrayList myItems = new ArrayList();
            UserPrincipal user = GetUser(UserName);
            PrincipalSearchResult<Principal> oPrincipalSearcherResult = user.GetGroups();
            foreach (Principal oResult in oPrincipalSearcherResult)
            {
                myItems.Add(oResult.Name);
            }
            return myItems;
        }

        string netuserdomain;
        private void button2_Click(object sender, EventArgs e)
        {
            startTime();
            if (InfozAD.IsBusy != true)
            {
                InfozAD.RunWorkerAsync();
            }
            stopTime();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox(null);
            Process p = new Process();
            p.StartInfo.FileName = @"ipconfig";
            p.StartInfo.Arguments = @"/flushdns";
            p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(pOutputHandler);
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
            stopTime();
        }

        private void komputerInfoCOMM()
        {
            startTime();
                ComputerInfo computerInfo = new ComputerInfo();
                ComputerInfo_TEMP += ("Nazwa komputera: ");
                ProgressBarValue = 1;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "DNSHostName");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Domena: ");
                ProgressBarValue = 2;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "Domain");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Uptime: ");
                ProgressBarValue = 3;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem, "LastBootUpTime");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("SN: ");
                ProgressBarValue = 4;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystemProduct, "IdentifyingNumber");
                ComputerInfo_TEMP += ("PN: ");
                ProgressBarValue = 5;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathWMI, ComputerInfo.querySystemInformation, "SystemSKU");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Model: ");
                ProgressBarValue = 6;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "Model");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("OS: ");
                ProgressBarValue = 7;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                //TotalCapacity
                ComputerInfo_TEMP += ("Pamięć TOTAL: \n");
                ProgressBarValue = 8;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryPhysicalMemory, "Capacity");
                ComputerInfo_TEMP += ("\n");
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("CPU \n");
                ProgressBarValue = 9;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProcessor, "Name");
                ComputerInfo_TEMP += ("Rdzenie: ");
                ProgressBarValue = 10;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProcessor, "NumberOfCores");
                ComputerInfo_TEMP += ("Wątki: ");
                ProgressBarValue = 11;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProcessor, "NumberOfLogicalProcessors");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Użytkownik: ");
                ProgressBarValue = 12;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "UserName");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Profile\n");
                ProgressBarValue = 13;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryDesktop, "Name");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Dyski: \n");
                ProgressBarValue = 14;
                ComputerInfo_TEMP += ("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n");
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Zasoby sieciowe\n\n");
                ProgressBarValue = 15;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryNetworkConnection, "LocalName", "RemoteName");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Drukarki sieciowe\n\n");
                ProgressBarValue = 16;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryPrinterConfiguration, "DeviceName");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Udziały\n");
                ProgressBarValue = 17;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryShare, "Name", "Path", "Description");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("AutoStart\n");
                ProgressBarValue = 18;
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryStartupCommand, "Caption", "Command");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                ComputerInfo_TEMP += ("Środowisko uruchomieniowe\n");
                ProgressBarValue = 19;
                ComputerInfo_TEMP += ("Nazwa zmiennej           Wartość zmiennej\n");
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryEnvironment, "Name", "VariableValue");
                ReplaceRichTextBox(ComputerInfo_TEMP);
                ComputerInfo_TEMP = null;
            stopTime();
        }
        private void komputerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Start();
        }
        
        private void programList_DoWork(object sender, DoWorkEventArgs e)
        {

            startTime();
            Puzzel.Ping.Pinging(HostName());
            ClearRichTextBox(null);
            string text = "fast";
            if (PingStatus == 0)
            {StartAgainIfReturnedValueIsNull:
                switch (text)
                {
                    case "fast":
                        {
                            var ps = PowerShell.Create();

                            ps.AddScript("Invoke-Command -ComputerName " + HostName() + @" -Command {Get-ItemProperty -Path HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\* | Select-Object DisplayName, InstallDate, DisplayVersion}");
                            System.Collections.Generic.List<PSObject> items = ps.Invoke().ToList();
                            string[] objItem = null;
                            int firstoptimvalue = 50;
                            int secondoptimvalue = 31;
                            ComputerInfo_TEMP += (string.Format("{0,-50}{1,-31}{2,-1}", "DisplayName", "InstallDate", "DisplayVersion" + "\n"));
                            foreach (PSObject item in items)
                            {
                                objItem = item.ToString().Split(';');
                                objItem[0] = objItem[0].Replace("@{DisplayName=", " ");
                                objItem[1] = objItem[1].Replace("InstallDate=", "");
                                objItem[2] = objItem[2].Replace("DisplayVersion=", "").Replace("}", "");

                                int firstObjLength = objItem[0].Length;
                                int secondObjLenght = objItem[1].Length;
                                int thirdObjLenght = objItem[2].Length;
                                int addspace = 0;
                                if (firstObjLength > 1)
                                {
                                    ComputerInfo_TEMP += objItem[0];
                                    if (firstObjLength < firstoptimvalue)
                                    {
                                        addspace = firstoptimvalue - firstObjLength;
                                        for (int i = 0; i < addspace; i++)
                                            ComputerInfo_TEMP += " ";
                                    }
                                    else
                                    {
                                        ComputerInfo_TEMP += "   ";
                                    }
                                    if (secondObjLenght > 1 && thirdObjLenght > 1)
                                    {
                                        ComputerInfo_TEMP += objItem[1];
                                        if (firstoptimvalue > firstObjLength)
                                        {
                                            addspace = secondoptimvalue - secondObjLenght;
                                            for (int i = 0; i < addspace; i++)
                                                ComputerInfo_TEMP += " ";
                                        }
                                        if (firstoptimvalue < firstObjLength)
                                        {
                                            if (firstoptimvalue + secondoptimvalue > firstObjLength + secondObjLenght + 3)
                                            {
                                                addspace = firstoptimvalue + secondoptimvalue - firstObjLength - secondObjLenght - 3;
                                                for (int i = 0; i < addspace; i++)
                                                    ComputerInfo_TEMP += " ";
                                            }
                                            else ComputerInfo_TEMP += "  ";
                                        }
                                    }
                                    if (secondObjLenght < 4 && thirdObjLenght > 1)
                                    {
                                        if (firstoptimvalue > firstObjLength)
                                            addspace = secondoptimvalue;
                                        else addspace = firstoptimvalue + secondoptimvalue - firstObjLength - 3;
                                            for (int i = 0; i < addspace; i++)
                                                ComputerInfo_TEMP += " ";
                                        
                                    }
                                    if (secondObjLenght < 1 && thirdObjLenght < 1)
                                    {
                                        ComputerInfo_TEMP += "\n";
                                    }
                                    if (objItem[2].Length < 2)
                                        objItem[2] = "";
                                    ComputerInfo_TEMP += objItem[2] + "\n";

                                }
                            }
                            UpdateRichTextBox(ComputerInfo_TEMP);
                            if (ComputerInfo_TEMP == null)
                            {
                                text = "slow";
                                goto StartAgainIfReturnedValueIsNull;
                            }
                            break;
                        };
                    case "slow":
                        {

                            ManagementScope scope = new ManagementScope();
                            try
                            {
                                ConnectionOptions options = new ConnectionOptions
                                {
                                    EnablePrivileges = true
                                };

                                scope = new ManagementScope(@"\\" + HostName() + @"\root\CIMV2", options);
                                scope.Connect();
                                //SelectQuery query = new SelectQuery("SELECT * FROM Win32_Product");
                                ManagementObjectSearcher searcher = new ManagementObjectSearcher(new ManagementScope(@"\\" + HostName() + @"\root\CIMV2", options), new SelectQuery("SELECT * FROM Win32_Product"));
                                int nazwa_dlugosc;
                                using (ManagementObjectCollection queryCollection = searcher.Get())
                                {//sprawdzenie maksymalnej wartości dla nazwa
                                    string nazwa = null;
                                    string[] nazwa1 = null;
                                    string wersja = null;
                                    string[] wersja1 = null;
                                    nazwa_dlugosc = 0;
                                    foreach (ManagementObject m in queryCollection)
                                    {   //tworzenie ciągu wszystkich nazw po przecinku
                                        nazwa += m["description"].ToString() + ",";
                                        //tworzenie ciągu wszystkich wersji po przecinku
                                        wersja += m["version"].ToString() + ",";
                                    }
                                    //rozdzielenie całego ciągu na osobne obiekty
                                    nazwa1 = nazwa.Split(',');
                                    wersja1 = wersja.Split(',');

                                    for (int i = nazwa1.Count() - 2; i > 0; i--)
                                    {//szukanie najdłuższego wyrazu
                                        if (nazwa1[i].Length > nazwa_dlugosc)
                                        {
                                            nazwa_dlugosc = nazwa1[i].Length;
                                        }
                                    }
                                    //dodanie pierwszej linijki informacyjnej
                                    ComputerInfo_TEMP+=("Nazwa");
                                    for (int i = 0; i < nazwa_dlugosc - 4; i++)
                                    {
                                        ComputerInfo_TEMP+=(" ");
                                    }
                                    ComputerInfo_TEMP += ("Wersja\n");
                                    //dodanie nazwy i wersji programu linijka pod linijką
                                    for (int i = nazwa1.Count() - 2; i > 0; i--)
                                    {
                                        ComputerInfo_TEMP += (nazwa1[i].ToString());
                                        for (int j = 0; j < nazwa_dlugosc - nazwa1[i].Length + 1; j++)
                                        {
                                            ComputerInfo_TEMP += (" ");
                                        }
                                        ComputerInfo_TEMP += (wersja1[i].ToString() + "\n");
                                    }
                                }
                            }

                            catch (UnauthorizedAccessException)
                            {
                                MessageBox.Show("Nie można połączyć ponieważ dostęp jest wzbroniony na bieżacych poświadczeniach", "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Nie można połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
                            }
                            ReplaceRichTextBox(ComputerInfo_TEMP);
                            break;
                        };
                }
            }
            else return;
            stopTime();
        }

        Stopwatch stopWatch = new Stopwatch();
        
        private void startTime()
        {
            stopWatch.Start();
            UpdateStatusbp1text("Czekaj");
            //timer1.Start();
        }

        private void stopTime()
        {
            //timer1.Stop();
            stopWatch.Stop();
            UpdateStatusbp1text("Gotowe");
            UpdateStatusbp2text("Czas: " + stopWatch.Elapsed.Seconds + "s " + stopWatch.Elapsed.Milliseconds + "ms ");
            stopWatch.Reset();
        }
        private void timer1_Tick(object sender, EventArgs e)
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

        private void szukanieSesji(string termserver, string login)
        {
            string sesjelogs = null;

            try
            {
                System.Diagnostics.Process session = new System.Diagnostics.Process();
                session.StartInfo.FileName = @"C:\Windows\sysnative\query.exe";
                session.StartInfo.Arguments = "user " + login + " /server:" + termserver;
                session.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
                session.StartInfo.CreateNoWindow = true;
                session.StartInfo.UseShellExecute = false;
                session.StartInfo.RedirectStandardOutput = true;
                session.Start();
                session.WaitForExit();
                using (StreamReader reader = session.StandardOutput)
                {
                    if (reader != null)
                        sesjelogs = reader.ReadToEnd() + "\n";
                    string[] tempsesje = sesjelogs.Split('\n');
                    string[] tempsesje1 = null;
                    string tempss = null;
                    for (int j = 0; j < tempsesje.Length - 1; j += 2)
                    {
                        if (tempsesje[j].Length > 1)
                        {
                            int s = 30 + (8 - termserver.Length);
                            UpdateRichTextBox(termserver + "  ");
                            for (int k = 0; k < s; k++)
                                UpdateRichTextBox("-");
                            UpdateRichTextBox("\n");
                            for (int k = 0; k < tempsesje.Length - 1; k++)
                                UpdateRichTextBox(tempsesje[k]);
                            UpdateRichTextBox("\n");
                        }
                    }
                    if (tempsesje[1].Length > 1)
                    {
                        tempsesje1 = tempsesje[1].Split(' ');
                        for (int j = 0; j < tempsesje1.Length; j++)
                            if (tempsesje1[j].Length > 0)
                                tempss += tempsesje1[j] + ",";

                        string[] tempsesje5 = null;
                        if (tempss.Length > 3)
                        {
                            tempsesje5 = tempss.Split(',');
                            if (tempsesje5[2] == "Disc")
                            updateComboBox(tempsesje5[1] + " " + termserver);
                            else updateComboBox(tempsesje5[2] + " " + termserver);
                        }
                    }
                }
                sesjelogs = null;
            }
            catch (Win32Exception)
            {
                UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                UpdateRichTextBox(@"C:\Windows\system32\query.exe");
            }
            if (comboBox1.Items.Count > 0)
                if (comboBox1.InvokeRequired)
                {
                    comboBox1.Invoke(new MethodInvoker(() => comboBox1.SelectedIndex = 0));
                }
        }

        private delegate void updateComboBoxEventHandler(string message);
        private void updateComboBox(string message)
        {
            if (comboBox1.InvokeRequired)
            {
                comboBox1.Invoke(new updateComboBoxEventHandler(updateComboBox), new object[] { message });
            }
            else { comboBox1.Items.Add(message); }
        }
        private string Allowed_workstions()
        { string[] temp = netuserdomain.Split('\n');
            return temp[16].ToString();
        }
        private string Allowed_Hours()
        {
            string[] temp = netuserdomain.Split('\n');
            return temp[22].ToString();
        }
        private string PasswordIsRequired()
        {
            string[] temp = netuserdomain.Split('\n');
            string temp1 = null;
            for (int i = 13; i < 15; i++)
            {
                temp1 += temp[i] + "\n";
            }
            return temp1;
        }

        private string MembersOf()
        {
            string[] temp = netuserdomain.Split('\n');
            string temp1 = null;
            for (int i = 24; i < temp.Count() - 4; i++)
            {
                temp1 += temp[i] + "\n";
            }
            return temp1;
        }
        private void InfozAD_DoWork(object sender, DoWorkEventArgs e)
        {
            startTime();
            ClearRichTextBox("");
            Process p = new Process();
            p.StartInfo.FileName = @"net";
            p.StartInfo.Arguments = @"user " + UserName() + " /domain";
            p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(netuserdomainbloop);
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();

            if (UserName().Trim().Length != 0)
            {
                GetInfo(domainName());
                //1 linijka
                TimeSpan temp = (pwdLastSet.AddDays(30) - DateTime.Now);
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
                UpdateRichTextBox("Nazwa użytkownika:\t\t\t" + loginName + "\n");
                //5 linijka
                UpdateRichTextBox("Pełna nazwa:\t\t\t\t" + displayName + "\n");
                //6 linijka
                UpdateRichTextBox("Komentarz:\t\t\t\t\t" + title + "\n");
                //7 linijka
                UpdateRichTextBox("Firma zatrudniająca:\t\t\t" + company + "\n");
                //8 linijka
                UpdateRichTextBox("Mail:\t\t\t\t\t\t" + mail + "\n");
                //9 linijka
                UpdateRichTextBox("Konto jest aktywne:\t\t\t" + userEnabled + "\n");
                //10 linijka
                UpdateRichTextBox("\n");
                //11 linijka
                UpdateRichTextBox("Konto wygasa:\t\t\t\t" + accountExpires + "\n");  //działa ale jest zła strefa czasowa
                //12 linijka
                if (pwdLastSet < lockoutTime)
                    UpdateRichTextBox("Konto zablokowane:\t\t\t" + lockoutTime + "\n");
                else UpdateRichTextBox("Konto zablokowane:\t\t\t" + "0" + "\n");
                //13 linijka
                UpdateRichTextBox("Ostatnie błędne logowanie:\t\t" + badPasswordTime + "\n"); //działa ale potrzebna jest deklaracja serwera
                //14 linijka
                UpdateRichTextBox("Ilość błędnych prób logowania:\t" + badPwdCount + "\n"); //działa serwerów są 4
                //15 linijka
                UpdateRichTextBox("Dostęp do internetu:\t\t\t" + InternetAccessEnabled + "\n");
                //16 linijka
                UpdateRichTextBox("Hasło ostatnio ustawiono:\t\t" + pwdLastSet + "\n");
                //17 linijka
                UpdateRichTextBox("Hasło wygasa:\t\t\t\t" + pwdLastSet.AddDays(30) + "\n");
                //18 linijka
                UpdateRichTextBox("Hasło może być zmienione:\t\t" + pwdLastSet.AddDays(1) + "\n");
                //19 linijka
                UpdateRichTextBox("\n");
                //20 linijka
                UpdateRichTextBox("Ostatnie logowanie:\t\t\t" + lastLogon + "\n");
                //21 linijka
                if (lastLogoff > lastLogon)
                    UpdateRichTextBox("Ostatnie wylogowanie:\t\t\t\t" + lastLogoff + "\n");
                else UpdateRichTextBox("Ostatnie wylogowanie:\t\t\t" + "0" + "\n");
                //22 linijka
                UpdateRichTextBox("\n");
                //23  i 24 linijka
                UpdateRichTextBox(PasswordIsRequired() + "\n");
                //25
                UpdateRichTextBox(Allowed_workstions() + "\n");
                //26 linijka
                UpdateRichTextBox("Skrypt logowania:\t\t\t\t" + scriptPath + "\n");
                //27 linijka
                UpdateRichTextBox("Katalog macierzysty:\t\t\t" + homeDirectory + "\n");
                //28 linijka
                UpdateRichTextBox("Dysk macierzysty:\t\t\t\t" + homeDrive + "\n");
                //29 linijka
                UpdateRichTextBox("\n");
                //30 linijka
                UpdateRichTextBox(Allowed_Hours());
                //31 linijka
                UpdateRichTextBox("\n");
                //32 linijka
                UpdateRichTextBox(MembersOf());
            }
            stopTime();
        }


        private void button20_Click(object sender, EventArgs e)
        {
            // domainController = null;
            //getDomainControllers();
            DomainController();
            //if(!ladujLogiWTle.IsBusy)
            //ladujLogiWTle.RunWorkerAsync();

            if (domainController !=null && domainController.Length > 1)
            {
                MessageBox.Show(domainController[1]);
            }
           
        }
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
            catch(Exception)
            {
                throw;
            }
        }
        private void osName(string nazwaKomputera, string path, string query)
        {
            ManagementScope scope = new ManagementScope();
            try
            {
                ConnectionOptions options = new ConnectionOptions()
                {
                    EnablePrivileges = true
                };
                scope = new ManagementScope(@"\\" + nazwaKomputera + path, options);
                scope.Connect();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new SelectQuery(query));
                using (ManagementObjectCollection queryCollection = searcher.Get())
                    foreach (ManagementObject m in queryCollection) 
                    {
                        //osname = m["caption"].ToString();
                        osarch = m["osarchitecture"].ToString();
                    }
            }

            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Nie można połączyć ponieważ dostęp jest wzbroniony na bieżacych poświadczeniach", "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Nie można połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }
        }

        //string osname = null;
        string osarch = null;
        private void button21_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox(null);
            Puzzel.Ping.Pinging(HostName());
            if (PingStatus == 0)
            {
                osName(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem);
                string applicationName = null;
                if (osarch.Contains("64-bit"))
                    applicationName = "PsExec64.exe";
                else applicationName = "PsExec.exe";

                if (File.Exists(Directory.GetCurrentDirectory() + @"\" + applicationName))
                {
                    ProcExec Exec = new ProcExec(applicationName, @"\\" + HostName() + " cmd");
                }
                else
                {
                    UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                    UpdateRichTextBox(Directory.GetCurrentDirectory() + @"\" + applicationName);
                }
            }
            else
                UpdateRichTextBox("Stacja: " + HostName() + " nie jest widoczna na sieci");
            stopTime();
        }

        private void KomputerInfoMenuStrip(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox(null);
            Puzzel.Ping.Pinging(HostName());
            if (PingStatus == 0)
            {
                ComputerInfo computerInfo = new ComputerInfo();
                ComputerInfo_TEMP += ("Nazwa komputera: ");
                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "DNSHostName");
                ComputerInfo_TEMP += ("----------------------------------------\n");
                if (sender is ToolStripMenuItem)
                {
                    if (((ToolStripMenuItem)sender).Name == "uptimeToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Uptime: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem, "LastBootUpTime");
                    }

                    if (((ToolStripMenuItem)sender).Name == "nrSeryjnyINrPartiiToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("SN: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystemProduct, "IdentifyingNumber");
                        ComputerInfo_TEMP += ("PN: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathWMI, ComputerInfo.querySystemInformation, "SystemSKU");
                    }

                    if (((ToolStripMenuItem)sender).Name == "modelToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("MODEL: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "Model");
                    }

                    if (((ToolStripMenuItem)sender).Name == "oSToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("OS: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version");
                    }

                    if (((ToolStripMenuItem)sender).Name == "pamięćRAMToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Pamięć TOTAL: \n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryPhysicalMemory, "Capacity");
                        ComputerInfo_TEMP += ("\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber");
                    }

                    if (((ToolStripMenuItem)sender).Name == "procesorToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("CPU \n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProcessor, "Name");
                        ComputerInfo_TEMP += ("Rdzenie: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProcessor, "NumberOfCores");
                        ComputerInfo_TEMP += ("Wątki: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProcessor, "NumberOfLogicalProcessors");
                    }

                    if (((ToolStripMenuItem)sender).Name == "zalogowanyUżytkownikToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Użytkownik: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryComputerSystem, "UserName");
                    }

                    if (((ToolStripMenuItem)sender).Name == "profileUżytkownikówToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Profile\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryDesktop, "Name");
                    }

                    if (((ToolStripMenuItem)sender).Name == "dyskiToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Dyski: \n");
                        ComputerInfo_TEMP += ("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size");
                    }

                    if (((ToolStripMenuItem)sender).Name == "drukarkiSiecioweToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Drukarki sieciowe\n\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryPrinterConfiguration, "DeviceName");
                    }

                    if (((ToolStripMenuItem)sender).Name == "udziałyToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Udziały\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryShare, "Name", "Path", "Description");
                    }

                    if (((ToolStripMenuItem)sender).Name == "autostartToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("AutoStart\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryStartupCommand, "Caption", "Command");
                    }

                    if (((ToolStripMenuItem)sender).Name == "pATHToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Środowisko uruchomieniowe\n");
                        ComputerInfo_TEMP += ("Nazwa zmiennej           Wartość zmiennej\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryEnvironment, "Name", "VariableValue");
                    }

                    if (((ToolStripMenuItem)sender).Name == "zasobySiecioweToolStripMenuItem")
                    {
                        ComputerInfo_TEMP += ("Zasoby sieciowe\n\n");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryNetworkConnection, "LocalName", "RemoteName");
                    }
                }
                if (sender is Button)
                {
                    if (((Button)sender).Name == "button18")
                    {
                        ComputerInfo_TEMP += ("Karty Sieciowe: ");
                        computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryNetworkAdapterConfiguration, "IPEnabled", "Description", "DNSDomainSuffixSearchOrder", "DNSHostName", "IPAddress", "IPSubnet", "MACAddress");
                    }
                }
                UpdateRichTextBox(ComputerInfo_TEMP);
                ComputerInfo_TEMP = null;
            }
            else UpdateRichTextBox("Brak komputera w sieci");
            stopTime();
        }

        private void narzedziaadministracyjne(object sender, EventArgs e)
        {
            startTime();
            Puzzel.Ping.Pinging(HostName());
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
            }
            if (sender is Button)
            {
                if (((Button)sender).Name == "button12")
                    arguments = "compmgmt.msc";
                
            }
            if (PingStatus == 0)
            {
                ProcExec Exec = new ProcExec("mmc.exe", arguments+ @" /computer:\\" + HostName());
            }
            else
            {
                ClearRichTextBox("");
                ProcExec Exec = new ProcExec("mmc.exe", arguments);
            }
            stopTime();
        }

        private void dHCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startTime();
            ProcExec Exec = new ProcExec();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\dhcp.msc"))
                Exec.ProcExecIF("dhcp.msc", @"/64");
            else
            UpdateRichTextBox("Brak pliku" +Directory.GetCurrentDirectory() + @"\dhcp.msc");
            stopTime();
        }

        private void ladujLogiWTle_DoWork(object sender, DoWorkEventArgs e)
        {
         //   GetLogs();
        }



        public static string terminalName = null;
        private void szukanieSesjiCustom(object sender, EventArgs e)
        {
            PodajNazweTerminala podajNazweTerminala = new PodajNazweTerminala();
            Thread thread1 = new Thread(() =>
            {
                podajNazweTerminala.ShowDialog();
            });
            thread1.Start();
            Thread thread;
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Cassia.dll")) 
            {
                TerminalExplorer terminalExplorer = new TerminalExplorer();
                thread1.Join();
                thread = new Thread(() => terminalExplorer.szukanieSesji(terminalName));
                thread.Start();
                terminalExplorer.Show();
            }
            else MessageBox.Show("Plik "+Directory.GetCurrentDirectory() + @"\Cassia.dll nie jest dostępny.");
        }

        private void szukanieSesji(object sender, EventArgs e)
        {
            ClearRichTextBox(null);
            startTime();
            Thread thread;
            foreach (string termserv in termservers)
            {
                thread = new Thread(() => 
                    szukanieSesji(termserv, UserName()));
                thread.Start();
            }
            stopTime();
        }

        public string HostName()
        {
            return textBox2.Text.ToUpper();
        }
        public static string hostname;
        public static string username;
        public string UserName()
        {
            string _UserName = textBox1.Text;
            username = textBox1.Text.ToUpper();
            return _UserName;
        }

        private void lockoutStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserName();
            Lockout_Status LS = new Lockout_Status(UserName());
            LS.Show();
        }

        private void AutoGettingLogs_Tick(object sender, EventArgs e)
        {
            ladujLogiWTle.RunWorkerAsync();
        }
        
        private void wyszukiwanieSesji_TerminalExplorer(object sender, EventArgs e)
        {
            Thread thread;
            if (File.Exists(Directory.GetCurrentDirectory()+@"\Cassia.dll"))
            {
                TerminalExplorer terminalExplorer = new TerminalExplorer();
                thread = new Thread(() => terminalExplorer.szukanieSesji(((ToolStripMenuItem)sender).Text));
                thread.Start();
                terminalExplorer.Show();
            }
            else MessageBox.Show("Plik Cassia.dll nie jest dostępny.");
        }

        public static string PingLicznik="1";
        int licz = 0;
        public static string PingRemoteHost = null;
        private void button22_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox("");
            RemotePing_Tracert remotePing_Tracert = new RemotePing_Tracert();
            remotePing_Tracert.ShowDialog();
            if (PingLicznik != null | PingRemoteHost != null)
            {
                StreamWriter SW = new StreamWriter("remoteping.cmd");
                SW.WriteLine("PsExec64.exe " + @"\\" + HostName() + " ping " + PingRemoteHost + " -n " + PingLicznik + " 1> " + Directory.GetCurrentDirectory() + @"\temp.log");
                SW.Close();
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c remoteping.cmd";
                p.Start();
                p.WaitForExit();
                if (File.Exists(Directory.GetCurrentDirectory() + @"\temp.log"))
                {
                    StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\temp.log");
                    PingRemoteHost = (sr.ReadToEnd());
                    sr.Close();
                }
                licz = PingRemoteHost.IndexOf("Odpowied");
                PingRemoteHost = PingRemoteHost.Replace(PingRemoteHost[licz + 8], 'ź');
                PingRemoteHost = PingRemoteHost.Replace("bźźdzenia", "błądzenia");
                PingRemoteHost = PingRemoteHost.Replace("bajtźw", "bajtów");
                PingRemoteHost = PingRemoteHost.Replace("wysźane", "wysłane");
                PingRemoteHost = PingRemoteHost.Replace("pakietźw", "pakietów");
                PingRemoteHost = PingRemoteHost.Replace("Wysźane", "Wysłane");
                PingRemoteHost = PingRemoteHost.Replace("źredni", "średni");
                UpdateRichTextBox(PingRemoteHost);
                PingRemoteHost = null;
                PingLicznik = null;
                licz = 0;

            }
            if (File.Exists("remoteping.cmd"))
                File.Delete("remoteping.cmd");
            if (File.Exists("temp.log"))
                File.Delete("temp.log");
            stopTime();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox("");
            RemotePing_Tracert remotePing_Tracert = new RemotePing_Tracert();
            remotePing_Tracert.ShowDialog();
            if (PingRemoteHost != null)
            {
                StreamWriter SW = new StreamWriter("remotetracert.cmd");
                SW.WriteLine("PsExec64.exe " + @"\\" + HostName() + " tracert " + PingRemoteHost + " 1> " + Directory.GetCurrentDirectory() + @"\temp.log");
                SW.Close();
                Process p = new Process();
                p.StartInfo.FileName = "CMD";
                p.StartInfo.Arguments = "/c remotetracert.cmd";
                p.Start();
                p.WaitForExit();
                if (File.Exists(Directory.GetCurrentDirectory() + @"\temp.log"))
                {
                    StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\temp.log");
                    PingRemoteHost = (sr.ReadToEnd());
                    sr.Close();
                }
                licz = PingRemoteHost.IndexOf("ledzenie");
                PingRemoteHost = PingRemoteHost.Replace(PingRemoteHost[licz - 1], 'ź');
                PingRemoteHost = PingRemoteHost.Replace("źledzenie", "Śledzenie");
                PingRemoteHost = PingRemoteHost.Replace("maksymalnź", "maksymalną");
                PingRemoteHost = PingRemoteHost.Replace("liczbź", "liczbą");
                PingRemoteHost = PingRemoteHost.Replace("przeskokźw", "przeskoków");
                PingRemoteHost = PingRemoteHost.Replace("zakoźczone", "zakończone");
                UpdateRichTextBox(PingRemoteHost);
                PingRemoteHost = null;
                licz = 0;
            }
            if (File.Exists("remotetracert.cmd"))
                File.Delete("remotetracert.cmd");
            if (File.Exists("temp.log"))
                File.Delete("temp.log");
            stopTime();
        }

        private void CMDMenuItem1_Click(object sender, EventArgs e)
        {
            ProcExec Exec = new ProcExec("cmd", "/u");
        }

        private void PowershellMenuItem2_Click(object sender, EventArgs e)
        {
            ProcExec exec = new ProcExec("powershell", "-noexit Enter-PSSession -ComputerName " + HostName());
        }

        private void cMDSYSTEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startTime();
            ClearRichTextBox(null);
            Puzzel.Ping.Pinging(HostName());
            if (PingStatus == 0)
            {
                osName(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem);
                string applicationName =null;
                if (osarch.Contains("64-bit"))
                    applicationName = "PsExec64.exe";
                else applicationName = "PsExec.exe";

                if (File.Exists(Directory.GetCurrentDirectory() + @"\" + applicationName))
                {
                    ProcExec Exec = new ProcExec(applicationName, @"\\" + HostName() + " -s  cmd");
                }
                else
                {
                    UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                    UpdateRichTextBox(Directory.GetCurrentDirectory() + @"\"+applicationName);
                }
            }
            else
                UpdateRichTextBox("Stacja: " + HostName() + " nie jest widoczna na sieci");
            stopTime();
        }

        private void EADWMenuContext_Click(object sender, EventArgs e)
        {
            startTime();
            if (File.Exists(Working[9].Remove(13)))
            {
                ProcExec Exec = new ProcExec(Working[9].Remove(13), "-m:" + HostName() + " -x -a:2 "+Working[11].Remove(5));
            }
            else
            {
                UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                UpdateRichTextBox(Working[9].Remove(13));
            }
            stopTime();
        }

        string PwdLcl(string computername)
        {
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + domainName());
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(cn=" + computername + ")";
            SearchResult result = search.FindOne();
            string text;
            if (search.FindOne().GetDirectoryEntry().Properties[Working[13].Remove(4)].Value == null)
                text = "";
            else text = search.FindOne().GetDirectoryEntry().Properties[Working[13].Remove(4)].Value.ToString();
            return text;
        }

        string Nazwauzytkownika(string username)
        {
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + domainName());
            myLdapConnection.UsePropertyCache = true;
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(&(objectClass=user)(sAMAccountName=" + username + "))";
            search.PropertiesToLoad.Add("displayName");
            search.PageSize = 1000;
            search.SizeLimit = 1;
            //SearchResult result = search.FindOne();
            string text;
            if (search.FindOne().GetDirectoryEntry().Properties["displayName"].Value == null)
                text = "brak w AD";
            else text = search.FindOne().GetDirectoryEntry().Properties["displayName"].Value.ToString();
            search.Dispose();
            return text;
        }

        string DomainController()
        {
            //DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://OU=Domain Controllers," + domainName());
            DirectorySearcher search = new DirectorySearcher(new DirectoryEntry("LDAP://" + domainName()));
            //search.Filter = "(sAMAccountName=" + username + ")";
            SearchResult search1 = search.FindOne();
            //SearchResultCollection collection = search.FindAll();
            object[] lines = (object[])search1.GetDirectoryEntry().Properties["msds-isdomainfor"].Value;
            string table = null;
            foreach (string line in lines)
            {
                string[] words = line.Split(',');
                table += words[1].Replace("CN=", "") + ",";
            }
            return table;
        }

        private void DyDWContextMenu_Click(object sender, EventArgs e)
        {
            startTime();
            if (PwdLcl(HostName()) > 1)
	            if(File.Exists(Working[9].Remove(13)))
	            {
	                ProcExec Exec = new ProcExec(Working[9].Remove(13), "-m:" + HostName() + " -x -a:2 "+Working[12].Remove(6)+ PwdLcl(HostName()) + " -d:");
	            }
	            else
	            {
	                UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
	                UpdateRichTextBox(Working[9].Remove(13));
	            }
	        else MessageBox.Show("Brak hasła");
            stopTime();
        }

        private void rDPBezPustyContextMenu_Click(object sender, EventArgs e)
        {
            startTime();
            ProcExec Exec = new ProcExec(ProcExec.rdp, "");
            stopTime();
        }
        
        private void Keys_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                szukajLogow(sender,e);
            }

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (richTextBox1.Focused)
                    if (richTextBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(richTextBox1.SelectedText) && !string.IsNullOrWhiteSpace(richTextBox1.SelectedText))
                        Clipboard.SetText(richTextBox1.SelectedText.Trim(' '));

                if (textBox1.Focused)
                    if (textBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox1.SelectedText) && !string.IsNullOrWhiteSpace(textBox1.SelectedText))
                        Clipboard.SetText(textBox1.SelectedText.Trim(' '));

                if (textBox2.Focused)
                    if (textBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(textBox2.SelectedText) && !string.IsNullOrWhiteSpace(textBox2.SelectedText))
                        Clipboard.SetText(textBox2.SelectedText.Trim(' '));

                if (comboBox1.Focused)
                    if (comboBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox1.SelectedText) && !string.IsNullOrWhiteSpace(comboBox1.SelectedText))
                        Clipboard.SetText(comboBox1.SelectedText.Trim(' '));
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
                if (comboBox1.Focused)
                {
                    Clipboard.GetText(TextDataFormat.UnicodeText);
                }
            }

            if (e.Control && e.KeyCode == Keys.X)
            {
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

                if (comboBox1.Focused)
                    if (comboBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox1.SelectedText) && !string.IsNullOrWhiteSpace(comboBox1.SelectedText))
                    {
                        Clipboard.SetText(comboBox1.SelectedText.TrimEnd(' '));
                        comboBox1.Text.Remove(comboBox1.SelectionStart, comboBox1.SelectionLength);
                        Clipboard.SetText(Clipboard.GetText().Trim(' '));
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

                if (comboBox1.Focused)
                    comboBox1.SelectAll();
            }
        }

        private void kopiujMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
                if (richTextBox1.SelectedText.Length > 0)
                    Clipboard.SetText(richTextBox1.SelectedText.Trim(' '));

            if (textBox1.Focused)
                if (textBox1.SelectedText.Length > 0)
                    Clipboard.SetText(textBox1.SelectedText.Trim(' '));

            if (textBox2.Focused)
                if (textBox2.SelectedText.Length > 0)
                    Clipboard.SetText(textBox2.SelectedText.Trim(' '));

            if (comboBox1.Focused)
                if (comboBox1.SelectedText.Length > 0)
                    Clipboard.SetText(comboBox1.SelectedText.Trim(' '));
        }

        private void wytnijMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.Cut();
                    Clipboard.SetText(Clipboard.GetText().Trim(' '));
                }

            if (textBox1.Focused)
                if (textBox1.SelectedText.Length > 0)
                {
                    textBox1.Cut();
                    Clipboard.SetText(Clipboard.GetText().Trim(' '));
                }

            if (textBox2.Focused)
                if (textBox2.SelectedText.Length > 0)
                {
                    textBox2.Cut();
                    Clipboard.SetText(Clipboard.GetText().Trim(' '));
                }

            if (comboBox1.Focused)
                if (comboBox1.SelectedText.Length > 0)
                {
                    string test = comboBox1.SelectedText.Replace(" ", "");
                    comboBox1.Text.Replace(comboBox1.SelectedText, "");
                    Clipboard.SetText(Clipboard.GetText().Trim(' '));
                }
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (comboBox1.Focused)
            {
                comboBox1.Text.Insert(comboBox1.SelectionStart,Clipboard.GetText());
            }
        }

        private void zaznaczWszystkoMenuItem3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Focused)
                richTextBox1.SelectAll();

            if (textBox1.Focused)
                textBox1.SelectAll();

            if (textBox2.Focused)
                textBox2.SelectAll();

            if (comboBox1.Focused)
                comboBox1.SelectAll();
        }
    }
}        
 