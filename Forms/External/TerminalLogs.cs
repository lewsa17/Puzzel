using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Forms
{
    public partial class TerminalLogs : Form
    {
        public TerminalLogs()
        {
            InitializeComponent();
        }

        string filelist { get => PuzzelLibrary.Settings.GetSettings.GetValuesFromXml("ExternalResources.xml", "TerminalsLogFolder"); }

        private void button1_Click(object sender, EventArgs e)
        {
            getUserLog(textBox1.Text, filelist);
        }

        private delegate void UpdateRichTextBoxEventHandler(string message);
        public static void UpdateRichTextBox(string message)
        {
            if (!string.IsNullOrEmpty(message))
                if (richTextBox1.InvokeRequired)
                    richTextBox1.Invoke(new UpdateRichTextBoxEventHandler(UpdateRichTextBox), new object[] { message });
                else { richTextBox1.AppendText(message); }
        }
        public void getUserLog(string name, string PathName)
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    using (FileStream fileStream = new FileStream(PathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        while (!sr.EndOfStream)
                        {
                            string dataLine = sr.ReadLine();
                            var words = dataLine.Split(' ');
                            if (name == words[1])
                                UpdateRichTextBox(dataLine + "\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }).Start();
        }

        public void getComputerLog(string name, string PathName)
        {
            new System.Threading.Thread(() =>
            {
                try
                {
                    using (FileStream fileStream = new FileStream(PathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        while (!sr.EndOfStream)
                        {

                            string dataLine = sr.ReadLine();
                            var words = dataLine.Split(' ');
                            if (name == words[0])
                                UpdateRichTextBox(dataLine + "\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }).Start(); 
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            getComputerLog(textBox2.Text, filelist);

        }
    }
}
