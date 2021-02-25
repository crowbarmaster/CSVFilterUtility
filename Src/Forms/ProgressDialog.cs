using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class progressDialog : Form
    {
        FileInfo InFile;
        List<Filter> Filters;
        long fileSize;
        ParseCSV csvParser;
        Progress<double> Progress;
        TextWriter mergeWriter;
        bool MergeFiles = false;
        int indexCount = 0;

        public progressDialog(FileInfo inFile, string mergePath, bool mergeFiles, List<Filter> filters)
        {
            InitializeComponent();

            progressBar.Maximum = 1000;
            Shown += progressDialog_onShown;
            InFile = inFile;
            Filters = filters;
            fileSize = inFile.Length;
            MergeFiles = mergeFiles;

            MaximizeBox = false;
            MinimizeBox = false;

            if (mergeFiles)
            {
                mergeWriter = new StreamWriter(mergePath);
            }
            csvParser = new ParseCSV();
            Progress = new Progress<double>();
            Progress.ProgressChanged += progressChanged;
        }


        public async void progressDialog_onShown(object s, EventArgs e)
        {
            progressBar.Value = 0;
            indexCount = await Task.Run(() => csvParser.DoRemove(InFile, Filters, Progress));
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CancelDialog dialog = new CancelDialog();
            if (cancelBtn.Text == "Close")
            {
                Close();
            }
            else
            {
                dialog.ShowDialog();
                if (dialog.DialogResult == DialogResult.OK)
                {
                    csvParser.KillFlag = true;
                    Close();
                }
            }
        }

        private void progressChanged(object s, double value)
        {
            {
                double val = ((value / fileSize) * 1000);
                double part = value / 1024 / 1024;
                double whole = fileSize / 1024 / 1024;
                progressLbl.Text = $"Progress: {part:0.00} of {whole:0.00} MB";
                progressBar.Value = (int)val;
                bool waiting = true;
                if (value == fileSize)
                {
                    while (waiting)
                    {
                        if (!csvParser.StopWatch.IsRunning)
                        {
                            if (MergeFiles)
                            {
                                bool wroteHeader = false;
                                progressLbl.Text = "Merging filters to selected CSV file, please wait!";
                                foreach (Filter filter in Filters)
                                {
                                    int index = 0;
                                    TextReader reader = new StreamReader(filter.OutputFile);
                                    string readLine;
                                    while ((readLine = reader.ReadLine()) != null)
                                    {
                                        if (!wroteHeader)
                                        {
                                            mergeWriter.WriteLine(readLine);
                                            wroteHeader = true;
                                        }
                                        else
                                        {
                                            if (index > 0)
                                            {
                                                mergeWriter.WriteLine(readLine);
                                            }
                                        }
                                        index++;
                                    }
                                    reader.Close();
                                }
                                MergeFiles = false;
                                mergeWriter.Flush();
                                mergeWriter.Close();
                            }
                            waiting = false;
                            int LPS = (int)(csvParser.curIndex / csvParser.StopWatch.Elapsed.TotalSeconds);
                            progressLbl.Text = $@"Process completed in {csvParser.StopWatch.Elapsed.ToString("mm")} minutes and {csvParser.StopWatch.Elapsed.ToString("ss")} seconds ({LPS} LPS)";
                            cancelBtn.Text = "Close";
                        }
                    }
                }
                if (csvParser.Aborted)
                {
                    progressLbl.Text = $@"Process completed in error! Check filters or input file, and try again! (Line {csvParser.curIndex})";
                    cancelBtn.Text = "Close";
                }
            }
        }
    }
}

