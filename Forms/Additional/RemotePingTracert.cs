using System;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class RemotePingTracert : Form
    {
        public RemotePingTracert(object sender)
        {
            var tracert = ((Button)sender);
            if (tracert.Name.Contains("Tracert"))
                isPing = false;
            InitializeComponent();
            if (tracert.Name.Contains("Tracert"))
            {
                this.MaximumSize = new System.Drawing.Size(371, 128);
                this.MinimumSize = new System.Drawing.Size(371, 128);

            }
        }

        private string HostName;
        private string Counter;
        private bool isPing = true;
        public string GetHost { get => HostName; }
        public string GetCounter { get => Counter; }

        public void AssingValue(object sender, EventArgs e)
        {
            HostName = textboxHostName.Text;
            Counter = textboxCounter.Text;
        }
    }
}
