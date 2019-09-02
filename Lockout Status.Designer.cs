namespace Puzzel
{
    partial class Lockout_Status
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybierzUżytkownikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyczyśćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusHasłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.odświeżZaznaczoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odświerzWszystkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bad_pwd_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_bad_pwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pwd_last_set = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lockout_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progress = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.widokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wybierzUżytkownikaToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // wybierzUżytkownikaToolStripMenuItem
            // 
            this.wybierzUżytkownikaToolStripMenuItem.Name = "wybierzUżytkownikaToolStripMenuItem";
            this.wybierzUżytkownikaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.wybierzUżytkownikaToolStripMenuItem.Text = "Wybierz użytkownika";
            this.wybierzUżytkownikaToolStripMenuItem.Click += new System.EventHandler(this.WybierzUżytkownikaToolStripMenuItem_Click);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyczyśćToolStripMenuItem,
            this.toolStripSeparator1,
            this.statusHasłaToolStripMenuItem,
            this.toolStripSeparator2,
            this.odświeżZaznaczoneToolStripMenuItem,
            this.odświerzWszystkoToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // wyczyśćToolStripMenuItem
            // 
            this.wyczyśćToolStripMenuItem.Name = "wyczyśćToolStripMenuItem";
            this.wyczyśćToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.wyczyśćToolStripMenuItem.Text = "Wyczyść";
            this.wyczyśćToolStripMenuItem.Click += new System.EventHandler(this.wyczyśćToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // statusHasłaToolStripMenuItem
            // 
            this.statusHasłaToolStripMenuItem.Name = "statusHasłaToolStripMenuItem";
            this.statusHasłaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.statusHasłaToolStripMenuItem.Text = "Status hasła";
            this.statusHasłaToolStripMenuItem.Click += new System.EventHandler(this.statusHasłaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // odświeżZaznaczoneToolStripMenuItem
            // 
            this.odświeżZaznaczoneToolStripMenuItem.Name = "odświeżZaznaczoneToolStripMenuItem";
            this.odświeżZaznaczoneToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.odświeżZaznaczoneToolStripMenuItem.Text = "Odśwież zaznaczone";
            this.odświeżZaznaczoneToolStripMenuItem.Click += new System.EventHandler(this.OdświeżZaznaczoneToolStripMenuItem_Click);
            // 
            // odświerzWszystkoToolStripMenuItem
            // 
            this.odświerzWszystkoToolStripMenuItem.Name = "odświerzWszystkoToolStripMenuItem";
            this.odświerzWszystkoToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.odświerzWszystkoToolStripMenuItem.Text = "Odświerz wszystko";
            this.odświerzWszystkoToolStripMenuItem.Click += new System.EventHandler(this.odświerzWszystkoToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DC,
            this.user_state,
            this.bad_pwd_count,
            this.Last_bad_pwd,
            this.Pwd_last_set,
            this.Lockout_time});
            this.dataGridView1.Location = new System.Drawing.Point(4, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(745, 268);
            this.dataGridView1.TabIndex = 1;
            // 
            // DC
            // 
            this.DC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DC.HeaderText = "Kontroler domeny";
            this.DC.Name = "DC";
            this.DC.ReadOnly = true;
            this.DC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DC.Width = 120;
            // 
            // user_state
            // 
            this.user_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.user_state.DefaultCellStyle = dataGridViewCellStyle1;
            this.user_state.HeaderText = "Status konta";
            this.user_state.Name = "user_state";
            this.user_state.ReadOnly = true;
            this.user_state.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.user_state.Width = 95;
            // 
            // bad_pwd_count
            // 
            this.bad_pwd_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.bad_pwd_count.DefaultCellStyle = dataGridViewCellStyle2;
            this.bad_pwd_count.HeaderText = "Ilość błędnych prób";
            this.bad_pwd_count.Name = "bad_pwd_count";
            this.bad_pwd_count.ReadOnly = true;
            this.bad_pwd_count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bad_pwd_count.Width = 150;
            // 
            // Last_bad_pwd
            // 
            this.Last_bad_pwd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Last_bad_pwd.HeaderText = "Ostatnie błędne";
            this.Last_bad_pwd.Name = "Last_bad_pwd";
            this.Last_bad_pwd.ReadOnly = true;
            this.Last_bad_pwd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Last_bad_pwd.Width = 130;
            // 
            // Pwd_last_set
            // 
            this.Pwd_last_set.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Pwd_last_set.HeaderText = "Ostatnia zmiana";
            this.Pwd_last_set.Name = "Pwd_last_set";
            this.Pwd_last_set.ReadOnly = true;
            this.Pwd_last_set.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Pwd_last_set.Width = 120;
            // 
            // Lockout_time
            // 
            this.Lockout_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Lockout_time.HeaderText = "Kiedy zablokowane";
            this.Lockout_time.Name = "Lockout_time";
            this.Lockout_time.ReadOnly = true;
            this.Lockout_time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Lockout_time.Width = 130;
            // 
            // progress
            // 
            this.progress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.progress_DoWork);
            // 
            // Lockout_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 295);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(759, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(759, 320);
            this.Name = "Lockout_Status";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lockout_Status";
            this.Activated += new System.EventHandler(this.Lockout_Status_Activated);
            this.Load += new System.EventHandler(this.Lockout_Status_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wybierzUżytkownikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem widokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyczyśćToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem statusHasłaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem odświeżZaznaczoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odświerzWszystkoToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn bad_pwd_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_bad_pwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pwd_last_set;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lockout_time;
        private System.ComponentModel.BackgroundWorker progress;
    }
}