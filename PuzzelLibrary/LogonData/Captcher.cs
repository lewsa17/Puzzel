using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PuzzelLibrary.Debug;
using PuzzelLibrary.Settings;

namespace PuzzelLibrary.LogonData
{
    public class Captcher
    {
        private static string _logsDirectory;
        private static string logsDirectory => getLogsDirectory();
        private static string getLogsDirectory()
        {
            if (_logsDirectory != null)
                return _logsDirectory;
            _logsDirectory = GetSettings.GetValuesFromXml("ExternalResources.xml", "LogsDirectory");
            return _logsDirectory;
        }
        private string getUserComputerLog(string pole, string rodzaj, decimal licznik)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                using (FileStream fileStream = new FileStream(logsDirectory + rodzaj + @"\" + pole + "_logons.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
                    string[] word;
                    string[] words;
                    word = LogCompLogs[0].Split(';');
                    string lastWords = word[2];
                    LastSearchedLogin = SAMAccountName(word[2]);
                    sb.Append(string.Format("{0,-13}{1,-16}{2,-30}{3,-12}{4,-28}{5,-10}", "LOGOWANIE", "KOMPUTER", "NAZWA", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));
                    int count = 0;
                    if (licznik > maxLines)
                        count = maxLines;
                    else
                        count = (int)licznik;

                    for (int i = 0; i < count; i++)
                    {
                        words = LogCompLogs[i].Split(';');
                        if (words[2] != lastWords)
                            sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], SAMAccountName(words[2]), words[2].Replace(" ", ""), words[3], words[word.Length - 2]) + "\n");
                        else
                        {
                            sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], LastSearchedLogin, words[2].Replace(" ", ""), words[3], words[word.Length - 2]) + "\n");
                            lastWords = words[2];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogsCollector.GetLogs(ex, pole + ',' + rodzaj + ',' + licznik);
            }
            return sb.ToString();
        }
        public string SearchLogs(decimal counter, string pole, string rodzaj)
        {
            string logs = string.Empty;
            System.Threading.Tasks.Task thread = null;
            if (Directory.Exists(logsDirectory))
            {
                if (!IsInvalidChar(pole))
                {
                    string[] returnedValues = keyWordsReturned(pole, rodzaj);
                    if (returnedValues.Length > 0)
                        foreach (string LogName in returnedValues)
                        {
                            thread = new System.Threading.Tasks.Task(() =>
                            logs += getUserComputerLog(LogName, rodzaj, counter));
                            thread.RunSynchronously();
                        }
                    else return ("Brak w logach");
                }
            }
            else MessageBox.Show("Brak dostępu do zasobu");
            return logs;
        }


        private static bool IsInvalidChar(string path)
        {
            foreach (char x in path)
            {
                if (Path.GetInvalidFileNameChars().Equals(x))
                {
                    return true;
                }
            }
            //foreach (char invalidPathChar in Path.GetInvalidFileNameChars())
            //{
            //    if (path.Contains(invalidPathChar))
            //    {
            //        MessageBox.Show("Użyto niedozwolonych znaków w nazwie");
            //        return true;
            //    }
            //}
            return false;
        }
        private string[] keyWordsReturned(string pole, string rodzaj)
        {
            string[] logsNames = null;
            if (!string.IsNullOrEmpty(pole) | !string.IsNullOrWhiteSpace(pole))
            {
                logsNames = Directory.GetFiles(logsDirectory + rodzaj + @"\", "*" + pole + "*_logons.log", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < logsNames.Length; i++)
                {
                    logsNames[i] = Path.GetFileNameWithoutExtension(logsNames[i]);
                    logsNames[i] = logsNames[i].Replace("_logons", "");
                }
            }
            else MessageBox.Show("Pole puste lub niepotrzebna spacja");
            return logsNames;
        }
        private string SAMAccountName(string username)
        {
            var Result = new AD.User.SearchInformation.Search().ByUserName(username);
			object NameOfUser = null;
			if (Result != null)
            NameOfUser = Result.GetDirectoryEntry().Properties["displayName"].Value;

            try
            {
                if (NameOfUser != null)
                    return NameOfUser.ToString();
            }

            catch (Exception e) { LogsCollector.GetLogs(e, username); }

            return "Brak w AD";
            } 
        }
    }

