namespace Settings
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TabSettings = new System.Windows.Forms.TabControl();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.Other = new System.Windows.Forms.TabPage();
            this.DescriptionBox = new System.Windows.Forms.GroupBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.HistoryLogBox = new System.Windows.Forms.GroupBox();
            this.CheckBoxHistoryLog = new System.Windows.Forms.CheckBox();
            this.TabSettings.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            this.DescriptionBox.SuspendLayout();
            this.HistoryLogBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(632, 415);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(713, 415);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Zamknij";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TabSettings
            // 
            this.TabSettings.Controls.Add(this.GeneralPage);
            this.TabSettings.Controls.Add(this.Other);
            this.TabSettings.Location = new System.Drawing.Point(12, 3);
            this.TabSettings.Name = "TabSettings";
            this.TabSettings.SelectedIndex = 0;
            this.TabSettings.Size = new System.Drawing.Size(776, 406);
            this.TabSettings.TabIndex = 2;
            // 
            // GeneralPage
            // 
            this.GeneralPage.Controls.Add(this.HistoryLogBox);
            this.GeneralPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPage.Size = new System.Drawing.Size(768, 378);
            this.GeneralPage.TabIndex = 0;
            this.GeneralPage.Text = "Ogólne";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // Other
            // 
            this.Other.Location = new System.Drawing.Point(4, 24);
            this.Other.Name = "Other";
            this.Other.Padding = new System.Windows.Forms.Padding(3);
            this.Other.Size = new System.Drawing.Size(768, 378);
            this.Other.TabIndex = 1;
            this.Other.Text = "Inne";
            this.Other.UseVisualStyleBackColor = true;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptionBox.Controls.Add(this.DescriptionLabel);
            this.DescriptionBox.Location = new System.Drawing.Point(19, 303);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(762, 100);
            this.DescriptionBox.TabIndex = 3;
            this.DescriptionBox.TabStop = false;
            this.DescriptionBox.Text = "Opis";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 19);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(275, 15);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Najedź kursorem na opcję aby wyświetlić tutaj opis";
            // 
            // HistoryLogBox
            // 
            this.HistoryLogBox.Controls.Add(this.CheckBoxHistoryLog);
            this.HistoryLogBox.Location = new System.Drawing.Point(20, 11);
            this.HistoryLogBox.Name = "HistoryLogBox";
            this.HistoryLogBox.Size = new System.Drawing.Size(127, 52);
            this.HistoryLogBox.TabIndex = 0;
            this.HistoryLogBox.TabStop = false;
            this.HistoryLogBox.Text = "Historia logów";
            // 
            // CheckBoxHistoryLog
            // 
            this.CheckBoxHistoryLog.AutoSize = true;
            this.CheckBoxHistoryLog.Location = new System.Drawing.Point(6, 22);
            this.CheckBoxHistoryLog.Name = "CheckBoxHistoryLog";
            this.CheckBoxHistoryLog.Size = new System.Drawing.Size(83, 19);
            this.CheckBoxHistoryLog.TabIndex = 0;
            this.CheckBoxHistoryLog.Text = "Wyłaczone";
            this.CheckBoxHistoryLog.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.CheckBoxHistoryLog.MouseEnter += new System.EventHandler(this.MouseOn);
            this.CheckBoxHistoryLog.MouseLeave += new System.EventHandler(this.MouseOut);
            this.CheckBoxHistoryLog.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TabSettings);
            this.Name = "SettingsForm";
            this.Text = "Ustawienia";
            this.TabSettings.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            this.DescriptionBox.ResumeLayout(false);
            this.DescriptionBox.PerformLayout();
            this.HistoryLogBox.ResumeLayout(false);
            this.HistoryLogBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TabControl TabSettings;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.GroupBox DescriptionBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TabPage Other;
        private System.Windows.Forms.GroupBox HistoryLogBox;
        private System.Windows.Forms.CheckBox CheckBoxHistoryLog;
    }
}

