using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ExcelAddIn1
{
    public partial class AddFilter : Form
    {
        public Filter FilterToPass = new Filter();
        readonly SaveFileDialog saveFileDialog = new SaveFileDialog();
        readonly string inFileName;
        Filter.Type checkedType = Filter.Type.Equal;
        Filter.OutputType selectedOutput = Filter.OutputType.None;
        Filter.InputType selectedInput = Filter.InputType.Numeric;
        List<CheckBox> OpBoxes;

        public AddFilter(Filter filter, string name)
        {
            InitializeComponent();
            inFileName = name;
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Filter = "CSV File|*.csv";
            saveFileDialog.OverwritePrompt = false;

            rangeChkBox.Click += ChangeCheck;
            matchChkBox.Click += ChangeCheck;
            notEqualChkBox.Click += ChangeCheck;
            greaterChkBox.Click += ChangeCheck;
            greaterEqualChkBox.Click += ChangeCheck;
            lesserChkBox.Click += ChangeCheck;
            lessEqualChkBox.Click += ChangeCheck;
            startsWithChkBox.Click += ChangeCheck;
            containsChkBox.Click += ChangeCheck;

            filterEditChkBox.Click += FilterEditChkBox_Click;
            filterInsertChkBox.Click += FilterInsertChkBox_Click;

            daysOldChkBox.Click += DisableChecks;
            numChkBox.Click += DisableChecks;
            stringChkBox.Click += DisableChecks;

            saveAllChkBox.Click += SaveAllChkBox_Click;

            OpBoxes = new List<CheckBox>
            { 
                matchChkBox, rangeChkBox, notEqualChkBox, 
                greaterChkBox, greaterEqualChkBox, lesserChkBox, 
                lessEqualChkBox, startsWithChkBox, containsChkBox 
            };
            
            if (filter.DisplayName != "null")
            {
                rangeMaxLbl.Visible = false;
                rangeMaxBox.Visible = false;

                switch (filter.SelectedType)
                {
                    case Filter.Type.Ranged:
                        ChangeCheck(rangeChkBox, null);

                        rangeMinMatchLbl.Text = "               Value:";
                        checkedType = Filter.Type.Ranged;
                        rangeMaxLbl.Visible = true;
                        rangeMaxBox.Visible = true;

                        rangeMaxBox.Enabled = true;

                        matchBox.Text = filter.ValueMatch;
                        rangeMaxBox.Text = filter.ValueMax;
                        columnBox.Text = filter.SelectedColumn;
                        break;

                    case Filter.Type.Greater:
                        ChangeCheck(greaterChkBox, null);
                        break;

                    case Filter.Type.Lesser:
                        ChangeCheck(lesserChkBox, null);
                        break;

                    case Filter.Type.GreaterOrEqual:
                        ChangeCheck(greaterEqualChkBox, null);
                        break;

                    case Filter.Type.LesserOrEqual:
                        ChangeCheck(lessEqualChkBox, null);
                        break;

                    case Filter.Type.Equal:
                        ChangeCheck(matchChkBox, null);
                        break;

                    case Filter.Type.NotEqual:
                        ChangeCheck(notEqualChkBox, null);
                        break;
                    case Filter.Type.StartsWith:
                        ChangeCheck(startsWithChkBox, null);
                        break;
                    case Filter.Type.Contains:
                        ChangeCheck(containsChkBox, null);
                        break;
                }

                switch (selectedOutput)
                {
                    case Filter.OutputType.Edit:
                        filterEditChkBox.Checked = true;
                        break;
                    case Filter.OutputType.Insert:
                        filterInsertChkBox.Checked = true;
                        break;
                }

                if (filter.SaveAll)
                {
                    saveAllChkBox.Checked = true;
                }

                columnBox.Enabled = true;
                saveBtn.Enabled = true;

                matchBox.Text = filter.ValueMatch;
                columnBox.Text = filter.SelectedColumn;

            }
            else
            {
                matchChkBox.Checked = true;
                rangeChkBox.Checked = false;
                rangeMaxLbl.Visible = false;
                rangeMaxBox.Visible = false;
                rangeMinMatchLbl.Text = "               Value:";
            }
            FilterToPass = filter;
            DisableChecks(numChkBox, null);
        }

        private void SaveAllChkBox_Click(object sender, EventArgs e)
        {
            if (FilterToPass.SaveAll)
            {
                saveAllChkBox.Checked = false;
                FilterToPass.SaveAll = false;
            }
            else
            {
                saveAllChkBox.Checked = true;
                FilterToPass.SaveAll = true;
            }
        }

        private void FilterInsertChkBox_Click(object sender, EventArgs e)
        {
            filterEditLbl.Enabled = false;
            filterEditNewValueLbl.Enabled = false;
            filterEditColBox.Enabled = false;

            switch (selectedOutput)
            {
                case Filter.OutputType.None:
                    filterInsertChkBox.Checked = true;
                    selectedOutput = Filter.OutputType.Insert;
                    break;
                case Filter.OutputType.Edit:
                    filterInsertChkBox.Checked = true;
                    filterEditChkBox.Checked = false;
                    selectedOutput = Filter.OutputType.Insert;
                    break;
                case Filter.OutputType.Insert:
                    filterInsertChkBox.Checked = false;
                    selectedOutput = Filter.OutputType.None;
                    break;
            }

            filterEditLbl.Enabled = filterInsertChkBox.Checked;
            filterEditNewValueLbl.Enabled = filterInsertChkBox.Checked;
            filterEditColBox.Enabled = filterInsertChkBox.Checked;
            filterEditValBox.Enabled = filterInsertChkBox.Checked;
        }
        

        private void FilterEditChkBox_Click(object sender, EventArgs e)
        {
            filterEditLbl.Enabled = false;
            filterEditNewValueLbl.Enabled = false;
            filterEditColBox.Enabled = false;

            switch (selectedOutput)
            {
                case Filter.OutputType.None:
                    filterEditChkBox.Checked = true;
                    selectedOutput = Filter.OutputType.Edit;
                    break;
                case Filter.OutputType.Edit:
                    filterEditChkBox.Checked = false;
                    selectedOutput = Filter.OutputType.None;
                    break;
                case Filter.OutputType.Insert:
                    filterEditChkBox.Checked = true;
                    filterInsertChkBox.Checked = false;
                    selectedOutput = Filter.OutputType.Edit;
                    break;
            }

            filterEditLbl.Enabled = filterEditChkBox.Checked;
            filterEditNewValueLbl.Enabled = filterEditChkBox.Checked;
            filterEditColBox.Enabled = filterEditChkBox.Checked;
            filterEditValBox.Enabled = filterEditChkBox.Checked;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (CheckChars(columnBox.Text.ToCharArray()))
            {
                columnBox.Refresh();
                saveFileDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CSVs\FilterOutput";
                if (!Directory.Exists(saveFileDialog.InitialDirectory))
                {
                    Directory.CreateDirectory(saveFileDialog.InitialDirectory);
                }

                if(checkedType == Filter.Type.Ranged)
                {
                    saveFileDialog.FileName = $"{inFileName}-{matchBox.Text}_to_{rangeMaxBox.Text}@{columnBox.Text}.csv";
                }
                else
                {
                    saveFileDialog.FileName = $"{inFileName}-{columnBox.Text}_{checkedType}_{matchBox.Text}.csv";
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;
                    switch (checkedType)
                    {
                        case Filter.Type.Equal:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} equals \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.NotEqual:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} does not equal \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.Greater:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} is more than \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.Lesser:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} is less than \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.GreaterOrEqual:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} is more than or equal to \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.LesserOrEqual:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} is less than or equal to \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.StartsWith:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} starts with \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.Contains:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} contains \"{matchBox.Text}\"";
                            break;
                        case Filter.Type.Ranged:
                            FilterToPass.DisplayName = $"Column {columnBox.Text} greater than \"{matchBox.Text}\" but less than \"{rangeMaxBox.Text}\"";
                            break;
                    }
                    FilterToPass.ValueMatch = matchBox.Text;
                    FilterToPass.ValueMax = matchBox.Enabled ? rangeMaxBox.Text : null;
                    FilterToPass.SelectedColumn = columnBox.Text;
                    FilterToPass.OutputFile = savePath;
                    FilterToPass.SkippedHeader = false;
                    FilterToPass.SelectedType = checkedType;
                    FilterToPass.EditColumn = filterEditChkBox.Checked || filterInsertChkBox.Checked? filterEditColBox.Text : null;
                    FilterToPass.EditValue = filterEditChkBox.Checked || filterInsertChkBox.Checked ? filterEditValBox.Text : null; ;
                    FilterToPass.SelectedOutput = selectedOutput;
                    FilterToPass.SelectedInput = selectedInput;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void rangeMinMatchBox_TextChanged(object sender, EventArgs e)
        {
            if (matchBox.TextLength > 0)
            {
                if (rangeChkBox.CheckState == CheckState.Checked)
                {
                    rangeMaxBox.Enabled = true;
                }
                else
                {
                    columnBox.Enabled = true;
                }
            }
        }

        private void rangeMaxBox_TextChanged(object sender, EventArgs e)
        {
            if (rangeMaxBox.TextLength > 0)
            {
                columnBox.Enabled = true;
            }
        }

        private void columnBox_TextChanged(object sender, EventArgs e)
        {
            if (columnBox.TextLength > 0)
            {
                saveBtn.Enabled = true;
                saveAllChkBox.Enabled = true;
                filterInsertChkBox.Enabled = true;
                filterEditChkBox.Enabled = true;
            }
            else if (columnBox.TextLength == 0)
            {
                saveBtn.Enabled = false;
                saveAllChkBox.Enabled = false;
                filterInsertChkBox.Enabled = false;
                filterEditChkBox.Enabled = false;
            }
        }

        private void filterEditColBox_TextChanged(object sender, EventArgs e)
        {
            if (filterEditColBox.TextLength > 0)
            {
                filterEditValBox.Enabled = true;
            }
            else if (filterEditColBox.TextLength == 0)
            {
                filterEditValBox.Enabled = false;
            }
        }

        private void filterEditValBox_TextChanged(object sender, EventArgs e)
        {
            if (filterEditColBox.TextLength > 0)
            {
                string text = filterEditColBox.Text;
                char[] arr = text.ToCharArray();
                if (text.Length > 2)
                {
                    if (new AlertDialog("General error", "This application was not built to handle columns about ZZ. Contact support.").ShowDialog() == DialogResult.OK)
                    {
                        filterEditColBox.Text = $"{arr[0]}{arr[1]}";
                        return;
                    }
                }
                else if (arr.Length == 1)
                {
                    if (!char.IsUpper(arr[0]))
                    {
                        if (char.IsLower(arr[0]))
                        {
                            arr[0] = char.ToUpper(arr[0]);
                        }
                        else
                        {
                            if (new AlertDialog("General error", "A character in the search index was not a letter. Please revise.").ShowDialog() == DialogResult.OK)
                            {
                                return;
                            }
                        }
                    }
                    filterEditColBox.Text = $"{arr[0]}";
                }
                else
                {
                    if (!char.IsUpper(arr[0]) || !char.IsUpper(arr[1]))
                    {
                        if (char.IsLower(arr[0]))
                        {
                            arr[0] = char.ToUpper(arr[0]);
                        }
                        if (char.IsLower(arr[1]))
                        {
                            arr[1] = char.ToUpper(arr[1]);
                        }
                        if (!char.IsLetter(arr[0]) || !char.IsLetter(arr[1]))
                        {
                            if (new AlertDialog("General error", "A character in the search index was not a letter. Please revise.").ShowDialog() == DialogResult.OK)
                            {
                                return;
                            }
                        }
                        filterEditColBox.Text = $"{arr[0]}{arr[1]}";
                    }
                }
            }
            filterEditColBox.Refresh();
        }

        private void ChangeCheck(object s, EventArgs e)
        {
            rangeMinMatchLbl.Text = "               Value:";
            rangeMaxLbl.Enabled = false;
            rangeMaxBox.Enabled = false;
            rangeMaxLbl.Visible = false;
            rangeMaxBox.Visible = false;
            foreach (CheckBox check in OpBoxes)
            {
                check.Checked = false;
                if (((CheckBox)s).Equals(check))
                {
                    check.Checked = true;
                    switch (check.Name)
                    {
                        case "rangeChkBox":
                            checkedType = Filter.Type.Ranged;
                            rangeMinMatchLbl.Text = "Minimum value:";
                            rangeMaxBox.Enabled = true;
                            rangeMaxLbl.Enabled = true;
                            rangeMaxLbl.Visible = true;
                            rangeMaxBox.Visible = true;
                            break;
                        case "matchBox":
                            checkedType = Filter.Type.Equal;
                            break;
                        case "greaterChkBox":
                            checkedType = Filter.Type.Greater;
                            break;
                        case "greaterEqualChkBox":
                            checkedType = Filter.Type.GreaterOrEqual;
                            break;
                        case "lessEqualChkBox":
                            checkedType = Filter.Type.LesserOrEqual;
                            break;
                        case "lesserChkBox":
                            checkedType = Filter.Type.Lesser;
                            break;
                        case "notEqualChkBox":
                            checkedType = Filter.Type.NotEqual;
                            break;
                        case "startsWithChkBox":
                            checkedType = Filter.Type.StartsWith;
                            break;
                        case "containsChkBox":
                            checkedType = Filter.Type.Contains;
                            break;
                    }
                }
            }
        }

        private void DisableChecks (object s, EventArgs e)
        {
            numChkBox.Checked = false;
            stringChkBox.Checked = false;
            daysOldChkBox.Checked = false;
            switch (((CheckBox)s).Name)
            {
                case "numChkBox":
                    numChkBox.Checked = true;
                    selectedInput = Filter.InputType.Numeric;
                    foreach (CheckBox opbox in OpBoxes)
                    {
                        opbox.Enabled = true;
                        if (opbox.Equals(startsWithChkBox) || opbox.Equals(containsChkBox))
                        {
                            opbox.Enabled = false;
                        }
                    }
                    break;

                case "daysOldChkBox":
                    daysOldChkBox.Checked = true;
                    selectedInput = Filter.InputType.DaysOld;
                    foreach (CheckBox opbox in OpBoxes)
                    {
                        opbox.Enabled = true;
                        if (opbox.Equals(startsWithChkBox) || opbox.Equals(containsChkBox))
                        {
                            opbox.Enabled = false;
                        }
                    }
                    break;

                case "stringChkBox":
                    stringChkBox.Checked = true;
                    selectedInput = Filter.InputType.String;
                    foreach (CheckBox opbox in OpBoxes)
                    {
                        opbox.Enabled = true;
                        if (opbox.Equals(rangeChkBox) || opbox.Equals(greaterChkBox) || opbox.Equals(greaterEqualChkBox) || opbox.Equals(lessEqualChkBox) || opbox.Equals(lesserChkBox))
                        {
                            opbox.Enabled = false;
                        }
                    }
                    break;
            }
            ChangeCheck(matchChkBox, null);
        }

        private bool CheckChars (char[] input)
        {
            if (input.Length > 2)
            {
                if (new AlertDialog("General error", "This application was not built to handle columns about ZZ. Contact support.").ShowDialog() == DialogResult.OK)
                {
                    columnBox.Text = $"{input[0]}{input[1]}";
                    return false;
                }
            }
            else if (input.Length == 1)
            {
                if (!char.IsUpper(input[0]))
                {
                    if (char.IsLower(input[0]))
                    {
                        input[0] = char.ToUpper(input[0]);
                    }
                    else
                    {
                        if (new AlertDialog("General error", "A character in the search index was not a letter. Please revise.").ShowDialog() == DialogResult.OK)
                        {
                            return false;
                        }
                    }
                }
                columnBox.Text = $"{input[0]}";
            }
            else
            {
                if (!char.IsUpper(input[0]) || !char.IsUpper(input[1]))
                {
                    if (char.IsLower(input[0]))
                    {
                        input[0] = char.ToUpper(input[0]);
                    }
                    if (char.IsLower(input[1]))
                    {
                        input[1] = char.ToUpper(input[1]);
                    }
                    if (!char.IsLetter(input[0]) || !char.IsLetter(input[1]))
                    {
                        if (new AlertDialog("General error", "A character in the search index was not a letter. Please revise.").ShowDialog() == DialogResult.OK)
                        {
                            return false;
                        }
                    }
                    columnBox.Text = $"{input[0]}{input[1]}";
                }
            }
            return true;
        }
    }
}
