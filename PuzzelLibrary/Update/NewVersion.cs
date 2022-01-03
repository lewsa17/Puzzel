using System;
using System.IO;
using PuzzelLibrary.Settings;

namespace PuzzelLibrary.Update
{
    public class NewVersion
    {
        public NewVersion()
        {
        }
        private string CurrentVersion;
        private bool iDFSet { get => Values.LocalUpdateCheck && !string.IsNullOrEmpty(Values.LocalUpdatePath); }
        private string intranetDeploymentFolder { get => Values.LocalUpdatePath; }
        //private List<Commit> commits;

        private TimeSpan CurrentAgeOfVersion() => currentDate - newDate;
        private readonly string localFolder = Path.Combine(Path.GetTempPath(), "remoteRepo");
        private string currentShortSha { get; set; }
        private int currentCommits { get; set; }
        private DateTime currentDate { get; set; }

        private string UpdatingString()
        {
            return string.Format(
                "Nowa wersja aplikacji Puzzel jest dostępna!" +
                "\n" +
                "\n" +
                "Aktualna wersja: {0}-{1}-{2}({3})" +
                "\n" +
                "Ostatnia wersja: {4}-{5}-{6}({7})" +
                "\n" +
                "Aktualna wersja jest z przed {8} dni {9} godzin" +
                "\n" +
                "\n" +
                "Czy chcesz zaktualizować ?",
                CurrentVersion, currentCommits, currentShortSha, currentDate,
                newBuild, newcommits, newShortSha, newDate,
                CurrentAgeOfVersion().Days.ToString().Trim('-'), CurrentAgeOfVersion().Hours.ToString().Trim('-'));
        }

        public bool CheckVersion(out string message)
        {
            if (iDFSet)
                GetVersionFromIDF();
            CurrentVersion = Version.Major + "." + Version.Minor;
            currentDate = Version.BuildDate;
            currentCommits = Version.Build;
            currentShortSha = Version.Hash;
            bool newVersion  = CheckNewVersion();
            message = UpdatingString();
            return newVersion;
        }
        public void RemoveLocalRepo(string directory)
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
        System.Reflection.PropertyInfo[] propertyVersion;
        private void GetVersionFromIDF()
        {
            var path = Path.Combine(intranetDeploymentFolder, "PuzzelLibrary.dll");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(File.ReadAllBytes(path));
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
            var newVer = newcommits;
            var currVer = currentCommits;
            if (currAge != TimeSpan.Zero && Convert.ToInt32(newVer) > Convert.ToInt32(currVer))
                return true;
            return false;
        }

        private string newBuild
        {
            get
            {
                if (iDFSet)
                    return "0." + (int)propertyVersion[1].GetValue(null);
                return 0.ToString();
            }
        }
        private string newShortSha
        {
            get
            {
                if (iDFSet)
                    return propertyVersion[3].GetValue(null).ToString();
                return "";//commits[0].Sha.Substring(0, 8);
            }
        }
        private int newcommits
        {
            get
            {
                if (iDFSet)
                    return (int)propertyVersion[2].GetValue(null);
                return 0;// commits.Count.ToString();
            }
        }
        private DateTime newDate
        {
            get
            {
                if (iDFSet)
                    return (DateTime)propertyVersion[4].GetValue(null);
                return DateTime.MinValue;//commits[0].Committer.When.DateTime;
            }
        }
    }
}
