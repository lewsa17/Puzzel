using System;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class RemotePingTracert : Form
    {
        public RemotePingTracert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.MainForm.PingLicznik = this.textBox2.Text;
            Forms.MainForm.PingRemoteHost = this.textBox1.Text;
            this.Close();
            
        }
    }
}
