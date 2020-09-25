namespace Forms.External
{
    partial class LockoutStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockoutStatus));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSelectUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPasswordStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemRefreshSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRefreshAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemPasswordStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemRefreshSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemRefreshAll = new System.Windows.Forms.ToolStripMenuItem();
            dataGridView = new System.Windows.Forms.DataGridView();
            this.DCColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserStateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BadPasswordCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastBadPasswordAttemptColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastSetPasswordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LockoutTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuItemUnlockAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuseparator = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuItemClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuseparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(736, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSelectUser});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(38, 20);
            this.menuItemFile.Text = "Plik";
            // 
            // menuItemSelectUser
            // 
            this.menuItemSelectUser.Name = "menuItemSelectUser";
            this.menuItemSelectUser.Size = new System.Drawing.Size(185, 22);
            this.menuItemSelectUser.Text = "Wybierz użytkownika";
            this.menuItemSelectUser.Click += new System.EventHandler(this.menuItemSelectUser_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClear,
            this.menuSeparator,
            this.menuItemPasswordStatus,
            this.menuSeparator2,
            this.menuItemRefreshSelected,
            this.menuItemRefreshAll});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(53, 20);
            this.menuItemView.Text = "Widok";
            // 
            // menuItemClear
            // 
            this.menuItemClear.Name = "menuItemClear";
            this.menuItemClear.Size = new System.Drawing.Size(181, 22);
            this.menuItemClear.Text = "Wyczyść";
            this.menuItemClear.Click += new System.EventHandler(this.menuItemClearAll_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(178, 6);
            // 
            // menuItemPasswordStatus
            // 
            this.menuItemPasswordStatus.Name = "menuItemPasswordStatus";
            this.menuItemPasswordStatus.Size = new System.Drawing.Size(181, 22);
            this.menuItemPasswordStatus.Text = "Status hasła";
            this.menuItemPasswordStatus.Click += new System.EventHandler(this.menuItemPasswordStatus_Click);
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            this.menuSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // menuItemRefreshSelected
            // 
            this.menuItemRefreshSelected.Name = "menuItemRefreshSelected";
            this.menuItemRefreshSelected.Size = new System.Drawing.Size(181, 22);
            this.menuItemRefreshSelected.Text = "Odśwież zaznaczone";
            this.menuItemRefreshSelected.Click += new System.EventHandler(this.menuItemRefreshSelected_Click);
            // 
            // menuItemRefreshAll
            // 
            this.menuItemRefreshAll.Name = "menuItemRefreshAll";
            this.menuItemRefreshAll.Size = new System.Drawing.Size(181, 22);
            this.menuItemRefreshAll.Text = "Odśwież wszystko";
            this.menuItemRefreshAll.Click += new System.EventHandler(this.menuItemRefreshAll_Click);
            // 
            // contextMenuItemPasswordStatus
            // 
            this.contextMenuItemPasswordStatus.Name = "contextMenuItemPasswordStatus";
            this.contextMenuItemPasswordStatus.Size = new System.Drawing.Size(181, 22);
            this.contextMenuItemPasswordStatus.Text = "Status hasła";
            this.contextMenuItemPasswordStatus.Click += new System.EventHandler(this.menuItemPasswordStatus_Click);
            // 
            // contextMenuItemRefreshSelected
            // 
            this.contextMenuItemRefreshSelected.Name = "contextMenuItemRefreshSelected";
            this.contextMenuItemRefreshSelected.Size = new System.Drawing.Size(181, 22);
            this.contextMenuItemRefreshSelected.Text = "Odśwież zaznaczone";
            this.contextMenuItemRefreshSelected.Click += new System.EventHandler(this.menuItemRefreshSelected_Click);
            // 
            // contextMenuItemRefreshAll
            // 
            this.contextMenuItemRefreshAll.Name = "contextMenuItemRefreshAll";
            this.contextMenuItemRefreshAll.Size = new System.Drawing.Size(181, 22);
            this.contextMenuItemRefreshAll.Text = "Odśwież wszystko";
            this.contextMenuItemRefreshAll.Click += new System.EventHandler(this.menuItemRefreshAll_Click);
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DCColumn,
            this.UserStateColumn,
            this.BadPasswordCountColumn,
            this.LastBadPasswordAttemptColumn,
            this.LastSetPasswordColumn,
            this.LockoutTimeColumn});
            dataGridView.ContextMenuStrip = this.ContextMenu;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView.GridColor = System.Drawing.SystemColors.Control;
            dataGridView.Location = new System.Drawing.Point(0, 25);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ShowEditingIcon = false;
            dataGridView.Size = new System.Drawing.Size(745, 268);
            dataGridView.TabIndex = 1;
            dataGridView.TabStop = false;
            // 
            // DCColumn
            // 
            this.DCColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DCColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.DCColumn.HeaderText = "Kontroler domeny";
            this.DCColumn.Name = "DCColumn";
            this.DCColumn.ReadOnly = true;
            this.DCColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DCColumn.Width = 120;
            // 
            // UserStateColumn
            // 
            this.UserStateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.UserStateColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.UserStateColumn.HeaderText = "Status konta";
            this.UserStateColumn.Name = "UserStateColumn";
            this.UserStateColumn.ReadOnly = true;
            this.UserStateColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UserStateColumn.Width = 95;
            // 
            // BadPasswordCountColumn
            // 
            this.BadPasswordCountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.BadPasswordCountColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.BadPasswordCountColumn.HeaderText = "Ilość błędnych prób";
            this.BadPasswordCountColumn.Name = "BadPasswordCountColumn";
            this.BadPasswordCountColumn.ReadOnly = true;
            this.BadPasswordCountColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BadPasswordCountColumn.Width = 150;
            // 
            // LastBadPasswordAttemptColumn
            // 
            this.LastBadPasswordAttemptColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.LastBadPasswordAttemptColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.LastBadPasswordAttemptColumn.HeaderText = "Ostatnie błędne";
            this.LastBadPasswordAttemptColumn.Name = "LastBadPasswordAttemptColumn";
            this.LastBadPasswordAttemptColumn.ReadOnly = true;
            this.LastBadPasswordAttemptColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LastBadPasswordAttemptColumn.Width = 130;
            // 
            // LastSetPasswordColumn
            // 
            this.LastSetPasswordColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.LastSetPasswordColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.LastSetPasswordColumn.HeaderText = "Ostatnia zmiana";
            this.LastSetPasswordColumn.Name = "LastSetPasswordColumn";
            this.LastSetPasswordColumn.ReadOnly = true;
            this.LastSetPasswordColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LastSetPasswordColumn.Width = 120;
            // 
            // LockoutTimeColumn
            // 
            this.LockoutTimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.LockoutTimeColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.LockoutTimeColumn.HeaderText = "Kiedy zablokowane";
            this.LockoutTimeColumn.Name = "LockoutTimeColumn";
            this.LockoutTimeColumn.ReadOnly = true;
            this.LockoutTimeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LockoutTimeColumn.Width = 130;
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuItemPasswordStatus,
            this.contextMenuItemUnlockAccount,
            this.contextMenuseparator,
            this.contextMenuItemClearAll,
            this.contextMenuseparator2,
            this.contextMenuItemRefreshSelected,
            this.contextMenuItemRefreshAll});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(182, 126);
            // 
            // menuItemUnlockAccount
            // 
            this.contextMenuItemUnlockAccount.Name = "menuItemUnlockAccount";
            this.contextMenuItemUnlockAccount.Size = new System.Drawing.Size(181, 22);
            this.contextMenuItemUnlockAccount.Text = "Odblokuj Konto";
            this.contextMenuItemUnlockAccount.Click += new System.EventHandler(this.UnlockAll_Click);
            // 
            // contextMenuseparator
            // 
            this.contextMenuseparator.Name = "contextMenuseparator";
            this.contextMenuseparator.Size = new System.Drawing.Size(178, 6);
            // 
            // menuItemClearAll
            // 
            this.contextMenuItemClearAll.Name = "menuItemClearAll";
            this.contextMenuItemClearAll.Size = new System.Drawing.Size(181, 22);
            this.contextMenuItemClearAll.Text = "Wyczyść";
            this.contextMenuItemClearAll.Click += new System.EventHandler(this.menuItemClearAll_Click);
            // 
            // Separator4
            // 
            this.contextMenuseparator2.Name = "Separator4";
            this.contextMenuseparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // LockoutStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 280);
            this.Controls.Add(dataGridView);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(752, 319);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(752, 319);
            this.Name = "LockoutStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lockout Status";
            this.TopMost = false;
            this.Activated += new System.EventHandler(this.LockoutStatus_Activated);
            this.Load += new System.EventHandler(this.LockoutStatus_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).EndInit();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectUser;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemClear;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemPasswordStatus;
        private System.Windows.Forms.ToolStripSeparator menuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRefreshSelected;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRefreshAll;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemUnlockAccount;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemClearAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemPasswordStatus;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefreshSelected;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefreshAll;
        private System.Windows.Forms.ToolStripSeparator contextMenuseparator;
        private System.Windows.Forms.ToolStripSeparator contextMenuseparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserStateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BadPasswordCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastBadPasswordAttemptColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastSetPasswordColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LockoutTimeColumn;
        private static System.Windows.Forms.DataGridView dataGridView;
    }
}
