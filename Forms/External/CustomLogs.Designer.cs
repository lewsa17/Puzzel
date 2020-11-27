
namespace Forms
{
    partial class TerminalLogs
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
            this.btnFinder = new System.Windows.Forms.Button();
            textLogView = new System.Windows.Forms.RichTextBox();
            this.panelBox = new System.Windows.Forms.GroupBox();
            this.comboQueryFileBox = new System.Windows.Forms.ComboBox();
            this.labelFile = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelQuery = new System.Windows.Forms.Label();
            this.labelOptions = new System.Windows.Forms.Label();
            this.comboQueryTimeBox = new System.Windows.Forms.ComboBox();
            this.textQuery = new System.Windows.Forms.TextBox();
            this.comboQueryNameBox = new System.Windows.Forms.ComboBox();
            this.panelBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinder
            // 
            this.btnFinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinder.Location = new System.Drawing.Point(795, 41);
            this.btnFinder.Name = "btnFinder";
            this.btnFinder.Size = new System.Drawing.Size(75, 23);
            this.btnFinder.TabIndex = 4;
            this.btnFinder.Text = "Szukaj";
            this.btnFinder.UseVisualStyleBackColor = true;
            this.btnFinder.Click += new System.EventHandler(this.BtnFinderClick);
            // 
            // textLogView
            // 
            textLogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            textLogView.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textLogView.Location = new System.Drawing.Point(6, 70);
            textLogView.Name = "textLogView";
            textLogView.Size = new System.Drawing.Size(864, 270);
            textLogView.TabIndex = 5;
            textLogView.Text = "";
            textLogView.TextChanged += new System.EventHandler(this.TextLogViewChanged);
            // 
            // panelBox
            // 
            this.panelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBox.Controls.Add(this.comboQueryFileBox);
            this.panelBox.Controls.Add(this.labelFile);
            this.panelBox.Controls.Add(this.progressBar);
            this.panelBox.Controls.Add(this.labelTime);
            this.panelBox.Controls.Add(this.labelQuery);
            this.panelBox.Controls.Add(this.labelOptions);
            this.panelBox.Controls.Add(this.comboQueryTimeBox);
            this.panelBox.Controls.Add(this.textQuery);
            this.panelBox.Controls.Add(this.comboQueryNameBox);
            this.panelBox.Controls.Add(textLogView);
            this.panelBox.Controls.Add(this.btnFinder);
            this.panelBox.Location = new System.Drawing.Point(12, 12);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(876, 375);
            this.panelBox.TabIndex = 0;
            this.panelBox.TabStop = false;
            this.panelBox.Text = "Szukaj logów";
            // 
            // comboQueryFileBox
            // 
            this.comboQueryFileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQueryFileBox.FormattingEnabled = true;
            this.comboQueryFileBox.Location = new System.Drawing.Point(500, 41);
            this.comboQueryFileBox.Name = "comboQueryFileBox";
            this.comboQueryFileBox.Size = new System.Drawing.Size(130, 23);
            this.comboQueryFileBox.TabIndex = 2;
            // 
            // labelFile
            // 
            this.labelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(500, 23);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(90, 15);
            this.labelFile.TabIndex = 15;
            this.labelFile.Text = "Z którego pliku:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(6, 343);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(864, 23);
            this.progressBar.TabIndex = 16;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(635, 23);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(96, 15);
            this.labelTime.TabIndex = 17;
            this.labelTime.Text = "Z jakiego okresu:";
            // 
            // labelQuery
            // 
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new System.Drawing.Point(140, 23);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new System.Drawing.Size(150, 15);
            this.labelQuery.TabIndex = 18;
            this.labelQuery.Text = "Podaj czego chcesz szukać:";
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Location = new System.Drawing.Point(6, 23);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(84, 15);
            this.labelOptions.TabIndex = 19;
            this.labelOptions.Text = "Wybierz opcję:";
            // 
            // comboQueryTimeBox
            // 
            this.comboQueryTimeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQueryTimeBox.FormattingEnabled = true;
            this.comboQueryTimeBox.Location = new System.Drawing.Point(636, 41);
            this.comboQueryTimeBox.Name = "comboQueryTimeBox";
            this.comboQueryTimeBox.Size = new System.Drawing.Size(153, 23);
            this.comboQueryTimeBox.TabIndex = 3;
            // 
            // textQuery
            // 
            this.textQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textQuery.Location = new System.Drawing.Point(140, 41);
            this.textQuery.Name = "textQuery";
            this.textQuery.Size = new System.Drawing.Size(354, 23);
            this.textQuery.TabIndex = 1;
            // 
            // comboQueryNameBox
            // 
            this.comboQueryNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboQueryNameBox.FormattingEnabled = true;
            this.comboQueryNameBox.Items.AddRange(new object[] {
            "Nazwa użytkownika",
            "Nazwa urządzenia",
            "Numer seryjny"});
            this.comboQueryNameBox.Location = new System.Drawing.Point(6, 41);
            this.comboQueryNameBox.Name = "comboQueryNameBox";
            this.comboQueryNameBox.Size = new System.Drawing.Size(128, 23);
            this.comboQueryNameBox.TabIndex = 0;
            // 
            // TerminalLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 390);
            this.Controls.Add(this.panelBox);
            this.MinimumSize = new System.Drawing.Size(916, 429);
            this.Name = "TerminalLogs";
            this.Text = "TerminalLogs";
            this.panelBox.ResumeLayout(false);
            this.panelBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFinder;
        private System.Windows.Forms.GroupBox panelBox;
        private System.Windows.Forms.ComboBox comboQueryNameBox;
        private System.Windows.Forms.TextBox textQuery;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelQuery;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.ComboBox comboQueryTimeBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox comboQueryFileBox;
        private System.Windows.Forms.Label labelFile;
        private static System.Windows.Forms.RichTextBox textLogView;
    }
}
