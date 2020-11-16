﻿using System;
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

        private static string lastSearchedName { get; set; }

        public string getUserComputerLog(string pole, string rodzaj, decimal licznik)
        {
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
                    lastSearchedName = SAMAccountName(word[2].Replace(" ", ""));
                    string lastUsedLogin = word[2];
                    sb.Append(string.Format("{0,-13}{1,-16}{2,-30}{3,-12}{4,-28}{5,-10}", "LOGOWANIE", "KOMPUTER", "NAZWA", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));
                    int count = (int)licznik;
                    if (licznik > maxLines)
                        count = maxLines;

                    for (int i = 0; i < count; i++)
                    {
                        words = LogCompLogs[i].Split(';');
                        if (words[2] != lastUsedLogin)
                            lastSearchedName = SAMAccountName(words[2].Replace(" ", ""));
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
        public string CheckLogs(string pole)
        {
            if (!Directory.Exists(logsDirectory))
                return ("Brak dostępu do zasobu");
            if (IsInvalidChar(pole))
                return ("Użyto niedozwolonych znaków w nazwie");
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
        public string[] keyWordsValues(string pole, string rodzaj)
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
			if (Result != null)
				return Result.Properties["displayName"][0].ToString();
            return "Brak w AD";
            } 
        }
    }

