using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    class ParseCSV
    {
        public FileStream inputStream;
        public TextReader inputReader;
        public bool KillFlag;
        public bool Aborted = false;
        public Stopwatch StopWatch;
        public int curIndex = 0;
        IProgress<double> Progress;

        public int DoRemove(FileInfo inFileInfo, List<Filter> filters, IProgress<double> progress)
        {
            StopWatch = new Stopwatch();
            StopWatch.Start();
            inputStream = File.OpenRead(inFileInfo.FullName);
            inputReader = new StreamReader(inputStream);
            Progress = progress;
            long fileSize = inputStream.Length;
            string curLine = null;

            KillFlag = false;
            while (!KillFlag)
            {
                progress.Report(inputStream.Position);
                if (curLine != null)
                {
                    curIndex++;
                }

                foreach (Filter filter in filters)
                {
                    if (filter.FilterWriter == null)
                    {
                        try
                        {
                            filter.FilterWriter = new StreamWriter(filter.OutputFile, false);
                        }
                        catch (Exception)
                        {
                            ThrowErrorMsg("Error opening file!", $"Please verify that the file for filter {filter.DisplayName} is not opened in anything!");
                            filter.KillFlag = true;
                            return 0;
                        }
                    }
                    FilterLine(filter, curLine);
                }


                if (inputStream.Position == fileSize && string.IsNullOrEmpty(curLine) || KillFlag)
                {
                    foreach (Filter filter in filters)
                    {
                        filter.KillFlag = true;
                        try
                        {
                            filter.FilterWriter.Flush();
                        }
                        catch (Exception) { }

                        filter.FilterWriter.Close();
                        filter.FilterWriter.Dispose();
                        filter.FilterWriter = null;
                        filter.SkippedHeader = false;
                    }
                    KillFlag = true;
                }
                curLine = inputReader.ReadLine();
            }
            StopWatch.Stop();

            Console.WriteLine($"Original file contained {curIndex} lines.\n Completed in {StopWatch.Elapsed.TotalMinutes} minutes.");
            inputReader.Close();
            inputStream.Close();
            inputReader.Dispose();
            inputStream.Dispose();
            inputReader = null;
            inputStream = null;
            return curIndex;
        }

        private void FilterLine(Filter filter, string input)
        {
            char separatorChar = ','; // Define a comma as the split char.
            Regex regx = new Regex(separatorChar + "(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))"); // This regex expression checks for and ignores commas and quotes wrapped in double-quotes.

            if (filter.FilterWriter == null)
            {
                filter.FilterWriter = new StreamWriter(filter.OutputFile, false);
            }

            if (!string.IsNullOrEmpty(input))
            {
                if (!filter.SkippedHeader) // We need to skip the header as part of index count.
                {
                    filter.SkippedHeader = true; // Changed to true to keep from skipping data.
                    if (filter.SelectedOutput > Filter.OutputType.None)
                    {
                        string[] line = regx.Split(input); // split the line to string array.
                        int columnToEdit = ParseCharsToInt(filter.EditColumn.ToCharArray());
                        if (filter.SelectedOutput == Filter.OutputType.Edit)
                        {
                            if (filter.EditHeaderName != "Unchanged")
                            {
                                line[columnToEdit] = filter.EditHeaderName;
                                input = ArrayToString(line, ',');
                            }
                        }
                        if(filter.SelectedOutput == Filter.OutputType.Insert)
                        {
                            string[] newLine = new string[line.Length + 1];
                            if (columnToEdit <= line.Length)
                            {
                                Array.Copy(line, newLine, columnToEdit > 0 ? columnToEdit - 1 : 0);
                                newLine[columnToEdit] = filter.EditHeaderName;
                                Array.Copy(line, columnToEdit, newLine, columnToEdit + 1, line.Length - columnToEdit);
                            }
                            else
                            {
                                ThrowErrorMsg("Error! Selected column to insert is beyond acceptable bounds", "An inserted column must be no more than the last empty column!");
                            }
                            input = ArrayToString(newLine, ',');
                        }
                        if(filter.SelectedOutput == Filter.OutputType.Copy)
                        {
                            int colToWrite = ParseCharsToInt(filter.EditValue.ToCharArray());
                            bool testWrite = filter.EditHeaderName != "Unchanged";
                            if (colToWrite == line.Length)
                            {
                                string[] newLine = new string[line.Length + 1];

                                Array.Copy(line, newLine, line.Length);
                                newLine[colToWrite] = testWrite ? filter.EditHeaderName : line[colToWrite];

                                input = ArrayToString(newLine, ',');
                            }
                            else
                            {
                                line[colToWrite] = testWrite ? filter.EditHeaderName : line[colToWrite];
                                input = ArrayToString(line, ',');
                            }
                        }
                    }
                    filter.FilterWriter.WriteLine(input); // Write header to new file.
                    filter.Index++; // Increase dest index by one.
                }
                else
                {

                    string[] line = regx.Split(input); // split the line to string array.
                    int columnToSearch = ParseCharsToInt(filter.SelectedColumn.ToCharArray());
                    if (line.Length <= columnToSearch)
                    {
                        ThrowErrorMsg("Error Parsing CSV.", $"The selected column \"{filter.SelectedColumn}\" in filter \"{filter.DisplayName}\" is not found in this CSV file!");
                        filter.KillFlag = true;
                        return;
                    }
                    bool shouldWrite = PerformFilter(filter.SelectedInput, filter.SelectedType, filter.ValueMatch, filter.ValueMax, line[columnToSearch]);
                    if (KillFlag)
                    {
                        filter.KillFlag = true;
                        return;
                    }

                    if (shouldWrite)
                    {
                        if (filter.SelectedOutput == Filter.OutputType.Edit)
                        {
                            line[ParseCharsToInt(filter.EditColumn.ToCharArray())] = filter.EditValue;

                            input = ArrayToString(line, ',');
                        }

                        if (filter.SelectedOutput == Filter.OutputType.Insert)
                        {
                            int colToIns = ParseCharsToInt(filter.EditColumn.ToCharArray());
                            string[] newLine = new string[line.Length + 1];

                            if (colToIns <= line.Length)
                            {
                                Array.Copy(line, newLine, colToIns > 0 ? colToIns - 1 : 0);
                                newLine[colToIns] = filter.EditHeaderName;
                                Array.Copy(line, colToIns, newLine, colToIns + 1, line.Length - colToIns);
                            }
                            else
                            {
                                ThrowErrorMsg("Error! Selected column to insert is beyond acceptable bounds", "An inserted column must be no more than the last empty column!");
                            }
                            input = ArrayToString(newLine, ',');
                        }

                        if(filter.SelectedOutput == Filter.OutputType.Copy)
                        {
                            int colToRead = ParseCharsToInt(filter.EditColumn.ToCharArray());
                            int colToWrite = ParseCharsToInt(filter.EditValue.ToCharArray());
                            string[] newLine = new string[line.Length + 1];

                            if (colToRead >= 0 && colToWrite >= 0)
                            {
                                if(colToWrite == line.Length)
                                {
                                    Array.Copy(line, newLine, colToWrite);
                                    newLine[colToWrite] = line[colToRead];
                                    input = ArrayToString(newLine, ',');
                                }
                                else
                                {
                                    line[colToWrite] = line[colToRead];
                                    input = ArrayToString(line, ',');
                                }
                            }
                        }
                        filter.FilterWriter.WriteLine(input);
                    }

                    if (filter.SaveAll && !shouldWrite)
                    {
                        if (filter.SelectedOutput == Filter.OutputType.Insert)
                        {
                            int colToIns = ParseCharsToInt(filter.EditColumn.ToCharArray());
                            string[] newLine = new string[line.Length + 1];
                            if (colToIns <= line.Length)
                            {
                                Array.Copy(line, newLine, colToIns > 0 ? colToIns - 1 : 0);
                                newLine[colToIns] = "";
                                Array.Copy(line, colToIns, newLine, colToIns + 1, line.Length - colToIns);
                            }
                            else
                            {
                                ThrowErrorMsg("Error! Selected column to insert is beyond acceptable bounds", "An inserted column must be no more than the last empty column!");
                            }
                            input = ArrayToString(newLine, ',');
                        }
                        if (filter.SelectedOutput == Filter.OutputType.Copy)
                        {
                            int colToRead = ParseCharsToInt(filter.EditColumn.ToCharArray());
                            int colToWrite = ParseCharsToInt(filter.EditValue.ToCharArray());
                            string[] newLine = new string[line.Length + 1];

                            if (colToRead >= 0 && colToWrite >= 0)
                            {
                                if (colToWrite == line.Length)
                                {
                                    Array.Copy(line, newLine, colToWrite);
                                    newLine[colToWrite] = "";
                                    input = ArrayToString(newLine, ',');
                                }
                                else
                                {
                                    line[colToWrite] = "";
                                    input = ArrayToString(line, ',');
                                }
                            }
                        }
                        filter.FilterWriter.WriteLine(input);
                    }
                }
            }
        }

        private string ArrayToString(string[] array, char delim)
        {
            string output = "";
            foreach (string entry in array)
            {
                output += $"{entry}{delim}";
            }
            return output.Substring(0, output.Length - 1);
        }

        private int ParseCharsToInt(char[] columnChars)
        {
            int columnCharsLength = columnChars.Length;
            int multiplier;
            int columnToSearch;
            if (columnCharsLength == 2)
            {
                multiplier = columnChars[0] - 64;
                columnToSearch = (multiplier * 26) + (columnChars[1] - 65);
            }
            else
            {
                columnToSearch = columnChars[0] - 65;
            }

            return columnToSearch;
        }


        private bool PerformFilter(Filter.InputType inType, Filter.Type opType, string minMatchValue, string valMax, string compValue)
        {
            bool shouldWrite = false;
            switch (inType)
            {
                case Filter.InputType.Numeric:
                    compValue = compValue.Replace("$", "").Replace(",", "").Replace("\"", "").Trim();
                    if (double.TryParse(minMatchValue, out double value) && double.TryParse(compValue, out double columnValue))
                    {
                        switch (opType)
                        {
                            case Filter.Type.EqualTo:
                                shouldWrite = minMatchValue == compValue;
                                break;
                            case Filter.Type.NotEqualTo:
                                shouldWrite = minMatchValue != compValue;
                                break;
                            case Filter.Type.GreaterThan:
                                shouldWrite = columnValue > value;
                                break;
                            case Filter.Type.LesserThan:
                                shouldWrite = columnValue < value;
                                break;
                            case Filter.Type.GreaterThanOrEqualTo:
                                shouldWrite = columnValue >= value;
                                break;
                            case Filter.Type.LessThanOrEqualTo:
                                shouldWrite = columnValue <= value;
                                break;
                            case Filter.Type.WithinRange:
                                if (double.TryParse(valMax, out double maxValue))
                                {
                                    shouldWrite = columnValue > value && columnValue < maxValue;
                                }
                                else
                                {
                                    ThrowErrorMsg("Error parsing text into a numeric value.", $"Please check the collumn your searching contains only a '$' or '.' and numbers! (Line {curIndex})");
                                    KillFlag = true;
                                    return false;
                                }
                                break;
                        }
                    }
                    else
                    {
                        ThrowErrorMsg("Error parsing text into a numeric value.", $"Please check the collumn your searching contains only a '$' or '.' and numbers! (Line {curIndex})");
                        KillFlag = true;
                        return false;
                    }
                    break;
                case Filter.InputType.String:
                    switch (opType)
                    {
                        case Filter.Type.EqualTo:
                            shouldWrite = compValue == minMatchValue;
                            break;
                        case Filter.Type.NotEqualTo:
                            shouldWrite = compValue != minMatchValue;
                            break;
                        case Filter.Type.StartsWith:
                            shouldWrite = compValue.StartsWith(minMatchValue);
                            break;
                        case Filter.Type.Contains:
                            shouldWrite = compValue.Contains(minMatchValue);
                            break;
                    }
                    break;
                case Filter.InputType.DaysOld:
                    TimeSpan timeToRemove = new TimeSpan(int.Parse(minMatchValue), 0, 0, 0);
                    DateTime compareDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(timeToRemove);

                    DateTime maxDate;

                    DateTime parseDate;
                    if (DateTime.TryParse(compValue, out parseDate))
                    {
                        switch (opType)
                        {
                            case Filter.Type.EqualTo:
                                shouldWrite = parseDate.Date == compareDate.Date;
                                break;
                            case Filter.Type.NotEqualTo:
                                shouldWrite = parseDate.Date != compareDate.Date;
                                break;
                            case Filter.Type.GreaterThan:
                                shouldWrite = compareDate.Date > parseDate.Date;
                                break;
                            case Filter.Type.LesserThan:
                                shouldWrite = compareDate.Date < parseDate.Date;
                                break;
                            case Filter.Type.GreaterThanOrEqualTo:
                                shouldWrite = compareDate.Date >= parseDate.Date;
                                break;
                            case Filter.Type.LessThanOrEqualTo:
                                shouldWrite = compareDate.Date <= parseDate.Date;
                                break;
                            case Filter.Type.WithinRange:
                                TimeSpan spanMax = new TimeSpan(int.Parse(valMax), 0, 0, 0);
                                maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(spanMax);
                                shouldWrite = parseDate.Date <= compareDate.Date && parseDate.Date >= maxDate.Date;
                                break;
                        }
                    }
                    else
                    {
                        ThrowErrorMsg("Error parsing text into a date value.", $"Please check the column your searching contains only dates in dd/mm/yyyy format! (Line {curIndex})");
                        KillFlag = true;
                        return false;
                    }
                    break;
            }
            return shouldWrite;
        }



        private void ThrowErrorMsg(string err, string msg)
        {
            if (new AlertDialog(err, msg).ShowDialog() == DialogResult.OK)
            {
                KillFlag = true;
                Aborted = true;
                Progress.Report(inputStream.Length);
                return;
            }
        }

    }
}
