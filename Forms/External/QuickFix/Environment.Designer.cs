namespace Forms.External.QuickFix
{
    partial class Environment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Environment));
            this.textNameOfVariable = new System.Windows.Forms.TextBox();
            this.textValueOfVariable = new System.Windows.Forms.TextBox();
            this.labelInputNameOfVariable = new System.Windows.Forms.Label();
            this.labelNameOfVariable = new System.Windows.Forms.Label();
            this.labelValueOfVariable = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textNameOfVariable
            // 
            this.textNameOfVariable.Location = new System.Drawing.Point(108, 34);
            this.textNameOfVariable.Name = "textNameOfVariable";
            this.textNameOfVariable.Size = new System.Drawing.Size(184, 20);
            this.textNameOfVariable.TabIndex = 0;
            // 
            // textValueOfVariable
            // 
            this.textValueOfVariable.Location = new System.Drawing.Point(108, 60);
            this.textValueOfVariable.Name = "textValueOfVariable";
            this.textValueOfVariable.Size = new System.Drawing.Size(184, 20);
            this.textValueOfVariable.TabIndex = 1;
            // 
            // labelInputNameOfVariable
            // 
            this.labelInputNameOfVariable.AutoSize = true;
            this.labelInputNameOfVariable.Location = new System.Drawing.Point(12, 9);
            this.labelInputNameOfVariable.Name = "labelInputNameOfVariable";
            this.labelInputNameOfVariable.Size = new System.Drawing.Size(290, 13);
            this.labelInputNameOfVariable.TabIndex = 2;
            this.labelInputNameOfVariable.Text = "Podaj nazwę zmiennej środowiskowej którą chcesz ustawić:";
            // 
            // labelNameOfVariable
            // 
            this.labelNameOfVariable.AutoSize = true;
            this.labelNameOfVariable.Location = new System.Drawing.Point(18, 37);
            this.labelNameOfVariable.Name = "labelNameOfVariable";
            this.labelNameOfVariable.Size = new System.Drawing.Size(90, 13);
            this.labelNameOfVariable.TabIndex = 3;
            this.labelNameOfVariable.Text = "Nazwa zmiennej: ";
            // 
            // labelValueOfVariable
            // 
            this.labelValueOfVariable.AutoSize = true;
            this.labelValueOfVariable.Location = new System.Drawing.Point(11, 63);
            this.labelValueOfVariable.Name = "labelValueOfVariable";
            this.labelValueOfVariable.Size = new System.Drawing.Size(97, 13);
            this.labelValueOfVariable.TabIndex = 4;
            this.labelValueOfVariable.Text = "Wartość zmiennej: ";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(86, 89);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 5;
            this.btnInput.Text = "Wprowadź";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // Environment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.labelValueOfVariable);
            this.Controls.Add(this.labelNameOfVariable);
            this.Controls.Add(this.labelInputNameOfVariable);
            this.Controls.Add(this.textValueOfVariable);
            this.Controls.Add(this.textNameOfVariable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.TextBox textNameOfVariable;
        private System.Windows.Forms.TextBox textValueOfVariable;
        private System.Windows.Forms.Label labelInputNameOfVariable;
        private System.Windows.Forms.Label labelNameOfVariable;
        private System.Windows.Forms.Label labelValueOfVariable;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnCancel;
    }
}