using System.Windows.Forms;


namespace Forms.Additional
{
    public partial class Progress : Form
    {
        public int ProgressValue { get => PuzzelLibrary.WMI.ComputerInfo.GetProgressValue; }
        private int _ProgressMax { get; }
        public Progress(int ProgressMax)
    {
            InitializeComponent();
            //Loading.RunWorkerAsync();
            _ProgressMax = ProgressMax;
            this.progressBar.Maximum = ProgressMax;
            this.Show();

        }

        public void progress()
        {
            while (progressBar.Value != progressBar.Maximum)
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
                PuzzelLibrary.WMI.ComputerInfo.GetProgressValue = 0;
            }
        }

    }
}
