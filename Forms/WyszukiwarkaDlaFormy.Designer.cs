namespace Puzzel
{
    partial class WyszukiwarkaDlaFormy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WyszukiwarkaDlaFormy));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Wyszukiwarka = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Wyszukiwarka.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Szukany tekst";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(9, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Wyszukaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "< = Poprzednie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.button4.Location = new System.Drawing.Point(167, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Następne =>";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // Wyszukiwarka
            // 
            this.Wyszukiwarka.Controls.Add(this.tabPage1);
            this.Wyszukiwarka.Controls.Add(this.tabPage2);
            this.Wyszukiwarka.Location = new System.Drawing.Point(1, 4);
            this.Wyszukiwarka.Name = "Wyszukiwarka";
            this.Wyszukiwarka.SelectedIndex = 0;
            this.Wyszukiwarka.Size = new System.Drawing.Size(341, 154);
            this.Wyszukiwarka.TabIndex = 5;
            this.Wyszukiwarka.SelectedIndexChanged += new System.EventHandler(this.Wyszukiwarka_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(333, 128);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Szukaj";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(176, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Szukanie dwukierunkowe";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(333, 128);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zamień";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zamień na:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(9, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(318, 20);
            this.textBox3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Szukany tekst;";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(318, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Zamień";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(318, 20);
            this.textBox2.TabIndex = 0;
            // 
            // WyszukiwarkaDlaFormy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 161);
            this.Controls.Add(this.Wyszukiwarka);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Puzzel.Properties.Resources.Puzzel;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 200);
            this.Name = "WyszukiwarkaDlaFormy";
            this.Text = "Szukaj";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WyszukiwarkaDlaFormy_FormClosing);
            this.Load += new System.EventHandler(this.WyszukiwarkaDlaFormy_Load);
            this.Wyszukiwarka.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl Wyszukiwarka;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}