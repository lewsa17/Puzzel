﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class SearchingMainForm : Form
    {
        public SearchingMainForm()
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
            string SearchWord = textBoxSearchedText.Text;
            int SelectionStart = 0;
            if (sender is Button)
            {
                if (Form.SelectedTab == TabFind)
                {
                    if (((Button)sender) == btnSearch | ((Button)sender) == btnNextWord)
                    {
                        if (MainForm.richTextBox1.SelectionStart > 1)
                            SelectionStart = MainForm.richTextBox1.Text.IndexOf(SearchWord, MainForm.richTextBox1.SelectionStart + SearchWord.Length, StringComparison.CurrentCultureIgnoreCase);
                        else SelectionStart = MainForm.richTextBox1.Text.IndexOf(SearchWord, MainForm.richTextBox1.SelectionStart, StringComparison.CurrentCultureIgnoreCase);
                    }

                    if (((Button)sender) == btnPreviousWord)
                        SelectionStart = MainForm.richTextBox1.Find(SearchWord, 0, MainForm.richTextBox1.SelectionStart, RichTextBoxFinds.Reverse);
                }
            }

            if (sender is TextBox)
            {
                if (MainForm.richTextBox1.SelectionStart > 1)
                    SelectionStart = MainForm.richTextBox1.Text.IndexOf(SearchWord, MainForm.richTextBox1.SelectionStart + SearchWord.Length, StringComparison.CurrentCultureIgnoreCase);
                else SelectionStart = MainForm.richTextBox1.Text.IndexOf(SearchWord, MainForm.richTextBox1.SelectionStart, StringComparison.CurrentCultureIgnoreCase);
            }
            if (SelectionStart != -1)
                MainForm.richTextBox1.SelectionStart = SelectionStart;
            else
                MessageBox.Show("Nie znaleziono wartości: " + SearchWord);
            MainForm.richTextBox1.SelectionLength = SearchWord.Length;
        }

        private void WyszukiwarkaDlaFormy_Load(object sender, EventArgs e)
        {
            textBoxSearchedText.Text = ostatniouzywanawartosc;
            btnPreviousWord.Location = new Point(9, 54);
            btnNextWord.Location = new Point(167, 54);
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Buttons_Click(sender, e);
        }

        private void Wyszukiwarka_Click(object sender, EventArgs e)
        {
            this.Text = Form.SelectedTab.Text;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DualDirectionbox.Checked)
            {
                btnPreviousWord.Visible = true;
                btnNextWord.Visible = true;
                btnSearch.Visible = false;
            }
            else
            {
                btnPreviousWord.Visible = false;
                btnNextWord.Visible = false;
                btnSearch.Visible = true;
            }
        }

        private void WyszukiwarkaDlaFormy_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.richTextBox1.HideSelection = true;
        }
    }
}