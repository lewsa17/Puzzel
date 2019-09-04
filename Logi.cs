using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;

namespace Puzzel
{
    class Logi
    {
        private string domainName() { return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; }

        
        string[] Working = File.ReadAllLines("DefaultValue.txt");
        public string loGi(string pole, string rodzaj, decimal licznik)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                FileStream fileStream = new FileStream(Working[8].Remove(8) + rodzaj + @"\" + pole + "_logons.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fileStream);
                long fsize = fileStream.Length;
                int lineMaxLenOptim = 255;
                long pos = fsize - lineMaxLenOptim * (long)licznik;
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
                string LastSearchedLogin = null;
                int maxLines = LogCompLogs.Length;
                decimal a = licznik;
                string[] word;
                string[] words;
                string[] lastWords;
                word = LogCompLogs[0].Split(';');
                LastSearchedLogin = Nazwauzytkownika(word[2]);
                sb.Append(string.Format("{0,-13}{1,-16}{2,-30}{3,-12}{4,-28}{5,-10}", "LOGOWANIE", "KOMPUTER", "NAZWA", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));
                if (a < maxLines)
                    for (int i = 0; i < a; i++)
                    {
                        words = LogCompLogs[i].Split(';');
                        if (i == 0)
                            sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                        else
                        {
                            lastWords = LogCompLogs[i - 1].Split(';');
                            if (words[2] == lastWords[2])
                                sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], LastSearchedLogin, words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                            else
                                sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                        }
                    }
                else
                    for (int i = 0; i < maxLines; i++)
                    {
                        words = LogCompLogs[i].Split(';');
                        if (i == 0)
                            sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                        else
                        {
                            lastWords = LogCompLogs[i - 1].Split(';');
                            if (words[2] == lastWords[2])
                                sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], LastSearchedLogin, words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                            else
                                sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Count() - 2]) + "\n");
                        }
                    }
            }
            catch (Exception ex)
            {
                Form1.Loger(ex, pole + ',' + rodzaj + ',' + licznik);
            }
            return sb.ToString();
        }
        string[] LogsNames = null;
        public string[] LogNames()
        {
            return LogsNames;
        }
        public void contains(string pole, string rodzaj)
        {
            if (!string.IsNullOrEmpty(pole) | !string.IsNullOrWhiteSpace(pole))
            {
                LogsNames = Directory.GetFiles(Working[8].Remove(8) + rodzaj + @"\", "*" + pole + "*_logons.log", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < LogsNames.Length; i++)
                {
                    LogsNames[i] = Path.GetFileNameWithoutExtension(LogsNames[i]);
                    LogsNames[i] = LogsNames[i].Replace("_logons", "");
                }
            }
            else MessageBox.Show("Pole puste lub niepotrzebna spacja");
        }
        private string Nazwauzytkownika(string username)
        {
            DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + domainName());
            myLdapConnection.UsePropertyCache = true;
            DirectorySearcher search = new DirectorySearcher(myLdapConnection);
            search.Filter = "(&(objectClass=user)(sAMAccountName=" + username.Replace(" ", "") + "))";
            search.PropertiesToLoad.Add("displayName");
            search.PageSize = 1000;
            search.SizeLimit = 1;
            string text = null;
            try
            {
                if (search.FindOne() != null)
                    text = search.FindOne().GetDirectoryEntry().Properties["displayName"].Value.ToString();
                else
                    text = "brak w AD";
            }
            //catch (NullReferenceException)
            //{
            //    text = "brak w AD";
            //}
            catch (Exception e)
            {
                Form1.Loger(e, username);
            }
            search.Dispose();
            return text;
        }
    }
}
