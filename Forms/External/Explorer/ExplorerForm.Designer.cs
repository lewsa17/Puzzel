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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new();
            System.ComponentModel.ComponentResourceManager resources = new(typeof(ExplorerForm));
            this.tabControl = new();
            this.tabPageSession = new();
            this.labelSessionCount = new();
            this.btnCloseForm = new();
            this.btnRefreshNow = new();
            this.DataGridView = new();
            this.ServerColumn = new();
            this.UserColumn = new();
            this.SessionColumn = new();
            this.IDColumn = new();
            this.StatusColumn = new();
            this.IdleTimeColumn = new();
            this.LogonTimeColumn = new();
            this.ContextMenuSession = new(this.components);
            this.menuItemSessionConnect = new();
            this.menuItemSessionDisconnect = new();
            this.menuItemSessionSendMessage = new();
            this.menuItemSessionRemoteControl = new();
            this.menuItemSessionReset = new();
            this.menuItemSessionLogoff = new(); 
            this.menuItemSessionStatus = new();
            this.menuItemSessionProcesses = new();
            this.LabelProcessCount = new();
            this.button5 = new();
            this.button6 = new();
            this.dataGridViewTextBoxColumn1 = new();
            this.dataGridViewTextBoxColumn2 = new();
            this.dataGridViewTextBoxColumn3 = new();
            this.dataGridViewTextBoxColumn4 = new();
            this.dataGridViewTextBoxColumn5 = new();
            this.dataGridViewTextBoxColumn6 = new();
            this.contextMenuProcess = new(this.components);
            this.menuItemProcessKill = new();
            this.tabControl.SuspendLayout();
            this.tabPageSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.ContextMenuSession.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSession);
            this.tabControl.Location = new(0, 0);
            this.tabControl.Margin = new(5, 3, 5, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new(743, 714);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSession
            // 
            this.tabPageSession.Controls.Add(this.DataGridView);
            this.tabPageSession.Location = new(4, 24);
            this.tabPageSession.Name = "tabPageSession";
            this.tabPageSession.Padding = new(4, 3, 4, 3);
            this.tabPageSession.Size = new(735, 686);
            this.tabPageSession.TabIndex = 0;
            this.tabPageSession.Text = "Sesje";
            this.tabPageSession.UseVisualStyleBackColor = true;
            // 
            // labelSessionCount
            // 
            this.labelSessionCount.AutoSize = true;
            this.labelSessionCount.Location = new(7, 723);
            this.labelSessionCount.Margin = new(4, 0, 4, 0);
            this.labelSessionCount.Name = "labelSessionCount";
            this.labelSessionCount.Size = new(88, 15);
            this.labelSessionCount.TabIndex = 27;
            this.labelSessionCount.Text = "Aktywne Sesje: ";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new(644, 716);
            this.btnCloseForm.Margin = new(4, 3, 4, 3);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new(89, 27);
            this.btnCloseForm.TabIndex = 26;
            this.btnCloseForm.Text = "Zamknij";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new(this.CloseTabForm);
            // 
            // btnRefreshNow
            // 
            this.btnRefreshNow.Location = new(522, 716);
            this.btnRefreshNow.Margin = new(4, 3, 4, 3);
            this.btnRefreshNow.Name = "btnRefreshNow";
            this.btnRefreshNow.Size = new(114, 27);
            this.btnRefreshNow.TabIndex = 25;
            this.btnRefreshNow.Text = "Odśwież teraz";
            this.btnRefreshNow.UseVisualStyleBackColor = true;
            this.btnRefreshNow.Click += new(this.BtnRefresh_Click);
            // 
            // dataGridView1
            // 
           // this.DataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new[] {
            this.ServerColumn,
            this.UserColumn,
            this.SessionColumn,
            this.IDColumn,
            this.StatusColumn,
            this.IdleTimeColumn,
            this.LogonTimeColumn});
            this.DataGridView.ContextMenuStrip = this.ContextMenuSession;
            this.DataGridView.GridColor = System.Drawing.Color.DarkGray;
            this.DataGridView.Location = new(0, 0);
            this.DataGridView.Margin = new(5, 3, 5, 3);
            this.DataGridView.MultiSelect = false;
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new(734, 686);
            this.DataGridView.TabIndex = 0;
            // 
            // ServerColumn
            // 
            this.ServerColumn.HeaderText = "Serwer";
            this.ServerColumn.Name = "ServerColumn";
            this.ServerColumn.ReadOnly = true;
            this.ServerColumn.Width = 65;
            this.ServerColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // UserColumn
            // 
            this.UserColumn.HeaderText = "Nazwa użytkownika";
            this.UserColumn.Name = "UserColumn";
            this.UserColumn.ReadOnly = true;
            this.UserColumn.Width = 127;
            this.UserColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // SessionColumn
            // 
            this.SessionColumn.HeaderText = "Sesja";
            this.SessionColumn.Name = "SessionColumn";
            this.SessionColumn.ReadOnly = true;
            this.SessionColumn.Width = 58;
            this.SessionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.StatusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // IdleTimeColumn
            // 
            this.IdleTimeColumn.HeaderText = "Idle";
            this.IdleTimeColumn.Name = "IdleTimeColumn";
            this.IdleTimeColumn.ReadOnly = true;
            this.IdleTimeColumn.Width = 49;
            this.IdleTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // LogonTimeColumn
            // 
            this.LogonTimeColumn.HeaderText = "Czas logowania";
            this.LogonTimeColumn.Name = "LogonTimeColumn";
            this.LogonTimeColumn.ReadOnly = true;
            this.LogonTimeColumn.Width = 106;
            this.LogonTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // ContextMenuSession
            // 
            this.ContextMenuSession.Font = new("Tahoma", 8F);
            this.ContextMenuSession.Items.AddRange(new[] {
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
            this.ContextMenuSession.Size = new(126, 180);
            // 
            // menuItemSessionConnect
            // 
            this.menuItemSessionConnect.Name = "menuItemSessionConnect";
            this.menuItemSessionConnect.ShowShortcutKeys = false;
            this.menuItemSessionConnect.Size = new(125, 22);
            this.menuItemSessionConnect.Text = "Połącz";
            this.menuItemSessionConnect.Visible = false;
            // 
            // menuItemSessionDisconnect
            // 
            this.menuItemSessionDisconnect.Name = "menuItemSessionDisconnect";
            this.menuItemSessionDisconnect.Size = new(125, 22);
            this.menuItemSessionDisconnect.Text = "Rozłącz";
            this.menuItemSessionDisconnect.Click += new(this.ContextMenus);
            // 
            // menuItemSessionSendMessage
            // 
            this.menuItemSessionSendMessage.Name = "menuItemSessionSendMessage";
            this.menuItemSessionSendMessage.ShowShortcutKeys = false;
            this.menuItemSessionSendMessage.Size = new(125, 22);
            this.menuItemSessionSendMessage.Text = "Wyślij wiadomość";
            this.menuItemSessionSendMessage.Click += new(this.ContextMenus);
            // 
            // menuItemSessionRemoteControl
            // 
            this.menuItemSessionRemoteControl.Name = "menuItemSessionRemoteControl";
            this.menuItemSessionRemoteControl.ShowShortcutKeys = false;
            this.menuItemSessionRemoteControl.Size = new(125, 22);
            this.menuItemSessionRemoteControl.Text = "Zdalna kontrola";
            this.menuItemSessionRemoteControl.Click += new(this.ContextMenus);
            // 
            // menuItemSessionReset
            // 
            this.menuItemSessionReset.Name = "menuItemSessionReset";
            this.menuItemSessionReset.ShowShortcutKeys = false;
            this.menuItemSessionReset.Size = new(125, 22);
            this.menuItemSessionReset.Text = "Reset";
            this.menuItemSessionReset.Visible = false;
            // 
            // menuItemSessionLogoff
            // 
            this.menuItemSessionLogoff.Name = "menuItemSessionLogoff";
            this.menuItemSessionLogoff.ShowShortcutKeys = false;
            this.menuItemSessionLogoff.Size = new(125, 22);
            this.menuItemSessionLogoff.Text = "Wyloguj";
            this.menuItemSessionLogoff.Click += new(this.ContextMenus);
            // 
            // menuItemSessionStatus
            // 
            this.menuItemSessionStatus.Name = "menuItemSessionStatus";
            this.menuItemSessionStatus.ShowShortcutKeys = false;
            this.menuItemSessionStatus.Size = new(125, 22);
            this.menuItemSessionStatus.Text = "Status";
            this.menuItemSessionStatus.Click += new(this.ContextMenus);
            // 
            // menuItemSessionProcesses
            // 
            this.menuItemSessionProcesses.Name = "menuItemSessionProcesses";
            this.menuItemSessionProcesses.ShowShortcutKeys = false;
            this.menuItemSessionProcesses.Size = new(125, 22);
            this.menuItemSessionProcesses.Text = "Procesy";
            this.menuItemSessionProcesses.Click += new(this.ContextMenus);
            // 
            // LabelProcessCount
            // 
            this.LabelProcessCount.Location = new(0, 0);
            this.LabelProcessCount.Name = "LabelProcessCount";
            this.LabelProcessCount.Size = new(100, 23);
            this.LabelProcessCount.TabIndex = 0;
            // 
            // contextMenuProcess
            // 
            this.contextMenuProcess.Name = "contextMenuProcess";
            this.contextMenuProcess.Size = new(61, 4);
            // 
            // ZabijProcess
            // 
            this.menuItemProcessKill.Name = "menuItemProcessKill";
            this.menuItemProcessKill.Size = new(32, 19);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(743, 745);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.labelSessionCount);
            this.Controls.Add(this.btnRefreshNow);
            this.DoubleBuffered = true;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.Margin = new(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new(759, 784);
            this.MinimizeBox = false;
            this.MinimumSize = new(759, 784);
            this.Name = "ExplorerForm";
            this.Text = "Terminal Explorer";
            this.tabControl.ResumeLayout(false);
            this.tabPageSession.ResumeLayout(false);
            this.tabPageSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ContextMenuSession.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSession;
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
