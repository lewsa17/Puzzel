namespace Puzzel.LockoutStatus
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lockout_Status));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wybierzUżytkownikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.widokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyczyśćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusHasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.odświeżZaznaczoneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.odświeżWszystkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusHasłaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odświeżZaznaczoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odświerzWszystkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bad_pwd_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_bad_pwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pwd_last_set = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lockout_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.odblokujKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.wyczyśćToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.widokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wybierzUżytkownikaToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // wybierzUżytkownikaToolStripMenuItem
            // 
            this.wybierzUżytkownikaToolStripMenuItem.Name = "wybierzUżytkownikaToolStripMenuItem";
            this.wybierzUżytkownikaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.wybierzUżytkownikaToolStripMenuItem.Text = "Wybierz użytkownika";
            this.wybierzUżytkownikaToolStripMenuItem.Click += new System.EventHandler(this.WybierzUżytkownikaToolStripMenuItem_Click);
            // 
            // widokToolStripMenuItem
            // 
            this.widokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wyczyśćToolStripMenuItem,
            this.toolStripSeparator1,
            this.statusHasToolStripMenuItem,
            this.toolStripSeparator2,
            this.odświeżZaznaczoneToolStripMenuItem1,
            this.odświeżWszystkoToolStripMenuItem});
            this.widokToolStripMenuItem.Name = "widokToolStripMenuItem";
            this.widokToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.widokToolStripMenuItem.Text = "Widok";
            // 
            // wyczyśćToolStripMenuItem
            // 
            this.wyczyśćToolStripMenuItem.Name = "wyczyśćToolStripMenuItem";
            this.wyczyśćToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.wyczyśćToolStripMenuItem.Text = "Wyczyść";
            this.wyczyśćToolStripMenuItem.Click += new System.EventHandler(this.WyczyśćToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // statusHasToolStripMenuItem
            // 
            this.statusHasToolStripMenuItem.Name = "statusHasToolStripMenuItem";
            this.statusHasToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.statusHasToolStripMenuItem.Text = "Status hasła";
            this.statusHasToolStripMenuItem.Click += new System.EventHandler(this.StatusHasłaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // odświeżZaznaczoneToolStripMenuItem1
            // 
            this.odświeżZaznaczoneToolStripMenuItem1.Name = "odświeżZaznaczoneToolStripMenuItem1";
            this.odświeżZaznaczoneToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.odświeżZaznaczoneToolStripMenuItem1.Text = "Odśwież zaznaczone";
            this.odświeżZaznaczoneToolStripMenuItem1.Click += new System.EventHandler(this.OdświeżZaznaczoneToolStripMenuItem_Click);
            // 
            // odświeżWszystkoToolStripMenuItem
            // 
            this.odświeżWszystkoToolStripMenuItem.Name = "odświeżWszystkoToolStripMenuItem";
            this.odświeżWszystkoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.odświeżWszystkoToolStripMenuItem.Text = "Odśwież wszystko";
            this.odświeżWszystkoToolStripMenuItem.Click += new System.EventHandler(this.OdświerzWszystkoToolStripMenuItem_Click);
            // 
            // statusHasłaToolStripMenuItem
            // 
            this.statusHasłaToolStripMenuItem.Name = "statusHasłaToolStripMenuItem";
            this.statusHasłaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.statusHasłaToolStripMenuItem.Text = "Status hasła";
            this.statusHasłaToolStripMenuItem.Click += new System.EventHandler(this.StatusHasłaToolStripMenuItem_Click);
            // 
            // odświeżZaznaczoneToolStripMenuItem
            // 
            this.odświeżZaznaczoneToolStripMenuItem.Name = "odświeżZaznaczoneToolStripMenuItem";
            this.odświeżZaznaczoneToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.odświeżZaznaczoneToolStripMenuItem.Text = "Odśwież zaznaczone";
            this.odświeżZaznaczoneToolStripMenuItem.Click += new System.EventHandler(this.OdświeżZaznaczoneToolStripMenuItem_Click);
            // 
            // odświerzWszystkoToolStripMenuItem
            // 
            this.odświerzWszystkoToolStripMenuItem.Name = "odświerzWszystkoToolStripMenuItem";
            this.odświerzWszystkoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.odświerzWszystkoToolStripMenuItem.Text = "Odśwież wszystko";
            this.odświerzWszystkoToolStripMenuItem.Click += new System.EventHandler(this.OdświerzWszystkoToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DC,
            this.user_state,
            this.bad_pwd_count,
            this.Last_bad_pwd,
            this.Pwd_last_set,
            this.Lockout_time});
            dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            dataGridView1.Location = new System.Drawing.Point(0, 25);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new System.Drawing.Size(745, 268);
            dataGridView1.TabIndex = 1;
            dataGridView1.TabStop = false;
            // 
            // DC
            // 
            this.DC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DC.DefaultCellStyle = dataGridViewCellStyle2;
            this.DC.HeaderText = "Kontroler domeny";
            this.DC.Name = "DC";
            this.DC.ReadOnly = true;
            this.DC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DC.Width = 120;
            // 
            // user_state
            // 
            this.user_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.user_state.DefaultCellStyle = dataGridViewCellStyle3;
            this.user_state.HeaderText = "Status konta";
            this.user_state.Name = "user_state";
            this.user_state.ReadOnly = true;
            this.user_state.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.user_state.Width = 95;
            // 
            // bad_pwd_count
            // 
            this.bad_pwd_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.bad_pwd_count.DefaultCellStyle = dataGridViewCellStyle4;
            this.bad_pwd_count.HeaderText = "Ilość błędnych prób";
            this.bad_pwd_count.Name = "bad_pwd_count";
            this.bad_pwd_count.ReadOnly = true;
            this.bad_pwd_count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bad_pwd_count.Width = 150;
            // 
            // Last_bad_pwd
            // 
            this.Last_bad_pwd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Last_bad_pwd.DefaultCellStyle = dataGridViewCellStyle5;
            this.Last_bad_pwd.HeaderText = "Ostatnie błędne";
            this.Last_bad_pwd.Name = "Last_bad_pwd";
            this.Last_bad_pwd.ReadOnly = true;
            this.Last_bad_pwd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Last_bad_pwd.Width = 130;
            // 
            // Pwd_last_set
            // 
            this.Pwd_last_set.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Pwd_last_set.DefaultCellStyle = dataGridViewCellStyle6;
            this.Pwd_last_set.HeaderText = "Ostatnia zmiana";
            this.Pwd_last_set.Name = "Pwd_last_set";
            this.Pwd_last_set.ReadOnly = true;
            this.Pwd_last_set.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Pwd_last_set.Width = 120;
            // 
            // Lockout_time
            // 
            this.Lockout_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.Lockout_time.DefaultCellStyle = dataGridViewCellStyle7;
            this.Lockout_time.HeaderText = "Kiedy zablokowane";
            this.Lockout_time.Name = "Lockout_time";
            this.Lockout_time.ReadOnly = true;
            this.Lockout_time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Lockout_time.Width = 130;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusHasłaToolStripMenuItem,
            this.odblokujKontoToolStripMenuItem,
            this.toolStripSeparator3,
            this.wyczyśćToolStripMenuItem1,
            this.toolStripSeparator4,
            this.odświeżZaznaczoneToolStripMenuItem,
            this.odświerzWszystkoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 126);
            // 
            // odblokujKontoToolStripMenuItem
            // 
            this.odblokujKontoToolStripMenuItem.Name = "odblokujKontoToolStripMenuItem";
            this.odblokujKontoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.odblokujKontoToolStripMenuItem.Text = "Odblokuj Konto";
            this.odblokujKontoToolStripMenuItem.Click += new System.EventHandler(this.OdblokujKonto);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // wyczyśćToolStripMenuItem1
            // 
            this.wyczyśćToolStripMenuItem1.Name = "wyczyśćToolStripMenuItem1";
            this.wyczyśćToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.wyczyśćToolStripMenuItem1.Text = "Wyczyść";
            this.wyczyśćToolStripMenuItem1.Click += new System.EventHandler(this.WyczyśćToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // Lockout_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 280);
            this.Controls.Add(dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Puzzel.Properties.Resources.Puzzel;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(752, 319);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(752, 319);
            this.Name = "Lockout_Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lockout_Status";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Lockout_Status_Activated);
            this.Load += new System.EventHandler(this.Lockout_Status_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem odblokujKontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyczyśćToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statusHasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odświeżZaznaczoneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem odświeżWszystkoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn bad_pwd_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_bad_pwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pwd_last_set;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lockout_time;
        private static System.Windows.Forms.DataGridView dataGridView1;
    }
}