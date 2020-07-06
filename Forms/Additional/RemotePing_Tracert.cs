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
            Forms.Form1.PingLicznik = this.textBox2.Text;
            Forms.Form1.PingRemoteHost = this.textBox1.Text;
            this.Close();
            
        }
    }
}
