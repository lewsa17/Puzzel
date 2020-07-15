using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Forms.Additional
{
    public partial class Progress : Form
    {
        public static int ProgressValue => PuzzelLibrary.WMI.ComputerInfo.getProgressValue;
        public static int ProgressMax { get; set; }
        public Progress()
        {
            InitializeComponent();
            //Loading.RunWorkerAsync();
            this.progressBar.Maximum = ProgressMax;
            this.Show();

        }

        public void progress()
        {
            while (progressBar.Value != ProgressMax)
            {
                if (progressBar.InvokeRequired)
                    progressBar.Invoke(new MethodInvoker(() =>
                    {
                        progressBar.Value = ProgressValue;
                        progressBar.Refresh();
                        System.Threading.Thread.Sleep(200);
                    }));
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    this.Close();
                }));
            }
        }

    }
}
