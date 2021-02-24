using System;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class Settings : Form
    {
        FolderBrowserDialog dirSelectDialog;
        public Settings()
        {
            InitializeComponent();

            MaximizeBox = false;
            MinimizeBox = false;

            inputLocationLbl.Text = $"Input directory: {Main.AppSettings.InputLocation}";
            outputLocationLbl.Text = $"Output directory: {Main.AppSettings.OutputLocation}";
            filterInputDefaultDropbox.Items.AddRange(Enum.GetNames(typeof(Filter.InputType)));
            filterOpDefaultDropBox.Items.AddRange(Enum.GetNames(typeof(Filter.Type)));
            filterInputDefaultDropbox.SelectedIndex = Main.AppSettings.IsDefault ? 0 : (int)Main.AppSettings.DefaultInputType;
        }

        private FolderBrowserDialog initDialog()
        {
            dirSelectDialog = new FolderBrowserDialog();
            dirSelectDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dirSelectDialog.ShowNewFolderButton = true;
            return dirSelectDialog;
        }

        private void inputLocationBtn_Click(object sender, EventArgs e)
        {
            dirSelectDialog = initDialog();
            if (dirSelectDialog.ShowDialog() == DialogResult.OK)
            {
                Main.AppSettings.InputLocation = dirSelectDialog.SelectedPath;
                inputLocationLbl.Text = $"Input directory: {dirSelectDialog.SelectedPath}";
            }
            dirSelectDialog.Dispose();
        }

        private void outputLocationBtn_Click(object sender, EventArgs e)
        {
            dirSelectDialog = initDialog();
            if (dirSelectDialog.ShowDialog() == DialogResult.OK)
            {
                Main.AppSettings.OutputLocation = dirSelectDialog.SelectedPath;
                outputLocationLbl.Text = $"Output directory: {dirSelectDialog.SelectedPath}";
            }
            dirSelectDialog.Dispose();
        }

        private void setDefaultListBtn_Click(object sender, EventArgs e)
        {
            if(Main.Filters.Count > 0)
            {
                Main.AppSettings.DefaultFilterList = JsonParser.Serialize(JsonParser.FromValue(Main.Filters));
            }
        }

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            Main.AppSettings.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void filterInputDefaultDropbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterInputDefaultDropbox.SelectedIndex > -1)
            {
                Main.AppSettings.DefaultInputType = (Filter.InputType)Enum.Parse(typeof(Filter.InputType), filterInputDefaultDropbox.SelectedItem.ToString());
                filterOpDefaultDropBox.Items.Clear();
                filterOpDefaultDropBox.Items.AddRange(Enum.GetNames(typeof(Filter.Type)));

                if (Main.AppSettings.DefaultInputType < Filter.InputType.String)
                {
                    for (int i = 0; i < (int)Filter.Type.EqualTo; i++)
                    {
                        filterOpDefaultDropBox.Items.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = (int)Filter.Type.GreaterThan; i <= (int)Filter.Type.WithinRange; i++)
                    {
                        filterOpDefaultDropBox.Items.RemoveAt((int)Filter.Type.GreaterThan);
                    }
                }
            }
            if (Main.AppSettings.IsDefault)
            {
                filterOpDefaultDropBox.SelectedIndex = 0;
            }
            else
            {
                filterOpDefaultDropBox.SelectedItem = Enum.GetName(typeof(Filter.Type), Main.AppSettings.DefaultType);
            }
            filterOpDefaultDropBox.Refresh();

        }

        private void filterOpDefaultDropBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.AppSettings.DefaultType = (Filter.Type)Enum.Parse(typeof(Filter.Type), filterOpDefaultDropBox.SelectedItem.ToString());
        }
    }
}
