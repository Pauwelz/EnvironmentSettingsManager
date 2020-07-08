﻿// (c) Copyright 2007-20 Thomas F. Abraham.
// This source is subject to the Microsoft Public License (Ms-PL).
// See http://www.opensource.org/licenses/ms-pl.html
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace EnvironmentSettingsExporter
{
    internal static class SettingsFileReader
    {
        /// <summary>
        /// Read the contents of the Settings worksheet in the specified Excel file into a DataTable.
        /// Excel files up to Excel 2000 and SpreadsheetML XML 2000 files are both supported.
        /// </summary>
        /// <param name="inputFile">Path to the XLS or XML file</param>
        /// <returns></returns>
        internal static DataTable ReadSettingsFromExcelFile(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException("The specified input file " + inputFile + " does not exist.", inputFile);
            }

            DataTable dt = null;
            string fileExtension = Path.GetExtension(inputFile);

            if (string.Compare(fileExtension, ".xls", true) == 0 || string.Compare(fileExtension, ".xlsx", true) == 0)
            {
                dt = ExcelBinarySettingsFileReader.ReadSettingsFromXls(inputFile);
            }
            else
            {
                dt = SpreadsheetMlSettingsFileReader.ReadSettingsFromSpreadsheetMl(inputFile);
            }

            return dt;
        }
    }
}
