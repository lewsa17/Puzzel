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
    public partial class LockoutStatusZmianaHasla : Form
    {
        public LockoutStatusZmianaHasla()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
                Lockout_Status.password = textBox1.Text;
            else MessageBox.Show(new Form { TopMost = true }, "Podane hasła nie są zgodne", "Zmiana hasła", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
