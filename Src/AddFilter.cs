using System;
using System.IO;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class AddFilter : Form
    {
        public Filter FilterToPass = new Filter();
        readonly SaveFileDialog saveFileDialog = new SaveFileDialog();
        readonly string inFileName;
        Filter.Type checkedType = Filter.Type.EqualTo;
        Filter.OutputType selectedOutput = Filter.OutputType.None;
        Filter.InputType selectedInput = Filter.InputType.Numeric;
        readonly Type inType = typeof(Filter.InputType);
        readonly Type opType = typeof(Filter.Type);
        readonly Type editType = typeof(Filter.OutputType);

        public AddFilter(Filter filter, string name)
        {
            InitializeComponent();
            inFileName = name;
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Filter = "CSV File|*.csv";
            saveFileDialog.OverwritePrompt = false;

            saveAllChkBox.Click += SaveAllChkBox_Click;

            filterInputDropBox.Items.AddRange(Enum.GetNames(inType));
            filterOpDropBox.Items.AddRange(Enum.GetNames(opType));
            filterEditDropBox.Items.AddRange(Enum.GetNames(editType));
            filterEditDropBox.SelectedIndex = 0;

            MinimizeBox = MaximizeBox = false;

            if (filter.DisplayName != "null")
            {
                filterInputDropBox.SelectedItem = Enum.GetName(inType, filter.SelectedInput);
                filterOpDropBox.SelectedItem = Enum.GetName(opType, filter.SelectedType);
                filterEditDropBox.SelectedItem = Enum.GetName(editType, filter.SelectedOutput);
                saveAllChkBox.Checked = filter.SaveAll;
                saveBtn.Enabled = columnBox.Enabled = true;

                matchBox.Text = filter.ValueMatch;
                rangeMaxBox.Enabled = rangeMaxBox.Visible = checkedType == Filter.Type.WithinRange;
                rangeMaxBox.Text = filter.ValueMax;
                filterEditColBox.Text = filter.EditColumn;
                filterEditValBox.Text = filter.EditValue;
                editHeaderNameBox.Text = filter.EditHeaderName;
                columnBox.Text = filter.SelectedColumn;
            }
            else
            {
                filterInputDropBox.SelectedItem = Enum.GetName(inType, Main.AppSettings.DefaultInputType);
                filterOpDropBox.SelectedItem = Enum.GetName(opType, Main.AppSettings.DefaultType);
            }
            FilterToPass = filter;
        }

        private void FilterDropBox_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox thisBox = (ComboBox)sender;
            if (e.KeyData >= Keys.D1 && e.KeyData <= Keys.D9)
            {
                KeysConverter kc = new KeysConverter();
                int keyToInt = int.Parse(kc.ConvertToString(e.KeyData));
                if (keyToInt - 1 < thisBox.Items.Count)
                {
                    thisBox.SelectedIndex = keyToInt - 1;
                    thisBox.Refresh();
                }
            }
            if (e.KeyData >= Keys.NumPad1 && e.KeyData <= Keys.NumPad9)
            {
                if (e.KeyValue - 97 < thisBox.Items.Count)
                {
                    thisBox.SelectedIndex = e.KeyValue - 97;
                    thisBox.Refresh();
                }
            }
        }

        private void SaveAllChkBox_Click(object sender, EventArgs e)
        {
            FilterToPass.SaveAll = saveAllChkBox.Checked = !FilterToPass.SaveAll;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = Main.AppSettings.OutputLocation;
            Directory.CreateDirectory(saveFileDialog.InitialDirectory);

            saveFileDialog.FileName = selectedInput != Filter.InputType.LineRemover && checkedType == Filter.Type.WithinRange ?
                $"{inFileName}-{columnBox.Text}_within_{matchBox.Text}_to_{rangeMaxBox.Text}.{Enum.GetName(inType, selectedInput)}.csv" : selectedInput == Filter.InputType.LineRemover && checkedType == Filter.Type.WithinRange ?
                $"{inFileName}-remove_{matchBox.Text}_to_{rangeMaxBox.Text}.{Enum.GetName(inType, selectedInput)}.csv" : selectedInput == Filter.InputType.LineRemover && checkedType != Filter.Type.WithinRange ?
                $"{inFileName}-remove_{checkedType}_{matchBox.Text}.{Enum.GetName(inType, selectedInput)}.csv" : $"{inFileName}-{columnBox.Text}_{checkedType}_{matchBox.Text}.{Enum.GetName(inType, selectedInput)}.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;
                FilterToPass.DisplayName = checkedType == Filter.Type.EqualTo ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} equals \"{matchBox.Text}\"" : checkedType == Filter.Type.NotEqualTo ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} does not equal \"{matchBox.Text}\"" : checkedType == Filter.Type.GreaterThan ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} is more than \"{matchBox.Text}\"" : checkedType == Filter.Type.LesserThan ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} is less than \"{matchBox.Text}\"" : checkedType == Filter.Type.GreaterThanOrEqualTo ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} is more than or equal to \"{matchBox.Text}\"" : checkedType == Filter.Type.LessThanOrEqualTo ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} is less than or equal to \"{matchBox.Text}\"" : checkedType == Filter.Type.StartsWith ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} starts with \"{matchBox.Text}\"" : checkedType == Filter.Type.Contains ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} contains \"{matchBox.Text}\"" : checkedType == Filter.Type.WithinRange && selectedInput == Filter.InputType.LineRemover ?
                    $"Remove lines \"{matchBox.Text}\" through \"{rangeMaxBox.Text}\"" : checkedType == Filter.Type.WithinRange ?
                    $"Type: {Enum.GetName(inType, selectedInput)}; Column {columnBox.Text} greater than \"{matchBox.Text}\" but less than \"{rangeMaxBox.Text}\"" : "";

                FilterToPass.ValueMatch = matchBox.Text;
                FilterToPass.ValueMax = checkedType == Filter.Type.WithinRange ? rangeMaxBox.Text : null;
                FilterToPass.SelectedColumn = columnBox.Text;
                FilterToPass.OutputFile = savePath;
                FilterToPass.SkippedHeader = false;
                FilterToPass.SelectedType = checkedType;
                FilterToPass.EditHeaderName = editHeaderNameBox.Text;
                FilterToPass.EditColumn = selectedOutput > Filter.OutputType.None ? filterEditColBox.Text : null;
                FilterToPass.EditValue = selectedOutput > Filter.OutputType.None ? filterEditValBox.Text : null;
                FilterToPass.SelectedOutput = selectedOutput;
                FilterToPass.SelectedInput = selectedInput;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void rangeMinMatchBox_TextChanged(object sender, EventArgs e)
        {
            rangeMaxBox.Enabled = checkedType == Filter.Type.WithinRange && matchBox.TextLength > 0;
            columnBox.Enabled = checkedType != Filter.Type.WithinRange && matchBox.TextLength > 0;
            saveAllChkBox.Enabled = saveBtn.Enabled = rangeMaxBox.TextLength > 0 && selectedInput == Filter.InputType.LineRemover;
        }

        private void rangeMaxBox_TextChanged(object sender, EventArgs e)
        {
            columnBox.Enabled = rangeMaxBox.TextLength > 0;
            saveAllChkBox.Enabled = saveBtn.Enabled = rangeMaxBox.TextLength > 0 && selectedInput == Filter.InputType.LineRemover;
        }

        private void columnBox_TextChanged(object sender, EventArgs e)
        {
            columnBox.Text = columnBox.TextLength > 0 ? CheckChars(columnBox.Text.ToCharArray()) : "";
            columnBox.Select(columnBox.TextLength, 0);
            filterEditDropBox.Enabled = columnBox.TextLength > 0 && selectedInput != Filter.InputType.LineRemover;
            saveAllChkBox.Enabled = saveBtn.Enabled = columnBox.TextLength > 0;
            columnBox.Refresh();
        }

        private void filterEditColBox_TextChanged(object sender, EventArgs e)
        {
            filterEditColBox.Text = filterEditColBox.TextLength > 0 ? CheckChars(filterEditColBox.Text.ToCharArray()) : "";
            filterEditColBox.Refresh();
            filterEditValBox.Enabled = filterEditColBox.TextLength > 0;
        }

        private void filterEditValBox_TextChanged(object sender, EventArgs e)
        {
            saveBtn.Enabled = saveAllChkBox.Enabled = filterEditValBox.TextLength > 0;
        }

        private string CheckChars(char[] input)
        {
            return input.Length == 2 && char.IsLetter(input[0]) && char.IsLetter(input[1]) ?
                $"{char.ToUpper(input[0])}{char.ToUpper(input[1])}" : input.Length == 1 && char.IsLetter(input[0]) ?
                $"{char.ToUpper(input[0])}" : "";
        }

        private void filterInputDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterInputDropBox.SelectedIndex > -1)
            {
                selectedInput = (Filter.InputType)Enum.Parse(inType, filterInputDropBox.SelectedItem.ToString());
                filterOpDropBox.Items.Clear();
                filterOpDropBox.Items.AddRange(Enum.GetNames(opType));

                if (selectedInput < Filter.InputType.String)
                {
                    for (int i = 0; i < (int)Filter.Type.EqualTo; i++)
                    {
                        filterOpDropBox.Items.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = (int)Filter.Type.GreaterThan; i <= (int)Filter.Type.WithinRange; i++)
                    {
                        filterOpDropBox.Items.RemoveAt((int)Filter.Type.GreaterThan);
                    }
                }
            }
            filterEditDropBox.Enabled = columnBox.Enabled = columnBox.Visible = columnLbl.Visible = columnLbl.Enabled = selectedInput != Filter.InputType.LineRemover;
            filterOpDropBox.SelectedIndex = 0;
            filterOpDropBox.Refresh();
        }

        private void filterOpDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedType = (Filter.Type)Enum.Parse(opType, filterOpDropBox.SelectedItem.ToString());
            rangeMinMatchLbl.Text = checkedType == Filter.Type.WithinRange ? "Minimum value:" : "               Value:";
            rangeMaxLbl.Visible =
                rangeMaxLbl.Enabled =
                rangeMaxBox.Enabled =
                rangeMaxBox.Visible =
                checkedType == Filter.Type.WithinRange;
        }

        private void filterEditDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOutput = (Filter.OutputType)Enum.Parse(editType, filterEditDropBox.SelectedItem.ToString());
            editHeaderNameBox.Text = selectedOutput == Filter.OutputType.Edit ? "Unchanged" : selectedOutput == Filter.OutputType.Insert ? "NewValue" : selectedOutput == Filter.OutputType.Copy ? "Unchanged" : "";
            filterEditColBox.Text = selectedOutput == Filter.OutputType.Copy ? columnBox.Text : "";
            filterEditValBox.Text = "";
            filterEditNewValueLbl.Text = selectedOutput == Filter.OutputType.Copy ? "To column:" : "New Value:";
            filterEditNewValueLbl.Location = selectedOutput == Filter.OutputType.Copy ? new System.Drawing.Point(127, filterEditNewValueLbl.Location.Y) : new System.Drawing.Point(16, filterEditNewValueLbl.Location.Y);
            filterEditLbl.Text = selectedOutput == Filter.OutputType.Copy ? "Copy value from column:" : "When a match is made, set column:";
            filterEditLbl.Location = selectedOutput == Filter.OutputType.Copy ? new System.Drawing.Point(62, filterEditLbl.Location.Y) : new System.Drawing.Point(16, filterEditLbl.Location.Y);
            filterEditValBox.Location = selectedOutput == Filter.OutputType.Copy ? new System.Drawing.Point(194, filterEditValBox.Location.Y) : new System.Drawing.Point(80, filterEditValBox.Location.Y);
            filterEditValBox.Size = selectedOutput == Filter.OutputType.Copy ? new System.Drawing.Size(36, filterEditValBox.Size.Height) : new System.Drawing.Size(150, filterEditValBox.Size.Height);
            saveBtn.Enabled = saveAllChkBox.Enabled = selectedOutput == Filter.OutputType.None && columnBox.TextLength > 0;
            filterEditColBox.Enabled = filterEditValBox.Enabled = editHeaderNameBox.Enabled = selectedOutput > Filter.OutputType.None;
        }
    }
}