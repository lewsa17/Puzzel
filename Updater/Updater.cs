using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;
using System.IO;
using System.Diagnostics;

namespace Updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();   
        }

        internal void Execute(string[] currentBuildInfo)
        {
            while(Directory.Exists(localFolder))
                RemoveLocalRepo(localFolder);
            CurrentVersion = currentBuildInfo[0] + "." + currentBuildInfo[1];
            currentDate = DateTime.Parse(currentBuildInfo[4]);
            currentCommits = currentBuildInfo[2];
            currentShortSha = currentBuildInfo[3];
            LoadCommits();
            CheckVersion();
        }
        private Repository repo;
        private readonly string localFolder = Path.GetTempPath()+"remoteRepo";
        private string currentShortSha { get; set; }
        private string currentCommits { get; set; }
        private DateTime currentDate { get; set; }
        private string newShortSha
        {
            get
            {
                if (iDFSet)
                    return "";
                return commits[0].Sha.Substring(0, 8);
            }
        }
        private string newcommits
        {
            get
            {
                if (iDFSet)
                    return "";
                return commits.Count.ToString();
            }
        }
        private DateTime newDate
        {
            get
            {
                if (iDFSet)
                    return DateTime.Now; 
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


        private static List<Commit> commits;
        internal void LoadCommits()
        {
            if (iDFSet)
            { }
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
                CurrentVersion, GetCurrentCommitNumber(),GetCurrentVersionHash(), GetCurrentVersionDate(),
                CurrentVersion, GetNewCommitNumber(), GetNewShortSha(),GetNewVersionDate(),
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
                }
                else
                {
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
        internal bool CheckNewVersion()
        {
            var currAge = CurrentAgeOfVersion();
            var newVer = GetNewCommitNumber();
            var currVer = GetCurrentCommitNumber();
            if (currAge != TimeSpan.Zero | Convert.ToInt32(newVer) > Convert.ToInt32(currVer))
                return true;
            return false;
        }
    }
}