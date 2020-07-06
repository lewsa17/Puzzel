using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Puzzel
{
    public class CompUserLog : Form1
    {
        public void logs(string UserOrComputerName,string UserOrComputer, int iloscLogow)
        {
			String[] Working = File.ReadAllLines("DefaultValue.txt").Split('\n');
                if (File.Exists(Working[8].Remove(9)+UserOrComputer+@"\" + UserOrComputerName + "_logons.log"))
                {
                    int a = Convert.ToInt32(iloscLogow);
                    StreamReader sr = new StreamReader(Working[8].Remove(9)+UserOrComputer+@"\" + UserOrComputerName + "_logons.log");

                    string[] lines = sr.ReadToEnd().Split('\n');
                    sr.Close();

                    Array.Reverse(lines);

                    int maxLines = lines.Count();
                    string[] word;
                    string[] words;
                    word = lines[1].Split(';');
                    words = lines[maxLines - 1].Split(';');

                    ReplaceRichTextBox(string.Format("{0,-13}{1,-16}{2,-17}{3,-30}{4,-15}", "LOGOWANIE", "KOMPUTER", "UŻYTKOWNIK", "DATA", "WERSJA SYSTEMU" + "\n"));

                    for (int i = 1; i <= a; i++)
                    {
                        words = lines[i].Split(';');
                        UpdateRichTextBox(string.Format("{0,-12}{1,-16}{2,-17}{3,-30}{4,-20}", words[0], words[1], words[2], words[3], words[word.Count() - 2]) + "\n");

                    }
                }
        }
    }
}
