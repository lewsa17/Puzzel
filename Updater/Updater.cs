using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;
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
        }

        public void Execute(string[] currentBuildInfo)
        {
            while (Directory.Exists(localFolder))
                RemoveLocalRepo(localFolder);
            CurrentVersion = currentBuildInfo[0] + "." + currentBuildInfo[1];
            currentDate = DateTime.Parse(currentBuildInfo[4]);
            currentCommits = currentBuildInfo[2];
            currentShortSha = currentBuildInfo[3];
            LoadCommits();
            CheckVersion();
        }
        private Repository repo;
        private readonly string localFolder = Path.GetTempPath() + "remoteRepo";
        private string currentShortSha { get; set; }
        private string currentCommits { get; set; }
        private DateTime currentDate { get; set; }
        private string newShortSha
        {
            get
            {
                if (iDFSet)
                    return propertyVersion[3].GetValue(null).ToString();
                return commits[0].Sha.Substring(0, 8);
            }
        }
        private string newcommits
        {
            get
            {
                if (iDFSet)
                    return propertyVersion[2].GetValue(null).ToString();
                return commits.Count.ToString();
            }
        }
        private DateTime newDate
        {
            get
            {
                if (iDFSet)
                    return (DateTime)propertyVersion[4].GetValue(null);
                return commits[0].Committer.When.DateTime;
            }
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
        private static string intranetDeploymentFolder { get; set; }

        private static System.Reflection.PropertyInfo[] propertyVersion;
        private static List<Commit> commits;
        internal void LoadCommits()
        {
            if (iDFSet)
                GetVersionFromIDF();
            else
            {
                var task = Task.Run(() => GetCommits()).GetAwaiter().GetResult();
                commits = task;
            }
        }

        internal string UpdatingString()
        {
            string Value = string.Format(
                "Nowa wersja aplikacji Puzzel jest dostępna!" +
                "\n" +
                "\n" +
                "Aktualna wersja: {0}-{1}-{2}({3})" +
                "\n" +
                "Ostatnia wersja: {4}-{5}-{6}({7})" +
                "\n" +
                "Aktualna wersja ma {8} dni {9} godzin" +
                "\n" +
                "\n" +
                "Czy chcesz zaktualizować ?",
                CurrentVersion, GetCurrentCommitNumber(), GetCurrentVersionHash(), GetCurrentVersionDate(),
                CurrentVersion, GetNewCommitNumber(), GetNewShortSha(), GetNewVersionDate(),
                CurrentAgeOfVersion().Days, CurrentAgeOfVersion().Hours);
            return Value;
        }
        private string CurrentVersion;
        private async Task<List<Commit>> GetCommits()
        {
            const string remote = "https://github.com/Lewsa17/Puzzel.git";
            if (!File.Exists(localFolder))
                Repository.Clone(remote, localFolder);
            List<Commit> listOfCommits;
            repo = new Repository(localFolder);
            listOfCommits = await Task.Run(() => repo.Commits.ToList());
            Debug.Write(listOfCommits);
            return listOfCommits;
        }
        private DateTime GetNewVersionDate() => newDate;
        private string GetNewShortSha() => newShortSha;
        private string GetCurrentCommitNumber() => currentCommits;
        private string GetCurrentVersionHash() => currentShortSha;
        private string GetNewCommitNumber() => newcommits;
        private DateTime GetCurrentVersionDate() => currentDate;
        private TimeSpan CurrentAgeOfVersion() => GetCurrentVersionDate() - GetNewVersionDate();
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void CheckVersion()
        {
            bool isNewVersion = CheckNewVersion();
            string stringToMessageBox = UpdatingString();
            if (isNewVersion)
            {
                if (MessageBox.Show(stringToMessageBox, "Aktualizacja jest dostępna", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Application.Run(FindForm());
                    while (!this.IsHandleCreated)
                    {
                        Thread.Sleep(500);
                    }
                    ProcessUpdating();
                }
            }
            else
            {
                MessageBox.Show("Twoja wersja jest obecnie aktualna", "Auto-Updater", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            repo.Dispose();
            RemoveLocalRepo(localFolder);
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
        private void GetVersionFromIDF()
        {
            var path = Path.Combine(intranetDeploymentFolder, "PuzzelLibrary.dll");
            var assembly = System.Reflection.Assembly.LoadFile(path);
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.Name == "Version")
                {
                    propertyVersion = type.GetProperties();
                }
            }
        }
        internal bool CheckNewVersion()
        {

            var currAge = CurrentAgeOfVersion();
            var newVer = GetNewCommitNumber();
            var currVer = GetCurrentCommitNumber();
            if (currAge != TimeSpan.Zero && Convert.ToInt32(newVer) > Convert.ToInt32(currVer))
                return true;
            return false;
        }

        private void BuildSollution()
        {
            PuzzelLibrary.ProcessExecutable.ProcExec.StartSimpleProcessWithWaitingForExit("dotnet", "build " + localFolder + "\\Puzzel.sln -o " + localFolder + "\\Update");
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
                foreach (var process in Process.GetProcesses())
                {
                    KillProcessBlockingFile(fileNameWithPath, fileName, process);
                }
                File.Copy(fileNameWithPath, localFolder + "\\" + fileName, true);
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
    }
}