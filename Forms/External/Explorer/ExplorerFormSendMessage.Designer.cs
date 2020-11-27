namespace Forms.External.Explorer
{
    partial class ExplorerFormSendMessage
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
            System.ComponentModel.ComponentResourceManager resources = new(typeof(ExplorerFormSendMessage));
            richTextBoxContents = new();
            this.btnSendMessage = new();
            this.labelTitle = new();
            this.textBoxTitleValue = new();
            this.labelContents = new();
            this.SuspendLayout();
            // 
            // richTextBoxContents
            // 
            richTextBoxContents.Location = new(12, 67);
            richTextBoxContents.Name = "richTextBoxContents";
            richTextBoxContents.Size = new(342, 165);
            richTextBoxContents.TabIndex = 0;
            richTextBoxContents.Text = "";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new(113, 238);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new(101, 23);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Wyślij wiadomość";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new(this.SendMessage);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new(14, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new(88, 13);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Podaj tytuł okna:";
            // 
            // textBoxTitleValue
            // 
            this.textBoxTitleValue.Location = new(115, 12);
            this.textBoxTitleValue.Name = "textBoxTitleValue";
            this.textBoxTitleValue.Size = new(241, 20);
            this.textBoxTitleValue.TabIndex = 3;
            // 
            // labelContents
            // 
            this.labelContents.AutoSize = true;
            this.labelContents.Location = new(14, 51);
            this.labelContents.Name = "labelContents";
            this.labelContents.Size = new(37, 13);
            this.labelContents.TabIndex = 4;
            this.labelContents.Text = "Treść:";
            // 
            // ExplorerFormSendMessage
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(368, 273);
            this.Controls.Add(this.labelContents);
            this.Controls.Add(this.textBoxTitleValue);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(richTextBoxContents);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(376, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new(376, 300);
            this.Name = "ExplorerFormSendMessage";
            this.Text = "Wiadomość do użytkownika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxContents;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitleValue;
        private System.Windows.Forms.Label labelContents;
    }
}