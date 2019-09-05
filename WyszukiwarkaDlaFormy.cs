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
       public void Lastvalue(string lastValue)
        {
            ostatniouzywanawartosc = lastValue;
        }
        string ostatniouzywanawartosc = null;

        private void Buttons_Click(object sender, EventArgs e)
        {
            string SearchWord = textBox1.Text;
            int SelectionStart = 0;
            if (sender is Button)
            {
                if (Wyszukiwarka.SelectedTab == tabPage1)
                {
                    if (((Button)sender) == button1 | ((Button)sender) == button4)
                    {
                        if (Form1.richTextBox1.SelectionStart > 1)
                            SelectionStart = Form1.richTextBox1.Text.IndexOf(SearchWord, Form1.richTextBox1.SelectionStart + SearchWord.Length, StringComparison.CurrentCultureIgnoreCase);
                        else SelectionStart = Form1.richTextBox1.Text.IndexOf(SearchWord, Form1.richTextBox1.SelectionStart, StringComparison.CurrentCultureIgnoreCase);
                    }

                    if (((Button)sender) == button3)
                        SelectionStart = Form1.richTextBox1.Find(SearchWord, 0, Form1.richTextBox1.SelectionStart, RichTextBoxFinds.Reverse);
                }
            }

            if (sender is TextBox)
            {
                if (Form1.richTextBox1.SelectionStart > 1)
                    SelectionStart = Form1.richTextBox1.Text.IndexOf(SearchWord, Form1.richTextBox1.SelectionStart + SearchWord.Length, StringComparison.CurrentCultureIgnoreCase);
                else SelectionStart = Form1.richTextBox1.Text.IndexOf(SearchWord, Form1.richTextBox1.SelectionStart, StringComparison.CurrentCultureIgnoreCase);
            }
            if (SelectionStart != -1)
                Form1.richTextBox1.SelectionStart = SelectionStart;
            else
                MessageBox.Show("Nie znaleziono wartości: " + SearchWord);
            Form1.richTextBox1.SelectionLength = SearchWord.Length;   
        }

        private void WyszukiwarkaDlaFormy_Load(object sender, EventArgs e)
        {
            textBox1.Text = ostatniouzywanawartosc;
            button3.Location = new Point(9, 54);
            button4.Location = new Point(167, 54);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Buttons_Click(sender,e);
        }

        private void Wyszukiwarka_Click(object sender, EventArgs e)
        {
            this.Text = Wyszukiwarka.SelectedTab.Text;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button3.Visible = true;
                button4.Visible = true;
                button1.Visible = false;
            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
                button1.Visible = true;
            }
        }

        private void WyszukiwarkaDlaFormy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.richTextBox1.HideSelection = true;
        }
    }
}
