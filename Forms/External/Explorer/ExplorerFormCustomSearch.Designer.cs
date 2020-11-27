namespace Forms.External.Explorer
{
    partial class ExplorerFormCustomSearch
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
            System.ComponentModel.ComponentResourceManager resources = new(typeof(ExplorerFormCustomSearch));
            this.textBoxInput = new();
            this.btnInput = new();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new(12, 22);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new(186, 20);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.PreviewKeyDown += new(this.textBoxInput_PreviewKeyDown);
            // 
            // btnInput
            // 
            this.btnInput.Location = new(62, 66);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new(75, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Potwierdź";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new(this.btnInput_Click);
            // 
            // ExplorerFormCustomInput
            // 
            this.AutoScaleDimensions = new(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new(217, 114);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.textBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Forms.Resources.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new(223, 139);
            this.MinimizeBox = false;
            this.MinimumSize = new(223, 139);
            this.Name = "ExplorerFormCustomInput";
            this.Text = "Podaj nazwę Terminala";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button btnInput;
    }
}