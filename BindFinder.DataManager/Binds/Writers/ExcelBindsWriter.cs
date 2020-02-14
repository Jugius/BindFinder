using BindFinder.AppModels.Binds;
using BindFinder.DataManager.UsingExcel;
using Ookii.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace BindFinder.DataManager.Binds.Writers
{
    class ExcelBindsWriter : UsingExcel.ExcelApplication, IProcessor
    {
        private readonly List<Bind> binds;

        public ExcelBindsWriter(List<Bind> binds)
        {
            this.binds = binds;
        }

        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            int count = dialog.Maximum = binds.Count;
            int done = 0;
            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            dialog.ReportProgress(-1, null, "Экспорт данных..", null);

            InitializeExcelApplication();

            xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            xlApp.ActiveWindow.DisplayGridlines = false;

            try
            {
                var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];

                OfficeHelper.FormatExportBindsPage(xlWorkSheet);

                int rowNumber = 2;
                foreach (var bind in binds)
                {
                    xlWorkSheet.Range["A" + rowNumber].Value = bind.OriginalAddress;
                    xlWorkSheet.Range["B" + rowNumber].Value = bind.Address.Coordinates.Latitude.ToString(formatter);
                    xlWorkSheet.Range["C" + rowNumber].Value = bind.Address.Coordinates.Longitude.ToString(formatter);
                    xlWorkSheet.Range["D" + rowNumber].Value = bind.Address.Country;
                    xlWorkSheet.Range["E" + rowNumber].Value = bind.Address.Region;
                    xlWorkSheet.Range["F" + rowNumber].Value = bind.Address.City;
                    xlWorkSheet.Range["G" + rowNumber].Value = bind.Address.District;
                    xlWorkSheet.Range["H" + rowNumber].Value = bind.Address.Street;
                    xlWorkSheet.Range["I" + rowNumber].Value = bind.Address.StreetNumber;
                    xlWorkSheet.Range["J" + rowNumber].Value = "'" + bind.Address.Zip;
                    xlWorkSheet.Range["K" + rowNumber].Value = bind.Description;
                    xlWorkSheet.Hyperlinks.Add(Anchor: xlWorkSheet.Range["L" + rowNumber], Address: GetLink(bind), TextToDisplay: "Карта");
                    xlWorkSheet.Range["M" + rowNumber].Value = bind.Address.PlaceId;

                    rowNumber++;
                    done++;
                    dialog.ReportProgress(done, null, $"Выполнено: {done}/{count}");
                }
            }
            finally
            {
                ExitExcelApplication(false);
            }
        }
        private string GetLink(Bind bind)
        {
            return @"https://www.google.com/maps/search/" + bind.Address.Coordinates.ToString();
        }
    }
}
