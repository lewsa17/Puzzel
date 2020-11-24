using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class TerminalLogs : Form
    {
        public TerminalLogs()
        {
            InitializeComponent();
            comboQueryTimeBox.Items.AddRange(GetFolderNamesWithLogs());
            comboQueryFileBox.Items.AddRange(fileQuery.Split(','));
        }
        public static string TerminalsLogFolder { get => PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "TerminalsLogFolder"); }
        static string fileQuery = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "TerminalsLogFile");
        static List<string[]> LogDB
        {
            get
            {
                var filename = PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "TerminalsLogDB");
                var pathDB = Path.Combine(TerminalsLogFolder, filename);
                List<string[]> dblist = new();
                using (FileStream fileStream = new FileStream(pathDB, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    while (!sr.EndOfStream)
                    {
                        dblist.Add(sr.ReadLine().Split(','));
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
        public void getTerminalLogs(string Value, string PathName, int ValueType)
        {
            textLogView.Focus();
            if (ValueType == 2)
            {
                Value = GetNameBySN(Value);
                ValueType = 0;
            }
            var task = Task.Run(() =>
            {
                using (FileStream fileStream = new FileStream(PathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    while (!sr.EndOfStream)
                    {
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
                }
            });
        }
    }
}