using System.Windows.Forms;
using System.Threading;
namespace Puzzel
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
            //Loading.RunWorkerAsync();
            this.progressBar1.Maximum = Puzzel.Form1.ProgressMax;

            Thread thread = new Thread(StartLoading);
            thread.Start();

        }

        public void StartLoading()
        {
            while(Puzzel.Form1.progressBar.IsAlive)
            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(new MethodInvoker(() =>
                {
                    progressBar1.Value = Puzzel.Form1.ProgressBarValue;
                    progressBar1.Refresh();
                }));
            
        }
        
    }
}
