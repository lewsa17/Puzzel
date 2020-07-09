namespace Forms.External
{
    partial class Ustawienia
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RestoreSettings = new System.Windows.Forms.Button();
            this.SaveSettings = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.przywróćUstawieniaDomyślneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.Remote_Tracert = new System.Windows.Forms.Button();
            this.Remote_Ping = new System.Windows.Forms.Button();
            this.ZdalneCMD = new System.Windows.Forms.Button();
            this.Karty_sieciowe = new System.Windows.Forms.Button();
            this.Lista_program = new System.Windows.Forms.Button();
            this.ExplorerC = new System.Windows.Forms.Button();
            this.Pulpit_Zdalny = new System.Windows.Forms.Button();
            this.DW = new System.Windows.Forms.Button();
            this.Zarzadzanie = new System.Windows.Forms.Button();
            this.KomputerInfo = new System.Windows.Forms.Button();
            this.Ping = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KomputerLog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Profil_EXT = new System.Windows.Forms.Button();
            this.Profil_TS = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Logoff = new System.Windows.Forms.Button();
            this.Polacz = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Szukaj_sesji = new System.Windows.Forms.Button();
            this.Profil_ERI = new System.Windows.Forms.Button();
            this.Profil_VFS = new System.Windows.Forms.Button();
            this.Info_z_AD = new System.Windows.Forms.Button();
            this.UserLog = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1041, 556);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1033, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Skróty klawiszowe";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RestoreSettings);
            this.groupBox5.Controls.Add(this.SaveSettings);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.comboBox6);
            this.groupBox5.Controls.Add(this.comboBox5);
            this.groupBox5.Controls.Add(this.comboBox4);
            this.groupBox5.Location = new System.Drawing.Point(6, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(979, 96);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ustaw skróty klawiszowe";
            // 
            // RestoreSettings
            // 
            this.RestoreSettings.Location = new System.Drawing.Point(423, 67);
            this.RestoreSettings.Name = "RestoreSettings";
            this.RestoreSettings.Size = new System.Drawing.Size(113, 23);
            this.RestoreSettings.TabIndex = 6;
            this.RestoreSettings.Text = "Przywróć ustawienia domyślne";
            this.RestoreSettings.UseVisualStyleBackColor = true;
            this.RestoreSettings.Click += new System.EventHandler(this.RestoreSettings_Click);
            // 
            // SaveSettings
            // 
            this.SaveSettings.Location = new System.Drawing.Point(316, 67);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(101, 23);
            this.SaveSettings.TabIndex = 9;
            this.SaveSettings.Text = "Zapisz ustawienia";
            this.SaveSettings.UseVisualStyleBackColor = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "+";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "+";
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(284, 16);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(120, 21);
            this.comboBox6.TabIndex = 2;
            this.comboBox6.Visible = false;
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(145, 16);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(120, 21);
            this.comboBox5.TabIndex = 1;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "CTRL",
            "ALT",
            "BRAK"});
            this.comboBox4.Location = new System.Drawing.Point(6, 16);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(120, 21);
            this.comboBox4.TabIndex = 0;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.ComboBox4_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button20);
            this.groupBox4.Controls.Add(this.button19);
            this.groupBox4.Location = new System.Drawing.Point(6, 174);
            this.groupBox4.MinimumSize = new System.Drawing.Size(0, 45);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(979, 54);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Różne narzędzia";
            // 
            // button20
            // 
            this.button20.ContextMenuStrip = this.contextMenuStrip1;
            this.button20.Enabled = false;
            this.button20.Image = global::Forms.Properties.Resources.reload;
            this.button20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button20.Location = new System.Drawing.Point(101, 15);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(97, 33);
            this.button20.TabIndex = 0;
            this.button20.TabStop = false;
            this.button20.Text = "Reload Logs";
            this.button20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.Object_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.przywróćUstawieniaDomyślneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(237, 26);
            // 
            // przywróćUstawieniaDomyślneToolStripMenuItem
            // 
            this.przywróćUstawieniaDomyślneToolStripMenuItem.Name = "przywróćUstawieniaDomyślneToolStripMenuItem";
            this.przywróćUstawieniaDomyślneToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.przywróćUstawieniaDomyślneToolStripMenuItem.Text = "Przywróć ustawienia domyślne";
            this.przywróćUstawieniaDomyślneToolStripMenuItem.Click += new System.EventHandler(this.PrzywróćUstawieniaDomyślneToolStripMenuItem_Click);
            // 
            // button19
            // 
            this.button19.ContextMenuStrip = this.contextMenuStrip1;
            this.button19.Image = global::Forms.Properties.Resources.rubish;
            this.button19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button19.Location = new System.Drawing.Point(6, 15);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(89, 36);
            this.button19.TabIndex = 1;
            this.button19.TabStop = false;
            this.button19.Text = "Flush DNS";
            this.button19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.Object_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.Remote_Tracert);
            this.groupBox3.Controls.Add(this.Remote_Ping);
            this.groupBox3.Controls.Add(this.ZdalneCMD);
            this.groupBox3.Controls.Add(this.Karty_sieciowe);
            this.groupBox3.Controls.Add(this.Lista_program);
            this.groupBox3.Controls.Add(this.ExplorerC);
            this.groupBox3.Controls.Add(this.Pulpit_Zdalny);
            this.groupBox3.Controls.Add(this.DW);
            this.groupBox3.Controls.Add(this.Zarzadzanie);
            this.groupBox3.Controls.Add(this.KomputerInfo);
            this.groupBox3.Controls.Add(this.Ping);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.KomputerLog);
            this.groupBox3.Location = new System.Drawing.Point(0, 93);
            this.groupBox3.MinimumSize = new System.Drawing.Size(0, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(985, 75);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informacje o komputerze:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(6, 43);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 1;
            // 
            // Remote_Tracert
            // 
            this.Remote_Tracert.ContextMenuStrip = this.contextMenuStrip1;
            this.Remote_Tracert.Location = new System.Drawing.Point(736, 40);
            this.Remote_Tracert.Name = "Remote_Tracert";
            this.Remote_Tracert.Size = new System.Drawing.Size(107, 30);
            this.Remote_Tracert.TabIndex = 0;
            this.Remote_Tracert.TabStop = false;
            this.Remote_Tracert.Text = "Remote TRACERT";
            this.Remote_Tracert.UseVisualStyleBackColor = true;
            this.Remote_Tracert.Click += new System.EventHandler(this.Object_Click);
            // 
            // Remote_Ping
            // 
            this.Remote_Ping.ContextMenuStrip = this.contextMenuStrip1;
            this.Remote_Ping.Location = new System.Drawing.Point(736, 10);
            this.Remote_Ping.Name = "Remote_Ping";
            this.Remote_Ping.Size = new System.Drawing.Size(107, 30);
            this.Remote_Ping.TabIndex = 1;
            this.Remote_Ping.TabStop = false;
            this.Remote_Ping.Text = "Remote PING";
            this.Remote_Ping.UseVisualStyleBackColor = true;
            this.Remote_Ping.Click += new System.EventHandler(this.Object_Click);
            // 
            // ZdalneCMD
            // 
            this.ZdalneCMD.ContextMenuStrip = this.contextMenuStrip1;
            this.ZdalneCMD.Image = global::Forms.Properties.Resources.zdalneCMD;
            this.ZdalneCMD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ZdalneCMD.Location = new System.Drawing.Point(633, 10);
            this.ZdalneCMD.Name = "ZdalneCMD";
            this.ZdalneCMD.Size = new System.Drawing.Size(103, 30);
            this.ZdalneCMD.TabIndex = 2;
            this.ZdalneCMD.TabStop = false;
            this.ZdalneCMD.Text = "Zdalne CMD";
            this.ZdalneCMD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ZdalneCMD.UseVisualStyleBackColor = true;
            this.ZdalneCMD.Click += new System.EventHandler(this.Object_Click);
            // 
            // Karty_sieciowe
            // 
            this.Karty_sieciowe.ContextMenuStrip = this.contextMenuStrip1;
            this.Karty_sieciowe.Image = global::Forms.Properties.Resources.netcard;
            this.Karty_sieciowe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Karty_sieciowe.Location = new System.Drawing.Point(633, 40);
            this.Karty_sieciowe.Name = "Karty_sieciowe";
            this.Karty_sieciowe.Size = new System.Drawing.Size(103, 30);
            this.Karty_sieciowe.TabIndex = 3;
            this.Karty_sieciowe.TabStop = false;
            this.Karty_sieciowe.Text = "Karty sieciowe";
            this.Karty_sieciowe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Karty_sieciowe.UseVisualStyleBackColor = true;
            this.Karty_sieciowe.Click += new System.EventHandler(this.Object_Click);
            // 
            // Lista_program
            // 
            this.Lista_program.ContextMenuStrip = this.contextMenuStrip1;
            this.Lista_program.Image = global::Forms.Properties.Resources.programlist;
            this.Lista_program.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lista_program.Location = new System.Drawing.Point(520, 40);
            this.Lista_program.Name = "Lista_program";
            this.Lista_program.Size = new System.Drawing.Size(113, 30);
            this.Lista_program.TabIndex = 4;
            this.Lista_program.TabStop = false;
            this.Lista_program.Text = "Lista programów";
            this.Lista_program.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Lista_program.UseVisualStyleBackColor = true;
            this.Lista_program.Click += new System.EventHandler(this.Object_Click);
            // 
            // ExplorerC
            // 
            this.ExplorerC.ContextMenuStrip = this.contextMenuStrip1;
            this.ExplorerC.Image = global::Forms.Properties.Resources.folder;
            this.ExplorerC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExplorerC.Location = new System.Drawing.Point(520, 10);
            this.ExplorerC.Name = "ExplorerC";
            this.ExplorerC.Size = new System.Drawing.Size(113, 30);
            this.ExplorerC.TabIndex = 5;
            this.ExplorerC.TabStop = false;
            this.ExplorerC.Text = "Explorer C$";
            this.ExplorerC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExplorerC.UseVisualStyleBackColor = true;
            this.ExplorerC.Click += new System.EventHandler(this.Object_Click);
            // 
            // Pulpit_Zdalny
            // 
            this.Pulpit_Zdalny.ContextMenuStrip = this.contextMenuStrip1;
            this.Pulpit_Zdalny.Image = global::Forms.Properties.Resources.rdp;
            this.Pulpit_Zdalny.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Pulpit_Zdalny.Location = new System.Drawing.Point(423, 40);
            this.Pulpit_Zdalny.Name = "Pulpit_Zdalny";
            this.Pulpit_Zdalny.Size = new System.Drawing.Size(97, 30);
            this.Pulpit_Zdalny.TabIndex = 6;
            this.Pulpit_Zdalny.TabStop = false;
            this.Pulpit_Zdalny.Text = "Pulpit zdalny";
            this.Pulpit_Zdalny.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Pulpit_Zdalny.UseVisualStyleBackColor = true;
            this.Pulpit_Zdalny.Click += new System.EventHandler(this.Object_Click);
            // 
            // DW
            // 
            this.DW.ContextMenuStrip = this.contextMenuStrip1;
            this.DW.Image = global::Forms.Properties.Resources.dw;
            this.DW.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DW.Location = new System.Drawing.Point(423, 10);
            this.DW.Name = ExternalResources.dw;
            this.DW.Size = new System.Drawing.Size(97, 30);
            this.DW.TabIndex = 7;
            this.DW.TabStop = false;
            this.DW.Text = ExternalResources.dw;
            this.DW.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DW.UseVisualStyleBackColor = true;
            this.DW.Click += new System.EventHandler(this.Object_Click);
            // 
            // Zarzadzanie
            // 
            this.Zarzadzanie.ContextMenuStrip = this.contextMenuStrip1;
            this.Zarzadzanie.Image = global::Forms.Properties.Resources.compmgmt;
            this.Zarzadzanie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Zarzadzanie.Location = new System.Drawing.Point(316, 40);
            this.Zarzadzanie.Name = "Zarzadzanie";
            this.Zarzadzanie.Size = new System.Drawing.Size(107, 30);
            this.Zarzadzanie.TabIndex = 8;
            this.Zarzadzanie.TabStop = false;
            this.Zarzadzanie.Text = "Zarządzanie";
            this.Zarzadzanie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Zarzadzanie.UseVisualStyleBackColor = true;
            this.Zarzadzanie.Click += new System.EventHandler(this.Object_Click);
            // 
            // KomputerInfo
            // 
            this.KomputerInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.KomputerInfo.Image = global::Forms.Properties.Resources.komputerinfo;
            this.KomputerInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KomputerInfo.Location = new System.Drawing.Point(316, 10);
            this.KomputerInfo.Name = "KomputerInfo";
            this.KomputerInfo.Size = new System.Drawing.Size(107, 30);
            this.KomputerInfo.TabIndex = 9;
            this.KomputerInfo.TabStop = false;
            this.KomputerInfo.Text = "Komputer info";
            this.KomputerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.KomputerInfo.UseVisualStyleBackColor = true;
            this.KomputerInfo.Click += new System.EventHandler(this.Object_Click);
            // 
            // Ping
            // 
            this.Ping.ContextMenuStrip = this.contextMenuStrip1;
            this.Ping.Image = global::Forms.Properties.Resources.ping;
            this.Ping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ping.Location = new System.Drawing.Point(209, 40);
            this.Ping.Name = "Ping";
            this.Ping.Size = new System.Drawing.Size(107, 30);
            this.Ping.TabIndex = 10;
            this.Ping.TabStop = false;
            this.Ping.Text = "Ping";
            this.Ping.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Ping.UseVisualStyleBackColor = true;
            this.Ping.Click += new System.EventHandler(this.Object_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.numericUpDown2.Location = new System.Drawing.Point(143, 43);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(137, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ilośc logów:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Nazwa komputera:";
            // 
            // KomputerLog
            // 
            this.KomputerLog.ContextMenuStrip = this.contextMenuStrip1;
            this.KomputerLog.Image = global::Forms.Properties.Resources.Complog;
            this.KomputerLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KomputerLog.Location = new System.Drawing.Point(209, 10);
            this.KomputerLog.Name = "KomputerLog";
            this.KomputerLog.Size = new System.Drawing.Size(107, 30);
            this.KomputerLog.TabIndex = 13;
            this.KomputerLog.TabStop = false;
            this.KomputerLog.Text = "Komputer log";
            this.KomputerLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.KomputerLog.UseVisualStyleBackColor = true;
            this.KomputerLog.Click += new System.EventHandler(this.Object_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.Profil_EXT);
            this.groupBox1.Controls.Add(this.Profil_TS);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.Profil_ERI);
            this.groupBox1.Controls.Add(this.Profil_VFS);
            this.groupBox1.Controls.Add(this.Info_z_AD);
            this.groupBox1.Controls.Add(this.UserLog);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informacje o użytkowniku:";
            // 
            // comboBox2
            // 
            this.comboBox2.Location = new System.Drawing.Point(6, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // Profil_EXT
            // 
            this.Profil_EXT.ContextMenuStrip = this.contextMenuStrip1;
            this.Profil_EXT.Image = global::Forms.Properties.Resources.folder;
            this.Profil_EXT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profil_EXT.Location = new System.Drawing.Point(393, 41);
            this.Profil_EXT.Name = "Profil_EXT";
            this.Profil_EXT.Size = new System.Drawing.Size(80, 30);
            this.Profil_EXT.TabIndex = 0;
            this.Profil_EXT.TabStop = false;
            this.Profil_EXT.Text = "Profil EXT";
            this.Profil_EXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Profil_EXT.UseVisualStyleBackColor = true;
            this.Profil_EXT.Click += new System.EventHandler(this.Object_Click);
            // 
            // Profil_TS
            // 
            this.Profil_TS.ContextMenuStrip = this.contextMenuStrip1;
            this.Profil_TS.Image = global::Forms.Properties.Resources.folder;
            this.Profil_TS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profil_TS.Location = new System.Drawing.Point(393, 11);
            this.Profil_TS.Name = "Profil_TS";
            this.Profil_TS.Size = new System.Drawing.Size(80, 30);
            this.Profil_TS.TabIndex = 1;
            this.Profil_TS.TabStop = false;
            this.Profil_TS.Text = "Profil TS";
            this.Profil_TS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Profil_TS.UseVisualStyleBackColor = true;
            this.Profil_TS.Click += new System.EventHandler(this.Object_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Logoff);
            this.groupBox2.Controls.Add(this.Polacz);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.Szukaj_sesji);
            this.groupBox2.Location = new System.Drawing.Point(537, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LogOff";
            // 
            // Logoff
            // 
            this.Logoff.ContextMenuStrip = this.contextMenuStrip1;
            this.Logoff.Image = global::Forms.Properties.Resources.Logoff;
            this.Logoff.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Logoff.Location = new System.Drawing.Point(351, 14);
            this.Logoff.Name = "Logoff";
            this.Logoff.Size = new System.Drawing.Size(75, 36);
            this.Logoff.TabIndex = 0;
            this.Logoff.TabStop = false;
            this.Logoff.Text = "LogOff";
            this.Logoff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Logoff.UseVisualStyleBackColor = true;
            this.Logoff.Click += new System.EventHandler(this.Object_Click);
            // 
            // Polacz
            // 
            this.Polacz.ContextMenuStrip = this.contextMenuStrip1;
            this.Polacz.Image = global::Forms.Properties.Resources.handshake;
            this.Polacz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Polacz.Location = new System.Drawing.Point(249, 14);
            this.Polacz.Name = "Polacz";
            this.Polacz.Size = new System.Drawing.Size(96, 36);
            this.Polacz.TabIndex = 1;
            this.Polacz.TabStop = false;
            this.Polacz.Text = "Połącz";
            this.Polacz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Polacz.UseVisualStyleBackColor = true;
            this.Polacz.Click += new System.EventHandler(this.Object_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBox1.Location = new System.Drawing.Point(122, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // Szukaj_sesji
            // 
            this.Szukaj_sesji.ContextMenuStrip = this.contextMenuStrip1;
            this.Szukaj_sesji.Image = global::Forms.Properties.Resources.session;
            this.Szukaj_sesji.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Szukaj_sesji.Location = new System.Drawing.Point(6, 14);
            this.Szukaj_sesji.Name = "Szukaj_sesji";
            this.Szukaj_sesji.Size = new System.Drawing.Size(101, 36);
            this.Szukaj_sesji.TabIndex = 3;
            this.Szukaj_sesji.TabStop = false;
            this.Szukaj_sesji.Text = "Szukaj sesji";
            this.Szukaj_sesji.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Szukaj_sesji.UseVisualStyleBackColor = true;
            this.Szukaj_sesji.Click += new System.EventHandler(this.Object_Click);
            // 
            // Profil_ERI
            // 
            this.Profil_ERI.ContextMenuStrip = this.contextMenuStrip1;
            this.Profil_ERI.Image = global::Forms.Properties.Resources.folder;
            this.Profil_ERI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profil_ERI.Location = new System.Drawing.Point(316, 41);
            this.Profil_ERI.Name = "Profil_ERI";
            this.Profil_ERI.Size = new System.Drawing.Size(77, 30);
            this.Profil_ERI.TabIndex = 3;
            this.Profil_ERI.TabStop = false;
            this.Profil_ERI.Text = "Profil ERI";
            this.Profil_ERI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Profil_ERI.UseVisualStyleBackColor = true;
            this.Profil_ERI.Click += new System.EventHandler(this.Object_Click);
            // 
            // Profil_VFS
            // 
            this.Profil_VFS.ContextMenuStrip = this.contextMenuStrip1;
            this.Profil_VFS.Image = global::Forms.Properties.Resources.folder;
            this.Profil_VFS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Profil_VFS.Location = new System.Drawing.Point(316, 11);
            this.Profil_VFS.Name = "Profil_VFS";
            this.Profil_VFS.Size = new System.Drawing.Size(77, 30);
            this.Profil_VFS.TabIndex = 4;
            this.Profil_VFS.TabStop = false;
            this.Profil_VFS.Text = "Profil VFS";
            this.Profil_VFS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Profil_VFS.UseVisualStyleBackColor = true;
            this.Profil_VFS.Click += new System.EventHandler(this.Object_Click);
            // 
            // Info_z_AD
            // 
            this.Info_z_AD.ContextMenuStrip = this.contextMenuStrip1;
            this.Info_z_AD.Image = global::Forms.Properties.Resources.infozad;
            this.Info_z_AD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Info_z_AD.Location = new System.Drawing.Point(209, 41);
            this.Info_z_AD.Name = "Info_z_AD";
            this.Info_z_AD.Size = new System.Drawing.Size(107, 30);
            this.Info_z_AD.TabIndex = 5;
            this.Info_z_AD.TabStop = false;
            this.Info_z_AD.Text = "Info z AD";
            this.Info_z_AD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Info_z_AD.UseVisualStyleBackColor = true;
            this.Info_z_AD.Click += new System.EventHandler(this.Object_Click);
            // 
            // UserLog
            // 
            this.UserLog.BackColor = System.Drawing.Color.Transparent;
            this.UserLog.ContextMenuStrip = this.contextMenuStrip1;
            this.UserLog.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.UserLog.Image = global::Forms.Properties.Resources.userlog;
            this.UserLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UserLog.Location = new System.Drawing.Point(209, 11);
            this.UserLog.Name = "UserLog";
            this.UserLog.Size = new System.Drawing.Size(107, 30);
            this.UserLog.TabIndex = 6;
            this.UserLog.TabStop = false;
            this.UserLog.Text = "User Log";
            this.UserLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UserLog.UseVisualStyleBackColor = false;
            this.UserLog.Click += new System.EventHandler(this.Object_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.numericUpDown1.Location = new System.Drawing.Point(143, 40);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(137, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ilość logów:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Login:";
            // 
            // Ustawienia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 568);
            this.Controls.Add(this.tabControl1);
            this.Name = "Ustawienia";
            this.Text = "Ustawienia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ustawienia_FormClosing);
            this.Load += new System.EventHandler(this.Ustawienia_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button Profil_EXT;
        private System.Windows.Forms.Button Profil_TS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Logoff;
        private System.Windows.Forms.Button Polacz;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Szukaj_sesji;
        private System.Windows.Forms.Button Profil_ERI;
        private System.Windows.Forms.Button Info_z_AD;
        private System.Windows.Forms.Button UserLog;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button Remote_Tracert;
        private System.Windows.Forms.Button Remote_Ping;
        private System.Windows.Forms.Button ZdalneCMD;
        private System.Windows.Forms.Button Karty_sieciowe;
        private System.Windows.Forms.Button Lista_program;
        private System.Windows.Forms.Button ExplorerC;
        private System.Windows.Forms.Button Pulpit_Zdalny;
        private System.Windows.Forms.Button DW;
        private System.Windows.Forms.Button Zarzadzanie;
        private System.Windows.Forms.Button KomputerInfo;
        private System.Windows.Forms.Button Ping;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button KomputerLog;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button SaveSettings;
        private System.Windows.Forms.Button Profil_VFS;
        private System.Windows.Forms.Button RestoreSettings;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem przywróćUstawieniaDomyślneToolStripMenuItem;
    }
}
