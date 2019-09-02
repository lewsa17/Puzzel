using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzel
{
    public partial class RemotePing_Tracert : Form
    {
        public RemotePing_Tracert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Puzzel.Form1.PingLicznik = this.textBox2.Text;
            Puzzel.Form1.PingRemoteHost = this.textBox1.Text;
            this.Close();
            
        }
    }
}
