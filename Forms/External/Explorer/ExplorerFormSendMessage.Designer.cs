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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerFormSendMessage));
            richTextBoxContents = new System.Windows.Forms.RichTextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitleValue = new System.Windows.Forms.TextBox();
            this.labelContents = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxContents
            // 
            richTextBoxContents.Location = new System.Drawing.Point(12, 67);
            richTextBoxContents.Name = "richTextBoxContents";
            richTextBoxContents.Size = new System.Drawing.Size(342, 165);
            richTextBoxContents.TabIndex = 0;
            richTextBoxContents.Text = "";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(113, 238);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(101, 23);
            this.btnSendMessage.TabIndex = 1;
            this.btnSendMessage.Text = "Wyślij wiadomość";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.SendMessage);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(14, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(88, 13);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Podaj tytuł okna:";
            // 
            // textBoxTitleValue
            // 
            this.textBoxTitleValue.Location = new System.Drawing.Point(115, 12);
            this.textBoxTitleValue.Name = "textBoxTitleValue";
            this.textBoxTitleValue.Size = new System.Drawing.Size(241, 20);
            this.textBoxTitleValue.TabIndex = 3;
            // 
            // labelContents
            // 
            this.labelContents.AutoSize = true;
            this.labelContents.Location = new System.Drawing.Point(14, 51);
            this.labelContents.Name = "labelContents";
            this.labelContents.Size = new System.Drawing.Size(37, 13);
            this.labelContents.TabIndex = 4;
            this.labelContents.Text = "Treść:";
            // 
            // ExplorerFormSendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 273);
            this.Controls.Add(this.labelContents);
            this.Controls.Add(this.textBoxTitleValue);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(richTextBoxContents);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(376, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(376, 300);
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