using System;
using System.Windows.Forms;

namespace Forms.External.Explorer
{
    public partial class PodajNazweTerminala : Form
    {
        public PodajNazweTerminala()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.MainForm.terminalName = textBox1.Text;
            this.Close();
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Forms.MainForm.terminalName = textBox1.Text;
                this.Close();
            }
        }
    }
}
