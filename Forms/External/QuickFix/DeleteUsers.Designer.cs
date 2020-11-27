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
            System.ComponentModel.ComponentResourceManager resources = new(typeof(DeleteUsers));
            this.ComboBoxUsers = new();
            this.DeleteUserLabel = new();
            this.BtnDeleteUsers = new();
            this.SuspendLayout();
            // 
            // ComboBoxUsers
            // 
            this.ComboBoxUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ComboBoxUsers.FormattingEnabled = true;
            this.ComboBoxUsers.Location = new(71, 48);
            this.ComboBoxUsers.Name = "ComboBoxUsers";
            this.ComboBoxUsers.Size = new(128, 21);
            this.ComboBoxUsers.TabIndex = 0;
            // 
            // DeleteUserLabel
            // 
            this.DeleteUserLabel.AutoSize = true;
            this.DeleteUserLabel.Location = new(12, 23);
            this.DeleteUserLabel.Name = "DeleteUserLabel";
            this.DeleteUserLabel.Size = new(249, 13);
            this.DeleteUserLabel.TabIndex = 1;
            this.DeleteUserLabel.Text = "Wybierz użytkownika z listy którego chcesz usunąć";
            // 
            // BtnDeleteUsers
            // 
            this.BtnDeleteUsers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnDeleteUsers.Location = new(71, 75);
            this.BtnDeleteUsers.Name = "BtnDeleteUsers";
            this.BtnDeleteUsers.Size = new(128, 24);
            this.BtnDeleteUsers.TabIndex = 2;
            this.BtnDeleteUsers.Text = "Usuń użytkownika";
            this.BtnDeleteUsers.UseVisualStyleBackColor = true;
            this.BtnDeleteUsers.Click += new(this.BtnDeleteUsers_Click);
            // 
            // DeleteUsersForm
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(273, 103);
            this.Controls.Add(this.BtnDeleteUsers);
            this.Controls.Add(this.DeleteUserLabel);
            this.Controls.Add(this.ComboBoxUsers);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(289, 142);
            this.MinimizeBox = false;
            this.MinimumSize = new(289, 142);
            this.Name = "DeleteUsersForm";
            this.Text = "Usuwanie użytkowników";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxUsers;
        private System.Windows.Forms.Label DeleteUserLabel;
        private System.Windows.Forms.Button BtnDeleteUsers;
    }
}