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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvironmentVariable));
            this.TextBoxNameVar = new System.Windows.Forms.TextBox();
            this.TextBoxValueVar = new System.Windows.Forms.TextBox();
            this.LabelTitleEnv = new System.Windows.Forms.Label();
            this.LabelNameVar = new System.Windows.Forms.Label();
            this.LabelValueVar = new System.Windows.Forms.Label();
            this.BtnInputVar = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxNameVar
            // 
            this.TextBoxNameVar.Location = new System.Drawing.Point(108, 34);
            this.TextBoxNameVar.Name = "TextBoxNameVar";
            this.TextBoxNameVar.Size = new System.Drawing.Size(184, 20);
            this.TextBoxNameVar.TabIndex = 0;
            // 
            // TextBoxValueVar
            // 
            this.TextBoxValueVar.Location = new System.Drawing.Point(108, 60);
            this.TextBoxValueVar.Name = "TextBoxValueVar";
            this.TextBoxValueVar.Size = new System.Drawing.Size(184, 20);
            this.TextBoxValueVar.TabIndex = 1;
            // 
            // LabelTitleEnv
            // 
            this.LabelTitleEnv.AutoSize = true;
            this.LabelTitleEnv.Location = new System.Drawing.Point(12, 9);
            this.LabelTitleEnv.Name = "LabelTitleEnv";
            this.LabelTitleEnv.Size = new System.Drawing.Size(290, 13);
            this.LabelTitleEnv.TabIndex = 2;
            this.LabelTitleEnv.Text = "Podaj nazwę zmiennej środowiskowej którą chcesz ustawić:";
            // 
            // LabelNameVar
            // 
            this.LabelNameVar.AutoSize = true;
            this.LabelNameVar.Location = new System.Drawing.Point(18, 37);
            this.LabelNameVar.Name = "LabelNameVar";
            this.LabelNameVar.Size = new System.Drawing.Size(90, 13);
            this.LabelNameVar.TabIndex = 3;
            this.LabelNameVar.Text = "Nazwa zmiennej: ";
            // 
            // LabelValueVar
            // 
            this.LabelValueVar.AutoSize = true;
            this.LabelValueVar.Location = new System.Drawing.Point(11, 63);
            this.LabelValueVar.Name = "LabelValueVar";
            this.LabelValueVar.Size = new System.Drawing.Size(97, 13);
            this.LabelValueVar.TabIndex = 4;
            this.LabelValueVar.Text = "Wartość zmiennej: ";
            // 
            // BtnInputVar
            // 
            this.BtnInputVar.Location = new System.Drawing.Point(86, 89);
            this.BtnInputVar.Name = "BtnInputVar";
            this.BtnInputVar.Size = new System.Drawing.Size(75, 23);
            this.BtnInputVar.TabIndex = 5;
            this.BtnInputVar.Text = "Wprowadź";
            this.BtnInputVar.UseVisualStyleBackColor = true;
            this.BtnInputVar.Click += new System.EventHandler(this.BtnInputVar_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(167, 89);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Anuluj";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Environment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 124);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnInputVar);
            this.Controls.Add(this.LabelValueVar);
            this.Controls.Add(this.LabelNameVar);
            this.Controls.Add(this.LabelTitleEnv);
            this.Controls.Add(this.TextBoxValueVar);
            this.Controls.Add(this.TextBoxNameVar);
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(327, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(327, 163);
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