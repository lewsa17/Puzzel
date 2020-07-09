namespace Forms.External.Explorer
{
    partial class ExplorerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSession = new System.Windows.Forms.TabPage();
            this.labelSessionCount = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnRefreshNow = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ServerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SessionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdleTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogonTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenuSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSessionConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionSendMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionRemoteControl = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionProcesses = new System.Windows.Forms.ToolStripMenuItem();
            this.TabPageProcess = new System.Windows.Forms.TabPage();
            this.LabelProcessCount = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemProcessKill = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabPageSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.ContextMenuSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSession);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(637, 649);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSession
            // 
            this.tabPageSession.Controls.Add(this.labelSessionCount);
            this.tabPageSession.Controls.Add(this.btnCloseForm);
            this.tabPageSession.Controls.Add(this.btnRefreshNow);
            this.tabPageSession.Controls.Add(this.DataGridView);
            this.tabPageSession.Location = new System.Drawing.Point(4, 22);
            this.tabPageSession.Name = "tabPageSession";
            this.tabPageSession.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSession.Size = new System.Drawing.Size(629, 623);
            this.tabPageSession.TabIndex = 0;
            this.tabPageSession.Text = "Sesje";
            this.tabPageSession.UseVisualStyleBackColor = true;
            // 
            // labelSessionCount
            // 
            this.labelSessionCount.AutoSize = true;
            this.labelSessionCount.Location = new System.Drawing.Point(6, 602);
            this.labelSessionCount.Name = "labelSessionCount";
            this.labelSessionCount.Size = new System.Drawing.Size(83, 13);
            this.labelSessionCount.TabIndex = 27;
            this.labelSessionCount.Text = "Aktywne Sesje: ";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(552, 597);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(76, 23);
            this.btnCloseForm.TabIndex = 26;
            this.btnCloseForm.Text = "Zamknij";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.CloseForm);
            // 
            // btnRefreshNow
            // 
            this.btnRefreshNow.Location = new System.Drawing.Point(382, 597);
            this.btnRefreshNow.Name = "btnRefreshNow";
            this.btnRefreshNow.Size = new System.Drawing.Size(98, 23);
            this.btnRefreshNow.TabIndex = 25;
            this.btnRefreshNow.Text = "Odśwież teraz";
            this.btnRefreshNow.UseVisualStyleBackColor = true;
            this.btnRefreshNow.Click += new System.EventHandler(this.RefreshRows);
            // 
            // dataGridView1
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerColumn,
            this.UserColumn,
            this.SessionColumn,
            this.IDColumn,
            this.StatusColumn,
            this.IdleTimeColumn,
            this.LogonTimeColumn});
            this.DataGridView.ContextMenuStrip = this.ContextMenuSession;
            this.DataGridView.GridColor = System.Drawing.Color.DarkGray;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DataGridView.MultiSelect = false;
            this.DataGridView.Name = "dataGridView1";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(629, 596);
            this.DataGridView.TabIndex = 0;
            // 
            // ServerColumn
            // 
            this.ServerColumn.HeaderText = "Serwer";
            this.ServerColumn.Name = "ServerColumn";
            this.ServerColumn.ReadOnly = true;
            this.ServerColumn.Width = 65;
            // 
            // UserColumn
            // 
            this.UserColumn.HeaderText = "Nazwa użytkownika";
            this.UserColumn.Name = "UserColumn";
            this.UserColumn.ReadOnly = true;
            this.UserColumn.Width = 127;
            // 
            // SessionColumn
            // 
            this.SessionColumn.HeaderText = "Sesja";
            this.SessionColumn.Name = "SessionColumn";
            this.SessionColumn.ReadOnly = true;
            this.SessionColumn.Width = 58;
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 43;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 62;
            // 
            // IdleTimeColumn
            // 
            this.IdleTimeColumn.HeaderText = "Idle";
            this.IdleTimeColumn.Name = "IdleTimeColumn";
            this.IdleTimeColumn.ReadOnly = true;
            this.IdleTimeColumn.Width = 49;
            // 
            // LogonTimeColumn
            // 
            this.LogonTimeColumn.HeaderText = "Czas logowania";
            this.LogonTimeColumn.Name = "LogonTimeColumn";
            this.LogonTimeColumn.ReadOnly = true;
            this.LogonTimeColumn.Width = 106;
            // 
            // ContextMenuSession
            // 
            this.ContextMenuSession.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ContextMenuSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSessionConnect,
            this.menuItemSessionDisconnect,
            this.menuItemSessionSendMessage,
            this.menuItemSessionRemoteControl,
            this.menuItemSessionReset,
            this.menuItemSessionLogoff,
            this.menuItemSessionStatus,
            this.menuItemSessionProcesses});
            this.ContextMenuSession.Name = "ContextMenuSession";
            this.ContextMenuSession.ShowImageMargin = false;
            this.ContextMenuSession.Size = new System.Drawing.Size(126, 180);
            // 
            // menuItemSessionConnect
            // 
            this.menuItemSessionConnect.Name = "menuItemSessionConnect";
            this.menuItemSessionConnect.ShowShortcutKeys = false;
            this.menuItemSessionConnect.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionConnect.Text = "Połącz";
            this.menuItemSessionConnect.Visible = false;
            // 
            // menuItemSessionDisconnect
            // 
            this.menuItemSessionDisconnect.Name = "menuItemSessionDisconnect";
            this.menuItemSessionDisconnect.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionDisconnect.Text = "Rozłącz";
            this.menuItemSessionDisconnect.Click += new System.EventHandler(this.ContextMenus);
            // 
            // menuItemSessionSendMessage
            // 
            this.menuItemSessionSendMessage.Name = "menuItemSessionSendMessage";
            this.menuItemSessionSendMessage.ShowShortcutKeys = false;
            this.menuItemSessionSendMessage.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionSendMessage.Text = "Wyślij wiadomość";
            this.menuItemSessionSendMessage.Click += new System.EventHandler(this.ContextMenus);
            // 
            // menuItemSessionRemoteControl
            // 
            this.menuItemSessionRemoteControl.Name = "menuItemSessionRemoteControl";
            this.menuItemSessionRemoteControl.ShowShortcutKeys = false;
            this.menuItemSessionRemoteControl.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionRemoteControl.Text = "Zdalna kontrola";
            this.menuItemSessionRemoteControl.Click += new System.EventHandler(this.ContextMenus);
            // 
            // menuItemSessionReset
            // 
            this.menuItemSessionReset.Name = "menuItemSessionReset";
            this.menuItemSessionReset.ShowShortcutKeys = false;
            this.menuItemSessionReset.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionReset.Text = "Reset";
            this.menuItemSessionReset.Visible = false;
            // 
            // menuItemSessionLogoff
            // 
            this.menuItemSessionLogoff.Name = "menuItemSessionLogoff";
            this.menuItemSessionLogoff.ShowShortcutKeys = false;
            this.menuItemSessionLogoff.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionLogoff.Text = "Wyloguj";
            this.menuItemSessionLogoff.Click += new System.EventHandler(this.ContextMenus);
            // 
            // menuItemSessionStatus
            // 
            this.menuItemSessionStatus.Name = "menuItemSessionStatus";
            this.menuItemSessionStatus.ShowShortcutKeys = false;
            this.menuItemSessionStatus.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionStatus.Text = "Status";
            this.menuItemSessionStatus.Click += new System.EventHandler(this.ContextMenus);
            // 
            // menuItemSessionProcesses
            // 
            this.menuItemSessionProcesses.Name = "menuItemSessionProcesses";
            this.menuItemSessionProcesses.ShowShortcutKeys = false;
            this.menuItemSessionProcesses.Size = new System.Drawing.Size(125, 22);
            this.menuItemSessionProcesses.Text = "Procesy";
            this.menuItemSessionProcesses.Click += new System.EventHandler(this.ContextMenus);
            // 
            // TabPageProcess
            // 
            this.TabPageProcess.Location = new System.Drawing.Point(0, 0);
            this.TabPageProcess.Name = "TabPageProcess";
            this.TabPageProcess.Size = new System.Drawing.Size(200, 100);
            this.TabPageProcess.TabIndex = 0;
            // 
            // LabelProcessCount
            // 
            this.LabelProcessCount.Location = new System.Drawing.Point(0, 0);
            this.LabelProcessCount.Name = "LabelProcessCount";
            this.LabelProcessCount.Size = new System.Drawing.Size(100, 23);
            this.LabelProcessCount.TabIndex = 0;
            // 
            // contextMenuProcess
            // 
            this.contextMenuProcess.Name = "contextMenuProcess";
            this.contextMenuProcess.Size = new System.Drawing.Size(61, 4);
            // 
            // ZabijProcess
            // 
            this.menuItemProcessKill.Name = "menuItemProcessKill";
            this.menuItemProcessKill.Size = new System.Drawing.Size(32, 19);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 646);
            this.Controls.Add(this.tabControl);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(653, 685);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 685);
            this.Name = "ExplorerForm";
            this.Text = "Terminal Explorer";
            this.tabControl.ResumeLayout(false);
            this.tabPageSession.ResumeLayout(false);
            this.tabPageSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ContextMenuSession.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSession;
        private System.Windows.Forms.TabPage TabPageProcess;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdleTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogonTimeColumn;
        private System.Windows.Forms.ContextMenuStrip ContextMenuSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionConnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionDisconnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionSendMessage;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionRemoteControl;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionReset;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionLogoff;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionStatus;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionProcesses;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnRefreshNow;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ContextMenuStrip contextMenuProcess;
        private System.Windows.Forms.ToolStripMenuItem menuItemProcessKill;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label labelSessionCount;
        private System.Windows.Forms.Label LabelProcessCount;
    }
}
