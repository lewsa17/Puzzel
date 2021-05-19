using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
            ProcessUpdating();
        }

        private static string intranetDeploymentFolder { get => GetValuesFromXml("Settings.xml", "LocalUpdatePath"); }

        private readonly string localFolder = Path.Combine(Path.GetTempPath(), "remoteRepo");

        public static string GetValuesFromXml(string XmlFile, string valueToGet)
        {
            string value = string.Empty;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), XmlFile);
            if (File.Exists(filePath))
                using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(XmlFile))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (valueToGet == reader.Name.ToString())
                                value = reader.ReadString();
                        }
                    }
                }
            else System.Windows.Forms.MessageBox.Show(new System.Windows.Forms.Form { TopMost = true }, "Nie znaleziono pliku " + filePath, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            return value;
        }

        private static bool iDFSet
        {
            get
            {
                if (string.IsNullOrEmpty(intranetDeploymentFolder))
                    return false;
                return true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BuildSollution()
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "dotnet.exe";
                p.StartInfo.Arguments = "build " + localFolder + "\\Puzzel.sln -o " + localFolder + "\\Update";
                p.Start();
            }
        }

        private void CopyUpdate()
        {
            string _localFolder = string.Empty;
            if (iDFSet)
                _localFolder = intranetDeploymentFolder;
            else _localFolder = localFolder + "\\Update";

            foreach (string fileNameWithPath in Directory.EnumerateFiles(_localFolder))
            {
                var fileName = Path.GetFileName(fileNameWithPath);
                var targetPath = Application.StartupPath;
                foreach (var process in Process.GetProcesses())
                {
                    KillProcessBlockingFile(fileNameWithPath, fileName, process);
                }
                File.Copy(fileNameWithPath, targetPath + "\\" + fileName, true);
            }
        }

        private static void KillProcessBlockingFile(string fileNameWithPath, string fileName, Process process)
        {
            if (fileName != Process.GetCurrentProcess().MainModule.ModuleName)
                if (process.ProcessName == Path.GetFileNameWithoutExtension(fileNameWithPath))
                    foreach (var module in process.Modules)
                        if (((ProcessModule)module).ModuleName == fileName)
                            process.Kill(true);
        }
        private void ProcessUpdating()
        {
            string _waitLabel = WaitLabel.Text;
            var progressBar = Task.Run(() =>
            {
                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 1));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "25%"));
                if (!iDFSet)
                    BuildSollution();

                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 2));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "50%"));
                CopyUpdate();

                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 3));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "75%"));
                if (!iDFSet)
                    CleanUpAfterUpdate();

                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 4));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "100%"));
            });

            var progressTitle = Task.Run(() =>
            {
                while (progressBar.IsCompletedSuccessfully)
                    for (int i = 0; i < 6; i++)
                    {
                        WaitLabel.Invoke(new MethodInvoker(() => WaitLabel.Text += "."));
                        if (i == 5)
                        {
                            WaitLabel.Invoke(new MethodInvoker(() => WaitLabel.Text = "Proszę czekać"));
                        }
                        Thread.Sleep(400);
                    }
            });
        }
        private void CleanUpAfterUpdate()
        {
            RemoveLocalRepo(localFolder+"\\Update");
        }

        private static void RemoveLocalRepo(string directory)
        {
            foreach (string subdirectory in Directory.EnumerateDirectories(directory))
            {
                RemoveLocalRepo(subdirectory);
            }
            foreach (string fileName in Directory.EnumerateFiles(directory))
            {
                var fileInfo = new FileInfo(fileName)
                {
                    Attributes = FileAttributes.Normal
                };
                fileInfo.Delete();
            }
            Directory.Delete(directory);
        }
    }
}