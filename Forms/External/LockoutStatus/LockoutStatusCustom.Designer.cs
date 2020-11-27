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
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new(29, 15);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new(133, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Podaj nazwę użytkownika:";
            // 
            // labelDomainName
            // 
            this.labelDomainName.AutoSize = true;
            this.labelDomainName.Location = new(51, 37);
            this.labelDomainName.Name = "labelDomainName";
            this.labelDomainName.Size = new(111, 13);
            this.labelDomainName.TabIndex = 1;
            this.labelDomainName.Text = "Podaj nazwę domeny:";
            // 
            // textUserName
            // 
            this.textUserName.Location = new(168, 12);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new(165, 20);
            this.textUserName.TabIndex = 2;
            this.textUserName.PreviewKeyDown += new(this.EnterKeyDown);
            // 
            // textDomainName
            // 
            this.textDomainName.Location = new(168, 34);
            this.textDomainName.Name = "textDomainName";
            this.textDomainName.Size = new(165, 20);
            this.textDomainName.TabIndex = 3;
            this.textDomainName.PreviewKeyDown += new(this.EnterKeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new(96, 60);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new(177, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new(this.btnCancel_Click);
            // 
            // LockoutStatusCustom
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(354, 99);
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
    }
}
