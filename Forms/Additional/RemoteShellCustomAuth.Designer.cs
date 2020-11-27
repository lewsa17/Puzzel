using System.Windows.Forms.VisualStyles;

namespace Forms.Additional
{
    partial class RemoteShellCustomAuth
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
            this.labelLogin = new();
            this.labelPassword = new();
            this.BtnClose = new();
            this.BtnUse = new();
            this.textLogin = new();
            this.textPassword = new();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new(8, 24);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new(70, 15);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "Podaj login:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new(8, 63);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new(71, 15);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Podaj hasło:";
            // 
            // BtnUse
            // 
            this.BtnUse.Location = new(80, 89);
            this.BtnUse.Name = "BtnUse";
            this.BtnUse.Size = new(70, 23);
            this.BtnUse.TabIndex = 2;
            this.BtnUse.Text = "Użyj";
            this.BtnUse.UseVisualStyleBackColor = true;
            this.BtnUse.Click += new(BtnClick);
            //
            // BtnClose
            // 
            this.BtnClose.Location = new(155, 89);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new(75, 23);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Zamknij";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new(this.BtnClose_Click);
            // 
            // textLogin
            // 
            this.textLogin.Location = new(81, 21);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new(148, 23);
            this.textLogin.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new(81, 60);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new(148, 23);
            this.textPassword.TabIndex = 4;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // RemoteShellCustomAuth
            // 
            this.AutoScaleDimensions = new(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(244, 130);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnUse);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(260, 169);
            this.MinimizeBox = false;
            this.MinimumSize = new(260, 169);
            this.Name = "RemoteShellCustomAuth";
            this.Text = "Podaj login i hasło";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button BtnUse; 
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPassword;
    }
}