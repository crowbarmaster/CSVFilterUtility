# CSVParserExcel

********** CSV Filtering utility for Excel **********

Written by Tad Tarrant. (aka Crowbarmaster).
Created for my lovely wife, to her specifications.

This is a utility created to filter a CSV by column
entries. There were a couple goals at hand to start
with. This utility needed to:
```
  -Filter a CSV file with speed and accuracy.
  -Run in a resource-starved enviornment.
  -Optionally, run as an Excel add-in. 
```
The current result is still beta, however exceeds
expectations. A single filter has seen speeds of 
almost 14,000 lines-per-second. The process is simple.
A line is read and split to an array. Then the selected
search column's value is then compared to an assortment 
of different opperations available to filter by. Once a
match is made, the user can opt to edit a column with a
static value, or insert a new column with a specified 
value. This value can be specified as a numeric value,
a string of plain text, or "value is xxx days old". 

Numeric values and date comparisons can be compared in
the following ways:
```
  -Equal to  
  -Not equal to 
  -Greater than 
  -Less than 
  -Greater than or equal to
  -Less than or equal to
  -Witin a range (Column value is greater than or equal
  to selected minimum, but less than or equal to selected
  maximum.)
```
Column values searched for in "Plain text mode" will have
the following options:
```
  -Equal to
  -Not equal to
  -Starts with
  -Contains
  *** Note: Plain text filters must match case and any 
  special characters! ***
```
Edited filters can optionally save unmatched
lines if desired. Multi-filtered searches can be merged
to one CSV file if desired. 

*** NOTE: Care should be taken if "Merge filters after
filtering" option is used! If every filter does not 
produce unique results, Duplicates will happen! 
Filters that edit a newly inserted column will produce 
blanks if used with the "Save all lines" function! ***

If desired, a list of filters can be saved, and retrieved
later. This will be found useful for reports that require
extensive filtering in the same manner each time.

There are plans to add a few settable defaults for default
directories and filter options. Stay tuned!
