namespace Forms.Additional
{
    partial class Progress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new(typeof(Progress));
            this.progressBar = new();
            this.label = new();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new(22, 12);
            this.progressBar.Size = new(170, 22);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = _ProgressMax;
            //
            // label
            //
            this.label.Location = new(56, 43);
            this.label.Text = "Ładowanie danych";
            this.label.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            // 
            // Progress
            // 
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Width = 222;
            this.Height = 100;
            this.Controls.Add(this.progressBar);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.Name = "Progress";
            this.Text = "Progress";
            this.PerformLayout();
            this.Controls.Add(label);
            this.Controls.Add(progressBar);
            this.SuspendLayout();
            progressBar.PerformLayout();
            progressBar.SuspendLayout();
        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label;
    }
}
