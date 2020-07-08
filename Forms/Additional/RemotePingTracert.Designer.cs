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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemotePingTracert));
            this.textboxHostName = new System.Windows.Forms.TextBox();
            this.textboxCounter = new System.Windows.Forms.TextBox();
            this.labelHostName = new System.Windows.Forms.Label();
            this.labelCouter = new System.Windows.Forms.Label();
            this.btnTryTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textboxHostName.Location = new System.Drawing.Point(210, 16);
            this.textboxHostName.Name = "textboxHostName";
            this.textboxHostName.Size = new System.Drawing.Size(100, 20);
            this.textboxHostName.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textboxCounter.Location = new System.Drawing.Point(210, 38);
            this.textboxCounter.Name = "textboxCounter";
            this.textboxCounter.Size = new System.Drawing.Size(100, 20);
            this.textboxCounter.TabIndex = 1;
            // 
            // label1
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Location = new System.Drawing.Point(16, 19);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(188, 13);
            this.labelHostName.TabIndex = 3;
            this.labelHostName.Text = "Podaj IP lub nazwę hosta docelowego";
            // 
            // label2
            // 
            this.labelCouter.AutoSize = true;
            this.labelCouter.Location = new System.Drawing.Point(16, 45);
            this.labelCouter.Name = "labelCouter";
            this.labelCouter.Size = new System.Drawing.Size(152, 13);
            this.labelCouter.TabIndex = 4;
            this.labelCouter.Text = "Podaj ilość żądań echa (PING)";
            // 
            // button1
            // 
            this.btnTryTest.Location = new System.Drawing.Point(129, 72);
            this.btnTryTest.Name = "btnTryTest";
            this.btnTryTest.Size = new System.Drawing.Size(75, 23);
            this.btnTryTest.TabIndex = 5;
            this.btnTryTest.Text = "Start";
            this.btnTryTest.UseVisualStyleBackColor = true;
            this.btnTryTest.Click += new System.EventHandler(this.AssingValue);
            // 
            // RemotePing_Tracert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 107);
            this.Controls.Add(this.btnTryTest);
            this.Controls.Add(this.labelCouter);
            this.Controls.Add(this.labelHostName);
            this.Controls.Add(this.textboxCounter);
            this.Controls.Add(this.textboxHostName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(341, 131);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(341, 131);
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