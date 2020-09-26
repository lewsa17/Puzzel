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
        public Updater(string currentVersion)
        {
            InitializeComponent(); Process.Start("powershell", "-WindowStyle hidden -Command Remove-Item " + localFolder + " -Recurse -Force");
            CurrentVersion = currentVersion;
        }

        private static List<Commit> commits;
        internal static void LoadCommits()
        {
            var task = Task.Run(() => GetCommits());
            if (task.IsCompletedSuccessfully)
            {
                commits = task.Result;
            }
            else { task.Wait(); commits = task.Result; }
        }
    
        internal static string UpdatingString()
        {
            string Value = string.Format(
                "Nowa wersja aplikacji Puzzel jest dostępna!" +
                "\n" +
                "\n" +
                "Aktualna wersja: {0} - {1}({2})" +
                "\n" + 
                "Ostatnia wersja: {3} - {4}({5})" +
                "\n" + 
                "Aktualna wersja ma {6} dni {7} godzin" +
                "\n" +
                "\n" +
                "Czy chcesz zaktualizować ?",
                CurrentVersion, GetCurrentVersionName(),GetCurrentVersionDate(),
                CurrentVersion, GetNewVersionName(),GetNewVersionDate(),
                CurrentAgeOfVersion().Days, CurrentAgeOfVersion().Hours);
            return Value;
        }
        private static string CurrentVersion = "0.131.0-137-fee8399";
        private static string localFolder = /*InputLocalFolder*/"";
        private static List<Commit> GetCommits()
        {
            const string remote = "https://github.com/Lewsa17/Puzzel.git";
            if (!File.Exists(localFolder))
            Repository.Clone(remote, localFolder);
            List<Commit> listOfCommits;
            var repo = new Repository(localFolder);
            
                listOfCommits = repo.Commits.ToList();
            
            return listOfCommits;
        }
        private static string GetCurrentVersionName()
        {
            return CurrentVersion.Split("-")[1];
        }
        private static string GetCurrentVersionHash()
        {
            return CurrentVersion.Split("-")[2];
        }
        private static string GetNewVersionName()
        {
            return commits.Count.ToString();
        }
        private static DateTime GetNewVersionDate()
        {
            return commits[0].Committer.When.DateTime;
        }
        private static DateTime GetCurrentVersionDate()
        {
            var listOfCommits = commits;
            var findedCommit = listOfCommits.Find(x => x.Sha.Contains(GetCurrentVersionHash()));
            return findedCommit.Committer.When.DateTime;
        }
        private static TimeSpan CurrentAgeOfVersion()
        {
            var currentAge = GetCurrentVersionDate() - GetNewVersionDate();
            return currentAge;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
            RemoveLocalRepo();
        }

        internal static bool CheckNewVersion()
        {
            if (CurrentAgeOfVersion() == TimeSpan.Zero | Convert.ToInt32(GetNewVersionName()) == Convert.ToInt32(GetCurrentVersionName()))
                    return false;
            return true;
        }

        internal static void RemoveLocalRepo()
        {
            Process.Start("powershell", "-WindowStyle hidden -Command Remove-Item " + localFolder + " -Recurse -Force");
        }
    }
}
