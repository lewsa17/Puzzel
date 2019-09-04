namespace Puzzel
{
    partial class TerminalExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalExplorer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sesjeTab = new System.Windows.Forms.TabPage();
            this.sessionCount = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.serverCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sessionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogonTimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextSessionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.polaczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozlaczToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyslijWiadomoscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zdalnaKontrolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wylogujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesTab = new System.Windows.Forms.TabPage();
            this.processCount = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextProcessMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ZabijProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.sesjeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ContextSessionMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sesjeTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 649);
            this.tabControl1.TabIndex = 0;
            // 
            // sesjeTab
            // 
            this.sesjeTab.Controls.Add(this.sessionCount);
            this.sesjeTab.Controls.Add(this.button3);
            this.sesjeTab.Controls.Add(this.button4);
            this.sesjeTab.Controls.Add(this.dataGridView1);
            this.sesjeTab.Location = new System.Drawing.Point(4, 22);
            this.sesjeTab.Name = "sesjeTab";
            this.sesjeTab.Padding = new System.Windows.Forms.Padding(3);
            this.sesjeTab.Size = new System.Drawing.Size(629, 623);
            this.sesjeTab.TabIndex = 0;
            this.sesjeTab.Text = "Sesje";
            this.sesjeTab.UseVisualStyleBackColor = true;
            // 
            // sessionCount
            // 
            this.sessionCount.AutoSize = true;
            this.sessionCount.Location = new System.Drawing.Point(6, 602);
            this.sessionCount.Name = "sessionCount";
            this.sessionCount.Size = new System.Drawing.Size(83, 13);
            this.sessionCount.TabIndex = 27;
            this.sessionCount.Text = "Aktywne Sesje: ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(552, 597);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Zamknij";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.zamykanieFormy);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(382, 597);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "Odśwież teraz";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serverCol,
            this.userCol,
            this.sessionCol,
            this.idCol,
            this.statusCol,
            this.idleCol,
            this.LogonTimeCol});
            this.dataGridView1.ContextMenuStrip = this.ContextSessionMenu;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(629, 596);
            this.dataGridView1.TabIndex = 0;
            // 
            // serverCol
            // 
            this.serverCol.HeaderText = "Serwer";
            this.serverCol.Name = "serverCol";
            this.serverCol.Width = 64;
            // 
            // userCol
            // 
            this.userCol.HeaderText = "Nazwa użytkownika";
            this.userCol.Name = "userCol";
            this.userCol.Width = 126;
            // 
            // sessionCol
            // 
            this.sessionCol.HeaderText = "Sesja";
            this.sessionCol.Name = "sessionCol";
            this.sessionCol.Width = 57;
            // 
            // idCol
            // 
            this.idCol.HeaderText = "ID";
            this.idCol.Name = "idCol";
            this.idCol.Width = 42;
            // 
            // statusCol
            // 
            this.statusCol.HeaderText = "Status";
            this.statusCol.Name = "statusCol";
            this.statusCol.Width = 61;
            // 
            // idleCol
            // 
            this.idleCol.HeaderText = "Idle";
            this.idleCol.Name = "idleCol";
            this.idleCol.Width = 48;
            // 
            // LogonTimeCol
            // 
            this.LogonTimeCol.HeaderText = "Czas logowania";
            this.LogonTimeCol.Name = "LogonTimeCol";
            this.LogonTimeCol.Width = 105;
            // 
            // ContextSessionMenu
            // 
            this.ContextSessionMenu.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ContextSessionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polaczToolStripMenuItem,
            this.rozlaczToolStripMenuItem,
            this.wyslijWiadomoscToolStripMenuItem,
            this.zdalnaKontrolaToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.wylogujToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.procesyToolStripMenuItem});
            this.ContextSessionMenu.Name = "contextMenuStrip1";
            this.ContextSessionMenu.ShowImageMargin = false;
            this.ContextSessionMenu.Size = new System.Drawing.Size(126, 180);
            // 
            // polaczToolStripMenuItem
            // 
            this.polaczToolStripMenuItem.Name = "polaczToolStripMenuItem";
            this.polaczToolStripMenuItem.ShowShortcutKeys = false;
            this.polaczToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.polaczToolStripMenuItem.Text = "Połącz";
            this.polaczToolStripMenuItem.Visible = false;
            // 
            // rozlaczToolStripMenuItem
            // 
            this.rozlaczToolStripMenuItem.Name = "rozlaczToolStripMenuItem";
            this.rozlaczToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rozlaczToolStripMenuItem.Text = "Rozłącz";
            this.rozlaczToolStripMenuItem.Click += new System.EventHandler(this.ContextMenus);
            // 
            // wyslijWiadomoscToolStripMenuItem
            // 
            this.wyslijWiadomoscToolStripMenuItem.Name = "wyslijWiadomoscToolStripMenuItem";
            this.wyslijWiadomoscToolStripMenuItem.ShowShortcutKeys = false;
            this.wyslijWiadomoscToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.wyslijWiadomoscToolStripMenuItem.Text = "Wyślij wiadomość";
            this.wyslijWiadomoscToolStripMenuItem.Click += new System.EventHandler(this.ContextMenus);
            // 
            // zdalnaKontrolaToolStripMenuItem
            // 
            this.zdalnaKontrolaToolStripMenuItem.Name = "zdalnaKontrolaToolStripMenuItem";
            this.zdalnaKontrolaToolStripMenuItem.ShowShortcutKeys = false;
            this.zdalnaKontrolaToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.zdalnaKontrolaToolStripMenuItem.Text = "Zdalna kontrola";
            this.zdalnaKontrolaToolStripMenuItem.Click += new System.EventHandler(this.ContextMenus);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShowShortcutKeys = false;
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Visible = false;
            // 
            // wylogujToolStripMenuItem
            // 
            this.wylogujToolStripMenuItem.Name = "wylogujToolStripMenuItem";
            this.wylogujToolStripMenuItem.ShowShortcutKeys = false;
            this.wylogujToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.wylogujToolStripMenuItem.Text = "Wyloguj";
            this.wylogujToolStripMenuItem.Click += new System.EventHandler(this.ContextMenus);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.ShowShortcutKeys = false;
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.ContextMenus);
            // 
            // procesyToolStripMenuItem
            // 
            this.procesyToolStripMenuItem.Name = "procesyToolStripMenuItem";
            this.procesyToolStripMenuItem.ShowShortcutKeys = false;
            this.procesyToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.procesyToolStripMenuItem.Text = "Procesy";
            this.procesyToolStripMenuItem.Click += new System.EventHandler(this.ContextMenus);
            // 
            // procesTab
            // 
            this.procesTab.Location = new System.Drawing.Point(0, 0);
            this.procesTab.Name = "procesTab";
            this.procesTab.Size = new System.Drawing.Size(200, 100);
            this.procesTab.TabIndex = 0;
            // 
            // processCount
            // 
            this.processCount.Location = new System.Drawing.Point(0, 0);
            this.processCount.Name = "processCount";
            this.processCount.Size = new System.Drawing.Size(100, 23);
            this.processCount.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // ContextProcessMenu
            // 
            this.ContextProcessMenu.Name = "ContextProcessMenu";
            this.ContextProcessMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // ZabijProcess
            // 
            this.ZabijProcess.Name = "ZabijProcess";
            this.ZabijProcess.Size = new System.Drawing.Size(32, 19);
            // 
            // TerminalExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 645);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(715, 672);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(644, 672);
            this.Name = "TerminalExplorer";
            this.Text = "Terminal Explorer";
            this.tabControl1.ResumeLayout(false);
            this.sesjeTab.ResumeLayout(false);
            this.sesjeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ContextSessionMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sesjeTab;
        private System.Windows.Forms.TabPage procesTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn userCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sessionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn idleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogonTimeCol;
        private System.Windows.Forms.ContextMenuStrip ContextSessionMenu;
        private System.Windows.Forms.ToolStripMenuItem polaczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozlaczToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyslijWiadomoscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zdalnaKontrolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wylogujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesyToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ContextMenuStrip ContextProcessMenu;
        private System.Windows.Forms.ToolStripMenuItem ZabijProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label sessionCount;
        private System.Windows.Forms.Label processCount;
    }
}