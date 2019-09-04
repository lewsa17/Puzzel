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
    public partial class WyszukiwarkaDlaFormy : Form
    {
        public WyszukiwarkaDlaFormy()
        {
            InitializeComponent();
        }
       public void lastvalue(string lastValue)
        {
            ostatniouzywanawartosc = lastValue;
        }
        string ostatniouzywanawartosc = null;

        private void buttons_Click(object sender, EventArgs e)
        {if (sender is Button)
            {
                if (Wyszukiwarka.SelectedTab == tabPage1)
                {
                    if (((Button)sender) == button1)
                        Form1.statusOkna = 1;
                
                    if (((Button)sender) == button3)
                        Form1.statusOkna = 2;

                    if (((Button)sender) == button4)
                        Form1.statusOkna = 3;
                    stringdopracy = textBox1.Text;
                }

                if (Wyszukiwarka.SelectedTab == tabPage2)
                {
                    if (((Button)sender) == button2)
                        Form1.statusOkna = 4;
                    stringdopracy = textBox2.Text;
                    stringdopracy += ";" + textBox3.Text;
                }
            }
        if (sender is TextBox)
            { 
                if (((TextBox)sender) == textBox1)
                    Form1.statusOkna = 1;
            }
            Close();
        }
        string stringdopracy = null;
        public string GetValue()
        {
            return stringdopracy;
        }

        public string GetDialogResult()
        {
            return "OK";
        }

        private void WyszukiwarkaDlaFormy_Load(object sender, EventArgs e)
        {
            textBox1.Text = ostatniouzywanawartosc;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                buttons_Click(sender,e);
        }

        private void Wyszukiwarka_Click(object sender, EventArgs e)
        {
            this.Text = Wyszukiwarka.SelectedTab.Text;
        }
    }
}
