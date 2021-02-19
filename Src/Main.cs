using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Main : Form
    {
        public Filter filterToEdit;

        FileInfo openedFile;
        TextWriter mergeWriter = null;
        bool mergeFiles = false;
        List<Filter> Filters = new List<Filter>();
        readonly OpenFileDialog openDialog = new OpenFileDialog();
        readonly SaveFileDialog saveDialog = new SaveFileDialog();

        public Main()
        {
            InitializeComponent();

            openDialog.FileName = "csvFile.csv";
            openDialog.DefaultExt = ".csv";
            openDialog.Filter = "CSV Files|*.csv";
            openDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CSVs";
            saveDialog.FileName = $"{openDialog.SafeFileName.Substring(0, openDialog.SafeFileName.Length - 4)}-merged.csv";
            saveDialog.DefaultExt = ".csv";
            saveDialog.Filter = "CSV Files|*.csv";
            saveDialog.InitialDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CSVs";
            if (!Directory.Exists(openDialog.InitialDirectory))
            {
                Directory.CreateDirectory(openDialog.InitialDirectory);
            }
            addBtn.Enabled = false;
            editBtn.Enabled = false;
            RemoveBtn.Enabled = false;
            saveFiltersBtn.Enabled = false;
            loadFiltersBtn.Enabled = false;
            doRemoveBtn.Enabled = false;

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                openedFile = new FileInfo(openDialog.FileName);
                long fileLen = openedFile.Length;
                float sizeKB = fileLen / 1024;
                float sizeMB = sizeKB / 1024;
                string displaySize;
                if (sizeKB > 2000)
                {
                    displaySize = $"{sizeMB.ToString("0.00")} MB";
                }
                else
                {
                    displaySize = $"{sizeKB.ToString("0.00")} KB";
                }
                csvOpenFileInfo.Text = $"Opened file {openedFile.Name} Size: {displaySize}";
                saveFiltersBtn.Enabled = true;
                loadFiltersBtn.Enabled = true;
                addBtn.Enabled = true;
                editBtn.Enabled = true;
                RemoveBtn.Enabled = true;
                mergeOutputChkBox.Enabled = true;
            }
        }

        private void doRemoveBtn_Click(object sender, EventArgs e)
        {
            if (Filters.Count > 0)
            {
                progressDialog dialog = new progressDialog(openedFile, mergeWriter, mergeFiles, Filters);
                dialog.ShowDialog();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddFilter filterForm = new AddFilter(new Filter(), openedFile.Name);

            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                Filters.Add(filterForm.FilterToPass);
                filterListBox.Items.Add(filterForm.FilterToPass.DisplayName);
            }
            filterListBox.Refresh();
            doRemoveBtn.Enabled = true;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (filterListBox.SelectedIndex != -1)
            {
                int index = filterListBox.SelectedIndex;
                Filter filterToEdit = null;
                foreach (Filter filter in Filters)
                {
                    if (filterListBox.SelectedItem.Equals(filter.DisplayName))
                    {
                        filterToEdit = filter;
                    }
                }
                AddFilter form = new AddFilter(filterToEdit, openedFile.Name);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Filters.Remove(filterToEdit);
                    Filters.Add(form.FilterToPass);
                    filterListBox.Items.RemoveAt(index);
                    filterListBox.Items.Insert(index, form.FilterToPass.DisplayName);
                    filterListBox.Refresh();
                }
            }
            if (filterListBox.Items.Count > 0)
            {
                doRemoveBtn.Enabled = true;
            }
            else
            {
                doRemoveBtn.Enabled = false;
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (filterListBox.SelectedIndex != -1)
            {
                Filter filterToRem = null;
                foreach (Filter filter in Filters)
                {
                    if (filter.DisplayName.Equals(filterListBox.SelectedItem))
                    {
                        filterToRem = filter;
                    }
                }
                if (!filterToRem.Equals(null))
                {
                    Filters.Remove(filterToRem);
                    filterListBox.Items.RemoveAt(filterListBox.SelectedIndex);
                    filterListBox.Refresh();
                }
            }
            if (filterListBox.Items.Count > 0)
            {
                doRemoveBtn.Enabled = true;
            }
            else
            {
                doRemoveBtn.Enabled = false;
            }
        }

        private void loadFiltersBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = @"Filter list file|*.flt";
            open.FileName = $"{openedFile.Name}.flt";
            open.Title = "Open filter list...";
            open.DefaultExt = ".flt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filterListBox.Items.Clear();
                string jsonContent = File.ReadAllText(open.FileName);
                JsonParser deSerialize = JsonParser.Deserialize(jsonContent);
                Filters = deSerialize.Value.ToObject<List<Filter>>();
                foreach (Filter filter in Filters)
                {
                    filterListBox.Items.Add(filter.DisplayName);
                }
                filterListBox.Refresh();
                doRemoveBtn.Enabled = true;
            }
        }

        private void saveFiltersBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = @"Filter list file|*.flt";
            save.FileName = $"{openedFile.Name}.flt";
            save.Title = "Save filter list as...";
            save.DefaultExt = ".flt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, JsonParser.Serialize(JsonParser.FromValue(Filters)));
            }
        }

        private void filterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterListBox.Items.Count > 0)
            {
                doRemoveBtn.Enabled = true;
            }
            else
            {
                doRemoveBtn.Enabled = false;
            }
        }

        private void mergeOutputChkBox_CheckedChanged(object sender, EventArgs e)
        {
            mergeOutputBtn.Visible = mergeOutputChkBox.Checked;
            mergeOutputBtn.Enabled = mergeOutputChkBox.Checked;
            mergeOutputLbl.Visible = mergeOutputChkBox.Checked;
            mergeOutputLbl.Enabled = mergeOutputChkBox.Checked;
            mergeFiles = true;
        }

        private void mergeOutputBtn_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                mergeWriter = new StreamWriter(saveDialog.FileName);
            }
        }
    }

    public class Filter
    {
        public enum Type
        {
            Equal,
            Ranged,
            NotEqual,
            Greater,
            GreaterOrEqual,
            Lesser,
            LesserOrEqual,
            StartsWith,
            Contains
        }
        public enum InputType
        {
            Numeric,
            String,
            DaysOld
        }
        public enum OutputType
        {
            None,
            Edit,
            Insert
        }

        public string ValueMax { get; set; }
        public string ValueMatch { get; set; }
        public string SelectedColumn { get; set; }
        public string DisplayName { get; set; }
        public string DaysOldValue { get; set; }
        public string EditColumn { get; set; }
        public string EditValue { get; set; }
        public int Index { get; set; }
        public bool SkippedHeader { get; set; }
        public bool KillFlag { get; set; }
        public bool SaveAll { get; set; }
        public string OutputFile { get; set; }
        public TextWriter FilterWriter { get; set; }
        public Type SelectedType { get; set; }
        public InputType SelectedInput { get; set; }
        public OutputType SelectedOutput { get; set; }

        public Filter()
        {
            DisplayName = "null";
        }

    }
}