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

        internal static string IntranetDeploymentFolder { get => GetValuesFromXml("Settings.xml", "LocalUpdatePath"); }

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

        internal static bool IDFSet
        {
            get
            {
                bool ifSet = Convert.ToBoolean(GetValuesFromXml("Settings.xml", "LocalUpdateCheck"));
                return ifSet;
            }
        }

        private void CancelOKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BuildSollution()
        {
            using Process p = new();
            p.StartInfo.FileName = "dotnet.exe";
            p.StartInfo.Arguments = "build " + localFolder + "\\Puzzel.sln -o " + localFolder + "\\Update";
            p.Start();
        }

        private void CopyUpdate()
        {
            string _localFolder;
            if (IDFSet)
                _localFolder = IntranetDeploymentFolder;
            else _localFolder = localFolder + "\\Update";

            foreach (string fileNameWithPath in Directory.EnumerateFiles(_localFolder))
            {
                var fileName = Path.GetFileName(fileNameWithPath);
                var targetPath = Application.StartupPath;
                //foreach (var process in Process.GetProcesses())
                //{
                //    WaitForKillingApp(fileNameWithPath, fileName, process);
                //}
                Console.WriteLine("Copy " + fileNameWithPath + "to " + targetPath + "\\" + fileName);
                File.Copy(fileNameWithPath, targetPath + "\\" + fileName, true);
            }
        }

        private static void WaitForKillingApp(string fileNameWithPath, string fileName, Process process)
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
                WaitLabel.Invoke(new MethodInvoker(() => WaitLabel.Text = "Proszę czekać"));
                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 1));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "25%"));
                if (!IDFSet)
                    BuildSollution();

                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 2));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "50%"));
                CopyUpdate();

                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 3));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "75%"));
                if (!IDFSet)
                    CleanUpAfterUpdate();

                ProgressLoading.Invoke(new MethodInvoker(() => ProgressLoading.Value = 4));
                PercentLabel.Invoke(new MethodInvoker(() => PercentLabel.Text = "100%"));
                WaitLabel.Invoke(new MethodInvoker(() => WaitLabel.Text = "Aktualizacja zakończona"));
                if (MessageBox.Show("Czy chcesz uruchomić ponownie aplikację?", "Uruchamianie aplikacji", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "Puzzel.exe");
                    Process.Start(path);
                    this.Close();
                }
                else
                    Invoke(new MethodInvoker(() => this.Close()));
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