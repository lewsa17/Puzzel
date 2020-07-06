using System.Windows.Forms;
using System.Threading;
namespace Forms.Additional
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
            //Loading.RunWorkerAsync();
            this.progressBar1.Maximum = Forms.Form1.ProgressMax;

            Thread thread = new Thread(StartLoading);
            thread.Start();

        }

        public void StartLoading()
        {/*StartLoading:
            if (Puzzel.Form1.progressBar.IsAlive)
            {
                if (progressBar1.InvokeRequired)
                    progressBar1.Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Value = Puzzel.Form1.ProgressBarValue;
                        progressBar1.Refresh();
                    }));
            }
            else { Thread.Sleep(500); goto StartLoading; }
        */}
        
    }
}
