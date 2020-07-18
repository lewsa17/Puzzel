namespace Forms.Additional
{
    partial class SearchingMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchingMainForm));
            this.labelSearchedText = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxSearchedText = new System.Windows.Forms.TextBox();
            this.btnPreviousWord = new System.Windows.Forms.Button();
            this.btnNextWord = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabFind = new System.Windows.Forms.TabPage();
            this.DualDirectionbox = new System.Windows.Forms.CheckBox();
            this.TabChange = new System.Windows.Forms.TabPage();
            this.labelChangeWord = new System.Windows.Forms.Label();
            this.textboxChangeWord = new System.Windows.Forms.TextBox();
            this.labelSearchedText1 = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.textboxReplaceWord = new System.Windows.Forms.TextBox();
            this.TabControl.SuspendLayout();
            this.TabFind.SuspendLayout();
            this.TabChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearchedText
            // 
            this.labelSearchedText.AutoSize = true;
            this.labelSearchedText.Location = new System.Drawing.Point(6, 12);
            this.labelSearchedText.Name = "labelSearchedText";
            this.labelSearchedText.Size = new System.Drawing.Size(74, 13);
            this.labelSearchedText.TabIndex = 0;
            this.labelSearchedText.Text = "Szukany tekst";
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new System.Drawing.Point(8, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(314, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Wyszukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // textBoxSearchedText
            // 
            this.textBoxSearchedText.Location = new System.Drawing.Point(9, 28);
            this.textBoxSearchedText.Name = "textBoxSearchedText";
            this.textBoxSearchedText.Size = new System.Drawing.Size(313, 20);
            this.textBoxSearchedText.TabIndex = 1;
            this.textBoxSearchedText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // btnPreviousWord
            // 
            this.btnPreviousWord.Location = new System.Drawing.Point(8, 83);
            this.btnPreviousWord.Name = "btnPreviousWord";
            this.btnPreviousWord.Size = new System.Drawing.Size(155, 23);
            this.btnPreviousWord.TabIndex = 3;
            this.btnPreviousWord.Text = "<= Poprzednie";
            this.btnPreviousWord.UseVisualStyleBackColor = true;
            this.btnPreviousWord.Visible = false;
            this.btnPreviousWord.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // btnNextWord
            // 
            this.btnNextWord.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnNextWord.Location = new System.Drawing.Point(166, 83);
            this.btnNextWord.Name = "btnNextWord";
            this.btnNextWord.Size = new System.Drawing.Size(155, 23);
            this.btnNextWord.TabIndex = 4;
            this.btnNextWord.Text = "Następne =>";
            this.btnNextWord.UseVisualStyleBackColor = true;
            this.btnNextWord.Visible = false;
            this.btnNextWord.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabFind);
            this.TabControl.Controls.Add(this.TabChange);
            this.TabControl.Location = new System.Drawing.Point(1, 4);
            this.TabControl.Name = "Wyszukiwarka";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(341, 154);
            this.TabControl.TabIndex = 5;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_Click);
            // 
            // TabFind
            // 
            this.TabFind.Controls.Add(this.DualDirectionbox);
            this.TabFind.Controls.Add(this.textBoxSearchedText);
            this.TabFind.Controls.Add(this.labelSearchedText);
            this.TabFind.Controls.Add(this.btnNextWord);
            this.TabFind.Controls.Add(this.btnSearch);
            this.TabFind.Controls.Add(this.btnPreviousWord);
            this.TabFind.Location = new System.Drawing.Point(4, 22);
            this.TabFind.Name = "TabFind";
            this.TabFind.Padding = new System.Windows.Forms.Padding(3);
            this.TabFind.Size = new System.Drawing.Size(333, 128);
            this.TabFind.TabIndex = 0;
            this.TabFind.Text = "Szukaj";
            this.TabFind.UseVisualStyleBackColor = true;
            // 
            // DualDirectionbox
            // 
            this.DualDirectionbox.AutoSize = true;
            this.DualDirectionbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DualDirectionbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DualDirectionbox.Location = new System.Drawing.Point(176, 6);
            this.DualDirectionbox.Name = "DualDirectionbox";
            this.DualDirectionbox.Size = new System.Drawing.Size(145, 17);
            this.DualDirectionbox.TabIndex = 5;
            this.DualDirectionbox.Text = "Szukanie dwukierunkowe";
            this.DualDirectionbox.UseVisualStyleBackColor = true;
            this.DualDirectionbox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // TabChange
            // 
            this.TabChange.Controls.Add(this.labelChangeWord);
            this.TabChange.Controls.Add(this.textboxChangeWord);
            this.TabChange.Controls.Add(this.labelSearchedText1);
            this.TabChange.Controls.Add(this.btnReplace);
            this.TabChange.Controls.Add(this.textboxReplaceWord);
            this.TabChange.Location = new System.Drawing.Point(4, 22);
            this.TabChange.Name = "TabChange";
            this.TabChange.Padding = new System.Windows.Forms.Padding(3);
            this.TabChange.Size = new System.Drawing.Size(333, 128);
            this.TabChange.TabIndex = 1;
            this.TabChange.Text = "Zamień";
            this.TabChange.UseVisualStyleBackColor = true;
            // 
            // labelChangeWord
            // 
            this.labelChangeWord.AutoSize = true;
            this.labelChangeWord.Location = new System.Drawing.Point(6, 57);
            this.labelChangeWord.Name = "labelChangeWord";
            this.labelChangeWord.Size = new System.Drawing.Size(60, 13);
            this.labelChangeWord.TabIndex = 6;
            this.labelChangeWord.Text = "Zamień na:";
            // 
            // textboxChangeWord
            // 
            this.textboxChangeWord.Location = new System.Drawing.Point(9, 73);
            this.textboxChangeWord.Name = "textboxChangeWord";
            this.textboxChangeWord.Size = new System.Drawing.Size(318, 20);
            this.textboxChangeWord.TabIndex = 1;
            // 
            // labelSearchedText1
            // 
            this.labelSearchedText1.AutoSize = true;
            this.labelSearchedText1.Location = new System.Drawing.Point(6, 12);
            this.labelSearchedText1.Name = "labelSearchedText1";
            this.labelSearchedText1.Size = new System.Drawing.Size(77, 13);
            this.labelSearchedText1.TabIndex = 7;
            this.labelSearchedText1.Text = "Szukany tekst:";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new System.Drawing.Point(9, 99);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(318, 23);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Zamień";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // textboxReplaceWord
            // 
            this.textboxReplaceWord.Location = new System.Drawing.Point(9, 28);
            this.textboxReplaceWord.Name = "textboxReplaceWord";
            this.textboxReplaceWord.Size = new System.Drawing.Size(318, 20);
            this.textboxReplaceWord.TabIndex = 0;
            // 
            // SearchingMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 161);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 200);
            this.Name = "SearchingMainForm";
            this.Text = "Szukaj";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchingMainForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchingMainForm_Load);
            this.TabControl.ResumeLayout(false);
            this.TabFind.ResumeLayout(false);
            this.TabFind.PerformLayout();
            this.TabChange.ResumeLayout(false);
            this.TabChange.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSearchedText;
        private System.Windows.Forms.TextBox textBoxSearchedText;
        private System.Windows.Forms.Button btnPreviousWord;
        private System.Windows.Forms.Button btnNextWord;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabFind;
        private System.Windows.Forms.TabPage TabChange;
        private System.Windows.Forms.Label labelSearchedText1;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.TextBox textboxReplaceWord;
        private System.Windows.Forms.Label labelChangeWord;
        private System.Windows.Forms.TextBox textboxChangeWord;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox DualDirectionbox;
    }
}
