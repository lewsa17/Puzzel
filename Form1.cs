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

namespace Puzzel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Working = File.ReadAllLines("DefaultValue.txt");
            InitializeComponent();
            //AutoGettingLogs.Start();
            //if (File.Exists(Directory.GetCurrentDirectory() + @"\UserLogCache.log") && File.Exists(Directory.GetCurrentDirectory() + @"\ComputerLogCache.log.log"))
            //{
            //    Logi logi = new Logi(UserName(), HostName());
            //    progressBar = new System.Threading.Thread(logi.LoadLogs);
            //    Puzzel.Form1.ProgressMax = 2;
            //    LoadingForm loadingForm = new LoadingForm();
            //    System.Threading.Thread progress = new System.Threading.Thread(loadingForm.progress);
            //    progressBar.Start();
            //    progress.Start();
            //}
            //else
            //{
            //    progressBar = new System.Threading.Thread(GetLogs);
            //    Puzzel.Form1.ProgressMax = 8;
            //    LoadingForm loadingForm = new LoadingForm();
            //    System.Threading.Thread progress = new System.Threading.Thread(loadingForm.progress);
            //    progressBar.Start();
            //    progress.Start();
            //}*/

        }
        //private void GetLogs()
        //{
        //    Logi logi = new Logi(UserName(), HostName());
        //    logi.GetLogs();
        //    logi.SaveLogs();
        //    logi.LoadLogs();
        //}
        //public static void InvokeProgress()
        //{
        //    Progress progress = new Progress();
        //    if (progress.InvokeRequired)
        //    {
        //        progress.Invoke(new MethodInvoker(() =>
        //        {
        //            progress.Show();
        //        }));
        //    }

        //}
        public static Thread progressBar;// = new System.Threading.Thread(InvokeProgress);
        public DirectorySearcher dirsearch = null;
        public static string DomainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }
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
        private void ReplaceRichTextBox(string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new ReplaceRichTextBoxEventHandler(ReplaceRichTextBox), new object[] { message });
            }
            else { richTextBox1.Text = message; }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            StartTime();
            if (HostName().Length > 0)
            {
                if (Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    new ProcExec(ProcExec.rdp, ProcExec.rdp_args + HostName());
                }
                else ReplaceRichTextBox("Niewidoczny na sieci");
            }
            else ReplaceRichTextBox("Nie podano nazwy hosta");
            StopTime();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            StartTime();
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
                p.OutputDataReceived += new DataReceivedEventHandler(POutputHandler);
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
                n.OutputDataReceived += new DataReceivedEventHandler(POutputHandler);
                n.Start();
                n.BeginOutputReadLine();
                n.WaitForExit();
            }
            else ReplaceRichTextBox("Nie podano nazwy hosta");
            StopTime();
        }
        private void Profilsieciowy(object sender, EventArgs e)
        {
            StartTime();
            string folder = null;
            if (((Button)sender).Name == "button4")
                folder = ProcExec.vfs;

            if (((Button)sender).Name == "button3")
                folder = ProcExec.eri;

            if (((Button)sender).Name == "button6")
                folder = ProcExec.net;

            if (((Button)sender).Name == "button5")
                folder = ProcExec.ext;

            if (Directory.Exists(folder))
                new ProcExec(ProcExec.explorer, folder + UserName());
            else ReplaceRichTextBox("Katalog jest niedostępny");
            StopTime();
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            StartTime();
            if (HostName().Length > 0)
            {
                if (Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    new ProcExec(ProcExec.explorer, @"\\" + HostName() + @"\c$");
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
                LogsCollector.Loger(ex, WindowState.ToString());
            }
        }

        public void Button8_Click(object sender, EventArgs e)
        {
            StartTime();
            string[] SlowowTekscie = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(' ');
            try
            {
                if (comboBox1.Items.Count > 0)
                {
                    if (comboBox1.SelectedIndex >= 0)
                    {
                        TerminalExplorer Term = new TerminalExplorer();
                        Term.ConnectToSession(SlowowTekscie[1], Convert.ToInt16(SlowowTekscie[0]));
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
                LogsCollector.Loger(ex, SlowowTekscie[1]);
            }
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

        private delegate void ClearRichTextBoxEventHandler(string sign);
        private void ClearRichTextBox(string sign)
        {
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new ClearRichTextBoxEventHandler(ClearRichTextBox), new object[] { sign });
            }
            else ReplaceRichTextBox(null);
        }

        string combobox2_last = null;
        string combobox3_last = null;
        private void SzukajLogow(object sender, EventArgs e)
        {
            ClearRichTextBox(null);
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            StartTime();
            int NameLength = 0;
            string senderZ = null;
            decimal counter = 0;
            string NameZ = null;

            if (sender is Button)
            {
                if (((Button)sender).Name == "button1")
                {
                    senderZ = "User";
                    counter = numericUpDown1.Value;
                    NameZ = UserName();
                    NameLength = NameZ.Length;
                }
                if (((Button)sender).Name == "button10")
                {
                    senderZ = "Computer";
                    counter = numericUpDown2.Value;
                    NameZ = HostName();
                    NameLength = NameZ.Length;
                }
            }

            if (sender is ComboBox)
            {
                if (((ComboBox)sender).Name == "comboBox2")
                {
                    senderZ = "User";
                    counter = numericUpDown1.Value;
                    NameZ = UserName();
                    NameLength = NameZ.Length;
                }
                if (((ComboBox)sender).Name == "comboBox3")
                {
                    senderZ = "Computer";
                    counter = numericUpDown2.Value;
                    NameZ = HostName();
                    NameLength = NameZ.Length;
                }
            }
            if (NameLength > 1)
            {
                if (comboBox2.Text.Length > 0)
                    if (comboBox2.Text != combobox2_last)
                    {
                        combobox2_last = comboBox2.Text;
                        comboBox2.Items.Add(combobox2_last);
                    }
                if (comboBox3.Text.Length > 0)
                    if (comboBox3.Text != combobox3_last)
                    {
                        combobox3_last = comboBox3.Text;
                        comboBox3.Items.Add(combobox3_last);
                    }

                if (Directory.Exists(Working[8].Remove(8)))
                {
                    Logi logi = new Logi();

                    int invalidPathChars = 0;
                    foreach (char invalidPathChar in Path.GetInvalidFileNameChars())
                    {
                        if (NameZ.Contains(invalidPathChar))
                            invalidPathChars++;
                    }
                    if (invalidPathChars == 0)
                    {
                        logi.contains(NameZ, senderZ);
                        if (logi.LogNames().Count() > 0)
                        {
                            foreach (string LogsName in logi.LogNames())
                            {
                                Thread thread = new Thread(() =>
                                UpdateRichTextBox(logi.loGi(LogsName, senderZ, counter)));
                                thread.Start();
                            }
                        }
                        else ReplaceRichTextBox("Brak w logach");
                    }
                    else ReplaceRichTextBox("Użyto niedozwolonych znaków w loginie lub nazwie komputera");
                }
                else MessageBox.Show("Brak dostępu do zasobu");

                if (comboBox1.InvokeRequired)
                    comboBox1.Invoke(new MethodInvoker(() =>
                    {
                        comboBox1.Text = "";
                        comboBox1.Items.Clear();
                    }));
            }
            else ReplaceRichTextBox("Za mało danych");
            statusBar1.Focus();
            StopTime();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            StartTime();
            string[] SlowowTekscie = comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(' ');
            try
            {
                if (comboBox1.Items.Count > 0)
                {
                    if (comboBox1.SelectedIndex >= 0)
                    {
                        //if (File.Exists(Directory.GetCurrentDirectory() + @"\Cassia.dll"))
                        //{
                            TerminalExplorer Term = new TerminalExplorer();
                            Term.LogoffSession(SlowowTekscie[1], Convert.ToInt16(SlowowTekscie[0]));
                        //}
                        //else MessageBox.Show("Plik Cassia.dll nie jest dostępny.");
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
                LogsCollector.Loger(ex, SlowowTekscie[1]);
            }
            StopTime();
        }
        public static string terminalName = null;
        private void SzukanieSesjiCustom(object sender, EventArgs e)
        {
            PodajNazweTerminala podajNazweTerminala = new PodajNazweTerminala();
            Thread thread1 = new Thread(() =>
            {
                podajNazweTerminala.ShowDialog();
            });
            thread1.Start();
            Thread thread;
            //if (File.Exists(Directory.GetCurrentDirectory() + @"\Cassia.dll"))
            //{
                TerminalExplorer terminalExplorer = new TerminalExplorer();
                thread1.Join();
                thread = new Thread(() => terminalExplorer.SzukanieSesji(terminalName));
                thread.Start();
                terminalExplorer.Show();
            //}
            //else MessageBox.Show("Plik " + Directory.GetCurrentDirectory() + @"\Cassia.dll nie jest dostępny.");
        }
        private void WyszukiwanieSesji_TerminalExplorer(object sender, EventArgs e)
        {
            Thread thread;
            //if (File.Exists(Directory.GetCurrentDirectory() + @"\Cassia.dll"))
            //{
                TerminalExplorer terminalExplorer = new TerminalExplorer();
                thread = new Thread(() => terminalExplorer.SzukanieSesji(((ToolStripMenuItem)sender).Text));
                thread.Start();
                terminalExplorer.Show();
            //}
            //else MessageBox.Show("Plik Cassia.dll nie jest dostępny.");
        }

        public static string ComputerInfo_TEMP;
        private void DWButton_Click(object sender, EventArgs e)
        {
            StartTime();
            try
            {
	            if (File.Exists(Working[9].Remove(13)))
	            {
	            	if (sender is Button)
	            	{
	                	ProcExec Exec = new ProcExec(Working[9].Remove(13), "-m:" + HostName() + " -x -a:1");
					}
					else
					{
						string login = null;
						string pwd = null;
						if (sender is ToolStripMenuItem)
						{
							if (((ToolStripMenuItem)sender).Text.Contains(Working[14].Remove(9)))
	                        {
	                            login = Working[14].Remove(9);
	                            pwd = LAPSui.PwdLcl(HostName());
	                        }
	                        else
	                        {
	                            login = Working[15].Remove(9);
	                            pwd = Working[17];
	                        }
	                        if (pwd.Length > 1)
	                        {
	                            ProcExec Exec = new ProcExec(Working[9].Remove(13), "-m:" + HostName() + " -x -a:2 -u:" + login + " -p:" + pwd + " -d:");
							}
                        	else MessageBox.Show("Brak hasła");
                        }
                    }
                }
                else
                {
                    UpdateRichTextBox("Nie można odnaleźć określonego pliku\n");
                    UpdateRichTextBox(Working[9].Remove(13));
				}
            }
            catch (Exception ex)
            {
                LogsCollector.Loger(ex, "DWButton_Click");
            }
            StopTime();
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

#pragma warning disable IDE0051 // Usuń nieużywane prywatne składowe
        private string SearchProperty(string propertyName)
#pragma warning restore IDE0051 // Usuń nieużywane prywatne składowe
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + DomainName());
            DirectorySearcher searcher = new DirectorySearcher(entry);
            SearchResult searchResult = searcher.FindOne();
            ResultPropertyValueCollection valueCollection = searchResult.Properties[propertyName];
            string temp = null;
            if (valueCollection != null)
                temp = valueCollection.ToString();
            return temp;
        }

        SearchResult GetInfo(string domain)
        {
            Cursor.Current = Cursors.WaitCursor;
#pragma warning disable IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
            SearchResult rs = null;
#pragma warning restore IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
            if (UserName().Trim().IndexOf("@") > 0)
                rs = SearchByEmail(GetDirectorySearcher(domain), UserName().Trim());
            else
                rs = SearchByUserName(GetDirectorySearcher(domain), UserName().Trim());

            if (rs != null)
                ShowUserInformation(rs);
            else
            {
                MessageBox.Show("User not found!", "Search Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return rs;
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
        string permittedWorkstation = null;
        string SkypeLogin = null;

        string Groups = null;
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
                UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, UserName());
                //? - to mark DateTime type as nullable

                if (user.Enabled != null)
                {
                    if (user.Enabled == true) userEnabled = "TAK";
                    if (user.Enabled == false) userEnabled = "NIE";
                }
                else userEnabled = "błąd";

                if (user.BadLogonCount >= 0)
                    badPwdCount = (int)user.BadLogonCount;

                if (user.HomeDirectory != null)
                    homeDirectory = user.HomeDirectory;

                if (user.PermittedWorkstations.Count > 0)
                {
                    foreach (var permiWorks in user.PermittedWorkstations)
                    {
                        permittedWorkstation += permiWorks.ToString() + "\n\t\t\t\t\t\t";
                    }
                }
                else permittedWorkstation = "Wszystkie";

                if (user.LastPasswordSet != null)
                {
                    pwdLastSet = DateTime.FromFileTime(user.LastPasswordSet.Value.ToFileTime());
                }
                //if (user.PermittedLogonTimes != null)
                //{
                //    var zone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                //    var time = new LogonTime(DayOfWeek.Monday,
                //         new DateTime(2011, 1, 1, 8, 0, 0),
                //         new DateTime(2011, 1, 1, 10, 0, 0), zone);
                //    var times = new List<LogonTime>();
                //    times.add(time);
                //    var mask = PermittedLogonTimes.GetByteMask(times);

                //    var times = PermittedLogonTimes.GetLogonTimes(mask);
                //}
                //    permittedLogonTime = user.PermittedLogonTimes;

                if (user.GetGroups() != null)
                    foreach (var groups in user.GetGroups())
                        Groups += groups.SamAccountName + "\n\t\t\t\t\t\t";
                if (user.LastBadPasswordAttempt.Value != null)
                {
                    badPasswordTime = DateTime.FromFileTime(user.LastBadPasswordAttempt.Value.ToFileTime());
                }
                if (user.HomeDrive != null)
                    homeDrive = (string)user.HomeDrive;

                if (user.LastBadPasswordAttempt != null)
                    lastBadPwdAttempt = (DateTime)user.LastBadPasswordAttempt;

                if (user.ScriptPath != null)
                    scriptPath = (string)user.ScriptPath;

                //if (user.PasswordNotRequired)
                //{
                    if (user.PasswordNotRequired == true) passwordNotRequired = "NIE";
                    else if (user.PasswordNotRequired == false) passwordNotRequired = "TAK";
                //}
                //else passwordNotRequired = "Błąd";

                //if (user.UserCannotChangePassword)
                //{
                    if (user.UserCannotChangePassword == true) userCannotChangePassword = "NIE";
                    else if (user.UserCannotChangePassword == false) userCannotChangePassword = "TAK";
                //}
                //else userCannotChangePassword = "Błąd";
            }

            if (rs.GetDirectoryEntry().Properties["msRTCSIP-PrimaryUserAddress"].Value != null)
            {
                SkypeLogin = rs.GetDirectoryEntry().Properties["msRTCSIP-PrimaryUserAddress"].Value.ToString();
            }
            else SkypeLogin = "Brak loginu";
            if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value != null)
            {
                if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "True")
                    InternetAccessEnabled = "TAK";
                if (rs.GetDirectoryEntry().Properties["msRTCSIP-InternetAccessEnabled"].Value.ToString() == "False")
                    InternetAccessEnabled = "NIE";
            }
            else InternetAccessEnabled = "Błąd, brak obiektu";
            
            if (rs.Properties.Contains("lastLogoff"))
                if (rs.Properties["lastlogoff"][0].ToString() != "0")
            {
                long temp = (long)rs.GetDirectoryEntry().Properties["lastLogoff"].Value;
                lastLogoff = DateTime.FromFileTime(temp);
            }

            if (rs.Properties.Contains("lastlogon"))
            if (rs.Properties["lastLogon"][0].ToString() != "0")
            {
                long temp = (long)rs.Properties["lastLogon"][0];
                lastLogon = DateTime.FromFileTime(temp);
            }

            if (rs.Properties.Contains("accountExpires"))
            if (rs.GetDirectoryEntry().Properties["accountExpires"] != null)
            {
                long temp = (long)rs.Properties["accountExpires"][0];
                accountExpires = DateTime.FromFileTime(temp);
            }

            if (rs.GetDirectoryEntry().Properties.Contains("lockoutTime"))
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

        public ArrayList GetUserGroups(string UserName)
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

        private void Button2_Click(object sender, EventArgs e)
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
            ClearRichTextBox(null);

            if (UserName().Length != 0)
            {
                if (GetInfo(DomainName()) != null)
                {
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
                    UpdateRichTextBox("Adres logowania Skype: \t\t\t" + SkypeLogin.Replace("sip:","") + "\n");
                    //10 linijka
                    UpdateRichTextBox("Konto jest aktywne:\t\t\t" + userEnabled + "\n");
                    //11 linijka
                    UpdateRichTextBox("\n");
                    //12 linijka
                    UpdateRichTextBox("Konto wygasa:\t\t\t\t" + accountExpires + "\n");  //działa ale jest zła strefa czasowa
                    //13 linijka                                                                     //12 linijka
                    if (pwdLastSet < lockoutTime)
                        UpdateRichTextBox("Konto zablokowane:\t\t\t" + lockoutTime + "\n");
                    else UpdateRichTextBox("Konto zablokowane:\t\t\t" + "0" + "\n");
                    //14 linijka
                    UpdateRichTextBox("Ostatnie błędne logowanie:\t\t" + badPasswordTime + "\n"); //działa ale potrzebna jest deklaracja serwera
                    //15 linijka
                    UpdateRichTextBox("Ilość błędnych prób logowania:\t" + badPwdCount + "\n"); //działa serwerów są 4
                    //16 linijka                                                                            
                    UpdateRichTextBox("Dostęp do internetu:\t\t\t" + InternetAccessEnabled + "\n");
                    //17 linijka
                    UpdateRichTextBox("Hasło ostatnio ustawiono:\t\t" + pwdLastSet + "\n");
                    //18 linijka
                    UpdateRichTextBox("Hasło wygasa:\t\t\t\t" + pwdLastSet.AddDays(30) + "\n");
                    //19 linijka
                    UpdateRichTextBox("Hasło może być zmienione:\t\t" + pwdLastSet.AddDays(1) + "\n");
                    //20 linijka
                    UpdateRichTextBox("\n");
                    //21 linijka
                    UpdateRichTextBox("Ostatnie logowanie:\t\t\t" + lastLogon + "\n");
                    //22 linijka
                    if (lastLogoff > lastLogon)
                        UpdateRichTextBox("Ostatnie wylogowanie:\t\t\t\t" + lastLogoff + "\n");
                    else UpdateRichTextBox("Ostatnie wylogowanie:\t\t\t" + "0" + "\n");
                    //23 linijka
                    UpdateRichTextBox("\n");
                    //24 linijka
                    UpdateRichTextBox("Czy hasło jest wymagane? \t\t"+passwordNotRequired + "\n");
                    //25 linijka
                    UpdateRichTextBox("Użytkownik nie może zmienić hasła \t" + userCannotChangePassword+"\n");
                    //26 linijka
                    UpdateRichTextBox(/*Allowed_workstions() */"Dozwolone stacje robocze:\t\t" + permittedWorkstation + "\n");
                    //27 linijka
                    UpdateRichTextBox("Skrypt logowania:\t\t\t\t" + scriptPath + "\n");
                    //28 linijka
                    UpdateRichTextBox("Katalog macierzysty:\t\t\t" + homeDirectory + "\n");
                    //29 linijka
                    UpdateRichTextBox("Dysk macierzysty:\t\t\t\t" + homeDrive + "\n");
                    //30 linijka
                    UpdateRichTextBox("\n");
                    //31 linijka
                    //UpdateRichTextBox(/*Allowed_Hours()*/ permittedLogonTime.ToString());
                    UpdateRichTextBox("\n");
                    //32 linijka
                    UpdateRichTextBox(/*MembersOf()*/"Członkowsta grup:\t\t\t\t"+Groups.ToString());
                }
                else UpdateRichTextBox("Nie znaleziono użytkownika w AD");
            }
            StopTime();
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox(null);
            Process p = new Process();
            p.StartInfo.FileName = @"ipconfig";
            p.StartInfo.Arguments = @"/flushdns";
            p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(852);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(POutputHandler);
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
            StopTime();
        }

        private void KomputerInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar.Start();
        }

        private void KomputerInfoCOMM()
        {
            StartTime();
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
            ComputerInfo_TEMP += ("----------------------------------------\n");
            ComputerInfo_TEMP += ("Podłączone ekrany\n");
            computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status");
            ComputerInfo_TEMP += ("----------------------------------------\n");
            ComputerInfo_TEMP += ("BIOS\n");
            computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryBios, "Manufacturer", "BIOSVersion", "SMBIOSBIOSVersion", "ReleaseDate");

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

        private void SzukanieSesji(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            richTextBox1.Clear();
            int aktywnesesje = 0;
            if (UserName().Length > 1)
            {
                    StartTime();
                foreach (string terms in termservers)
                {
                    Thread th = new Thread(() =>
                    {
                        //try
                        //if (comboBox1.Items.Count > 0)

                        TerminalExplorer ts = new TerminalExplorer();
                        object[] combo = ts.FindSession(terms, UserName());
                        if (combo != null)
                        {
                            aktywnesesje++;
                            UpdateComboBox(combo[0] + " " + combo[1]);
                            if (comboBox1.InvokeRequired)
                            {
                                Thread.Sleep(500);
                                comboBox1.Invoke(new MethodInvoker(() =>
                                {
                                    if (comboBox1.Items.Count > 0)
                                        comboBox1.SelectedIndex = 0;
                                }));
                            }
                            else comboBox1.SelectedIndex = 0;
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
                StopTime();
            }
        }

        private delegate void updateComboBoxEventHandler(string message);
        private void UpdateComboBox(string message)
        {
            if (comboBox1.InvokeRequired)
            {
                comboBox1.Invoke(new updateComboBoxEventHandler(UpdateComboBox), new object[] { message });
            }
            else { comboBox1.Items.Add(message); }
        }       
        private void Button20_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ClientSize.ToString()+"\n"
                + richTextBox1.ClientSize.ToString()+"\n"
                + Size.ToString()+"\n"
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
#pragma warning disable IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
            ManagementScope scope = new ManagementScope();
#pragma warning restore IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
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
            catch (UnauthorizedAccessException ex)
            {
                LogsCollector.Loger(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Dostęp zabroniony na obecnych poświadczeniach", "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception ex)
            {
                LogsCollector.Loger(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Nie można się połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return osarch;
        }
        private void Button21_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox(null);
            try
            {
                if (HostName().Length > 0)
                {
                    if (Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        var OSName = OsName(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem);
                        string applicationName = null;
                        if (OSName.Contains("64-bit"))
                            applicationName = "PsExec64.exe";
                        else applicationName = "PsExec.exe";

                        if (File.Exists(Directory.GetCurrentDirectory() + @"\" + applicationName))
                        {
                            ProcExec Exec = new ProcExec(applicationName, @"\\" + HostName() + " cmd");
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
                LogsCollector.Loger(ex, HostName() + "," + ComputerInfo.pathCIMv2 + "," + ComputerInfo.queryOperatingSystem);
            }
            StopTime();
        }

        private void KomputerInfoMenuStrip(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox(null);
            if (HostName().Length > 0)
            {
                if (Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    if (Ping.TCPPing(HostName(), 135) == Ping.TCPPingStatus.Success)
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

                            if (((ToolStripMenuItem)sender).Name == "ekranyPodłączoneToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("Podłączone ekrany\n\n");
                                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status");
                            }

                            if (((ToolStripMenuItem)sender).Name == "bIOSToolStripMenuItem")
                            {
                                ComputerInfo_TEMP += ("BIOS\n\n");
                                computerInfo.Fast2(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryBios);
                            }
                        }
                        if (sender is Button)
                        {
                            if (((Button)sender).Name == "button18")
                            {
                                ComputerInfo_TEMP += ("Karty Sieciowe: ");
                                computerInfo.GetInfo(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryNetworkAdapterConfiguration, "IPEnabled", "Description", "DNSDomainSuffixSearchOrder", "DNSHostName", "IPAddress", "IPSubnet", "MACAddress");
                            }

                            if (((Button)sender).Name == "button16")
                            {
                                computerInfo.Fast(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryProduct);
                            }

                            if (((Button)sender).Name == "button13")
                            {
                                if (MessageBox.Show(new Form() { TopMost = true }, "Wyszukiwanie może chwile potrwać, zezwolić ?", "Wyszukiwanie danych", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    if (!komputerInfo.IsBusy)
                                    {
                                        ClearRichTextBox(null);
                                        Puzzel.Form1.ProgressMax = 19;
                                        LoadingForm loadingForm = new LoadingForm();
                                        System.Threading.Thread progress;
                                        progress = new System.Threading.Thread(loadingForm.progress);
                                        progress.Start();
                                        progressBar = new System.Threading.Thread(KomputerInfoCOMM);
                                        komputerInfo.RunWorkerAsync();
                                    }
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
            }
            if (sender is Button)
            {
                if (((Button)sender).Name == "button12")
                    arguments = "compmgmt.msc";

            }
            if (HostName().Length > 0)
                if (Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    new ProcExec("mmc.exe", arguments + @" /computer:\\" + HostName());
                }
                else
                {
                    ClearRichTextBox("");
                    new ProcExec("mmc.exe", arguments);
                }
            StopTime();
        }

        private void DHCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTime();
            ProcExec Exec = new ProcExec();
            if (File.Exists(Directory.GetCurrentDirectory() + @"\dhcp.msc"))
                Exec.ProcExecIF("mmc.exe", "dhcp.msc");
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
        public static string hostname;
        public static string username;
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
            Lockout_Status LS = new Lockout_Status(UserName());
            if (UserName().Length > 0)
            {
                if (Lockout_Status.UserInfo(UserName()) != null)
                {
                    Lockout_Status.AddEntry(UserName());
                    LS.Show();
                }
            }
            else
                LS.Show();
        }

        public static string PingLicznik = "1";
        int licz = 0;
        public static string PingRemoteHost = null;
        private void Button22_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox("");
            RemotePing_Tracert remotePing_Tracert = new RemotePing_Tracert();
            remotePing_Tracert.ShowDialog();
            if (PingRemoteHost != null)
            {
                if (PingLicznik == null)
                    PingLicznik = "5";
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
            StopTime();
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            StartTime();
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
            StopTime();
        }

        private void CMDMenuItem1_Click(object sender, EventArgs e)
        {
            new ProcExec("cmd", "/u");
        }

        private void PowershellMenuItem2_Click(object sender, EventArgs e)
        {
            new ProcExec("powershell", "-noexit Enter-PSSession -ComputerName " + HostName());
        }

        private void CMDSYSTEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTime();
            ClearRichTextBox(null);
            if (HostName().Length > 0)
            {
                if (Ping.Pinging(HostName()) == System.Net.NetworkInformation.IPStatus.Success)
                {
                    var OSName = OsName(HostName(), ComputerInfo.pathCIMv2, ComputerInfo.queryOperatingSystem);
#pragma warning disable IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
                    string applicationName = null;
#pragma warning restore IDE0059 // Wartość przypisana do symbolu nie jest nigdy używana
                    if (OSName.Contains("64-bit"))
                        applicationName = "PsExec64.exe";
                    else applicationName = "PsExec.exe";

                    if (File.Exists(Directory.GetCurrentDirectory() + @"\" + applicationName))
                    {
                        new ProcExec(applicationName, @"\\" + HostName() + " -s  cmd");
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
            new ProcExec(ProcExec.rdp, "");
            StopTime();
        }
        private void Keys_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).Name != "comboBox1")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SzukajLogow(sender, e);
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
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        private void Keys_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                CloseClipboard();
                if (e.KeyCode == Keys.Enter)
                {
                    if (sender is TextBox /*|| (sender is ComboBox && ((ComboBox)sender).Name != "comboBox1")*/)
                    {
                        SzukajLogow(sender, e);
                    }
                }
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

                    if (comboBox1.Focused)
                        if (comboBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox1.SelectedText) && !string.IsNullOrWhiteSpace(comboBox1.SelectedText))
                        {
                            comboBox1.Text = comboBox1.Text.Trim(' ');
                            comboBox1.SelectAll();
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBox1.SelectedText.Trim());
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
                    if (comboBox1.Focused)
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

                    if (comboBox1.Focused)
                        if (comboBox1.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox1.SelectedText) && !string.IsNullOrWhiteSpace(comboBox1.SelectedText))
                        {
                            //Thread.Sleep(250);
                            Clipboard.SetText(comboBox1.SelectedText);
                            comboBox1.Text.Remove(comboBox1.SelectionStart, comboBox1.SelectionLength);
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

                    if (comboBox1.Focused)
                        comboBox1.SelectAll();

                    if (comboBox2.Focused)
                        comboBox2.SelectAll();

                    if (comboBox3.Focused)
                        comboBox3.SelectAll();
                }
            }
            catch (Exception ex)
            {
                LogsCollector.Loger(ex, sender + " " + e.KeyCode);
            }
        }
        private void KopiujMenuItem1_Click(object sender, EventArgs e)
        {
            try
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

                if (comboBox2.Focused)
                    if (comboBox2.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox2.SelectedText) && !string.IsNullOrWhiteSpace(comboBox2.SelectedText))
                        Clipboard.SetText(comboBox2.SelectedText.Trim(' '));

                if (comboBox3.Focused)
                    if (comboBox3.SelectedText.Length > 0 && !string.IsNullOrEmpty(comboBox3.SelectedText) && !string.IsNullOrWhiteSpace(comboBox3.SelectedText))
                        Clipboard.SetText(comboBox3.SelectedText.Trim(' '));
            }
            catch (Exception ex)
            {
                LogsCollector.Loger(ex, "Kopiowanie_ContextMenuText");
            }
        }

        private void WytnijMenuItem1_Click(object sender, EventArgs e)
        {
            try
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
                        Clipboard.SetText(comboBox1.SelectedText);
                        comboBox1.Text = comboBox1.Text.Remove(comboBox1.SelectionStart, comboBox1.SelectionLength);
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
                LogsCollector.Loger(ex, "Wycinanie_ContextMenuText");
            }
        }

        private void WklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
                    comboBox1.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
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
                LogsCollector.Loger(ex, "Wklej_ContextMenuText");
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

                if (comboBox1.Focused)
                    comboBox1.SelectAll();

                if (comboBox2.Focused)
                    comboBox2.SelectAll();

                if (comboBox3.Focused)
                    comboBox3.SelectAll();
            }
            catch (Exception ex)
            {
                LogsCollector.Loger(ex, "zaznaczWszystko_ConcetxtMenuText");
            }
        }

        public static int IDrtb = 0;
        public static int statusOkna = 0;
        private void WyszukiwanieDanych()
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.HideSelection = false;
            WyszukiwarkaDlaFormy wyszukiwarka = new WyszukiwarkaDlaFormy();
            wyszukiwarka.Show();
        }
        private void WyszukajMenuItem_Click(object sender, EventArgs e)
        {
            WyszukiwanieDanych();
        }
        private void PwdLclToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HostName().Length > 0)
            {
                LAPSui.HostName = HostName();
                LAPSui lAPSui = new LAPSui();
                lAPSui.LoadPassword(HostName());
                lAPSui.Show();
            }
            else MessageBox.Show(new Form() { TopMost = true }, "Nie podano nazwy komputera");
        }
        private void Zmianahasla(object sender, EventArgs e)
        {
            if (UserName().Length > 0)
            {
                if (Lockout_Status.UserInfo(UserName()) != null)
                {
                    ZmianaHasla zh = new ZmianaHasla();
                    zh.ZmianaHasla_Load(UserName());
                    zh.Show();
                }
            }
            else UpdateRichTextBox("Nie podano loginu");
        }
    }
}        