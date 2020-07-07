using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;

namespace PuzzelLibrary.LogonData
{
    public class Logi
    {
        private static string domainName() => System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; 
        public static async void loGi(string pole, string rodzaj, decimal licznik)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (FileStream fileStream = new FileStream(ExternalResources.logsDirectory + rodzaj + @"\" + pole + "_logons.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fileStream))
                {
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
                    word = LogCompLogs[0].Split(';');
                    string lastWords = word[2];
                    LastSearchedLogin = Nazwauzytkownika(word[2]);
                    sb.Append(string.Format("{0,-13}{1,-16}{2,-30}{3,-12}{4,-28}{5,-10}", "LOGOWANIE", "KOMPUTER", "NAZWA", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));
                    int count = 0;
                    if (a > maxLines)
                        count = maxLines;
                    else
                        count = (int)a;

                    for (int i = 0; i < count; i++)
                    {
                        words = LogCompLogs[i].Split(';');
                        if (words[2] != lastWords)

                            sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], Nazwauzytkownika(words[2]), words[2].Replace(" ", ""), words[3], words[word.Length - 2]) + "\n");
                        else
                        {
                            sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], LastSearchedLogin, words[2].Replace(" ", ""), words[3], words[word.Length - 2]) + "\n");
                            lastWords = words[2];
                        }
                    }
                }
                //Form1.UpdateRichTextBox(sb.ToString());
            }
            catch (Exception ex)
            {
                //LogsCollector.Loger(ex, pole + ',' + rodzaj + ',' + licznik);
            }
        }
        private static string[] LogsNames = null;
        public static string[] LogNames()
        {
            return LogsNames;
        }
        public static void contains(string pole, string rodzaj)
        {
            if (!string.IsNullOrEmpty(pole) | !string.IsNullOrWhiteSpace(pole))
            {
                LogsNames = Directory.GetFiles(ExternalResources.logsDirectory + rodzaj + @"\", "*" + pole + "*_logons.log", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < LogsNames.Length; i++)
                {
                    LogsNames[i] = Path.GetFileNameWithoutExtension(LogsNames[i]);
                    LogsNames[i] = LogsNames[i].Replace("_logons", "");
                }
            }
            else MessageBox.Show("Pole puste lub niepotrzebna spacja");
        }
        private static string Nazwauzytkownika(string username)
        {
            using (DirectoryEntry myLdapConnection = new DirectoryEntry("LDAP://" + domainName()))
            {
                myLdapConnection.UsePropertyCache = true;
                using (DirectorySearcher search = new DirectorySearcher(myLdapConnection))
                {
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
                    catch (Exception e)
                    {
                        //LogsCollector.Loger(e, username);
                    }
                    finally
                    {
                        search.Dispose();
                    }
                    return text;
                }
            }
        }
    }
}
