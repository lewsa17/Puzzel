namespace Forms.External.QuickFix
{
    partial class DeleteUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteUsers));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DeleteUserLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // DeleteUserLabel
            // 
            this.DeleteUserLabel.AutoSize = true;
            this.DeleteUserLabel.Location = new System.Drawing.Point(12, 23);
            this.DeleteUserLabel.Name = "DeleteUserLabel";
            this.DeleteUserLabel.Size = new System.Drawing.Size(249, 13);
            this.DeleteUserLabel.TabIndex = 1;
            this.DeleteUserLabel.Text = "Wybierz użytkownika z listy którego chcesz usunąć";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(71, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Usuń użytkownika";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 103);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DeleteUserLabel);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 142);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(289, 142);
            this.Name = "DeleteUsers";
            this.Text = "Usuwanie użytkowników";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label DeleteUserLabel;
        private System.Windows.Forms.Button button1;
    }
}