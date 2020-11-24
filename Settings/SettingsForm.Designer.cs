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
            this.UpdaterTab = new System.Windows.Forms.TabPage();
            this.localUpdateBox = new System.Windows.Forms.GroupBox();
            this.localUpdateTextBox = new System.Windows.Forms.TextBox();
            this.localUpdateCheck = new System.Windows.Forms.CheckBox();
            this.AutostartUpdateBox = new System.Windows.Forms.GroupBox();
            this.AutostartUpdateCheck = new System.Windows.Forms.CheckBox();
            this.TerminalLogsTab = new System.Windows.Forms.TabPage();
            this.TerminalLogsBox = new System.Windows.Forms.GroupBox();
            this.TerminalLogsSNFileTextBox = new System.Windows.Forms.TextBox();
            this.TerminalLogsSNFileLabel = new System.Windows.Forms.Label();
            this.TerminalLogsFileTextBox = new System.Windows.Forms.TextBox();
            this.TerminalLogsFileLabel = new System.Windows.Forms.Label();
            this.TerminalLogsFolderTextBox = new System.Windows.Forms.TextBox();
            this.TerminalLogsFolderLabel = new System.Windows.Forms.Label();
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
            this.UpdaterTab.SuspendLayout();
            this.localUpdateBox.SuspendLayout();
            this.AutostartUpdateBox.SuspendLayout();
            this.TerminalLogsTab.SuspendLayout();
            this.TerminalLogsBox.SuspendLayout();
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
            this.TabSettings.Controls.Add(this.UpdaterTab);
            this.TabSettings.Controls.Add(this.TerminalLogsTab);
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
            this.SessionShortcutBox.Size = new System.Drawing.Size(302, 100);
            this.SessionShortcutBox.TabIndex = 3;
            this.SessionShortcutBox.TabStop = false;
            this.SessionShortcutBox.Text = "Skrót klawiszowy do rozłączenia";
            // 
            // SessionShortcutText
            // 
            this.SessionShortcutText.Location = new System.Drawing.Point(144, 20);
            this.SessionShortcutText.Name = "SessionShortcutText";
            this.SessionShortcutText.ReadOnly = true;
            this.SessionShortcutText.Size = new System.Drawing.Size(143, 23);
            this.SessionShortcutText.TabIndex = 1;
            this.SessionShortcutText.Text = "Control + Multiply";
            this.SessionShortcutText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
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
            this.CustomSourceTextBox.Enabled = false;
            this.CustomSourceTextBox.Location = new System.Drawing.Point(3, 50);
            this.CustomSourceTextBox.Name = "CustomSourceTextBox";
            this.CustomSourceTextBox.Size = new System.Drawing.Size(720, 87);
            this.CustomSourceTextBox.TabIndex = 0;
            this.CustomSourceTextBox.Text = "";
            this.CustomSourceTextBox.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // UpdaterTab
            // 
            this.UpdaterTab.BackColor = System.Drawing.Color.Transparent;
            this.UpdaterTab.Controls.Add(this.localUpdateBox);
            this.UpdaterTab.Controls.Add(this.AutostartUpdateBox);
            this.UpdaterTab.Location = new System.Drawing.Point(4, 24);
            this.UpdaterTab.Name = "UpdaterTab";
            this.UpdaterTab.Size = new System.Drawing.Size(768, 378);
            this.UpdaterTab.TabIndex = 3;
            this.UpdaterTab.Text = "Aktualizacje";
            this.UpdaterTab.UseVisualStyleBackColor = true;
            // 
            // localUpdateBox
            // 
            this.localUpdateBox.Controls.Add(this.localUpdateTextBox);
            this.localUpdateBox.Controls.Add(this.localUpdateCheck);
            this.localUpdateBox.Location = new System.Drawing.Point(20, 69);
            this.localUpdateBox.Name = "localUpdateBox";
            this.localUpdateBox.Size = new System.Drawing.Size(398, 81);
            this.localUpdateBox.TabIndex = 1;
            this.localUpdateBox.TabStop = false;
            this.localUpdateBox.Text = "Aktualizacje lokalne";
            // 
            // localUpdateTextBox
            // 
            this.localUpdateTextBox.Enabled = false;
            this.localUpdateTextBox.Location = new System.Drawing.Point(11, 47);
            this.localUpdateTextBox.Name = "localUpdateTextBox";
            this.localUpdateTextBox.Size = new System.Drawing.Size(205, 23);
            this.localUpdateTextBox.TabIndex = 1;
            this.localUpdateTextBox.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // localUpdateCheck
            // 
            this.localUpdateCheck.AutoSize = true;
            this.localUpdateCheck.Location = new System.Drawing.Point(11, 22);
            this.localUpdateCheck.Name = "localUpdateCheck";
            this.localUpdateCheck.Size = new System.Drawing.Size(83, 19);
            this.localUpdateCheck.TabIndex = 0;
            this.localUpdateCheck.Text = "Wyłączone";
            this.localUpdateCheck.UseVisualStyleBackColor = true;
            this.localUpdateCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.localUpdateCheck.CheckStateChanged += new System.EventHandler(this.EnablingTextBox);
            this.localUpdateCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.localUpdateCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // AutostartUpdateBox
            // 
            this.AutostartUpdateBox.Controls.Add(this.AutostartUpdateCheck);
            this.AutostartUpdateBox.Location = new System.Drawing.Point(20, 11);
            this.AutostartUpdateBox.Name = "AutostartUpdateBox";
            this.AutostartUpdateBox.Size = new System.Drawing.Size(226, 52);
            this.AutostartUpdateBox.TabIndex = 0;
            this.AutostartUpdateBox.TabStop = false;
            this.AutostartUpdateBox.Text = "Autostart";
            // 
            // AutostartUpdateCheck
            // 
            this.AutostartUpdateCheck.AutoSize = true;
            this.AutostartUpdateCheck.Location = new System.Drawing.Point(11, 23);
            this.AutostartUpdateCheck.Name = "AutostartUpdateCheck";
            this.AutostartUpdateCheck.Size = new System.Drawing.Size(205, 19);
            this.AutostartUpdateCheck.TabIndex = 0;
            this.AutostartUpdateCheck.Text = "Sprawdzaj aktualizacje przy starcie";
            this.AutostartUpdateCheck.UseVisualStyleBackColor = true;
            this.AutostartUpdateCheck.CheckStateChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.AutostartUpdateCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.AutostartUpdateCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsTab
            // 
            this.TerminalLogsTab.Controls.Add(this.TerminalLogsBox);
            this.TerminalLogsTab.Location = new System.Drawing.Point(4, 24);
            this.TerminalLogsTab.Name = "TerminalLogsTab";
            this.TerminalLogsTab.Padding = new System.Windows.Forms.Padding(3);
            this.TerminalLogsTab.Size = new System.Drawing.Size(768, 378);
            this.TerminalLogsTab.TabIndex = 4;
            this.TerminalLogsTab.Text = "LogiTerminali";
            this.TerminalLogsTab.UseVisualStyleBackColor = true;
            // 
            // TerminalLogsBox
            // 
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsSNFileTextBox);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsSNFileLabel);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFileTextBox);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFileLabel);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFolderTextBox);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFolderLabel);
            this.TerminalLogsBox.Location = new System.Drawing.Point(6, 4);
            this.TerminalLogsBox.Name = "TerminalLogsBox";
            this.TerminalLogsBox.Size = new System.Drawing.Size(470, 137);
            this.TerminalLogsBox.TabIndex = 0;
            this.TerminalLogsBox.TabStop = false;
            this.TerminalLogsBox.Text = "Wymagane do zbierania danych o terminalach";
            // 
            // TerminalLogsSNFileTextBox
            // 
            this.TerminalLogsSNFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalLogsSNFileTextBox.Location = new System.Drawing.Point(165, 101);
            this.TerminalLogsSNFileTextBox.Name = "TerminalLogsSNFileTextBox";
            this.TerminalLogsSNFileTextBox.Size = new System.Drawing.Size(299, 23);
            this.TerminalLogsSNFileTextBox.TabIndex = 5;
            this.TerminalLogsSNFileTextBox.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsSNFileTextBox.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsSNFileLabel
            // 
            this.TerminalLogsSNFileLabel.AutoSize = true;
            this.TerminalLogsSNFileLabel.Location = new System.Drawing.Point(6, 105);
            this.TerminalLogsSNFileLabel.Name = "TerminalLogsSNFileLabel";
            this.TerminalLogsSNFileLabel.Size = new System.Drawing.Size(146, 15);
            this.TerminalLogsSNFileLabel.TabIndex = 6;
            this.TerminalLogsSNFileLabel.Text = "Plik z numerami seryjnymi";
            this.TerminalLogsSNFileLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsSNFileLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsFileTextBox
            // 
            this.TerminalLogsFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalLogsFileTextBox.Location = new System.Drawing.Point(165, 62);
            this.TerminalLogsFileTextBox.Name = "TerminalLogsFileTextBox";
            this.TerminalLogsFileTextBox.Size = new System.Drawing.Size(299, 23);
            this.TerminalLogsFileTextBox.TabIndex = 3;
            this.TerminalLogsFileTextBox.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFileTextBox.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsFileLabel
            // 
            this.TerminalLogsFileLabel.AutoSize = true;
            this.TerminalLogsFileLabel.Location = new System.Drawing.Point(6, 66);
            this.TerminalLogsFileLabel.Name = "TerminalLogsFileLabel";
            this.TerminalLogsFileLabel.Size = new System.Drawing.Size(77, 15);
            this.TerminalLogsFileLabel.TabIndex = 4;
            this.TerminalLogsFileLabel.Text = "Pliki z logami";
            this.TerminalLogsFileLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFileLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsFolderTextBox
            // 
            this.TerminalLogsFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalLogsFolderTextBox.Location = new System.Drawing.Point(165, 22);
            this.TerminalLogsFolderTextBox.Name = "TerminalLogsFolderTextBox";
            this.TerminalLogsFolderTextBox.Size = new System.Drawing.Size(299, 23);
            this.TerminalLogsFolderTextBox.TabIndex = 1;
            this.TerminalLogsFolderTextBox.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFolderTextBox.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsFolderLabel
            // 
            this.TerminalLogsFolderLabel.AutoSize = true;
            this.TerminalLogsFolderLabel.Location = new System.Drawing.Point(6, 26);
            this.TerminalLogsFolderLabel.Name = "TerminalLogsFolderLabel";
            this.TerminalLogsFolderLabel.Size = new System.Drawing.Size(88, 15);
            this.TerminalLogsFolderLabel.TabIndex = 2;
            this.TerminalLogsFolderLabel.Text = "Folder z logami";
            this.TerminalLogsFolderLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFolderLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // Other
            // 
            this.Other.Controls.Add(this.AutomaticallyAllowBox);
            this.Other.Location = new System.Drawing.Point(4, 24);
            this.Other.Name = "Other";
            this.Other.Padding = new System.Windows.Forms.Padding(3);
            this.Other.Size = new System.Drawing.Size(768, 378);
            this.Other.TabIndex = 5;
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
            this.ClientSize = new System.Drawing.Size(799, 450);
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
            this.UpdaterTab.ResumeLayout(false);
            this.localUpdateBox.ResumeLayout(false);
            this.localUpdateBox.PerformLayout();
            this.AutostartUpdateBox.ResumeLayout(false);
            this.AutostartUpdateBox.PerformLayout();
            this.TerminalLogsTab.ResumeLayout(false);
            this.TerminalLogsBox.ResumeLayout(false);
            this.TerminalLogsBox.PerformLayout();
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
        private System.Windows.Forms.TabPage UpdaterTab;
        private System.Windows.Forms.TabPage TerminalLogsTab;
        private System.Windows.Forms.GroupBox AutostartUpdateBox;
        private System.Windows.Forms.CheckBox AutostartUpdateCheck;
        private System.Windows.Forms.GroupBox localUpdateBox;
        private System.Windows.Forms.TextBox localUpdateTextBox;
        private System.Windows.Forms.CheckBox localUpdateCheck;
        private System.Windows.Forms.GroupBox TerminalLogsBox;
        private System.Windows.Forms.TextBox TerminalLogsFolderTextBox;
        private System.Windows.Forms.Label TerminalLogsFolderLabel;
        private System.Windows.Forms.TextBox TerminalLogsSNFileTextBox;
        private System.Windows.Forms.Label TerminalLogsSNFileLabel;
        private System.Windows.Forms.TextBox TerminalLogsFileTextBox;
        private System.Windows.Forms.Label TerminalLogsFileLabel;
    }
}

