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
            this.CustomValueBox = new System.Windows.Forms.GroupBox();
            this.UserMaxLogs = new System.Windows.Forms.Label();
            this.CompMaxLogs = new System.Windows.Forms.Label();
            this.NumbersOfUserLogs = new System.Windows.Forms.NumericUpDown();
            this.NumbersOfCompLogs = new System.Windows.Forms.NumericUpDown();
            this.HistoryLogBox = new System.Windows.Forms.GroupBox();
            this.HistoryLogCheck = new System.Windows.Forms.CheckBox();
            this.SessionTab = new System.Windows.Forms.TabPage();
            this.SessionShortcutBox = new System.Windows.Forms.GroupBox();
            this.SessionShortcutText = new System.Windows.Forms.TextBox();
            this.SessionShortcutLabel = new System.Windows.Forms.Label();
            this.CustomSourceBox = new System.Windows.Forms.GroupBox();
            this.CustomSourceCheck = new System.Windows.Forms.CheckBox();
            this.CustomSourceTextBox = new System.Windows.Forms.RichTextBox();
            this.Other = new System.Windows.Forms.TabPage();
            this.AutomaticallyAllowBox = new System.Windows.Forms.GroupBox();
            this.SaveUserDataCheck = new System.Windows.Forms.CheckBox();
            this.AutoUnlockFirewallCheck = new System.Windows.Forms.CheckBox();
            this.AutoOpenPortCheck = new System.Windows.Forms.CheckBox();
            this.DescriptionBox = new System.Windows.Forms.GroupBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.RestoreDefaultButton = new System.Windows.Forms.Button();
            this.TabSettings.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            this.CustomValueBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumbersOfUserLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumbersOfCompLogs)).BeginInit();
            this.HistoryLogBox.SuspendLayout();
            this.SessionTab.SuspendLayout();
            this.SessionShortcutBox.SuspendLayout();
            this.CustomSourceBox.SuspendLayout();
            this.Other.SuspendLayout();
            this.AutomaticallyAllowBox.SuspendLayout();
            this.DescriptionBox.SuspendLayout();
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
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.TabSettings.Controls.Add(this.SessionTab);
            this.TabSettings.Controls.Add(this.Other);
            this.TabSettings.Location = new System.Drawing.Point(12, 3);
            this.TabSettings.Name = "TabSettings";
            this.TabSettings.SelectedIndex = 0;
            this.TabSettings.Size = new System.Drawing.Size(776, 406);
            this.TabSettings.TabIndex = 2;
            // 
            // GeneralPage
            // 
            this.GeneralPage.Controls.Add(this.CustomValueBox);
            this.GeneralPage.Controls.Add(this.HistoryLogBox);
            this.GeneralPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPage.Size = new System.Drawing.Size(768, 378);
            this.GeneralPage.TabIndex = 0;
            this.GeneralPage.Text = "Ogólne";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // CustomValueBox
            // 
            this.CustomValueBox.Controls.Add(this.UserMaxLogs);
            this.CustomValueBox.Controls.Add(this.CompMaxLogs);
            this.CustomValueBox.Controls.Add(this.NumbersOfUserLogs);
            this.CustomValueBox.Controls.Add(this.NumbersOfCompLogs);
            this.CustomValueBox.Location = new System.Drawing.Point(20, 69);
            this.CustomValueBox.Name = "CustomValueBox";
            this.CustomValueBox.Size = new System.Drawing.Size(167, 82);
            this.CustomValueBox.TabIndex = 1;
            this.CustomValueBox.TabStop = false;
            this.CustomValueBox.Text = "Niestandardowe wartości:";
            // 
            // UserMaxLogs
            // 
            this.UserMaxLogs.AutoSize = true;
            this.UserMaxLogs.Location = new System.Drawing.Point(16, 23);
            this.UserMaxLogs.Name = "UserMaxLogs";
            this.UserMaxLogs.Size = new System.Drawing.Size(33, 15);
            this.UserMaxLogs.TabIndex = 4;
            this.UserMaxLogs.Text = "Max:";
            this.UserMaxLogs.MouseEnter += new System.EventHandler(this.MouseOn);
            this.UserMaxLogs.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // CompMaxLogs
            // 
            this.CompMaxLogs.AutoSize = true;
            this.CompMaxLogs.Location = new System.Drawing.Point(16, 52);
            this.CompMaxLogs.Name = "CompMaxLogs";
            this.CompMaxLogs.Size = new System.Drawing.Size(33, 15);
            this.CompMaxLogs.TabIndex = 4;
            this.CompMaxLogs.Text = "Max:";
            this.CompMaxLogs.MouseEnter += new System.EventHandler(this.MouseOn);
            this.CompMaxLogs.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // NumbersOfUserLogs
            // 
            this.NumbersOfUserLogs.Location = new System.Drawing.Point(55, 50);
            this.NumbersOfUserLogs.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumbersOfUserLogs.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumbersOfUserLogs.Name = "NumbersOfUserLogs";
            this.NumbersOfUserLogs.Size = new System.Drawing.Size(61, 23);
            this.NumbersOfUserLogs.TabIndex = 4;
            this.NumbersOfUserLogs.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumbersOfUserLogs.ValueChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // NumbersOfCompLogs
            // 
            this.NumbersOfCompLogs.Location = new System.Drawing.Point(55, 21);
            this.NumbersOfCompLogs.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumbersOfCompLogs.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumbersOfCompLogs.Name = "NumbersOfCompLogs";
            this.NumbersOfCompLogs.Size = new System.Drawing.Size(61, 23);
            this.NumbersOfCompLogs.TabIndex = 4;
            this.NumbersOfCompLogs.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumbersOfCompLogs.ValueChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // HistoryLogBox
            // 
            this.HistoryLogBox.Controls.Add(this.HistoryLogCheck);
            this.HistoryLogBox.Location = new System.Drawing.Point(20, 11);
            this.HistoryLogBox.Name = "HistoryLogBox";
            this.HistoryLogBox.Size = new System.Drawing.Size(167, 52);
            this.HistoryLogBox.TabIndex = 0;
            this.HistoryLogBox.TabStop = false;
            this.HistoryLogBox.Text = "Historia logów";
            // 
            // HistoryLogCheck
            // 
            this.HistoryLogCheck.AutoSize = true;
            this.HistoryLogCheck.Location = new System.Drawing.Point(6, 22);
            this.HistoryLogCheck.Name = "HistoryLogCheck";
            this.HistoryLogCheck.Size = new System.Drawing.Size(83, 19);
            this.HistoryLogCheck.TabIndex = 0;
            this.HistoryLogCheck.Text = "Wyłaczone";
            this.HistoryLogCheck.UseVisualStyleBackColor = true;
            this.HistoryLogCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.HistoryLogCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.HistoryLogCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // SessionTab
            // 
            this.SessionTab.BackColor = System.Drawing.Color.Transparent;
            this.SessionTab.Controls.Add(this.SessionShortcutBox);
            this.SessionTab.Controls.Add(this.CustomSourceBox);
            this.SessionTab.Location = new System.Drawing.Point(4, 24);
            this.SessionTab.Name = "SessionTab";
            this.SessionTab.Size = new System.Drawing.Size(768, 378);
            this.SessionTab.TabIndex = 2;
            this.SessionTab.Text = "Sesje";
            this.SessionTab.UseVisualStyleBackColor = true;
            // 
            // SessionShortcutBox
            // 
            this.SessionShortcutBox.Controls.Add(this.SessionShortcutText);
            this.SessionShortcutBox.Controls.Add(this.SessionShortcutLabel);
            this.SessionShortcutBox.Location = new System.Drawing.Point(23, 175);
            this.SessionShortcutBox.Name = "SessionShortcutBox";
            this.SessionShortcutBox.Size = new System.Drawing.Size(257, 100);
            this.SessionShortcutBox.TabIndex = 3;
            this.SessionShortcutBox.TabStop = false;
            this.SessionShortcutBox.Text = "Skrót klawiszowy do rozłączenia";
            // 
            // SessionShortcutText
            // 
            this.SessionShortcutText.Location = new System.Drawing.Point(144, 20);
            this.SessionShortcutText.Name = "SessionShortcutText";
            this.SessionShortcutText.ReadOnly = true;
            this.SessionShortcutText.Size = new System.Drawing.Size(95, 23);
            this.SessionShortcutText.TabIndex = 1;
            this.SessionShortcutText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.SessionShortcutText.Text = "Control + *";
            this.SessionShortcutText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SessionShortcutText_KeyDown);
            // 
            // SessionShortcutLabel
            // 
            this.SessionShortcutLabel.AutoSize = true;
            this.SessionShortcutLabel.Location = new System.Drawing.Point(8, 23);
            this.SessionShortcutLabel.Name = "SessionShortcutLabel";
            this.SessionShortcutLabel.Size = new System.Drawing.Size(130, 15);
            this.SessionShortcutLabel.TabIndex = 0;
            this.SessionShortcutLabel.Text = "Ustaw skrót klawiszowy";
            this.SessionShortcutLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.SessionShortcutLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // CustomSourceBox
            // 
            this.CustomSourceBox.Controls.Add(this.CustomSourceCheck);
            this.CustomSourceBox.Controls.Add(this.CustomSourceTextBox);
            this.CustomSourceBox.Location = new System.Drawing.Point(20, 11);
            this.CustomSourceBox.Name = "CustomSourceBox";
            this.CustomSourceBox.Size = new System.Drawing.Size(726, 141);
            this.CustomSourceBox.TabIndex = 2;
            this.CustomSourceBox.TabStop = false;
            this.CustomSourceBox.Text = "Zewnętrzne źródła";
            // 
            // CustomSourceCheck
            // 
            this.CustomSourceCheck.AutoSize = true;
            this.CustomSourceCheck.Location = new System.Drawing.Point(11, 23);
            this.CustomSourceCheck.Name = "CustomSourceCheck";
            this.CustomSourceCheck.Size = new System.Drawing.Size(83, 19);
            this.CustomSourceCheck.TabIndex = 1;
            this.CustomSourceCheck.Text = "Wyłączone";
            this.CustomSourceCheck.UseVisualStyleBackColor = true;
            this.CustomSourceCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.CustomSourceCheck.CheckStateChanged += new System.EventHandler(this.EnablingTextBox);
            this.CustomSourceCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.CustomSourceCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // CustomSourceTextBox
            // 
            this.CustomSourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomSourceTextBox.Location = new System.Drawing.Point(3, 50);
            this.CustomSourceTextBox.Name = "CustomSourceTextBox";
            this.CustomSourceTextBox.Size = new System.Drawing.Size(720, 87);
            this.CustomSourceTextBox.TabIndex = 0;
            this.CustomSourceTextBox.Text = "";
            this.CustomSourceTextBox.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // Other
            // 
            this.Other.Controls.Add(this.AutomaticallyAllowBox);
            this.Other.Location = new System.Drawing.Point(4, 24);
            this.Other.Name = "Other";
            this.Other.Padding = new System.Windows.Forms.Padding(3);
            this.Other.Size = new System.Drawing.Size(768, 378);
            this.Other.TabIndex = 1;
            this.Other.Text = "Inne";
            this.Other.UseVisualStyleBackColor = true;
            // 
            // AutomaticallyAllowBox
            // 
            this.AutomaticallyAllowBox.Controls.Add(this.SaveUserDataCheck);
            this.AutomaticallyAllowBox.Controls.Add(this.AutoUnlockFirewallCheck);
            this.AutomaticallyAllowBox.Controls.Add(this.AutoOpenPortCheck);
            this.AutomaticallyAllowBox.Location = new System.Drawing.Point(20, 11);
            this.AutomaticallyAllowBox.Name = "AutomaticallyAllowBox";
            this.AutomaticallyAllowBox.Size = new System.Drawing.Size(236, 100);
            this.AutomaticallyAllowBox.TabIndex = 2;
            this.AutomaticallyAllowBox.TabStop = false;
            this.AutomaticallyAllowBox.Text = "Automatyczne zezwolenia";
            // 
            // SaveUserDataCheck
            // 
            this.SaveUserDataCheck.AutoSize = true;
            this.SaveUserDataCheck.Location = new System.Drawing.Point(6, 75);
            this.SaveUserDataCheck.Name = "SaveUserDataCheck";
            this.SaveUserDataCheck.Size = new System.Drawing.Size(201, 19);
            this.SaveUserDataCheck.TabIndex = 0;
            this.SaveUserDataCheck.Text = "Zachowanie danych użytkownika";
            this.SaveUserDataCheck.UseVisualStyleBackColor = true;
            this.SaveUserDataCheck.CheckedChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.SaveUserDataCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.SaveUserDataCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // AutoUnlockFirewallCheck
            // 
            this.AutoUnlockFirewallCheck.AutoSize = true;
            this.AutoUnlockFirewallCheck.Location = new System.Drawing.Point(6, 50);
            this.AutoUnlockFirewallCheck.Name = "AutoUnlockFirewallCheck";
            this.AutoUnlockFirewallCheck.Size = new System.Drawing.Size(141, 19);
            this.AutoUnlockFirewallCheck.TabIndex = 0;
            this.AutoUnlockFirewallCheck.Text = "Odblokowanie zapory";
            this.AutoUnlockFirewallCheck.UseVisualStyleBackColor = true;
            this.AutoUnlockFirewallCheck.CheckedChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.AutoUnlockFirewallCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.AutoUnlockFirewallCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // AutoOpenPortCheck
            // 
            this.AutoOpenPortCheck.AutoSize = true;
            this.AutoOpenPortCheck.Location = new System.Drawing.Point(6, 25);
            this.AutoOpenPortCheck.Name = "AutoOpenPortCheck";
            this.AutoOpenPortCheck.Size = new System.Drawing.Size(196, 19);
            this.AutoOpenPortCheck.TabIndex = 0;
            this.AutoOpenPortCheck.Text = "Automatycznie otwieranie portu";
            this.AutoOpenPortCheck.UseVisualStyleBackColor = true;
            this.AutoOpenPortCheck.CheckedChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.AutoOpenPortCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.AutoOpenPortCheck.MouseLeave += new System.EventHandler(this.MouseOut);
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
            this.DescriptionLabel.MaximumSize = new System.Drawing.Size(762, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(0, 15);
            this.DescriptionLabel.TabIndex = 0;
            // 
            // RestoreDefaultButton
            // 
            this.RestoreDefaultButton.Location = new System.Drawing.Point(448, 415);
            this.RestoreDefaultButton.Name = "RestoreDefaultButton";
            this.RestoreDefaultButton.Size = new System.Drawing.Size(178, 23);
            this.RestoreDefaultButton.TabIndex = 4;
            this.RestoreDefaultButton.Text = "Przywróć ustawienia domyślne";
            this.RestoreDefaultButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultButton.Click += new System.EventHandler(this.RestoreDefaultSettings);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RestoreDefaultButton);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TabSettings);
            this.Name = "SettingsForm";
            this.Text = "Ustawienia";
            this.TabSettings.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            this.CustomValueBox.ResumeLayout(false);
            this.CustomValueBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumbersOfUserLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumbersOfCompLogs)).EndInit();
            this.HistoryLogBox.ResumeLayout(false);
            this.HistoryLogBox.PerformLayout();
            this.SessionTab.ResumeLayout(false);
            this.SessionShortcutBox.ResumeLayout(false);
            this.SessionShortcutBox.PerformLayout();
            this.CustomSourceBox.ResumeLayout(false);
            this.CustomSourceBox.PerformLayout();
            this.Other.ResumeLayout(false);
            this.AutomaticallyAllowBox.ResumeLayout(false);
            this.AutomaticallyAllowBox.PerformLayout();
            this.DescriptionBox.ResumeLayout(false);
            this.DescriptionBox.PerformLayout();
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
        private System.Windows.Forms.CheckBox HistoryLogCheck;
        private System.Windows.Forms.GroupBox CustomValueBox;
        private System.Windows.Forms.Label UserMaxLogs;
        private System.Windows.Forms.Label CompMaxLogs;
        private System.Windows.Forms.NumericUpDown NumbersOfUserLogs;
        private System.Windows.Forms.NumericUpDown NumbersOfCompLogs;
        private System.Windows.Forms.TabPage SessionTab;
        private System.Windows.Forms.GroupBox CustomSourceBox;
        private System.Windows.Forms.RichTextBox CustomSourceTextBox;
        private System.Windows.Forms.CheckBox CustomSourceCheck;
        private System.Windows.Forms.GroupBox AutomaticallyAllowBox;
        private System.Windows.Forms.CheckBox SaveUserDataCheck;
        private System.Windows.Forms.CheckBox AutoUnlockFirewallCheck;
        private System.Windows.Forms.CheckBox AutoOpenPortCheck;
        private System.Windows.Forms.GroupBox SessionShortcutBox;
        private System.Windows.Forms.TextBox SessionShortcutText;
        private System.Windows.Forms.Label SessionShortcutLabel;
        private System.Windows.Forms.Button RestoreDefaultButton;
    }
}

