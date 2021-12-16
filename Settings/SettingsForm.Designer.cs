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
            this.DomainControllerBox = new System.Windows.Forms.GroupBox();
            this.DomainControllerText = new System.Windows.Forms.TextBox();
            this.ComputerInputBox = new System.Windows.Forms.GroupBox();
            this.ComputerInputCheck = new System.Windows.Forms.CheckBox();
            this.CustomValueBox = new System.Windows.Forms.GroupBox();
            this.UserMaxLogs = new System.Windows.Forms.Label();
            this.CompMaxLogs = new System.Windows.Forms.Label();
            this.UserMaxLogsNumeric = new System.Windows.Forms.NumericUpDown();
            this.CompMaxLogsNumeric = new System.Windows.Forms.NumericUpDown();
            this.HistoryLogBox = new System.Windows.Forms.GroupBox();
            this.HistoryLogCheck = new System.Windows.Forms.CheckBox();
            this.SessionTab = new System.Windows.Forms.TabPage();
            this.SessionShortcutBox = new System.Windows.Forms.GroupBox();
            this.SessionDisconectShortcutText = new System.Windows.Forms.TextBox();
            this.SessionShortcutLabel = new System.Windows.Forms.Label();
            this.CustomSourceBox = new System.Windows.Forms.GroupBox();
            this.CustomSourceCheck = new System.Windows.Forms.CheckBox();
            this.CustomDataSourceTextBox = new System.Windows.Forms.RichTextBox();
            this.UpdaterTab = new System.Windows.Forms.TabPage();
            this.localUpdateBox = new System.Windows.Forms.GroupBox();
            this.LocalUpdatePathText = new System.Windows.Forms.TextBox();
            this.LocalUpdateCheck = new System.Windows.Forms.CheckBox();
            this.AutoStartUpdateBox = new System.Windows.Forms.GroupBox();
            this.AutoStartUpdateCheck = new System.Windows.Forms.CheckBox();
            this.Logs = new System.Windows.Forms.TabPage();
            this.MotpServerBox = new System.Windows.Forms.GroupBox();
            this.EventLogTableViewBox = new System.Windows.Forms.GroupBox();
            this.EventLogTableViewCheck = new System.Windows.Forms.CheckBox();
            this.MotpLogNameBox = new System.Windows.Forms.GroupBox();
            this.MotpLogNameText = new System.Windows.Forms.TextBox();
            this.MotpServersText = new System.Windows.Forms.TextBox();
            this.CheckLogsBeforeStartUpBox = new System.Windows.Forms.GroupBox();
            this.CheckLogsBeforeStartUpCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComputerLogsFolderTextBox = new System.Windows.Forms.TextBox();
            this.ComputerLogsFolderLabel = new System.Windows.Forms.Label();
            this.ComputerSNFileText = new System.Windows.Forms.TextBox();
            this.ComputerSNFileLabel = new System.Windows.Forms.Label();
            this.TerminalLogsBox = new System.Windows.Forms.GroupBox();
            this.TerminalLogsSNFileText = new System.Windows.Forms.TextBox();
            this.TerminalLogsSNFileLabel = new System.Windows.Forms.Label();
            this.TerminalLogsFileText = new System.Windows.Forms.TextBox();
            this.TerminalLogsFileLabel = new System.Windows.Forms.Label();
            this.TerminalLogsFolderText = new System.Windows.Forms.TextBox();
            this.TerminalLogsFolderLabel = new System.Windows.Forms.Label();
            this.Other = new System.Windows.Forms.TabPage();
            this.KeywordSearchingBox = new System.Windows.Forms.GroupBox();
            this.KeywordSearchingCheck = new System.Windows.Forms.CheckBox();
            this.AutomaticallyAllowBox = new System.Windows.Forms.GroupBox();
            this.SaveUserDataCheck = new System.Windows.Forms.CheckBox();
            this.AutoUnlockFirewallCheck = new System.Windows.Forms.CheckBox();
            this.AutoOpenPortCheck = new System.Windows.Forms.CheckBox();
            this.DescriptionBox = new System.Windows.Forms.GroupBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.RestoreDefaultButton = new System.Windows.Forms.Button();
            this.TabSettings.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            this.DomainControllerBox.SuspendLayout();
            this.ComputerInputBox.SuspendLayout();
            this.CustomValueBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMaxLogsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompMaxLogsNumeric)).BeginInit();
            this.HistoryLogBox.SuspendLayout();
            this.SessionTab.SuspendLayout();
            this.SessionShortcutBox.SuspendLayout();
            this.CustomSourceBox.SuspendLayout();
            this.UpdaterTab.SuspendLayout();
            this.localUpdateBox.SuspendLayout();
            this.AutoStartUpdateBox.SuspendLayout();
            this.Logs.SuspendLayout();
            this.MotpServerBox.SuspendLayout();
            this.EventLogTableViewBox.SuspendLayout();
            this.MotpLogNameBox.SuspendLayout();
            this.CheckLogsBeforeStartUpBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TerminalLogsBox.SuspendLayout();
            this.Other.SuspendLayout();
            this.KeywordSearchingBox.SuspendLayout();
            this.AutomaticallyAllowBox.SuspendLayout();
            this.DescriptionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(632, 415);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(713, 415);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Zamknij";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TabSettings
            // 
            this.TabSettings.Controls.Add(this.GeneralPage);
            this.TabSettings.Controls.Add(this.SessionTab);
            this.TabSettings.Controls.Add(this.UpdaterTab);
            this.TabSettings.Controls.Add(this.Logs);
            this.TabSettings.Controls.Add(this.Other);
            this.TabSettings.Location = new System.Drawing.Point(12, 3);
            this.TabSettings.Name = "TabSettings";
            this.TabSettings.SelectedIndex = 0;
            this.TabSettings.Size = new System.Drawing.Size(776, 406);
            this.TabSettings.TabIndex = 0;
            // 
            // GeneralPage
            // 
            this.GeneralPage.Controls.Add(this.DomainControllerBox);
            this.GeneralPage.Controls.Add(this.ComputerInputBox);
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
            // DomainControllerBox
            // 
            this.DomainControllerBox.Controls.Add(this.DomainControllerText);
            this.DomainControllerBox.Location = new System.Drawing.Point(20, 218);
            this.DomainControllerBox.Name = "DomainControllerBox";
            this.DomainControllerBox.Size = new System.Drawing.Size(209, 52);
            this.DomainControllerBox.TabIndex = 2;
            this.DomainControllerBox.TabStop = false;
            this.DomainControllerBox.Text = "Domyślny kontroler";
            // 
            // DomainControllerText
            // 
            this.DomainControllerText.Location = new System.Drawing.Point(6, 22);
            this.DomainControllerText.Name = "DomainControllerText";
            this.DomainControllerText.Size = new System.Drawing.Size(197, 23);
            this.DomainControllerText.TabIndex = 0;
            this.DomainControllerText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.DomainControllerText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.DomainControllerText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // ComputerInputBox
            // 
            this.ComputerInputBox.Controls.Add(this.ComputerInputCheck);
            this.ComputerInputBox.Location = new System.Drawing.Point(20, 159);
            this.ComputerInputBox.Name = "ComputerInputBox";
            this.ComputerInputBox.Size = new System.Drawing.Size(209, 53);
            this.ComputerInputBox.TabIndex = 1;
            this.ComputerInputBox.TabStop = false;
            this.ComputerInputBox.Text = "Podstawianie nazwy komputera:";
            // 
            // ComputerInputCheck
            // 
            this.ComputerInputCheck.AutoSize = true;
            this.ComputerInputCheck.Location = new System.Drawing.Point(6, 23);
            this.ComputerInputCheck.Name = "ComputerInputCheck";
            this.ComputerInputCheck.Size = new System.Drawing.Size(83, 19);
            this.ComputerInputCheck.TabIndex = 0;
            this.ComputerInputCheck.Text = "Wyłączone";
            this.ComputerInputCheck.UseVisualStyleBackColor = true;
            this.ComputerInputCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.ComputerInputCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.ComputerInputCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // CustomValueBox
            // 
            this.CustomValueBox.Controls.Add(this.UserMaxLogs);
            this.CustomValueBox.Controls.Add(this.CompMaxLogs);
            this.CustomValueBox.Controls.Add(this.UserMaxLogsNumeric);
            this.CustomValueBox.Controls.Add(this.CompMaxLogsNumeric);
            this.CustomValueBox.Location = new System.Drawing.Point(20, 13);
            this.CustomValueBox.Name = "CustomValueBox";
            this.CustomValueBox.Size = new System.Drawing.Size(209, 82);
            this.CustomValueBox.TabIndex = 0;
            this.CustomValueBox.TabStop = false;
            this.CustomValueBox.Text = "Niestandardowe wartości:";
            // 
            // UserMaxLogs
            // 
            this.UserMaxLogs.AutoSize = true;
            this.UserMaxLogs.Location = new System.Drawing.Point(16, 23);
            this.UserMaxLogs.Name = "UserMaxLogs";
            this.UserMaxLogs.Size = new System.Drawing.Size(33, 15);
            this.UserMaxLogs.TabIndex = 0;
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
            this.CompMaxLogs.TabIndex = 1;
            this.CompMaxLogs.Text = "Max:";
            this.CompMaxLogs.MouseEnter += new System.EventHandler(this.MouseOn);
            this.CompMaxLogs.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // UserMaxLogsNumeric
            // 
            this.UserMaxLogsNumeric.Location = new System.Drawing.Point(55, 50);
            this.UserMaxLogsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.UserMaxLogsNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.UserMaxLogsNumeric.Name = "UserMaxLogsNumeric";
            this.UserMaxLogsNumeric.Size = new System.Drawing.Size(61, 23);
            this.UserMaxLogsNumeric.TabIndex = 3;
            this.UserMaxLogsNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.UserMaxLogsNumeric.ValueChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // CompMaxLogsNumeric
            // 
            this.CompMaxLogsNumeric.Location = new System.Drawing.Point(55, 21);
            this.CompMaxLogsNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CompMaxLogsNumeric.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CompMaxLogsNumeric.Name = "CompMaxLogsNumeric";
            this.CompMaxLogsNumeric.Size = new System.Drawing.Size(61, 23);
            this.CompMaxLogsNumeric.TabIndex = 2;
            this.CompMaxLogsNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CompMaxLogsNumeric.ValueChanged += new System.EventHandler(this.OnChangeSaveProperty);
            // 
            // HistoryLogBox
            // 
            this.HistoryLogBox.Controls.Add(this.HistoryLogCheck);
            this.HistoryLogBox.Location = new System.Drawing.Point(20, 101);
            this.HistoryLogBox.Name = "HistoryLogBox";
            this.HistoryLogBox.Size = new System.Drawing.Size(209, 52);
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
            this.HistoryLogCheck.TabIndex = 1;
            this.HistoryLogCheck.Text = "Wyłaczone";
            this.HistoryLogCheck.UseVisualStyleBackColor = true;
            this.HistoryLogCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.HistoryLogCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.HistoryLogCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // SessionTab
            // 
            this.SessionTab.Controls.Add(this.SessionShortcutBox);
            this.SessionTab.Controls.Add(this.CustomSourceBox);
            this.SessionTab.Location = new System.Drawing.Point(4, 24);
            this.SessionTab.Name = "SessionTab";
            this.SessionTab.Size = new System.Drawing.Size(768, 378);
            this.SessionTab.TabIndex = 1;
            this.SessionTab.Text = "Sesje";
            this.SessionTab.UseVisualStyleBackColor = true;
            // 
            // SessionShortcutBox
            // 
            this.SessionShortcutBox.Controls.Add(this.SessionDisconectShortcutText);
            this.SessionShortcutBox.Controls.Add(this.SessionShortcutLabel);
            this.SessionShortcutBox.Location = new System.Drawing.Point(23, 175);
            this.SessionShortcutBox.Name = "SessionShortcutBox";
            this.SessionShortcutBox.Size = new System.Drawing.Size(302, 100);
            this.SessionShortcutBox.TabIndex = 1;
            this.SessionShortcutBox.TabStop = false;
            this.SessionShortcutBox.Text = "Skrót klawiszowy do rozłączenia";
            // 
            // SessionDisconectShortcutText
            // 
            this.SessionDisconectShortcutText.Location = new System.Drawing.Point(144, 20);
            this.SessionDisconectShortcutText.Name = "SessionDisconectShortcutText";
            this.SessionDisconectShortcutText.ReadOnly = true;
            this.SessionDisconectShortcutText.Size = new System.Drawing.Size(143, 23);
            this.SessionDisconectShortcutText.TabIndex = 3;
            this.SessionDisconectShortcutText.Text = "Control + Multiply";
            this.SessionDisconectShortcutText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.SessionDisconectShortcutText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SessionShortcutText_KeyDown);
            this.SessionDisconectShortcutText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.SessionDisconectShortcutText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // SessionShortcutLabel
            // 
            this.SessionShortcutLabel.AutoSize = true;
            this.SessionShortcutLabel.Location = new System.Drawing.Point(8, 23);
            this.SessionShortcutLabel.Name = "SessionShortcutLabel";
            this.SessionShortcutLabel.Size = new System.Drawing.Size(130, 15);
            this.SessionShortcutLabel.TabIndex = 1;
            this.SessionShortcutLabel.Text = "Ustaw skrót klawiszowy";
            this.SessionShortcutLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.SessionShortcutLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // CustomSourceBox
            // 
            this.CustomSourceBox.Controls.Add(this.CustomSourceCheck);
            this.CustomSourceBox.Controls.Add(this.CustomDataSourceTextBox);
            this.CustomSourceBox.Location = new System.Drawing.Point(20, 11);
            this.CustomSourceBox.Name = "CustomSourceBox";
            this.CustomSourceBox.Size = new System.Drawing.Size(726, 141);
            this.CustomSourceBox.TabIndex = 0;
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
            // CustomDataSourceTextBox
            // 
            this.CustomDataSourceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomDataSourceTextBox.Enabled = false;
            this.CustomDataSourceTextBox.Location = new System.Drawing.Point(3, 50);
            this.CustomDataSourceTextBox.Name = "CustomDataSourceTextBox";
            this.CustomDataSourceTextBox.Size = new System.Drawing.Size(720, 87);
            this.CustomDataSourceTextBox.TabIndex = 2;
            this.CustomDataSourceTextBox.Text = "";
            this.CustomDataSourceTextBox.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.CustomDataSourceTextBox.MouseEnter += new System.EventHandler(this.MouseOn);
            this.CustomDataSourceTextBox.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // UpdaterTab
            // 
            this.UpdaterTab.Controls.Add(this.localUpdateBox);
            this.UpdaterTab.Controls.Add(this.AutoStartUpdateBox);
            this.UpdaterTab.Location = new System.Drawing.Point(4, 24);
            this.UpdaterTab.Name = "UpdaterTab";
            this.UpdaterTab.Size = new System.Drawing.Size(768, 378);
            this.UpdaterTab.TabIndex = 2;
            this.UpdaterTab.Text = "Aktualizacje";
            this.UpdaterTab.UseVisualStyleBackColor = true;
            // 
            // localUpdateBox
            // 
            this.localUpdateBox.Controls.Add(this.LocalUpdatePathText);
            this.localUpdateBox.Controls.Add(this.LocalUpdateCheck);
            this.localUpdateBox.Location = new System.Drawing.Point(20, 69);
            this.localUpdateBox.Name = "localUpdateBox";
            this.localUpdateBox.Size = new System.Drawing.Size(255, 81);
            this.localUpdateBox.TabIndex = 1;
            this.localUpdateBox.TabStop = false;
            this.localUpdateBox.Text = "Aktualizacje lokalne";
            // 
            // LocalUpdatePathText
            // 
            this.LocalUpdatePathText.Enabled = false;
            this.LocalUpdatePathText.Location = new System.Drawing.Point(11, 47);
            this.LocalUpdatePathText.Name = "LocalUpdatePathText";
            this.LocalUpdatePathText.Size = new System.Drawing.Size(205, 23);
            this.LocalUpdatePathText.TabIndex = 2;
            this.LocalUpdatePathText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.LocalUpdatePathText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.LocalUpdatePathText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // LocalUpdateCheck
            // 
            this.LocalUpdateCheck.AutoSize = true;
            this.LocalUpdateCheck.Location = new System.Drawing.Point(11, 22);
            this.LocalUpdateCheck.Name = "LocalUpdateCheck";
            this.LocalUpdateCheck.Size = new System.Drawing.Size(83, 19);
            this.LocalUpdateCheck.TabIndex = 1;
            this.LocalUpdateCheck.Text = "Wyłączone";
            this.LocalUpdateCheck.UseVisualStyleBackColor = true;
            this.LocalUpdateCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.LocalUpdateCheck.CheckStateChanged += new System.EventHandler(this.EnablingTextBox);
            this.LocalUpdateCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.LocalUpdateCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // AutoStartUpdateBox
            // 
            this.AutoStartUpdateBox.Controls.Add(this.AutoStartUpdateCheck);
            this.AutoStartUpdateBox.Location = new System.Drawing.Point(20, 11);
            this.AutoStartUpdateBox.Name = "AutoStartUpdateBox";
            this.AutoStartUpdateBox.Size = new System.Drawing.Size(255, 52);
            this.AutoStartUpdateBox.TabIndex = 0;
            this.AutoStartUpdateBox.TabStop = false;
            this.AutoStartUpdateBox.Text = "AutoStart";
            // 
            // AutoStartUpdateCheck
            // 
            this.AutoStartUpdateCheck.AutoSize = true;
            this.AutoStartUpdateCheck.Location = new System.Drawing.Point(11, 23);
            this.AutoStartUpdateCheck.Name = "AutoStartUpdateCheck";
            this.AutoStartUpdateCheck.Size = new System.Drawing.Size(205, 19);
            this.AutoStartUpdateCheck.TabIndex = 0;
            this.AutoStartUpdateCheck.Text = "Sprawdzaj aktualizacje przy starcie";
            this.AutoStartUpdateCheck.UseVisualStyleBackColor = true;
            this.AutoStartUpdateCheck.CheckStateChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.AutoStartUpdateCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.AutoStartUpdateCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.MotpServerBox);
            this.Logs.Controls.Add(this.CheckLogsBeforeStartUpBox);
            this.Logs.Controls.Add(this.groupBox1);
            this.Logs.Controls.Add(this.TerminalLogsBox);
            this.Logs.Location = new System.Drawing.Point(4, 24);
            this.Logs.Name = "Logs";
            this.Logs.Padding = new System.Windows.Forms.Padding(3);
            this.Logs.Size = new System.Drawing.Size(768, 378);
            this.Logs.TabIndex = 3;
            this.Logs.Text = "Logi";
            this.Logs.UseVisualStyleBackColor = true;
            // 
            // MotpServerBox
            // 
            this.MotpServerBox.Controls.Add(this.EventLogTableViewBox);
            this.MotpServerBox.Controls.Add(this.MotpLogNameBox);
            this.MotpServerBox.Controls.Add(this.MotpServersText);
            this.MotpServerBox.Location = new System.Drawing.Point(513, 62);
            this.MotpServerBox.Name = "MotpServerBox";
            this.MotpServerBox.Size = new System.Drawing.Size(239, 174);
            this.MotpServerBox.TabIndex = 3;
            this.MotpServerBox.TabStop = false;
            this.MotpServerBox.Text = "Serwery MOTP z logami";
            // 
            // EventLogTableViewBox
            // 
            this.EventLogTableViewBox.Controls.Add(this.EventLogTableViewCheck);
            this.EventLogTableViewBox.Location = new System.Drawing.Point(7, 114);
            this.EventLogTableViewBox.Name = "EventLogTableViewBox";
            this.EventLogTableViewBox.Size = new System.Drawing.Size(227, 45);
            this.EventLogTableViewBox.TabIndex = 4;
            this.EventLogTableViewBox.TabStop = false;
            this.EventLogTableViewBox.Text = "Dziennik w formie tabeli";
            // 
            // EventLogTableViewCheck
            // 
            this.EventLogTableViewCheck.AutoSize = true;
            this.EventLogTableViewCheck.Location = new System.Drawing.Point(6, 16);
            this.EventLogTableViewCheck.Name = "EventLogTableViewCheck";
            this.EventLogTableViewCheck.Size = new System.Drawing.Size(83, 19);
            this.EventLogTableViewCheck.TabIndex = 3;
            this.EventLogTableViewCheck.Text = "Wyłączone";
            this.EventLogTableViewCheck.UseVisualStyleBackColor = true;
            this.EventLogTableViewCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.EventLogTableViewCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.EventLogTableViewCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // MotpLogNameBox
            // 
            this.MotpLogNameBox.Controls.Add(this.MotpLogNameText);
            this.MotpLogNameBox.Location = new System.Drawing.Point(6, 55);
            this.MotpLogNameBox.Name = "MotpLogNameBox";
            this.MotpLogNameBox.Size = new System.Drawing.Size(227, 53);
            this.MotpLogNameBox.TabIndex = 2;
            this.MotpLogNameBox.TabStop = false;
            this.MotpLogNameBox.Text = "LogName z dziennika";
            // 
            // MotpLogNameText
            // 
            this.MotpLogNameText.Location = new System.Drawing.Point(7, 22);
            this.MotpLogNameText.Name = "MotpLogNameText";
            this.MotpLogNameText.Size = new System.Drawing.Size(214, 23);
            this.MotpLogNameText.TabIndex = 1;
            this.MotpLogNameText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.MotpLogNameText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.MotpLogNameText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // MotpServersText
            // 
            this.MotpServersText.Location = new System.Drawing.Point(7, 24);
            this.MotpServersText.Name = "MotpServersText";
            this.MotpServersText.Size = new System.Drawing.Size(226, 23);
            this.MotpServersText.TabIndex = 0;
            this.MotpServersText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.MotpServersText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.MotpServersText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // CheckLogsBeforeStartUpBox
            // 
            this.CheckLogsBeforeStartUpBox.Controls.Add(this.CheckLogsBeforeStartUpCheck);
            this.CheckLogsBeforeStartUpBox.Location = new System.Drawing.Point(513, 11);
            this.CheckLogsBeforeStartUpBox.Name = "CheckLogsBeforeStartUpBox";
            this.CheckLogsBeforeStartUpBox.Size = new System.Drawing.Size(239, 45);
            this.CheckLogsBeforeStartUpBox.TabIndex = 2;
            this.CheckLogsBeforeStartUpBox.TabStop = false;
            this.CheckLogsBeforeStartUpBox.Text = "Odświeżaniu logów przy uruchomieniu";
            // 
            // CheckLogsBeforeStartUpCheck
            // 
            this.CheckLogsBeforeStartUpCheck.AutoSize = true;
            this.CheckLogsBeforeStartUpCheck.Location = new System.Drawing.Point(7, 22);
            this.CheckLogsBeforeStartUpCheck.Name = "CheckLogsBeforeStartUpCheck";
            this.CheckLogsBeforeStartUpCheck.Size = new System.Drawing.Size(83, 19);
            this.CheckLogsBeforeStartUpCheck.TabIndex = 0;
            this.CheckLogsBeforeStartUpCheck.Text = "Wyłączone";
            this.CheckLogsBeforeStartUpCheck.UseVisualStyleBackColor = true;
            this.CheckLogsBeforeStartUpCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.CheckLogsBeforeStartUpCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.CheckLogsBeforeStartUpCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComputerLogsFolderTextBox);
            this.groupBox1.Controls.Add(this.ComputerLogsFolderLabel);
            this.groupBox1.Controls.Add(this.ComputerSNFileText);
            this.groupBox1.Controls.Add(this.ComputerSNFileLabel);
            this.groupBox1.Location = new System.Drawing.Point(20, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wymagane do zbierania danych o komputerach";
            // 
            // ComputerLogsFolderTextBox
            // 
            this.ComputerLogsFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComputerLogsFolderTextBox.Location = new System.Drawing.Point(165, 22);
            this.ComputerLogsFolderTextBox.Name = "ComputerLogsFolderTextBox";
            this.ComputerLogsFolderTextBox.Size = new System.Drawing.Size(299, 23);
            this.ComputerLogsFolderTextBox.TabIndex = 8;
            this.ComputerLogsFolderTextBox.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.ComputerLogsFolderTextBox.MouseEnter += new System.EventHandler(this.MouseOn);
            this.ComputerLogsFolderTextBox.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // ComputerLogsFolderLabel
            // 
            this.ComputerLogsFolderLabel.AutoSize = true;
            this.ComputerLogsFolderLabel.Location = new System.Drawing.Point(6, 66);
            this.ComputerLogsFolderLabel.Name = "ComputerLogsFolderLabel";
            this.ComputerLogsFolderLabel.Size = new System.Drawing.Size(146, 15);
            this.ComputerLogsFolderLabel.TabIndex = 6;
            this.ComputerLogsFolderLabel.Text = "Plik z numerami seryjnymi";
            this.ComputerLogsFolderLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.ComputerLogsFolderLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // ComputerSNFileText
            // 
            this.ComputerSNFileText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComputerSNFileText.Location = new System.Drawing.Point(165, 62);
            this.ComputerSNFileText.Name = "ComputerSNFileText";
            this.ComputerSNFileText.Size = new System.Drawing.Size(299, 23);
            this.ComputerSNFileText.TabIndex = 7;
            this.ComputerSNFileText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.ComputerSNFileText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.ComputerSNFileText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // ComputerSNFileLabel
            // 
            this.ComputerSNFileLabel.AutoSize = true;
            this.ComputerSNFileLabel.Location = new System.Drawing.Point(6, 26);
            this.ComputerSNFileLabel.Name = "ComputerSNFileLabel";
            this.ComputerSNFileLabel.Size = new System.Drawing.Size(88, 15);
            this.ComputerSNFileLabel.TabIndex = 9;
            this.ComputerSNFileLabel.Text = "Folder z logami";
            this.ComputerSNFileLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.ComputerSNFileLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsBox
            // 
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsSNFileText);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsSNFileLabel);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFileText);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFileLabel);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFolderText);
            this.TerminalLogsBox.Controls.Add(this.TerminalLogsFolderLabel);
            this.TerminalLogsBox.Location = new System.Drawing.Point(20, 11);
            this.TerminalLogsBox.Name = "TerminalLogsBox";
            this.TerminalLogsBox.Size = new System.Drawing.Size(470, 137);
            this.TerminalLogsBox.TabIndex = 0;
            this.TerminalLogsBox.TabStop = false;
            this.TerminalLogsBox.Text = "Wymagane do zbierania danych o terminalach";
            // 
            // TerminalLogsSNFileText
            // 
            this.TerminalLogsSNFileText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalLogsSNFileText.Location = new System.Drawing.Point(165, 102);
            this.TerminalLogsSNFileText.Name = "TerminalLogsSNFileText";
            this.TerminalLogsSNFileText.Size = new System.Drawing.Size(299, 23);
            this.TerminalLogsSNFileText.TabIndex = 3;
            this.TerminalLogsSNFileText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.TerminalLogsSNFileText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsSNFileText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsSNFileLabel
            // 
            this.TerminalLogsSNFileLabel.AutoSize = true;
            this.TerminalLogsSNFileLabel.Location = new System.Drawing.Point(6, 106);
            this.TerminalLogsSNFileLabel.Name = "TerminalLogsSNFileLabel";
            this.TerminalLogsSNFileLabel.Size = new System.Drawing.Size(146, 15);
            this.TerminalLogsSNFileLabel.TabIndex = 1;
            this.TerminalLogsSNFileLabel.Text = "Plik z numerami seryjnymi";
            this.TerminalLogsSNFileLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsSNFileLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsFileText
            // 
            this.TerminalLogsFileText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalLogsFileText.Location = new System.Drawing.Point(165, 62);
            this.TerminalLogsFileText.Name = "TerminalLogsFileText";
            this.TerminalLogsFileText.Size = new System.Drawing.Size(299, 23);
            this.TerminalLogsFileText.TabIndex = 2;
            this.TerminalLogsFileText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.TerminalLogsFileText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFileText.MouseLeave += new System.EventHandler(this.MouseOut);
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
            // TerminalLogsFolderText
            // 
            this.TerminalLogsFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminalLogsFolderText.Location = new System.Drawing.Point(165, 22);
            this.TerminalLogsFolderText.Name = "TerminalLogsFolderText";
            this.TerminalLogsFolderText.Size = new System.Drawing.Size(299, 23);
            this.TerminalLogsFolderText.TabIndex = 1;
            this.TerminalLogsFolderText.TextChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.TerminalLogsFolderText.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFolderText.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // TerminalLogsFolderLabel
            // 
            this.TerminalLogsFolderLabel.AutoSize = true;
            this.TerminalLogsFolderLabel.Location = new System.Drawing.Point(6, 26);
            this.TerminalLogsFolderLabel.Name = "TerminalLogsFolderLabel";
            this.TerminalLogsFolderLabel.Size = new System.Drawing.Size(88, 15);
            this.TerminalLogsFolderLabel.TabIndex = 5;
            this.TerminalLogsFolderLabel.Text = "Folder z logami";
            this.TerminalLogsFolderLabel.MouseEnter += new System.EventHandler(this.MouseOn);
            this.TerminalLogsFolderLabel.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // Other
            // 
            this.Other.Controls.Add(this.KeywordSearchingBox);
            this.Other.Controls.Add(this.AutomaticallyAllowBox);
            this.Other.Location = new System.Drawing.Point(4, 24);
            this.Other.Name = "Other";
            this.Other.Padding = new System.Windows.Forms.Padding(3);
            this.Other.Size = new System.Drawing.Size(768, 378);
            this.Other.TabIndex = 4;
            this.Other.Text = "Inne";
            this.Other.UseVisualStyleBackColor = true;
            // 
            // KeywordSearchingBox
            // 
            this.KeywordSearchingBox.Controls.Add(this.KeywordSearchingCheck);
            this.KeywordSearchingBox.Location = new System.Drawing.Point(20, 117);
            this.KeywordSearchingBox.Name = "KeywordSearchingBox";
            this.KeywordSearchingBox.Size = new System.Drawing.Size(236, 47);
            this.KeywordSearchingBox.TabIndex = 1;
            this.KeywordSearchingBox.TabStop = false;
            this.KeywordSearchingBox.Text = "Wyszukiwanie loginu/nazwy komputera";
            // 
            // KeywordSearchingCheck
            // 
            this.KeywordSearchingCheck.AutoSize = true;
            this.KeywordSearchingCheck.Checked = true;
            this.KeywordSearchingCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeywordSearchingCheck.Location = new System.Drawing.Point(6, 22);
            this.KeywordSearchingCheck.Name = "KeywordSearchingCheck";
            this.KeywordSearchingCheck.Size = new System.Drawing.Size(77, 19);
            this.KeywordSearchingCheck.TabIndex = 0;
            this.KeywordSearchingCheck.Text = "Włączone";
            this.KeywordSearchingCheck.UseVisualStyleBackColor = true;
            this.KeywordSearchingCheck.CheckedChanged += new System.EventHandler(this.ChangeChecked);
            this.KeywordSearchingCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.KeywordSearchingCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // AutomaticallyAllowBox
            // 
            this.AutomaticallyAllowBox.Controls.Add(this.SaveUserDataCheck);
            this.AutomaticallyAllowBox.Controls.Add(this.AutoUnlockFirewallCheck);
            this.AutomaticallyAllowBox.Controls.Add(this.AutoOpenPortCheck);
            this.AutomaticallyAllowBox.Location = new System.Drawing.Point(20, 11);
            this.AutomaticallyAllowBox.Name = "AutomaticallyAllowBox";
            this.AutomaticallyAllowBox.Size = new System.Drawing.Size(236, 100);
            this.AutomaticallyAllowBox.TabIndex = 0;
            this.AutomaticallyAllowBox.TabStop = false;
            this.AutomaticallyAllowBox.Text = "Automatyczne zezwolenia";
            // 
            // SaveUserDataCheck
            // 
            this.SaveUserDataCheck.AutoSize = true;
            this.SaveUserDataCheck.Location = new System.Drawing.Point(6, 75);
            this.SaveUserDataCheck.Name = "SaveUserDataCheck";
            this.SaveUserDataCheck.Size = new System.Drawing.Size(201, 19);
            this.SaveUserDataCheck.TabIndex = 3;
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
            this.AutoUnlockFirewallCheck.TabIndex = 2;
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
            this.AutoOpenPortCheck.TabIndex = 1;
            this.AutoOpenPortCheck.Text = "Automatycznie otwieranie portu";
            this.AutoOpenPortCheck.UseVisualStyleBackColor = true;
            this.AutoOpenPortCheck.CheckedChanged += new System.EventHandler(this.OnChangeSaveProperty);
            this.AutoOpenPortCheck.MouseEnter += new System.EventHandler(this.MouseOn);
            this.AutoOpenPortCheck.MouseLeave += new System.EventHandler(this.MouseOut);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Controls.Add(this.DescriptionLabel);
            this.DescriptionBox.Location = new System.Drawing.Point(19, 303);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(762, 100);
            this.DescriptionBox.TabIndex = 5;
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
            this.RestoreDefaultButton.TabIndex = 5;
            this.RestoreDefaultButton.Text = "Przywróć ustawienia domyślne";
            this.RestoreDefaultButton.UseVisualStyleBackColor = true;
            this.RestoreDefaultButton.Click += new System.EventHandler(this.RestoreDefaultSettings);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.RestoreDefaultButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TabSettings);
            this.Icon = global::Settings.Properties.Resources.PuzzelSettings;
            this.Name = "SettingsForm";
            this.Text = "Ustawienia";
            this.TabSettings.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            this.DomainControllerBox.ResumeLayout(false);
            this.DomainControllerBox.PerformLayout();
            this.ComputerInputBox.ResumeLayout(false);
            this.ComputerInputBox.PerformLayout();
            this.CustomValueBox.ResumeLayout(false);
            this.CustomValueBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserMaxLogsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompMaxLogsNumeric)).EndInit();
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
            this.AutoStartUpdateBox.ResumeLayout(false);
            this.AutoStartUpdateBox.PerformLayout();
            this.Logs.ResumeLayout(false);
            this.MotpServerBox.ResumeLayout(false);
            this.MotpServerBox.PerformLayout();
            this.EventLogTableViewBox.ResumeLayout(false);
            this.EventLogTableViewBox.PerformLayout();
            this.MotpLogNameBox.ResumeLayout(false);
            this.MotpLogNameBox.PerformLayout();
            this.CheckLogsBeforeStartUpBox.ResumeLayout(false);
            this.CheckLogsBeforeStartUpBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TerminalLogsBox.ResumeLayout(false);
            this.TerminalLogsBox.PerformLayout();
            this.Other.ResumeLayout(false);
            this.KeywordSearchingBox.ResumeLayout(false);
            this.KeywordSearchingBox.PerformLayout();
            this.AutomaticallyAllowBox.ResumeLayout(false);
            this.AutomaticallyAllowBox.PerformLayout();
            this.DescriptionBox.ResumeLayout(false);
            this.DescriptionBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button RestoreDefaultButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox AutoOpenPortCheck;
        private System.Windows.Forms.CheckBox AutoStartUpdateCheck;
        private System.Windows.Forms.CheckBox AutoUnlockFirewallCheck;
        private System.Windows.Forms.CheckBox CustomSourceCheck;
        private System.Windows.Forms.CheckBox HistoryLogCheck;
        private System.Windows.Forms.CheckBox LocalUpdateCheck;
        private System.Windows.Forms.CheckBox SaveUserDataCheck;
        private System.Windows.Forms.GroupBox AutomaticallyAllowBox;
        private System.Windows.Forms.GroupBox AutoStartUpdateBox;
        private System.Windows.Forms.GroupBox CustomSourceBox;
        private System.Windows.Forms.GroupBox CustomValueBox;
        private System.Windows.Forms.GroupBox DescriptionBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox HistoryLogBox;
        private System.Windows.Forms.GroupBox localUpdateBox;
        private System.Windows.Forms.GroupBox SessionShortcutBox;
        private System.Windows.Forms.GroupBox TerminalLogsBox;
        private System.Windows.Forms.Label CompMaxLogs;
        private System.Windows.Forms.Label ComputerLogsFolderLabel;
        private System.Windows.Forms.Label ComputerSNFileLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label SessionShortcutLabel;
        private System.Windows.Forms.Label TerminalLogsFileLabel;
        private System.Windows.Forms.Label TerminalLogsFolderLabel;
        private System.Windows.Forms.Label TerminalLogsSNFileLabel;
        private System.Windows.Forms.Label UserMaxLogs;
        private System.Windows.Forms.NumericUpDown CompMaxLogsNumeric;
        private System.Windows.Forms.NumericUpDown UserMaxLogsNumeric;
        private System.Windows.Forms.RichTextBox CustomDataSourceTextBox;
        private System.Windows.Forms.TabControl TabSettings;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage Other;
        private System.Windows.Forms.TabPage SessionTab;
        private System.Windows.Forms.TabPage Logs;
        private System.Windows.Forms.TabPage UpdaterTab;
        private System.Windows.Forms.TextBox ComputerLogsFolderTextBox;
        private System.Windows.Forms.TextBox ComputerSNFileText;
        private System.Windows.Forms.TextBox LocalUpdatePathText;
        private System.Windows.Forms.TextBox SessionDisconectShortcutText;
        private System.Windows.Forms.TextBox TerminalLogsFileText;
        private System.Windows.Forms.TextBox TerminalLogsFolderText;
        private System.Windows.Forms.TextBox TerminalLogsSNFileText;
        private System.Windows.Forms.GroupBox CheckLogsBeforeStartUpBox;
        private System.Windows.Forms.CheckBox CheckLogsBeforeStartUpCheck;
        private System.Windows.Forms.GroupBox MotpServerBox;
        private System.Windows.Forms.GroupBox MotpLogNameBox;
        private System.Windows.Forms.TextBox MotpLogNameText;
        private System.Windows.Forms.TextBox MotpServersText;
        private System.Windows.Forms.GroupBox ComputerInputBox;
        private System.Windows.Forms.CheckBox ComputerInputCheck;
        private System.Windows.Forms.CheckBox EventLogTableViewCheck;
        private System.Windows.Forms.GroupBox EventLogTableViewBox;
        private System.Windows.Forms.GroupBox DomainControllerBox;
        private System.Windows.Forms.TextBox DomainControllerText;
        private System.Windows.Forms.GroupBox KeywordSearchingBox;
        private System.Windows.Forms.CheckBox KeywordSearchingCheck;
    }
}

