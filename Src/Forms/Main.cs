using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Main : Form
    {
        public static List<Filter> Filters = new List<Filter>();
        public static SettingsStore AppSettings = new SettingsStore();
        public static string AppSettingsSavePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\CSVFU_Excel\Settings.dat";
        public Filter filterToEdit;
        FileInfo openedFile;
        string mergeFilePath;
        bool mergeFiles = false;
        readonly OpenFileDialog openDialog = new OpenFileDialog();
        readonly SaveFileDialog saveDialog = new SaveFileDialog();

        public Main()
        {
            InitializeComponent();

            AppSettings.Load();
            if (AppSettings.IsDefault)
            {
                settingsBtn_Click(null, null);
            }
           
            if(Filters.Count > 0)
            {
                filterListBox.Enabled = true;
                foreach(Filter filter in Filters)
                {
                    filterListBox.Items.Add(filter.DisplayName);
                }
            }
            openDialog.FileName = "csvFile.csv";
            openDialog.DefaultExt = ".csv";
            openDialog.Filter = "CSV Files|*.csv";
            openDialog.InitialDirectory = AppSettings.InputLocation;
            saveDialog.FileName = $"{openDialog.SafeFileName.Substring(0, openDialog.SafeFileName.Length - 4)}-merged.csv";
            saveDialog.DefaultExt = ".csv";
            saveDialog.Filter = "CSV Files|*.csv";
            saveDialog.InitialDirectory = AppSettings.InputLocation;
            if (!Directory.Exists(openDialog.InitialDirectory))
            {
                Directory.CreateDirectory(openDialog.InitialDirectory);
            }
            MinimizeBox = 
                MaximizeBox = 
                doRemoveBtn.Enabled = 
                loadFiltersBtn.Enabled = 
                saveFiltersBtn.Enabled = 
                clearFilterListBtn.Enabled = 
                RemoveBtn.Enabled = 
                editBtn.Enabled = 
                addBtn.Enabled = false;

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
                displaySize = sizeKB > 2000 ? $"{sizeMB.ToString("0.00")} MB" : $"{sizeKB.ToString("0.00")} KB";
                csvOpenFileInfo.Text = $"Opened file {openedFile.Name} Size: {displaySize}";
                clearFilterListBtn.Enabled = RemoveBtn.Enabled = editBtn.Enabled = addBtn.Enabled = loadFiltersBtn.Enabled = mergeOutputChkBox.Enabled = saveFiltersBtn.Enabled = true;
                doRemoveBtn.Enabled = filterListBox.Items.Count > 0 && openedFile != null;
            }
        }

        private void doRemoveBtn_Click(object sender, EventArgs e)
        {
            if (Filters.Count > 0)
            {
                progressDialog dialog = new progressDialog(openedFile, mergeFilePath, mergeFiles, Filters);
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
            doRemoveBtn.Enabled = 
                filterListBox.Items.Count > 0 && openedFile != null;
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
            doRemoveBtn.Enabled = filterListBox.Items.Count > 0 && openedFile != null;
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (filterListBox.SelectedIndex != -1)
            {
                Filter filterToRem = null;
                foreach (Filter filter in Filters)
                {
                    filterToRem = filter.DisplayName.Equals(filterListBox.SelectedItem) ? filter : filterToRem;
                }
                if (!filterToRem.Equals(null))
                {
                    Filters.Remove(filterToRem);
                    filterListBox.Items.RemoveAt(filterListBox.SelectedIndex);
                    filterListBox.Refresh();
                }
            }
            doRemoveBtn.Enabled = filterListBox.Items.Count > 0 && openedFile != null;
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
                doRemoveBtn.Enabled = filterListBox.Items.Count > 0 && openedFile != null;
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
            doRemoveBtn.Enabled = filterListBox.Items.Count > 0 && openedFile != null;
        }

        private void mergeOutputChkBox_CheckedChanged(object sender, EventArgs e)
        {
            mergeFiles = 
                mergeOutputLbl.Enabled = 
                mergeOutputLbl.Visible = 
                mergeOutputBtn.Enabled = 
                mergeOutputBtn.Visible = mergeOutputChkBox.Checked;
        }

        private void mergeOutputBtn_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                mergeFilePath = saveDialog.FileName;
                FileInfo fileInfo = new FileInfo(mergeFilePath);
                mergeOutputLbl.Text = $"{fileInfo.Name} selected to merge outputs to";
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Settings dialog = new Settings();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Dispose();
            }
        }

        private void clearFilterListBtn_Click(object sender, EventArgs e)
        {
            CancelDialog cancelDialog = new CancelDialog();
            cancelDialog.EditLblText = "clear the filter list?";
            if(Filters.Count > 0 && cancelDialog.ShowDialog() == DialogResult.OK)
            {
                Filters = new List<Filter>();
                filterListBox.Items.Clear();
            }
        }
    }

    public class SettingsStore
    {
        public string InputLocation { get; set; }
        public string OutputLocation { get; set; }
        public Filter.InputType DefaultInputType { get; set; }
        public Filter.Type DefaultType { get; set; }
        public string DefaultFilterList { get; set; }
        public bool IsDefault { get; set; }

        public void Load()
        {
            if (File.Exists(Main.AppSettingsSavePath))
            {
                JsonParser jsonString = JsonParser.Deserialize(File.ReadAllText(Main.AppSettingsSavePath));
                Main.AppSettings = jsonString.Value.ToObject<SettingsStore>();
                Main.Filters = string.IsNullOrEmpty(Main.AppSettings.DefaultFilterList) ? Main.Filters : JsonParser.Deserialize(Main.AppSettings.DefaultFilterList).Value.ToObject<List<Filter>>();
                Main.AppSettings.IsDefault = false;
            }
            else
            {
                Main.AppSettings.InputLocation = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CSVs";
                Main.AppSettings.OutputLocation = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\CSVs\FilterOutputs";
                Main.AppSettings.DefaultInputType = Filter.InputType.Numeric;
                Main.AppSettings.DefaultType = (Filter.Type)2;
                Main.AppSettings.DefaultFilterList = "";
                Main.AppSettings.IsDefault = true;
            }
        }

        public void Save()
        {
            if(!Directory.Exists(new FileInfo(Main.AppSettingsSavePath).Directory.FullName))
            {
                Directory.CreateDirectory(new FileInfo(Main.AppSettingsSavePath).Directory.FullName);
            }
            File.WriteAllText(Main.AppSettingsSavePath, JsonParser.Serialize(JsonParser.FromValue(Main.AppSettings)));
        }
    }

    public class Filter
    {
        public enum Type
        {
            StartsWith,
            Contains,
            EqualTo,
            NotEqualTo,
            GreaterThan,
            GreaterThanOrEqualTo,
            LesserThan,
            LessThanOrEqualTo,
            WithinRange
        }
        public enum InputType
        {
            Numeric,
            DaysOld,
            FromDate,
            LineRemover,
            String
        }
        public enum OutputType
        {
            None,
            Edit,
            Insert,
            Copy
        }

        public string ValueMax { get; set; }
        public string ValueMatch { get; set; }
        public string SelectedColumn { get; set; }
        public string DisplayName { get; set; }
        public string DaysOldValue { get; set; }
        public string EditHeaderName { get; set; }
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