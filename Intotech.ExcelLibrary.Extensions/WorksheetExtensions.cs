using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intotech.ExcelLibrary.Extensions;

public static class WorksheetExtensions
{
    public static void AddRow(this Worksheet wSheet, List<string> items)
    {
        int i = wSheet.Cells.Rows.Count;

        for (int j = 0; j < items.Count(); j++)
        {
            wSheet.Cells[i, j] = new Cell(items[j]);
        }
    }

    public static void FillWorksheet(this Worksheet wSheet, List<List<string>> items)
    {
        foreach (List<string> item in items)
        {
            wSheet.AddRow(item);
        }
    }

    public static void PopulateWorksheets(this Workbook wb, Dictionary<string, List<List<string>>> workbookData)
    {
        foreach (KeyValuePair<string, List<List<string>>> item in workbookData)
        {
            Worksheet wSheet = new Worksheet(item.Key);

            wSheet.FillWorksheet(item.Value);

            wb.Worksheets.Add(wSheet);
        }
    }
}