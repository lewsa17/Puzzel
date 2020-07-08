using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace PuzzelLibrary.Debug
{
    public static class LogsCollector
    {
        public static string GetLogs(Exception e, string InputedValue)
        {
            string Data = null;
            //Data+=(Environment.NewLine);
            Data += ("-----------------------------------" + Environment.NewLine);
            Data += (DateTime.Now.ToString() + Environment.NewLine);
            Data += ("Wystąpił błąd" + Environment.NewLine);
            Data += ("-----------------------------------" + Environment.NewLine);
            //Data+=(Environment.NewLine);
            SaveLogs(e, InputedValue);
            return Data;
        }
        private static void SaveLogs(Exception e, string InputedValue) 
        { 
            string path = Directory.GetCurrentDirectory() + @"\" + Application.ProductName + ".log";
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

