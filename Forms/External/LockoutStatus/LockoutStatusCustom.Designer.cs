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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockoutStatusCustom));
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelDomainName = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textDomainName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(29, 15);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(133, 13);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "Podaj nazwę użytkownika:";
            // 
            // labelDomainName
            // 
            this.labelDomainName.AutoSize = true;
            this.labelDomainName.Location = new System.Drawing.Point(51, 37);
            this.labelDomainName.Name = "labelDomainName";
            this.labelDomainName.Size = new System.Drawing.Size(111, 13);
            this.labelDomainName.TabIndex = 1;
            this.labelDomainName.Text = "Podaj nazwę domeny:";
            // 
            // textUserName
            // 
            this.textUserName.Location = new System.Drawing.Point(168, 12);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(165, 20);
            this.textUserName.TabIndex = 2;
            this.textUserName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EnterKeyDown);
            // 
            // textDomainName
            // 
            this.textDomainName.Location = new System.Drawing.Point(168, 34);
            this.textDomainName.Name = "textDomainName";
            this.textDomainName.Size = new System.Drawing.Size(165, 20);
            this.textDomainName.TabIndex = 3;
            this.textDomainName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EnterKeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(96, 60);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LockoutStatusCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 99);
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
            this.Load += new System.EventHandler(this.LockoutStatusCustoma_Load);
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
