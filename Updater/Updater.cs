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
        public Updater(string[] currentBuildInfo)
        {
            InitializeComponent();
            Process.Start("powershell", "-WindowStyle hidden -Command Remove-Item " + localFolder + " -Recurse -Force");

            CurrentVersion = currentBuildInfo[0]+"."+currentBuildInfo[1];
            currentDate = DateTime.Parse(currentBuildInfo[4]);
            currentCommits = currentBuildInfo[2];
            currentShortSha = currentBuildInfo[3];
            LoadCommits();
            CheckVersion();

        }
        public string currentShortSha { get; set; }
        public string currentCommits { get; set; }
        public DateTime currentDate { get; set; }
        public string newShortSha => commits[0].Sha.Substring(0,8);
        public string newcommits => commits.Count.ToString();
        public DateTime newDate => commits[0].Committer.When.DateTime;

        private List<Commit> commits;
        internal void LoadCommits()
        {
            var task = Task.Run(() => GetCommits());
            if (task.IsCompletedSuccessfully)
            {
                commits = task.Result;
            }
            else { 
                task.Wait(); 
                commits = task.Result; }
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
        private string localFolder = Path.Combine(System.IO.Directory.GetCurrentDirectory(),"remoteRepo");
        private List<Commit> GetCommits()
        {
            const string remote = "https://github.com/Lewsa17/Puzzel.git";
            if (!File.Exists(localFolder))
                Repository.Clone(remote, localFolder);
            List<Commit> listOfCommits;
            var repo = new Repository(localFolder);

            listOfCommits = repo.Commits.ToList();
            return listOfCommits;
        }
        private DateTime GetNewVersionDate()
        {
            return newDate;
        }
        private string GetNewShortSha()
        {
            return newShortSha;
        }
        private string GetCurrentCommitNumber()
        {
            return currentCommits;
        }
        private string GetCurrentVersionHash()
        {
            return currentShortSha;
        }
        private string GetNewCommitNumber()
        {
            return commits.Count.ToString();
        }
        private DateTime GetCurrentVersionDate()
        {
            return currentDate;
        }
        private TimeSpan CurrentAgeOfVersion()
        {
            var currentAge = GetCurrentVersionDate() - GetNewVersionDate();
            return currentAge;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            RemoveLocalRepo();
        }

        internal void RemoveLocalRepo()
        {
            Process.Start("powershell", "-WindowStyle hidden -Command Remove-Item " + localFolder + " -Recurse -Force");
        }
        public void CheckVersion()
        {
            bool isNewVersion = CheckNewVersion();
            string stringToMessageBox = UpdatingString();
            if (isNewVersion)
            {
                if (MessageBox.Show(stringToMessageBox, "Aktualizacja jest dostępna", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Twoja wersja jest obecnie aktualna", "Auto-Updater", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        internal bool CheckNewVersion()
        {

            var currAge = CurrentAgeOfVersion();
            var newVer = GetNewCommitNumber();
            var currVer = GetCurrentCommitNumber();
            if (currAge == TimeSpan.Zero | Convert.ToInt32(newVer) == Convert.ToInt32(currVer))
                return false;
            return true;
        }
    }
}