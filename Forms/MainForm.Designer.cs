namespace Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new(typeof(MainForm));
            this.groupBoxUserInfo = new();
            this.comboBoxLogin = new();
            this.contextMenuOperationTextBox = new(this.components);
            this.contextMenuItemCut = new();
            this.contextMenuItemCopy = new();
            this.contextMenuItemPaste = new();
            this.contextMenuItemSelectAll = new();
            this.btnProfilEXT = new();
            this.btnProfilTS = new();
            this.groupBoxLogoff = new();
            this.btnLogoffSession = new();
            this.btnConnectSession = new();
            this.comboBoxFindedSessions = new();
            this.BtnFindSession = new();
            this.btnProfilERI = new();
            this.btnProfilVFS = new();
            this.btnInfoZAd = new();
            this.btnUserLog = new();
            this.numericLogin = new();
            this.labelCountUserLogs = new();
            this.labelLogin = new();
            this.contextMenuOperationRichTextBox = new(this.components);
            this.contextMenuItemCutR = new();
            this.contextMenuItemCopyR = new();
            this.contextMenuItemPasteR = new();
            this.contextMenuItemSelectAllR = new();
            this.contextMenuItemSearchR = new();
            this.groupBoxComputerInfo = new();
            this.comboBoxComputer = new();
            this.btnRemoteTracert = new();
            this.btnRemotePing = new();
            this.btnRemoteCMD = new();
            this.contextMenuRemoteCMD = new(this.components);
            this.contextMenuItemRemoteCMDSystem = new();
            this.contextMenuItemCMD = new();
            this.contextMenuItemCMDRemoteCustomAuth = new();
            this.contextMenuItemPowerShell = new();
            this.contextMenuItemPowerShellRemoteCustomAuth = new();
            this.contextMenuItemRemotePowerShell = new();
            this.btnNetworkInterfaces = new();
            this.btnProgramList = new();
            this.btnExplorer = new();
            this.btnRDP = new();
            this.contextMenuRDP = new(this.components);
            this.menuItemRDPOpen = new();
            this.btnDW = new();
            this.DWMenuContext = new(this.components);
            this.menuItemDWEadm = new();
            this.menuItemDWLAPS = new();
            this.btnManagement = new();
            this.btnCompInfo = new();
            this.contextMenuComputerInfo = new(this.components);
            this.MsLicensingCache = new();
            this.menuItemComputerInfoDrivers = new();
            this.menuItemComputerInfoUptime = new();
            this.menuItemComputerInfoSNPN = new();
            this.menuItemComputerInfoModel = new();
            this.menuItemComputerInfoOS = new();
            this.menuItemComputerInfoRAM = new();
            this.menuItemComputerInfoProcessor = new();
            this.menuItemComputerInfoLoggedUser = new();
            this.menuItemComputerInfoProfile = new();
            this.btnReloadLogs = new();
            this.menuItemComputerInfoDrives = new();
            this.menuItemComputerInfoPrinters = new();
            this.menuItemComputerInfoShares = new();
            this.menuItemComputerInfoAutostart = new();
            this.menuItemComputerInfoPath = new();
            this.menuItemComputerInfoNetworkRes = new();
            this.menuItemComputerInfoDisplay = new();
            this.LogonsOnComputer = new();
            this.LogonsOnDomainHub = new();
            this.MotpLogons = new();
            this.TerminalCustomData = new();
            this.ComputerCustomData = new();
            this.menuItemComputerInfoBios = new();
            this.menuItemSettings = new();
            this.btnPing = new();
            this.numericComputer = new();
            this.labelCountCompLogs = new();
            this.labelComputer = new();
            this.btnCompLog = new();
            this.groupBoxOtherTools = new();
            this.panelTCP = new();
            this.numericTCP = new();
            this.labelTCP = new();
            this.btnTestTCP = new();
            this.btnCollapseTCP = new();
            this.btnFlushDNS = new();
            richTextBox1 = new();
            this.backgroundWorkerComputerInfo = new();
            this.statusBar1 = new();
            this.statusBP1 = new();
            this.statusBP2 = new();
            this.InfozAD = new();
            this.mainMenu = new();
            this.menuItemAbout = new();
            this.menuItemUpdate = new();
            this.menuItemFile = new();
            this.menuItemAdmTools = new();
            this.menuItemWindowsFirewall = new();
            this.menuItemDHCP = new();
            this.menuItemEventViewer = new();
            this.menuItemTaskshedule = new();
            this.menuItemServices = new();
            this.menuItemLusrmgr = new();
            this.menuItemTermimalExplorer = new();
            this.menuItemCustomName = new();
            this.menuItemComputerExplorer = new();
            this.menuItemActiveSessions = new();
            this.menuItemSessions = new();
            this.menuItemLAPSpwd = new();
            this.menuItemLockoutStatus = new();
            this.menuItemChangeDomainPassword = new();
            this.menuItemQuickFix = new();
            this.menuItemActivateOffice = new();
            this.menuItemEnableIEHosting = new();
            this.menuItemWinEnvironment = new();
            this.menuItemDeleteUsers = new();
            this.groupBoxUserInfo.SuspendLayout();
            this.contextMenuOperationTextBox.SuspendLayout();
            this.groupBoxLogoff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericLogin)).BeginInit();
            this.contextMenuOperationRichTextBox.SuspendLayout();
            this.groupBoxComputerInfo.SuspendLayout();
            this.contextMenuRemoteCMD.SuspendLayout();
            this.contextMenuRDP.SuspendLayout();
            this.DWMenuContext.SuspendLayout();
            this.contextMenuComputerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericComputer)).BeginInit();
            this.groupBoxOtherTools.SuspendLayout();
            this.panelTCP.SuspendLayout();
            this.statusBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTCP)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUserInfo
            // 
            this.groupBoxUserInfo.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxUserInfo.Controls.Add(this.comboBoxLogin);
            this.groupBoxUserInfo.Controls.Add(this.btnProfilEXT);
            this.groupBoxUserInfo.Controls.Add(this.btnProfilTS);
            this.groupBoxUserInfo.Controls.Add(this.groupBoxLogoff);
            this.groupBoxUserInfo.Controls.Add(this.btnProfilERI);
            this.groupBoxUserInfo.Controls.Add(this.btnProfilVFS);
            this.groupBoxUserInfo.Controls.Add(this.btnInfoZAd);
            this.groupBoxUserInfo.Controls.Add(this.btnUserLog);
            this.groupBoxUserInfo.Controls.Add(this.numericLogin);
            this.groupBoxUserInfo.Controls.Add(this.labelCountUserLogs);
            this.groupBoxUserInfo.Controls.Add(this.labelLogin);
            this.groupBoxUserInfo.Location = new(1, 26);
            this.groupBoxUserInfo.MinimumSize = new(1182, 75);
            this.groupBoxUserInfo.Name = "groupBoxUserInfo";
            this.groupBoxUserInfo.Size = new(1182, 75);
            this.groupBoxUserInfo.TabIndex = 1;
            this.groupBoxUserInfo.TabStop = false;
            this.groupBoxUserInfo.Text = "Informacje o użytkowniku:";
            // 
            // comboBoxLogin
            // 
            this.comboBoxLogin.ContextMenuStrip = this.contextMenuOperationTextBox;
            this.comboBoxLogin.FormattingEnabled = true;
            this.comboBoxLogin.Location = new(6, 40);
            this.comboBoxLogin.Name = "comboBoxLogin";
            this.comboBoxLogin.Size = new(121, 21);
            this.comboBoxLogin.TabIndex = 1;
            this.comboBoxLogin.KeyDown += new(this.Keys_KeyDown);
            this.comboBoxLogin.PreviewKeyDown += new(this.Keys_PreviewKeyDown);
            // 
            // contextMenuOperationTextBox
            // 
            this.contextMenuOperationTextBox.Items.AddRange(new[] {
            this.contextMenuItemCut,
            this.contextMenuItemCopy,
            this.contextMenuItemPaste,
            this.contextMenuItemSelectAll});
            this.contextMenuOperationTextBox.Name = "contextMenuOperationTextBox";
            this.contextMenuOperationTextBox.ShowImageMargin = false;
            // 
            // contextMenuItemCut
            // 
            this.contextMenuItemCut.Name = "contextMenuItemCut";
            this.contextMenuItemCut.ShortcutKeyDisplayString = "Ctrl + X";
            this.contextMenuItemCut.Text = "Wytnij";
            this.contextMenuItemCut.Click += new(this.ContextMenuItemCut_Click);
            // 
            // contextMenuItemCopy
            // 
            this.contextMenuItemCopy.Name = "contextMenuItemCopy";
            this.contextMenuItemCopy.ShortcutKeyDisplayString = "Ctrl + C";
            this.contextMenuItemCopy.Text = "Kopiuj";
            this.contextMenuItemCopy.Click += new(this.ContextMenuItemCopy_Click);
            // 
            // contextMenuItemPaste
            // 
            this.contextMenuItemPaste.Name = "contextMenuItemPaste";
            this.contextMenuItemPaste.ShortcutKeyDisplayString = "Ctrl + V";
            this.contextMenuItemPaste.Text = "Wklej";
            this.contextMenuItemPaste.Click += new(this.ContextMenuItemPaste_Click);
            // 
            // contextMenuItemSelectAll
            // 
            this.contextMenuItemSelectAll.Name = "contextMenuItemSelectAll";
            this.contextMenuItemSelectAll.ShortcutKeyDisplayString = "Ctrl + A";
            this.contextMenuItemSelectAll.Text = "Zaznacz wszystko";
            this.contextMenuItemSelectAll.Click += new(this.ContextMenuItemSelectAll_Click);
            // 
            // btnProfilEXT
            // 
            this.btnProfilEXT.Image = global::Forms.Resources.Resources.folder;
            this.btnProfilEXT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfilEXT.Location = new(393, 41);
            this.btnProfilEXT.Name = "btnProfilEXT";
            this.btnProfilEXT.Size = new(80, 30);
            this.btnProfilEXT.TabIndex = 0;
            this.btnProfilEXT.TabStop = false;
            this.btnProfilEXT.Text = "Profil EXT";
            this.btnProfilEXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfilEXT.UseVisualStyleBackColor = true;
            this.btnProfilEXT.Click += new(this.Profilsieciowy);
            // 
            // btnProfilTS
            // 
            this.btnProfilTS.Image = global::Forms.Resources.Resources.folder;
            this.btnProfilTS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfilTS.Location = new(393, 11);
            this.btnProfilTS.Name = "btnProfilTS";
            this.btnProfilTS.Size = new(80, 30);
            this.btnProfilTS.TabIndex = 1;
            this.btnProfilTS.TabStop = false;
            this.btnProfilTS.Text = "Profil TS";
            this.btnProfilTS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfilTS.UseVisualStyleBackColor = true;
            this.btnProfilTS.Click += new(this.Profilsieciowy);
            // 
            // groupBoxLogoff
            // 
            this.groupBoxLogoff.Controls.Add(this.btnLogoffSession);
            this.groupBoxLogoff.Controls.Add(this.btnConnectSession);
            this.groupBoxLogoff.Controls.Add(this.comboBoxFindedSessions);
            this.groupBoxLogoff.Controls.Add(this.BtnFindSession);
            this.groupBoxLogoff.Location = new(537, 11);
            this.groupBoxLogoff.Name = "groupBoxLogoff";
            this.groupBoxLogoff.Size = new(434, 60);
            this.groupBoxLogoff.TabIndex = 3;
            this.groupBoxLogoff.TabStop = false;
            this.groupBoxLogoff.Text = "LogOff";
            // 
            // btnLogoffSession
            // 
            this.btnLogoffSession.Image = global::Forms.Resources.Resources.Logoff;
            this.btnLogoffSession.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnLogoffSession.Location = new(351, 14);
            this.btnLogoffSession.Name = "btnLogoffSession";
            this.btnLogoffSession.Size = new(75, 36);
            this.btnLogoffSession.TabIndex = 0;
            this.btnLogoffSession.TabStop = false;
            this.btnLogoffSession.Text = "LogOff";
            this.btnLogoffSession.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogoffSession.UseVisualStyleBackColor = true;
            this.btnLogoffSession.Click += new(this.LogoffSession);
            // 
            // btnConnectSession
            // 
            this.btnConnectSession.Image = global::Forms.Resources.Resources.handshake;
            this.btnConnectSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnectSession.Location = new(249, 14);
            this.btnConnectSession.Name = "btnConnectSession";
            this.btnConnectSession.Size = new(96, 36);
            this.btnConnectSession.TabIndex = 1;
            this.btnConnectSession.TabStop = false;
            this.btnConnectSession.Text = "Połącz";
            this.btnConnectSession.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConnectSession.UseVisualStyleBackColor = true;
            this.btnConnectSession.Click += new(this.ConnectToSession);
            // 
            // comboBoxFindedSessions
            // 
            this.comboBoxFindedSessions.FormattingEnabled = true;
            this.comboBoxFindedSessions.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxFindedSessions.Location = new(122, 19);
            this.comboBoxFindedSessions.Name = "comboBoxFindedSessions";
            this.comboBoxFindedSessions.Size = new(121, 21);
            this.comboBoxFindedSessions.MaxDropDownItems = 100;
            this.comboBoxFindedSessions.TabIndex = 3;
            this.comboBoxFindedSessions.PreviewKeyDown += new(this.Keys_PreviewKeyDown);
            // 
            // btnFindSessions
            // 
            this.BtnFindSession.Image = global::Forms.Resources.Resources.session;
            this.BtnFindSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFindSession.Location = new(6, 14);
            this.BtnFindSession.Name = "btnFindSessions";
            this.BtnFindSession.Size = new(101, 36);
            this.BtnFindSession.TabIndex = 3;
            this.BtnFindSession.TabStop = false;
            this.BtnFindSession.Text = "Szukaj sesji";
            this.BtnFindSession.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFindSession.UseVisualStyleBackColor = true;
            this.BtnFindSession.Click += new(this.FindSessionBtn_Click);
            // 
            // btnProfilERI
            // 
            this.btnProfilERI.Image = global::Forms.Resources.Resources.folder;
            this.btnProfilERI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfilERI.Location = new(316, 41);
            this.btnProfilERI.Name = "btnProfilERI";
            this.btnProfilERI.Size = new(77, 30);
            this.btnProfilERI.TabIndex = 3;
            this.btnProfilERI.TabStop = false;
            this.btnProfilERI.Text = "Profil ERI";
            this.btnProfilERI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfilERI.UseVisualStyleBackColor = true;
            this.btnProfilERI.Click += new(this.Profilsieciowy);
            // 
            // btnProfilVFS
            // 
            this.btnProfilVFS.Image = global::Forms.Resources.Resources.folder;
            this.btnProfilVFS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfilVFS.Location = new(316, 11);
            this.btnProfilVFS.Name = "btnProfilVFS";
            this.btnProfilVFS.Size = new(77, 30);
            this.btnProfilVFS.TabIndex = 4;
            this.btnProfilVFS.TabStop = false;
            this.btnProfilVFS.Text = "Profil VFS";
            this.btnProfilVFS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfilVFS.UseVisualStyleBackColor = true;
            this.btnProfilVFS.Click += new(this.Profilsieciowy);
            // 
            // btnInfoZAd
            // 
            this.btnInfoZAd.Image = global::Forms.Resources.Resources.infozad;
            this.btnInfoZAd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfoZAd.Location = new(209, 41);
            this.btnInfoZAd.Name = "btnInfoZAd";
            this.btnInfoZAd.Size = new(107, 30);
            this.btnInfoZAd.TabIndex = 5;
            this.btnInfoZAd.TabStop = false;
            this.btnInfoZAd.Text = "Info z AD";
            this.btnInfoZAd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInfoZAd.UseVisualStyleBackColor = true;
            this.btnInfoZAd.Click += new(this.Info_z_AD_Click);
            // 
            // btnUserLog
            // 
            this.btnUserLog.Image = global::Forms.Resources.Resources.userlog;
            this.btnUserLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserLog.Location = new(209, 11);
            this.btnUserLog.Name = "btnUserLog";
            this.btnUserLog.Size = new(107, 30);
            this.btnUserLog.TabIndex = 6;
            this.btnUserLog.TabStop = false;
            this.btnUserLog.Text = "User log";
            this.btnUserLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserLog.UseVisualStyleBackColor = true;
            this.btnUserLog.Click += new(this.BtnUserLogs);
            // 
            // numericLogin
            // 
            this.numericLogin.ContextMenuStrip = this.contextMenuOperationTextBox;
            this.numericLogin.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericLogin.Location = new(143, 40);
            this.numericLogin.KeyDown += new(this.Keys_KeyDown);
            this.numericLogin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLogin.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericLogin.Name = "numericLogin";
            this.numericLogin.Size = new(60, 20);
            this.numericLogin.TabIndex = 2;
            this.numericLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericLogin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelCountCompLogs
            // 
            this.labelCountUserLogs.AutoSize = true;
            this.labelCountUserLogs.Font = new("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCountUserLogs.Location = new(137, 16);
            this.labelCountUserLogs.Name = "labelCountCompLogs";
            this.labelCountUserLogs.Size = new(71, 15);
            this.labelCountUserLogs.TabIndex = 7;
            this.labelCountUserLogs.Text = "Ilość logów:";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin.Location = new(3, 16);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.TabIndex = 8;
            this.labelLogin.Text = "Login:";
            // 
            // contextMenuOperationRichTextBox
            // 
            this.contextMenuOperationRichTextBox.Items.AddRange(new[] {
            this.contextMenuItemCutR,
            this.contextMenuItemCopyR,
            this.contextMenuItemPasteR,
            this.contextMenuItemSelectAllR,
            this.contextMenuItemSearchR});
            this.contextMenuOperationRichTextBox.Name = "contextMenuOperationRichTextBox";
            this.contextMenuOperationRichTextBox.ShowImageMargin = false;
            // 
            // contextMenuItemCutR
            // 
            this.contextMenuItemCutR.Name = "contextMenuItemCutR";
            this.contextMenuItemCutR.ShortcutKeyDisplayString = "Ctrl + X";
            this.contextMenuItemCutR.Text = "Wytnij";
            this.contextMenuItemCutR.Click += new(this.ContextMenuItemCut_Click);
            // 
            // contextMenuItemCopyR
            // 
            this.contextMenuItemCopyR.Name = "contextMenuItemCopyR";
            this.contextMenuItemCopyR.ShortcutKeyDisplayString = "Ctrl + C";
            this.contextMenuItemCopyR.Text = "Kopiuj";
            this.contextMenuItemCopyR.Click += new(this.ContextMenuItemCopy_Click);
            // 
            // contextMenuItemPasteR
            // 
            this.contextMenuItemPasteR.Name = "contextMenuItemPasteR";
            this.contextMenuItemPasteR.ShortcutKeyDisplayString = "Ctrl + V";
            this.contextMenuItemPasteR.Text = "Wklej";
            this.contextMenuItemPasteR.Click += new(this.ContextMenuItemPaste_Click);
            // 
            // contextMenuItemSelectAllR
            // 
            this.contextMenuItemSelectAllR.Name = "contextMenuItemSelectAllR";
            this.contextMenuItemSelectAllR.ShortcutKeyDisplayString = "Ctrl + A";
            this.contextMenuItemSelectAllR.Text = "Zaznacz wszystko";
            this.contextMenuItemSelectAllR.Click += new(this.ContextMenuItemSelectAll_Click);
            // 
            // contextMenuItemSearchR
            // 
            this.contextMenuItemSearchR.Name = "contextMenuItemSearchR";
            this.contextMenuItemSearchR.ShortcutKeyDisplayString = "Ctrl + F";
            this.contextMenuItemSearchR.Text = "Wyszukaj";
            this.contextMenuItemSearchR.Click += new(this.ContextMenuItemSearch_Click);
            // 
            // groupBoxComputerInfo
            // 
            this.groupBoxComputerInfo.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxComputerInfo.Controls.Add(this.comboBoxComputer);
            this.groupBoxComputerInfo.Controls.Add(this.btnRemoteTracert);
            this.groupBoxComputerInfo.Controls.Add(this.btnRemotePing);
            this.groupBoxComputerInfo.Controls.Add(this.btnRemoteCMD);
            this.groupBoxComputerInfo.Controls.Add(this.btnNetworkInterfaces);
            this.groupBoxComputerInfo.Controls.Add(this.btnProgramList);
            this.groupBoxComputerInfo.Controls.Add(this.btnExplorer);
            this.groupBoxComputerInfo.Controls.Add(this.btnRDP);
            this.groupBoxComputerInfo.Controls.Add(this.btnDW);
            this.groupBoxComputerInfo.Controls.Add(this.btnManagement);
            this.groupBoxComputerInfo.Controls.Add(this.btnCompInfo);
            this.groupBoxComputerInfo.Controls.Add(this.btnPing);
            this.groupBoxComputerInfo.Controls.Add(this.numericComputer);
            this.groupBoxComputerInfo.Controls.Add(this.labelCountCompLogs);
            this.groupBoxComputerInfo.Controls.Add(this.labelComputer);
            this.groupBoxComputerInfo.Controls.Add(this.btnCompLog);
            this.groupBoxComputerInfo.Location = new(1, 101);
            this.groupBoxComputerInfo.MinimumSize = new(1182, 61);
            this.groupBoxComputerInfo.Name = "groupBoxComputerInfo";
            this.groupBoxComputerInfo.Size = new(1182, 75);
            this.groupBoxComputerInfo.TabIndex = 2;
            this.groupBoxComputerInfo.TabStop = false;
            this.groupBoxComputerInfo.Text = "Informacje o komputerze:";
            // 
            // comboBoxComputer
            // 
            this.comboBoxComputer.ContextMenuStrip = this.contextMenuOperationTextBox;
            this.comboBoxComputer.FormattingEnabled = true;
            this.comboBoxComputer.Location = new(6, 43);
            this.comboBoxComputer.Name = "comboBoxComputer";
            this.comboBoxComputer.Size = comboBoxLogin.Size;
            this.comboBoxComputer.TabIndex = 1;
            this.comboBoxComputer.KeyDown += new(this.Keys_KeyDown);
            this.comboBoxComputer.PreviewKeyDown += new(this.Keys_PreviewKeyDown);
            // 
            // btnRemoteTracert
            // 
            this.btnRemoteTracert.Location = new(736, 40);
            this.btnRemoteTracert.Name = "btnRemoteTracert";
            this.btnRemoteTracert.Size = new(107, 30);
            this.btnRemoteTracert.TabIndex = 0;
            this.btnRemoteTracert.TabStop = false;
            this.btnRemoteTracert.Text = "Remote TRACERT";
            this.btnRemoteTracert.UseVisualStyleBackColor = true;
            this.btnRemoteTracert.Click += new(this.RemotePingTracert);
            // 
            // btnRemotePing
            // 
            this.btnRemotePing.Location = new(736, 10);
            this.btnRemotePing.Name = "btnRemotePing";
            this.btnRemotePing.Size = new(107, 30);
            this.btnRemotePing.TabIndex = 1;
            this.btnRemotePing.TabStop = false;
            this.btnRemotePing.Text = "Remote PING";
            this.btnRemotePing.UseVisualStyleBackColor = true;
            this.btnRemotePing.Click += new(this.RemotePingTracert);
            // 
            // btnRemoteCMD
            // 
            this.btnRemoteCMD.ContextMenuStrip = this.contextMenuRemoteCMD;
            this.btnRemoteCMD.Image = global::Forms.Resources.Resources.zdalneCMD;
            this.btnRemoteCMD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoteCMD.Location = new(633, 10);
            this.btnRemoteCMD.Name = "btnRemoteCMD";
            this.btnRemoteCMD.Size = new(103, 30);
            this.btnRemoteCMD.TabIndex = 2;
            this.btnRemoteCMD.TabStop = false;
            this.btnRemoteCMD.Text = "Zdalne CMD";
            this.btnRemoteCMD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoteCMD.UseVisualStyleBackColor = true;
            this.btnRemoteCMD.Click += new(this.RemoteCMD_Click);
            // 
            // contextMenuRemoteCMD
            // 
            this.contextMenuRemoteCMD.Items.AddRange(new[] {
            this.contextMenuItemRemoteCMDSystem,
            this.contextMenuItemCMDRemoteCustomAuth,
            this.contextMenuItemPowerShellRemoteCustomAuth,
            this.contextMenuItemRemotePowerShell,
            this.contextMenuItemCMD,
            this.contextMenuItemPowerShell});
            this.contextMenuRemoteCMD.Name = "contextMenuRemoteCMD";
            // 
            // contextMenuItemRemoteCMDSystem
            // 
            this.contextMenuItemRemoteCMDSystem.Image = global::Forms.Resources.Resources.zdalneCMD;
            this.contextMenuItemRemoteCMDSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.contextMenuItemRemoteCMDSystem.Name = "contextMenuItemRemoteCMDSystem";
            this.contextMenuItemRemoteCMDSystem.Text = "Zdalne CMD (SYSTEM)";
            this.contextMenuItemRemoteCMDSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.contextMenuItemRemoteCMDSystem.Click += new(this.MenuItemCMDSYSTEM_Click);
            // 
            // contextMenuItemCMD
            // 
            this.contextMenuItemCMD.Image = global::Forms.Resources.Resources.cmd;
            this.contextMenuItemCMD.Name = "contextMenuItemCMD";
            this.contextMenuItemCMD.Text = "CMD";
            this.contextMenuItemCMD.Click += new(this.MenuItemCMD_Click);
            // 
            // contextMenuItemCMDRemoteCustomAth
            // 
            this.contextMenuItemCMDRemoteCustomAuth.Image = global::Forms.Resources.Resources.cmd;
            this.contextMenuItemCMDRemoteCustomAuth.Name = "contextMenuItemCMDRemoteCustomAth";
            this.contextMenuItemCMDRemoteCustomAuth.Text = "Zdalne CMD (Custom Auth)";
            this.contextMenuItemCMDRemoteCustomAuth.Click += new(this.CMDRemoteCustomAuth);
            // 
            // contextMenuItemPowerShell
            // 
            this.contextMenuItemPowerShell.Image = global::Forms.Resources.Resources.powershell;
            this.contextMenuItemPowerShell.Name = "contextMenuItemPowerShell";
            this.contextMenuItemPowerShell.Text = "Powershell";
            this.contextMenuItemPowerShell.Click += new(this.Powershell_Click);
            //
            // contextMenuItemRemotePowerShell
            //
            this.contextMenuItemRemotePowerShell.Name = "contextMenuItemRemotePowerShell";
            this.contextMenuItemRemotePowerShell.Image = global::Forms.Resources.Resources.powershell;
            this.contextMenuItemRemotePowerShell.Text = "Zdalny Powershell";
            this.contextMenuItemRemotePowerShell.Click += new(this.RemotePowerShell_Click);
            //
            // contextMenuItemRemotePowerShell
            //
            this.contextMenuItemPowerShellRemoteCustomAuth.Name = "contextMenuItemPowerShellRemoteCustomAuth";
            this.contextMenuItemPowerShellRemoteCustomAuth.Image = global::Forms.Resources.Resources.powershell;
            this.contextMenuItemPowerShellRemoteCustomAuth.Text = "Zdalny Powershell (Custom Auth)";
            this.contextMenuItemPowerShellRemoteCustomAuth.Click += new(this.RemotePowerShellCustomAuth_Click);
            // 
            // btnNetworkInterfaces
            // 
            this.btnNetworkInterfaces.Image = global::Forms.Resources.Resources.netcard;
            this.btnNetworkInterfaces.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNetworkInterfaces.Location = new(633, 40);
            this.btnNetworkInterfaces.Name = "btnNetworkInterfaces";
            this.btnNetworkInterfaces.Size = new(103, 30);
            this.btnNetworkInterfaces.TabIndex = 3;
            this.btnNetworkInterfaces.TabStop = false;
            this.btnNetworkInterfaces.Text = "Karty sieciowe";
            this.btnNetworkInterfaces.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNetworkInterfaces.UseVisualStyleBackColor = true;
            this.btnNetworkInterfaces.Click += new(this.KomputerInfoMenuStrip);
            // 
            // btnProgramList
            // 
            this.btnProgramList.Image = global::Forms.Resources.Resources.programlist;
            this.btnProgramList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgramList.Location = new(520, 40);
            this.btnProgramList.Name = "btnProgramList";
            this.btnProgramList.Size = new(113, 30);
            this.btnProgramList.TabIndex = 4;
            this.btnProgramList.TabStop = false;
            this.btnProgramList.Text = "Lista programów";
            this.btnProgramList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProgramList.UseVisualStyleBackColor = true;
            this.btnProgramList.Click += new(this.KomputerInfoMenuStrip);
            // 
            // btnExplorer
            // 
            this.btnExplorer.Image = global::Forms.Resources.Resources.folder;
            this.btnExplorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExplorer.Location = new(520, 10);
            this.btnExplorer.Name = "btnExplorer";
            this.btnExplorer.Size = new(113, 30);
            this.btnExplorer.TabIndex = 5;
            this.btnExplorer.TabStop = false;
            this.btnExplorer.Text = "Explorer C$";
            this.btnExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExplorer.UseVisualStyleBackColor = true;
            this.btnExplorer.Click += new(this.BtnExplorer_Click);
            // 
            // btnRDP
            // 
            this.btnRDP.ContextMenuStrip = this.contextMenuRDP;
            this.btnRDP.Image = global::Forms.Resources.Resources.rdp;
            this.btnRDP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRDP.Location = new(423, 40);
            this.btnRDP.Name = "btnRDP";
            this.btnRDP.Size = new(97, 30);
            this.btnRDP.TabIndex = 6;
            this.btnRDP.TabStop = false;
            this.btnRDP.Text = "Pulpit zdalny";
            this.btnRDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRDP.UseVisualStyleBackColor = true;
            this.btnRDP.Click += new(this.BtnRDP_Click);
            // 
            // contextMenuRDP
            // 
            this.contextMenuRDP.Items.AddRange(new[] {
            this.menuItemRDPOpen});
            this.contextMenuRDP.Name = "contextMenuRDP";
            this.contextMenuRDP.Text = "ZdalnyPulpit";
            this.contextMenuRDP.ShowImageMargin = false;
            // 
            // menuItemRDPOpen
            // 
            this.menuItemRDPOpen.Name = "rDPBezPustyContextMenu";
            this.menuItemRDPOpen.Text = "RDP pusty";
            this.menuItemRDPOpen.Click += new(this.MenuItemRDPOpen_Click);
            // 
            // btnDW
            // 
            this.btnDW.ContextMenuStrip = this.DWMenuContext;
            this.btnDW.Image = global::Forms.Resources.Resources.DW;
            this.btnDW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDW.Location = new(423, 10);
            this.btnDW.Name = "btnDW";
            this.btnDW.Size = new(97, 30);
            this.btnDW.TabIndex = 7;
            this.btnDW.TabStop = false;
            this.btnDW.Text = "default";
            this.btnDW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDW.UseVisualStyleBackColor = true;
            this.btnDW.Click += new(this.BtnDW_Click);
            // 
            // DWMenuContext
            // 
            this.DWMenuContext.Items.AddRange(new[] {
            this.menuItemDWEadm,
            this.menuItemDWLAPS});
            this.DWMenuContext.Name = "DWMenuContext";
            this.DWMenuContext.Text = "default";
            this.DWMenuContext.ShowImageMargin = false;
            // 
            // menuItemDWEadm
            // 
            this.menuItemDWEadm.Name = "menuItemDWEadm";
            this.menuItemDWEadm.Text = "default";
            this.menuItemDWEadm.Click += new(this.BtnDW_Click);
            // 
            // menuItemDWLAPS
            // 
            this.menuItemDWLAPS.Name = "menuItemDWLAPS";
            this.menuItemDWLAPS.Text = "default";
            this.menuItemDWLAPS.Click += new(this.BtnDW_Click);
            // 
            // btnManagement
            // 
            this.btnManagement.Image = global::Forms.Resources.Resources.compmgmt;
            this.btnManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.Location = new(316, 40);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new(107, 30);
            this.btnManagement.TabIndex = 8;
            this.btnManagement.TabStop = false;
            this.btnManagement.Text = "Zarządzanie";
            this.btnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Click += new(this.AdmTools);
            // 
            // btnCompInfo
            // 
            this.btnCompInfo.ContextMenuStrip = this.contextMenuComputerInfo;
            this.btnCompInfo.Image = global::Forms.Resources.Resources.komputerinfo;
            this.btnCompInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompInfo.Location = new(316, 10);
            this.btnCompInfo.Name = "btnCompInfo";
            this.btnCompInfo.Size = new(107, 30);
            this.btnCompInfo.TabIndex = 9;
            this.btnCompInfo.TabStop = false;
            this.btnCompInfo.Text = "Komputer info";
            this.btnCompInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompInfo.UseVisualStyleBackColor = true;
            this.btnCompInfo.Click += new(this.KomputerInfoMenuStrip);
            // 
            // contextMenuComputerInfo
            // 
            this.contextMenuComputerInfo.Items.AddRange(new[] {
            this.menuItemComputerInfoAutostart,
            this.menuItemComputerInfoBios,
            this.menuItemComputerInfoProcessor,
            this.menuItemComputerInfoPrinters,
            this.menuItemComputerInfoDrives,
            this.menuItemComputerInfoDisplay,
            this.menuItemComputerInfoModel,
            this.menuItemComputerInfoRAM,
            this.menuItemComputerInfoPath,
            this.menuItemComputerInfoOS,
            this.menuItemComputerInfoProfile,
            this.menuItemComputerInfoSNPN,
            this.menuItemComputerInfoDrivers,
            this.menuItemComputerInfoShares,
            this.menuItemComputerInfoUptime,
            this.menuItemComputerInfoLoggedUser,
            this.menuItemComputerInfoNetworkRes});
            this.contextMenuComputerInfo.Name = "contextMenuComputerInfo";
            this.contextMenuComputerInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuComputerInfo.ShowImageMargin = false;
            // 
            // menuItemComputerInfoUptime
            // 
            this.menuItemComputerInfoUptime.Name = "menuItemComputerInfoUptime";
            this.menuItemComputerInfoUptime.Text = "Uptime";
            this.menuItemComputerInfoUptime.Click += new(this.KomputerInfoMenuStrip);
            //
            // menuItemComputerInfoDrivers 
            //
            this.menuItemComputerInfoDrivers.Name = "menuItemComputerInfoDrivers";
            this.menuItemComputerInfoDrivers.Text = "Sterowniki";
            this.menuItemComputerInfoDrivers.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoSNPN
            // 
            this.menuItemComputerInfoSNPN.Name = "menuItemComputerInfoSNPN";
            this.menuItemComputerInfoSNPN.Text = "Nr Seryjny i Nr Partii";
            this.menuItemComputerInfoSNPN.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoModel
            // 
            this.menuItemComputerInfoModel.Name = "menuItemComputerInfoModel";
            this.menuItemComputerInfoModel.Text = "Model";
            this.menuItemComputerInfoModel.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoOS
            // 
            this.menuItemComputerInfoOS.Name = "menuItemComputerInfoOS";
            this.menuItemComputerInfoOS.Text = "OS";
            this.menuItemComputerInfoOS.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoRAM
            // 
            this.menuItemComputerInfoRAM.Name = "menuItemComputerInfoRAM";
            this.menuItemComputerInfoRAM.Text = "Pamięć RAM";
            this.menuItemComputerInfoRAM.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoProcessor
            // 
            this.menuItemComputerInfoProcessor.Name = "menuItemComputerInfoProcessor";
            this.menuItemComputerInfoProcessor.Text = "CPU";
            this.menuItemComputerInfoProcessor.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoLoggedUser
            // 
            this.menuItemComputerInfoLoggedUser.Name = "menuItemComputerInfoLoggedUser";
            this.menuItemComputerInfoLoggedUser.Text = "Zalogowany";
            this.menuItemComputerInfoLoggedUser.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoProfile
            // 
            this.menuItemComputerInfoProfile.Name = "menuItemComputerInfoProfile";
            this.menuItemComputerInfoProfile.Text = "Profile Użytkowników";
            this.menuItemComputerInfoProfile.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoDrives
            // 
            this.menuItemComputerInfoDrives.Name = "menuItemComputerInfoDrives";
            this.menuItemComputerInfoDrives.Text = "Dyski";
            this.menuItemComputerInfoDrives.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoPrinters
            // 
            this.menuItemComputerInfoPrinters.Name = "menuItemComputerInfoPrinters";
            this.menuItemComputerInfoPrinters.Text = "Drukarki sieciowe";
            this.menuItemComputerInfoPrinters.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoShares
            // 
            this.menuItemComputerInfoShares.Name = "menuItemComputerInfoShares";
            this.menuItemComputerInfoShares.Text = "Udziały";
            this.menuItemComputerInfoShares.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoAutostart
            // 
            this.menuItemComputerInfoAutostart.Name = "menuItemComputerInfoAutostart";
            this.menuItemComputerInfoAutostart.Text = "Autostart";
            this.menuItemComputerInfoAutostart.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoPath
            // 
            this.menuItemComputerInfoPath.Name = "menuItemComputerInfoPath";
            this.menuItemComputerInfoPath.Text = "PATH";
            this.menuItemComputerInfoPath.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoNetworkRes
            // 
            this.menuItemComputerInfoNetworkRes.Name = "menuItemComputerInfoNetworkRes";
            this.menuItemComputerInfoNetworkRes.Text = "Zasoby sieciowe";
            this.menuItemComputerInfoNetworkRes.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoDisplay
            // 
            this.menuItemComputerInfoDisplay.Name = "menuItemComputerInfoDisplay";
            this.menuItemComputerInfoDisplay.Text = "Ekrany podłączone";
            this.menuItemComputerInfoDisplay.Click += new(this.KomputerInfoMenuStrip);
            // 
            // menuItemComputerInfoBios
            // 
            this.menuItemComputerInfoBios.Name = "menuItemComputerInfoBios";
            this.menuItemComputerInfoBios.Text = "BIOS";
            this.menuItemComputerInfoBios.Click += new(this.KomputerInfoMenuStrip);
            // 
            // btnPing
            // 
            this.btnPing.Image = global::Forms.Resources.Resources.ping;
            this.btnPing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPing.Location = new(209, 40);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new(107, 30);
            this.btnPing.TabIndex = 10;
            this.btnPing.TabStop = false;
            this.btnPing.Text = "Ping";
            this.btnPing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new(this.BtnPing_Click);
            // 
            // numericComputer
            // 
            this.numericComputer.ContextMenuStrip = this.contextMenuOperationTextBox;
            this.numericComputer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numericComputer.Location = new(143, 43);
            this.numericComputer.KeyDown += new(this.Keys_KeyDown);
            this.numericComputer.Minimum = new(new int[] {
            1,
            0,
            0,
            0});
            this.numericComputer.Maximum = new(new int[] {
            1000,
            0,
            0,
            0});
            this.numericComputer.Name = "numericComputer";
            this.numericComputer.Size = numericLogin.Size;
            this.numericComputer.TabIndex = 2;
            this.numericComputer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericComputer.Value = new(new int[] {
            5,
            0,
            0,
            0});
            // 
            // labelCountCompLogs
            // 
            this.labelCountCompLogs.AutoSize = true;
            this.labelCountCompLogs.Font = new("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCountCompLogs.Location = new(137, 19);
            this.labelCountCompLogs.Name = "labelCountCompLogs";
            this.labelCountCompLogs.TabIndex = 11;
            this.labelCountCompLogs.Text = "Ilośc logów:";
            // 
            // labelComputer
            // 
            this.labelComputer.AutoSize = true;
            this.labelComputer.Font = new("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelComputer.Location = new(3, 19);
            this.labelComputer.Name = "labelComputer";
            this.labelComputer.TabIndex = 12;
            this.labelComputer.Text = "Nazwa komputera:";
            // 
            // btnCompLog
            // 
            this.btnCompLog.Image = global::Forms.Resources.Resources.Complog;
            this.btnCompLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompLog.Location = new(209, 10);
            this.btnCompLog.Name = "btnCompLog";
            this.btnCompLog.Size = btnUserLog.Size;
            this.btnCompLog.TabIndex = 13;
            this.btnCompLog.TabStop = false;
            this.btnCompLog.Text = "Komputer log";
            this.btnCompLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompLog.UseVisualStyleBackColor = true;
            this.btnCompLog.Click += new(this.BtnComputerLogs);
            // 
            // groupBoxOtherTools
            // 
            this.groupBoxOtherTools.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxOtherTools.Controls.Add(this.panelTCP);
            this.groupBoxOtherTools.Controls.Add(this.btnReloadLogs);
            this.groupBoxOtherTools.Controls.Add(this.btnFlushDNS);
            this.groupBoxOtherTools.Location = new(1, 180);
            this.groupBoxOtherTools.MinimumSize = new(1182, 45);
            this.groupBoxOtherTools.Name = "groupBoxOtherTools";
            this.groupBoxOtherTools.Size = new(1182, 54);
            this.groupBoxOtherTools.TabIndex = 3;
            this.groupBoxOtherTools.TabStop = false;
            this.groupBoxOtherTools.Text = "Inne narzędzia";
            // 
            // btnReloadLogs
            // 
            this.btnReloadLogs.Image = global::Forms.Resources.Resources.reload;
            this.btnReloadLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReloadLogs.Location = new System.Drawing.Point(97, 15);
            this.btnReloadLogs.Name = "btnReloadLogs";
            this.btnReloadLogs.Size = new System.Drawing.Size(97, 36);
            this.btnReloadLogs.TabIndex = 0;
            this.btnReloadLogs.TabStop = false;
            this.btnReloadLogs.Text = "Reload Logs";
            this.btnReloadLogs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReloadLogs.UseVisualStyleBackColor = true;
            this.btnReloadLogs.Click += new(this.ReloadLogs);
            this.btnReloadLogs.MouseMove += new(this.MouseMovingOverbtnReloadLogs);
            // 
            // panelTCP
            // 
            this.panelTCP.Controls.Add(this.numericTCP);
            this.panelTCP.Controls.Add(this.labelTCP);
            this.panelTCP.Controls.Add(this.btnTestTCP);
            this.panelTCP.Controls.Add(this.btnCollapseTCP);
            this.panelTCP.Location = new(196, 16);
            this.panelTCP.Name = "panelTCP";
            this.panelTCP.Size = new(63, 32);
            this.panelTCP.TabIndex = 2;
            // 
            // numericTCP
            // 
            this.numericTCP.Location = new(180, 8);
            this.numericTCP.Maximum = new(new int[] {
            65535,
            0,
            0,
            0});
            this.numericTCP.Name = "numericTCP";
            this.numericTCP.Size = new(61, 20);
            this.numericTCP.TabIndex = 3;
            this.numericTCP.Value = new(new int[] {
            135,
            0,
            0,
            0});
            // 
            // labelTCP
            // 
            this.labelTCP.AutoSize = true;
            this.labelTCP.Location = new(61, 11);
            this.labelTCP.Name = "labelTCP";
            this.labelTCP.Size = new(117, 13);
            this.labelTCP.TabIndex = 2;
            this.labelTCP.Text = "Podaj Port dla badania:";
            // 
            // btnTestTCP
            // 
            this.btnTestTCP.Location = new(245, 2);
            this.btnTestTCP.Name = "btnTestTCP";
            this.btnTestTCP.Size = new(104, 28);
            this.btnTestTCP.TabIndex = 1;
            this.btnTestTCP.Text = "Wykonaj badanie";
            this.btnTestTCP.UseVisualStyleBackColor = true;
            this.btnTestTCP.Click += new(this.BtnTestTCP_Click);
            // 
            // btnCollapseTCP
            // 
            this.btnCollapseTCP.Location = new(2, 2);
            this.btnCollapseTCP.Name = "btnCollapseTCP";
            this.btnCollapseTCP.Size = new(59, 28);
            this.btnCollapseTCP.TabIndex = 0;
            this.btnCollapseTCP.Text = "TCPPing";
            this.btnCollapseTCP.UseVisualStyleBackColor = true;
            this.btnCollapseTCP.Click += new(this.BtnCollapseTCP);
            // 
            // btnFlushDNS
            // 
            this.btnFlushDNS.Image = global::Forms.Resources.Resources.rubish;
            this.btnFlushDNS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlushDNS.Location = new(6, 15);
            this.btnFlushDNS.Name = "btnFlushDNS";
            this.btnFlushDNS.Size = new(89, 36);
            this.btnFlushDNS.TabIndex = 1;
            this.btnFlushDNS.TabStop = false;
            this.btnFlushDNS.Text = "Flush DNS";
            this.btnFlushDNS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFlushDNS.UseVisualStyleBackColor = true;
            this.btnFlushDNS.Click += new(this.BtnFlushDNS_Click);
            // 
            // richTextBox1
            // 
            richTextBox1.AutoWordSelection = true;
            richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            richTextBox1.ContextMenuStrip = this.contextMenuOperationRichTextBox;
            richTextBox1.DetectUrls = false;
            richTextBox1.Font = new("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            richTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            richTextBox1.Location = new(2, 240);
            richTextBox1.MinimumSize = new(1181, 294);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ShortcutsEnabled = false;
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.KeyDown += new(this.Keys_KeyDown);
            richTextBox1.PreviewKeyDown += new(this.Keys_PreviewKeyDown);
            // 
            // backgroundWorkerComputerInfo
            // 
            this.backgroundWorkerComputerInfo.DoWork += new(this.KomputerInfo_DoWork);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new(0, 535);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Items.AddRange(new[] {
            this.statusBP1,
            this.statusBP2});
            this.statusBar1.TabIndex = 5;
            this.statusBar1.Text = "statusbar";
            // 
            // statusBP1
            // 
            this.statusBP1.Name = "statusBP1";
            this.statusBP1.Text = "Gotowe";
            // 
            // statusBP2
            // 
            this.statusBP2.Name = "statusBP2";
            this.statusBP2.Text = "Czas";
            // 
            // InfozAD
            // 
            this.InfozAD.DoWork += new(this.InfozAD_DoWork);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.mainMenu.Items.AddRange(new[] {
            this.menuItemFile,
            this.menuItemAbout,
            this.menuItemSettings,
            this.menuItemAdmTools,
            this.menuItemQuickFix,});
            this.mainMenu.Location = new(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // menuItemFile
            // 
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Text = "Plik";
            this.menuItemFile.Visible = false;
            //
            // menuItemAbout
            //
            this.menuItemAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Text = "?";
            this.menuItemAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUpdate,
            });
            //
            // menuItemUpdate
            //
            this.menuItemUpdate.Name = "menuItemUpdate";
            this.menuItemUpdate.Text = "Sprawdź dostępność aktualizacji";
            this.menuItemUpdate.Image = global::Forms.Resources.Resources.PuzzelUpdate.ToBitmap();
            this.menuItemUpdate.Click += new(this.CheckUpdate);

            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuItemSettings.Name = "ustawienia";
            this.menuItemSettings.Size = new(76, 20);
            this.menuItemSettings.Text = "Ustawienia";
            this.menuItemSettings.Visible = true;
            this.menuItemSettings.Click += new(this.OpenSettings);
            // 
            // narzędziaAdministracyjneToolStripMenuItem
            // 
            this.menuItemAdmTools.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuItemAdmTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDHCP,
            this.menuItemEventViewer,
            this.menuItemTaskshedule,
            this.menuItemServices,
            this.menuItemLusrmgr,
            this.menuItemWindowsFirewall,
            new System.Windows.Forms.ToolStripSeparator(),
            this.ComputerCustomData,
            this.TerminalCustomData,
            this.LogonsOnDomainHub,
            this.LogonsOnComputer,
            this.MotpLogons,
            new System.Windows.Forms.ToolStripSeparator(),
            this.menuItemTermimalExplorer,
            this.menuItemComputerExplorer,
            new System.Windows.Forms.ToolStripSeparator(),
            this.menuItemLAPSpwd,
            this.menuItemLockoutStatus,
            this.menuItemChangeDomainPassword});
            this.menuItemAdmTools.Name = "menuItemAdmTools";
            this.menuItemAdmTools.Text = "Narzędzia administracyjne";
            //
            // menuItemWindowsFirewall
            //
            this.menuItemWindowsFirewall.Image = global::Forms.Resources.Resources.firewall;
            this.menuItemWindowsFirewall.Name = "menuItemWindowsFirewall";
            this.menuItemWindowsFirewall.Text = "Zaawansowana Zapora Windows";
            this.menuItemWindowsFirewall.Click += new(this.AdmTools);
            //
            // TerminalCustomData
            //
            this.TerminalCustomData.Name = "TerminalCustomData";
            this.TerminalCustomData.Text = "Niestandardowe logi dla terminali";
            this.TerminalCustomData.Click += new(this.BtnCustomFinderLogs);
            //
            // ComputerCustomData
            //
            this.ComputerCustomData.Name = "ComputerCustomData";
            this.ComputerCustomData.Text = "Niestandardowe logi dla komputerów";
            this.ComputerCustomData.Click += new(this.BtnCustomFinderLogs);
            //
            // MotpLogons
            //
            this.MotpLogons.Image = global::Forms.Resources.Resources.motp;
            this.MotpLogons.Name = "MotpLogons";
            this.MotpLogons.Text = "Wyszukiwanie prób logowania (motp)";
            this.MotpLogons.Click += new(this.BtnBadPwdFinderLogs);
            //
            // LogonsOnDomainHub
            //
            this.LogonsOnDomainHub.Image = global::Forms.Resources.Resources.userlog;
            this.LogonsOnDomainHub.Name = "LogonsOnDomainHub";
            this.LogonsOnDomainHub.Text = "Wyszukiwanie prób logowania (domena)";
            this.LogonsOnDomainHub.Click += new(this.BtnBadPwdFinderLogs);
            //
            // LogonsOnComputer
            //
            this.LogonsOnComputer.Image = global::Forms.Resources.Resources.Complog;
            this.LogonsOnComputer.Name = "LogonsOnComputer";
            this.LogonsOnComputer.Text = "Wyszukiwanie prób logowania (komputer)";
            this.LogonsOnComputer.Click += new(this.BtnBadPwdFinderLogs);
            //
            // menuItemDHCP
            // 
            this.menuItemDHCP.Image = global::Forms.Resources.Resources.dhcp;
            this.menuItemDHCP.Name = "menuItemDHCP";
            this.menuItemDHCP.Text = "DHCP";
            this.menuItemDHCP.Click += new(this.DHCPToolStripMenuItem_Click);
            // 
            // menuItemEventViewer
            // 
            this.menuItemEventViewer.Image = global::Forms.Resources.Resources.eventvwr;
            this.menuItemEventViewer.Name = "menuItemEventViewer";
            this.menuItemEventViewer.Text = "Dziennik zdarzeń";
            this.menuItemEventViewer.Click += new(this.AdmTools);
            // 
            // menuItemTaskshedule
            // 
            this.menuItemTaskshedule.Image = global::Forms.Resources.Resources.tasksched;
            this.menuItemTaskshedule.Name = "menuItemTaskshedule";
            this.menuItemTaskshedule.Text = "Harmonogram zadań";
            this.menuItemTaskshedule.Click += new(this.AdmTools);
            // 
            // menuItemServices
            // 
            this.menuItemServices.Image = global::Forms.Resources.Resources.services;
            this.menuItemServices.Name = "menuItemServices";
            this.menuItemServices.Text = "Usługi";
            this.menuItemServices.Click += new(this.AdmTools);
            // 
            // menuItemLusrmgr
            // 
            this.menuItemLusrmgr.Image = global::Forms.Resources.Resources.lusrmgr;
            this.menuItemLusrmgr.Name = "menuItemLusrmgr";
            this.menuItemLusrmgr.Text = "Użytkownicy i grupy lokalne";
            this.menuItemLusrmgr.Click += new(this.AdmTools);
            // 
            // menuItemTermimalExplorer
            //
            this.menuItemTermimalExplorer.DropDownItems.Add(this.menuItemCustomName);
            this.menuItemTermimalExplorer.Image = global::Forms.Resources.Resources.terminalexplorer;
            this.menuItemTermimalExplorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemTermimalExplorer.Name = "menuItemTermimalExplorer";
            this.menuItemTermimalExplorer.Text = "Terminal Explorer";
            this.menuItemTermimalExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuItemCustomName
            // 
            this.menuItemCustomName.Name = "menuItemCustomName";
            this.menuItemCustomName.Text = "Ręczna nazwa";
            this.menuItemCustomName.Click += new(FindSessions);
            // 
            // menuItemComputerExplorer
            // 
            this.menuItemComputerExplorer.DropDownItems.AddRange(new[] {
            this.menuItemActiveSessions,
            this.menuItemSessions});
            this.menuItemComputerExplorer.Image = global::Forms.Resources.Resources.ComputerExplorer;
            this.menuItemComputerExplorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuItemComputerExplorer.Name = "menuItemComputerExplorer";
            this.menuItemComputerExplorer.Text = "Komputer Explorer";
            this.menuItemComputerExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuItemActiveSessions
            // 
            this.menuItemActiveSessions.Image = global::Forms.Resources.Resources.deactiveSession;
            this.menuItemActiveSessions.Name = "menuItemActiveSessions";
            this.menuItemActiveSessions.Text = "Aktywne Sesje";
            this.menuItemActiveSessions.Click += new(this.ActiveSession);
            // 
            // menuItemSessions
            // 
            this.menuItemSessions.Image = global::Forms.Resources.Resources.process;
            this.menuItemSessions.Name = "menuItemSessions";
            this.menuItemSessions.Text = "Eksplorator Sesji";
            this.menuItemSessions.Click += new(this.FindSessions);
            // 
            // menuItemLAPSpwd
            // 
            this.menuItemLAPSpwd.Image = global::Forms.Resources.Resources.password;
            this.menuItemLAPSpwd.Name = "menuItemLAPSpwd";
            this.menuItemLAPSpwd.Text = "Hasło z LAPS-a";
            this.menuItemLAPSpwd.Click += new(this.PwdLAPS);
            // 
            // menuItemLockoutStatus
            // 
            this.menuItemLockoutStatus.Image = global::Forms.Resources.Resources.lockout;
            this.menuItemLockoutStatus.Name = "menuItemLockoutStatus";
            this.menuItemLockoutStatus.Text = "Lockout Status";
            this.menuItemLockoutStatus.Click += new(this.MenuItemLockoutStatus_Click);
            // 
            // menuItemChangeDomainPassword
            // 
            this.menuItemChangeDomainPassword.Image = global::Forms.Resources.Resources.changepass;
            this.menuItemChangeDomainPassword.Name = "menuItemChangeDomainPassword";
            this.menuItemChangeDomainPassword.Text = "Zmiana hasła domenowego";
            this.menuItemChangeDomainPassword.Click += new(this.ChangePassword);
            // 
            // menuItemQuickFix
            // 
            this.menuItemQuickFix.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuItemQuickFix.DropDownItems.AddRange(new[] {
            this.menuItemActivateOffice,
            this.menuItemDeleteUsers,
            this.menuItemEnableIEHosting,
            this.menuItemWinEnvironment,
            this.MsLicensingCache});
            this.menuItemQuickFix.Name = "menuItemQuickFix";
            this.menuItemQuickFix.Text = "Szybkie rozwiązanie";
            //
            // menuItemActivateOffice
            // 
            this.menuItemActivateOffice.Name = "menuItemActivateOffice";
            this.menuItemActivateOffice.Text = "Aktywacja Office 2016";
            this.menuItemActivateOffice.Click += new(ActivateOffice);
            // 
            // menuItemEnableIEHosting
            // 
            this.menuItemEnableIEHosting.Name = "menuItemEnableIEHosting";
            this.menuItemEnableIEHosting.Text = "Framework4+ IE compatibility";
            this.menuItemEnableIEHosting.Click += new(this.EnableIEHosting_Click);
            // 
            // menuItemWinEnvironment
            // 
            this.menuItemWinEnvironment.Name = "menuItemWinEnvironment";
            this.menuItemWinEnvironment.Text = "Zmienna środowiskowa";
            this.menuItemWinEnvironment.Click += new(this.WinEnvironment_Click);
            // 
            // menuItemDeleteUsers
            // 
            this.menuItemDeleteUsers.Name = "menuItemDeleteUsers";
            this.menuItemDeleteUsers.Text = "Usuwanie użytkowników";
            this.menuItemDeleteUsers.Click += new(this.DeleteUsers_Click);
            //
            // MsLicensingCache
            //
            this.MsLicensingCache.Name = "MsLicensingCache";
            this.MsLicensingCache.Text = "Usuwanie cache licencji RDP";
            this.MsLicensingCache.Click += new(this.DeleteRDPLicensingCache);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(1184, 557);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(richTextBox1);
            this.Controls.Add(this.groupBoxOtherTools);
            this.Controls.Add(this.groupBoxComputerInfo);
            this.Controls.Add(this.groupBoxUserInfo);
            this.Controls.Add(this.mainMenu);
            this.DoubleBuffered = true;
            this.Font = new("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new(1200, 509);
            this.Name = "Puzzel";
            this.Text = "Puzzel";
            this.Load += (this.LoadingForm);
            this.groupBoxUserInfo.ResumeLayout(false);
            this.groupBoxUserInfo.PerformLayout();
            this.contextMenuOperationTextBox.ResumeLayout(false);
            this.groupBoxLogoff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericLogin)).EndInit();
            this.contextMenuOperationRichTextBox.ResumeLayout(false);
            this.groupBoxComputerInfo.ResumeLayout(false);
            this.groupBoxComputerInfo.PerformLayout();
            this.contextMenuRemoteCMD.ResumeLayout(false);
            this.contextMenuRDP.ResumeLayout(false);
            this.DWMenuContext.ResumeLayout(false);
            this.contextMenuComputerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericComputer)).EndInit();
            this.groupBoxOtherTools.ResumeLayout(false);
            this.panelTCP.ResumeLayout(false);
            this.panelTCP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTCP)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.statusBar1.ResumeLayout(false);
            this.statusBar1.PerformLayout();
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.GroupBox groupBoxUserInfo;
        private System.Windows.Forms.Button btnReloadLogs;
        private System.Windows.Forms.Button btnProfilEXT;
        private System.Windows.Forms.Button btnProfilTS;
        private System.Windows.Forms.GroupBox groupBoxLogoff;
        private System.Windows.Forms.Button btnLogoffSession;
        private System.Windows.Forms.Button btnConnectSession;
        private System.Windows.Forms.Button BtnFindSession;
        private System.Windows.Forms.Button btnProfilERI;
        private System.Windows.Forms.Button btnProfilVFS;
        private System.Windows.Forms.Button btnInfoZAd;
        private System.Windows.Forms.Button btnUserLog;
        private System.Windows.Forms.Label labelCountUserLogs;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.GroupBox groupBoxComputerInfo;
        private System.Windows.Forms.Button btnNetworkInterfaces;
        private System.Windows.Forms.Button btnProgramList;
        private System.Windows.Forms.Button btnExplorer;
        private System.Windows.Forms.Button btnRDP;
        private System.Windows.Forms.Button btnDW;
        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btnCompInfo;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Label labelCountCompLogs;
        private System.Windows.Forms.Label labelComputer;
        private System.Windows.Forms.Button btnCompLog;
        private System.Windows.Forms.GroupBox groupBoxOtherTools;
        private System.Windows.Forms.Button btnFlushDNS;
        private System.Windows.Forms.ComboBox comboBoxFindedSessions;
        private System.Windows.Forms.NumericUpDown numericLogin;
        private System.Windows.Forms.NumericUpDown numericComputer;
        private System.ComponentModel.BackgroundWorker backgroundWorkerComputerInfo;
        private System.Windows.Forms.StatusStrip statusBar1;
        private System.Windows.Forms.ToolStripStatusLabel statusBP1;
        private System.Windows.Forms.ToolStripStatusLabel statusBP2;
        private System.ComponentModel.BackgroundWorker InfozAD;
        private System.Windows.Forms.Button btnRemoteCMD;
        private System.Windows.Forms.ContextMenuStrip contextMenuOperationRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCutR;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCopyR;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSelectAllR;
        private System.Windows.Forms.Button btnRemoteTracert;
        private System.Windows.Forms.Button btnRemotePing;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuComputerInfo;
        private System.Windows.Forms.ToolStripMenuItem TerminalUniversalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoUptime;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoSNPN;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoModel;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoOS;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoRAM;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoProcessor;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoLoggedUser;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoProfile;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoDrivers;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoDrives;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoPrinters;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoShares;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoAutostart;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoPath;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoNetworkRes;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdmTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindowsFirewall;
        private System.Windows.Forms.ToolStripMenuItem menuItemEventViewer;
        private System.Windows.Forms.ToolStripMenuItem menuItemServices;
        private System.Windows.Forms.ToolStripMenuItem menuItemTaskshedule;
        private System.Windows.Forms.ToolStripMenuItem menuItemLusrmgr;
        private System.Windows.Forms.ToolStripMenuItem menuItemDHCP;
        private System.Windows.Forms.ToolStripMenuItem menuItemLockoutStatus;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemPasteR; 
        private System.Windows.Forms.ToolStripMenuItem TerminalCustomData;
        private System.Windows.Forms.ToolStripMenuItem ComputerCustomData;
        private System.Windows.Forms.ToolStripMenuItem LogonsOnDomainHub;
        private System.Windows.Forms.ToolStripMenuItem LogonsOnComputer;
        private System.Windows.Forms.ToolStripMenuItem MsLicensingCache;
        private System.Windows.Forms.ToolStripMenuItem MotpLogons;
        private System.Windows.Forms.ToolStripMenuItem menuItemTermimalExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuItemCustomName;
        private System.Windows.Forms.ContextMenuStrip contextMenuRemoteCMD;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCMD;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCMDRemoteCustomAuth;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemPowerShell;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemPowerShellRemoteCustomAuth;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRemotePowerShell;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRemoteCMDSystem;
        private System.Windows.Forms.ContextMenuStrip DWMenuContext;
        private System.Windows.Forms.ToolStripMenuItem menuItemDWEadm;
        private System.Windows.Forms.ToolStripMenuItem menuItemDWLAPS;
        private System.Windows.Forms.ContextMenuStrip contextMenuRDP;
        private System.Windows.Forms.ToolStripMenuItem menuItemRDPOpen;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSearchR;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemLAPSpwd;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoDisplay;
        private System.Windows.Forms.ToolStripMenuItem menuItemComputerInfoBios;
        private System.Windows.Forms.ContextMenuStrip contextMenuOperationTextBox;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCut;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeDomainPassword;
        private System.Windows.Forms.ComboBox comboBoxLogin;
        private System.Windows.Forms.ComboBox comboBoxComputer;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuickFix;
        private System.Windows.Forms.ToolStripMenuItem menuItemActivateOffice;
        private System.Windows.Forms.ToolStripMenuItem menuItemEnableIEHosting;
        private System.Windows.Forms.ToolStripMenuItem menuItemWinEnvironment;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteUsers;
        private System.Windows.Forms.ToolStripMenuItem menuItemActiveSessions;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessions;
        private System.Windows.Forms.Panel panelTCP;
        private System.Windows.Forms.NumericUpDown numericTCP;
        private System.Windows.Forms.Label labelTCP;
        private System.Windows.Forms.Button btnTestTCP;
        private System.Windows.Forms.Button btnCollapseTCP;
        public static System.Windows.Forms.RichTextBox richTextBox1;
    }
}
