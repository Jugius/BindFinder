using BindFinder.AppModels.Binds;
using BindFinder.DataManager.UsingExcel;
using Ookii.Dialogs;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace BindFinder.DataManager.Boards.Writers
{
    class ExcelBoardsWriter : UsingExcel.ExcelApplication, IProcessor
    {
        private readonly List<Bind> binds;
        public ExcelBoardsWriter(List<Bind> binds)
        {
            this.binds = binds;
        }
        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            int count = dialog.Maximum = binds.SelectMany(a => a.BindedBoards).Count(a => a.IsChecked);
            int done = 0;
            dialog.ReportProgress(-1, null, "Экспорт данных..", null);

            InitializeExcelApplication();

            xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            xlApp.ActiveWindow.DisplayGridlines = false;

            try
            {
                var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
                OfficeHelper.FormatExportBoardsPage(xlWorkSheet);

                int rowNumber = 2;
                foreach (var bind in binds)
                {
                    string bindAddress = bind.Address.FormattedAddress;
                    string bindDescription = string.IsNullOrEmpty(bind.Description) ? bind.OriginalAddress : bind.Description;
                    System.Drawing.Color bindColor = bind.Color;

                    foreach (var board in bind.BindedBoards)
                    {
                        if (!board.IsChecked) continue;

                        string poiMap = @"https://www.google.com/maps/dir/" + bind.Address.Coordinates.ToString() + @"/" + board.Location.ToString();

                        var distance = (int)(bind.Address.Coordinates.DistanceBetween(board.Location, Geocoding.DistanceUnits.Kilometers).Value * 1000);

                        xlWorkSheet.Range["A" + rowNumber].Value = board.Address.City;
                        xlWorkSheet.Range["B" + rowNumber].Value = board.Supplier;
                        xlWorkSheet.Range["C" + rowNumber].Value = board.Address.Street;
                        xlWorkSheet.Range["D" + rowNumber].Value = board.Address.StreetNumber;
                        xlWorkSheet.Range["E" + rowNumber].Value = board.Address.Description;
                        xlWorkSheet.Range["F" + rowNumber].Value = board.Type;
                        xlWorkSheet.Range["G" + rowNumber].Value = board.Size;
                        xlWorkSheet.Range["H" + rowNumber].Value = board.Side;
                        if (board.Metrics != null)
                        {
                            xlWorkSheet.Range["I" + rowNumber].Value = board.Metrics.OTS;
                            xlWorkSheet.Range["J" + rowNumber].Value = string.Format("{0:0.00}", board.Metrics.GRP);
                        }
                        xlWorkSheet.Range["K" + rowNumber].Value = board.Code;
                        xlWorkSheet.Range["L" + rowNumber].Value = board.ID;
                        if (board.Lighting)
                            xlWorkSheet.Range["M" + rowNumber].Value = @"*";
                        if (!string.IsNullOrEmpty(board.URL_Photo))
                        {
                            xlWorkSheet.Hyperlinks.Add(Anchor: xlWorkSheet.Range["N" + rowNumber], Address: board.URL_Photo, TextToDisplay: "Фото");
                            xlWorkSheet.Range["N" + rowNumber].Font.Size = 9;
                        }
                        if (!string.IsNullOrEmpty(board.URL_Map))
                        {
                            xlWorkSheet.Hyperlinks.Add(Anchor: xlWorkSheet.Range["O" + rowNumber], Address: board.URL_Map, TextToDisplay: "Схема");
                            xlWorkSheet.Range["O" + rowNumber].Font.Size = 9;
                        }

                        xlWorkSheet.Hyperlinks.Add(Anchor: xlWorkSheet.Range["P" + rowNumber], Address: poiMap, TextToDisplay: "Карта");
                        xlWorkSheet.Range["P" + rowNumber].Font.Size = 9;

                        xlWorkSheet.Range["Q" + rowNumber].Value = distance;

                        xlWorkSheet.Range["R" + rowNumber].Value = bindAddress;                        
                        xlWorkSheet.Range["S" + rowNumber].Value = bindDescription;
                        xlWorkSheet.Range["R" + rowNumber].Font.Color = xlWorkSheet.Range["S" + rowNumber].Font.Color = System.Drawing.ColorTranslator.ToOle(bindColor);


                        rowNumber++;
                        done++;
                        dialog.ReportProgress(done, null, $"Выполнено: {done}/{count}");
                    }
                }
            }
            finally
            {
                ExitExcelApplication(false);
            }
        }
    }
}
