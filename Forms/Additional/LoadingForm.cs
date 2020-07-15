using System.Windows.Forms;

namespace Forms.Additional
{
    class LoadingForm
    {
        public LoadingForm()
        {
            form.PerformLayout();
            form.Controls.Add(label);
            form.Controls.Add(progressBar);
            form.SuspendLayout();
            form.Show();
            progressBar.PerformLayout();
            progressBar.SuspendLayout();
            this.label.Refresh();
        }
        Form form = new Form
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            MinimizeBox = false,
            MaximizeBox = false,
            ShowIcon = false,
            ShowInTaskbar = false,
            TopMost = true,
            StartPosition = FormStartPosition.CenterScreen,
            Width = 222,
            Height = 100,
        };

        Label label = new Label
        {
            Location = new System.Drawing.Point(56, 43),
            Text = "Ładowanie danych",
            Anchor = (AnchorStyles.Bottom | AnchorStyles.Left),
        };
        ProgressBar progressBar = new ProgressBar
        {
            Location = new System.Drawing.Point(22, 12),
            Size = new System.Drawing.Size(170, 22),
            Minimum = 0,
            Maximum = MainForm.ProgressMax
        };
        public void progress()
        {
            while (MainForm.ProgressBarValue != MainForm.ProgressMax )
            {
                if (progressBar.InvokeRequired)
                    progressBar.Invoke(new MethodInvoker(() =>
                    {
                        progressBar.Value = MainForm.ProgressBarValue;
                        progressBar.Refresh();
                        System.Threading.Thread.Sleep(200);
                    }));
            }
            if (form.InvokeRequired) {
                form.Invoke(new MethodInvoker(() =>
                {
                    form.Close();
                }));
            }
        }
    }
}
