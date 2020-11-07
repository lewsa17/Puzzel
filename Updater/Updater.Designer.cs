namespace Updater
{
    partial class Updater
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WaitLabel = new System.Windows.Forms.Label();
            this.ProgressLoading = new System.Windows.Forms.ProgressBar();
            this.PercentLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WaitLabel
            // 
            this.WaitLabel.Location = new System.Drawing.Point(109, 9);
            this.WaitLabel.Name = "WaitLabel";
            this.WaitLabel.Size = new System.Drawing.Size(107, 22);
            this.WaitLabel.TabIndex = 3;
            this.WaitLabel.Text = "Proszę czekać";
            // 
            // ProgressLoading
            // 
            this.ProgressLoading.Location = new System.Drawing.Point(12, 34);
            this.ProgressLoading.Name = "ProgressLoading";
            this.ProgressLoading.Size = new System.Drawing.Size(284, 30);
            this.ProgressLoading.Maximum = 4;
            // 
            // PercentLabel
            // 
            this.PercentLabel.Location = new System.Drawing.Point(302, 42);
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(23, 15);
            this.PercentLabel.TabIndex = 1;
            this.PercentLabel.Text = "0%";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(253, 70);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 101);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.PercentLabel);
            this.Controls.Add(this.ProgressLoading);
            this.Controls.Add(this.WaitLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.Text = "Auto-Updater";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label WaitLabel;
        private System.Windows.Forms.ProgressBar ProgressLoading;
        private System.Windows.Forms.Label PercentLabel;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.WebBrowser webBrowser;
    }
}

