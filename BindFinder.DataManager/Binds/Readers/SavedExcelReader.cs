using BindFinder.AppModels.Binds;
using Geocoding;
using Ookii.Dialogs;
using System.Collections.Generic;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;

namespace BindFinder.DataManager.Binds.Readers
{
    class SavedExcelReader : UsingExcel.ExcelApplication, IProcessor
    {
        private ProgressDialog ProgressDialog;
        private string excelFile;

        public SavedExcelReader(string excelFile)
        {
            this.excelFile = excelFile;
        }

        public void StartProcess(ProgressDialog dialog, DoWorkEventArgs e)
        {
            this.ProgressDialog = dialog;
            List<Bind> binds = new List<Bind>();

            ProgressDialog.ReportProgress(-1, null, "Импорт данных..", null);
            InitializeExcelApplication();
            xlWorkBook = OpenWorkbook(this.excelFile);

            try
            {
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
                Excel.Range workRange = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                int lastRow = workRange.Row;
                int firstRow = 2;
                int bindsCount = lastRow - firstRow + 1;
                int done = 0;
                this.ProgressDialog.Maximum = bindsCount;

                for (int i = firstRow; i <= lastRow; i++)
                {
                    Bind bind = new Bind();
                    bind.OriginalAddress = xlWorkSheet.Range["A" + i].Value?.ToString();
                    bind.Description = xlWorkSheet.Range["K" + i].Value?.ToString();

                    string country = string.Empty, region = string.Empty, city = string.Empty, district = string.Empty, street = string.Empty, streetNumber = string.Empty, zip = string.Empty, placeId = string.Empty;
                    country = xlWorkSheet.Range["D" + i].Value?.ToString();
                    region = xlWorkSheet.Range["E" + i].Value?.ToString();
                    city = xlWorkSheet.Range["F" + i].Value?.ToString();
                    district = xlWorkSheet.Range["G" + i].Value?.ToString();
                    street = xlWorkSheet.Range["H" + i].Value?.ToString();
                    streetNumber = xlWorkSheet.Range["I" + i].Value?.ToString();
                    zip = xlWorkSheet.Range["J" + i].Value?.ToString();
                    placeId = xlWorkSheet.Range["M" + i].Value?.ToString();

                    string formatted = $"{country}, {city}, {street}, {streetNumber}".TrimEnd(',', ' ');

                    string latlon = xlWorkSheet.Range["B" + i].Value.ToString() + "," + xlWorkSheet.Range["C" + i].Value.ToString();
                    if (Location.TryParse(latlon, out Location location))
                    {
                        BindAddress address = new BindAddress(formatted, location, "Google")
                        {
                            Country = country,
                            Region = region,
                            City = city,
                            District = district,
                            Street = street,
                            StreetNumber = streetNumber,
                            Zip = zip,
                            PlaceId = placeId
                        };

                        bind.Address = address;
                        binds.Add(bind);
                        done++;
                        ProgressDialog.ReportProgress(done, null, $"Обработано строк: {done} / {bindsCount}", null);
                    }
                    else
                    {
                        throw new System.Exception("Ошибка чтения координат в строке " + i.ToString());
                    }
                }
                e.Result = binds;
            }
            finally
            {
                xlWorkBook.Close();
                ExitExcelApplication();
            }
        }
    }
}
