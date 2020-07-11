﻿namespace Forms.External
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.textConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.checkPaswordMustBeChanged = new System.Windows.Forms.CheckBox();
            this.llabelRelogoffInfobel3 = new System.Windows.Forms.Label();
            this.labelAccountIsLocked = new System.Windows.Forms.Label();
            this.checkUnlockAccount = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(196, 196);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(75, 23);
            this.btnChangePassword.TabIndex = 0;
            this.btnChangePassword.Text = "Zmień hasło";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(277, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textNewPassword
            // 
            this.textNewPassword.Location = new System.Drawing.Point(151, 19);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.PasswordChar = '*';
            this.textNewPassword.Size = new System.Drawing.Size(201, 20);
            this.textNewPassword.TabIndex = 2;
            // 
            // textConfirmPassword
            // 
            this.textConfirmPassword.Location = new System.Drawing.Point(151, 53);
            this.textConfirmPassword.Name = "textConfirmPassword";
            this.textConfirmPassword.PasswordChar = '*';
            this.textConfirmPassword.Size = new System.Drawing.Size(201, 20);
            this.textConfirmPassword.TabIndex = 3;
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(16, 19);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(68, 13);
            this.labelNewPassword.TabIndex = 4;
            this.labelNewPassword.Text = "Nowe hasło:";
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(16, 56);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(86, 13);
            this.labelConfirmPassword.TabIndex = 5;
            this.labelConfirmPassword.Text = "Potwierdź hasło:";
            // 
            // checkPaswordMustBeChanged
            // 
            this.checkPaswordMustBeChanged.AutoSize = true;
            this.checkPaswordMustBeChanged.Location = new System.Drawing.Point(12, 85);
            this.checkPaswordMustBeChanged.Name = "checkPaswordMustBeChanged";
            this.checkPaswordMustBeChanged.Size = new System.Drawing.Size(300, 17);
            this.checkPaswordMustBeChanged.TabIndex = 6;
            this.checkPaswordMustBeChanged.Text = "Użytkownik musi zmienić hasło przy następnym logowaniu";
            this.checkPaswordMustBeChanged.UseVisualStyleBackColor = true;
            // 
            // labelRelogoffInfo
            // 
            this.llabelRelogoffInfobel3.Location = new System.Drawing.Point(16, 105);
            this.llabelRelogoffInfobel3.Name = "labelRelogoffInfo";
            this.llabelRelogoffInfobel3.Size = new System.Drawing.Size(324, 31);
            this.llabelRelogoffInfobel3.TabIndex = 7;
            this.llabelRelogoffInfobel3.Text = "Użytkownik musi wylogować się i zalogować ponownie, aby zmiany zostały wprowadzone.";
            // 
            // labelAccountIsLocked
            // 
            this.labelAccountIsLocked.AutoSize = true;
            this.labelAccountIsLocked.Location = new System.Drawing.Point(9, 153);
            this.labelAccountIsLocked.Name = "labelAccountIsLocked";
            this.labelAccountIsLocked.Size = new System.Drawing.Size(159, 13);
            this.labelAccountIsLocked.TabIndex = 8;
            this.labelAccountIsLocked.Text = "Stan blokady konta w domenie: ";
            // 
            // checkUnlockAccount
            // 
            this.checkUnlockAccount.AutoSize = true;
            this.checkUnlockAccount.Location = new System.Drawing.Point(19, 178);
            this.checkUnlockAccount.Name = "checkUnlockAccount";
            this.checkUnlockAccount.Size = new System.Drawing.Size(160, 17);
            this.checkUnlockAccount.TabIndex = 9;
            this.checkUnlockAccount.Text = "Odblokuj konto użytkownika";
            this.checkUnlockAccount.UseVisualStyleBackColor = true;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 231);
            this.Controls.Add(this.checkUnlockAccount);
            this.Controls.Add(this.labelAccountIsLocked);
            this.Controls.Add(this.llabelRelogoffInfobel3);
            this.Controls.Add(this.checkPaswordMustBeChanged);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.textConfirmPassword);
            this.Controls.Add(this.textNewPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChangePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 270);
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ZmianaHasła";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.TextBox textConfirmPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.CheckBox checkPaswordMustBeChanged;
        private System.Windows.Forms.Label llabelRelogoffInfobel3;
        private System.Windows.Forms.Label labelAccountIsLocked;
        private System.Windows.Forms.CheckBox checkUnlockAccount;
    }
}
