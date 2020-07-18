using System;
using System.Windows.Forms;

namespace Forms.External.Explorer
{
    public partial class ExplorerFormCustomSearch : Form
    {
        public ExplorerFormCustomSearch()
        {
            InitializeComponent();
        }
        public string TerminalName { get; set; }
        private void btnInput_Click(object sender, EventArgs e)
        {
            TerminalName = textBoxInput.Text;
            this.Close();
        }

        private void textBoxInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TerminalName = textBoxInput.Text;
                this.Close();
            }
        }
    }
}
