using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class RemotePingTracert : Form
    {
        public RemotePingTracert()
        {
            InitializeComponent();
        }

        private string HostName;
        private string Counter;
        public string GetHost { get => HostName; }
        public string GetCounter { get => Counter; }

        public void AssingValue(object sender, EventArgs e)
        {
            HostName = textboxHostName.Text;
            Counter = textboxCounter.Text;
        }
    }
}
