namespace Settings
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DescriptionBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.DescriptionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(632, 415);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(713, 415);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Zamknij";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.GeneralPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "TabSettings";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 406);
            this.tabControl1.TabIndex = 2;
            // 
            // GeneralPage
            // 
            this.GeneralPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPage.Size = new System.Drawing.Size(768, 378);
            this.GeneralPage.TabIndex = 0;
            this.GeneralPage.Text = "Ogólne";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "Other";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inne";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptionBox.Controls.Add(this.label1);
            this.DescriptionBox.Location = new System.Drawing.Point(19, 303);
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(762, 100);
            this.DescriptionBox.TabIndex = 3;
            this.DescriptionBox.TabStop = false;
            this.DescriptionBox.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Najedź kursorem na opcję aby wyświetlić tutaj opis";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "Ustawienia";
            this.tabControl1.ResumeLayout(false);
            this.DescriptionBox.ResumeLayout(false);
            this.DescriptionBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.GroupBox DescriptionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

