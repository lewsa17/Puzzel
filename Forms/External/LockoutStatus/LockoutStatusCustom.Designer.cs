namespace Forms.External
{
    partial class LockoutStatusCustom
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
            System.ComponentModel.ComponentResourceManager resources = new(typeof(LockoutStatusCustom));
            this.labelUserName = new();
            this.labelDomainName = new();
            this.textUserName = new();
            this.textDomainName = new();
            this.btnOk = new();
            this.btnCancel = new();
            this.alternateCredCheck = new();
            this.CredentialBox = new();
            this.domainLabel = new();
            this.passwordLabel = new();
            this.userNameLabel = new();
            this.DomainText = new();
            this.PasswordText = new();
            this.UserNameText = new();
            this.CredentialBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new(43, 17);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new(145, 15);
            this.labelUserName.Text = "Podaj nazwę użytkownika:";
            // 
            // labelDomainName
            // 
            this.labelDomainName.AutoSize = true;
            this.labelDomainName.Location = new(65, 43);
            this.labelDomainName.Name = "labelDomainName";
            this.labelDomainName.Size = new(123, 15);
            this.labelDomainName.Text = "Podaj nazwę domeny:";
            // 
            // textUserName
            // 
            this.textUserName.Location = new(196, 14);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new(192, 23);
            this.textUserName.TabIndex = 0;
            this.textUserName.PreviewKeyDown += new(this.EnterKeyDown);
            // 
            // textDomainName
            // 
            this.textDomainName.Location = new(196, 39);
            this.textDomainName.Name = "textDomainName";
            this.textDomainName.Size = new(192, 23);
            this.textDomainName.TabIndex = 1;
            this.textDomainName.PreviewKeyDown += new(this.EnterKeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new(102, 200);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new(88, 27);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new(196, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new(this.btnCancel_Click);
            // 
            // alternateCredCheck
            // 
            this.alternateCredCheck.AutoSize = true;
            this.alternateCredCheck.Location = new(12, 83);
            this.alternateCredCheck.Name = "alternateCredCheck";
            this.alternateCredCheck.Size = new(206, 19);
            this.alternateCredCheck.TabIndex = 2;
            this.alternateCredCheck.Text = "Użyj alternatywnych poświadczeń:";
            this.alternateCredCheck.UseVisualStyleBackColor = true;
            this.alternateCredCheck.CheckedChanged += new(this.alternateCredCheck_CheckedChanged);
            // 
            // CredentialBox
            // 
            this.CredentialBox.Controls.Add(this.domainLabel);
            this.CredentialBox.Controls.Add(this.passwordLabel);
            this.CredentialBox.Controls.Add(this.userNameLabel);
            this.CredentialBox.Controls.Add(this.DomainText);
            this.CredentialBox.Controls.Add(this.PasswordText);
            this.CredentialBox.Controls.Add(this.UserNameText);
            this.CredentialBox.Location = new(12, 100);
            this.CredentialBox.Name = "CredentialBox";
            this.CredentialBox.Size = new(376, 94);
            this.CredentialBox.TabIndex = 5;
            this.CredentialBox.TabStop = false;
            // 
            // domainLabel
            // 
            this.domainLabel.AutoSize = true;
            this.domainLabel.Location = new(97, 67);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new(55, 15);
            this.domainLabel.Text = "Domena:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new(112, 42);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new(40, 15);
            this.passwordLabel.Text = "Hasło:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new(38, 17);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new(114, 15);
            this.userNameLabel.Text = "Nazwa użytkownika:";
            // 
            // DomainText
            // 
            this.DomainText.Location = new(158, 64);
            this.DomainText.Name = "DomainText";
            this.DomainText.ReadOnly = true;
            this.DomainText.Size = new(195, 23);
            this.DomainText.TabIndex = 5;
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new(158, 39);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.ReadOnly = true;
            this.PasswordText.Size = new(195, 23);
            this.PasswordText.TabIndex = 4;
            // 
            // UserNameText
            // 
            this.UserNameText.Location = new(158, 14);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.ReadOnly = true;
            this.UserNameText.Size = new(195, 23);
            this.UserNameText.TabIndex = 3;
            // 
            // LockoutStatusCustom
            // 
            this.AutoScaleDimensions = new(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(398, 239);
            this.Controls.Add(this.CredentialBox);
            this.Controls.Add(this.alternateCredCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textDomainName);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.labelDomainName);
            this.Controls.Add(this.labelUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockoutStatusCustom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybierz użytkownika";
            this.Load += new(this.LockoutStatusCustoma_Load);
            this.CredentialBox.ResumeLayout(false);
            this.CredentialBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelDomainName;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textDomainName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox alternateCredCheck;
        private System.Windows.Forms.GroupBox CredentialBox;
        private System.Windows.Forms.Label domainLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox DomainText;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.TextBox UserNameText;
    }
}
