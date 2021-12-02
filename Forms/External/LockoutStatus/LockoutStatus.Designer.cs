using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new();
            System.ComponentModel.ComponentResourceManager resources = new(typeof(LockoutStatus));
            this.mainMenu = new();
            this.menuItemFile = new();
            this.menuItemSelectUser = new();
            this.menuItemView = new();
            this.menuItemClear = new();
            this.menuItemPasswordStatus = new();
            this.contextMenuItemCopyValue = new();
            this.contextMenuItemCopySelectedRow = new();
            this.menuItemRefreshSelected = new();
            this.menuItemRefreshAll = new();
            this.contextMenuItemPasswordStatus = new();
            this.contextMenuItemRefreshSelected = new();
            this.contextMenuItemRefreshAll = new();
            dataGridView = new();
            this.DCColumn = new();
            this.DCSiteName = new();
            this.UserStateColumn = new();
            this.BadPasswordCountColumn = new();
            this.LastBadPasswordAttemptColumn = new();
            this.LastSetPasswordColumn = new();
            this.LockoutTimeColumn = new();
            this.ContextMenu = new(this.components);
            this.ContextMenuFile = new(this.components);
            this.ContextMenuView = new(this.components);
            this.contextMenuItemUnlockAccount = new();
            this.contextMenuItemClearAll = new();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
            this.ContextMenu.SuspendLayout();
            this.ContextMenuFile.SuspendLayout();
            this.ContextMenuView.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new[] {
            this.menuItemFile,
            this.menuItemView});
            this.mainMenu.Location = new(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new(736, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDown = ContextMenuFile;
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new(38, 20);
            this.menuItemFile.Text = "Plik";
            // 
            // menuItemSelectUser
            // 
            this.menuItemSelectUser.Name = "menuItemSelectUser";
            this.menuItemSelectUser.Size = new(185, 22);
            this.menuItemSelectUser.Text = "Wybierz użytkownika";
            this.menuItemSelectUser.Click += new(this.MenuItemSelectUser_Click);
            //
            // ContextMenuFile
            //
            this.ContextMenuFile.Items.AddRange(new ToolStripItem[] {
            this.menuItemSelectUser});
            this.ContextMenuFile.ShowImageMargin = false;
            //
            // ContextMenuView
            //
            this.ContextMenuView.ShowImageMargin = false;
            this.ContextMenuView.Items.AddRange(
            new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClear,
            new ToolStripSeparator(),
            this.menuItemPasswordStatus,
            new ToolStripSeparator(),
            this.menuItemRefreshSelected,
            this.menuItemRefreshAll});
            // 
            // menuItemView
            // 
            this.menuItemView.DropDown = ContextMenuView;
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new(53, 20);
            this.menuItemView.Text = "Widok";
            // 
            // menuItemClear
            // 
            this.menuItemClear.Name = "menuItemClear";
            this.menuItemClear.Size = new(181, 22);
            this.menuItemClear.Text = "Wyczyść";
            this.menuItemClear.Click += new(this.MenuItemClearAll_Click);
            // 
            // menuItemPasswordStatus
            // 
            this.menuItemPasswordStatus.Name = "menuItemPasswordStatus";
            this.menuItemPasswordStatus.Size = new(181, 22);
            this.menuItemPasswordStatus.Text = "Status hasła";
            this.menuItemPasswordStatus.Click += new(this.MenuItemPasswordStatus_Click);
            // 
            // menuItemRefreshSelected
            // 
            this.menuItemRefreshSelected.Name = "menuItemRefreshSelected";
            this.menuItemRefreshSelected.Size = new(181, 22);
            this.menuItemRefreshSelected.Text = "Odśwież zaznaczone";
            this.menuItemRefreshSelected.Click += new(this.MenuItemRefreshSelected_Click);
            // 
            // menuItemRefreshAll
            // 
            this.menuItemRefreshAll.Name = "menuItemRefreshAll";
            this.menuItemRefreshAll.Size = new(181, 22);
            this.menuItemRefreshAll.Text = "Odśwież wszystko";
            this.menuItemRefreshAll.Click += new(this.MenuItemRefreshAll_Click);
            // 
            // contextMenuItemPasswordStatus
            // 
            this.contextMenuItemPasswordStatus.Name = "contextMenuItemPasswordStatus";
            this.contextMenuItemPasswordStatus.Size = new(81, 22);
            this.contextMenuItemPasswordStatus.Text = "Status hasła";
            this.contextMenuItemPasswordStatus.Click += new(this.MenuItemPasswordStatus_Click);
            // 
            // contextMenuItemRefreshSelected
            // 
            this.contextMenuItemRefreshSelected.Name = "contextMenuItemRefreshSelected";
            this.contextMenuItemRefreshSelected.Size = new(181, 22);
            this.contextMenuItemRefreshSelected.Text = "Odśwież zaznaczone";
            this.contextMenuItemRefreshSelected.Click += new(this.MenuItemRefreshSelected_Click);
            // 
            // contextMenuItemRefreshAll
            // 
            this.contextMenuItemRefreshAll.Name = "contextMenuItemRefreshAll";
            this.contextMenuItemRefreshAll.Size = new(181, 22);
            this.contextMenuItemRefreshAll.Text = "Odśwież wszystko";
            this.contextMenuItemRefreshAll.Click += new(this.MenuItemRefreshAll_Click);
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new[] {
            this.DCColumn,
            this.DCSiteName,
            this.UserStateColumn,
            this.BadPasswordCountColumn,
            this.LastBadPasswordAttemptColumn,
            this.LastSetPasswordColumn,
            this.LockoutTimeColumn,
            new DataGridViewTextBoxColumn(){ AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill} });
            dataGridView.ContextMenuStrip = this.ContextMenu;
            dataGridView.GridColor = System.Drawing.SystemColors.Control;
            dataGridView.Location = new(0, 25);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ShowEditingIcon = false;
            dataGridView.Size = new(830, 309);
            dataGridView.TabIndex = 1;
            dataGridView.TabStop = false;
            // 
            // DCColumn
            // 
            this.DCColumn.HeaderText = "Kontroler domeny";
            this.DCColumn.Name = "DCColumn";
            this.DCColumn.ReadOnly = true;
            this.DCColumn.Width = 120;
            // 
            // DCSiteName
            // 
            this.DCSiteName.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader | DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DCSiteName.HeaderText = "Lokacja";
            this.DCSiteName.Name = "DCSiteName";
            this.DCSiteName.ReadOnly = true;
            this.DCSiteName.Width = 120;
            // 
            // UserStateColumn
            // 
            this.UserStateColumn.HeaderText = "Status konta";
            this.UserStateColumn.Name = "UserStateColumn";
            this.UserStateColumn.ReadOnly = true;
            this.UserStateColumn.DefaultCellStyle = new() { Alignment = DataGridViewContentAlignment.MiddleCenter };
            this.UserStateColumn.Width = 95;
            // 
            // BadPasswordCountColumn
            // 
            this.BadPasswordCountColumn.HeaderText = "Ilość błędnych prób";
            this.BadPasswordCountColumn.Name = "BadPasswordCountColumn";
            this.BadPasswordCountColumn.ReadOnly = true;
            this.BadPasswordCountColumn.DefaultCellStyle = new() { Alignment = DataGridViewContentAlignment.MiddleCenter };
            this.BadPasswordCountColumn.Width = 126;
            // 
            // LastBadPasswordAttemptColumn
            // 
            this.LastBadPasswordAttemptColumn.HeaderText = "Ostatnie błędne";
            this.LastBadPasswordAttemptColumn.Name = "LastBadPasswordAttemptColumn";
            this.LastBadPasswordAttemptColumn.ReadOnly = true;
            this.LastBadPasswordAttemptColumn.Width = 121;
            // 
            // LastSetPasswordColumn
            // 
            this.LastSetPasswordColumn.HeaderText = "Ostatnia zmiana";
            this.LastSetPasswordColumn.Name = "LastSetPasswordColumn";
            this.LastSetPasswordColumn.ReadOnly = true;
            this.LastSetPasswordColumn.Width = 121;
            // 
            // LockoutTimeColumn
            // 
            this.LockoutTimeColumn.HeaderText = "Kiedy zablokowane";
            this.LockoutTimeColumn.Name = "LockoutTimeColumn";
            this.LockoutTimeColumn.ReadOnly = true;
            this.LockoutTimeColumn.Width = 122;
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new[] {
            this.contextMenuItemPasswordStatus,
            this.contextMenuItemUnlockAccount,
            this.contextMenuItemCopyValue,
            this.contextMenuItemCopySelectedRow,
            this.contextMenuItemClearAll,
            this.contextMenuItemRefreshSelected,
            this.contextMenuItemRefreshAll});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new(182, 126);
            // 
            // contextMenuItemUnlockAccount
            // 
            this.contextMenuItemUnlockAccount.Name = "contextMenuItemUnlockAccount";
            this.contextMenuItemUnlockAccount.Size = new(181, 22);
            this.contextMenuItemUnlockAccount.Text = "Odblokuj Konto";
            this.contextMenuItemUnlockAccount.Click += new(this.UnlockAll_Click);
            // 
            // contextMenuItemClearAll
            // 
            this.contextMenuItemClearAll.Name = "contextMenuItemClearAll";
            this.contextMenuItemClearAll.Size = new(181, 22);
            this.contextMenuItemClearAll.Text = "Wyczyść";
            this.contextMenuItemClearAll.Click += new(this.MenuItemClearAll_Click);
            // 
            // contextMenuItemCopySelectedRow
            // 
            this.contextMenuItemCopySelectedRow.Name = "contextMenuItemCopySelectedRow";
            this.contextMenuItemCopySelectedRow.Text = "Kopiuj wiersz";
            this.contextMenuItemCopySelectedRow.Click += new(this.CopyValueClick);
            // 
            // contextMenuItemCopyValue
            // 
            this.contextMenuItemCopyValue.Name = "contextMenuItemCopyValue";
            this.contextMenuItemCopyValue.Text = "Kopiuj";
            this.contextMenuItemCopyValue.Click += new(this.CopyValueClick);
            // LockoutStatus
            // 
            this.AutoScaleDimensions = new(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(dataGridView);
            this.Controls.Add(this.mainMenu);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MainMenuStrip = this.mainMenu;
            this.MinimizeBox = false;
            this.ClientSize = new(830, 319);
            this.Name = "LockoutStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lockout Status";
            this.Activated += new(this.LockoutStatus_Activated);
            this.Load += new(this.LockoutStatus_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).EndInit();
            this.ContextMenu.ResumeLayout(false);
            this.ContextMenuFile.ResumeLayout(false);
            this.ContextMenuView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSelectUser;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemClear;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemPasswordStatus;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRefreshSelected;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemRefreshAll;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCopyValue;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCopySelectedRow;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ContextMenuStrip ContextMenuFile;
        private System.Windows.Forms.ContextMenuStrip ContextMenuView;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemUnlockAccount;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemClearAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemPasswordStatus;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefreshSelected;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefreshAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCSiteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserStateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BadPasswordCountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastBadPasswordAttemptColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastSetPasswordColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LockoutTimeColumn;
        private static System.Windows.Forms.DataGridView dataGridView;
    }
}
