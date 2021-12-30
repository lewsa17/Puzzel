using System;
using System.Windows.Forms;

namespace Forms.Additional
{
    public partial class SearchingMainForm : Form
    {
        RichTextBox textField = new();
        DataGridView table = new();
        public SearchingMainForm(RichTextBox control)
        {
            InitializeComponent();
            textField = control;
            textField.HideSelection = true;
            textField.SelectionStart = 0;
            textField.SelectionLength = 0;
        }

        public SearchingMainForm(DataGridView control)
        {
            InitializeComponent();
            table = control;
        }
        private void SearchingInTable(object sender, EventArgs e)
        {
            string SearchWord = textBoxSearchedText.Text;
            table.ClearSelection();

            var begginingCell = table.CurrentCell;
            int currentCellIndex = begginingCell.ColumnIndex;

            int currentRowIndex = begginingCell.RowIndex;
            
            DataGridViewRow newRow = begginingCell.OwningRow;
            DataGridViewCell newCell = null;
            if (sender is Button)
            {
                if (((Button)sender) == btnSearch | ((Button)sender) == btnNextWord)
                {
                    while (currentCellIndex < table.ColumnCount && currentRowIndex < table.RowCount)
                    {
                        newRow = table.Rows[currentRowIndex];
                        for (int j = currentCellIndex; j < table.ColumnCount; j++)
                        {
                            newCell = newRow.Cells[j];
                            if (newCell.Value.ToString().Contains(SearchWord, StringComparison.CurrentCultureIgnoreCase) && newCell != begginingCell)
                            {
                                newCell.Selected = true;
                                return;
                            }
                            table.CurrentCell = newCell;
                        }
                        currentCellIndex = 0;
                        currentRowIndex++;
                    }
                    MessageBox.Show("Dotarłeś do końca");
                }

                if (((Button)sender) == btnPreviousWord)
                {
                    while (currentCellIndex >= 0 && currentRowIndex >= 0)
                    {
                        newRow = table.Rows[currentRowIndex];
                        for (int j = currentCellIndex; j >= 0; j--)
                        {
                            newCell = newRow.Cells[j];
                            if (newCell.Value.ToString().Contains(SearchWord, StringComparison.CurrentCultureIgnoreCase) && newCell != begginingCell)
                            {
                                newCell.Selected = true;
                                return;
                            }
                            table.CurrentCell = newCell;
                        }
                        currentCellIndex = table.ColumnCount -1;
                        currentRowIndex--;
                    }
                    MessageBox.Show("Jesteś na początku");
                }

            }

        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            string SearchWord = textBoxSearchedText.Text;
            int SelectionStart = 0;
            if (table.Visible)
                SearchingInTable(sender, e);
            else if (sender is Button)
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
            else if (sender is TextBox)
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

