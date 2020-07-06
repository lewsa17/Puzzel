using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzel
{
    static class LogsCollector
    {
        public static void Loger(Exception e, string InputedValue)
        {
            string path = Directory.GetCurrentDirectory() + @"\" + Application.ProductName + ".log";
            FileStream fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter log = new StreamWriter(fileStream);
            //Form1.UpdateRichTextBox(Environment.NewLine);
            Form1.UpdateRichTextBox("-----------------------------------" + Environment.NewLine);
            Form1.UpdateRichTextBox(DateTime.Now.ToString() + Environment.NewLine);
            Form1.UpdateRichTextBox("Wystąpił błąd" + Environment.NewLine);
            Form1.UpdateRichTextBox("-----------------------------------" + Environment.NewLine);
            //Form1.UpdateRichTextBox(Environment.NewLine);
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

