using System;
using System.Drawing;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class SearchingMainForm : Form
    {
        RichTextBox textField = new();
        public SearchingMainForm(RichTextBox richTextBox)
        {
            InitializeComponent();
            textField = richTextBox;
            textField.HideSelection = true;
            textField.SelectionStart = 0;
            textField.SelectionLength = 0;
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
                        if (textField.SelectionStart > 1)
                            SelectionStart = textField.Text.IndexOf(SearchWord, textField.SelectionStart + SearchWord.Length, StringComparison.CurrentCultureIgnoreCase);
                        else SelectionStart = textField.Text.IndexOf(SearchWord, textField.SelectionStart, StringComparison.CurrentCultureIgnoreCase);
                    }

                    if (((Button)sender) == btnPreviousWord)
                        SelectionStart = textField.Find(SearchWord, 0, textField.SelectionStart, RichTextBoxFinds.Reverse);
                    textField.HideSelection = false;
                }
            }
            if (sender is TextBox)
            {
                if (textField.SelectionStart > 1)
                    SelectionStart = textField.Text.IndexOf(SearchWord, textField.SelectionStart + SearchWord.Length, StringComparison.CurrentCultureIgnoreCase);
                else SelectionStart = textField.Text.IndexOf(SearchWord, textField.SelectionStart, StringComparison.CurrentCultureIgnoreCase);
                textField.HideSelection = false;
            }
            if (SelectionStart != -1)
                textField.SelectionStart = SelectionStart;
            else
                MessageBox.Show("Nie znaleziono wartości: " + SearchWord);
            textField.SelectionLength = SearchWord.Length;
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
            textField.HideSelection = true;
        }
    }
}

