using System.IO;

namespace Puzzel
{
    class Logi
    {
		string[] Working = null;
        public Logi(string Username, string Hostname)
        {
            username = Username;
            hostname = Hostname;
			Working = File.ReadAllLines("DefaultValue.txt");
        }
        string username;
        string hostname;
        string userlogon;
        string computerlogon;
        public void GetLogs()
        {
            if (Directory.Exists(Working[0].Remove(13)))
            {
                Puzzel.Form1.ProgressBarValue =1;
                string[] usr = Directory.GetFiles(Working[0].Remove(13), "*_logons.log", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < usr.Length; i++)
                {
                    string usrfilename = Path.GetFileNameWithoutExtension(usr[i]);
                    string temp = null;

                    for (int j = 0; j < usrfilename.Length - 7; j++)
                        temp += usrfilename[j];
                    userlogon += temp + ",";
                }
                Puzzel.Form1.ProgressBarValue =2;
            }
            if (Directory.Exists(Working[1].Remove(13)))
            {
                Puzzel.Form1.ProgressBarValue =3;
                string[] cmp = Directory.GetFiles(Working[1].Remove(13), "*_logons.log", SearchOption.TopDirectoryOnly);
                for (int i = 0; i < cmp.Length; i++)
                {
                    string cmpfilename = Path.GetFileNameWithoutExtension(cmp[i]);
                    string temp = null;

                    for (int j = 0; j < cmpfilename.Length - 7; j++)
                        temp += cmpfilename[j];
                    computerlogon += temp + ",";
                }
                Puzzel.Form1.ProgressBarValue++;
            }
        }
        public void SaveLogs()
        {
            Puzzel.Form1.ProgressBarValue=4;
            StreamWriter usr = new StreamWriter(Path.GetTempPath() + @"\UserLogCache.log");
            usr.WriteLine(userlogon);
            usr.Close();
            Puzzel.Form1.ProgressBarValue =5;
            StreamWriter cmp = new StreamWriter(Path.GetTempPath() + @"\ComputerLogCache.log");
            cmp.WriteLine(computerlogon);
            cmp.Close();
        }
        public void LoadLogs()
        {
            Puzzel.Form1.ProgressBarValue++;
            StreamReader usr = new StreamReader(Path.GetTempPath() + @"\UserLogCache.log");
            //Puzzel.Form1.UserLogs = usr.ReadLine().Split(',');
            Program.UserCollection.AddRange(usr.ReadLine().Split(','));
            usr.Close();
            Puzzel.Form1.ProgressBarValue++;
            StreamReader cmp = new StreamReader(Path.GetTempPath() + @"\ComputerLogCache.log");
            //Puzzel.Form1.ComputerLogs = cmp.ReadLine().Split(',');
            Program.ComputerCollection.AddRange(cmp.ReadLine().Split(','));
            cmp.Close();
        }
    }
}