namespace Forms.External
{
    partial class LAPSui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LAPSui));
            this.labelCompName = new System.Windows.Forms.Label();
            this.inputedcomputerName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textPasswordExpires = new System.Windows.Forms.TextBox();
            this.labelPasswordExpires = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCompName
            // 
            this.labelCompName.AutoSize = true;
            this.labelCompName.Location = new System.Drawing.Point(12, 26);
            this.labelCompName.Name = "labelCompName";
            this.labelCompName.Size = new System.Drawing.Size(94, 13);
            this.labelCompName.TabIndex = 0;
            this.labelCompName.Text = "Nazwa Komputera";
            // 
            // inputedcomputerName
            // 
            this.inputedcomputerName.Location = new System.Drawing.Point(12, 42);
            this.inputedcomputerName.Name = "inputedcomputerName";
            this.inputedcomputerName.Size = new System.Drawing.Size(318, 20);
            this.inputedcomputerName.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(12, 96);
            this.textPassword.Name = "textPassword";
            this.textPassword.ReadOnly = true;
            this.textPassword.Size = new System.Drawing.Size(318, 20);
            this.textPassword.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 80);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(36, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Hasło";
            // 
            // textPasswordExpires
            // 
            this.textPasswordExpires.Location = new System.Drawing.Point(12, 136);
            this.textPasswordExpires.Name = "textPasswordExpires";
            this.textPasswordExpires.ReadOnly = true;
            this.textPasswordExpires.Size = new System.Drawing.Size(318, 20);
            this.textPasswordExpires.TabIndex = 5;
            // 
            // labelPasswordExpires
            // 
            this.labelPasswordExpires.AutoSize = true;
            this.labelPasswordExpires.Location = new System.Drawing.Point(12, 120);
            this.labelPasswordExpires.Name = "labelPasswordExpires";
            this.labelPasswordExpires.Size = new System.Drawing.Size(75, 13);
            this.labelPasswordExpires.TabIndex = 4;
            this.labelPasswordExpires.Text = "Hasło wygasa";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(12, 172);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(156, 23);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Wyszukaj";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnGetPwd);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(174, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LAPSui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 196);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.textPasswordExpires);
            this.Controls.Add(this.labelPasswordExpires);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.inputedcomputerName);
            this.Controls.Add(this.labelCompName);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 235);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 235);
            this.Name = "LAPSui";
            this.Text = "LAPSui";
            this.Load += new System.EventHandler(this.LAPSui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCompName;
        private System.Windows.Forms.TextBox inputedcomputerName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textPasswordExpires;
        private System.Windows.Forms.Label labelPasswordExpires;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
    }
}
