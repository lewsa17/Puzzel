using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using PuzzelLibrary.Debug;
using PuzzelLibrary.Settings;
using System.DirectoryServices;
using System.Collections.Generic;
using System.Linq;

namespace PuzzelLibrary.LogonData
{
    public class Captcher
    {
        private static string _logsDirectory;
        private static string logsDirectory => getLogsDirectory();
        public string LastKnownComputerName { get; set; }
        private static string getLogsDirectory()
        {
            if (_logsDirectory != null)
                return _logsDirectory;
            _logsDirectory = GetSettings.GetValuesFromXml("ExternalResources.xml", "LogsDirectory");
            return _logsDirectory;
        }

        private static string lastSearchedName { get; set; }
        private static readonly string FileCache = Path.Combine(Application.StartupPath, nameof(PuzzelLibrary) + ".cache");

        public static void HardResetCache()
        {
            File.Delete(FileCache);
            ReloadCache();
        }
        public static void ReloadCache()
        {
            if (Values.CheckLogsBeforeStartUp | !File.Exists(FileCache))
            {
                ComputerNameDB.GetADComputers();
                UserNameDB.GetADUsers();
                Cache.Save();
            }
            else Cache.Refresh();
        }
        public class ComputerNameDB
        {
            public struct ComputerNameEntry
            {
                public string Name;
            }
            internal static List<ComputerNameEntry> ADComputerDB = new();
            internal static void GetADComputers()
            {
                if (Directory.Exists(logsDirectory))
                {
                    ComputerNameDB.ADComputerDB.Clear();
                    ComputerNameEntry computerNameEntry = new();
                    var logsNames = Directory.GetFiles(logsDirectory + "Computer" + @"\", "*_logons.log", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < logsNames.Length; i++)
                    {
                        computerNameEntry.Name = Path.GetFileNameWithoutExtension(logsNames[i]).Replace("_logons", "");
                        ADComputerDB.Add(computerNameEntry);
                    }
                }
                else MessageBox.Show(String.Concat("Brak dostępu do zasobu ", logsDirectory));
            }
        }
        public class Cache
        {
            internal static void Save()
            {
                StringBuilder data = new StringBuilder();
                foreach (var ADUser in UserNameDB.ADUserDB)
                    data.Append(nameof(ADUser.UserName) + "=" + ADUser.UserName + "," +
                        nameof(ADUser.DisplayName) + "=" + ADUser.DisplayName + Environment.NewLine);
                data.Append("ADComputers" + Environment.NewLine);
                foreach (var ADComputer in ComputerNameDB.ADComputerDB)
                    data.Append(nameof(ADComputer.Name) + "=" + ADComputer.Name + Environment.NewLine);
                PuzzelLibrary.Crypting.Data.Encrypt(FileCache, data.ToString());
            }
            internal static void Refresh()
            {
                string decryptedData;
                PuzzelLibrary.Crypting.Data.Decrypt(FileCache, out decryptedData);
                UserNameDB.UserNameEntry ADUser = new();
                ComputerNameDB.ComputerNameEntry ADComputer = new();
                ComputerNameDB.ADComputerDB.Clear();
                UserNameDB.ADUserDB.Clear();
                List<string> lines = decryptedData.Split(Environment.NewLine).ToList<string>();
                var nextCache = lines.IndexOf("ADComputers");
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i < nextCache)
                    {
                        string[] variable = lines[i].Split(",");
                        ADUser.UserName = variable[0].Split("=")[1];
                        ADUser.DisplayName = variable[1].Split("=")[1];
                        UserNameDB.ADUserDB.Add(ADUser);

                    }
                    if (i > nextCache)
                    {
                        ADComputer.Name = lines[i].Split("=")[1];
                        ComputerNameDB.ADComputerDB.Add(ADComputer);
                    }
                }
            }
        }
        public class UserNameDB
        {
            public struct UserNameEntry
            {
                public string UserName;
                public string DisplayName;
            }
            internal static List<UserNameEntry> ADUserDB = new();
            internal static void GetADUsers()
            {
                UserNameDB.ADUserDB.Clear();
                UserNameEntry _userNameEntry = new();
                var allusers = Captcher.GetAllUsers();
                if (allusers != null)
                    foreach (SearchResult ADUser in allusers)
                    {
                        if (ADUser.Properties.Contains("DisplayName") && ADUser.Properties.Contains("SamAccountName"))
                        {
                            _userNameEntry.DisplayName = ADUser.Properties["DisplayName"][0].ToString();
                            _userNameEntry.UserName = ADUser.Properties["SamAccountName"][0].ToString();
                            ADUserDB.Add(_userNameEntry);
                        }
                    }
            }
        }
        private string getUserComputerLog(string pole, string rodzaj, decimal licznik)
        {
            UserNameDB userNameDB = new();
            StringBuilder sb = new();
            try
            {
                using (FileStream fileStream = new FileStream(logsDirectory + rodzaj + @"\" + pole + "_logons.log", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    long fsize = fileStream.Length;
                    int lineMaxLenOptim = 200;
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
                    int maxLines = LogCompLogs.Length;
                    string[] word;
                    string[] words;
                    word = LogCompLogs[0].Split(';');
                    int lastKnownName = 0;
                    if (UserNameDB.ADUserDB == null)
                        Cache.Refresh();
                    else
                        lastSearchedName = UserNameDB.ADUserDB.Find(x => string.Equals(x.UserName, word[2].Replace(" ", ""), StringComparison.OrdinalIgnoreCase)).DisplayName;
                    string lastUsedLogin = word[2];
                    sb.Append(string.Format("{0,-13}{1,-16}{2,-30}{3,-12}{4,-28}{5,-10}", "LOGOWANIE", "KOMPUTER", "NAZWA", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));
                    int count = (int)licznik;
                    if (licznik > maxLines)
                        count = maxLines;

                    for (int i = 0; i < count; i++)
                    {
                        words = LogCompLogs[i].Split(';');

                        if (Settings.Values.ComputerInput && lastKnownName < 1 && rodzaj == "User")
                        {
                            ExtractLastKnowComputerName(out lastKnownName, words[1]);
                        }

                        if (words[2] != lastUsedLogin)
                        {
                            if (UserNameDB.ADUserDB == null || UserNameDB.ADUserDB.Count <= 0)
                                Cache.Refresh();
                            lastSearchedName = UserNameDB.ADUserDB.Find(x => string.Equals(x.UserName, words[2].Replace(" ", ""), StringComparison.OrdinalIgnoreCase)).DisplayName;
                        }
                        //sb.Clear();
                        sb.Append(string.Format("{0,-13}{1,-17}{2,-30}{3,-11}{4,-28}{5,-10}", " " + words[0], words[1], lastSearchedName, words[2].Replace(" ", ""), words[3], words[word.Length - 2]) + "\n");
                        lastUsedLogin = words[2];
                    }
                }
            }
            catch (Exception ex)
            {
                LogsCollector.GetLogs(ex, pole + ',' + rodzaj + ',' + licznik);
            }
            return sb.ToString();
        }
        public string CheckLogs(string nazwa, string kindOf, out List<string> nameEntries)
        {
            nameEntries = new();
            string pole = nazwa;
            if (Values.KeywordSearching)
                pole = nazwa.Replace("*", "");
            if (!Directory.Exists(logsDirectory))
                return ("Brak dostępu do zasobu");
            if (IsInvalidChar(pole))
                return ("Użyto niedozwolonych znaków w nazwie");
            if (kindOf == "User")
            {
                List<UserNameDB.UserNameEntry> usr;
                if (nazwa.Contains("*"))
                    usr = UserNameDB.ADUserDB.FindAll(x => x.UserName.Contains(pole, StringComparison.OrdinalIgnoreCase));
                else
                    usr = UserNameDB.ADUserDB.FindAll(x => x.UserName.Equals(pole, StringComparison.OrdinalIgnoreCase));
                if (usr.Count == 0)
                    return ("Brak użytkownika w cache");
                else
                {
                    foreach (var user in usr)
                    {
                        if (File.Exists(logsDirectory + kindOf + "\\" + user.UserName + "_logons.log"))
                            nameEntries.Add(user.UserName);
                    }
                    if (nameEntries.Count == 0)
                        return ("Brak w logach");
                }
            }
            if (kindOf == "Computer")
            {
                List<ComputerNameDB.ComputerNameEntry> comp;
                if (nazwa.Contains("*"))
                    comp = ComputerNameDB.ADComputerDB.FindAll(x => x.Name.Contains(pole, StringComparison.OrdinalIgnoreCase));
                else
                    comp = ComputerNameDB.ADComputerDB.FindAll(x => x.Name.Equals(pole, StringComparison.OrdinalIgnoreCase));
                if (comp.Count == 0)
                    return ("Brak nazwy komputera w cache");
                else
                {
                    foreach (var compName in comp)
                        if (File.Exists(logsDirectory + kindOf + "\\" + compName.Name + "_logons.log"))
                            nameEntries.Add(compName.Name);
                    if (nameEntries.Count == 0)
                        return ("Brak w logach");
                }
            }
            return "";
        }

        public string SearchLogs(decimal counter, string LogName, string rodzaj)
        {
            return getUserComputerLog(LogName, rodzaj, counter);
        }

        private static bool IsInvalidChar(string path)
        {
            foreach (char x in path)
            {
                if (Path.GetInvalidFileNameChars().Contains(x))
                {
                    return true;
                }
            }
            return false;
        }
        public ComputerNameDB.ComputerNameEntry[] ComputerNames(string pole, string kindOf)
        {
            List<ComputerNameDB.ComputerNameEntry> logsNames = new();
            if (!string.IsNullOrEmpty(pole) | !string.IsNullOrWhiteSpace(pole))
            {
                foreach (var logName in ComputerNameDB.ADComputerDB.FindAll(x => x.Name.Contains(pole)))
                    if (File.Exists(logsDirectory + kindOf + "\\" + logName.Name + "_logons.log"))
                    {
                        logsNames.Add(logName);
                    }
            }
            return logsNames.ToArray();
        }
        public UserNameDB.UserNameEntry[] userNames(string pole, string kindOf)
        {
            List<UserNameDB.UserNameEntry> logsNames = new();
            if (!string.IsNullOrEmpty(pole) | !string.IsNullOrWhiteSpace(pole))
            {
                foreach (var logName in UserNameDB.ADUserDB.FindAll(x => x.UserName.Contains(pole)))
                    if (File.Exists(logsDirectory + kindOf + "\\" + logName.UserName + "_logons.log"))
                    {
                        logsNames.Add(logName);
                    }
            }
            return logsNames.ToArray();
        }
        private string SAMAccountName(string username)
        {
            var Result = new AD.User.SearchInformation.Search().ByUserName(username);
            if (Result != null)
                return Result.Properties["displayName"][0].ToString();
            return "Brak w AD";
        }
        private static SearchResultCollection GetAllUsers()
        {
            var ds = AD.Connection.Initiate.GetDirectorySearcher();
            try
            {
                if (ds != null)
                {
                    ds.Filter = "(&(objectCategory=person)(objectClass=user))";
                    ds.SearchScope = SearchScope.Subtree;
                    ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
                    ds.PropertiesToLoad.AddRange(new string[] { "displayName", "SamAccountName" });
                    ds.SizeLimit = 5000;
                    ds.PageSize = 5000;
                    SearchResultCollection ADUserCollection = ds.FindAll();
                    return ADUserCollection;
                }
            }
            catch (System.Runtime.InteropServices.COMException) { System.Windows.Forms.MessageBox.Show("Brak połączenia z AD"); }
            return null;
        }
        private void ExtractLastKnowComputerName(out int isKnown, string ComputerName)
        {
            isKnown = 0;
            if (!ComputerName.Contains("ts-", StringComparison.OrdinalIgnoreCase))
            {
                LastKnownComputerName = ComputerName;
                isKnown = 1;
            }
        }
    }
}

