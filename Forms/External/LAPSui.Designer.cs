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
            this.labelCompName = new System.Windows.Forms.Label();
            this.inputtedcomputerName = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelPasswordExpires = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.dateTimePasswordExpires = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // labelCompName
            // 
            this.labelCompName.AutoSize = true;
            this.labelCompName.Location = new System.Drawing.Point(14, 30);
            this.labelCompName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompName.Name = "labelCompName";
            this.labelCompName.Size = new System.Drawing.Size(104, 15);
            this.labelCompName.TabIndex = 0;
            this.labelCompName.Text = "Nazwa Komputera";
            // 
            // inputedcomputerName
            // 
            this.inputtedcomputerName.Location = new System.Drawing.Point(14, 48);
            this.inputtedcomputerName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputtedcomputerName.Name = "inputedcomputerName";
            this.inputtedcomputerName.Size = new System.Drawing.Size(404, 23);
            this.inputtedcomputerName.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(14, 93);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textPassword.Name = "textPassword";
            this.textPassword.ReadOnly = true;
            this.textPassword.Size = new System.Drawing.Size(404, 23);
            this.textPassword.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(14, 74);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(37, 15);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Hasło";
            // 
            // labelPasswordExpires
            // 
            this.labelPasswordExpires.AutoSize = true;
            this.labelPasswordExpires.Location = new System.Drawing.Point(14, 119);
            this.labelPasswordExpires.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPasswordExpires.Name = "labelPasswordExpires";
            this.labelPasswordExpires.Size = new System.Drawing.Size(79, 15);
            this.labelPasswordExpires.TabIndex = 4;
            this.labelPasswordExpires.Text = "Hasło wygasa";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(14, 167);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(200, 27);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Wyszukaj";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnGetPwd);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(219, 167);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 27);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(364, 138);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(54, 23);
            this.setButton.TabIndex = 8;
            this.setButton.Text = "Ustaw";
            this.setButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePasswordExpires
            // 
            this.dateTimePasswordExpires.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

            this.dateTimePasswordExpires.Location = new System.Drawing.Point(14, 138);
            this.dateTimePasswordExpires.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePasswordExpires.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePasswordExpires.Name = "dateTimePasswordExpires";
            this.dateTimePasswordExpires.Size = new System.Drawing.Size(345, 23);
            this.dateTimePasswordExpires.TabIndex = 9;
            this.dateTimePasswordExpires.CustomFormat = "dd MMMM yyyy HH:mm:ss";
            // 
            // LAPSui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 206);
            this.Controls.Add(this.dateTimePasswordExpires);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.labelPasswordExpires);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.inputtedcomputerName);
            this.Controls.Add(this.labelCompName);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(446, 245);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(446, 245);
            this.Name = "LAPSui";
            this.Text = "LAPSui";
            this.Load += new System.EventHandler(this.LAPSui_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCompName;
        private System.Windows.Forms.TextBox inputtedcomputerName;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelPasswordExpires;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.DateTimePicker dateTimePasswordExpires;
    }
}
