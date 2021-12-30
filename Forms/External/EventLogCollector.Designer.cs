namespace Forms.External
{
    partial class EventLogCollector
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
            this.StartDateRangePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateRangePicker = new System.Windows.Forms.DateTimePicker();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.FindButton = new System.Windows.Forms.Button();
            this.PanelBox = new System.Windows.Forms.GroupBox();
            this.LogCounterLabel = new System.Windows.Forms.Label();
            this.LogCounter = new System.Windows.Forms.NumericUpDown();
            this.LocationText = new System.Windows.Forms.ComboBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.TextLogView = new System.Windows.Forms.RichTextBox();
            this.TableLogView = new System.Windows.Forms.DataGridView();
            this.PanelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLogView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartDateRangePicker
            // 
            this.StartDateRangePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StartDateRangePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.StartDateRangePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDateRangePicker.Location = new System.Drawing.Point(163, 52);
            this.StartDateRangePicker.MaxDate = new System.DateTime(2030, 12, 31, 23, 59, 59, 0);
            this.StartDateRangePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.StartDateRangePicker.Name = "StartDateRangePicker";
            this.StartDateRangePicker.Size = new System.Drawing.Size(200, 23);
            this.StartDateRangePicker.TabIndex = 2;
            this.StartDateRangePicker.ValueChanged += new System.EventHandler(this.ChangedValue);
            // 
            // EndDateRangePicker
            // 
            this.EndDateRangePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EndDateRangePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.EndDateRangePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDateRangePicker.Location = new System.Drawing.Point(369, 52);
            this.EndDateRangePicker.MaxDate = new System.DateTime(2031, 1, 1, 0, 0, 0, 0);
            this.EndDateRangePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.EndDateRangePicker.Name = "EndDateRangePicker";
            this.EndDateRangePicker.Size = new System.Drawing.Size(200, 23);
            this.EndDateRangePicker.TabIndex = 3;
            this.EndDateRangePicker.ValueChanged += new System.EventHandler(this.ChangedValue);
            // 
            // FromLabel
            // 
            this.FromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(163, 34);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(26, 15);
            this.FromLabel.TabIndex = 6;
            this.FromLabel.Text = "Od:";
            // 
            // ToLabel
            // 
            this.ToLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(372, 34);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(25, 15);
            this.ToLabel.TabIndex = 7;
            this.ToLabel.Text = "Do:";
            // 
            // FindButton
            // 
            this.FindButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FindButton.Location = new System.Drawing.Point(645, 52);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Wyszukaj";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // PanelBox
            // 
            this.PanelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBox.Controls.Add(this.LogCounterLabel);
            this.PanelBox.Controls.Add(this.LogCounter);
            this.PanelBox.Controls.Add(this.LocationText);
            this.PanelBox.Controls.Add(this.LocationLabel);
            this.PanelBox.Controls.Add(this.FromLabel);
            this.PanelBox.Controls.Add(this.FindButton);
            this.PanelBox.Controls.Add(this.StartDateRangePicker);
            this.PanelBox.Controls.Add(this.EndDateRangePicker);
            this.PanelBox.Controls.Add(this.ToLabel);
            this.PanelBox.Location = new System.Drawing.Point(3, 12);
            this.PanelBox.Name = "PanelBox";
            this.PanelBox.Size = new System.Drawing.Size(753, 91);
            this.PanelBox.TabIndex = 5;
            this.PanelBox.TabStop = false;
            this.PanelBox.Text = "Wyszukiwanie złych prób logowania";
            // 
            // LogCounterLabel
            // 
            this.LogCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LogCounterLabel.AutoSize = true;
            this.LogCounterLabel.Location = new System.Drawing.Point(579, 34);
            this.LogCounterLabel.Name = "LogCounterLabel";
            this.LogCounterLabel.Size = new System.Drawing.Size(34, 15);
            this.LogCounterLabel.TabIndex = 9;
            this.LogCounterLabel.Text = "Ilość:";
            // 
            // LogCounter
            // 
            this.LogCounter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LogCounter.Location = new System.Drawing.Point(576, 51);
            this.LogCounter.Name = "LogCounter";
            this.LogCounter.Size = new System.Drawing.Size(63, 23);
            this.LogCounter.TabIndex = 8;
            // 
            // LocationText
            // 
            this.LocationText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LocationText.Location = new System.Drawing.Point(6, 52);
            this.LocationText.Name = "LocationText";
            this.LocationText.Size = new System.Drawing.Size(151, 23);
            this.LocationText.TabIndex = 1;
            // 
            // LocationLabel
            // 
            this.LocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(6, 34);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(125, 15);
            this.LocationLabel.TabIndex = 5;
            this.LocationLabel.Text = "Miejsce wyszukiwania:";
            // 
            // TextLogView
            // 
            this.TextLogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextLogView.AutoWordSelection = true;
            this.TextLogView.Location = new System.Drawing.Point(3, 110);
            this.TextLogView.Name = "TextLogView";
            this.TextLogView.ShortcutsEnabled = false;
            this.TextLogView.Size = new System.Drawing.Size(754, 328);
            this.TextLogView.TabIndex = 6;
            this.TextLogView.Text = "";
            this.TextLogView.Visible = !PuzzelLibrary.Settings.Values.EventLogTableView;
            this.TextLogView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchData);
            // 
            // TableLogView
            // 
            this.TableLogView.AllowUserToAddRows = false;
            this.TableLogView.AllowUserToDeleteRows = false;
            this.TableLogView.AllowUserToResizeColumns = false;
            this.TableLogView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.TableLogView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TableLogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLogView.BackgroundColor = System.Drawing.Color.White;
            this.TableLogView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.TableLogView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TableLogView.Location = new System.Drawing.Point(3, 110);
            this.TableLogView.MultiSelect = false;
            this.TableLogView.Name = "TableLogView";
            this.TableLogView.ReadOnly = true;
            this.TableLogView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.TableLogView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TableLogView.Size = new System.Drawing.Size(754, 328);
            this.TableLogView.TabIndex = 0;
            this.TableLogView.Visible = PuzzelLibrary.Settings.Values.EventLogTableView;
            this.TableLogView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchData);
            // 
            // EventLogCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.PanelBox);
            this.Controls.Add(this.TextLogView);
            this.Controls.Add(this.TableLogView);
            this.MinimumSize = new System.Drawing.Size(760, 450);
            this.Name = "EventLogCollector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zbieracz zdarzeń";
            this.PanelBox.ResumeLayout(false);
            this.PanelBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableLogView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDateRangePicker;
        private System.Windows.Forms.DateTimePicker EndDateRangePicker;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.GroupBox PanelBox;
        private System.Windows.Forms.ComboBox LocationText;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.RichTextBox TextLogView;
        private System.Windows.Forms.Label LogCounterLabel;
        private System.Windows.Forms.NumericUpDown LogCounter;
        private System.Windows.Forms.DataGridView TableLogView;
    }
}