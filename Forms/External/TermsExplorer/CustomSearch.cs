using System;
using System.Windows.Forms;

namespace Forms
{
    public partial class PodajNazweTerminala : Form
    {
        public PodajNazweTerminala()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.Form1.terminalName = textBox1.Text;
            this.Close();
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Forms.Form1.terminalName = textBox1.Text;
                this.Close();
            }
        }
    }
}
