﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class CustomLogs : Form
    {
        private string _objectName { get; set; }
        public CustomLogs(string ObjectName)
        { _objectName = ObjectName;
            InitializeComponent();
            if (_objectName.Contains("Terminal"))
            {
                comboQueryTimeBox.Items.AddRange(GetFolderNamesWithLogs());
                comboQueryFileBox.Items.AddRange(fileQuery.Split(','));
            }
            else 
            {
                comboQueryTimeBox.Visible = false; 
                comboQueryFileBox.Visible = false;
                labelTime.Visible = false;
                labelFile.Visible = false;
                this.textQuery.Size = new System.Drawing.Size(649, 23); 
            }
        }
        public static string TerminalsLogFolder { get => PuzzelLibrary.Settings.Values.TerminalLogsFolder; }
        public static string ComputersLogFolder { get => PuzzelLibrary.Settings.Values.ComputerLogsFolder; }
        private static string fileQuery = PuzzelLibrary.Settings.Values.TerminalLogsFile;
        static List<string[]> LogDB
        {
            get
            {
                var filename = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "TerminalsLogDB");
                var pathDB = Path.Combine(TerminalsLogFolder, filename);
                List<string[]> dblist = new();
                if (File.Exists(pathDB))
                {
                    using (FileStream fileStream = new(pathDB, FileMode.Open, FileAccess.Read, FileShare.Read))
                    using (StreamReader sr = new(fileStream))
                    {
                        while (!sr.EndOfStream)
                        {
                            dblist.Add(sr.ReadLine().Split(','));
                        }
                    } 
                }
                return dblist;
            }
        }
        private string[] GetFolderNamesWithLogs()
        {
            List<string> Folders = new();
            if (!string.IsNullOrEmpty(TerminalsLogFolder))
            {
                foreach (var subdirectory in Directory.EnumerateDirectories(TerminalsLogFolder))
                {
                    foreach (var files in Directory.EnumerateFiles(subdirectory))
                    {
                        if (files.Contains(fileQuery.Split(',')[0]))
                        {
                            Folders.Add(subdirectory.Replace(TerminalsLogFolder, ""));
                            break;
                        }
                    }
                }
            }
            Folders.Add("Aktualne");
            return Folders.ToArray();
        }
        private void BtnFinderClick(object sender, EventArgs e)
        {
            textLogView.Clear();
            if (_objectName.Contains("Terminal"))
                GetTerminalLogs();
            else { GetComputerLogs(); }
        }

        private void GetTerminalLogs()
        {
            string pathName = default;
            if (comboQueryTimeBox.Text != "Aktualne")
            {
                pathName = System.IO.Path.Combine(TerminalsLogFolder, comboQueryTimeBox.Text, comboQueryFileBox.Text);
            }
            else pathName = pathName = System.IO.Path.Combine(TerminalsLogFolder, comboQueryFileBox.Text);
            if (File.Exists(pathName))
            {
                int dataType = default;
                switch (comboQueryNameBox.SelectedIndex)
                {
                    case 0: { dataType = 1; break; }
                    case 1: { dataType = 0; break; }
                    case 2: { dataType = 2; break; }
                }
                getTerminalLogs(textQuery.Text, pathName, dataType);
            }
            else UpdateRichTextBox("Brak dostępu do pliku");
        }

        private void GetComputerLogs()
        {
            string pathName = PuzzelLibrary.Settings.Values.ComputerSNFile;
            if (File.Exists(pathName))
            {
                getComputerLogs(textQuery.Text, pathName, comboQueryNameBox.SelectedIndex);
            }
            else UpdateRichTextBox("Brak dostępu do pliku");
        }
        long ProgressbarValue { get; set; }
        public void UpdateProgressBarValue()
        {
            if (progressBar.InvokeRequired)
                progressBar.Invoke(new MethodInvoker(() =>
                {
                    progressBar.Value = (int)ProgressbarValue;
                    progressBar.Refresh();
                }));
            else { progressBar.Value = (int)ProgressbarValue; progressBar.Refresh(); }
        }
        private delegate void UpdateRichTextBoxEventHandler(string message);
        private static void UpdateRichTextBox(string message)
        {
            if (!string.IsNullOrEmpty(message))
                if (textLogView.InvokeRequired)
                    textLogView.Invoke(new UpdateRichTextBoxEventHandler(UpdateRichTextBox), new object[] { message });
                else { textLogView.AppendText(message); }
        }
        private string GetSN(string Name)
        {
            foreach (var line in LogDB)
                if (line[0] == Name)
                    return line[6];
            return "Brak danych";
        }
        private string GetNameBySN(string SN)
        {
            foreach (var line in LogDB)
                if (line[6] == SN)
                    return line[0];
            return "Brak danych";
        }
        private void TextLogViewChanged(object sender, EventArgs e)
        {
            UpdateProgressBarValue();
        }
        private void getTerminalLogs(string Value, string PathName, int ValueType)
        {
            progressBar.Value = 0;
            textLogView.Focus();
            if (ValueType == 2)
            {
                Value = GetNameBySN(Value);
                ValueType = 0;
            }
            var task = Task.Run(() =>
            {
                using (FileStream fileStream = new(PathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new(fileStream))
                {
                    while (!sr.EndOfStream)
                    {
                        ProgressbarValue = (sr.BaseStream.Position * 100 / sr.BaseStream.Length);
                        string dataLine = sr.ReadLine();
                        var words = dataLine.Split(' ');
                        if (words.Length > 2)
                        {
                            if (Value == words[ValueType])
                            {
                                UpdateRichTextBox(string.Format("{0,-17}{1,-12}{2,-14}{3,-10}{4,0}", words[0], words[1], GetSN(words[0]), words[2], words[3], dataLine.Remove(0, dataLine.IndexOf(words[4]))) + "\n");
                            }
                        }
                    }
                    UpdateProgressBarValue();
                }
            });
        }
        static cLogs[] dblist = null;
        private void getComputerLogs(string Value, string PathName, int ValueType)
        {
            textLogView.Focus();
            cLogs cLogs = new();
            cLogs.AddData(System.IO.File.ReadAllLines(PathName));
            dblist = cLogs.GetData();
            var shortedDBList = shortDBlist(dblist, Value, ValueType).GroupBy(dbl => dbl.ComputerName);
            List<string> listOfFilesLogs = new();
            foreach (var list in shortedDBList)
            {
                var path = Path.Combine(ComputersLogFolder, list.Key);
                if (File.Exists(path + ".txt"))
                {
                    listOfFilesLogs.Add(path + ".txt");
                }
                int i = 0;
                int j = 0;
                while (j<4)
                {
                    i++;
                    var lowerFile = path + "-" + i + ".txt";
                    if (File.Exists(lowerFile))
                    {
                        j = 0;
                        listOfFilesLogs.Add(lowerFile);
                    }
                    else j++;
                }
            }
            foreach (var list in listOfFilesLogs)
            {
                var file = File.ReadAllText(list);
                var words = file.Split(';');
                if (words.Length > 2)
                {
                    UpdateRichTextBox(string.Format("{0,-16}{1,-16}{2,-12}{3,-22}{4,0}", words[0], words[1], words[2], words[3], File.GetCreationTime(list)) + "\n");
                }
            }
        }
    

        private cLogs[] shortDBlist(cLogs[] dblist, string queryValue, int ValueType) 
        {
            List<cLogs> shortedDBList = new();
            foreach (var list in dblist)
            {
                if (ValueType == 0)
                    if (list.UserName == queryValue)
                    {
                        shortedDBList.Add(list);
                    }
                if (ValueType == 1)

                    if (list.ComputerName == queryValue)
                    {
                        shortedDBList.Add(list);
                    }
                if (ValueType == 2)
                    if (list.SerialNumber == queryValue)
                    {
                        shortedDBList.Add(list);
                    }
            }
            return shortedDBList.ToArray();
        }

        public class cLogs
        {
            public string ComputerName;
            public string UserName;
            public string SerialNumber;
            public string Model;
            public string OSVersion;
            private List<cLogs> DBList = new();
            public void AddData(string[] value)
            {
                CreateList(value);
            }
            public cLogs[] GetData()
            {
                return DBList.ToArray();
            }
            private void CreateList(string[] values)
            {
                foreach (string value in values)
                {
                    cLogs cl = new();
                    string[] splittedVal = value.Split(';');
                    cl.ComputerName = splittedVal[0];
                    cl.UserName = splittedVal[1];
                    cl.SerialNumber = splittedVal[2];
                    cl.Model = splittedVal[3];
                    if (splittedVal.Length > 4)
                    cl.OSVersion = splittedVal[4];
                    DBList.Add(cl);
                }
            }
        }
    }
}
