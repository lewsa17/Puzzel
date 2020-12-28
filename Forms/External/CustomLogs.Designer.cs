
namespace Forms
{
    partial class CustomLogs
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
            this.btnFinder = new();
            textLogView = new();
            this.panelBox = new();
            this.comboQueryFileBox = new();
            this.labelFile = new();
            this.progressBar = new();
            this.labelTime = new();
            this.labelQuery = new();
            this.labelOptions = new();
            this.comboQueryTimeBox = new();
            this.textQuery = new();
            this.comboQueryNameBox = new();
            this.panelBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinder
            // 
            this.btnFinder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinder.Location = new(795, 41);
            this.btnFinder.Name = "btnFinder";
            this.btnFinder.Size = new(75, 23);
            this.btnFinder.TabIndex = 4;
            this.btnFinder.Text = "Szukaj";
            this.btnFinder.UseVisualStyleBackColor = true;
            this.btnFinder.Click += new(this.BtnFinderClick);
            // 
            // textLogView
            // 
            textLogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            textLogView.Font = new("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textLogView.Location = new(6, 70);
            textLogView.Name = "textLogView";
            textLogView.Size = new(864, 270);
            textLogView.TabIndex = 5;
            textLogView.Text = "";
            textLogView.TextChanged += new(this.TextLogViewChanged);
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
            this.panelBox.Location = new(12, 12);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new(876, 375);
            this.panelBox.TabIndex = 0;
            this.panelBox.TabStop = false;
            this.panelBox.Text = "Szukaj logów";
            // 
            // comboQueryFileBox
            // 
            this.comboQueryFileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQueryFileBox.FormattingEnabled = true;
            this.comboQueryFileBox.Location = new(500, 41);
            this.comboQueryFileBox.Name = "comboQueryFileBox";
            this.comboQueryFileBox.Size = new(130, 23);
            this.comboQueryFileBox.TabIndex = 2;
            // 
            // labelFile
            // 
            this.labelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new(500, 23);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new(90, 15);
            this.labelFile.TabIndex = 15;
            this.labelFile.Text = "Z którego pliku:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new(6, 343);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new(864, 23);
            this.progressBar.TabIndex = 16;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new(635, 23);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new(96, 15);
            this.labelTime.TabIndex = 17;
            this.labelTime.Text = "Z jakiego okresu:";
            // 
            // labelQuery
            // 
            this.labelQuery.AutoSize = true;
            this.labelQuery.Location = new(140, 23);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new(150, 15);
            this.labelQuery.TabIndex = 18;
            this.labelQuery.Text = "Podaj czego chcesz szukać:";
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Location = new(6, 23);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new(84, 15);
            this.labelOptions.TabIndex = 19;
            this.labelOptions.Text = "Wybierz opcję:";
            // 
            // comboQueryTimeBox
            // 
            this.comboQueryTimeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboQueryTimeBox.FormattingEnabled = true;
            this.comboQueryTimeBox.Location = new(636, 41);
            this.comboQueryTimeBox.Name = "comboQueryTimeBox";
            this.comboQueryTimeBox.Size = new(153, 23);
            this.comboQueryTimeBox.TabIndex = 3;
            // 
            // textQuery
            // 
            this.textQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textQuery.Location = new(140, 41);
            this.textQuery.Name = "textQuery";
            this.textQuery.Size = new(354, 23);
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
            this.comboQueryNameBox.Location = new(6, 41);
            this.comboQueryNameBox.Name = "comboQueryNameBox";
            this.comboQueryNameBox.Size = new(128, 2);
            this.comboQueryNameBox.TabIndex = 0;
            // 
            // CustomLogs
            // 
            this.AutoScaleDimensions = new(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(900, 390);
            this.Controls.Add(this.panelBox);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MinimumSize = new(916, 429);
            this.Name = "CustomLogs";
            this.Text = "Niestandardowe logi";
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
