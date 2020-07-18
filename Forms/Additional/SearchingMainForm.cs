using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class SearchingMainForm : Form
    {
        public SearchingMainForm()
        {
            InitializeComponent();
        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            string SearchWord = textBoxSearchedText.Text;
            int SelectionStart = 0;
            if (sender is Button)
            {
                if (TabControl.SelectedTab == TabFind)
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
        private void SearchingMainForm_Load(object sender, EventArgs e)
        {
            //btnPreviousWord.Location = new Point(9, 54);
            //btnNextWord.Location = new Point(167, 54);
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Buttons_Click(sender, e);
        }
        private void TabControl_Click(object sender, EventArgs e)
        {
            this.Text = TabControl.SelectedTab.Text;
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
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
        private void SearchingMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.richTextBox1.HideSelection = true;
        }
    }
}
