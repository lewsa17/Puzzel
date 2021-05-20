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
            this.cancelOKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WaitLabel
            // 
            this.WaitLabel.Location = new System.Drawing.Point(109, 9);
            this.WaitLabel.Name = "WaitLabel";
            this.WaitLabel.AutoSize = true;
            this.WaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WaitLabel.TabIndex = 3;
            this.WaitLabel.Text = "Proszę czekać";
            // 
            // ProgressLoading
            // 
            this.ProgressLoading.Location = new System.Drawing.Point(12, 34);
            this.ProgressLoading.Name = "ProgressLoading";
            this.ProgressLoading.Size = new System.Drawing.Size(282, 30);
            this.ProgressLoading.Maximum = 4;
            // 
            // PercentLabel
            // 
            this.PercentLabel.Location = new System.Drawing.Point(296, 40);
            this.PercentLabel.AutoSize = true;
            this.PercentLabel.Name = "PercentLabel";
            this.PercentLabel.Size = new System.Drawing.Size(23, 15);
            this.PercentLabel.TabIndex = 1;
            this.PercentLabel.Text = "0%";
            this.PercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelOKButton
            // 
            this.cancelOKButton.Location = new System.Drawing.Point(253, 70);
            this.cancelOKButton.Name = "cancelOKButton";
            this.cancelOKButton.Size = new System.Drawing.Size(75, 23);
            this.cancelOKButton.TabIndex = 0;
            this.cancelOKButton.Text = "Anuluj";
            this.cancelOKButton.UseVisualStyleBackColor = true;
            this.cancelOKButton.Click += new System.EventHandler(this.CancelOKButton_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 101);
            this.Controls.Add(this.cancelOKButton);
            this.Controls.Add(this.PercentLabel);
            this.Controls.Add(this.ProgressLoading);
            this.Controls.Add(this.WaitLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Updater.Properties.Resources.PuzzelUpdate;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.Text = "Auto-Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WaitLabel;
        private System.Windows.Forms.ProgressBar ProgressLoading;
        private System.Windows.Forms.Label PercentLabel;
        private System.Windows.Forms.Button cancelOKButton;
    }
}

