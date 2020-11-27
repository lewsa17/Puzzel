namespace Forms.External.QuickFix
{
    partial class EnvironmentVariable
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
            System.ComponentModel.ComponentResourceManager resources = new(typeof(EnvironmentVariable));
            this.TextBoxNameVar = new();
            this.TextBoxValueVar = new();
            this.LabelTitleEnv = new();
            this.LabelNameVar = new();
            this.LabelValueVar = new();
            this.BtnInputVar = new();
            this.BtnCancel = new();
            this.SuspendLayout();
            // 
            // TextBoxNameVar
            // 
            this.TextBoxNameVar.Location = new(108, 34);
            this.TextBoxNameVar.Name = "TextBoxNameVar";
            this.TextBoxNameVar.Size = new(184, 20);
            this.TextBoxNameVar.TabIndex = 0;
            // 
            // TextBoxValueVar
            // 
            this.TextBoxValueVar.Location = new(108, 60);
            this.TextBoxValueVar.Name = "TextBoxValueVar";
            this.TextBoxValueVar.Size = new(184, 20);
            this.TextBoxValueVar.TabIndex = 1;
            // 
            // LabelTitleEnv
            // 
            this.LabelTitleEnv.AutoSize = true;
            this.LabelTitleEnv.Location = new(12, 9);
            this.LabelTitleEnv.Name = "LabelTitleEnv";
            this.LabelTitleEnv.Size = new(290, 13);
            this.LabelTitleEnv.TabIndex = 2;
            this.LabelTitleEnv.Text = "Podaj nazwę zmiennej środowiskowej którą chcesz ustawić:";
            // 
            // LabelNameVar
            // 
            this.LabelNameVar.AutoSize = true;
            this.LabelNameVar.Location = new(18, 37);
            this.LabelNameVar.Name = "LabelNameVar";
            this.LabelNameVar.Size = new(90, 13);
            this.LabelNameVar.TabIndex = 3;
            this.LabelNameVar.Text = "Nazwa zmiennej: ";
            // 
            // LabelValueVar
            // 
            this.LabelValueVar.AutoSize = true;
            this.LabelValueVar.Location = new(11, 63);
            this.LabelValueVar.Name = "LabelValueVar";
            this.LabelValueVar.Size = new(97, 13);
            this.LabelValueVar.TabIndex = 4;
            this.LabelValueVar.Text = "Wartość zmiennej: ";
            // 
            // BtnInputVar
            // 
            this.BtnInputVar.Location = new(86, 89);
            this.BtnInputVar.Name = "BtnInputVar";
            this.BtnInputVar.Size = new(75, 23);
            this.BtnInputVar.TabIndex = 5;
            this.BtnInputVar.Text = "Wprowadź";
            this.BtnInputVar.UseVisualStyleBackColor = true;
            this.BtnInputVar.Click += new(this.BtnInputVar_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new(167, 89);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Anuluj";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new(this.BtnCancel_Click);
            // 
            // Environment
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(311, 124);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnInputVar);
            this.Controls.Add(this.LabelValueVar);
            this.Controls.Add(this.LabelNameVar);
            this.Controls.Add(this.LabelTitleEnv);
            this.Controls.Add(this.TextBoxValueVar);
            this.Controls.Add(this.TextBoxNameVar);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(327, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new(327, 163);
            this.Name = "Environment";
            this.Text = "Zmienna środowiskowa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxNameVar;
        private System.Windows.Forms.TextBox TextBoxValueVar;
        private System.Windows.Forms.Label LabelTitleEnv;
        private System.Windows.Forms.Label LabelNameVar;
        private System.Windows.Forms.Label LabelValueVar;
        private System.Windows.Forms.Button BtnInputVar;
        private System.Windows.Forms.Button BtnCancel;
    }
}