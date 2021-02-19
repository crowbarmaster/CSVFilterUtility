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
        public Stopwatch StopWatch;
        public int curIndex = 0;


        public int DoRemove(FileInfo inFileInfo, List<Filter> filters, IProgress<double> progress)
        {
            StopWatch = new Stopwatch();
            StopWatch.Start();
            inputStream = File.OpenRead(inFileInfo.FullName);
            inputReader = new StreamReader(inputStream);
            long fileSize = inputStream.Length;
            string curLine = null;

            KillFlag = false;
            while (!KillFlag)
            {
                progress.Report(inputStream.Position);
                if(curLine != null)
                {
                   curIndex++;
                }

                foreach (Filter filter in filters)
                {
                    if (filter.FilterWriter == null)
                    {
                        filter.FilterWriter = new StreamWriter(filter.OutputFile, false);
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
                        catch (Exception e)
                        {

                        }
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

        void FilterLine(Filter filter, string input)
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
                    filter.SkippedHeader = true; // Changed to true to keep from skipping another round.
                    filter.FilterWriter.WriteLine(input); // Write header to new file.
                    filter.Index++; // Increase dest index by one.
                }
                else
                {

                    string[] line = regx.Split(input); // split the line to string array.

                    string col = filter.SelectedColumn;
                    char[] columnChars = col.ToCharArray();
                    int columnToSearch = ParseCharsToInt(col.ToCharArray(), line.Length);

                    if (line[columnToSearch].Contains("$"))
                    {
                        line[columnToSearch] = line[columnToSearch].Remove(line[columnToSearch].IndexOf('$'), 1);
                    }
                    if (line[columnToSearch].Contains(","))
                    {
                        line[columnToSearch] = line[columnToSearch].Remove(line[columnToSearch].IndexOf(','), 1);
                    }
                    if (line[columnToSearch].Contains("\""))
                    {
                        line[columnToSearch] = line[columnToSearch].Remove(line[columnToSearch].IndexOf('\"'), 1);
                        line[columnToSearch] = line[columnToSearch].Remove(line[columnToSearch].IndexOf('\"'), 1);
                    }
                    line[columnToSearch].Trim();
                    bool shouldWrite = false;
                    switch (filter.SelectedInput)
                    {
                        case Filter.InputType.Numeric:
                            if (double.TryParse(filter.ValueMatch, out double value) && double.TryParse(line[columnToSearch], out double columnValue))
                            {
                                switch (filter.SelectedType)
                                {
                                    case Filter.Type.Equal:
                                        shouldWrite = filter.ValueMatch == line[columnToSearch];
                                        break;
                                    case Filter.Type.NotEqual:
                                        shouldWrite = filter.ValueMatch != line[columnToSearch];
                                        break;
                                    case Filter.Type.Greater:
                                        shouldWrite = columnValue > value;
                                        break;
                                    case Filter.Type.Lesser:
                                        shouldWrite = columnValue < value;
                                        break;
                                    case Filter.Type.GreaterOrEqual:
                                        shouldWrite = columnValue >= value;
                                        break;
                                    case Filter.Type.LesserOrEqual:
                                        shouldWrite = columnValue <= value;
                                        break;
                                    case Filter.Type.Ranged:
                                        if (double.TryParse(filter.ValueMax, out double maxValue))
                                        {
                                            shouldWrite = columnValue > value && columnValue < maxValue;
                                        }
                                        else
                                        {
                                            string errMsg = "Error parsing text into a numeric value.";
                                            string msgDetail = $"Please check the collumn your searching contains only a '$' or '.' and numbers! (Line {curIndex})";
                                            if (new AlertDialog(errMsg, msgDetail).ShowDialog() == DialogResult.OK)
                                            {
                                                KillFlag = true;
                                                filter.KillFlag = true;
                                                return;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                string errMsg = "Error parsing text into a numeric value.";
                                string msgDetail = $"Please check the collumn your searching contains only a '$' or '.' and numbers! (Line {curIndex})";
                                if (new AlertDialog(errMsg, msgDetail).ShowDialog() == DialogResult.OK)
                                {
                                    KillFlag = true;
                                    filter.KillFlag = true;
                                    return;
                                }
                            }
                            break;
                        case Filter.InputType.String:
                            switch (filter.SelectedType)
                            {
                                case Filter.Type.Equal:
                                    shouldWrite = line[columnToSearch] == filter.ValueMatch;
                                    break;
                                case Filter.Type.NotEqual:
                                    shouldWrite = line[columnToSearch] != filter.ValueMatch;
                                    break;
                                case Filter.Type.StartsWith:
                                    shouldWrite = line[columnToSearch].StartsWith(filter.ValueMatch);
                                    break;
                                case Filter.Type.Contains:
                                    shouldWrite = line[columnToSearch].Contains(filter.ValueMatch);
                                    break;
                            }
                            break;
                        case Filter.InputType.DaysOld:
                            TimeSpan timeToRemove = new TimeSpan(int.Parse(filter.ValueMatch), 0, 0, 0);
                            DateTime compareDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(timeToRemove);

                            DateTime maxDate;

                            DateTime parseDate;
                            if (DateTime.TryParse(line[columnToSearch], out parseDate))
                            {
                                switch (filter.SelectedType)
                                {
                                    case Filter.Type.Equal:
                                        shouldWrite = parseDate.Date == compareDate.Date;
                                        break;
                                    case Filter.Type.NotEqual:
                                        shouldWrite = parseDate.Date != compareDate.Date;
                                        break;
                                    case Filter.Type.Greater:
                                        shouldWrite = compareDate.Date > parseDate.Date;
                                        break;
                                    case Filter.Type.Lesser:
                                        shouldWrite = compareDate.Date < parseDate.Date;
                                        break;
                                    case Filter.Type.GreaterOrEqual:
                                        shouldWrite = compareDate.Date >= parseDate.Date;
                                        break;
                                    case Filter.Type.LesserOrEqual:
                                        shouldWrite = compareDate.Date <= parseDate.Date;
                                        break;
                                    case Filter.Type.Ranged:
                                        TimeSpan spanMax = new TimeSpan(int.Parse(filter.ValueMax), 0, 0, 0);
                                        maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).Subtract(spanMax);
                                        shouldWrite = parseDate.Date <= compareDate.Date && parseDate.Date >= maxDate.Date;
                                        break;
                                }
                            }
                            else
                            {
                                string errMsg = "Error parsing text into a date value.";
                                string msgDetail = $"Please check the column your searching contains only dates in dd/mm/yyyy format! (Line {curIndex})";
                                if (new AlertDialog(errMsg, msgDetail).ShowDialog() == DialogResult.OK)
                                {
                                    KillFlag = true;
                                    filter.KillFlag = true;
                                    return;
                                }
                            }
                            break;
                    }
                    if (shouldWrite)
                    {
                        if (filter.SelectedOutput == Filter.OutputType.Edit)
                        {
                            line[ParseCharsToInt(filter.EditColumn.ToCharArray(), line.Length)] = filter.EditValue;

                            input = ArrayToString(line, ',');
                        }

                        if (filter.SelectedOutput == Filter.OutputType.Insert)
                        {
                            int colToIns = ParseCharsToInt(filter.EditColumn.ToCharArray(), line.Length);
                            string[] newLine = new string[line.Length + 1];
                            int newLen = newLine.Length;

                            for(int i = 0; i<newLen; i++)
                            {
                                if (i < colToIns)
                                {
                                    newLine[i] = line[i];
                                }
                                else if(i == colToIns)
                                {
                                    newLine[i] = filter.EditValue;
                                }
                                else if(i > colToIns)
                                {
                                    newLine[i] = line[i - 1];
                                }
                            }
                            input = ArrayToString(newLine, ',');
                        }

                        filter.FilterWriter.WriteLine(input);
                    }

                    if (filter.SaveAll && !shouldWrite)
                    {
                        if(filter.SelectedOutput == Filter.OutputType.Insert)
                        {
                            int colToIns = ParseCharsToInt(filter.EditColumn.ToCharArray(), line.Length);
                            string[] newLine = new string[line.Length + 1];
                            int newLen = newLine.Length;
                            for (int i = 0; i < newLen; i++)
                            {
                                if (i < colToIns)
                                {
                                    newLine[i] = line[i];
                                }
                                else if (i == colToIns)
                                {
                                    newLine[i] = "";
                                }
                                else if (i > colToIns)
                                {
                                    newLine[i] = line[i - 1];
                                }
                            }
                            input = ArrayToString(newLine, ',');
                        }
                        filter.FilterWriter.WriteLine(input);
                    }
                }
            }

            string ArrayToString (string[] array, char delim)
            {
                string output = "";
                foreach(string entry in array)
                {
                    output += $"{entry}{delim}";
                }
                return output.Substring(0, output.Length - 1);
            }

            int ParseCharsToInt(char[] columnChars, int len)
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

                if (len <= columnToSearch)
                {
                    string errMsg = "Error Parsing CSV.";
                    string msgDetail = $"The selected column \"{filter.SelectedColumn}\" in filter \"{filter.DisplayName}\" is not found in this CSV file!";
                    if (new AlertDialog(errMsg, msgDetail).ShowDialog() == DialogResult.OK)
                    {
                        KillFlag = true;
                        filter.KillFlag = true;
                        return -1;
                    }
                }

                return columnToSearch;
            }
        }
    }
}
