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
            this.labelSearchedText = new();
            this.btnSearch = new();
            this.textBoxSearchedText = new();
            this.btnPreviousWord = new ();
            this.btnNextWord = new();
            this.TabControl = new();
            this.TabFind = new();
            this.DualDirectionbox = new();
            this.TabChange = new();
            this.labelChangeWord = new();
            this.textboxChangeWord = new();
            this.labelSearchedText1 = new();
            this.btnReplace = new();
            this.textboxReplaceWord = new();
            this.TabControl.SuspendLayout();
            this.TabFind.SuspendLayout();
            this.TabChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearchedText
            // 
            this.labelSearchedText.AutoSize = true;
            this.labelSearchedText.Location = new(6, 12);
            this.labelSearchedText.Name = "labelSearchedText";
            this.labelSearchedText.Size = new(74, 13);
            this.labelSearchedText.Text = "Szukany tekst";
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new(8, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new(314, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Wyszukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new(this.Buttons_Click);
            // 
            // textBoxSearchedText
            // 
            this.textBoxSearchedText.Location = new(9, 28);
            this.textBoxSearchedText.Name = "textBoxSearchedText";
            this.textBoxSearchedText.Size = new(313, 20);
            this.textBoxSearchedText.TabIndex = 0;
            this.textBoxSearchedText.KeyDown += new(this.TextBox_KeyDown);
            // 
            // btnPreviousWord
            // 
            this.btnPreviousWord.Location = new(8, 83);
            this.btnPreviousWord.Name = "btnPreviousWord";
            this.btnPreviousWord.Size = new(155, 23);
            this.btnPreviousWord.TabIndex = 2;
            this.btnPreviousWord.Text = "<= Poprzednie";
            this.btnPreviousWord.UseVisualStyleBackColor = true;
            this.btnPreviousWord.Visible = false;
            this.btnPreviousWord.Click += new(this.Buttons_Click);
            // 
            // btnNextWord
            // 
            this.btnNextWord.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnNextWord.Location = new(166, 83);
            this.btnNextWord.Name = "btnNextWord";
            this.btnNextWord.Size = new(155, 23);
            this.btnNextWord.TabIndex = 3;
            this.btnNextWord.Text = "Następne =>";
            this.btnNextWord.UseVisualStyleBackColor = true;
            this.btnNextWord.Visible = false;
            this.btnNextWord.Click += new(this.Buttons_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabFind);
            this.TabControl.Controls.Add(this.TabChange);
            this.TabControl.Location = new(1, 4);
            this.TabControl.Name = "Wyszukiwarka";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new(341, 154);
            this.TabControl.TabStop = false;
            this.TabControl.SelectedIndexChanged += new(this.TabControl_Click);
            // 
            // TabFind
            // 
            this.TabFind.Controls.Add(this.DualDirectionbox);
            this.TabFind.Controls.Add(this.textBoxSearchedText);
            this.TabFind.Controls.Add(this.labelSearchedText);
            this.TabFind.Controls.Add(this.btnNextWord);
            this.TabFind.Controls.Add(this.btnSearch);
            this.TabFind.Controls.Add(this.btnPreviousWord);
            this.TabFind.Location = new(4, 22);
            this.TabFind.Name = "TabFind";
            this.TabFind.Padding = new System.Windows.Forms.Padding(3);
            this.TabFind.Size = new(333, 128);
            this.TabFind.Text = "Szukaj";
            this.TabFind.UseVisualStyleBackColor = true;
            // 
            // DualDirectionbox
            // 
            this.DualDirectionbox.AutoSize = true;
            this.DualDirectionbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DualDirectionbox.Font = new("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DualDirectionbox.Location = new(176, 6);
            this.DualDirectionbox.Name = "DualDirectionbox";
            this.DualDirectionbox.Size = new(145, 17);
            this.DualDirectionbox.TabIndex = 5;
            this.DualDirectionbox.Text = "Szukanie dwukierunkowe";
            this.DualDirectionbox.UseVisualStyleBackColor = true;
            this.DualDirectionbox.CheckedChanged += new(this.CheckBox_CheckedChanged);
            // 
            // TabChange
            // 
            this.TabChange.Controls.Add(this.labelChangeWord);
            this.TabChange.Controls.Add(this.textboxChangeWord);
            this.TabChange.Controls.Add(this.labelSearchedText1);
            this.TabChange.Controls.Add(this.btnReplace);
            this.TabChange.Controls.Add(this.textboxReplaceWord);
            this.TabChange.Location = new(4, 22);
            this.TabChange.Name = "TabChange";
            this.TabChange.Padding = new(3);
            this.TabChange.Size = new(333, 128);
            this.TabChange.Text = "Zamień";
            this.TabChange.UseVisualStyleBackColor = true;
            // 
            // labelChangeWord
            // 
            this.labelChangeWord.AutoSize = true;
            this.labelChangeWord.Location = new(6, 57);
            this.labelChangeWord.Name = "labelChangeWord";
            this.labelChangeWord.Size = new(60, 13);
            this.labelChangeWord.Text = "Zamień na:";
            // 
            // textboxChangeWord
            // 
            this.textboxChangeWord.Location = new(9, 73);
            this.textboxChangeWord.Name = "textboxChangeWord";
            this.textboxChangeWord.Size = new(318, 20);
            this.textboxChangeWord.TabIndex = 1;
            // 
            // labelSearchedText1
            // 
            this.labelSearchedText1.AutoSize = true;
            this.labelSearchedText1.Location = new(6, 12);
            this.labelSearchedText1.Name = "labelSearchedText1";
            this.labelSearchedText1.Size = new(77, 13);
            this.labelSearchedText1.Text = "Szukany tekst:";
            // 
            // btnReplace
            // 
            this.btnReplace.Location = new(9, 99);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new(318, 23);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Zamień";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new(this.Buttons_Click);
            // 
            // textboxReplaceWord
            // 
            this.textboxReplaceWord.Location = new(9, 28);
            this.textboxReplaceWord.Name = "textboxReplaceWord";
            this.textboxReplaceWord.Size = new(318, 20);
            this.textboxReplaceWord.TabIndex = 0;
            // 
            // SearchingMainForm
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(344, 161);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(360, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new(340, 200);
            this.Name = "SearchingMainForm";
            this.Text = "Szukaj";
            this.TopMost = true;
            this.FormClosing += new(this.SearchingMainForm_FormClosing);
            this.Load += new(this.SearchingMainForm_Load);
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
