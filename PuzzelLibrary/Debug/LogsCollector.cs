using System;
using System.IO;

namespace PuzzelLibrary.Debug
{
    public static class LogsCollector
    {
        public static string Result { get; set; }

        private static void ClearResult() { Result = ""; }

        private static void UpdateResult(string message)
        {
            Result += message + Environment.NewLine;
        }
        public static void GetLogs(Exception e, string InputedValue)
        {
            ClearResult();
            //UpdateResult("");
            UpdateResult("-----------------------------------");
            UpdateResult(DateTime.Now.ToString());
            UpdateResult("Wystąpił błąd");
            UpdateResult("-----------------------------------");
            //UpdateResult("");
            SaveLogs(e, InputedValue);
        }
        private static void SaveLogs(Exception e, string InputedValue) 
        { 
            string path = Directory.GetCurrentDirectory() + @"\" + System.Windows.Forms.Application.ProductName + ".log";
            FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter log = new StreamWriter(fileStream);
            log.WriteLine("-----------------------------------");
            log.WriteLine(DateTime.Now);
            log.WriteLine("-----------------------------------");
            log.WriteLine("Używana wartość w funkcji " + InputedValue);
            log.WriteLine(e.Message);
            log.WriteLine(e.HResult);
            log.WriteLine(e.InnerException);
            log.WriteLine(e.StackTrace);
            log.WriteLine(e.Source);
            log.WriteLine(e.GetType());
            log.WriteLine("");
            log.Close();
        }
    }
}

