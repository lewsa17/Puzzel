using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Forms.External.Explorer
{
    public partial class ExplorerFormCustomSearch : Form
    {
        public ExplorerFormCustomSearch()
        {
            InitializeComponent();
        }
        public static string TerminalName { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            TerminalName = textBox1.Text;
            this.Close();
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TerminalName = textBox1.Text;
                this.Close();
            }
        }
    }
}
