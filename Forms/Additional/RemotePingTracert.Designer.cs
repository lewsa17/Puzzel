namespace Forms.Additional
{
    partial class RemotePingTracert
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
            System.ComponentModel.ComponentResourceManager resources = new(typeof(RemotePingTracert));
            this.textboxHostName = new();
            this.textboxCounter = new();
            this.labelHostName = new();
            this.labelCouter = new();
            this.btnTryTest = new();
            this.SuspendLayout();
            // 
            // textboxHostName
            // 
            this.textboxHostName.Location = new(240, 16);
            this.textboxHostName.Name = "textboxHostName";
            this.textboxHostName.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.textboxHostName.Size = new(100, 20);
            this.textboxHostName.TabIndex = 0;
            // 
            // textboxCounter
            // 
            this.textboxCounter.Location = new(240, 43);
            this.textboxCounter.Name = "textboxCounter";
            this.textboxCounter.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            this.textboxCounter.Size = new(100, 20);
            this.textboxCounter.TabIndex = 1;
            this.textboxCounter.Visible = isPing;
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.labelHostName.Location = new(16, 19);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new(188, 13);
            this.labelHostName.TabIndex = 3;
            this.labelHostName.Text = "Podaj IP lub nazwę hosta docelowego";
            // 
            // labelCouter
            // 
            this.labelCouter.AutoSize = true;
            this.labelCouter.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            this.labelCouter.Location = new(16, 48);
            this.labelCouter.Name = "labelCouter";
            this.labelCouter.Size = new(152, 13);
            this.labelCouter.TabIndex = 4;
            this.labelCouter.Text = "Podaj ilość żądań echa (PING)";
            this.labelCouter.Visible = isPing;
            // 
            // btnTryTest
            // 
            this.btnTryTest.Location = new(129, 72);
            this.btnTryTest.Name = "btnTryTest";
            this.btnTryTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnTryTest.Size = new(75, 23);
            this.btnTryTest.TabIndex = 5;
            this.btnTryTest.Text = "Start";
            this.btnTryTest.UseVisualStyleBackColor = true;
            this.btnTryTest.Click += new(this.AssingValue);
            // 
            // RemotePing_Tracert
            // 
            this.ClientSize = new(333, 107);
            this.Controls.Add(this.btnTryTest);
            this.Controls.Add(this.labelCouter);
            this.Controls.Add(this.labelHostName);
            this.Controls.Add(this.textboxCounter);
            this.Controls.Add(this.textboxHostName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(371, 148);
            this.MinimizeBox = false;
            this.MinimumSize = new(371, 148);
            this.Name = "RemotePing_Tracert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remote Ping/Tracert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxHostName;
        private System.Windows.Forms.TextBox textboxCounter;
        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.Label labelCouter;
        private System.Windows.Forms.Button btnTryTest;
    }
}